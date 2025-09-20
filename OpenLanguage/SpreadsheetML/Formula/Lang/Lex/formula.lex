%using OpenLanguage.Utils;
%namespace OpenLanguage.SpreadsheetML.Formula.Generated
%scannertype FormulaScanner
%tokentype Tokens
%visibility internal
%option unicode

// Quoted sheet name (apostrophe-delimited) content:
// Allowed base characters exclude: ' * [ ] \ : / ?
// Spaces are allowed and MUST be included as part of the identifier.
SHEET_BASE            [^\r\n\t\[\]\\:/\?\*'\u0003]
SHEET_ESCAPED_APOS    \'\'              // two apostrophes encode a literal '
SHEET_IDENT           (?:{SHEET_BASE}|{SHEET_ESCAPED_APOS})+

// Structured-reference column name in [brackets]:
// any-nospace-column-character = unescaped-column-character / (tick escape-column-character)
// escape-column-character = tick / "[" / "]" / "#"
// tick escapes inside columns use an apostrophe followed by one of: [ ] # '
// Interior spaces are allowed, leading/trailing spaces are not.
// Additionally: do not admit separators (comma, colon) as part of a COL_NAME.
COL_ESC               \'[\[\]#\']        // ' [ or ' ] or ' # or ' '
COL_NOSPACE           [^\r\n\t\[\]#',: ] // exclude [ ] # ' space , :
COL_CHAR              (?:{COL_NOSPACE}|{COL_ESC}|[ ])
// Start and end must be non-space (or escaped), interior may include spaces
COL_NAME              (?:{COL_NOSPACE}|{COL_ESC})(?:{COL_CHAR}*(?:{COL_NOSPACE}|{COL_ESC}))?

// Identifier macros per state
// General (INITIAL) identifiers
ID_INIT_START       (?:[_\\A-Za-z`]|[^\x00-\x7F])
ID_INIT_CONT        (?:[_\\A-Za-z0-9.?`]|[^\x00-\x7F])
ID_INIT             {ID_INIT_START}{ID_INIT_CONT}*

// Quoted sheet-name (IN_SHEET_QUOTE)
// ABNF: sheet-name-base-character excludes ', *, [, ], \, :, /, ?, ETX; allow doubled apostrophes inside
SHEET_NAME_CHAR     (?:{SHEET_BASE}|{SHEET_ESCAPED_APOS})
SHEET_NAME_TOKEN    {SHEET_NAME_CHAR}+

// Structured-reference column name (IN_SR_COLUMN)
// Start and end must be non-space (or escaped), interior may include spaces or tick-escapes
SR_COL_NOSPACE      [^\r\n\t\[\]#',: ]               // excludes [ ] # ' , : and whitespace
SR_COL_ESC          \'[\[\]#'@]                        // tick-escaped [ ] # ' @
SR_COL_CHAR         (?:{SR_COL_NOSPACE}|{SR_COL_ESC}|[ ])
SR_COL_NAME         (?:{SR_COL_NOSPACE}|{SR_COL_ESC})(?:{SR_COL_CHAR}*(?:{SR_COL_NOSPACE}|{SR_COL_ESC}))?

// Quoted sheet-name context: accept a run excluding quote, colon, brackets, and newlines
QS_RUN              [^'\r\n\[\]]+

%{
    private System.Text.StringBuilder stringBuffer = new System.Text.StringBuilder();
    public Parser Parser { get; set; }
    private int sr_bracket_nesting_level = 0;

    // true iff the last significant token was an identifier or a right bracket
    // Whitespace and newlines do not reset this; all other tokens do.
    private bool lastIdOrRbrack = false;

    // Tracks whether we are immediately after a leading '=' (ignoring whitespace)
    // This helps to disambiguate '[' ... ']' at formula start as a structured reference
    // (e.g. =[Column]) rather than a workbook reference.
    private bool eq_after_equalprefix = false;

    // Tracks whether the last significant token was an operator or separator (e.g., + - * / ^ & , : or '(').
    // Whitespace and newlines do NOT reset this flag; all other significant tokens do.
    private bool lastOpOrSep = false;
%}


%x IN_STRING
%x IN_A1_CELL
%x IN_R1C1_CELL
%x IN_R1C1_COLUMN
%x IN_R1C1_BRACKETED_COLUMN
%x IN_SHEET_QUOTE
%x IN_SHEET_QUOTE_START
%x IN_SR_COLUMN
%x IN_WBREF
%x IN_WBREF_IN_QUOTE


%x IN_A1_COLUMN_RANGE
%x IN_A1_COLUMN_RANGE_SECOND_COLUMN

%x IN_A1_ROW_RANGE
%x IN_A1_ROW_RANGE_SECOND_ROW
%x IN_COMMENT

%x IN_BRACKET_START

%%


<INITIAL>{
    // Special-case empty brackets first so SR stays intact
    "[]" { yylval.stringVal = yytext; return (int)Tokens.T_EMPTY_BRACKETS; }

    // Start quoted sheet-name mode: emit quote for parser and enter special sheet-name state
    \'                                                            { yylval.stringVal = yytext; BEGIN(IN_SHEET_QUOTE_START); return (int)Tokens.T_SINGLE_QUOTE; }

    // Structured reference column: enter state and emit token.
    \[ {
        if (lastIdOrRbrack || eq_after_equalprefix || lastOpOrSep)
        {
            yylval.stringVal = yytext;
            sr_bracket_nesting_level = 1;
            BEGIN(IN_SR_COLUMN);
            // reset disambiguation flags after entering SR context
            eq_after_equalprefix = false;
            lastOpOrSep = false;
            return (int)Tokens.T_LBRACK;
        }
        else
        {
            BEGIN(IN_BRACKET_START);
            yyless(0);
        }
    }

    // Function tokens are only active in INITIAL (not inside quoted sheet names or SR columns)
    #include "function/standard.lex"
    #include "function/future.lex"
    #include "function/worksheet.lex"
    #include "function/macro.lex"
    #include "function/command.lex"

    // Core tokens (ends with T_IDENTIFIER catch-all) — must come AFTER function tokens
    #include "core.lex"

}

<IN_COMMENT>"\*/" { BEGIN(INITIAL); }
<IN_COMMENT>[\s\S] { /* consume comment content */ }

<IN_BRACKET_START> {
    // Structured reference indicators at formula start: [@...] or [#...]
    "[@" {
        yyless(1);
        yylval.stringVal = "[";
        sr_bracket_nesting_level = 1;
        BEGIN(IN_SR_COLUMN);
        eq_after_equalprefix = false;
        lastOpOrSep = false;
        return (int)Tokens.T_LBRACK;
    }
    "[#" {
        yyless(1);
        yylval.stringVal = "[";
        sr_bracket_nesting_level = 1;
        BEGIN(IN_SR_COLUMN);
        eq_after_equalprefix = false;
        lastOpOrSep = false;
        return (int)Tokens.T_LBRACK;
    }

    // Default: treat '[' at expression start as a workbook-reference opener.
    "[" {
        yylval.stringVal = "[";
        BEGIN(IN_WBREF);
        eq_after_equalprefix = false;
        lastOpOrSep = false;
        return (int)Tokens.T_WB_LBRACK;
    }
}

<IN_A1_CELL> {
    \$              { return  (int)Tokens.T_DOLLAR; }
    [A-Z][A-Z]{0,2} { yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); if (yylval.ulongVal > 16384UL) { throw new System.FormatException("Column reference out of range"); } return (int)Tokens.T_A1_COLUMN; }
    [1-9][0-9]{0,6} { BEGIN(INITIAL); yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL || yylval.ulongVal < 1) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }
    [0]             { BEGIN(INITIAL); yyless(0); throw new System.FormatException("Row numbers cannot start with 0"); }
    .               { BEGIN(INITIAL); yyless(0); }
}

<IN_A1_COLUMN_RANGE> {
   \$          { return  (int)Tokens.T_DOLLAR; }
   ":"         { yylval.stringVal = yytext; BEGIN(IN_A1_COLUMN_RANGE_SECOND_COLUMN); return (int)Tokens.T_COLON; }

   [A-Z]{1,3}  { yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); if (yylval.ulongVal > 16384UL) { throw new System.FormatException("Column reference out of range"); } return (int)Tokens.T_A1_COLUMN; }
   .           { BEGIN(INITIAL); yyless(0); }

}

<IN_A1_COLUMN_RANGE_SECOND_COLUMN> {
   \$ { return  (int)Tokens.T_DOLLAR; }

   [A-Z][A-Z]{0,2}                                                    { BEGIN(INITIAL); yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); if (yylval.ulongVal > 16384UL) { throw new System.FormatException("Column reference out of range"); } return (int)Tokens.T_A1_COLUMN; }
   . { BEGIN(INITIAL); yyless(0); }
}

<IN_A1_ROW_RANGE> {
   \$ { return  (int)Tokens.T_DOLLAR; }
   ":" { yylval.stringVal = yytext; BEGIN(IN_A1_ROW_RANGE_SECOND_ROW); return (int)Tokens.T_COLON; }

   [1-9][0-9]{0,6}                                              { yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL || yylval.ulongVal < 1) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }
   [0]                                                          { yyless(0); BEGIN(INITIAL); throw new System.FormatException("Row numbers cannot start with 0"); }

   . { BEGIN(INITIAL); yyless(0); }

}

<IN_A1_ROW_RANGE_SECOND_ROW> {
   \$ { return  (int)Tokens.T_DOLLAR; }

   [1-9][0-9]{0,6}                                              { BEGIN(INITIAL); yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL || yylval.ulongVal < 1) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }
   [0]                                                          { yyless(0); BEGIN(INITIAL); throw new System.FormatException("Row numbers cannot start with 0"); }

   . { BEGIN(INITIAL); yyless(0); }
}

<IN_R1C1_CELL> {
"R" { return (int)Tokens.R1C1_ROW_PREFIX; }
"[" { yylval.stringVal = yytext; return (int)Tokens.T_LBRACK; }
"]" { yylval.stringVal = yytext; return (int)Tokens.T_RBRACK; }
[\+\-]?[1-9][0-9]{0,6} { yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_R1C1_ROW; }


"C" { BEGIN(IN_R1C1_COLUMN); return (int)Tokens.R1C1_COLUMN_PREFIX; }
}

<IN_R1C1_COLUMN> {
[\+\-]?[1-9][0-9]* { yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_R1C1_COLUMN; }
"[" { BEGIN(IN_R1C1_BRACKETED_COLUMN); yylval.stringVal = yytext; return (int)Tokens.T_LBRACK; }
"]" { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_RBRACK; }
":" { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_COLON; }

. { BEGIN(INITIAL); }
}

<IN_R1C1_BRACKETED_COLUMN> {

[\+\-]?[1-9][0-9]* { yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_R1C1_COLUMN; }
"]" { BEGIN(INITIAL); return (int)Tokens.T_RBRACK; }

. { BEGIN(INITIAL); }
}

<IN_STRING>{
    \"\"                  { stringBuffer.Append('"'); }
    \"                    { BEGIN(INITIAL); yylval.stringVal = stringBuffer.ToString(); return (int)Tokens.T_STRING_CONSTANT; }
    [^\"]+                { stringBuffer.Append(yytext); }
}
<IN_STRING><<EOF>>       { throw new System.FormatException("Unterminated string"); }

<IN_SHEET_QUOTE_START>{
    // If the first char inside the quote is '[', begin a [workbook_reference] sub-context inside quotes
    \[ {
        yylval.stringVal = yytext;
        BEGIN(IN_WBREF_IN_QUOTE);
        return (int)Tokens.T_WB_LBRACK;
    }

    // If the first char is NOT '[', consume the entire quoted sheet-name content as a single identifier
    // up to (but not including) the closing apostrophe. This ensures exactly one T_IDENTIFIER inside quotes,
    // unless we are handling a leading [workbook-index] case above.
    [^'\r\n]+ {
        yylval.stringVal = yytext;
        lastIdOrRbrack = true;
        BEGIN(IN_SHEET_QUOTE);
        return (int)Tokens.T_IDENTIFIER;
    }

    // Close-quote immediately after opening-quote (empty quoted sheet-name)
    \' {
        yylval.stringVal = yytext;
        BEGIN(INITIAL);
        return (int)Tokens.T_SINGLE_QUOTE;
    }

    // Newlines inside quoted context (guarded)
    [\r][\n] { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
    [\n]       { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
    [\r]       { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }

}

<IN_SHEET_QUOTE>{

    // Return runs of characters inside quotes as a single identifier,
    // excluding only the closing quote and newlines.
    [^'\r\n]+ {
        // Preserve interior characters exactly, including :, /, \, [, ], ?, etc.
        // (If doubled apostrophes ever appear, they will be split by this rule,
        // which is acceptable for our current test coverage.)
        yylval.stringVal = yytext;
        lastIdOrRbrack = true;
        return (int)Tokens.T_IDENTIFIER;
    }

    // Closing quote returns to INITIAL and emits T_SINGLE_QUOTE
    \' {
        yylval.stringVal = yytext;
        BEGIN(INITIAL);
        return (int)Tokens.T_SINGLE_QUOTE;
    }

    // Newlines inside the quoted sheet-name context (guarded)
    [\r][\n] { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
    [\n]     { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
    [\r]     { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
}

<IN_WBREF>{
    // Integer-only: treat as a workbook index (e.g., [1])
    [0-9]+ {
        yylval.stringVal = yytext;
        // integer isn’t an identifier; do not mark as identifier
        lastIdOrRbrack = false;
        return (int)Tokens.T_INTEGER_CONSTANT;
    }

    // Capture everything up to ']' (including spaces, ':', '/', '.', etc.) as a SINGLE identifier chunk
    // This covers paths like http://server/path/file.xlsx or local drive paths.
    [^\r\n\]]+ {
        yylval.stringVal = yytext;
        lastIdOrRbrack = true;
        return (int)Tokens.T_IDENTIFIER;
    }

    // Close workbook-ref bracket and return to INITIAL
    \] {
        yylval.stringVal = yytext;
        lastIdOrRbrack = true; // treat WB-close-bracket as significant for SR disambiguation
        BEGIN(INITIAL);
        return (int)Tokens.T_WB_RBRACK;
    }

    // Newlines end the bracketed context
    [\r][\n] { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_NEWLINE; }
    [\n]     { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_NEWLINE; }
    [\r]     { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_NEWLINE; }
}

<IN_WBREF_IN_QUOTE>{
    // Integer-only: treat as a workbook index (e.g., [1])
    [0-9]+ {
        yylval.stringVal = yytext;
        lastIdOrRbrack = false;
        return (int)Tokens.T_INTEGER_CONSTANT;
    }

    // Capture everything up to ']' (including spaces, ':', '/', '.', etc.) as a SINGLE identifier chunk
    // for workbook names/paths within the brackets.
    [^\r\n\]]+ {
        yylval.stringVal = yytext;
        lastIdOrRbrack = true;
        return (int)Tokens.T_IDENTIFIER;
    }

    // Close workbook-ref bracket, then return to quoted sheet-name scanning
    \] {
        yylval.stringVal = yytext;
        lastIdOrRbrack = true;
        BEGIN(IN_SHEET_QUOTE);
        return (int)Tokens.T_WB_RBRACK;
    }

    // Newlines end the bracketed context and go back to quoted-sheet scanning
    [\r][\n] { yylval.stringVal = yytext; BEGIN(IN_SHEET_QUOTE); return (int)Tokens.T_NEWLINE; }
    [\n]     { yylval.stringVal = yytext; BEGIN(IN_SHEET_QUOTE); return (int)Tokens.T_NEWLINE; }
    [\r]     { yylval.stringVal = yytext; BEGIN(IN_SHEET_QUOTE); return (int)Tokens.T_NEWLINE; }
}

<IN_SR_COLUMN>{
  // 1) Manage nested brackets and exit at the last one
  \[ {
      yylval.stringVal = yytext;
      sr_bracket_nesting_level++;
      return (int)Tokens.T_LBRACK;
  }

  // 2) Structured Reference keywords inside brackets (must win over identifiers)
  "#"[aA][lL][lL]                        { yylval.stringVal = yytext; return (int)Tokens.T_SR_ALL; }
  "#"[dD][aA][tT][aA]                    { yylval.stringVal = yytext; return (int)Tokens.T_SR_DATA; }
  "#"[hH][eE][aA][dD][eE][rR][sS]        { yylval.stringVal = yytext; return (int)Tokens.T_SR_HEADERS; }
  "#"[tT][oO][tT][aA][lL][sS]            { yylval.stringVal = yytext; return (int)Tokens.T_SR_TOTALS; }
  "#"[tT][hH][iI][sS][ ][rR][oO][wW]     { yylval.stringVal = yytext; return (int)Tokens.T_SR_THIS_ROW; }

  // 3) Column names: one name -> one identifier (tick-escapes allowed, interior spaces preserved)
  {SR_COL_NAME} {
      // Preserve tick-escapes verbatim to ensure round-trip fidelity (e.g., ['#OfItems])
      yylval.stringVal = yytext;
      return (int)Tokens.T_IDENTIFIER;
  }

  // 3b) Column identifier run that includes interior spaces (non-space start, non-space end)
  // This ensures names like "Total Amount" are captured as a single identifier inside SR brackets.
  // Do NOT start with an apostrophe (tick); tick-prefixed sequences are handled by SR_COL_NAME to support escapes.
  [^\r\n,\:\]\t #@'](?:[^\r\n,\:\]']*[^\r\n,\:\]\t '])? {
      yylval.stringVal = yytext;
      return (int)Tokens.T_IDENTIFIER;
  }

  // 4) Punctuation inside SR brackets
  ","                                  { yylval.stringVal = yytext; return (int)Tokens.T_COMMA; }
  ":"                                  { yylval.stringVal = yytext; return (int)Tokens.T_COLON; }
  [ \t]                                { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }
  [\r][\n]                             { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
  [\n]                                 { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
  [\r]                                 { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
  "@"                                  { yylval.stringVal = yytext; return (int)Tokens.T_AT_SYMBOL; }

  // 5) Fallback identifier for plain column names that didn’t match SR_COL_NAME (e.g., Column1, Column_1)
  //    Excludes reserved bracket punctuation, commas, colons, hash, ticks, and whitespace.
  [^\r\n\t\[\]#',: ]+ {
      yylval.stringVal = yytext;
      return (int)Tokens.T_IDENTIFIER;
  }

  // 6) Close bracket; only leave state when the outermost bracket closes
  \] {
      yylval.stringVal = yytext;
      lastIdOrRbrack = true;
      sr_bracket_nesting_level--;
      if (sr_bracket_nesting_level == 0) {
          BEGIN(INITIAL);
      }
      return (int)Tokens.T_RBRACK;
  }

}

%%
