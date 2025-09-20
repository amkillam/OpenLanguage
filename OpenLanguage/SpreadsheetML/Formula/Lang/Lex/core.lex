"<>"                                                                              { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_NE; }
">="                                                                              { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_GE; }
"<="                                                                              { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_LE; }



"#"[aA][lL][lL]                                                                            { yylval.stringVal = yytext; return (int)Tokens.T_SR_ALL; }
"#"[dD][aA][tT][aA]                                                                           { yylval.stringVal = yytext; return (int)Tokens.T_SR_DATA; }
"#"[hH][eE][aA][dD][eE][rR][sS]                                                                        { yylval.stringVal = yytext; return (int)Tokens.T_SR_HEADERS; }
"#"[tT][oO][tT][aA][lL][sS]                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_SR_TOTALS; }
"#"[tT][hH][iI][sS]" "[rR][oO][wW]                                                                       { yylval.stringVal = yytext; return (int)Tokens.T_SR_THIS_ROW; }

"_"[xX][lL][wW][sS]"."                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_XLWS; }
"_"[xX][lL][fF][nN]"."                                                                         { yylval.stringVal = yytext; return (int)Tokens.T_XLFN; }
[xX][lL][pP][mM]"."                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_XLPM; }
[xX][lL][oO][pP]"."                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_XLOP; }

"#"[dD][iI][vV]"/0!"                                                                         { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_DIV0_ERROR; }
"#"[nN]"/"[aA]                                                                            { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_NA_ERROR; }
"#"[nN][aA][mM][eE]"?"                                                                         { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_NAME_ERROR; }
"#"[nN][uU][lL][lL]"!"                                                                          { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_NULL_ERROR; }
"#"[nN][uU][mM]"!"                                                                           { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_NUM_ERROR; }
"#"[vV][aA][lL][uU][eE]"!"                                                                         { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_VALUE_ERROR; }
"#"[rR][eE][fF]"!"                                                                           { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_REF_ERROR; }
"#"[rR][eE][fF]                                                                              { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_REF_ERROR; }
"#"[gG][eE][tT][tT][iI][nN][gG]"_"[dD][aA][tT][aA]                                                                   { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_GETTING_DATA_ERROR; }
"#"[sS][pP][iI][lL][lL]"!"                                                                         { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_SPILL_ERROR; }
"#"[cC][aA][lL][cC]"!"                                                                          { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_CALC_ERROR; }
"#"[bB][lL][oO][cC][kK][eE][dD]"!"                                                                       { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_BLOCKED_ERROR; }
"#"[bB][uU][sS][yY]"!"                                                                          { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_BUSY_ERROR; }
"#"[cC][iI][rR][cC][uU][lL][aA][rR]"!"                                                                      { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_CIRCULAR_ERROR; }
"#"[cC][oO][nN][nN][eE][cC][tT]"!"                                                                       { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_CONNECT_ERROR; }
"#"[eE][xX][tT][eE][rR][nN][aA][lL]"!"                                                                      { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_EXTERNAL_ERROR; }
"#"[fF][iI][eE][lL][dD]"!"                                                                         { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FIELD_ERROR; }
"#"[pP][yY][tT][hH][oO][nN]"!"                                                                        { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_PYTHON_ERROR; }
"#"[uU][nN][kK][nN][oO][wW][nN]"!"                                                                       { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_UNKNOWN_ERROR; }


\"                                                                                { stringBuffer.Clear(); BEGIN(IN_STRING); }
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
\$?[A-Z][A-Z]{0,2}\$?[0-9][0-9]{0,6}                                              { BEGIN(IN_A1_CELL); yyless(0); }

\$?[A-Z][A-Z]{0,2}:\$?[A-Z][A-Z]{0,2}                                             { BEGIN(IN_A1_COLUMN_RANGE); yyless(0); }
\$?[0-9][0-9]{0,6}:\$?[0-9][0-9]{0,6}                                             { BEGIN(IN_A1_ROW_RANGE); yyless(0); }




[0&][bB][01]+                                                                     { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
[0&][oO][0-7]+                                                                    { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
[0&][xX][0-9a-fA-F]+                                                              { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]{1,3}(,[0-9]{3})*\.[0-9]+([Ee][\+\-]?[0-9]+)?    { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]+\.[0-9]+([Ee][\+\-]?[0-9]+)?                    { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?\.[0-9]+([Ee][\+\-]?[0-9]+)?                          { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]{1,3}(,[0-9]{3})*[Ee][\+\-]?[0-9]+               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]+[Ee][\+\-]?[0-9]+                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[0-9]{1,3}(,[0-9]{3})*\.[0-9]+([Ee][\+\-]?[0-9]+)?[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]    { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[0-9]+\.[0-9]+([Ee][\+\-]?[0-9]+)?[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]                    { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
\.[0-9]+([Ee][\+\-]?[0-9]+)?[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]                          { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]{1,3}(,[0-9]{3})+                                { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]+                                                { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿][ ]?[0-9]{1,3}(\.[0-9]{3})+                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
[0-9]{1,3}(,[0-9]{3})+[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]                                { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
[0-9]+[ ]?[$¢£¥€₹₽₩₪₦₨₡₵₶₷₸₺₻₼₽₾₿]                                                { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
([0-9]{1,3}(,[0-9]{3})*(\.[0-9]*)?|[0-9]+(\.[0-9]*)?|\.[0-9]+)[Ee][\+\-]?[0-9]+   { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[0-9]{1,3}(\.[0-9]{3})+,[0-9]*[Ee][\+\-]?[0-9]+                                   { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[0-9]{1,3}(\.[0-9]{3})+,[0-9]+([Ee][\+\-]?[0-9]+)?                                { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[0-9]{1,3}(,[0-9]{3})+\.[0-9]+([Ee][\+\-]?[0-9]+)?                                { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[0-9]{1,3}(,[0-9]{3})+                                                            { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }
([0-9]+\.[0-9]*|\.[0-9]+)[Ee][\+\-]?                                              { throw new System.FormatException("Malformed floating point number, exponent has no digits."); }
[0-9]+[Ee][\+\-]?                                                                 { throw new System.FormatException("Malformed floating point number, exponent has no digits."); }
([0-9]+\.[0-9]*|\.[0-9]+)                                                         { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_FLOATING_POINT_CONSTANT; }
[0-9]+                                                                            { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_INTEGER_CONSTANT; }

"@"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_AT_SYMBOL; }
"+"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_PLUS; }
"-"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_MINUS; }
"*"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_ASTERISK; }
"/"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_SLASH; }
"^"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_CARET; }
"&"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_AMPERSAND; }
"%"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_PERCENT; }
"="                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; eq_after_equalprefix = true; lastOpOrSep = true; return (int)Tokens.T_EQ; }
">"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_GT; }
"<"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_LT; }
"("                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_LPAREN; }
")"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_RPAREN; }
"{"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_LBRACE; }
"}"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_RBRACE; }
","                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_COMMA; }
":"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; lastOpOrSep = true; return (int)Tokens.T_COLON; }
";"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_SEMICOLON; }
"!"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_BANG; }
"$"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_DOLLAR; }
"#"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_HASH; }
"?"                                                                               { yylval.stringVal = yytext; lastIdOrRbrack = false; return (int)Tokens.T_QUESTION_MARK; }

([_\\A-Za-z`]|[^\x00-\x7F])([_\\A-Za-z0-9.?`]|[^\x00-\x7F])*                      { yylval.stringVal = yytext; lastIdOrRbrack = true; lastOpOrSep = false; return (int)Tokens.T_IDENTIFIER; }

.                                                                                 { }
