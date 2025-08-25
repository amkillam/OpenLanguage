%using OpenLanguage.Utils;
%namespace OpenLanguage.SpreadsheetML.Formula.Generated
%scannertype FormulaScanner
%tokentype Tokens
%visibility internal

%{
    private System.Text.StringBuilder stringBuffer = new System.Text.StringBuilder();
    public Parser Parser { get; set; }
%}


%x IN_STRING
%x IN_QUOTED_SHEET_NAME
%x IN_A1_CELL
%x IN_R1C1_CELL
%x IN_R1C1_COLUMN
%x IN_R1C1_BRACKETED_COLUMN


%x IN_A1_COLUMN_RANGE
%x IN_A1_COLUMN_RANGE_SECOND_COLUMN

%x IN_A1_ROW_RANGE
%x IN_A1_ROW_RANGE_SECOND_ROW
%x IN_COMMENT

%%


<INITIAL>{

    "<>"                { return (int)Tokens.T_NE; }
    ">="                { return (int)Tokens.T_GE; }
    "<="                { return (int)Tokens.T_LE; }


    "#All"             { return (int)Tokens.T_SR_ALL; }
    "#Data"            { return (int)Tokens.T_SR_DATA; }
    "#Headers"         { return (int)Tokens.T_SR_HEADERS; }
    "#Totals"          { return (int)Tokens.T_SR_TOTALS; }
    "#This Row"        { return (int)Tokens.T_SR_THIS_ROW; }
    "[]"               { return (int)Tokens.T_EMPTY_BRACKETS; }


    "_xlfn\._xlws\."     { return (int)Tokens.T_XLFN_XLWS_; }
    "_xlfn\."            { return (int)Tokens.T_XLFN_; }
    "xlpm\."             { return (int)Tokens.T_XLPM_; }
    "xlop\."             { return (int)Tokens.T_XLOP_; }


    "#DIV/0!"           { yylval.stringVal = yytext; return (int)Tokens.T_DIV0_ERROR; }
    "#N/A"              { yylval.stringVal = yytext; return (int)Tokens.T_NA_ERROR; }
    "#NAME\?"           { yylval.stringVal = yytext; return (int)Tokens.T_NAME_ERROR; }
    "#NULL!"            { yylval.stringVal = yytext; return (int)Tokens.T_NULL_ERROR; }
    "#NUM!"             { yylval.stringVal = yytext; return (int)Tokens.T_NUM_ERROR; }
    "#VALUE!"           { yylval.stringVal = yytext; return (int)Tokens.T_VALUE_ERROR; }
    "#REF!"             { yylval.stringVal = yytext; return (int)Tokens.T_REF_ERROR; }
    "#GETTING_DATA"     { yylval.stringVal = yytext; return (int)Tokens.T_GETTING_DATA_ERROR; }
    "#SPILL!"           { yylval.stringVal = yytext; return (int)Tokens.T_SPILL_ERROR; }
    "#CALC!"            { yylval.stringVal = yytext; return (int)Tokens.T_CALC_ERROR; }
    "#BLOCKED!"         { yylval.stringVal = yytext; return (int)Tokens.T_BLOCKED_ERROR; }
    "#BUSY!"            { yylval.stringVal = yytext; return (int)Tokens.T_BUSY_ERROR; }
    "#CIRCULAR!"        { yylval.stringVal = yytext; return (int)Tokens.T_CIRCULAR_ERROR; }
    "#CONNECT!"         { yylval.stringVal = yytext; return (int)Tokens.T_CONNECT_ERROR; }
    "#EXTERNAL!"        { yylval.stringVal = yytext; return (int)Tokens.T_EXTERNAL_ERROR; }
    "#FIELD!"           { yylval.stringVal = yytext; return (int)Tokens.T_FIELD_ERROR; }
    "#PYTHON!"          { yylval.stringVal = yytext; return (int)Tokens.T_PYTHON_ERROR; }
    "#UNKNOWN!"         { yylval.stringVal = yytext; return (int)Tokens.T_UNKNOWN_ERROR; }

    "TRUE"              { yylval.boolVal = true; return (int)Tokens.T_TRUE; }
    "FALSE"             { yylval.boolVal = false; return (int)Tokens.T_FALSE; }

    #include "function/standard.lex"

    #include "function/future.lex"

    #include "function/worksheet.lex"

    #include "function/macro.lex"

    #include "function/command.lex"

    \"                  { stringBuffer.Clear(); BEGIN(IN_STRING); }
    \'                  { stringBuffer.Clear(); BEGIN(IN_QUOTED_SHEET_NAME); }

    "//".*             { /* skip single-line comment */ }
    "/\*"              { BEGIN(IN_COMMENT); }

    [\x2000-\x200A]+    { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; } // General punctuation spaces: en quad to hair space
    [\x202F]+           { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; } // Narrow no-break space
    [\x205F]+           { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; } // Medium mathematical space
    [\x3000]+           { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; } // Ideographic space
    [\x200B]+           { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; } // Zero-width space
    \s                  { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }
    [\r\n]+             { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE; }
    [\xA0]+             { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }


    [R]\[?[\+\-]?[1-9]{0,6}\]?[C]\[?[\+\-]?[1-9]{0,6}\]?                  { BEGIN(IN_R1C1_CELL); yyless(0); }
    \$?[A-Z][A-Z]{0,2}\$?[1-9][0-9]{0,6}                                  { BEGIN(IN_A1_CELL); yyless(0); }

    \$?[A-Z][A-Z]{0,2}:\$?[A-Z][A-Z]{0,2}                                                    { BEGIN(IN_A1_COLUMN_RANGE); yyless(0); }
    \$?[1-9][0-9]{0,6}:\$?[1-9][0-9]{0,6}                                              { BEGIN(IN_A1_ROW_RANGE); yyless(0); }




    [0-9]+\.[0-9]+\.[0-9]+                                { throw new System.FormatException("Invalid number format with multiple decimal points"); } // Invalid: 1.2.3
    [0-9]+[Ee][\+\-]?([0-9]+)?[Ee][\+\-]?([0-9]+)?             { throw new System.FormatException("Invalid scientific notation with multiple exponent"); } // Invalid: 1E2E3
    [0-9]+[Ee][\+\-]?                                     { throw new System.FormatException("Incomplete scientific notation"); } // Invalid: 1E, 1E+
    \.[Ee][0-9]+                                         { throw new System.FormatException("Invalid decimal point without digits"); } // Invalid: .E5
    ([0-9]+(\.[0-9]*)|\.[0-9]+)([Ee][\+\-]?([0-9]+))?    { yylval.stringVal = yytext; return (int)Tokens.T_NUMERICAL_CONSTANT; }
    [0-9]+[Ee][\+\-]?([0-9]+)                            { yylval.stringVal = yytext; return (int)Tokens.T_NUMERICAL_CONSTANT; }
    [0-9]+                                               { yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_LONG; }

    [a-zA-Z_\\`][a-zA-Z0-9_.?`]*                                    { yylval.stringVal = yytext; return (int)Tokens.T_IDENTIFIER; }


    "@" { yylval.stringVal = yytext; return (int)Tokens.T_AT_SYMBOL; } "+" { return (int)Tokens.T_PLUS; } "-" { return (int)Tokens.T_MINUS; } "*" { return (int)Tokens.T_ASTERISK; } "/" { return (int)Tokens.T_SLASH; } "^" { return (int)Tokens.T_CARET; } "&" { return (int)Tokens.T_AMPERSAND; } "%" { return (int)Tokens.T_PERCENT; } "=" { return (int)Tokens.T_EQ; } ">" { return (int)Tokens.T_GT; } "<" { return (int)Tokens.T_LT; } "(" { return (int)Tokens.T_LPAREN; } ")" { return (int)Tokens.T_RPAREN; } "{" { return (int)Tokens.T_LBRACE; } "}" { return (int)Tokens.T_RBRACE; } "[" { return (int)Tokens.T_LBRACK; } "]" { return (int)Tokens.T_RBRACK; } "," { return (int)Tokens.T_COMMA; } ":" { return (int)Tokens.T_COLON; } ";" { return (int)Tokens.T_SEMICOLON; } "!" { yylval.stringVal = "!"; return (int)Tokens.T_BANG; } "$" { return (int)Tokens.T_DOLLAR; } "#" { return (int)Tokens.T_HASH; } "?" { return (int)Tokens.T_QUESTIONMARK; }

    .                   { }
}

<IN_COMMENT>"\*/" { BEGIN(INITIAL); }
<IN_COMMENT>[\s\S] { /* consume comment content */ }

<IN_A1_CELL> {
    \$ { return  (int)Tokens.T_DOLLAR; }
    [A-Z][A-Z]{0,2}                                                    { yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); return (int)Tokens.T_A1_COLUMN; }
    [1-9][0-9]{0,6}                                              { BEGIN(INITIAL); yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_A1_ROW; }
    . { BEGIN(INITIAL); yyless(0); }
}

<IN_A1_COLUMN_RANGE> {
   \$ { return  (int)Tokens.T_DOLLAR; }
   ":" { BEGIN(IN_A1_COLUMN_RANGE_SECOND_COLUMN); return (int)Tokens.T_COLON; }

   [A-Z]{1,3}                                                    { yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); return (int)Tokens.T_A1_COLUMN; }
   . { BEGIN(INITIAL); yyless(0); }

}

<IN_A1_COLUMN_RANGE_SECOND_COLUMN> {
   \$ { return  (int)Tokens.T_DOLLAR; }

   [A-Z][A-Z]{0,2}                                                    { BEGIN(INITIAL); yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); return (int)Tokens.T_A1_COLUMN; }
   . { BEGIN(INITIAL); yyless(0); }
}

<IN_A1_ROW_RANGE> {
   \$ { return  (int)Tokens.T_DOLLAR; }
   ":" { BEGIN(IN_A1_ROW_RANGE_SECOND_ROW); return (int)Tokens.T_COLON; }

   [1-9][0-9]{0,6}                                              { yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_A1_ROW; }

   . { BEGIN(INITIAL); yyless(0); }

}

<IN_A1_ROW_RANGE_SECOND_ROW> {
   \$ { return  (int)Tokens.T_DOLLAR; }

   [1-9][0-9]{0,6}                                              { BEGIN(INITIAL); yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_A1_ROW; }

   . { BEGIN(INITIAL); yyless(0); }
}

<IN_R1C1_CELL> {
"R" { return (int)Tokens.R1C1_ROW_PREFIX; }
"[" { return (int)Tokens.T_LBRACK; }
"]" { return (int)Tokens.T_RBRACK; }
[\+\-]?[1-9]{0,6} { yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_R1C1_ROW; }


"C" { BEGIN(IN_R1C1_COLUMN); return (int)Tokens.R1C1_COLUMN_PREFIX; }
}

<IN_R1C1_COLUMN> {
[\+\-]?[1-9]+ { BEGIN(INITIAL); yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_R1C1_COLUMN; }
"[" { BEGIN(IN_R1C1_BRACKETED_COLUMN); return (int)Tokens.T_LBRACK; }
"]" { BEGIN(INITIAL); return (int)Tokens.T_RBRACK; }

. { BEGIN(INITIAL); }
}

<IN_R1C1_BRACKETED_COLUMN> {

[\+\-]?[1-9]+ { yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_R1C1_COLUMN; }
"]" { BEGIN(INITIAL); return (int)Tokens.T_RBRACK; }
. { BEGIN(INITIAL); }
}

<IN_STRING>{
    \"\"                  { stringBuffer.Append('"'); }
    \"                    { BEGIN(INITIAL); yylval.stringVal = stringBuffer.ToString(); return (int)Tokens.T_STRING_CONSTANT; }
    [^\"]+                { stringBuffer.Append(yytext); }
}

<IN_QUOTED_SHEET_NAME>{
    \'\'                  { stringBuffer.Append("'"); }
    \'                    { BEGIN(INITIAL); yylval.stringVal = stringBuffer.ToString(); return (int)Tokens.T_SHEET_NAME_SPECIAL; }
    [^\']+                { stringBuffer.Append(yytext); }
}
%%
