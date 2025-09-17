%namespace OpenLanguage.SpreadsheetML.Formula.Generated
%parsertype Parser
%tokentype Tokens
%visibility public

%using OpenLanguage.SpreadsheetML.Formula.Ast;
%using System.Linq;

%union
{
    public double doubleVal;
    public int integerVal;
    public long longVal;
    public ulong ulongVal;
    public bool boolVal;
    public string stringVal;
    public Node nodeVal;
    public ExpressionNode expressionVal;
    public List<ExpressionNode> expressionListVal;
    public List<Node> nodeListVal;
    public List<List<ExpressionNode>> rowsVal;


    public NumericLiteralNode<double> floatingPointNodeVal;
    public NumericLiteralNode<long>   integerNodeVal;

    public A1RelativeColumnNode A1RelativeColumnVal;
    public A1RelativeRowNode A1RelativeRowVal;

    public R1C1RelativeColumnNode R1C1RelativeColumnVal;
    public R1C1RelativeRowNode R1C1RelativeRowVal;

    public A1AbsoluteColumnNode A1AbsoluteColumnVal;
    public A1AbsoluteRowNode A1AbsoluteRowVal;

    public R1C1AbsoluteColumnNode R1C1AbsoluteColumnVal;
    public R1C1AbsoluteRowNode R1C1AbsoluteRowVal;

    public A1ColumnNode A1ColumnVal;
    public A1RowNode A1RowVal;
    public R1C1ColumnNode R1C1ColumnVal;
    public R1C1RowNode R1C1RowVal;

    public A1ColumnNode A1ColumnOnlyVal;
    public A1RowNode A1RowOnlyVal;
    public A1CellNode A1CellVal;
    public R1C1CellNode R1C1CellVal;

    public StructureTotalsReferenceNode structureTotalsVal;
    public StructureDataReferenceNode structureDataVal;
    public StructureHeadersReferenceNode structureHeadersVal;
    public StructureThisRowReferenceNode structureThisRowVal;
    public StructureAllReferenceNode structureAllVal;

    public NameNode nameVal;

    // -- Function prefixes -- //
    public XlpmFunctionPrefixNode xlpmVal;
    public XlopPrefixNode xlopVal;
    public XlwsFunctionPrefixNode xlwsVal;
    public XlfnFunctionPrefixNode xlfnVal;

    public WorkbookReferenceNode workbookIndexVal;
    public StructureThisRowColumnReferenceNode structureThisRowColumnVal;
    public StructureColumnRange structureColumnRangeVal;


    public StandardFunctionNode standardFunctionVal;
    public FutureFunctionNode futureFunctionVal;
    public MacroFunctionNode macroFunctionVal;
    public CommandFunctionNode commandFunctionVal;
    public WorksheetFunctionNode worksheetFunctionVal;

    public PyFunctionNode pyWorksheetFunctionVal;

    public BangNode bangVal;
    public BangReferenceNode bangReferenceVal;

}

%token R1C1_COLUMN_PREFIX
%token R1C1_ROW_PREFIX

#include "function/command/tokens.inc"
#include "function/future/tokens.inc"
#include "function/macro/tokens.inc"
#include "function/standard/tokens.inc"
#include "function/worksheet/tokens.inc"



%token<stringVal> T_XLWS_ T_XLFN_ T_XLPM_ T_XLOP_
%token<stringVal> T_FLOATING_POINT_CONSTANT T_DOLLAR T_INTEGER_CONSTANT
%token<longVal>  T_R1C1_ROW T_R1C1_COLUMN
%token<ulongVal>  T_A1_ROW T_A1_COLUMN
%token<stringVal> T_UNKNOWN_CHAR T_BANG T_AT_SYMBOL T_INTERSECTION T_NEWLINE T_SR_THIS_ROW
%token<stringVal> T_IDENTIFIER  T_STRING_CONSTANT T_QUOTED_IDENTIFIER T_SHEET_NAME_SPECIAL
%token<stringVal> T_STRUCTURED_REFERENCE
%token<stringVal> T_DIV0_ERROR T_NA_ERROR T_NAME_ERROR T_NULL_ERROR T_NUM_ERROR T_VALUE_ERROR T_GETTING_DATA_ERROR T_REF_ERROR T_SPILL_ERROR T_CALC_ERROR T_BLOCKED_ERROR T_BUSY_ERROR T_CIRCULAR_ERROR T_CONNECT_ERROR T_EXTERNAL_ERROR T_FIELD_ERROR T_PYTHON_ERROR T_UNKNOWN_ERROR
%token<stringVal> T_LBRACK T_RBRACK  T_QUESTION_MARK
%token<stringVal> T_PLUS T_MINUS T_ASTERISK T_SLASH T_AMPERSAND T_CARET T_PERCENT T_HASH
%token<stringVal> T_EQ T_NE T_LT T_LE T_GT T_GE
%token<stringVal> T_LPAREN T_RPAREN T_LBRACE T_RBRACE T_COMMA T_COLON T_SEMICOLON
%token<stringVal> T_TRUE T_FALSE T_EMPTY_BRACKETS
%token T_SR_ALL T_SR_DATA T_SR_HEADERS T_SR_TOTALS

%type <nodeVal>           formula whitespace
%type <expressionVal>     expression primary constant error_constant ref_constant solo_function
%type <expressionVal>     function_call_head builtin_function_call_head function_call argument
%type <expressionListVal> argument_list
%type <expressionVal>     cell_reference structured_reference structured_reference_index structured_reference_index_primitive
// %type <expressionVal>     pivot_item pivot_items pivot_item_index
%type <structureTotalsVal> structured_totals
%type <structureDataVal> structured_data
%type <structureHeadersVal> structured_headers
%type <expressionVal> structured_this_row
%type <structureAllVal> structured_all
%type <expressionVal> structured_reference
%type <structureColumnRangeVal>    column_range
%type <workbookIndexVal>  workbook_reference

%type <A1RelativeColumnVal>       A1_column_relative
%type <A1RelativeRowVal>          A1_row_relative

%type <R1C1RelativeColumnVal>     R1C1_column_relative
%type <R1C1RelativeRowVal>        R1C1_row_relative

%type <A1AbsoluteColumnVal>       A1_column_absolute
%type <A1AbsoluteRowVal>          A1_row_absolute

%type <R1C1AbsoluteColumnVal>     R1C1_column_absolute
%type <R1C1AbsoluteRowVal>        R1C1_row_absolute

%type <A1ColumnVal>       A1_column
%type <A1RowVal>          A1_row

%type <R1C1ColumnVal>     R1C1_column
%type <R1C1RowVal>        R1C1_row

%type <A1CellVal>         A1_cell
%type <R1C1CellVal>       R1C1_cell

%type <expressionVal>     array cell_or_ref_constant cell_range cell
%type <expressionVal>     name
%type <rowsVal>           list_rows
%type <expressionListVal> list_row
%type <expressionVal>     external_cell_reference sheet_range_bang_reference sheet_bang_reference
%type <expressionVal>     cell_or_ref_constant sheet_reference sheet_range
%type <expressionVal>     external_cell_reference bang_reference

%type <nodeListVal>       opt_whitespace
%type <bangVal>           bang
%type <bangReferenceVal>  bang_reference

%type <xlpmVal>           xlpm
%type <xlwsVal>           xlws opt_xlws
%type <xlopVal>           xlop
%type <xlfnVal>           xlfn opt_xlfn

%type <floatingPointNodeVal> floating_point_constant
%type <integerNodeVal>      integer_constant

#include "function/command/types.inc"
#include "function/future/types.inc"
#include "function/macro/types.inc"
#include "function/standard/types.inc"
#include "function/worksheet/types.inc"

%token UMINUS
%right T_COMMA
%left T_INTERSECTION T_NEWLINE
%left T_COLON
%left T_EQ T_NE T_LT T_LE T_GT T_GE
%left T_AMPERSAND
%left T_PLUS T_MINUS
%left T_ASTERISK T_SLASH
%right T_CARET
%left UMINUS
%left T_PERCENT
%right T_HASH

%start formula

%%

formula:
     expression    { $$ = $1; root = $$; }
  |  solo_function { $$ = $1; root = $$; }
  |  /* empty */   { $$ = null; root = null; }
  ;

expression:
    primary                                  { $$ = $1; }
  | whitespace expression                    { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | expression whitespace                    { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LPAREN expression T_RPAREN             { $$ = new ParenthesizedExpressionNode($2); }
  | expression T_PLUS expression             { $$ = new AddNode($1, new PlusLiteralNode($2), $3); }
  | expression T_MINUS expression            { $$ = new SubtractNode($1, new MinusLiteralNode($2), $3); }
  | expression T_ASTERISK expression         { $$ = new MultiplyNode($1, new AsteriskLiteralNode($2), $3); }
  | expression T_SLASH expression            { $$ = new DivideNode($1, new SlashLiteralNode($2), $3); }
  | expression T_CARET expression            { $$ = new PowerNode($1, new CaretLiteralNode($2), $3); }
  | expression T_AMPERSAND expression        { $$ = new ConcatenateNode($1, new AmpersandLiteralNode($2), $3); }
  | expression T_NE expression               { $$ = new NotEqualNode($1, new NotEqualLiteralNode($2), $3); }
  | expression T_LE expression               { $$ = new LessThanOrEqualNode($1, new LessThanOrEqualLiteralNode($2), $3); }
  | expression T_LT expression               { $$ = new LessThanNode($1, new LessThanLiteralNode($2), $3); }
  | expression T_GE expression               { $$ = new GreaterThanOrEqualNode($1, new GreaterThanOrEqualLiteralNode($2), $3); }
  | expression T_GT expression               { $$ = new GreaterThanNode($1, new GreaterThanLiteralNode($2), $3); }
  | expression T_EQ expression               { $$ = new EqualNode($1, new EqualLiteralNode($2), $3); }
  | expression T_COLON expression            { $$ = new RangeNode($1, new ColonNode($2), $3); }
  | expression T_COMMA expression            { $$ = new UnionNode($1, new CommaNode($2), $3); }
  | expression T_PERCENT %prec T_PERCENT     { $$ = new PercentNode(new PercentLiteralNode($2), $1); }
  | expression T_HASH                        { $$ = new DynamicNode(new HashLiteralNode($2), $1); }
  | T_PLUS expression %prec UMINUS           { $$ = new UnaryPlusNode(new PlusLiteralNode($1), $2); }
  | T_MINUS expression %prec UMINUS          { $$ = new UnaryMinusNode(new MinusLiteralNode($1), $2); }
  | expression T_INTERSECTION expression     { $$ = new IntersectionNode($1, new IntersectionLiteralNode($2), $3); }
  | T_AT_SYMBOL expression %prec UMINUS      { $$ = new ImplicitIntersectionNode(new AtSymbolLiteralNode($1), $2); }
  | T_EQ expression                          { $$ = new EqualPrefixedNode(new EqualLiteralNode($1), $2); }
  ;

primary:
    constant                    { $$ = $1; }
  | ref_constant                { $$ = $1; }
  | structured_reference         { $$ = $1; }
  | cell_reference              { $$ = $1; }
  | A1_row                      { $$ = $1; }
  | A1_column                   { $$ = $1; }
  | function_call               { $$ = $1; }
  | builtin_function_call_head  { $$ = $1; }
  | name                        { $$ = $1; }
  // | pivot_items         { $$ = $1; }
  ;

#include "function/command/nodes.inc"
#include "function/future/nodes.inc"
#include "function/macro/nodes.inc"
#include "function/standard/nodes.inc"
#include "function/worksheet/nodes.inc"

xlpm: T_XLPM_ { $$ = new XlpmFunctionPrefixNode($1); };

xlws: T_XLWS_ { $$ = new XlwsFunctionPrefixNode($1); };
xlop: T_XLOP_ { $$ = new XlopPrefixNode($1); };
xlfn: T_XLFN_ { $$ = new XlfnFunctionPrefixNode($1); };

opt_xlws: xlws { $$ = $1; } | /* empty */ { $$ = null; };
opt_xlfn: xlfn { $$ = $1; } | /* empty */ { $$ = null; };

builtin_function_call_head:
    whitespace builtin_function_call_head        { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | builtin_function_call_head whitespace        { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | standard_function_name                       { $$ = $1; }
  | future_function_name                         { $$ = $1; }
  | macro_function_name                          { $$ = $1; }
  | command_function_name                        { $$ = $1; }
  | worksheet_function_name                      { $$ = $1; }
  ;
function_call_head:
    whitespace function_call_head        { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | function_call_head whitespace        { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | builtin_function_call_head           { $$ = $1; }
  | name                                 { $$ =  new UserDefinedFunctionNode($1); }
  ;

function_call: function_call_head T_LPAREN argument_list T_RPAREN { $$ = new FunctionCallNode($1, $3); };

solo_function: opt_whitespace py_worksheet_function_name opt_whitespace T_LPAREN opt_whitespace integer_constant opt_whitespace T_COMMA opt_whitespace floating_point_constant opt_whitespace argument_list opt_whitespace T_RPAREN opt_whitespace
      {
          PyFunctionNode pyNode = $2;
          NumericLiteralNode<long> arg1 = $6;
          NumericLiteralNode<double> arg2 = $10;

          List<ExpressionNode> result = $12;
          result.Insert(0, arg2);
          result.Insert(0, arg1);

          FunctionCallNode funcCall = new FunctionCallNode(pyNode,  result, $1, $15);
          $$ = funcCall;
      }
  ;

argument_list:
    argument_list T_COMMA argument { $$ = $1; $$.Add($3); }
  | expression                     { $$ = new List<ExpressionNode>() { $1 }; }
  | /* empty */                    { $$ = new List<ExpressionNode>(); }
  ;

argument:
    xlpm argument { $$ = new ConcatenatedNodes(new List<ExpressionNode>() { $1, $2 }); }
  | xlop argument { $$ = new ConcatenatedNodes(new List<ExpressionNode>() { $1, $2 }); }
  | expression    { $$ = $1; }
  | /* empty */   { $$ = new EmptyArgumentNode(); }
  ;


integer_constant:
    T_INTEGER_CONSTANT { $$ = new NumericLiteralNode<long>($1, "D"); }
  ;

floating_point_constant:
    T_FLOATING_POINT_CONSTANT { $$ = new NumericLiteralNode<double>($1, "G9"); }
  ;

constant:
    floating_point_constant    { $$ = $1; }
  | integer_constant           { $$ = $1; }
  | T_STRING_CONSTANT          { $$ = new StringNode($1); }
  | T_TRUE                     { $$ = new LogicalNode(true, $1); }
  | T_FALSE                    { $$ = new LogicalNode(false, $1); }
  | error_constant             { $$ = $1; }
  | array                      { $$ = $1; }
  ;

error_constant:
    T_DIV0_ERROR         { $$ = new DivZeroErrorNode($1); }
  | T_NA_ERROR           { $$ = new NAErrorNode($1); }
  | T_NAME_ERROR         { $$ = new NameErrorNode($1); }
  | T_NULL_ERROR         { $$ = new NullErrorNode($1); }
  | T_NUM_ERROR          { $$ = new NumErrorNode($1); }
  | T_VALUE_ERROR        { $$ = new ValueErrorNode($1); }
  | T_GETTING_DATA_ERROR { $$ = new GettingDataErrorNode($1); }
  | T_SPILL_ERROR        { $$ = new SpillErrorNode($1); }
  | T_CALC_ERROR         { $$ = new CalcErrorNode($1); }
  | T_BLOCKED_ERROR      { $$ = new BlockedErrorNode($1); }
  | T_BUSY_ERROR         { $$ = new BusyErrorNode($1); }
  | T_CIRCULAR_ERROR     { $$ = new CircularErrorNode($1); }
  | T_CONNECT_ERROR      { $$ = new ConnectErrorNode($1); }
  | T_EXTERNAL_ERROR     { $$ = new ExternalErrorNode($1); }
  | T_FIELD_ERROR        { $$ = new FieldErrorNode($1); }
  | T_PYTHON_ERROR       { $$ = new PythonErrorNode($1); }
  | T_UNKNOWN_ERROR      { $$ = new UnknownErrorNode($1); }
  ;

ref_constant: opt_whitespace T_REF_ERROR opt_whitespace { $$ = new ErrorNode($2, $1, $3); };

array: T_LBRACE opt_whitespace list_rows opt_whitespace T_RBRACE { $$ = new ArrayNode($3, $2, $4); };

list_rows: list_row { $$ = new List<List<ExpressionNode>> { $1 }; }
  | list_rows opt_whitespace T_SEMICOLON opt_whitespace list_row
      {
          if ($1.LastOrDefault()?.LastOrDefault() != null)
              $1.Last().Last().TrailingWhitespace.AddRange($2);
          if ($5.FirstOrDefault() != null)
              $5.First().LeadingWhitespace.AddRange($4);
          $1.Add($5);
          $$ = $1;
      }
  ;

list_row: expression { $$ = new List<ExpressionNode> { $1 }; }
  | list_row opt_whitespace T_COMMA opt_whitespace expression
      {
          if ($1.Count == 0) {
            $1.Add(new EmptyArgumentNode($2));
          } else {
            $1.Last().TrailingWhitespace.AddRange($2);
          }
          $5.LeadingWhitespace.AddRange($4);
          $1.Add($5);
          $$ = $1;
      }
  ;

cell_reference:
    external_cell_reference { $$ = $1; }
  | cell_range { $$ = $1; }
  | cell { $$ = $1; };
name:
    whitespace name                           { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | name whitespace                           { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_AT_SYMBOL opt_whitespace T_IDENTIFIER   { $$ = new ImplicitIntersectionNode(new AtSymbolLiteralNode($3), new NamedRangeNode($1, $2)); }
  | T_IDENTIFIER                              { $$ = new NamedRangeNode($1); }
  | T_SHEET_NAME_SPECIAL                      { $$ = new NamedRangeNode($1); }
  ;

A1_column_absolute: T_DOLLAR T_A1_COLUMN { $$ = new A1AbsoluteColumnNode($2); };
A1_column_relative: T_A1_COLUMN { $$ = new A1RelativeColumnNode($1); };

A1_column: A1_column_absolute { $$ = $1; } | A1_column_relative { $$ = $1; };

A1_row_absolute: T_DOLLAR T_A1_ROW { $$ = new A1AbsoluteRowNode($2); };
A1_row_relative: T_A1_ROW { $$ = new A1RelativeRowNode($1); };

A1_row: A1_row_absolute { $$ = $1; } | A1_row_relative { $$ = $1; };

R1C1_column_relative: R1C1_COLUMN_PREFIX T_LBRACK T_R1C1_COLUMN T_RBRACK { $$ = new R1C1RelativeColumnNode($3); };
R1C1_column_absolute: R1C1_COLUMN_PREFIX T_R1C1_COLUMN { $$ = new R1C1AbsoluteColumnNode($2); };
R1C1_column: R1C1_column_relative { $$ = $1; }  | R1C1_column_absolute { $$ = $1; } | R1C1_COLUMN_PREFIX { $$ = new R1C1CurrentColumnNode(0); };

R1C1_row_relative: R1C1_ROW_PREFIX T_LBRACK T_R1C1_ROW T_RBRACK { $$ = new R1C1RelativeRowNode($3); };
R1C1_row_absolute: R1C1_ROW_PREFIX T_R1C1_ROW { $$ = new R1C1AbsoluteRowNode($2); };
R1C1_row: R1C1_row_relative { $$ = $1; } | R1C1_row_absolute { $$ = $1; } | R1C1_ROW_PREFIX { $$ = new R1C1CurrentRowNode(0); };

R1C1_cell: R1C1_row R1C1_column { $$ = new R1C1CellNode($1, $2); };
A1_cell: A1_column A1_row { $$ = new A1CellNode($1, $2); };

cell:
    R1C1_cell { $$ = $1; }
  | A1_cell   { $$ = $1; }
  ;
cell_range:
    A1_cell   T_COLON  A1_cell        { $$ = new CellRangeNode<A1CellNode, A1CellNode, UInt64, A1RowNode, UInt64, A1ColumnNode, UInt64, A1RowNode, UInt64, A1ColumnNode>($1, new ColonNode($2), $3); }
  | A1_cell   T_COLON  R1C1_cell      { $$ = new CellRangeNode<A1CellNode, R1C1CellNode, UInt64, A1RowNode, UInt64, A1ColumnNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode>($1, new ColonNode($2), $3); }
  | R1C1_cell T_COLON  A1_cell        { $$ = new CellRangeNode<R1C1CellNode, A1CellNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode, UInt64, A1RowNode, UInt64, A1ColumnNode>($1, new ColonNode($2), $3); }
  | R1C1_cell T_COLON  R1C1_cell      { $$ = new CellRangeNode<R1C1CellNode, R1C1CellNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode>($1, new ColonNode($2), $3); }
  | A1_column T_COLON  A1_column      { $$ = new RangeNode($1, new ColonNode($2), $3); }
  | A1_row    T_COLON  A1_row         { $$ = new RangeNode($1, new ColonNode($2), $3); }
  ;



external_cell_reference:
    sheet_bang_reference        { $$ = $1; }
  | sheet_range_bang_reference  { $$ = $1; }
  | bang_reference              { $$ = $1; };

bang: opt_whitespace T_BANG opt_whitespace { $$ = new BangNode($2, $1, $3); };
bang_reference: opt_whitespace bang cell_or_ref_constant opt_whitespace { $$ = new BangReferenceNode($2, $3, $1, $4); };


sheet_range_bang_reference:
  sheet_range  bang_reference { $$ = new SheetReferenceNode($1, $2); }
  ;
sheet_bang_reference:
  sheet_reference bang_reference { $$ = new SheetReferenceNode($1, $2); }
  ;
sheet_reference:
    T_SINGLE_QUOTE sheet_reference T_SINGLE_QUOTE { $$ = new QuotedSheetNode($2, $1, $3); }
  | whitespace sheet_reference                    { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | sheet_reference whitespace                    { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | workbook_reference name                       { $$ = new SheetNode($1, $2); }
  | name                                          { $$ = new SheetNode(null, $1); }
  | workbook_reference                            { $$ = new SheetNode($1); }
  ;
sheet_range:
  sheet_reference T_COLON sheet_reference { $$ = new SheetRangeNode($1, new ColonNode($2), $3); }
  ;

cell_or_ref_constant:
    cell { $$ = $1; }
  | cell_range { $$ = $1; }
  | name { $$ = $1; }
  | ref_constant { $$ = $1; }
  ;
// pivot_items:  pivot_items  T_INTERSECTION opt_whitespace pivot_item { List<Node> ws = new List<Node>() { new WhitespaceNode($2) }; ws.AddRange($3); $$ = new IntersectionNode($1, $4, ws); }
// | pivot_item { $$ = $1; };

// pivot_item
//     : name T_LBRACK pivot_item_index T_RBRACK { $$ = new IndexedPivotField($1, $3); }
//     | name { $$ = new PivotField($1); }
//     ;

// pivot_item_index
//     : name { $$ = $1; }
//     | opt_whitespace T_PLUS opt_whitespace T_INTEGER_CONSTANT opt_whitespace { $$ = new PivotFieldOffset(new UnaryPlusNode(new NumericLiteralNode<long>($4, "D"), $3, $1, $5)); }
//     | opt_whitespace T_MINUS opt_whitespace T_INTEGER_CONSTANT opt_whitespace { $$ = new PivotFieldOffset(new UnaryMinusNode(new NumericLiteralNode<long>($4, "D"), $3, $1, $5)); }
//
//     | opt_whitespace T_INTEGER_CONSTANT opt_whitespace { $$ = new PivotFieldOffset(new NumericLiteralNode<long>($2, "D", $1, $3)); }
//     ;




structured_reference:
    whitespace structured_reference                    { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | structured_reference whitespace                    { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | structured_reference T_COMMA structured_reference  { $$ = new StructuredReferenceUnion($1, new CommaNode($2), $3); }
  | structured_reference structured_reference          { $$ = new StructuredReferenceIntersection($1, $2); }
  | sheet_reference structured_reference_index         { $$ = new StructuredReferenceNode($1, $2); }
  ;

structured_reference_index:
    whitespace structured_reference_index                          { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | structured_reference_index whitespace                          { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_LBRACK structured_reference_index T_RBRACK                   { $$ = new StructureAllRowsReferenceNode($2); }
  | structured_reference_index T_COMMA structured_reference_index  { $$ = new StructuredReferenceIndicesUnion($1, new CommaNode($2), $3); }
  | column_range                                                   { $$ = $1; }
  | name                                                           { $$ = $1; }
  | structured_reference_index_primitive                           { $$ = $1; }
  ;





structured_data: T_SR_DATA       { $$ = new StructureDataReferenceNode(); };
structured_headers: T_SR_HEADERS { $$ = new StructureHeadersReferenceNode(); };
structured_totals: T_SR_TOTALS   { $$ = new StructureTotalsReferenceNode(); };

structured_this_row:
    T_AT_SYMBOL structured_reference_index { $$ = new StructureThisRowByPrefixReferenceNode(new AtSymbolLiteralNode($1), $2); }
  | T_SR_THIS_ROW                         { $$ = new StructureThisRowReferenceNode($1); }
  | T_AT_SYMBOL                           { $$ = new StructureThisRowReferenceNode($1); }
  ;

structured_all: T_SR_ALL { $$ = new StructureAllReferenceNode(); };
structured_reference_index_primitive:
    structured_all      { $$ = $1; }
  | structured_data     { $$ = $1; }
  | structured_headers  { $$ = $1; }
  | structured_totals   { $$ = $1; }
  | structured_this_row { $$ = $1; }
  ;

column_range: structured_reference_index T_COLON structured_reference_index { $$ = new StructureColumnRange($1, $3); };

workbook_reference:
    T_LBRACK opt_whitespace integer_constant opt_whitespace T_RBRACK
      { $$ = new WorkbookReferenceNode($3, new LeftBracketNode($1, null, $2), new RightBracketNode($5, $4, null)); }
  | T_LBRACK opt_whitespace name opt_whitespace T_RBRACK
      { $$ = new WorkbookReferenceNode($3, new LeftBracketNode($1, null, $2), new RightBracketNode($5, $4, null)); }
  | T_LBRACK opt_whitespace T_RBRACK
      { $$ = new WorkbookReferenceNode(null, new LeftBracketNode($1, null, $2), new RightBracketNode($3)); }
  ;


whitespace:
    T_NEWLINE      { $$ = new WhitespaceNode($1); }
  | T_INTERSECTION { $$ = new WhitespaceNode($1); }
  ;

opt_whitespace:
    opt_whitespace whitespace { $1.Add($2); $$ = $1; }
  | whitespace                { $$ = new List<Node>() { $1 }; }
  | /* empty */               { $$ = new List<Node>(); }
  ;



%%

public Node root;
internal Parser(OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner scanner) : base(scanner)
{
  scanner.Parser = this;
}
