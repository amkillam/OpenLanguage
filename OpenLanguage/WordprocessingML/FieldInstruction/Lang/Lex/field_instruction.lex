%namespace OpenLanguage.WordprocessingML.FieldInstruction.Generated
%scannertype FieldInstructionScanner
%tokentype Tokens
%visibility internal
%option unicode

%{
    public Parser Parser { get; set; }
    private System.Text.StringBuilder string_buffer = new System.Text.StringBuilder();

    public static void LogText(string text) {
      System.Console.WriteLine("Unknown char: \"" + text + "\"Hex:\"" + System.BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(text)) + "\"");
    }
%}

%x IN_MERGE_FIELD_NAME
%x IN_MERGE_FIELD_FORMATTING
%x S_DQUOTE_STRING
%x S_DQUOTE_STRING_END
%x S_SMART_DQUOTE_STRING
%x S_SMART_DQUOTE_STRING_END
%x S_SQUOTE_STRING
%x S_SQUOTE_STRING_END
%x S_SMART_SQUOTE_STRING
%x S_SMART_SQUOTE_STRING_END
%x IN_BRACK_STRING
%x IN_BRACK_STRING_END
%x IN_COMMENT

#include "table/state_id.lex"

#include "format/datetime/state_id.lex"
#include "format/numeric/state_id.lex"
#include "format/name/state_id.lex"
#include "format/general/state_id.lex"

#include "keyword/progid/state_id.lex"
#include "keyword/dbopt/state_id.lex"
#include "keyword/fim/state_id.lex"
#include "keyword/frame/state_id.lex"
#include "keyword/instruction/state_id.lex"
#include "keyword/function/state_id.lex"

%%

<INITIAL>{
    \"                      { string_buffer.Clear(); BEGIN(S_DQUOTE_STRING); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    \u201C|\u201D         { string_buffer.Clear(); BEGIN(S_SMART_DQUOTE_STRING); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    \'                      { string_buffer.Clear(); BEGIN(S_SQUOTE_STRING); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    \u2018|\u2019         { string_buffer.Clear(); BEGIN(S_SMART_SQUOTE_STRING); yylval.stringVal = yytext; return (int)Tokens.T_QUOTE; }
    \[                      { string_buffer.Clear(); BEGIN(IN_BRACK_STRING); yylval.stringVal = yytext; return (int)Tokens.T_LEFT_BRACKET; }

    #include "keyword/progid/core.lex"
    #include "keyword/instruction/core.lex"
    #include "keyword/function/core.lex"

    #include "format/datetime/core.lex"
    #include "format/numeric/core.lex"

    #include "table/core.lex"
    #include "switch.lex"

    "&lt;&gt;"                               { yylval.stringVal = yytext; return (int)Tokens.T_NOT_EQUAL; }
    "&lt;="                                  { yylval.stringVal = yytext; return (int)Tokens.T_LESS_THAN_OR_EQUAL; }
    "&gt;="                                  { yylval.stringVal = yytext; return (int)Tokens.T_GREATER_THAN_OR_EQUAL; }
    "<="                                     { yylval.stringVal = yytext; return (int)Tokens.T_LESS_THAN_OR_EQUAL; }
    ">="                                     { yylval.stringVal = yytext; return (int)Tokens.T_GREATER_THAN_OR_EQUAL; }
    "<>"                                     { yylval.stringVal = yytext; return (int)Tokens.T_NOT_EQUAL; }
    "«"                                      { BEGIN(IN_MERGE_FIELD_NAME); return (int)Tokens.T_LEFT_GUILLEMET; }
    // XML namespace declaration (xmlns:prefix="URI")
    "xmlns:"[_A-Za-z][_A-Za-z0-9\.\-]*[ \t]*"="[ \t]*\"[^"\r\n\t \u2028\u2029\u000B\u000C\u1680\u2000-\u200A\u202F\u205F\u3000\u200B\u00A0\uFEFF\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u000E\u000F\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001A\u001B\u001C\u001D\u001E\u001F\u007F]+\"   { yylval.stringVal = yytext; return (int)Tokens.T_XMLNS_DECL; }
    "{"                                      { yylval.stringVal = yytext; return (int)Tokens.T_LEFT_BRACE; }
    "}"                                      { yylval.stringVal = yytext; return (int)Tokens.T_RIGHT_BRACE; }

    "*"                                      { yylval.stringVal = yytext; return (int)Tokens.T_ASTERISK; }
    "@"                                      { yylval.stringVal = yytext; return (int)Tokens.T_AT; }
    "#"                                      { yylval.stringVal = yytext; return (int)Tokens.T_POUND; }
    "$"                                      { yylval.stringVal = yytext; return (int)Tokens.T_DOLLAR; }
    "%"                                      { yylval.stringVal = yytext; return (int)Tokens.T_PERCENT; }
    "^"                                      { yylval.stringVal = yytext; return (int)Tokens.T_CARET; }
    "="                                      { yylval.stringVal = yytext; return (int)Tokens.T_EQUAL; }
    "<"                                      { yylval.stringVal = yytext; return (int)Tokens.T_LESS_THAN; }
    "&lt;"                                   { yylval.stringVal = yytext; return (int)Tokens.T_LESS_THAN; }
    ">"                                      { yylval.stringVal = yytext; return (int)Tokens.T_GREATER_THAN; }
    "&gt;"                                   { yylval.stringVal = yytext; return (int)Tokens.T_GREATER_THAN; }
    "&"                                      { yylval.stringVal = yytext; return (int)Tokens.T_AMPERSAND; }
    "!"                                      { yylval.stringVal = yytext; return (int)Tokens.T_EXCLAMATION; }
    "?"                                      { yylval.stringVal = yytext; return (int)Tokens.T_QUESTION; }
    ";"                                      { yylval.stringVal = yytext; return (int)Tokens.T_SEMICOLON; }
    "-"                                      { yylval.stringVal = yytext; return (int)Tokens.T_MINUS; }
    "+"                                      { yylval.stringVal = yytext; return (int)Tokens.T_PLUS; }
    "("                                      { yylval.stringVal = yytext; return (int)Tokens.T_LEFT_PAREN; }
    ")"                                      { yylval.stringVal = yytext; return (int)Tokens.T_RIGHT_PAREN; }
    "]"                                      { yylval.stringVal = yytext; return (int)Tokens.T_RIGHT_BRACKET; }


    #include "format/general/core.lex"
    #include "format/name/core.lex"
    #include "keyword/dbopt/core.lex"
    #include "keyword/fim/core.lex"
    #include "keyword/frame/core.lex"
    #include "whitespace.lex"


    "."                                      { yylval.stringVal = yytext; return (int)Tokens.T_PERIOD; }
    [a-zA-Z][a-zA-Z0-9\.\+\-]*:[/][/][^\r\n\t \u2028\u2029\u000B\u000C\u1680\u2000-\u200A\u202F\u205F\u3000\u200B\u00A0\uFEFF\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u000E\u000F\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001A\u001B\u001C\u001D\u001E\u001F\u007F"}]+ { yylval.stringVal = yytext; return (int)Tokens.T_URI; }
    // [a-zA-Z0-9\._%\+\-]+@[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,} { yylval.stringVal = yytext; return (int)Tokens.T_IDENTIFIER; }
    ([_A-Za-z@$‘’]|[^\u0000-\u007F\r\n\t \u2028\u2029\u000B\u000C\u1680\u2000-\u200A\u202F\u205F\u3000\u200B\u00A0\uFEFF\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u000E\u000F\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001A\u001B\u001C\u001D\u001E\u001F\u007F“”])([‘’\-A-Za-z0-9_@$\.:/;&,]|[^\u0000-\u007F\r\n\t \u2028\u2029\u000B\u000C\u1680\u2000-\u200A\u202F\u205F\u3000\u200B\u00A0\uFEFF\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u000E\u000F\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001A\u001B\u001C\u001D\u001E\u001F\u007F“”])*         { yylval.stringVal = yytext; return (int)Tokens.T_IDENTIFIER; }
    ","                                      { yylval.stringVal = yytext; return (int)Tokens.T_COMMA; }
    ":"                                      { yylval.stringVal = yytext; return (int)Tokens.T_COLON; }
    "/"                                      { yylval.stringVal = yytext; return (int)Tokens.T_SLASH; }

    "/*"                                { BEGIN(IN_COMMENT); }
    [0-9]*\.[0-9]+([eE][\+\-]?[0-9]+)?           { yylval.stringVal = yytext; return (int)Tokens.T_FLOAT; }
    \\                                            { yylval.stringVal = yytext; return (int)Tokens.T_BACKSLASH; }
    [0-9]+([eE][\+\-]?[0-9]+)              { yylval.stringVal = yytext; return (int)Tokens.T_FLOAT; }
    [0&][xXhH][0-9a-fA-F]+                 { yylval.stringVal = yytext; return (int)Tokens.T_HEX_INTEGER; }
    [0&][bB][01]+                          { yylval.stringVal = yytext; return (int)Tokens.T_BINARY_INTEGER; }
    [0-9]+                                 { yylval.stringVal = yytext; return (int)Tokens.T_INTEGER; }

    .                                      { LogText(yytext); yylval.stringVal = yytext; return (int)Tokens.T_UNKNOWN; }

}


// String surrounded by [ ], has same quoting and escaping effect as double quoted string,
// but has a different start and end delimiter.
<IN_BRACK_STRING> {
    \]\]                                   { string_buffer.Append(yytext); }
    \\\\                                   { string_buffer.Append(yytext); }
    \\]                                    { string_buffer.Append(yytext); }
    \]                                     { yyless(0); yylval.stringVal = string_buffer.ToString(); BEGIN(IN_BRACK_STRING_END); return (int)Tokens.T_STRING_CONTENT; }
    \\.                                    { string_buffer.Append(yytext); }
    [^\\\]]+                               { string_buffer.Append(yytext); }
}
<IN_BRACK_STRING_END>{
    \]                                     { yylval.stringVal = yytext; BEGIN(INITIAL); return (int)Tokens.T_RIGHT_BRACKET; }
}
<IN_BRACK_STRING_END><<EOF>>               { throw new System.FormatException("Unterminated string literal"); }

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

<IN_MERGE_FIELD_NAME>{
    "»"                                     { BEGIN(INITIAL); return (int)Tokens.T_RIGHT_GUILLEMET; }
    \\                                      { yylval.stringVal = yytext; BEGIN(IN_MERGE_FIELD_FORMATTING); return (int)Tokens.T_BACKSLASH; }
    [^\\»]+                                 { yylval.stringVal = yytext; return (int)Tokens.T_FIELD_NAME; }
}

<IN_MERGE_FIELD_FORMATTING>{
    [^»]+                                   { BEGIN(IN_MERGE_FIELD_NAME); yylval.stringVal = yytext; return (int)Tokens.T_FORMATTING_SWITCH; }
}

#include "table/state.lex"

#include "format/datetime/state.lex"
#include "format/numeric/state.lex"
#include "format/name/state.lex"
#include "format/general/state.lex"

#include "keyword/progid/state.lex"
#include "keyword/dbopt/state.lex"
#include "keyword/fim/state.lex"
#include "keyword/frame/state.lex"
#include "keyword/instruction/state.lex"
#include "keyword/function/state.lex"

<IN_COMMENT> {
    "*/"                                   { BEGIN(INITIAL); }
    .                                      { /* consume comment content */ }
}
<IN_COMMENT><<EOF>>                        { throw new System.FormatException("Unterminated comment"); }
