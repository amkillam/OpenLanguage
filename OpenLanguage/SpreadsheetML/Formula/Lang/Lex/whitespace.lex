"//".*                                                                            { /* skip single-line comment */ }
[\r][\n]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
[\n]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
[\r]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
[ \t]                                                                             { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }
[\u2000-\u200A]                                                                   { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
[\u202F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
[\u205F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
[\u3000]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
[\u200B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
[\u00A0]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }
[\uFEFF]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
