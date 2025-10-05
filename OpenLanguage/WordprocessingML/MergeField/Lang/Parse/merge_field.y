%namespace OpenLanguage.WordprocessingML.MergeField.Generated
%parsertype Parser
%tokentype Tokens
%visibility internal

%using OpenLanguage.WordprocessingML.Ast;

%union {
    public string stringVal;
    public MergeFieldNode mergeFieldVal;
    public Node whitespaceVal;
    public LeftGuillemetLiteralNode leftGuillemetVal;
    public RightGuillemetLiteralNode rightGuillemetVal;
    public ExpressionNode expressionVal;
    public BoolFlagNode boolFlagVal;
    public QuoteLiteralNode quoteVal;
}

%token <stringVal> T_FIELD_NAME T_FORMATTING_SWITCH T_WHITESPACE T_UNKNOWN
%token <stringVal> T_BACKSLASH T_QUOTE
%token <stringVal> T_LEFT_GUILLEMET T_RIGHT_GUILLEMET

%type <mergeFieldVal> merge_field
%type <whitespaceVal> whitespace
%type <leftGuillemetVal> left_guillemet
%type <rightGuillemetVal> right_guillemet
%type <expressionVal> field_name
%type <boolFlagVal> formatting_switch
%type <quoteVal> quote

%start merge_field

%%

merge_field:
    whitespace merge_field { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); root = $$; }
  | merge_field whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); root = $$; }
  | left_guillemet field_name right_guillemet
      { $$ = new MergeFieldNode($1, $2, $3); root = $$; }
  | left_guillemet field_name formatting_switch right_guillemet
      { $$ = new MergeFieldNode($1, $2, $3, $4); root = $$; }
  ;

left_guillemet:
    whitespace left_guillemet { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | left_guillemet whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LEFT_GUILLEMET { $$ = new LeftGuillemetLiteralNode($1); }
  ;

right_guillemet:
    whitespace right_guillemet { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | right_guillemet whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_RIGHT_GUILLEMET { $$ = new RightGuillemetLiteralNode($1); }
  ;

field_name:
    whitespace field_name { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | field_name whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote field_name quote { $$ = new Quoted<ExpressionNode>($1, $2, $3); }
  | quote quote { $$ = new Quoted<ExpressionNode>($1, new EmptyExpressionNode(), $2); }
  | T_FIELD_NAME { $$ = new StringLiteralNode($1); }
  ;

quote:
    whitespace quote { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | quote whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_QUOTE { $$ = new QuoteLiteralNode($1); }
  ;

formatting_switch:
    whitespace formatting_switch { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | formatting_switch whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_BACKSLASH T_FORMATTING_SWITCH { $$ = new BoolFlagNode($1 + $2); }
  ;

whitespace:
    T_WHITESPACE { $$ = new WhitespaceNode($1); }
  ;

%%

public Node root;
internal Parser(OpenLanguage.WordprocessingML.MergeField.Generated.Scanner scanner) : base(scanner)
{
  scanner.Parser = this;
}
