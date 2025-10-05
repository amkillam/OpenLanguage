<IN_FUNCTION> {
[aA][bB][sS] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_ABS; }
[aA][nN][dD] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_AND; }
[aA][vV][eE][rR][aA][gG][eE] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_AVERAGE; }
[cC][oO][uU][nN][tT] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_COUNT; }
[dD][eE][fF][iI][nN][eE][dD] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_DEFINED; }
[fF][aA][lL][sS][eE] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_FALSE; }
[iI][nN][tT] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_INT; }
[mM][aA][xX] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_MAX; }
[mM][iI][nN] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_MIN; }
[mM][oO][dD] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_MOD; }
[nN][oO][tT] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_NOT; }
[oO][rR] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_OR; }
[pP][rR][oO][dD][uU][cC][tT] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_PRODUCT; }
[rR][oO][uU][nN][dD] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_ROUND; }
[sS][iI][gG][nN] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_SIGN; }
[sS][uU][mM] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_SUM; }
[tT][rR][uU][eE] { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_FUNC_TRUE; }

#include "../../word_separators.lex"
#include "../../whitespace.lex"
#include "../../switch.lex"

. { BEGIN(INITIAL); yyless(0); }
}
