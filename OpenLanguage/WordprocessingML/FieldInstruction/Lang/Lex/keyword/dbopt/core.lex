    // Database optimization flags (case-insensitive; optional -, _, or space separators)
    [Nn][oO][nN][eE]                                     { yylval.stringVal = yytext; return (int)Tokens.T_DBOPT_NONE; }
    [Qq][Uu][Ee][Rr][Yy][\s\-_]?[Oo][Nn][Cc][Ee]          { yylval.stringVal = yytext; return (int)Tokens.T_DBOPT_QUERYONCE; }
    [Cc][Aa][Cc][Hh][Ee][\s\-_]?[Rr][Ee][Ss][Uu][Ll][Tt][Ss] { yylval.stringVal = yytext; return (int)Tokens.T_DBOPT_CACHERESULTS; }
    [Uu][Ss][Ee][\s\-_]?[Cc][Oo][Nn][Nn][Ee][Cc][Tt][Ii][Oo][Nn][\s\-_]?[Pp][Oo][Oo][Ll][Ii][Nn][Gg] { yylval.stringVal = yytext; return (int)Tokens.T_DBOPT_USECONNECTIONPOOLING; }
    [Oo][Pp][Tt][Ii][Mm][Ii][Zz][Ee][\s\-_]?[Ff][Oo][Rr][\s\-_]?[Ll][Aa][Rr][Gg][Ee][\s\-_]?[Dd][Aa][Tt][Aa] { yylval.stringVal = yytext; return (int)Tokens.T_DBOPT_OPTIMIZEFORLARGEDATA; }
    [Oo][Pp][Tt][Ii][Mm][Ii][Zz][Ee][\s\-_]?[Ff][Oo][Rr][\s\-_]?[Ss][Mm][Aa][Ll][Ll][\s\-_]?[Dd][Aa][Tt][Aa] { yylval.stringVal = yytext; return (int)Tokens.T_DBOPT_OPTIMIZEFORSMALLDATA; }

