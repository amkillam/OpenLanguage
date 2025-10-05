    // Quoted frame target tokens
    "\""_[tT][oO][pP]"\""               { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_TOP; }
    "\""_[sS][eE][lL][fF]"\""           { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_SELF; }
    "\""_[bB][lL][aA][nN][kK]"\""       { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_BLANK; }
    "\""_[pP][aA][rR][eE][nN][tT]"\""   { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_PARENT; }
    "\""[tT][oO][pP]"\""                { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_TOP; }
    "\""[sS][eE][lL][fF]"\""            { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_SELF; }
    "\""[bB][lL][aA][nN][kK]"\""        { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_BLANK; }
    "\""[pP][aA][rR][eE][nN][tT]"\""    { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_PARENT; }

    // Unquoted frame target tokens (must be followed by a separator)
    _[tT][oO][pP](?=[\s\\}!]|\Z)               { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_TOP; }
    _[sS][eE][lL][fF](?=[\s\\}!]|\Z)           { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_SELF; }
    _[bB][lL][aA][nN][kK](?=[\s\\}!]|\Z)       { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_BLANK; }
    _[pP][aA][rR][eE][nN][tT](?=[\s\\}!]|\Z)   { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_PARENT; }
    [tT][oO][pP](?=[\s\\}!]|\Z)                { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_TOP; }
    [sS][eE][lL][fF](?=[\s\\}!]|\Z)            { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_SELF; }
    [bB][lL][aA][nN][kK](?=[\s\\}!]|\Z)        { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_BLANK; }
    [pP][aA][rR][eE][nN][tT](?=[\s\\}!]|\Z)    { yylval.stringVal = yytext; return (int)Tokens.T_FRAME_TARGET_PARENT; }
