%namespace OpenLanguage.WordprocessingML.FieldInstruction.Generated
%parsertype Parser
%tokentype Tokens
%visibility internal

%using OpenLanguage.WordprocessingML.Ast;
%using OpenLanguage.WordprocessingML.FieldInstruction;
%using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
%using OpenLanguage.WordprocessingML.Operators;
%using OpenLanguage.WordprocessingML;
%using System.Data.Odbc;
%using System.Xml.XPath;
%using System.Linq;

%union {
    public string stringVal;
    public NumericLiteralNode<int> intNodeVal;
    public NumericLiteralNode<float> floatNodeVal;
    public Node nodeVal;
    public ExpressionNode expressionVal;
    public MergeFieldNode mergeFieldNodeVal;
    public OpenLanguage.WordprocessingML.FieldInstruction.Ast.FieldInstruction fieldInstructionVal;
    public OpenLanguage.WordprocessingML.FieldInstruction.Ast.NestedFieldInstruction nestedFieldInstructionVal;

    #include "switch/union.inc"
    #include "progid/union.inc"
    #include "instruction/union.inc"
    #include "function/union.inc"
    #include "table/union.inc"
    #include "language_identifier/union.inc"

    public OpenLanguage.WordprocessingML.FieldInstruction.Generated.NameFormatNode nameFormatNodeVal;
    public OpenLanguage.WordprocessingML.FieldInstruction.Generated.DatabaseOptimizationFlagNode dbOptFlagNodeVal;

    public OpenLanguage.WordprocessingML.FieldInstruction.Generated.EqArgumentList eqArgListVal;
    public ExpressionListNode expressionListNodeVal;
    public OpenLanguage.WordprocessingML.FieldInstruction.Generated.FrameTargetNode frameTargetNodeVal;
    public LeftBracketNode leftBracketNodeVal;
    public RightBracketNode rightBracketNodeVal;
    public OpenLanguage.WordprocessingML.FieldInstruction.Generated.NamespaceDeclarationNode namespaceDeclNodeVal;

    public StringLiteralNode stringLiteralNodeVal;
    public FlaggedArgument<ExpressionNode> flaggedStringLiteralVal;
    public FlaggedArgument<ExpressionNode> flaggedExpressionVal;

    public LeftParenNode leftParenNodeVal;
    public RightParenNode rightParenNodeVal;
    public LeftBraceNode leftBraceNodeVal;
    public RightBraceNode rightBraceNodeVal;
    public LeftGuillemetLiteralNode leftGuillemetLiteralNodeVal;
    public RightGuillemetLiteralNode rightGuillemetLiteralNodeVal;
    public PlusLiteralNode plusLiteralNodeVal;
    public MinusLiteralNode minusLiteralNodeVal;
    public AsteriskLiteralNode asteriskLiteralNodeVal;
    public SlashLiteralNode slashLiteralNodeVal;
    public CaretLiteralNode caretLiteralNodeVal;
    public CommaNode commaNodeVal;
    public SemicolonNode semicolonNodeVal;
    public QuoteLiteralNode quoteLiteralNodeVal;
    public ColonNode colonNodeVal;

    public EqualLiteralNode equalLiteralNodeVal;
    public NotEqualLiteralNode notEqualLiteralNodeVal;
    public LessThanLiteralNode lessThanLiteralNodeVal;
    public LessThanOrEqualLiteralNode lessThanOrEqualLiteralNodeVal;
    public GreaterThanLiteralNode greaterThanLiteralNodeVal;
    public GreaterThanOrEqualLiteralNode greaterThanOrEqualLiteralNodeVal;

    public CharacterLiteralNode charLiteralNodeVal;
}

#include "progid/token.inc"
#include "switch/token.inc"
#include "instruction/token.inc"
#include "function/token.inc"
#include "table/token.inc"

#include "format/datetime/token.inc"
#include "format/numeric/token.inc"

#include "language_identifier/token.inc"

%token <stringVal> T_AMPERSAND
%token <stringVal> T_LEFT_GUILLEMET T_RIGHT_GUILLEMET
%token <stringVal> T_FIELD_NAME T_FORMATTING_SWITCH
%token <stringVal> T_NAMEFORMAT_FIRSTNAME T_NAMEFORMAT_LASTNAME T_NAMEFORMAT_FIRSTLASTNAME T_NAMEFORMAT_LASTFIRSTNAME T_NAMEFORMAT_TITLELASTNAME
%token <stringVal> T_NAMEFORMAT_FULLFORMALNAME
%token <stringVal> T_DBOPT_NONE T_DBOPT_QUERYONCE T_DBOPT_CACHERESULTS T_DBOPT_USECONNECTIONPOOLING T_DBOPT_OPTIMIZEFORLARGEDATA T_DBOPT_OPTIMIZEFORSMALLDATA
%token <stringVal> T_IDENTIFIER T_STRING_CONTENT T_WHITESPACE T_UNKNOWN
%token <stringVal> T_XMLNS_DECL
%token <stringVal> T_URI
%token <stringVal> T_INTEGER T_HEX_INTEGER T_BINARY_INTEGER
%token <stringVal> T_FLOAT

%token <stringVal> T_QUOTE T_BACKSLASH T_AT
%token <stringVal> T_LEFT_BRACE T_RIGHT_BRACE T_ASTERISK T_POUND T_DOLLAR
%token <stringVal> T_PERCENT T_CARET T_EXCLAMATION T_QUESTION
%token <stringVal> T_COLON T_SEMICOLON T_COMMA T_PERIOD T_SLASH T_MINUS T_PLUS T_LEFT_PAREN T_RIGHT_PAREN
%token <stringVal> T_LEFT_BRACKET T_RIGHT_BRACKET
%token <stringVal> T_EQUAL T_LESS_THAN T_GREATER_THAN T_LESS_THAN_OR_EQUAL T_GREATER_THAN_OR_EQUAL T_NOT_EQUAL
%token <stringVal> T_FRAME_TARGET_TOP T_FRAME_TARGET_SELF T_FRAME_TARGET_BLANK T_FRAME_TARGET_PARENT
%token <stringVal> T_FIM_COURTESY_REPLY T_FIM_BUSINESS_REPLY

%type <fieldInstructionVal> field_instruction
%type <fieldInstructionVal> base_field_instruction
%type <expressionVal> expression primary root string_literal identifier
%type <expressionVal> gotobutton_argument
%type <expressionVal> argument_expression
%type <nestedFieldInstructionVal> braced_field_instruction
%type <expressionVal> identifier_or_string string_literal
%type <stringLiteralNodeVal> mergeformat charformat
%type <expressionVal> uri
%type <stringVal> identifier_or_string_raw
%type <nodeVal> whitespace
%type <equalLiteralNodeVal> formula_prefix
%type <commaNodeVal> comma
%type <semicolonNodeVal> semicolon
%type <leftParenNodeVal> left_paren
%type <rightParenNodeVal> right_paren
%type <leftBraceNodeVal> left_brace
%type <rightBraceNodeVal> right_brace
%type <nameFormatNodeVal>      name_format
%type <dbOptFlagNodeVal>       optimization_flag
%type <expressionVal> addressblock_template
%type <eqArgListVal> eq_argument_list
%type <expressionVal> country_region_incl
%type <leftBracketNodeVal> left_bracket
%type <rightBracketNodeVal> right_bracket
%type <frameTargetNodeVal> frame_target
%type <floatNodeVal> float
%type <intNodeVal>   integer
%type <namespaceDeclNodeVal>   namespace_decl
%type <expressionVal>     float_list
%type <expressionVal>     float_list_contents
%type <flaggedStringLiteralVal>  xslt_path
%type <flaggedExpressionVal>          xpath
%type <expressionVal>          font_size
%type <mergeFieldNodeVal> merge_field
%type <leftGuillemetLiteralNodeVal> left_guillemet
%type <rightGuillemetLiteralNodeVal> right_guillemet
%type <expressionVal> field_name
%type <boolFlagNodeVal> formatting_switch
%type <quoteLiteralNodeVal> quote
%type <colonNodeVal> colon
%type <expressionListNodeVal> expr_list

%type <equalLiteralNodeVal> equal
%type <notEqualLiteralNodeVal> not_equal
%type <lessThanLiteralNodeVal> less_than
%type <lessThanOrEqualLiteralNodeVal> less_than_or_equal
%type <greaterThanLiteralNodeVal> greater_than
%type <greaterThanOrEqualLiteralNodeVal> greater_than_or_equal
%type <plusLiteralNodeVal> plus
%type <minusLiteralNodeVal> minus
%type <asteriskLiteralNodeVal> asterisk
%type <slashLiteralNodeVal> slash
%type <caretLiteralNodeVal> caret

%token UMINUS

%right T_CARET

%left UMINUS
%left T_ASTERISK T_SLASH
%left T_PLUS T_MINUS
// %right T_LEFT_PAREN
// %right T_LEFT_BRACE

// %nonassoc T_RIGHT_PAREN
// %nonassoc T_RIGHT_BRACE

%left T_COLON T_COMMA T_SEMICOLON
%left T_WHITESPACE

%nonassoc T_AUTHOR_INSTRUCTION
%nonassoc T_COMMENTS_INSTRUCTION
%nonassoc T_CREATEDATE_INSTRUCTION
%nonassoc T_EDITTIME_INSTRUCTION
%nonassoc T_FILENAME_INSTRUCTION
%nonassoc T_FILESIZE_INSTRUCTION
%nonassoc T_KEYWORDS_INSTRUCTION
%nonassoc T_LASTSAVEDBY_INSTRUCTION
%nonassoc T_NUMCHARS_INSTRUCTION
%nonassoc T_NUMPAGES_INSTRUCTION
%nonassoc T_NUMWORDS_INSTRUCTION
%nonassoc T_PRINTDATE_INSTRUCTION
%nonassoc T_REVNUM_INSTRUCTION
%nonassoc T_SAVEDATE_INSTRUCTION
%nonassoc T_SUBJECT_INSTRUCTION
%nonassoc T_TEMPLATE
%nonassoc T_TITLE_INSTRUCTION

// %nonassoc T_EQUAL T_NOT_EQUAL T_LESS_THAN
// %nonassoc T_LESS_THAN_OR_EQUAL T_GREATER_THAN T_GREATER_THAN_OR_EQUAL


#include "progid/type.inc"
#include "switch/type.inc"
#include "instruction/type.inc"
#include "function/type.inc"
#include "table/type.inc"
#include "language_identifier/type.inc"

#include "format/datetime/type.inc"
#include "format/numeric/type.inc"
#include "format/general/type.inc"

%type <charLiteralNodeVal> char_arg

%start root
%%

#include "switch/rule.inc"
#include "progid/rule.inc"
#include "instruction/rule.inc"

#include "function/rule.inc"
#include "table/rule.inc"

#include "format/datetime/rule.inc"
#include "format/numeric/rule.inc"
#include "format/general/rule.inc"

#include "language_identifier/rule.inc"

root:
    field_instruction EOF        { $$ = $1; root = $$; }
  | braced_field_instruction EOF { $$ = $1; root = $$; }
  | /* empty */ EOF             { $$ = new EmptyExpressionNode(); root = $$; }
  | error                        { root = null; YYABORT; }
  ;

field_instruction:
    base_field_instruction { $$ = $1; }
  ;

expression:
    left_paren expression right_paren             { $$ = new ParenthesizedExpressionNode($1, $2, $3); }
  | expression plus expression                    { $$ = new AddNode($1, $2, $3); }
  | expression minus expression                   { $$ = new SubtractNode($1, $2, $3); }
  | expression asterisk expression                { $$ = new MultiplyNode($1, $2, $3); }
  | expression slash expression                   { $$ = new DivideNode($1, $2, $3); }
  | expression caret expression                   { $$ = new PowerNode($1, $2, $3); }
  | expression  equal  expression                 { $$ = new EqualNode($1, $2, $3); }
  | expression  not_equal  expression             { $$ = new NotEqualNode($1, $2, $3); }
  | expression  less_than  expression             { $$ = new LessThanNode($1, $2, $3); }
  | expression  less_than_or_equal  expression    { $$ = new LessThanOrEqualNode($1, $2, $3); }
  | expression  greater_than  expression          { $$ = new GreaterThanNode($1, $2, $3); }
  | expression  greater_than_or_equal  expression { $$ = new GreaterThanOrEqualNode($1, $2, $3); }
  | expression colon expression                   { $$ = new RangeNode($1, $2, $3); }
  | plus expression %prec UMINUS                  { $$ = new UnaryPlusNode($1, $2); }
  | minus expression %prec UMINUS                 { $$ = new UnaryMinusNode($1, $2); }
  | primary                                       { $$ = $1; }
  ;

base_field_instruction:
    addressblock_field_instruction { $$ = $1; }
  | advance_field_instruction { $$ = $1; }
  | ask_field_instruction { $$ = $1; }
  | author_field_instruction { $$ = $1; }
  | autonum_field_instruction { $$ = $1; }
  | autonumlgl_field_instruction { $$ = $1; }
  | autonumout_field_instruction { $$ = $1; }
  | autotext_field_instruction { $$ = $1; }
  | autotextlist_field_instruction { $$ = $1; }
  | barcode_field_instruction { $$ = $1; }
  | bibliography_field_instruction { $$ = $1; }
  | bidioutline_field_instruction { $$ = $1; }
  | citation_field_instruction { $$ = $1; }
  | comments_field_instruction { $$ = $1; }
  | compare_field_instruction { $$ = $1; }
  | createdate_field_instruction { $$ = $1; }
  | database_field_instruction { $$ = $1; }
  | date_field_instruction { $$ = $1; }
  | dde_field_instruction { $$ = $1; }
  | ddeauto_field_instruction { $$ = $1; }
  | docproperty_field_instruction { $$ = $1; }
  | docvariable_field_instruction { $$ = $1; }
  | edittime_field_instruction { $$ = $1; }
  | embed_field_instruction { $$ = $1;}
  | eq_field_instruction { $$ = $1; }
  | filename_field_instruction { $$ = $1; }
  | filesize_field_instruction { $$ = $1; }
  | fillin_field_instruction { $$ = $1; }
  | formcheckbox_field_instruction { $$ = $1; }
  | formdropdown_field_instruction { $$ = $1; }
  | formtext_field_instruction { $$ = $1; }
  | formula_field_instruction { $$ = $1; }
  | gotobutton_field_instruction { $$ = $1; }
  | glossary_instruction { $$ = $1; }
  | greetingline_field_instruction { $$ = $1; }
  | hyperlink_field_instruction { $$ = $1; }
  | if_field_instruction { $$ = $1; }
  | include_instruction { $$ = $1; }
  | info_field_instruction { $$ = $1; }
  | import_instruction { $$ = $1; }
  | includepicture_field_instruction { $$ = $1; }
  | includetext_field_instruction { $$ = $1; }
  | index_field_instruction { $$ = $1; }
  | keywords_field_instruction { $$ = $1; }
  | lastsavedby_field_instruction { $$ = $1; }
  | link_field_instruction { $$ = $1; }
  | listnum_field_instruction { $$ = $1; }
  | macrobutton_field_instruction { $$ = $1; }
  | mergefield_field_instruction { $$ = $1; }
  | mergerec_field_instruction { $$ = $1; }
  | mergeseq_field_instruction { $$ = $1; }
  | next_field_instruction { $$ = $1; }
  | nextif_field_instruction { $$ = $1; }
  | noteref_field_instruction { $$ = $1; }
  | numchars_field_instruction { $$ = $1; }
  | numpages_field_instruction { $$ = $1; }
  | numwords_field_instruction { $$ = $1; }
  | page_field_instruction { $$ = $1; }
  | pageref_field_instruction { $$ = $1; }
  | printdate_field_instruction { $$ = $1; }
  | private_field_instruction     { $$ = $1; }
  | print_field_instruction { $$ = $1; }
  | quote_field_instruction { $$ = $1; }
  | rd_field_instruction { $$ = $1; }
  | ref_field_instruction { $$ = $1; }
  | revnum_field_instruction { $$ = $1; }
  | savedate_field_instruction { $$ = $1; }
  | section_field_instruction { $$ = $1; }
  | sectionpages_field_instruction { $$ = $1; }
  | shape_field_instruction { $$ = $1; }
  | seq_field_instruction { $$ = $1; }
  | set_field_instruction { $$ = $1; }
  | skipif_field_instruction { $$ = $1; }
  | styleref_field_instruction { $$ = $1; }
  | subject_field_instruction { $$ = $1; }
  | symbol_field_instruction { $$ = $1; }
  | ta_field_instruction { $$ = $1; }
  | tc_field_instruction { $$ = $1; }
  | template_field_instruction { $$ = $1; }
  | time_field_instruction { $$ = $1; }
  | title_field_instruction { $$ = $1; }
  | toa_field_instruction { $$ = $1; }
  | toc_field_instruction { $$ = $1; }
  | useraddress_field_instruction { $$ = $1; }
  | userinitials_field_instruction { $$ = $1; }
  | username_field_instruction { $$ = $1; }
  | xe_field_instruction { $$ = $1; }
  ;

primary:
    braced_field_instruction { $$ = $1; }
  | field_instruction { $$ = $1; }
  | func_call                                 { $$ = $1; }
  | cell_ref_list                             { $$ = $1; }
  | float                                     { $$ = $1; }
  | integer                                   { $$ = $1; }
  | string_literal                            { $$ = $1; }
  | merge_field                               { $$ = $1; }
  | identifier                                { $$ = $1; }
  | uri                                       { $$ = $1; }
  | identifier_or_string                      { $$ = $1; }
  | name_format                               { $$ = $1; }
  | quote                                     { $$ = $1; }
  ;

mergeformat:
    whitespace mergeformat { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | mergeformat whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_MERGEFORMAT          { $$ = new StringLiteralNode($1); }
  ;

charformat:
    whitespace charformat  { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | charformat whitespace  { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_CHARFORMAT           { $$ = new StringLiteralNode($1); }
  ;

left_guillemet:
    whitespace left_guillemet { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | left_guillemet whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LEFT_GUILLEMET          { $$ = new LeftGuillemetLiteralNode($1); }
  ;

right_guillemet:
    whitespace right_guillemet { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | right_guillemet whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_RIGHT_GUILLEMET          { $$ = new RightGuillemetLiteralNode($1); }
  ;

field_name:
    whitespace field_name  { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | field_name whitespace  { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote field_name quote { $$ = new Quoted<ExpressionNode>($1, $2, $3); }
  | T_FIELD_NAME           { $$ = new StringLiteralNode($1); }
  ;

formatting_switch:
    whitespace formatting_switch    { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | formatting_switch whitespace    { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_BACKSLASH T_FORMATTING_SWITCH { $$ = new BoolFlagNode($1 + $2); }
  ;
merge_field:
    whitespace merge_field                    { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | merge_field whitespace                    { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | merge_field formatting_switch             { $$ = $1; $$.FormattingSwitch = $2; }
  | left_guillemet field_name right_guillemet { $$ = new MergeFieldNode($1, $2, $3); }
  ;

equal:
    whitespace equal { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | equal whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_EQUAL          { $$ = new EqualLiteralNode($1); }
  ;

formula_prefix:
    whitespace formula_prefix { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | formula_prefix whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_EQUAL                   { $$ = new EqualLiteralNode($1); }
  ;

not_equal:
    whitespace not_equal { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | not_equal whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_NOT_EQUAL          { $$ = new NotEqualLiteralNode($1); }
  ;

less_than:
    whitespace less_than { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | less_than whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LESS_THAN          { $$ = new LessThanLiteralNode($1); }
  ;

less_than_or_equal:
    whitespace less_than_or_equal { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | less_than_or_equal whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LESS_THAN_OR_EQUAL          { $$ = new LessThanOrEqualLiteralNode($1); }
  ;

greater_than:
    whitespace greater_than { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | greater_than whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_GREATER_THAN          { $$ = new GreaterThanLiteralNode($1); }
  ;

greater_than_or_equal:
    whitespace greater_than_or_equal { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | greater_than_or_equal whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_GREATER_THAN_OR_EQUAL          { $$ = new GreaterThanOrEqualLiteralNode($1); }
  ;

plus:
    whitespace plus { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | plus whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_PLUS          { $$ = new PlusLiteralNode($1); }
  ;

minus:
    whitespace minus { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | minus whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_MINUS          { $$ = new MinusLiteralNode($1); }
  ;

asterisk:
    whitespace asterisk { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | asterisk whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_ASTERISK          { $$ = new AsteriskLiteralNode($1); }
  ;

slash:
    whitespace slash { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | slash whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SLASH          { $$ = new SlashLiteralNode($1); }
  ;

caret:
    whitespace caret { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | caret whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_CARET          { $$ = new CaretLiteralNode($1); }
  ;

string_literal:
    whitespace string_literal { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | string_literal whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote T_STRING_CONTENT quote { $$ = new Quoted<ExpressionNode>($1, new StringLiteralNode($2), $3); }
  | quote quote { $$ = new Quoted<ExpressionNode>($1, new EmptyExpressionNode(), $2); }
  ;

uri:
    whitespace uri           { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | uri whitespace           { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote uri quote          { $$ = new Quoted<ExpressionNode>($1, $2, $3); }
  | T_URI                    { $$ = new UriNode($1); }
  ;

identifier:
    whitespace identifier { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | identifier whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote identifier quote { $$ = new Quoted<ExpressionNode>($1, $2, $3); }
  | left_bracket identifier right_bracket { $$ = new BracketedExpressionNode($1, $2, $3); }
  | T_IDENTIFIER           { $$ = new IdentifierNode($1); }
  ;


identifier_or_string:
    whitespace identifier_or_string                 { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | identifier_or_string whitespace                 { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote T_STRING_CONTENT quote                    { $$ = new Quoted<ExpressionNode>($1, new StringLiteralNode($2), $3); }
  | quote quote                                     { $$ = new Quoted<ExpressionNode>($1, new EmptyExpressionNode(), $2); }
  | left_bracket identifier_or_string right_bracket { $$ = new BracketedExpressionNode($1, $2, $3); }
  | left_bracket right_bracket                      { $$ = new BracketedExpressionNode($1, new EmptyExpressionNode(), $2); }
  | quote identifier_or_string_raw quote            { $$ = new Quoted<ExpressionNode>($1, new StringLiteralNode($2), $3); }
  | identifier_or_string_raw                        { $$ = new StringLiteralNode($1); }
  ;

identifier_or_string_raw:
    T_AMPERSAND
  | T_AT { $$ = $1; }
  | T_CHARFORMAT { $$ = $1; }
  | T_COLON { $$ = $1; }
  | T_COMMA { $$ = $1; }
  | T_DBOPT_CACHERESULTS { $$ = $1; }
  | T_DBOPT_NONE { $$ = $1; }
  | T_DBOPT_OPTIMIZEFORLARGEDATA { $$ = $1; }
  | T_DBOPT_OPTIMIZEFORSMALLDATA { $$ = $1; }
  | T_DBOPT_QUERYONCE { $$ = $1; }
  | T_DBOPT_USECONNECTIONPOOLING { $$ = $1; }
  | T_DOLLAR { $$ = $1; }
  | T_EXCLAMATION { $$ = $1; }
  | T_FIELD_NAME { $$ = $1; }
  | T_FIM_BUSINESS_REPLY { $$ = $1; }
  | T_FIM_COURTESY_REPLY { $$ = $1; }
  | T_FORMATTING_SWITCH { $$ = $1; }
  | T_FRAME_TARGET_BLANK { $$ = $1; }
  | T_FRAME_TARGET_PARENT { $$ = $1; }
  | T_FRAME_TARGET_SELF { $$ = $1; }
  | T_FRAME_TARGET_TOP { $$ = $1; }
  | T_IDENTIFIER { $$ = $1; }
  | T_INTEGER { $$ = $1; }
  | T_HEX_INTEGER { $$ = $1; }
  | T_BINARY_INTEGER { $$ = $1; }
  | T_BINARY_INTEGER { $$ = $1; }
  | T_MERGEFORMAT { $$ = $1; }
  | T_NAMEFORMAT_FIRSTLASTNAME { $$ = $1; }
  | T_NAMEFORMAT_FIRSTNAME { $$ = $1; }
  | T_NAMEFORMAT_FULLFORMALNAME { $$ = $1; }
  | T_NAMEFORMAT_LASTFIRSTNAME { $$ = $1; }
  | T_NAMEFORMAT_LASTNAME { $$ = $1; }
  | T_NAMEFORMAT_TITLELASTNAME { $$ = $1; }
  | T_PERIOD { $$ = $1; }
  | T_POUND { $$ = $1; }
  | T_QUESTION { $$ = $1; }
  | T_SEMICOLON { $$ = $1; }
  | T_XMLNS_DECL { $$ = $1; }
  | T_ADDRESSBLOCK_INSTRUCTION { $$ = $1; }
  | T_ADVANCE_INSTRUCTION { $$ = $1; }
  | T_ASK_INSTRUCTION { $$ = $1; }
  | T_AUTHOR_INSTRUCTION { $$ = $1; }
  | T_AUTONUM_INSTRUCTION { $$ = $1; }
  | T_AUTONUMLGL_INSTRUCTION { $$ = $1; }
  | T_AUTONUMOUT_INSTRUCTION { $$ = $1; }
  | T_AUTOTEXT_INSTRUCTION { $$ = $1; }
  | T_AUTOTEXTLIST_INSTRUCTION { $$ = $1; }
  | T_BARCODE_INSTRUCTION { $$ = $1; }
  | T_BIBLIOGRAPHY_INSTRUCTION { $$ = $1; }
  | T_BIDIOUTLINE_INSTRUCTION { $$ = $1; }
  | T_CITATION_INSTRUCTION { $$ = $1; }
  | T_COMMENTS_INSTRUCTION { $$ = $1; }
  | T_COMPARE_INSTRUCTION { $$ = $1; }
  | T_CREATEDATE_INSTRUCTION { $$ = $1; }
  | T_DATABASE_INSTRUCTION { $$ = $1; }
  | T_DATE_INSTRUCTION { $$ = $1; }
  | T_DDE_INSTRUCTION { $$ = $1; }
  | T_DDEAUTO_INSTRUCTION { $$ = $1; }
  | T_DOCPROPERTY_INSTRUCTION { $$ = $1; }
  | T_DOCVARIABLE_INSTRUCTION { $$ = $1; }
  | T_EDITTIME_INSTRUCTION { $$ = $1; }
  | T_EMBED_INSTRUCTION { $$ = $1; }
  | T_EQ_INSTRUCTION { $$ = $1; }
  | T_FILENAME_INSTRUCTION { $$ = $1; }
  | T_FILESIZE_INSTRUCTION { $$ = $1; }
  | T_FILLIN_INSTRUCTION { $$ = $1; }
  | T_FORMCHECKBOX_INSTRUCTION { $$ = $1; }
  | T_FORMDROPDOWN_INSTRUCTION { $$ = $1; }
  | T_FORMTEXT_INSTRUCTION { $$ = $1; }
  | T_GOTOBUTTON_INSTRUCTION { $$ = $1; }
  | T_GREETINGLINE_INSTRUCTION { $$ = $1; }
  | T_HYPERLINK_INSTRUCTION { $$ = $1; }
  | T_IF_INSTRUCTION { $$ = $1; }
  | T_INCLUDEPICTURE_INSTRUCTION { $$ = $1; }
  | T_INCLUDETEXT_INSTRUCTION { $$ = $1; }
  | T_INDEX_INSTRUCTION { $$ = $1; }
  | T_INFO_INSTRUCTION { $$ = $1; }

  | T_KEYWORDS_INSTRUCTION { $$ = $1; }
  | T_LASTSAVEDBY_INSTRUCTION { $$ = $1; }
  | T_LINK_INSTRUCTION { $$ = $1; }
  | T_LISTNUM_INSTRUCTION { $$ = $1; }
  | T_MACROBUTTON_INSTRUCTION { $$ = $1; }
  | T_MERGEFIELD_INSTRUCTION { $$ = $1; }
  | T_MERGEREC_INSTRUCTION { $$ = $1; }
  | T_MERGESEQ_INSTRUCTION { $$ = $1; }
  | T_NEXT_INSTRUCTION { $$ = $1; }
  | T_NEXTIF_INSTRUCTION { $$ = $1; }
  | T_NOTEREF_INSTRUCTION { $$ = $1; }
  | T_NUMCHARS_INSTRUCTION { $$ = $1; }
  | T_NUMPAGES_INSTRUCTION { $$ = $1; }
  | T_NUMWORDS_INSTRUCTION { $$ = $1; }
  | T_PAGE { $$ = $1; }
  | T_PAGEREF_INSTRUCTION { $$ = $1; }
  | T_PRINT_INSTRUCTION { $$ = $1; }
  | T_PRINTDATE_INSTRUCTION { $$ = $1; }
  | T_PRIVATE_INSTRUCTION { $$ = $1; }
  | T_QUOTE_INSTRUCTION { $$ = $1; }
  | T_RD_INSTRUCTION { $$ = $1; }
  | T_REF_INSTRUCTION { $$ = $1; }
  | T_REVNUM_INSTRUCTION { $$ = $1; }
  | T_SAVEDATE_INSTRUCTION { $$ = $1; }
  | T_SECTION_INSTRUCTION { $$ = $1; }
  | T_SECTIONPAGES_INSTRUCTION { $$ = $1; }
  | T_SEQ_INSTRUCTION { $$ = $1; }
  | T_SET_INSTRUCTION { $$ = $1; }
  | T_SKIPIF_INSTRUCTION { $$ = $1; }
  | T_STYLEREF_INSTRUCTION { $$ = $1; }
  | T_SUBJECT_INSTRUCTION { $$ = $1; }
  | T_SYMBOL_INSTRUCTION { $$ = $1; }
  | T_TA_INSTRUCTION { $$ = $1; }
  | T_TC_INSTRUCTION { $$ = $1; }
  | T_TEMPLATE_INSTRUCTION { $$ = $1; }
  | T_TIME_INSTRUCTION { $$ = $1; }
  | T_TITLE_INSTRUCTION { $$ = $1; }
  | T_TOA_INSTRUCTION { $$ = $1; }
  | T_TOC_INSTRUCTION { $$ = $1; }
  | T_USERADDRESS_INSTRUCTION { $$ = $1; }
  | T_USERINITIALS_INSTRUCTION { $$ = $1; }
  | T_USERNAME_INSTRUCTION { $$ = $1; }
  | T_XE_INSTRUCTION { $$ = $1; }
  | T_FUNC_ABS { $$ = $1; }
  | T_FUNC_AND { $$ = $1; }
  | T_FUNC_AVERAGE { $$ = $1; }
  | T_FUNC_COUNT { $$ = $1; }
  | T_FUNC_DEFINED { $$ = $1; }
  | T_FUNC_FALSE { $$ = $1; }
  | T_FUNC_INT { $$ = $1; }
  | T_FUNC_MAX { $$ = $1; }
  | T_FUNC_MIN { $$ = $1; }
  | T_FUNC_MOD { $$ = $1; }
  | T_FUNC_NOT { $$ = $1; }
  | T_FUNC_OR { $$ = $1; }
  | T_FUNC_PRODUCT { $$ = $1; }
  | T_FUNC_ROUND { $$ = $1; }
  | T_FUNC_SIGN { $$ = $1; }
  | T_FUNC_SUM { $$ = $1; }
  | T_FUNC_TRUE { $$ = $1; }
  | T_STRING_CONTENT { $$ = $1; }
  ;

country_region_incl:
    whitespace country_region_incl  { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | country_region_incl whitespace  { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote country_region_incl quote { $$ = new Quoted<OpenLanguage.WordprocessingML.FieldInstruction.Generated.CountryRegionInclusionNode>($1, (OpenLanguage.WordprocessingML.FieldInstruction.Generated.CountryRegionInclusionNode)$2, $3); }
  | T_HEX_INTEGER                   { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.CountryRegionInclusionNode((OpenLanguage.WordprocessingML.FieldInstruction.CountryRegionInclusion)(int.Parse($1, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture)), $1); }
  | T_BINARY_INTEGER                { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.CountryRegionInclusionNode((OpenLanguage.WordprocessingML.FieldInstruction.CountryRegionInclusion)(int.Parse($1, System.Globalization.NumberStyles.AllowBinarySpecifier | System.Globalization.NumberStyles.BinaryNumber, System.Globalization.CultureInfo.InvariantCulture)), $1); }
  | T_INTEGER                       { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.CountryRegionInclusionNode((OpenLanguage.WordprocessingML.FieldInstruction.CountryRegionInclusion)(int.Parse($1, System.Globalization.CultureInfo.InvariantCulture)), $1); }
  | identifier_or_string_raw        { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.CountryRegionInclusionNode(OpenLanguage.WordprocessingML.FieldInstruction.CountryRegionInclusionExtensions.Parse($1), $1); }
  ;

frame_target:
    whitespace frame_target { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | frame_target whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FRAME_TARGET_TOP      { $$ = new FrameTargetNode(OpenLanguage.WordprocessingML.FieldInstruction.FrameTarget.Top); }
  | T_FRAME_TARGET_SELF     { $$ = new FrameTargetNode(OpenLanguage.WordprocessingML.FieldInstruction.FrameTarget.Self); }
  | T_FRAME_TARGET_BLANK    { $$ = new FrameTargetNode(OpenLanguage.WordprocessingML.FieldInstruction.FrameTarget.Blank); }
  | T_FRAME_TARGET_PARENT   { $$ = new FrameTargetNode(OpenLanguage.WordprocessingML.FieldInstruction.FrameTarget.Parent); }
  ;

name_format:
    whitespace name_format      { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | name_format whitespace      { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_NAMEFORMAT_FIRSTNAME      { $$ = new NameFormatNode(OpenLanguage.WordprocessingML.FieldInstruction.NameFormat.FirstName); }
  | T_NAMEFORMAT_LASTNAME       { $$ = new NameFormatNode(OpenLanguage.WordprocessingML.FieldInstruction.NameFormat.LastName); }
  | T_NAMEFORMAT_FIRSTLASTNAME  { $$ = new NameFormatNode(OpenLanguage.WordprocessingML.FieldInstruction.NameFormat.FirstLastName); }
  | T_NAMEFORMAT_LASTFIRSTNAME  { $$ = new NameFormatNode(OpenLanguage.WordprocessingML.FieldInstruction.NameFormat.LastFirstName); }
  | T_NAMEFORMAT_TITLELASTNAME  { $$ = new NameFormatNode(OpenLanguage.WordprocessingML.FieldInstruction.NameFormat.TitleLastName); }
  | T_NAMEFORMAT_FULLFORMALNAME { $$ = new NameFormatNode(OpenLanguage.WordprocessingML.FieldInstruction.NameFormat.FullFormalName); }
  ;

optimization_flag:
    whitespace optimization_flag { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | optimization_flag whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_DBOPT_NONE                 { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.DatabaseOptimizationFlagNode(OpenLanguage.WordprocessingML.FieldInstruction.DatabaseOptimizationFlag.None); }
  | T_DBOPT_QUERYONCE            { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.DatabaseOptimizationFlagNode(OpenLanguage.WordprocessingML.FieldInstruction.DatabaseOptimizationFlag.QueryOnce); }
  | T_DBOPT_CACHERESULTS         { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.DatabaseOptimizationFlagNode(OpenLanguage.WordprocessingML.FieldInstruction.DatabaseOptimizationFlag.CacheResults); }
  | T_DBOPT_USECONNECTIONPOOLING { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.DatabaseOptimizationFlagNode(OpenLanguage.WordprocessingML.FieldInstruction.DatabaseOptimizationFlag.UseConnectionPooling); }
  | T_DBOPT_OPTIMIZEFORLARGEDATA { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.DatabaseOptimizationFlagNode(OpenLanguage.WordprocessingML.FieldInstruction.DatabaseOptimizationFlag.OptimizeForLargeData); }
  | T_DBOPT_OPTIMIZEFORSMALLDATA { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.DatabaseOptimizationFlagNode(OpenLanguage.WordprocessingML.FieldInstruction.DatabaseOptimizationFlag.OptimizeForSmallData); }
  | /* empty */                  { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.DatabaseOptimizationFlagNode(OpenLanguage.WordprocessingML.FieldInstruction.DatabaseOptimizationFlag.QueryOnce, true); }
  ;

namespace_decl:
    whitespace namespace_decl { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | namespace_decl whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote T_STRING_CONTENT quote {
        $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.NamespaceDeclarationNode(new OpenLanguage.WordprocessingML.FieldInstruction.NamespaceDeclaration($1.ToRawString() + $2 + $3.ToRawString()));
    }
  | quote quote {
        $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.NamespaceDeclarationNode(new OpenLanguage.WordprocessingML.FieldInstruction.NamespaceDeclaration($1.ToRawString() + $2.ToRawString()));
    }
  ;

xslt_path:
    whitespace xslt_path    { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | xslt_path whitespace    { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | switch_t string_literal { $$ = new FlaggedArgument<ExpressionNode>($1, $2); }
  ;

xpath:
    whitespace xpath                              { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | xpath whitespace                              { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | switch_x quote T_STRING_CONTENT quote { $$ = new FlaggedArgument<ExpressionNode>($1, new Quoted<XPathExpressionNode>($2, new XPathExpressionNode($3), $4)); }
  | switch_x identifier_or_string_raw             { $$ = new FlaggedArgument<ExpressionNode>($1, new XPathExpressionNode($2)); }
  ;

font_size:
    whitespace font_size         { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | font_size whitespace         { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote T_BINARY_INTEGER quote { $$ = new Quoted<OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode>( $1, new OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = int.Parse($2, NumberStyles.AllowBinarySpecifier | NumberStyles.BinaryNumber, System.Globalization.CultureInfo.InvariantCulture).ToString() }, $2), $3); }
  | quote T_HEX_INTEGER quote    { $$ = new Quoted<OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode>( $1, new OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = int.Parse($2, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture).ToString() }, $2), $3); }
  | quote T_INTEGER quote        { $$ = new Quoted<OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode>( $1, new OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = $2 }, $2), $3); }
  | quote T_FLOAT quote          { $$ = new Quoted<OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode>( $1, new OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = System.Convert.ToUInt64(double.Parse($2, System.Globalization.CultureInfo.InvariantCulture)).ToString() }, $2), $3); }
  | T_BINARY_INTEGER             { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = int.Parse($1, NumberStyles.AllowBinarySpecifier | NumberStyles.BinaryNumber, System.Globalization.CultureInfo.InvariantCulture).ToString() }, $1); }
  | T_HEX_INTEGER                { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = int.Parse($1, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture).ToString() }, $1); }
  | T_INTEGER                    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = $1 }, $1); }
  | T_FLOAT                      { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.Generated.FontSizeNode(new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = System.Convert.ToUInt64(double.Parse($1, System.Globalization.CultureInfo.InvariantCulture)).ToString() }, $1); }
  ;


float:
    whitespace float { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | float whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  // Inch unit
  | T_FLOAT          { $$ = new OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<float>($1, float.Parse($1, System.Globalization.CultureInfo.InvariantCulture), string.Empty); }
  ;
integer:
    whitespace integer { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | integer whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  // Inch unit
  | T_BINARY_INTEGER   { $$ = new OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<int>($1, Convert.ToInt32($1.Substring(2), 2), "B"); }
  | T_HEX_INTEGER      { $$ = new OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<int>($1, Convert.ToInt32($1.Substring(2), 16), "H"); }
  | T_INTEGER          { $$ = new OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<int>($1, int.Parse($1, System.Globalization.CultureInfo.InvariantCulture), "D"); }
  ;
float_list_contents:
    float_list_contents comma float
      {
          FloatListNode list = (FloatListNode)$1;
          list.Separators.Add($2);
          list.Values.Add($3);
          $$ = list;
      }
  | float
      {
          $$ = new FloatListNode(new List<NumericLiteralNode<float>> { $1 }, new List<CommaNode>());
      }
  ;
float_list:
    float_list whitespace             { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace float_list             { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | quote float_list_contents quote   { $$ = new Quoted<ExpressionNode>($1, $2, $3); }
  | float_list_contents               { $$ = $1; }
  ;

left_bracket:
    whitespace left_bracket { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | left_bracket whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LEFT_BRACKET          { $$ = new LeftBracketNode($1); }
  ;

right_bracket:
    right_bracket whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace right_bracket { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | T_RIGHT_BRACKET          { $$ = new RightBracketNode($1); }
  ;

comma:
    whitespace comma { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | comma whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_COMMA          { $$ = new CommaNode($1); }
  ;

semicolon:
    whitespace semicolon { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | semicolon whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SEMICOLON          { $$ = new SemicolonNode($1); }
  ;

left_paren:
    whitespace left_paren { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | left_paren whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LEFT_PAREN          { $$ = new LeftParenNode($1); }
  ;

right_paren:
    right_paren whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace right_paren { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | T_RIGHT_PAREN          { $$ = new RightParenNode($1); }
  ;

left_brace:
    whitespace left_brace { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | left_brace whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LEFT_BRACE          { $$ = new LeftBraceNode($1); }
  ;

right_brace:
    right_brace whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace right_brace { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | T_RIGHT_BRACE          { $$ = new RightBraceNode($1); }
  ;

addressblock_template:
    whitespace addressblock_template { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | addressblock_template whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote T_STRING_CONTENT quote {
        OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.MergeFieldTemplateScanner scanner = new OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.MergeFieldTemplateScanner();
        scanner.SetSource($2, 0);
        OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.Parser parser =
        new OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.Parser(scanner);
        if (!parser.Parse())
        {
          throw new System.InvalidOperationException("Failed to parse ADDRESSBLOCK \\f format template.");
        }
        if (parser.root is TemplateNode templateNode)
        {
          $$ = new Quoted<ExpressionNode>($1, templateNode, $3);
        } else {
          throw new System.InvalidOperationException("Invalid template AST root for ADDRESSBLOCK \\f.");
        }
    }
  | quote quote {
        $$ = new Quoted<ExpressionNode>($1, new TemplateNode(new List<ExpressionNode>()), $2);
    }
  | identifier_or_string_raw {
    OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.MergeFieldTemplateScanner scanner = new OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.MergeFieldTemplateScanner();
    scanner.SetSource($1, 0);
    OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.Parser parser =
    new OpenLanguage.WordprocessingML.MergeFieldTemplate.Generated.Parser(scanner);
    if (!parser.Parse())
    {
      throw new System.InvalidOperationException("Failed to parse ADDRESSBLOCK \\f format template.");
    }
    if (parser.root is TemplateNode templateNode)
    {
      $$ = templateNode;
    } else {
      throw new System.InvalidOperationException("Invalid template AST root for ADDRESSBLOCK \\f.");
    }
  }
  ;

braced_field_instruction:
    left_brace braced_field_instruction right_brace { $$ = new NestedFieldInstruction($1, $2, $3); }
  | left_brace field_instruction right_brace { $$ = new NestedFieldInstruction($1, $2, $3); }
  ;

quote:
    whitespace quote { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | quote whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_QUOTE          { $$ = new QuoteLiteralNode($1); }
  ;

colon:
    whitespace colon { $$ = $2;  $$.LeadingWhitespace.Insert(0, $1); }
  | colon whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_COLON          { $$ = new ColonNode($1); }
  ;


whitespace:
    T_WHITESPACE  { $$ = new WhitespaceNode($1); }
  | T_UNKNOWN     { $$ = new WhitespaceNode($1); }
  ;

char_arg:
    whitespace char_arg { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | char_arg whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_IDENTIFIER { $$ = new CharacterLiteralNode($1); }
  | T_BACKSLASH T_LEFT_BRACE { $$ = new CharacterLiteralNode($1 + $2); }
  | T_BACKSLASH T_RIGHT_BRACE { $$ = new CharacterLiteralNode($1 + $2); }
  | T_BACKSLASH T_LEFT_PAREN { $$ = new CharacterLiteralNode($1 + $2); }
  | T_BACKSLASH T_RIGHT_PAREN { $$ = new CharacterLiteralNode($1 + $2); }
  | T_BACKSLASH T_LEFT_BRACKET { $$ = new CharacterLiteralNode($1 + $2); }
  | T_BACKSLASH T_RIGHT_BRACKET { $$ = new CharacterLiteralNode($1 + $2); }
  | T_BACKSLASH T_BACKSLASH { $$ = new CharacterLiteralNode($1 + $2); }
  | T_BACKSLASH T_QUOTE { $$ = new CharacterLiteralNode($1 + $2); }
  ;

%%

public Node root;
internal Parser(OpenLanguage.WordprocessingML.FieldInstruction.Generated.FieldInstructionScanner scanner) : base(scanner)
{
  scanner.Parser = this;
}

