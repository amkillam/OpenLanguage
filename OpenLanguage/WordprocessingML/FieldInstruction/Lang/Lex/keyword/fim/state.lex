<IN_FIM> {
    \"                                                   { BEGIN(IN_STRAIGHT_QUOTE_FIM); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    // smart quote
    \u201C                                             { BEGIN(IN_SMART_QUOTE_FIM); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    // smart quote
    \u201D                                             { yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    [Cc][oO][uU][rR][tT][eE][sS][yY][Rr][eE][pP][lL][yY] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FIM_COURTESY_REPLY; }
    [Bb][uU][sS][iI][nN][eE][sS][sS][Rr][eE][pP][lL][yY] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FIM_BUSINESS_REPLY; }
    [Aa]                                                 { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FIM_COURTESY_REPLY; }
    [Cc]                                                 { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FIM_BUSINESS_REPLY; }

    #include "../../word_separators.lex"
    #include "../../whitespace.lex"
    #include "../../switch.lex"

    .                                                    { BEGIN(INITIAL); yyless(0);  }
}

<IN_STRAIGHT_QUOTE_FIM> {
    \"                                                   { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    // smart quote
    \u201C                                             { yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    // smart quote
    \u201D                                             { yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    [Cc][oO][uU][rR][tT][eE][sS][yY][Rr][eE][pP][lL][yY] { yylval.stringVal = yytext; return (int)Tokens.T_FIM_COURTESY_REPLY; }
    [Bb][uU][sS][iI][nN][eE][sS][sS][Rr][eE][pP][lL][yY] { yylval.stringVal = yytext; return (int)Tokens.T_FIM_BUSINESS_REPLY; }
    [Aa]                                                 { yylval.stringVal = yytext; return (int)Tokens.T_FIM_COURTESY_REPLY; }
    [Cc]                                                 { yylval.stringVal = yytext; return (int)Tokens.T_FIM_BUSINESS_REPLY; }

    #include "../../word_separators.lex"
    #include "../../whitespace.lex"
    #include "../../switch.lex"

    .                                                    { BEGIN(INITIAL); yyless(0);  }
}

<IN_SMART_QUOTE_FIM> {
    // smart quote
    \u201D                                             { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    \"                                                   { yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    // smart quote
    \u201C                                             { yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    [Cc][oO][uU][rR][tT][eE][sS][yY][Rr][eE][pP][lL][yY] { yylval.stringVal = yytext; return (int)Tokens.T_FIM_COURTESY_REPLY; }
    [Bb][uU][sS][iI][nN][eE][sS][sS][Rr][eE][pP][lL][yY] { yylval.stringVal = yytext; return (int)Tokens.T_FIM_BUSINESS_REPLY; }
    [Aa]                                                 { yylval.stringVal = yytext; return (int)Tokens.T_FIM_COURTESY_REPLY; }
    [Cc]                                                 { yylval.stringVal = yytext; return (int)Tokens.T_FIM_BUSINESS_REPLY; }

    #include "../../word_separators.lex"
    #include "../../whitespace.lex"
    #include "../../switch.lex"

    .                                                    { BEGIN(INITIAL); yyless(0);  }
}
