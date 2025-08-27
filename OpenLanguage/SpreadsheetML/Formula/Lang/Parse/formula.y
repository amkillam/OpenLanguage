%namespace OpenLanguage.SpreadsheetML.Formula.Generated
%parsertype Parser
%tokentype Tokens
%visibility public

%using OpenLanguage.SpreadsheetML.Formula.Ast;
%using System.Linq;

%{
    public class ArgumentParseResult
    {
        public List<ExpressionNode> Arguments { get; set; } = new List<ExpressionNode>();
    }
%}

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
    public StructureColumn structureColumnVal;
    public List<ExpressionNode> expressionListVal;
    public List<Node> nodeListVal;
    public Parser.ArgumentParseResult argParseResultVal;
    public List<List<ExpressionNode>> rowsVal;

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

    public StructureTotalsNode structureTotalsVal;
    public StructureDataNode structureDataVal;
    public StructureHeadersNode structureHeadersVal;
    public StructureThisRowNode structureThisRowVal;
    public StructureAllNode structureAllVal;

    public NameNode nameVal;
    public StructureKeywordNode structureKeywordVal;
    public WorkbookIndexNode workbookIndexVal;
    public StructureThisRowColumnNode structureThisRowColumnVal;
    public StructureColumnRange structureColumnRangeVal;

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



%token<stringVal> T_XLFN_XLWS_ T_XLFN_ T_XLPM_ T_XLOP_
%token<stringVal> T_NUMERICAL_CONSTANT T_DOLLAR
%token<longVal> T_LONG T_R1C1_ROW T_R1C1_COLUMN
%token<ulongVal>  T_A1_ROW T_A1_COLUMN
%token<stringVal> T_UNKNOWN_CHAR T_BANG T_AT_SYMBOL T_INTERSECTION T_NEWLINE T_SR_THIS_ROW
%token<stringVal> T_IDENTIFIER  T_STRING_CONSTANT T_QUOTED_IDENTIFIER T_SHEET_NAME_SPECIAL
%token<stringVal> T_STRUCTURED_REFERENCE
%token<stringVal> T_DIV0_ERROR T_NA_ERROR T_NAME_ERROR T_NULL_ERROR T_NUM_ERROR T_VALUE_ERROR T_GETTING_DATA_ERROR T_REF_ERROR T_SPILL_ERROR T_CALC_ERROR T_BLOCKED_ERROR T_BUSY_ERROR T_CIRCULAR_ERROR T_CONNECT_ERROR T_EXTERNAL_ERROR T_FIELD_ERROR T_PYTHON_ERROR T_UNKNOWN_ERROR
%token<stringVal> T_LBRACK T_RBRACK  T_QUESTIONMARK
%token<stringVal> T_PLUS T_MINUS T_ASTERISK T_SLASH T_AMPERSAND T_CARET T_PERCENT T_HASH
%token<stringVal> T_EQ T_NE T_LT T_LE T_GT T_GE
%token<stringVal> T_LPAREN T_RPAREN T_LBRACE T_RBRACE T_COMMA T_COLON T_SEMICOLON
%token T_TRUE T_FALSE T_EMPTY_BRACKETS
%token T_SR_ALL T_SR_DATA T_SR_HEADERS T_SR_TOTALS

%type <nodeVal>           formula whitespace
%type <expressionVal>     expression primary constant error_constant ref_constant function_call solo_function
%type <expressionVal>     cell_reference name_reference structure_reference inner_reference_item inner_reference
// %type <expressionVal>     pivot_item pivot_items pivot_item_index
%type <structureColumnVal> structure_column
%type <structureTotalsVal> structure_totals
%type <structureDataVal> structure_data
%type <structureHeadersVal> structure_headers
%type <expressionVal> structure_this_row
%type <structureAllVal> structure_all
%type <expressionVal> keyword
%type <structureColumnRangeVal>    column_range
%type <workbookIndexVal>  workbook_index
%type <expressionVal> workbook_name
%type <stringVal> workbook_name_text
%type <stringVal> workbook_name_piece

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

%type <expressionVal>     array cell_or_ref_constant cell_range cell intra_table_reference
%type <expressionVal>           name opt_name
%type <rowsVal>           list_rows
%type <expressionListVal> list_row inner_reference opt_inner_reference intra_table_reference_list
%type <expressionVal>     external_cell_reference sheet_range_reference single_sheet_reference
%type <expressionVal>     cell_or_ref_constant single_sheet sheet_range
%type <expressionVal>     external_cell_reference bang_reference
%type <expressionVal>     function_call_head  argument
%type <argParseResultVal> argument_list

%type <nodeListVal>       opt_whitespace
%type <expressionVal>     opt_expression opt_solo_function
%type <expressionVal>     keyword_list

%type <bangVal>           bang
%type <bangReferenceVal>  bang_reference

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
       opt_expression    { $$ = $1; root = $$; }
    |  opt_solo_function { $$ = $1; root = $$; }
    ;

opt_expression:
      expression   { $$ = $1; }
    | /* empty */  { $$ = null; }
    ;

opt_solo_function:
      solo_function { $$ = $1; }
    | /* empty */   { $$ = null; }
    ;

expression:
      whitespace expression                    { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
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
    | primary                                  { $$ = $1; }
    ;

primary:
      constant            { $$ = $1; }
    | ref_constant        { $$ = $1; }
    | structure_reference { $$ = $1; }
    | cell_reference      { $$ = $1; }
    | A1_row              { $$ = $1; }
    | A1_column           { $$ = $1; }
    | function_call       { $$ = $1; }
    | function_call_head  { $$ = $1; }
    | name_reference      { $$ = $1; }
    // | pivot_items         { $$ = $1; }
    ;

function_call_head:
      opt_whitespace standard_function_name opt_whitespace
        { $$ = new BuiltInStandardFunctionNode($2, $1, $3); }
    | opt_whitespace future_function_name opt_whitespace
        { $$ = new BuiltInFutureFunctionNode($2, $1, $3); }
    | opt_whitespace macro_function_name opt_whitespace
        { $$ = new BuiltInMacroFunctionNode($2, $1, $3); }
    | opt_whitespace command_function_name opt_whitespace T_QUESTIONMARK opt_whitespace
        { $$ = new BuiltInCommandFunctionNode($2, new QuestionMarkNode($4, $3, $5), $1, null); }
    | opt_whitespace command_function_name opt_whitespace
        { $$ = new BuiltInCommandFunctionNode($2, null, $1, $3); }
    | opt_whitespace T_XLFN_XLWS_  worksheet_function_name opt_whitespace
        { $$ = new BuiltInWorksheetFunctionNode($2, new BuiltInFunctionNode($3), $1, $4); }
    ;

function_call: function_call_head T_LPAREN argument_list T_RPAREN { $$ = new FunctionCallNode($1, $3.Arguments); };

solo_function: opt_whitespace T_XLFN_XLWS_ T_FUNC_PY opt_whitespace T_LPAREN opt_whitespace T_LONG opt_whitespace T_COMMA opt_whitespace T_NUMERICAL_CONSTANT opt_whitespace argument_list opt_whitespace T_RPAREN opt_whitespace
        {
            BuiltInWorksheetFunctionNode pyNode = new PyWorksheetFunctionNode($1, $4);
            NumericLiteralNode<long> arg1 = new NumericLiteralNode<long>($7, "D", $6, $8);
            NumericLiteralNode<double> arg2 = new NumericLiteralNode<double>($11, "D", $10, $12);

            ArgumentParseResult result = $13;
            result.Arguments.Insert(0, arg2);
            result.Arguments.Insert(0, arg1);

            FunctionCallNode funcCall = new FunctionCallNode(pyNode,  result.Arguments, $1, $16);
            $$ = funcCall;
        }
    ;

argument_list:
    argument_list opt_whitespace T_COMMA opt_whitespace argument
        {
            $$ = $1;
            if ($5 != null) $$.Arguments.Add($5);
        }
    |     expression { $$ = new ArgumentParseResult(); if ($1 != null) $$.Arguments.Add($1); }
    | /* empty */ { $$ = new ArgumentParseResult(); }
    ;

argument: expression
    | /* empty */ { $$ = new EmptyArgumentNode(); }
    ;




constant:
        T_NUMERICAL_CONSTANT { $$ = new NumericLiteralNode<double>($1, "D"); }
      | T_LONG               { $$ = new NumericLiteralNode<long>($1, "D"); }
      | T_STRING_CONSTANT    { $$ = new StringNode($1); }
      | T_TRUE               { $$ = new LogicalNode(true); }
      | T_FALSE              { $$ = new LogicalNode(false); }
      | error_constant       { $$ = $1; }
      | array       { $$ = $1; }
      ;

error_constant: T_DIV0_ERROR { $$ = new ErrorNode($1); } | T_NA_ERROR { $$ = new ErrorNode($1); } | T_NAME_ERROR { $$ = new ErrorNode($1); } |  T_NULL_ERROR { $$ = new ErrorNode($1); } |  T_NUM_ERROR { $$ = new ErrorNode($1); } |  T_VALUE_ERROR { $$ = new ErrorNode($1); } |  T_GETTING_DATA_ERROR { $$ = new ErrorNode($1); } | T_SPILL_ERROR { $$ = new ErrorNode($1); } | T_CALC_ERROR { $$ = new ErrorNode($1); } | T_BLOCKED_ERROR { $$ = new ErrorNode($1); } | T_BUSY_ERROR { $$ = new ErrorNode($1); } | T_CIRCULAR_ERROR { $$ = new ErrorNode($1); } | T_CONNECT_ERROR { $$ = new ErrorNode($1); } | T_EXTERNAL_ERROR { $$ = new ErrorNode($1); } | T_FIELD_ERROR { $$ = new ErrorNode($1); } | T_PYTHON_ERROR { $$ = new ErrorNode($1); } | T_UNKNOWN_ERROR { $$ = new ErrorNode($1); };

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

cell_reference : external_cell_reference { $$ = $1; } | cell_range { $$ = $1; } | cell { $$ = $1; };
name_reference: opt_whitespace T_IDENTIFIER opt_whitespace T_LPAREN opt_whitespace argument_list opt_whitespace T_RPAREN opt_whitespace
    {
        UserDefinedFunctionNode head = new UserDefinedFunctionNode(new NameNode($2), $1, $3);
        ArgumentParseResult result = $6;

        $$ = new FunctionCallNode(head,  result.Arguments,  $1, $9);
    }
    | name
    {
        // This handles the case of a simple named range or variable.
        $$ = $1;
    }
    ;
name :  opt_whitespace T_AT_SYMBOL opt_whitespace T_IDENTIFIER opt_whitespace { $$ = new ImplicitIntersectionNode(new AtSymbolLiteralNode($2, $1, $3), new NamedRangeNode($4, null, null), null, $5); }
        | opt_whitespace T_IDENTIFIER opt_whitespace { $$ = new NamedRangeNode($2, $1, $3); };

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
    | A1_cell { $$ = $1; }
    ;
cell_range :
    A1_cell   T_COLON  A1_cell        { $$ = new CellRangeNode<A1CellNode, A1CellNode, UInt64, A1RowNode, UInt64, A1ColumnNode, UInt64, A1RowNode, UInt64, A1ColumnNode>($1, new ColonNode($2), $3); }
  | A1_cell   T_COLON  R1C1_cell      { $$ = new CellRangeNode<A1CellNode, R1C1CellNode, UInt64, A1RowNode, UInt64, A1ColumnNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode>($1, new ColonNode($2), $3); }
  | R1C1_cell T_COLON  A1_cell        { $$ = new CellRangeNode<R1C1CellNode, A1CellNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode, UInt64, A1RowNode, UInt64, A1ColumnNode>($1, new ColonNode($2), $3); }
  | R1C1_cell T_COLON  R1C1_cell      { $$ = new CellRangeNode<R1C1CellNode, R1C1CellNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode>($1, new ColonNode($2), $3); }
  | A1_column T_COLON  A1_column      { $$ = new RangeNode($1, new ColonNode($2), $3); }
  | A1_row    T_COLON  A1_row         { $$ = new RangeNode($1, new ColonNode($2), $3); }
  ;



external_cell_reference : single_sheet_reference { $$ = $1; } | sheet_range_reference { $$ = $1; } | bang_reference { $$ = $1; };

bang: opt_whitespace T_BANG opt_whitespace { $$ = new BangNode($2, $1, $3); };
bang_reference : opt_whitespace bang cell_or_ref_constant opt_whitespace { $$ = new BangReferenceNode($2, $3, $1, $4); };

sheet_range_reference   : sheet_range bang_reference { $$ = new SheetReferenceNode($1, $2); };
single_sheet_reference   :  single_sheet bang_reference { $$ = new SheetReferenceNode($1, $2); };
single_sheet
    : workbook_index opt_whitespace T_IDENTIFIER { $$ = new SheetNode($1, $3, false, $2, null); }
    | workbook_name opt_whitespace T_IDENTIFIER { $$ = new SheetNode($1, $3, false, $2, null); }
    |                opt_whitespace T_IDENTIFIER { $$ = new SheetNode(null, $2, false, $1, null); }
    | opt_whitespace T_SHEET_NAME_SPECIAL opt_whitespace { $$ = new SheetNode(null, $2, true, $1, $3); }
     ;
sheet_range
    : workbook_index opt_whitespace T_IDENTIFIER opt_whitespace T_COLON opt_whitespace T_IDENTIFIER { $$ = new SheetRangeNode($1, $3, new ColonNode($5, $4, $6), $7, $2, null); }
    | workbook_name opt_whitespace T_IDENTIFIER opt_whitespace T_COLON opt_whitespace T_IDENTIFIER { $$ = new SheetRangeNode($1, $3, new ColonNode($5, $4, $6), $7, $2, null); }
    |                opt_whitespace T_IDENTIFIER opt_whitespace T_COLON opt_whitespace T_IDENTIFIER { $$ = new SheetRangeNode(null, $2, new ColonNode($4, $3, $5), $6, $1, null); }
    ;


cell_or_ref_constant : cell { $$ = $1; } | cell_range { $$ = $1; } | name { $$ = $1; } | ref_constant { $$ = $1; };
// pivot_items :  pivot_items  T_INTERSECTION opt_whitespace pivot_item { List<Node> ws = new List<Node>() { new WhitespaceNode($2) }; ws.AddRange($3); $$ = new IntersectionNode($1, $4, ws); }
// | pivot_item { $$ = $1; };

// pivot_item
//     : name T_LBRACK pivot_item_index T_RBRACK { $$ = new IndexedPivotField($1, $3); }
//     | name { $$ = new PivotField($1); }
//     ;

// pivot_item_index
//     : name { $$ = $1; }
//     | opt_whitespace T_PLUS opt_whitespace T_LONG opt_whitespace { $$ = new PivotFieldOffset(new UnaryPlusNode(new NumericLiteralNode<long>($4, "D"), $3, $1, $5)); }
//     | opt_whitespace T_MINUS opt_whitespace T_LONG opt_whitespace { $$ = new PivotFieldOffset(new UnaryMinusNode(new NumericLiteralNode<long>($4, "D"), $3, $1, $5)); }
//
//     | opt_whitespace T_LONG opt_whitespace { $$ = new PivotFieldOffset(new NumericLiteralNode<long>($2, "D", $1, $3)); }
//     ;

opt_name:
        name
        | /* empty */ { $$ = null; };


structure_reference
    : workbook_index opt_name intra_table_reference_list { $$ = new StructuredReferenceNode($1, $2, $3); }
    |  opt_name intra_table_reference_list { $$ = new StructuredReferenceNode(null, $1, $2); }

    | intra_table_reference_list { $$ = new StructuredReferenceNode(null, null, $1); }
    ;

inner_reference_item: keyword_list { $$ = $1; }
    | keyword { $$ = $1; }
    | column_range { $$ = $1; }
    | structure_column { $$ = $1; }
    | name { $$ = $1; }
    // | inner_reference
    ;

inner_reference

    : inner_reference opt_whitespace T_COMMA opt_whitespace inner_reference_item
        {
            if ($1.LastOrDefault() is ExpressionNode last) last.TrailingWhitespace.AddRange($2);
            if ($5 is ExpressionNode first) first.LeadingWhitespace.AddRange($4);
            $1.Add($5);
            $$ = $1;
        }
        | inner_reference_item
        {
            $$ = new List<ExpressionNode> { $1 };
        }
        | /* empty */ { $$ = new List<ExpressionNode>(); }
    ;

opt_inner_reference: inner_reference { $$ = $1; }
                   | /* empty */ { $$ = new List<ExpressionNode>(); }
                   ;

intra_table_reference
   : T_LBRACK opt_whitespace opt_inner_reference opt_whitespace T_RBRACK
     {
         $$ = new IntraTableIndexedReference($3, $2, $4);
     }
   ;

intra_table_reference_list
    : intra_table_reference
        {
            $$ = new List<ExpressionNode> { $1 };
        }
    | intra_table_reference_list opt_whitespace intra_table_reference
        {
            if ($1.LastOrDefault() is ExpressionNode last) last.TrailingWhitespace.AddRange($2);
            $1.Add($3);
            $$ = $1;
        }
    ;

structure_data: T_SR_DATA { $$ = new StructureDataNode(); };
structure_headers: T_SR_HEADERS { $$ = new StructureHeadersNode(); };
structure_totals: T_SR_TOTALS { $$ = new StructureTotalsNode(); };

structure_this_row
    : T_AT_SYMBOL opt_whitespace structure_column
    {
        AtSymbolLiteralNode atSymbol = new AtSymbolLiteralNode($1, null, $2);
        $$ = new StructureThisRowByPrefixNode(atSymbol, $3);
    }
    | T_AT_SYMBOL opt_whitespace name
    {
        AtSymbolLiteralNode atSymbol = new AtSymbolLiteralNode($1, null, $2);
        $$ = new StructureThisRowByPrefixNode(atSymbol, $3);
    }
    | T_SR_THIS_ROW { $$ = new StructureThisRowNode($1); }
    | T_AT_SYMBOL { $$ = new StructureThisRowNode($1); }
    ;

structure_all: T_SR_ALL { $$ = new StructureAllNode(); };
keyword: structure_all { $$ = $1; }| structure_data { $$ = $1; }| structure_headers { $$ = $1; }| structure_totals { $$ = $1; } | structure_this_row { $$ = $1; };
keyword_list
     : structure_all { $$ = $1; } | structure_data { $$ = $1; } | structure_headers { $$ = $1; } | structure_totals { $$ = $1; } | structure_this_row { $$ = $1; }
     ;

column_range: structure_column T_COLON structure_column { $$ = new StructureColumnRange($1, $3); };
structure_column: T_LBRACK opt_whitespace name opt_whitespace T_RBRACK
    {
        LeftBracketNode openBracket = new LeftBracketNode($1, null, $2);
        RightBracketNode closeBracket = new RightBracketNode($5, $4, null);
        $$ = new StructureColumn(openBracket, $3, closeBracket);
    };

workbook_index : T_LBRACK opt_whitespace T_LONG opt_whitespace T_RBRACK
    {
        LeftBracketNode openBracket = new LeftBracketNode($1, null, $2);
        RightBracketNode closeBracket = new RightBracketNode($5, $4, null);
        $$ = new WorkbookIndexNode($3, openBracket, closeBracket);
    };

workbook_name
    : T_LBRACK opt_whitespace workbook_name_text opt_whitespace T_RBRACK
    {
        LeftBracketNode openBracket = new LeftBracketNode($1, null, $2);
        RightBracketNode closeBracket = new RightBracketNode($5, $4, null);
        $$ = new WorkbookNameNode($3, openBracket, closeBracket);
    }
    ;

workbook_name_text
    : workbook_name_text workbook_name_piece { $$ = $1 + $2; }
    | workbook_name_piece { $$ = $1; }
    ;

workbook_name_piece
    : T_IDENTIFIER { $$ = $1; }
    | T_COLON { $$ = $1; }
    | T_SLASH { $$ = $1; }
    | T_MINUS { $$ = $1; }
    | T_DOLLAR { $$ = $1; }
    | T_HASH { $$ = $1; }
    | T_AMPERSAND { $$ = $1; }
    | T_LPAREN { $$ = $1; }
    | T_RPAREN { $$ = $1; }
    | T_AT_SYMBOL { $$ = $1; }
    | T_EQ { $$ = $1; }
    | T_GT { $$ = $1; }
    | T_GE { $$ = $1; }
    | T_LT { $$ = $1; }
    | T_LE { $$ = $1; }
    | T_PERCENT { $$ = $1; }
    | T_CARET { $$ = $1; }
    | T_ASTERISK { $$ = $1; }
    | T_COMMA { $$ = $1; }
    | T_SEMICOLON { $$ = $1; }
    | T_NUMERICAL_CONSTANT { $$ = $1; }
    | T_LONG
    {
        string l = $1.ToString(System.Globalization.CultureInfo.InvariantCulture);
        $$ = l;
    }
    | whitespace { $$ = $1.ToString(); }
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

#include "function/command/nodes.inc"
#include "function/future/nodes.inc"
#include "function/macro/nodes.inc"
#include "function/standard/nodes.inc"
#include "function/worksheet/nodes.inc"

%%

public Node root;
internal Parser(OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner scanner) : base(scanner)
{
    scanner.Parser = this;
}
