%using OpenLanguage.Utils;
%namespace OpenLanguage.SpreadsheetML.Formula.Generated
%scannertype FormulaScanner
%tokentype Tokens
%visibility internal
%option unicode

%{
    private System.Text.StringBuilder stringBuffer = new System.Text.StringBuilder();
    public Parser Parser { get; set; }
%}


%x IN_STRING
%x IN_SPECIAL_SHEET_REFERENCE
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

    "<>"                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_NE; }
    ">="                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_GE; }
    "<="                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_LE; }



    "#"[aA][lL][lL]                                                                            { yylval.stringVal = yytext; return (int)Tokens.T_SR_ALL; }
    "#"[dD][aA][tT][aA]                                                                           { yylval.stringVal = yytext; return (int)Tokens.T_SR_DATA; }
    "#"[hH][eE][aA][dD][eE][rR][sS]                                                                        { yylval.stringVal = yytext; return (int)Tokens.T_SR_HEADERS; }
    "#"[tT][oO][tT][aA][lL][sS]                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_SR_TOTALS; }
    "#"[tT][hH][iI][sS]" "[rR][oO][wW]                                                                       { yylval.stringVal = yytext; return (int)Tokens.T_SR_THIS_ROW; }
    "[]"                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_EMPTY_BRACKETS; }

    "_"[xX][lL][wW][sS]"."                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_XLWS_; }
    "_"[xX][lL][fF][nN]"."                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_XLFN_; }
    [xX][lL][pP][mM]"."                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_XLPM_; }
    [xX][lL][oO][pP]"."                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_XLOP_; }

    "#"[dD][iI][vV]"/0!"                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_DIV0_ERROR; }
    "#"[nN]"/"[aA]                                                                            { yylval.stringVal = yytext; return (int)Tokens.T_NA_ERROR; }
    "#"[nN][aA][mM][eE]"?"                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_NAME_ERROR; }
    "#"[nN][uU][lL][lL]"!"                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_NULL_ERROR; }
    "#"[nN][uU][mM]"!"                                                                           { yylval.stringVal = yytext; return (int)Tokens.T_NUM_ERROR; }
    "#"[vV][aA][lL][uU][eE]"!"                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_VALUE_ERROR; }
    "#"[rR][eE][fF]"!"                                                                           { yylval.stringVal = yytext; return (int)Tokens.T_REF_ERROR; }
    "#"[gG][eE][tT][tT][iI][nN][gG]"_"[dD][aA][tT][aA]                                                                   { yylval.stringVal = yytext; return (int)Tokens.T_GETTING_DATA_ERROR; }
    "#"[sS][pP][iI][lL][lL]"!"                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_SPILL_ERROR; }
    "#"[cC][aA][lL][cC]"!"                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_CALC_ERROR; }
    "#"[bB][lL][oO][cC][kK][eE][dD]"!"                                                                       { yylval.stringVal = yytext; return (int)Tokens.T_BLOCKED_ERROR; }
    "#"[bB][uU][sS][yY]"!"                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_BUSY_ERROR; }
    "#"[cC][iI][rR][cC][uU][lL][aA][rR]"!"                                                                      { yylval.stringVal = yytext; return (int)Tokens.T_CIRCULAR_ERROR; }
    "#"[cC][oO][nN][nN][eE][cC][tT]"!"                                                                       { yylval.stringVal = yytext; return (int)Tokens.T_CONNECT_ERROR; }
    "#"[eE][xX][tT][eE][rR][nN][aA][lL]"!"                                                                      { yylval.stringVal = yytext; return (int)Tokens.T_EXTERNAL_ERROR; }
    "#"[fF][iI][eE][lL][dD]"!"                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_FIELD_ERROR; }
    "#"[pP][yY][tT][hH][oO][nN]"!"                                                                        { yylval.stringVal = yytext; return (int)Tokens.T_PYTHON_ERROR; }
    "#"[uU][nN][kK][nN][oO][wW][nN]"!"                                                                       { yylval.stringVal = yytext; return (int)Tokens.T_UNKNOWN_ERROR; }
    [tT][rR][uU][eE]                                                                            { yylval.stringVal = yytext; return (int)Tokens.T_TRUE; }
    [fF][aA][lL][sS][eE]                                                                           { yylval.stringVal = yytext; return (int)Tokens.T_FALSE; }


    #include "function/standard.lex"

    #include "function/future.lex"

    #include "function/worksheet.lex"

    #include "function/macro.lex"

    #include "function/command.lex"

    \"                                                                                { stringBuffer.Clear(); BEGIN(IN_STRING); }
    \'                                                                                { stringBuffer.Clear(); BEGIN(IN_SPECIAL_SHEET_REFERENCE); }

    "//".*                                                                            { /* skip single-line comment */ }
    "/\*"                                                                             { BEGIN(IN_COMMENT); }

    // CRLF - usually seen as its own distinct newline sequence
    [\r][\n]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
    // Line feed
    [\n]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
    // Carriage return
    [\r]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
    [ \t]                                                                             { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }
    // General punctuation spaces: en quad to hair space
    [\u2000-\u200A]                                                                   { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
    // Narrow no-break space
    [\u202F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
    // Medium mathematical space
    [\u205F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
    // Ideographic space
    [\u3000]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
    // Zero-width space
    [\u200B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
    [\u00A0]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }
    // Byte Order Mark treated as whitespace
    [\uFEFF]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }


    [R](\[?[\+\-]?[1-9][0-9]{0,6}\])?[C](\[?[\+\-]?[1-9][0-9]{0,6}\])?                { BEGIN(IN_R1C1_CELL); yyless(0); }
    \$?[A-Z][A-Z]{0,2}\$?[1-9][0-9]{0,6}                                              { BEGIN(IN_A1_CELL); yyless(0); }

    \$?[A-Z][A-Z]{0,2}:\$?[A-Z][A-Z]{0,2}                                             { BEGIN(IN_A1_COLUMN_RANGE); yyless(0); }
    \$?[1-9][0-9]{0,6}:\$?[1-9][0-9]{0,6}                                             { BEGIN(IN_A1_ROW_RANGE); yyless(0); }




    [0&][bB][01]+                                                                     { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    [0&][oO][0-7]+                                                                    { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    [0&][xX][0-9a-fA-F]+                                                              { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    [$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]{1,3}(,[0-9]{3})*\.[0-9]+([Ee][\+\-]?[0-9]+)?    { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]+\.[0-9]+([Ee][\+\-]?[0-9]+)?                    { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?\.[0-9]+([Ee][\+\-]?[0-9]+)?                          { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]{1,3}(,[0-9]{3})*[Ee][\+\-]?[0-9]+               { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]+[Ee][\+\-]?[0-9]+                               { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [0-9]{1,3}(,[0-9]{3})*\.[0-9]+([Ee][\+\-]?[0-9]+)?[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]    { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [0-9]+\.[0-9]+([Ee][\+\-]?[0-9]+)?[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]                    { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    \.[0-9]+([Ee][\+\-]?[0-9]+)?[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]                          { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]{1,3}(,[0-9]{3})+                                { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    [$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]+                                                { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    [$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]{1,3}(\.[0-9]{3})+                               { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    [0-9]{1,3}(,[0-9]{3})+[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]                                { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    [0-9]+[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]                                                { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    ([0-9]{1,3}(,[0-9]{3})*(\.[0-9]*)?|[0-9]+(\.[0-9]*)?|\.[0-9]+)[Ee][\+\-]?[0-9]+   { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [0-9]{1,3}(\.[0-9]{3})+,[0-9]*[Ee][\+\-]?[0-9]+                                   { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [0-9]{1,3}(\.[0-9]{3})+,[0-9]+([Ee][\+\-]?[0-9]+)?                                { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [0-9]{1,3}(,[0-9]{3})+\.[0-9]+([Ee][\+\-]?[0-9]+)?                                { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [0-9]{1,3}(,[0-9]{3})+                                                            { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }
    ([0-9]+\.[0-9]*|\.[0-9]+)([Ee][\+\-]?[0-9]+)?                                     { yylval.stringVal = yytext; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
    [0-9]+                                                                            { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER_CONSTANT; }

    [a-zA-Z_\\`][a-zA-Z0-9_.?`]*                                                      { yylval.stringVal = yytext; return (int)Tokens.T_IDENTIFIER; }


    "@"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_AT_SYMBOL; }
    "+"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_PLUS; }
    "-"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_MINUS; }
    "*"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_ASTERISK; }
    "/"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_SLASH; }
    "^"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_CARET; }
    "&"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_AMPERSAND; }
    "%"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_PERCENT; }
    "="                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_EQ; }
    ">"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_GT; }
    "<"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_LT; }
    "("                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_LPAREN; }
    ")"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_RPAREN; }
    "{"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_LBRACE; }
    "}"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_RBRACE; }
    "["                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_LBRACK; }
    "]"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_RBRACK; }
    ","                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_COMMA; }
    ":"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_COLON; }
    ";"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_SEMICOLON; }
    "!"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_BANG; }
    "$"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_DOLLAR; }
    "#"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_HASH; }
    "?"                                                                               { yylval.stringVal = yytext; return (int)Tokens.T_QUESTION_MARK; }

    .                                                                                 { }
}

<IN_COMMENT>"\*/" { BEGIN(INITIAL); }
<IN_COMMENT>[\s\S] { /* consume comment content */ }

<IN_A1_CELL> {
    \$ { return  (int)Tokens.T_DOLLAR; }
    [A-Z][A-Z]{0,2}                                                    { yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); if (yylval.ulongVal > 16384UL) { throw new System.FormatException("Column reference out of range"); } return (int)Tokens.T_A1_COLUMN; }
    [1-9][0-9]{0,6}                                              { BEGIN(INITIAL); yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }
    . { BEGIN(INITIAL); yyless(0); }
}

<IN_A1_COLUMN_RANGE> {
   \$ { return  (int)Tokens.T_DOLLAR; }
   ":" { yylval.stringVal = yytext; BEGIN(IN_A1_COLUMN_RANGE_SECOND_COLUMN); return (int)Tokens.T_COLON; }

   [A-Z]{1,3}                                                    { yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); if (yylval.ulongVal > 16384UL) { throw new System.FormatException("Column reference out of range"); } return (int)Tokens.T_A1_COLUMN; }
   . { BEGIN(INITIAL); yyless(0); }

}

<IN_A1_COLUMN_RANGE_SECOND_COLUMN> {
   \$ { return  (int)Tokens.T_DOLLAR; }

   [A-Z][A-Z]{0,2}                                                    { BEGIN(INITIAL); yylval.ulongVal = AlphabeticHexevigesimalProvider.Parse<ulong>(yytext); if (yylval.ulongVal > 16384UL) { throw new System.FormatException("Column reference out of range"); } return (int)Tokens.T_A1_COLUMN; }
   . { BEGIN(INITIAL); yyless(0); }
}

<IN_A1_ROW_RANGE> {
   \$ { return  (int)Tokens.T_DOLLAR; }
   ":" { yylval.stringVal = yytext; BEGIN(IN_A1_ROW_RANGE_SECOND_ROW); return (int)Tokens.T_COLON; }

   [1-9][0-9]{0,6}                                              { yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }

   . { BEGIN(INITIAL); yyless(0); }

}

<IN_A1_ROW_RANGE_SECOND_ROW> {
   \$ { return  (int)Tokens.T_DOLLAR; }

   [1-9][0-9]{0,6}                                              { BEGIN(INITIAL); yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }

   . { BEGIN(INITIAL); yyless(0); }
}

<IN_R1C1_CELL> {
"R" { return (int)Tokens.R1C1_ROW_PREFIX; }
"[" { yylval.stringVal = yytext; return (int)Tokens.T_LBRACK; }
"]" { yylval.stringVal = yytext; return (int)Tokens.T_RBRACK; }
[\+\-]?[1-9]{0,6} { yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_R1C1_ROW; }


"C" { BEGIN(IN_R1C1_COLUMN); return (int)Tokens.R1C1_COLUMN_PREFIX; }
}

<IN_R1C1_COLUMN> {
[\+\-]?[1-9]+ { BEGIN(INITIAL); yylval.longVal = long.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); return (int)Tokens.T_R1C1_COLUMN; }
"[" { BEGIN(IN_R1C1_BRACKETED_COLUMN); yylval.stringVal = yytext; return (int)Tokens.T_LBRACK; }
"]" { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_RBRACK; }
":" { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_COLON; }

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
<IN_STRING><<EOF>>       { throw new System.FormatException("Unterminated string"); }

<IN_SPECIAL_SHEET_REFERENCE>{
    \'\'                  { stringBuffer.Append("'"); }
    \'                    { BEGIN(INITIAL); yylval.stringVal = stringBuffer.ToString(); return (int)Tokens.T_SHEET_NAME_SPECIAL; }
    [^\']+                { stringBuffer.Append(yytext); }
}
%%
