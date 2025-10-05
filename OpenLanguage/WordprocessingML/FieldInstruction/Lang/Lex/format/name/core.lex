    // NameFormat tokens (case-insensitive)
    [Ff][iI][rR][sS][tT][Nn][aA][mM][eE]                { yylval.stringVal = yytext; return (int)Tokens.T_NAMEFORMAT_FIRSTNAME; }
    [Ll][aA][sS][tT][Nn][aA][mM][eE]                    { yylval.stringVal = yytext; return (int)Tokens.T_NAMEFORMAT_LASTNAME; }
    [Ff][iI][rR][sS][tT][Ll][aA][sS][tT][Nn][aA][mM][eE] { yylval.stringVal = yytext; return (int)Tokens.T_NAMEFORMAT_FIRSTLASTNAME; }
    [Ll][aA][sS][tT][Ff][iI][rR][sS][tT][Nn][aA][mM][eE] { yylval.stringVal = yytext; return (int)Tokens.T_NAMEFORMAT_LASTFIRSTNAME; }
    [Tt][iI][tT][lL][eE][Ll][aA][sS][tT][Nn][aA][mM][eE] { yylval.stringVal = yytext; return (int)Tokens.T_NAMEFORMAT_TITLELASTNAME; }
    [Ff][uU][lL][lL][Ff][oO][rR][mM][aA][lL][Nn][aA][mM][eE] { yylval.stringVal = yytext; return (int)Tokens.T_NAMEFORMAT_FULLFORMALNAME; }
