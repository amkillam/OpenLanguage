// Application tokens

<IN_PROGID> {
[eE][xX][cC][eE][lL] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_EXCEL; }
[fF][oO][rR][mM][sS] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_FORMS; }
[iI][nN][fF][oO][pP][aA][tT][hH] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_INFOPATH; }
[iI][nN][tT][eE][rR][nN][eE][tT][eE][xX][pP][lL][oO][rR][eE][rR] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_INTERNETEXPLORER; }
[mM][sS][gG][rR][aA][pP][hH] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_MSGRAPH; }
[mM][sS][pP][rR][oO][jJ][eE][cC][tT] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_MSPROJECT; }
[oO][nN][eE][nN][oO][tT][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_ONENOTE; }
[oO][uU][tT][lL][oO][oO][kK] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_OUTLOOK; }
[oO][wW][cC] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_OWC; }
[pP][oO][wW][eE][rR][pP][oO][iI][nN][tT] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_POWERPOINT; }
[pP][uU][bB][lL][iI][sS][hH][eE][rR] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_PUBLISHER; }
[vV][iI][sS][iI][oO] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_VISIO; }
[wW][oO][rR][dD] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_APPLICATION_WORD; }

// Object tokens
[aA][dD][dD][iI][nN] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_ADDIN; }
[aA][pP][pP][lL][iI][cC][aA][tT][iI][oO][nN] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_APPLICATION; }
[cC][hH][aA][rR][tT] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_CHART; }
[cC][hH][aA][rR][tT][sS][pP][aA][cC][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_CHARTSPACE; }
[cC][hH][eE][cC][kK][bB][oO][xX] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_CHECKBOX; }
[cC][oO][dD][eE][dD][aA][tT][aA] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_CODEDATA; }
[cC][oO][dD][eE][pP][rR][oO][jJ][eE][cC][tT] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_CODEPROJECT; }
[cC][oO][mM][bB][oO][bB][oO][xX] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_COMBOBOX; }
[cC][oO][mM][mM][aA][nN][dD][bB][uU][tT][tT][oO][nN] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_COMMANDBUTTON; }
[cC][uU][rR][rR][eE][nN][tT][dD][aA][tT][aA] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_CURRENTDATA; }
[cC][uU][rR][rR][eE][nN][tT][pP][rR][oO][jJ][eE][cC][tT] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_CURRENTPROJECT; }
[dD][aA][tT][aA][sS][oO][uU][rR][eE][cC][oO][nN][tT][rR][oO][lL] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_DATASOURCECONTROL; }
[dD][eE][fF][aA][uU][lL][tT][wW][eE][bB][oO][pP][tT][iI][oO][nN][sS] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_DEFAULTWEBOPTIONS; }
[dD][oO][cC][uU][mM][eE][nN][tT] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_DOCUMENT; }
[dD][oO][cC][uU][mM][eE][nN][tT][sS][uU][mM][mM][aA][rR][yY][iI][nN][fF][oO][rR][mM][aA][tT][iI][oO][nN] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_DOCUMENTSUMMARYINFORMATION; }
[eE][nN][vV][eE][lL][oO][pP][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_ENVELOPE; }
[eE][xX][pP][aA][nN][dD][cC][oO][nN][tT][rR][oO][lL] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_EXPANDCONTROL; }
[fF][oO][rR][mM] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_FORM; }
[fF][rR][aA][mM][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_FRAME; }
[gG][lL][oO][bB][aA][lL] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_GLOBAL; }
[gG][rR][aA][pP][hH] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_GRAPH; }
[gG][rR][aA][pP][hH][fF][rR][aA][mM][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_GRAPHFRAME; }
[iI][mM][aA][gG][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_IMAGE; }
[lL][aA][bB][eE][lL] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_LABEL; }
[lL][iI][sS][tT][bB][oO][xX] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_LISTBOX; }
[mM][aA][iI][lL][mM][eE][sS][sS][aA][gG][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_MAILMESSAGE; }
[mM][aA][iI][lL][eE][rR] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_MAILER; }
[mM][aA][pP] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_MAP; }
[mM][oO][dD][uU][lL][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_MODULE; }
[mM][uU][lL][tT][iI][pP][aA][gG][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_MULTIPAGE; }
[nN][oO][tT][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_NOTE; }
[oO][pP][tT][iI][oO][nN][bB][uU][tT][tT][oO][nN] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_OPTIONBUTTON; }
[pP][iI][cC][tT][uU][rR][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_PICTURE; }
[pP][iI][vV][oO][tT][tT][aA][bB][lL][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_PIVOTTABLE; }
[rR][eE][cC][oO][rR][dD][nN][aA][vV][iI][gG][aA][tT][iI][oO][nN][cC][oO][nN][tT][rR][oO][lL] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_RECORDNAVIGATIONCONTROL; }
[sS][cC][rR][oO][lL][lL][bB][aA][rR] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_SCROLLBAR; }
[sS][hH][eE][eE][tT] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_SHEET; }
[sS][lL][iI][dD][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_SLIDE; }
[sS][pP][iI][nN][bB][uU][tT][tT][oO][nN] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_SPINBUTTON; }
[sS][pP][rR][eE][aA][dD][sS][hH][eE][eE][tT] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_SPREADSHEET; }
[tT][aA][bB][lL][eE] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_TABLE; }
[tT][aA][bB][sS][tT][rR][iI][pP] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_TABSTRIP; }
[tT][eE][xX][tT][bB][oO][xX] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_TEXTBOX; }
[tT][oO][gG][gG][lL][eE][bB][uU][tT][tT][oO][nN] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_TOGGLEBUTTON; }
[vV][iI][eE][wW] { yylval.stringVal = yytext; return (int)Tokens.T_PROGID_OBJECT_VIEW; }

[0&][xXhH][0-9a-fA-F]+                 { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_HEX_INTEGER; }
[0&][bB][01]+                          { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_BINARY_INTEGER; }
[0-9]+                                 { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_INTEGER; }

#include "../../whitespace.lex"
#include "../../word_separators.lex"
#include "../../switch.lex"

"."                                    { return (int)Tokens.T_PERIOD; }
}
