/* Worksheet Function Keywords */
[fF][iI][lL][tT][eE][rR] { yylval.stringVal = yytext; return (int)Tokens.T_FUNC_FILTER; }
[pP][yY] { yylval.stringVal = yytext; return (int)Tokens.T_FUNC_PY; }
[sS][oO][rR][tT] { yylval.stringVal = yytext; return (int)Tokens.T_FUNC_SORT; }
