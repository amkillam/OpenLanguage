%namespace OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated
%parsertype Parser
%tokentype Tokens
%visibility internal

%using OpenLanguage.WordprocessingML.Ast;


%union {
    public string stringVal;
    public TemplateNode templateVal;
    public MergeFieldElementNode mergeFieldVal;
    public TextElementNode textVal;
    public ExpressionNode expressionVal;
    public BoolFlagNode boolFlagVal;
    public List<ExpressionNode> expressionListVal;
    public Node nodeVal;
    public LeftGuillemetLiteralNode leftGuillemetVal;
    public RightGuillemetLiteralNode rightGuillemetVal;
    public QuoteLiteralNode quoteVal;
}

%token <stringVal> T_TEXT T_STRING_CONTENT
%token <stringVal> T_LEFT_GUILLEMET T_RIGHT_GUILLEMET
%token <stringVal> T_FIELD_NAME T_FORMATTING_SWITCH
%token <stringVal> T_BACKSLASH T_QUOTE T_WHITESPACE

%type <templateVal> template
%type <expressionListVal> element_list
%type <expressionVal> element
%type <textVal> text_element
%type <mergeFieldVal> merge_field_element
%type <expressionVal> field_name
%type <boolFlagVal> formatting_switch
%type <nodeVal> whitespace
%type <leftGuillemetVal> left_guillemet
%type <rightGuillemetVal> right_guillemet
%type <quoteVal> quote

%start template

%%

template:
    whitespace template { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); root = $$; }
  | template whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); root = $$; }
  | element_list { $$ = new TemplateNode($1); root = $$; }
  | /* empty */  { $$ = new TemplateNode(new List<ExpressionNode>()); root = $$; }
  ;

element_list:
    element_list element
      {
          List<ExpressionNode> list = $1;
          list.Add($2);
          $$ = list;
      }
  | element
      {
          $$ = new List<ExpressionNode> { $1 };
      }
  ;

element:
    whitespace element { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | element whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | text_element        { $$ = $1; }
  | merge_field_element { $$ = $1; }
  ;

text_element:
    whitespace text_element { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | text_element whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_TEXT { $$ = new TextElementNode($1); }
  ;

merge_field_element:
    whitespace merge_field_element { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | merge_field_element whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | left_guillemet field_name right_guillemet
      { $$ = new MergeFieldElementNode($1, $2, $3); }
  | left_guillemet field_name formatting_switch right_guillemet
      { $$ = new MergeFieldElementNode($1, $2, $3, $4); }
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
internal Parser(OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.MergeFieldTemplateScanner scanner) : base(scanner)
{
  scanner.Parser = this;
}
