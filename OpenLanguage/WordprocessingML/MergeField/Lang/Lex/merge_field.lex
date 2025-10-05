%namespace OpenLanguage.WordprocessingML.MergeField.Generated
%scannertype Scanner
%tokentype Tokens
%visibility internal
%option unicode

%{
    public Parser Parser { get; set; }
%}

%x IN_FIELD_NAME
%x IN_FORMATTING_SWITCH

%%

<INITIAL>{
    "«"                                  { BEGIN(IN_FIELD_NAME); yylval.stringVal = yytext; return (int)Tokens.T_LEFT_GUILLEMET; }
    "<<"                                 { BEGIN(IN_FIELD_NAME); yylval.stringVal = yytext; return (int)Tokens.T_LEFT_GUILLEMET; }
    \"                                   { yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    #include "whitespace.lex"
}

<IN_FIELD_NAME>{
    "»"                                  { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_RIGHT_GUILLEMET; }
    ">>"                                 { BEGIN(INITIAL); yylval.stringVal = yytext; return (int)Tokens.T_RIGHT_GUILLEMET; }
    \\                                   { yylval.stringVal = yytext; BEGIN(IN_FORMATTING_SWITCH); return (int)Tokens.T_BACKSLASH; }
    \"                                   { yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    #include "whitespace.lex"
    [^\»>"\r\n\t \u2028\u2029\u000B\u000C\u1680\u2000-\u200A\u202F\u205F\u3000\u200B\u00A0\uFEFF\u0000\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u000E\u000F\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001A\u001B\u001C\u001D\u001E\u001F\u007F]+      { yylval.stringVal = yytext; return (int)Tokens.T_FIELD_NAME; }
}

<IN_FORMATTING_SWITCH>{
    [^»>\r\n\t \u2028\u2029\u000B\u000C\u1680\u2000-\u200A\u202F\u205F\u3000\u200B\u00A0\uFEFF\u0000\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u000E\u000F\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001A\u001B\u001C\u001D\u001E\u001F\u007F]+                        { BEGIN(IN_FIELD_NAME); yylval.stringVal = yytext; return (int)Tokens.T_FORMATTING_SWITCH; }
    #include "whitespace.lex"
}
