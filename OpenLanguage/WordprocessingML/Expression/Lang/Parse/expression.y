%namespace OpenLanguage.WordprocessingML.Expression.Generated
%parsertype Parser
%tokentype Tokens
%visibility internal

%using OpenLanguage.WordprocessingML.Ast;

%union {
    public string stringVal;
    public Node nodeVal;
    public ExpressionNode expressionVal;
    public QuoteLiteralNode quoteLiteralNodeVal;
    public LeftGuillemetLiteralNode leftGuillemetLiteralNodeVal;
    public RightGuillemetLiteralNode rightGuillemetLiteralNodeVal;
    public StringLiteralNode stringLiteralNodeVal;
    public MergeFieldNode mergeFieldNodeVal;
    public NumericLiteralNode<long> numericLiteralIntegerNodeVal;
    public NumericLiteralNode<float> numericLiteralFloatNodeVal;
    public IdentifierNode identifierNodeVal;
    public LeftParenNode leftParenNodeVal;
    public RightParenNode rightParenNodeVal;
}

%token <stringVal> T_IDENTIFIER T_STRING_CONTENT T_MERGE_FIELD_CONTENT T_WHITESPACE T_UNKNOWN
%token <stringVal>   T_INTEGER T_HEX_INTEGER T_BINARY_INTEGER
%token <stringVal> T_FLOAT
%token <stringVal> T_EQUAL T_NOT_EQUAL T_LESS_THAN T_LESS_THAN_OR_EQUAL T_GREATER_THAN T_GREATER_THAN_OR_EQUAL
%token <stringVal> T_PLUS T_MINUS T_ASTERISK T_SLASH T_CARET T_PERCENT
%token <stringVal> T_LEFT_PAREN T_RIGHT_PAREN T_QUOTE
%token T_FORMULA
%token <stringVal> T_LEFT_GUILLEMET T_RIGHT_GUILLEMET

%type <expressionVal> expression primary
%type <expressionVal> merge_field string_literal
%type <quoteLiteralNodeVal> quote
%type <nodeVal> whitespace
%type <leftGuillemetLiteralNodeVal> left_guillemet
%type <rightGuillemetLiteralNodeVal> right_guillemet
%type <stringLiteralNodeVal> merge_field_content
%type <mergeFieldNodeVal> merge_field
%type <expressionVal> parenthesized_expression
%type <leftParenNodeVal> left_paren
%type <rightParenNodeVal> right_paren
%type <numericLiteralIntegerNodeVal> integer
%type <numericLiteralFloatNodeVal> float
%type <identifierNodeVal> identifier


%token UMINUS

%left T_EQUAL T_NOT_EQUAL T_LESS_THAN T_LESS_THAN_OR_EQUAL T_GREATER_THAN T_GREATER_THAN_OR_EQUAL
%left T_FORMULA
%left T_PLUS T_MINUS
%left T_ASTERISK T_SLASH T_PERCENT
%right T_CARET
%right UMINUS


%start expression

%%

expression:
    whitespace expression { $2.LeadingWhitespace.Insert(0, $1); $$ = $2; root = $$; }
  | expression whitespace { $1.TrailingWhitespace.Add($2); $$ = $1; root = $$; }
  | primary { $$ = $1; root = $$; }
  | T_PLUS expression %prec UMINUS { $$ = new UnaryPlusNode(new PlusLiteralNode($1), $2); root = $$; }
  | T_MINUS expression %prec UMINUS { $$ = new UnaryMinusNode(new MinusLiteralNode($1), $2); root = $$; }
  | expression T_PLUS expression { $$ = new AddNode($1, new PlusLiteralNode($2), $3); root = $$; }
  | expression T_MINUS expression { $$ = new SubtractNode($1, new MinusLiteralNode($2), $3); root = $$; }
  | expression T_ASTERISK expression { $$ = new MultiplyNode($1, new AsteriskLiteralNode($2), $3); root = $$; }
  | expression T_SLASH expression { $$ = new DivideNode($1, new SlashLiteralNode($2), $3); root = $$; }
  | expression T_PERCENT { $$ = new PercentNode(new PercentLiteralNode($2), $1); root = $$; }
  | expression T_CARET expression { $$ = new PowerNode($1, new CaretLiteralNode($2), $3); root = $$; }
  | expression T_EQUAL expression { $$ = new EqualNode($1, new EqualLiteralNode($2), $3); root = $$; }
  | expression T_NOT_EQUAL expression { $$ = new NotEqualNode($1, new NotEqualLiteralNode($2), $3); root = $$; }
  | expression T_LESS_THAN expression { $$ = new LessThanNode($1, new LessThanLiteralNode($2), $3); root = $$; }
  | expression T_LESS_THAN_OR_EQUAL expression { $$ = new LessThanOrEqualNode($1, new LessThanOrEqualLiteralNode($2), $3); root = $$; }
  | expression T_GREATER_THAN expression { $$ = new GreaterThanNode($1, new GreaterThanLiteralNode($2), $3); root = $$; }
  | expression T_GREATER_THAN_OR_EQUAL expression { $$ = new GreaterThanOrEqualNode($1, new GreaterThanOrEqualLiteralNode($2), $3); root = $$; }
  ;

identifier:
    whitespace identifier { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | identifier whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_IDENTIFIER { $$ = new IdentifierNode($1); }
  ;

integer:
    whitespace integer { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | integer whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_BINARY_INTEGER { $$ = new OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<int>($1, int.Parse($1, NumberStyles.AllowBinarySpecifier | NumberStyles.BinaryNumber, System.Globalization.CultureInfo.InvariantCulture), "B"); }
  | T_HEX_INTEGER    { $$ = new OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<int>($1, int.Parse($1, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture), "H"); }
  | T_INTEGER { $$ = new OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<int>($1, int.Parse($1, System.Globalization.CultureInfo.InvariantCulture), "D"); }
  ;

float:
    whitespace float { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | float whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FLOAT { $$ = new NumericLiteralNode<float>($1, float.Parse($1, System.Globalization.CultureInfo.InvariantCulture), string.Empty); }
  ;

parenthesized_expression:
    whitespace parenthesized_expression { $2.LeadingWhitespace.Insert(0, $1); $$ = $2; }
  | parenthesized_expression whitespace { $1.TrailingWhitespace.Add($2); $$ = $1; }
  | left_paren expression right_paren { $$ = new ParenthesizedExpressionNode($1, $2, $3); }
  ;
primary:
    whitespace primary { $2.LeadingWhitespace.Insert(0, $1); $$ = $2; }
  | primary whitespace { $1.TrailingWhitespace.Add($2); $$ = $1; }
  | identifier { $$ = $1; }
  | integer { $$ = $1; }
  | float { $$ = $1; }
  | string_literal { $$ = $1; }
  | merge_field { $$ = $1; }
  | parenthesized_expression { $$ = $1; }
  ;

string_literal:
    whitespace string_literal      { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | string_literal whitespace      { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote string_literal quote     { $$ = new Quoted<ExpressionNode>($1, $2, $3); }
  | quote quote                    { $$ = new Quoted<ExpressionNode>($1, new EmptyExpressionNode(), $2); }
  | T_STRING_CONTENT               { $$ = new StringLiteralNode($1); }
  ;

quote:
    whitespace quote { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | quote whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_QUOTE          { $$ = new QuoteLiteralNode($1); }
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

merge_field_content:
    whitespace merge_field_content { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | merge_field_content whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_MERGE_FIELD_CONTENT { $$ = new StringLiteralNode($1); }
  ;

merge_field:
    whitespace merge_field { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | merge_field whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | left_guillemet merge_field_content right_guillemet { $$ = new MergeFieldNode($1, $2, $3); }
  ;

whitespace:
    T_WHITESPACE { $$ = new WhitespaceNode($1); }
  ;

left_paren:
    whitespace left_paren { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | left_paren whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LEFT_PAREN { $$ = new LeftParenNode($1); }
  ;

right_paren:
    whitespace right_paren { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | right_paren whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_RIGHT_PAREN { $$ = new RightParenNode($1); }
  ;

%%

public Node root;
internal Parser(OpenLanguage.WordprocessingML.Expression.Generated.ExpressionScanner scanner) : base(scanner)
{
  scanner.Parser = this;
}
