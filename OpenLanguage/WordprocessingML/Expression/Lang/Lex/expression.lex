%namespace OpenLanguage.WordprocessingML.Expression.Generated
%scannertype ExpressionScanner
%tokentype Tokens
%visibility internal
%option unicode

%{
    public Parser Parser { get; set; }
    private System.Text.StringBuilder string_buffer = new System.Text.StringBuilder();
%}

%x S_DQUOTE_STRING
%x S_DQUOTE_STRING_END
%x S_SMART_DQUOTE_STRING
%x S_SMART_DQUOTE_STRING_END
%x S_SQUOTE_STRING
%x S_SQUOTE_STRING_END
%x S_SMART_SQUOTE_STRING
%x S_SMART_SQUOTE_STRING_END
%x IN_MERGE_FIELD
%x IN_COMMENT

%%

<INITIAL>{
    "/*"                    { BEGIN(IN_COMMENT); }
    #include "whitespace.lex"

    // Literals and identifiers
    \"                      { string_buffer.Clear(); BEGIN(S_DQUOTE_STRING); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    \u201C|\u201D         { string_buffer.Clear(); BEGIN(S_SMART_DQUOTE_STRING); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    \'                      { string_buffer.Clear(); BEGIN(S_SQUOTE_STRING); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    \u2018|\u2019         { string_buffer.Clear(); BEGIN(S_SMART_SQUOTE_STRING); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    [\+\-]?[0-9]+[Ee][\+\-]?($|[^0-9])                        { throw new System.FormatException("Malformed floating point number, exponent has no digits."); }
    [\+\-]?[0-9]+\.[0-9]+([eE][\+\-]?[0-9]+)? { yylval.stringVal = yytext; return (int)Tokens.T_FLOAT; }
    ([\+\-]?[0-9]+\.[0-9]*|\.[0-9]+)[Ee][\+\-]?     { throw new System.FormatException("Malformed floating point number, exponent has no digits."); }
    [\+\-]?[0-9]+([eE][\+\-]?[0-9]+)          { yylval.stringVal = yytext; return (int)Tokens.T_FLOAT; }
    [\+\-]?\.[0-9]+([eE][\+\-]?[0-9]+)?             { yylval.stringVal = yytext; return (int)Tokens.T_FLOAT; }
    [\+\-]?[&0][xXhH][0-9a-fA-F]+                  { yylval.stringVal = yytext; return (int)Tokens.T_HEX_INTEGER; }
    [\+\-]?[&0][bB][01]+                           { yylval.stringVal = yytext; return (int)Tokens.T_BINARY_INTEGER; }
    [\+\-]?[0-9]+                            { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER; }

    // Operators
    "="                     { yylval.stringVal = yytext; return (int)Tokens.T_EQUAL; }
    "<>"                    { yylval.stringVal = yytext; return (int)Tokens.T_NOT_EQUAL; }
    "<"                     { yylval.stringVal = yytext; return (int)Tokens.T_LESS_THAN; }
    "<="                    { yylval.stringVal = yytext; return (int)Tokens.T_LESS_THAN_OR_EQUAL; }
    ">"                     { yylval.stringVal = yytext; return (int)Tokens.T_GREATER_THAN; }
    ">="                    { yylval.stringVal = yytext; return (int)Tokens.T_GREATER_THAN_OR_EQUAL; }
    "+"                     { yylval.stringVal = yytext; return (int)Tokens.T_PLUS; }
    "-"                     { yylval.stringVal = yytext; return (int)Tokens.T_MINUS; }
    "*"                     { yylval.stringVal = yytext; return (int)Tokens.T_ASTERISK; }
    "/"                     { yylval.stringVal = yytext; return (int)Tokens.T_SLASH; }
    "^"                     { yylval.stringVal = yytext; return (int)Tokens.T_CARET; }
    "%"                     { yylval.stringVal = yytext; return (int)Tokens.T_PERCENT; }

    "«"                     { BEGIN(IN_MERGE_FIELD); return (int)Tokens.T_LEFT_GUILLEMET; }

    "("                     { yylval.stringVal = yytext; return (int)Tokens.T_LEFT_PAREN; }
    ")"                     { yylval.stringVal = yytext; return (int)Tokens.T_RIGHT_PAREN; }

    [\b]\[[^\]\r\n]+\][\b]      { yylval.stringVal = yytext; return (int)Tokens.T_IDENTIFIER; }
    [\b]\`([^`]|``)+\`[\b]      { yylval.stringVal = yytext; return (int)Tokens.T_IDENTIFIER; }
    [\b][A-Za-z_@$\.][\-A-Za-z0-9_@$\.]*[\b]  { yylval.stringVal = yytext; return (int)Tokens.T_IDENTIFIER; }
    .                       { yylval.stringVal = yytext; return (int)Tokens.T_UNKNOWN; }
}

<S_DQUOTE_STRING>{
    \\\"                    { string_buffer.Append(yytext); }
    \"\"                    { string_buffer.Append(yytext); }
    \"                      { yyless(0); yylval.stringVal = string_buffer.ToString(); BEGIN(S_DQUOTE_STRING_END); return (int)Tokens.T_STRING_CONTENT; }
    \\.                     { string_buffer.Append(yytext); }
    [^\\"]+                 { string_buffer.Append(yytext); }
}
<S_DQUOTE_STRING_END>{
    \"                      { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_QUOTE; }
}
<S_DQUOTE_STRING_END><<EOF>> { throw new System.FormatException("Unterminated double-quoted string literal"); }

<S_SMART_DQUOTE_STRING>{
    \\\u201C|\\\u201D       { string_buffer.Append(yytext); }
    \u201C\u201C|\u201D\u201D { string_buffer.Append(yytext); }
    \u201C|\u201D           { yyless(0); yylval.stringVal = string_buffer.ToString(); BEGIN(S_SMART_DQUOTE_STRING_END); return (int)Tokens.T_STRING_CONTENT; }
    \\.                     { string_buffer.Append(yytext); }
    [^\\\u201C\u201D]+      { string_buffer.Append(yytext); }
}
<S_SMART_DQUOTE_STRING_END>{
    \u201C|\u201D           { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_QUOTE; }
}
<S_SMART_DQUOTE_STRING_END><<EOF>> { throw new System.FormatException("Unterminated smart double-quoted string literal"); }

<S_SQUOTE_STRING>{
    \\\'                    { string_buffer.Append(yytext); }
    \'\'                    { string_buffer.Append(yytext); }
    \'                      { yyless(0); yylval.stringVal = string_buffer.ToString(); BEGIN(S_SQUOTE_STRING_END); return (int)Tokens.T_STRING_CONTENT; }
    \\.                     { string_buffer.Append(yytext); }
    [^\\']+                 { string_buffer.Append(yytext); }
}
<S_SQUOTE_STRING_END>{
    \'                      { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_QUOTE; }
}
<S_SQUOTE_STRING_END><<EOF>> { throw new System.FormatException("Unterminated single-quoted string literal"); }

<S_SMART_SQUOTE_STRING>{
    \\\u2018|\\\u2019       { string_buffer.Append(yytext); }
    \u2018\u2018|\u2019\u2019 { string_buffer.Append(yytext); }
    \u2018|\u2019           { yyless(0); yylval.stringVal = string_buffer.ToString(); BEGIN(S_SMART_SQUOTE_STRING_END); return (int)Tokens.T_STRING_CONTENT; }
    \\.                     { string_buffer.Append(yytext); }
    [^\\\u2018\u2019]+      { string_buffer.Append(yytext); }
}
<S_SMART_SQUOTE_STRING_END>{
    \u2018|\u2019           { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_QUOTE; }
}
<S_SMART_SQUOTE_STRING_END><<EOF>> { throw new System.FormatException("Unterminated smart single-quoted string literal"); }

<IN_MERGE_FIELD>{
    [^»]+                   { yylval.stringVal = yytext; return (int)Tokens.T_MERGE_FIELD_CONTENT; }
    "»"                     { BEGIN(INITIAL); return (int)Tokens.T_RIGHT_GUILLEMET; }
}

<IN_COMMENT>"*/" { BEGIN(INITIAL); }
<IN_COMMENT><<EOF>> { throw new System.FormatException("Unterminated comment"); }
<IN_COMMENT>[\s\S] { /* consume comment content */ }

