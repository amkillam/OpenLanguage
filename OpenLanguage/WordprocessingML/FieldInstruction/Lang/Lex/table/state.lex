<IN_A1_CELL> {
    [a-zA-Z]{1,3}   { yylval.stringVal = yytext; return (int)Tokens.T_A1_COLUMN; }
    [1-9][0-9]{0,6} { BEGIN(INITIAL); yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL || yylval.ulongVal < 1) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }
    [0]             { BEGIN(INITIAL); yyless(0); throw new System.FormatException("Row numbers cannot start with 0"); }
    #include "../whitespace.lex"
    #include "../word_separators.lex"
    #include "../switch.lex"
    .               { BEGIN(INITIAL); yyless(0); }
}

<IN_A1_CELL_RANGE> {
    [a-zA-Z]{1,3}   { yylval.stringVal = yytext; return (int)Tokens.T_A1_COLUMN; }
    [1-9][0-9]{0,6} { BEGIN(INITIAL); yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL || yylval.ulongVal < 1) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }
    [0]             { BEGIN(INITIAL); yyless(0); throw new System.FormatException("Row numbers cannot start with 0"); }
    ":"             { BEGIN(IN_A1_CELL); return (int)Tokens.T_COLON; }
    #include "../whitespace.lex"
    #include "../word_separators.lex"
    #include "../switch.lex"
    .               { BEGIN(INITIAL); yyless(0); }
}

<IN_CELL_LIST> {
[lL][eE][fF][tT]     { yylval.stringVal = yytext; return (int)Tokens.T_RELATIVE_CELL_RANGE_KEYWORD_LEFT; }
[rR][iI][gG][hH][tT] { yylval.stringVal = yytext; return (int)Tokens.T_RELATIVE_CELL_RANGE_KEYWORD_RIGHT; }
[aA][bB][oO][vV][eE] { yylval.stringVal = yytext; return (int)Tokens.T_RELATIVE_CELL_RANGE_KEYWORD_ABOVE; }
[bB][eE][lL][oO][wW] { yylval.stringVal = yytext; return (int)Tokens.T_RELATIVE_CELL_RANGE_KEYWORD_BELOW; }

[a-zA-Z]{1,3}        { yylval.stringVal = yytext; return (int)Tokens.T_A1_COLUMN; }
[1-9][0-9]{0,6}      { yylval.ulongVal = ulong.Parse(yytext, System.Globalization.CultureInfo.InvariantCulture); if (yylval.ulongVal > 1048576UL || yylval.ulongVal < 1) { throw new System.FormatException("Row number out of range"); } return (int)Tokens.T_A1_ROW; }
[0]                  { yyless(0); throw new System.FormatException("Row numbers cannot start with 0"); }

#include "../whitespace.lex"
#include "../word_separators.lex"
#include "../switch.lex"

","                  { yylval.stringVal = yytext; return (int)Tokens.T_COMMA; }
";"                  { yylval.stringVal = yytext; return (int)Tokens.T_COMMA; }
":"                  { yylval.stringVal = yytext; return (int)Tokens.T_COLON; }

.                    { BEGIN(INITIAL); yyless(0);}

}

<IN_RELATIVE_CELL_RANGE> {
[lL][eE][fF][tT]     { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_RELATIVE_CELL_RANGE_KEYWORD_LEFT; }
[rR][iI][gG][hH][tT] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_RELATIVE_CELL_RANGE_KEYWORD_RIGHT; }
[aA][bB][oO][vV][eE] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_RELATIVE_CELL_RANGE_KEYWORD_ABOVE; }
[bB][eE][lL][oO][wW] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_RELATIVE_CELL_RANGE_KEYWORD_BELOW; }
#include "../whitespace.lex"
#include "../word_separators.lex"
#include "../switch.lex"
.                    { BEGIN(INITIAL); yyless(0); }
}
