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
        public List<List<Node>> WsBeforeComma { get; set; } = new List<List<Node>>();
        public List<List<Node>> WsAfterComma { get; set; } = new List<List<Node>>();
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

%token T_A1_ROW
%token T_A1_COLUMN
%token R1C1_COLUMN_PREFIX
%token R1C1_ROW_PREFIX
%token R1C1_ROW
%token R1C1_COLUMN

%token T_AT_SYMBOL
%token T_DOLLAR
%token T_DIV0_ERROR
%token T_EMPTY_BRACKETS
%token T_FALSE

#include "function/command.inc"
#include "function/future.inc"
#include "function/macro.inc"
#include "function/standard.inc"
#include "function/worksheet.inc"

%token T_HASH
%token T_GE
%token T_GETTING_DATA_ERROR
%token T_LE
%token T_NA_ERROR
%token T_NAME_ERROR
%token T_NE
%token T_NEWLINE
%token T_NULL_ERROR
%token T_NUM_ERROR
%token T_QUESTIONMARK
%token T_REF_ERROR
%token T_SHEET_NAME_SPECIAL
%token T_SR_ALL
%token T_SR_DATA
%token T_SR_HEADERS
%token T_SR_THIS_ROW
%token T_SR_TOTALS
%token T_TRUE
%token T_VALUE_ERROR
%token T_XLFN_
%token T_XLFN_XLWS_
%token T_XLOP_
%token T_XLPM_


%token<stringVal> T_NUMERICAL_CONSTANT
%token<longVal> T_LONG T_R1C1_ROW T_R1C1_COLUMN
%token<ulongVal>  T_A1_ROW T_A1_COLUMN
%token <stringVal> T_UNKNOWN_CHAR T_BANG T_AT_SYMBOL T_INTERSECTION T_NEWLINE T_SR_THIS_ROW
%token <stringVal> T_IDENTIFIER  T_STRING_CONSTANT T_QUOTED_IDENTIFIER T_SHEET_NAME_SPECIAL
%token <stringVal> T_STRUCTURED_REFERENCE T_XLFN_XLWS_
%token <stringVal> T_DIV0_ERROR T_NA_ERROR T_NAME_ERROR T_NULL_ERROR T_NUM_ERROR T_VALUE_ERROR T_GETTING_DATA_ERROR T_REF_ERROR T_SPILL_ERROR T_CALC_ERROR T_BLOCKED_ERROR T_BUSY_ERROR T_CIRCULAR_ERROR T_CONNECT_ERROR T_EXTERNAL_ERROR T_FIELD_ERROR T_PYTHON_ERROR T_UNKNOWN_ERROR
%token <stringVal> T_QUESTIONMARK
%token T_PLUS T_MINUS T_ASTERISK T_SLASH T_AMPERSAND T_CARET T_PERCENT T_HASH
%token T_EQ T_NE T_LT T_LE T_GT T_GE
%token T_LPAREN T_RPAREN T_LBRACE T_RBRACE T_LBRACK T_RBRACK T_COMMA T_COLON T_SEMICOLON
%token T_TRUE T_FALSE T_EMPTY_BRACKETS
%token T_SR_ALL T_SR_DATA T_SR_HEADERS T_SR_TOTALS T_SR_THIS_ROW

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

%type <expressionVal>     array_constant cell_or_ref_constant cell_range cell intra_table_reference
%type <expressionVal>           name opt_name
%type <rowsVal>           constant_list_rows
%type <expressionListVal> constant_list_row inner_reference opt_inner_reference intra_table_reference_list
%type <expressionVal>     external_cell_reference sheet_range_reference single_sheet_reference
%type <expressionVal>     cell_or_ref_constant single_sheet sheet_range
%type <expressionVal>     external_cell_reference bang_reference
%type <expressionVal>     function_call_head  argument
%type <argParseResultVal> argument_list
%type <stringVal>         standard_function_name future_function_name worksheet_function_name macro_function_name command_function_name
%type <nodeListVal>       opt_whitespace
%type <expressionVal>     opt_expression opt_solo_function
%type <expressionVal>     constant_leaf
%type <expressionVal>     keyword_list

%type <bangVal>           bang
%type <bangReferenceVal>  bang_reference


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

formula: opt_whitespace opt_expression opt_whitespace
        {
        if ($2 != null) {
            root = $2;
            if (root is ExpressionNode exprRoot)
            {
            if ($1 != null) {
                exprRoot.LeadingWhitespace.InsertRange(0, $1);
            }
              if ($3 != null) {
                exprRoot.TrailingWhitespace.AddRange($3);
                }
            }
            $$ = root;
        }
        } | opt_whitespace opt_solo_function opt_whitespace
        {
        if ($2 != null) {
            root = $2;
            if (root is ExpressionNode exprRoot)
            {
            if ($1 != null) {
                exprRoot.LeadingWhitespace.InsertRange(0, $1);
            }
              if ($3 != null) {
                exprRoot.TrailingWhitespace.AddRange($3);
                }
            }

         $$ = root;
        }
        }
    ;

opt_expression: { $$ = null; }
    | expression
    ;

opt_solo_function: { $$ = null; }
    | solo_function
    ;

expression: T_LPAREN opt_whitespace expression opt_whitespace T_RPAREN { $$ = new ParenthesizedExpressionNode($3, $2, $4); }
    | expression opt_whitespace T_PLUS opt_whitespace expression         { $$ = new AddNode($1, $5, $2, $4); }
    | expression opt_whitespace T_MINUS opt_whitespace expression        { $$ = new SubtractNode($1, $5, $2, $4); }
    | expression opt_whitespace T_ASTERISK opt_whitespace expression     { $$ = new MultiplyNode($1, $5, $2, $4); }
    | expression opt_whitespace T_SLASH opt_whitespace expression        { $$ = new DivideNode($1, $5, $2, $4); }
    | expression opt_whitespace T_CARET opt_whitespace expression        { $$ = new PowerNode($1, $5, $2, $4); }
    | expression opt_whitespace T_AMPERSAND opt_whitespace expression    { $$ = new ConcatenateNode($1, $5, $2, $4); }
    | expression opt_whitespace T_NE opt_whitespace expression           { $$ = new NotEqualNode($1, $5, $2, $4); }
    | expression opt_whitespace T_LE opt_whitespace expression           { $$ = new LessThanOrEqualNode($1, $5, $2, $4); }
    | expression opt_whitespace T_LT opt_whitespace expression           { $$ = new LessThanNode($1, $5, $2, $4); }
    | expression opt_whitespace T_GE opt_whitespace expression           { $$ = new GreaterThanOrEqualNode($1, $5, $2, $4); }
    | expression opt_whitespace T_GT opt_whitespace expression           { $$ = new GreaterThanNode($1, $5, $2, $4); }
    | expression opt_whitespace T_EQ opt_whitespace expression           { $$ = new EqualNode($1, $5, $2, $4); }
    | expression opt_whitespace T_COLON opt_whitespace expression        { $$ = new RangeNode($1, $5, $2, $4); }
    | expression opt_whitespace T_COMMA opt_whitespace expression        { $$ = new UnionNode($1, $5, $2, $4); }
    | expression opt_whitespace T_PERCENT %prec T_PERCENT                { $$ = new PercentNode($1, $2); }
    | expression opt_whitespace T_HASH                                 { $$ = new DynamicNode($1, $2); }
    | T_PLUS opt_whitespace expression %prec UMINUS                      { $$ = new UnaryPlusNode($3, $2); }
    | T_MINUS opt_whitespace expression %prec UMINUS                     { $$ = new UnaryMinusNode($3, $2); }
    | expression T_INTERSECTION opt_whitespace expression { List<Node> whitespace = new List<Node>() { new WhitespaceNode($2) }; whitespace.AddRange($3); $$ = new IntersectionNode($1, $4, whitespace); }
    | primary { $$ = $1; }
    ;

primary: constant
    | ref_constant
    | structure_reference
    | cell_reference
    | A1_row { $$ = $1; }
    | A1_column { $$ = $1; }
    | function_call
    | name_reference
    // | pivot_items
    ;

function_call_head: standard_function_name { $$ = new BuiltInStandardFunctionNode($1); }
    | future_function_name { $$ = new BuiltInFutureFunctionNode($1); }
    | macro_function_name { $$ = new BuiltInMacroFunctionNode($1); }
    | command_function_name opt_whitespace T_QUESTIONMARK opt_whitespace { $$ = new BuiltInCommandFunctionNode($1, new QuestionMarkNode($3, $2, $4)); }
    | command_function_name opt_whitespace { $$ = new BuiltInCommandFunctionNode($1, null); }

    | opt_whitespace T_XLFN_XLWS_ opt_whitespace worksheet_function_name opt_whitespace { $$ = new BuiltInWorksheetFunctionNode($2, $3, $4, $1, $5); }
    ;

function_call: function_call_head opt_whitespace T_LPAREN opt_whitespace argument_list opt_whitespace T_RPAREN
        {
            ArgumentParseResult result = $5;
            for (int i = 0; i < result.WsBeforeComma.Count; i++)
            {
                if (i + 1 < result.Arguments.Count && result.WsBeforeComma[i] != null) {
                result.Arguments[i].TrailingWhitespace.AddRange(result.WsBeforeComma[i]);
                }
                if (i + 1 < result.Arguments.Count && result.WsAfterComma[i] != null)
                {
                    result.Arguments[i+1].LeadingWhitespace.AddRange(result.WsAfterComma[i]);
                }
            }
            $$ = new FunctionCallNode($1, $2, $4, result.Arguments, result.WsBeforeComma, result.WsAfterComma, $6);
        };

solo_function: opt_whitespace T_XLFN_XLWS_ opt_whitespace T_FUNC_PY opt_whitespace T_LPAREN opt_whitespace T_LONG opt_whitespace T_COMMA opt_whitespace T_NUMERICAL_CONSTANT opt_whitespace argument_list opt_whitespace T_RPAREN opt_whitespace
        {
            BuiltInWorksheetFunctionNode pyNode = new BuiltInWorksheetFunctionNode($2, $3, "PY", $1, $5);
            NumericLiteralNode<long> arg1 = new NumericLiteralNode<long>($8, $7, $9);
            NumericLiteralNode<double> arg2 = new NumericLiteralNode<double>($12, $11, $13);

            ArgumentParseResult result = $14;
            result.Arguments.Insert(0, arg2);
            result.Arguments.Insert(0, arg1);

            result.WsBeforeComma.Insert(0, $9);
            result.WsAfterComma.Insert(0, $11);

            for (int i = 0; i < result.WsBeforeComma.Count; i++)
            {
                if (i < result.Arguments.Count - 1)
                {
                    result.Arguments[i].TrailingWhitespace.AddRange(result.WsBeforeComma[i]);
                    result.Arguments[i+1].LeadingWhitespace.AddRange(result.WsAfterComma[i]);
                }
            }

            FunctionCallNode funcCall = new FunctionCallNode(pyNode, $5, $7, result.Arguments, result.WsBeforeComma, result.WsAfterComma, $15, null, $17);
            $$ = funcCall;
        }
    ;

argument_list:
    argument_list opt_whitespace T_COMMA opt_whitespace argument
        {
            $$ = $1;
            if ($5 != null) $$.Arguments.Add($5);
            $$.WsBeforeComma.Add($2);
            $$.WsAfterComma.Add($4);
        }
    |     expression { $$ = new ArgumentParseResult(); if ($1 != null) $$.Arguments.Add($1); }
    | /* empty */ { $$ = new ArgumentParseResult(); }
    ;

argument: expression
    | /* empty */ { $$ = new EmptyArgumentNode(); }
    ;


constant: opt_whitespace constant_leaf opt_whitespace { $$ = $2; $2.LeadingWhitespace = $1; $2.TrailingWhitespace = $3; }
    ;

constant_leaf: T_NUMERICAL_CONSTANT { $$ = new NumericLiteralNode<double>($1); }
             | T_LONG { $$ = new NumericLiteralNode<long>($1); }
             | T_STRING_CONSTANT { $$ = new StringNode($1); }
             | T_TRUE { $$ = new LogicalNode(true); }
             | T_FALSE { $$ = new LogicalNode(false); }
             | error_constant { $$ = $1; }
             | array_constant { $$ = $1; };

error_constant: T_DIV0_ERROR { $$ = new ErrorNode($1); } | T_NA_ERROR { $$ = new ErrorNode($1); } | T_NAME_ERROR { $$ = new ErrorNode($1); } |  T_NULL_ERROR { $$ = new ErrorNode($1); } |  T_NUM_ERROR { $$ = new ErrorNode($1); } |  T_VALUE_ERROR { $$ = new ErrorNode($1); } |  T_GETTING_DATA_ERROR { $$ = new ErrorNode($1); } | T_SPILL_ERROR { $$ = new ErrorNode($1); } | T_CALC_ERROR { $$ = new ErrorNode($1); } | T_BLOCKED_ERROR { $$ = new ErrorNode($1); } | T_BUSY_ERROR { $$ = new ErrorNode($1); } | T_CIRCULAR_ERROR { $$ = new ErrorNode($1); } | T_CONNECT_ERROR { $$ = new ErrorNode($1); } | T_EXTERNAL_ERROR { $$ = new ErrorNode($1); } | T_FIELD_ERROR { $$ = new ErrorNode($1); } | T_PYTHON_ERROR { $$ = new ErrorNode($1); } | T_UNKNOWN_ERROR { $$ = new ErrorNode($1); };

ref_constant: opt_whitespace T_REF_ERROR opt_whitespace { $$ = new ErrorNode($2, $1, $3); }
    ;

array_constant: T_LBRACE opt_whitespace constant_list_rows opt_whitespace T_RBRACE
        {
            if ($3.FirstOrDefault()?.FirstOrDefault() is ExpressionNode expr)
                expr.LeadingWhitespace.InsertRange(0, $2);
            if ($3.LastOrDefault()?.LastOrDefault() is ExpressionNode lastExpr)
                lastExpr.TrailingWhitespace.AddRange($4);
            $$ = new ArrayNode($3);
        }
    ;

constant_list_rows: constant_list_row { $$ = new List<List<ExpressionNode>> { $1 }; }
    | constant_list_rows opt_whitespace T_SEMICOLON opt_whitespace constant_list_row
        {
            if ($1.LastOrDefault()?.LastOrDefault() != null)
                $1.Last().Last().TrailingWhitespace.AddRange($2);
            if ($5.FirstOrDefault() != null)
                $5.First().LeadingWhitespace.AddRange($4);
            $1.Add($5);
            $$ = $1;
        }
    ;

constant_list_row: constant { $$ = new List<ExpressionNode> { $1 }; }
    | constant_list_row opt_whitespace T_COMMA opt_whitespace constant
        {
            $1.LastOrDefault()?.TrailingWhitespace.AddRange($2);
            $5.LeadingWhitespace.AddRange($4);
            $1.Add($5);
            $$ = $1;
        }
    ;

cell_reference : external_cell_reference  | cell_range | cell;
name_reference: opt_whitespace T_IDENTIFIER opt_whitespace T_LPAREN opt_whitespace argument_list opt_whitespace T_RPAREN
    {
        // This logic is moved from the old function_call rule.
        // $1 is a NameNode, which correctly captures the identifier and its whitespace.
        UserDefinedFunctionNode head = new UserDefinedFunctionNode($2, $1, $3);
        ArgumentParseResult result = $6;
        for (int i = 0; i < result.WsBeforeComma.Count; i++)
            {
                if (i + 1 < result.Arguments.Count && result.WsBeforeComma[i] != null) {
                result.Arguments[i].TrailingWhitespace.AddRange(result.WsBeforeComma[i]);
                }
                if (i + 1 < result.Arguments.Count && result.WsAfterComma[i] != null)
                {
                    result.Arguments[i+1].LeadingWhitespace.AddRange(result.WsAfterComma[i]);
                }
            }
        $$ = new FunctionCallNode(head, new List<Node>(), $5, result.Arguments,  $7);
    }
    | name
    {
        // This handles the case of a simple named range or variable.
        $$ = $1;
    }
    ;
name :  opt_whitespace T_AT_SYMBOL opt_whitespace T_IDENTIFIER opt_whitespace { $$ = new ImplicitIntersectionNode(new NamedRangeNode($4, null, null), $3, $1, $5); }
        | opt_whitespace T_IDENTIFIER opt_whitespace { $$ = new NamedRangeNode($2, $1, $3); };

A1_column_absolute: T_DOLLAR T_A1_COLUMN { $$ = new A1AbsoluteColumnNode($2); };
A1_column_relative: T_A1_COLUMN { $$ = new A1RelativeColumnNode($1); };

A1_column: A1_column_absolute { $$ = $1; } | A1_column_relative { $$ = $1; };

A1_row_absolute: T_DOLLAR T_A1_ROW { $$ = new A1AbsoluteRowNode($2); };
A1_row_relative: T_A1_ROW { $$ = new A1RelativeRowNode($1); };

A1_row: A1_row_absolute { $$ = $1; } | A1_row_relative { $$ = $1; };

R1C1_column_relative: R1C1_COLUMN_PREFIX T_LBRACK T_R1C1_COLUMN T_RBRACK { $$ = new R1C1RelativeColumnNode($3); };
R1C1_column_absolute: R1C1_COLUMN_PREFIX T_R1C1_COLUMN { $$ = new R1C1AbsoluteColumnNode($2); };
R1C1_column: R1C1_column_relative { $$ = $1; }  | R1C1_column_absolute { $$ = $1; };

R1C1_row_relative: R1C1_ROW_PREFIX T_LBRACK T_R1C1_ROW T_RBRACK { $$ = new R1C1RelativeRowNode($3); };
R1C1_row_absolute: R1C1_ROW_PREFIX T_R1C1_ROW { $$ = new R1C1AbsoluteRowNode($2); };
R1C1_row: R1C1_row_relative { $$ = $1; } | R1C1_row_absolute { $$ = $1; };

R1C1_cell: R1C1_row R1C1_column { $$ = new R1C1CellNode($1, $2); };
A1_cell: A1_column A1_row { $$ = new A1CellNode($1, $2); };

cell: R1C1_cell { $$ = $1; } | A1_cell { $$ = $1; };
cell_range :
           A1_cell T_COLON  A1_cell { $$ = new CellRangeNode<A1CellNode, A1CellNode, UInt64, A1RowNode, UInt64, A1ColumnNode, UInt64, A1RowNode, UInt64, A1ColumnNode>($1, $3); }
           | A1_cell T_COLON  R1C1_cell { $$ = new CellRangeNode<A1CellNode, R1C1CellNode, UInt64, A1RowNode, UInt64, A1ColumnNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode>($1, $3); }
           | R1C1_cell T_COLON A1_cell  { $$ = new CellRangeNode<R1C1CellNode, A1CellNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode, UInt64, A1RowNode, UInt64, A1ColumnNode>($1, $3); }
                       | R1C1_cell T_COLON  R1C1_cell { $$ = new CellRangeNode<R1C1CellNode, R1C1CellNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode>($1, $3); }
            | A1_column T_COLON A1_column { $$ = new RangeNode($1, $3, null, null); }
            | A1_row T_COLON A1_row { $$ = new RangeNode($1, $3, null, null); };



external_cell_reference : single_sheet_reference { $$ = $1; } | sheet_range_reference { $$ = $1; } | bang_reference { $$ = $1; };

bang: opt_whitespace T_BANG opt_whitespace { $$ = new BangNode($2, $1, $3); };
bang_reference : opt_whitespace bang cell_or_ref_constant opt_whitespace { $$ = new BangReferenceNode($2, $3, $1, $4); };

sheet_range_reference   : sheet_range bang_reference { $$ = new SheetReferenceNode($1, $2); };
single_sheet_reference   :  single_sheet bang_reference { $$ = new SheetReferenceNode($1, $2); };
single_sheet
    : workbook_index opt_whitespace T_IDENTIFIER { $$ = new SheetNode($1, $2, $3, false); }
    |                opt_whitespace T_IDENTIFIER { $$ = new SheetNode(null, new List<Node>(), $2, false, $1, new List<Node>()); }
    | opt_whitespace T_SHEET_NAME_SPECIAL opt_whitespace { $$ = new SheetNode(null, new List<Node>(), $2, true, $1, $3); }
     ;
sheet_range
    : workbook_index opt_whitespace T_IDENTIFIER opt_whitespace T_COLON opt_whitespace T_IDENTIFIER { $$ = new SheetRangeNode($1, $2, $3, $4, $6, $7); }
    |                opt_whitespace T_IDENTIFIER opt_whitespace T_COLON opt_whitespace T_IDENTIFIER { $$ = new SheetRangeNode(null, $1, $2, $3, $5, $6); }
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
//     | opt_whitespace T_PLUS opt_whitespace T_LONG opt_whitespace { $$ = new PivotFieldOffset(new UnaryPlusNode(new NumericLiteralNode<long>($4), $3, $1, $5)); }
//     | opt_whitespace T_MINUS opt_whitespace T_LONG opt_whitespace { $$ = new PivotFieldOffset(new UnaryMinusNode(new NumericLiteralNode<long>($4), $3, $1, $5)); }
//
//     | opt_whitespace T_LONG opt_whitespace { $$ = new PivotFieldOffset(new NumericLiteralNode<long>($2, $1, $3)); }
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

structure_this_row: T_AT_SYMBOL structure_column { $$ = new StructureThisRowByPrefixNode($2); }
                  | T_AT_SYMBOL name { $$ = new StructureThisRowByPrefixNode($2); }
                  | T_SR_THIS_ROW { $$ = new StructureThisRowNode($1); };

structure_all: T_SR_ALL { $$ = new StructureAllNode(); };
keyword: structure_all { $$ = $1; }| structure_data { $$ = $1; }| structure_headers { $$ = $1; }| structure_totals { $$ = $1; } | structure_this_row { $$ = $1; };
keyword_list
     : structure_all { $$ = $1; } | structure_data { $$ = $1; } | structure_headers { $$ = $1; } | structure_totals { $$ = $1; } | structure_this_row { $$ = $1; }
     ;

column_range: structure_column T_COLON structure_column { $$ = new StructureColumnRange($1, $3); };
structure_column: T_LBRACK name T_RBRACK { $$ = new StructureColumn($2); };

workbook_index : T_LBRACK opt_whitespace T_LONG opt_whitespace T_RBRACK { $$ = new WorkbookIndexNode($3, $2, $4); };

whitespace: T_NEWLINE { $$ = new WhitespaceNode($1); }
          | T_INTERSECTION { $$ = new WhitespaceNode($1); };
opt_whitespace:
     opt_whitespace whitespace { $1.Add($2); $$ = $1; }
    | whitespace { $$ = new List<Node>() { $1 }; }
    | /* empty */ { $$ = new List<Node>(); }
    ;

standard_function_name: T_FUNC_ABS { $$ = "ABS"; } | T_FUNC_ACCRINT { $$ = "ACCRINT"; } | T_FUNC_ACCRINTM { $$ = "ACCRINTM"; } | T_FUNC_ACOS { $$ = "ACOS"; } | T_FUNC_ACOSH { $$ = "ACOSH"; } | T_FUNC_ADDRESS { $$ = "ADDRESS"; } | T_FUNC_AMORDEGRC { $$ = "AMORDEGRC"; } | T_FUNC_AMORLINC { $$ = "AMORLINC"; } | T_FUNC_AND { $$ = "AND"; } | T_FUNC_AREAS { $$ = "AREAS"; } | T_FUNC_ASC { $$ = "ASC"; } | T_FUNC_ASIN { $$ = "ASIN"; } | T_FUNC_ASINH { $$ = "ASINH"; } | T_FUNC_ATAN { $$ = "ATAN"; } | T_FUNC_ATAN2 { $$ = "ATAN2"; } | T_FUNC_ATANH { $$ = "ATANH"; } | T_FUNC_AVEDEV { $$ = "AVEDEV"; } | T_FUNC_AVERAGE { $$ = "AVERAGE"; } | T_FUNC_AVERAGEA { $$ = "AVERAGEA"; } | T_FUNC_AVERAGEIF { $$ = "AVERAGEIF"; } | T_FUNC_AVERAGEIFS { $$ = "AVERAGEIFS"; } | T_FUNC_BAHTTEXT { $$ = "BAHTTEXT"; } | T_FUNC_BESSELI { $$ = "BESSELI"; } | T_FUNC_BESSELJ { $$ = "BESSELJ"; } | T_FUNC_BESSELK { $$ = "BESSELK"; } | T_FUNC_BESSELY { $$ = "BESSELY"; } | T_FUNC_BETADIST { $$ = "BETADIST"; } | T_FUNC_BETAINV { $$ = "BETAINV"; } | T_FUNC_BIN2DEC { $$ = "BIN2DEC"; } | T_FUNC_BIN2HEX { $$ = "BIN2HEX"; } | T_FUNC_BIN2OCT { $$ = "BIN2OCT"; } | T_FUNC_BINOMDIST { $$ = "BINOMDIST"; } | T_FUNC_CEILING { $$ = "CEILING"; } | T_FUNC_CELL { $$ = "CELL"; } | T_FUNC_CHAR { $$ = "CHAR"; } | T_FUNC_CHIDIST { $$ = "CHIDIST"; } | T_FUNC_CHIINV { $$ = "CHIINV"; } | T_FUNC_CHITEST { $$ = "CHITEST"; } | T_FUNC_CHOOSE { $$ = "CHOOSE"; } | T_FUNC_CLEAN { $$ = "CLEAN"; } | T_FUNC_CODE { $$ = "CODE"; } | T_FUNC_COLUMN { $$ = "COLUMN"; } | T_FUNC_COLUMNS { $$ = "COLUMNS"; } | T_FUNC_COMBIN { $$ = "COMBIN"; } | T_FUNC_COMPLEX { $$ = "COMPLEX"; } | T_FUNC_CONCAT { $$ = "CONCAT"; } | T_FUNC_CONCATENATE { $$ = "CONCATENATE"; } | T_FUNC_CONFIDENCE { $$ = "CONFIDENCE"; } | T_FUNC_CONVERT { $$ = "CONVERT"; } | T_FUNC_CORREL { $$ = "CORREL"; } | T_FUNC_COS { $$ = "COS"; } | T_FUNC_COSH { $$ = "COSH"; } | T_FUNC_COUNT { $$ = "COUNT"; } | T_FUNC_COUNTA { $$ = "COUNTA"; } | T_FUNC_COUNTBLANK { $$ = "COUNTBLANK"; } | T_FUNC_COUNTIF { $$ = "COUNTIF"; } | T_FUNC_COUNTIFS { $$ = "COUNTIFS"; } | T_FUNC_COUPDAYBS { $$ = "COUPDAYBS"; } | T_FUNC_COUPDAYS { $$ = "COUPDAYS"; } | T_FUNC_COUPDAYSNC { $$ = "COUPDAYSNC"; } | T_FUNC_COUPNCD { $$ = "COUPNCD"; } | T_FUNC_COUPNUM { $$ = "COUPNUM"; } | T_FUNC_COUPPCD { $$ = "COUPPCD"; } | T_FUNC_COVAR { $$ = "COVAR"; } | T_FUNC_CRITBINOM { $$ = "CRITBINOM"; } | T_FUNC_CUBEKPIMEMBER { $$ = "CUBEKPIMEMBER"; } | T_FUNC_CUBEMEMBER { $$ = "CUBEMEMBER"; } | T_FUNC_CUBEMEMBERPROPERTY { $$ = "CUBEMEMBERPROPERTY"; } | T_FUNC_CUBERANKEDMEMBER { $$ = "CUBERANKEDMEMBER"; } | T_FUNC_CUBESET { $$ = "CUBESET"; } | T_FUNC_CUBESETCOUNT { $$ = "CUBESETCOUNT"; } | T_FUNC_CUBEVALUE { $$ = "CUBEVALUE"; } | T_FUNC_CUMIPMT { $$ = "CUMIPMT"; } | T_FUNC_CUMPRINC { $$ = "CUMPRINC"; } | T_FUNC_DATE { $$ = "DATE"; } | T_FUNC_DATEDIF { $$ = "DATEDIF"; } | T_FUNC_DATESTRING { $$ = "DATESTRING"; } | T_FUNC_DATEVALUE { $$ = "DATEVALUE"; } | T_FUNC_DAVERAGE { $$ = "DAVERAGE"; } | T_FUNC_DAY { $$ = "DAY"; } | T_FUNC_DAYS360 { $$ = "DAYS360"; } | T_FUNC_DB { $$ = "DB"; } | T_FUNC_DBCS { $$ = "DBCS"; } | T_FUNC_DCOUNT { $$ = "DCOUNT"; } | T_FUNC_DCOUNTA { $$ = "DCOUNTA"; } | T_FUNC_DDB { $$ = "DDB"; } | T_FUNC_DEC2BIN { $$ = "DEC2BIN"; } | T_FUNC_DEC2HEX { $$ = "DEC2HEX"; } | T_FUNC_DEC2OCT { $$ = "DEC2OCT"; } | T_FUNC_DEGREES { $$ = "DEGREES"; } | T_FUNC_DELTA { $$ = "DELTA"; } | T_FUNC_DEVSQ { $$ = "DEVSQ"; } | T_FUNC_DGET { $$ = "DGET"; } | T_FUNC_DISC { $$ = "DISC"; } | T_FUNC_DMAX { $$ = "DMAX"; } | T_FUNC_DMIN { $$ = "DMIN"; } | T_FUNC_DOLLAR { $$ = "DOLLAR"; } | T_FUNC_DOLLARDE { $$ = "DOLLARDE"; } | T_FUNC_DOLLARFR { $$ = "DOLLARFR"; } | T_FUNC_DPRODUCT { $$ = "DPRODUCT"; } | T_FUNC_DSTDEV { $$ = "DSTDEV"; } | T_FUNC_DSTDEVP { $$ = "DSTDEVP"; } | T_FUNC_DSUM { $$ = "DSUM"; } | T_FUNC_DURATION { $$ = "DURATION"; } | T_FUNC_DVAR { $$ = "DVAR"; } | T_FUNC_DVARP { $$ = "DVARP"; } | T_FUNC_EDATE { $$ = "EDATE"; } | T_FUNC_EFFECT { $$ = "EFFECT"; } | T_FUNC_EOMONTH { $$ = "EOMONTH"; } | T_FUNC_ERF { $$ = "ERF"; } | T_FUNC_ERFC { $$ = "ERFC"; } | T_FUNC_ERROR_TYPE { $$ = "ERROR.TYPE"; } | T_FUNC_EVEN { $$ = "EVEN"; } | T_FUNC_EXACT { $$ = "EXACT"; } | T_FUNC_EXP { $$ = "EXP"; } | T_FUNC_EXPONDIST { $$ = "EXPONDIST"; } | T_FUNC_FACT { $$ = "FACT"; } | T_FUNC_FACTDOUBLE { $$ = "FACTDOUBLE"; } | T_FUNC_FDIST { $$ = "FDIST"; } | T_FUNC_FIND { $$ = "FIND"; } | T_FUNC_FINDB { $$ = "FINDB"; } | T_FUNC_FINV { $$ = "FINV"; } | T_FUNC_FISHER { $$ = "FISHER"; } | T_FUNC_FISHERINV { $$ = "FISHERINV"; } | T_FUNC_FIXED { $$ = "FIXED"; } | T_FUNC_FLOOR { $$ = "FLOOR"; } | T_FUNC_FORECAST { $$ = "FORECAST"; } | T_FUNC_FREQUENCY { $$ = "FREQUENCY"; } | T_FUNC_FTEST { $$ = "FTEST"; } | T_FUNC_FV { $$ = "FV"; } | T_FUNC_FVSCHEDULE { $$ = "FVSCHEDULE"; } | T_FUNC_GAMMADIST { $$ = "GAMMADIST"; } | T_FUNC_GAMMAINV { $$ = "GAMMAINV"; } | T_FUNC_GAMMALN { $$ = "GAMMALN"; } | T_FUNC_GCD { $$ = "GCD"; } | T_FUNC_GEOMEAN { $$ = "GEOMEAN"; } | T_FUNC_GESTEP { $$ = "GESTEP"; } | T_FUNC_GETPIVOTDATA { $$ = "GETPIVOTDATA"; } | T_FUNC_GROWTH { $$ = "GROWTH"; } | T_FUNC_HARMEAN { $$ = "HARMEAN"; } | T_FUNC_HEX2BIN { $$ = "HEX2BIN"; } | T_FUNC_HEX2DEC { $$ = "HEX2DEC"; } | T_FUNC_HEX2OCT { $$ = "HEX2OCT"; } | T_FUNC_HLOOKUP { $$ = "HLOOKUP"; } | T_FUNC_HOUR { $$ = "HOUR"; } | T_FUNC_HYPERLINK { $$ = "HYPERLINK"; } | T_FUNC_HYPGEOMDIST { $$ = "HYPGEOMDIST"; } | T_FUNC_IF { $$ = "IF"; } | T_FUNC_IFERROR { $$ = "IFERROR"; } | T_FUNC_IFS { $$ = "IFS"; } | T_FUNC_IMABS { $$ = "IMABS"; } | T_FUNC_IMAGINARY { $$ = "IMAGINARY"; } | T_FUNC_IMARGUMENT { $$ = "IMARGUMENT"; } | T_FUNC_IMCONJUGATE { $$ = "IMCONJUGATE"; } | T_FUNC_IMCOS { $$ = "IMCOS"; } | T_FUNC_IMDIV { $$ = "IMDIV"; } | T_FUNC_IMEXP { $$ = "IMEXP"; } | T_FUNC_IMLN { $$ = "IMLN"; } | T_FUNC_IMLOG10 { $$ = "IMLOG10"; } | T_FUNC_IMLOG2 { $$ = "IMLOG2"; } | T_FUNC_IMPOWER { $$ = "IMPOWER"; } | T_FUNC_IMPRODUCT { $$ = "IMPRODUCT"; } | T_FUNC_IMREAL { $$ = "IMREAL"; } | T_FUNC_IMSIN { $$ = "IMSIN"; } | T_FUNC_IMSQRT { $$ = "IMSQRT"; } | T_FUNC_IMSUB { $$ = "IMSUB"; } | T_FUNC_IMSUM { $$ = "IMSUM"; } | T_FUNC_INDEX { $$ = "INDEX"; } | T_FUNC_INDIRECT { $$ = "INDIRECT"; } | T_FUNC_INFO { $$ = "INFO"; } | T_FUNC_INT { $$ = "INT"; } | T_FUNC_INTERCEPT { $$ = "INTERCEPT"; } | T_FUNC_INTRATE { $$ = "INTRATE"; } | T_FUNC_IPMT { $$ = "IPMT"; } | T_FUNC_IRR { $$ = "IRR"; } | T_FUNC_ISBLANK { $$ = "ISBLANK"; } | T_FUNC_ISERR { $$ = "ISERR"; } | T_FUNC_ISERROR { $$ = "ISERROR"; } | T_FUNC_ISEVEN { $$ = "ISEVEN"; } | T_FUNC_ISLOGICAL { $$ = "ISLOGICAL"; } | T_FUNC_ISNA { $$ = "ISNA"; } | T_FUNC_ISNONTEXT { $$ = "ISNONTEXT"; } | T_FUNC_ISNUMBER { $$ = "ISNUMBER"; } | T_FUNC_ISODD { $$ = "ISODD"; } | T_FUNC_ISPMT { $$ = "ISPMT"; } | T_FUNC_ISREF { $$ = "ISREF"; } | T_FUNC_ISTEXT { $$ = "ISTEXT"; } | T_FUNC_ISTHAIDIGIT { $$ = "ISTHAIDIGIT"; } | T_FUNC_KURT { $$ = "KURT"; } | T_FUNC_LARGE { $$ = "LARGE"; } | T_FUNC_LCM { $$ = "LCM"; } | T_FUNC_LEFT { $$ = "LEFT"; } | T_FUNC_LEFTB { $$ = "LEFTB"; } | T_FUNC_LEN { $$ = "LEN"; } | T_FUNC_LENB { $$ = "LENB"; } | T_FUNC_LINEST { $$ = "LINEST"; } | T_FUNC_LN { $$ = "LN"; } | T_FUNC_LOG { $$ = "LOG"; } | T_FUNC_LOG10 { $$ = "LOG10"; } | T_FUNC_LOGEST { $$ = "LOGEST"; } | T_FUNC_LOGINV { $$ = "LOGINV"; } | T_FUNC_LOGNORMDIST { $$ = "LOGNORMDIST"; } | T_FUNC_LOOKUP { $$ = "LOOKUP"; } | T_FUNC_LOWER { $$ = "LOWER"; } | T_FUNC_MATCH { $$ = "MATCH"; } | T_FUNC_MAX { $$ = "MAX"; } | T_FUNC_MAXA { $$ = "MAXA"; } | T_FUNC_MAXIFS { $$ = "MAXIFS"; } | T_FUNC_MDETERM { $$ = "MDETERM"; } | T_FUNC_MDURATION { $$ = "MDURATION"; } | T_FUNC_MEDIAN { $$ = "MEDIAN"; } | T_FUNC_MID { $$ = "MID"; } | T_FUNC_MIDB { $$ = "MIDB"; } | T_FUNC_MIN { $$ = "MIN"; } | T_FUNC_MINA { $$ = "MINA"; } | T_FUNC_MINIFS { $$ = "MINIFS"; } | T_FUNC_MINUTE { $$ = "MINUTE"; } | T_FUNC_MINVERSE { $$ = "MINVERSE"; } | T_FUNC_MIRR { $$ = "MIRR"; } | T_FUNC_MMULT { $$ = "MMULT"; } | T_FUNC_MOD { $$ = "MOD"; } | T_FUNC_MODE { $$ = "MODE"; } | T_FUNC_MONTH { $$ = "MONTH"; } | T_FUNC_MROUND { $$ = "MROUND"; } | T_FUNC_MULTINOMIAL { $$ = "MULTINOMIAL"; } | T_FUNC_N { $$ = "N"; } | T_FUNC_NA { $$ = "NA"; } | T_FUNC_NEGBINOMDIST { $$ = "NEGBINOMDIST"; } | T_FUNC_NETWORKDAYS { $$ = "NETWORKDAYS"; } | T_FUNC_NOMINAL { $$ = "NOMINAL"; } | T_FUNC_NORMDIST { $$ = "NORMDIST"; } | T_FUNC_NORMINV { $$ = "NORMINV"; } | T_FUNC_NORMSDIST { $$ = "NORMSDIST"; } | T_FUNC_NORMSINV { $$ = "NORMSINV"; } | T_FUNC_NOT { $$ = "NOT"; } | T_FUNC_NOW { $$ = "NOW"; } | T_FUNC_NPER { $$ = "NPER"; } | T_FUNC_NPV { $$ = "NPV"; } | T_FUNC_NUMBERSTRING { $$ = "NUMBERSTRING"; } | T_FUNC_OCT2BIN { $$ = "OCT2BIN"; } | T_FUNC_OCT2DEC { $$ = "OCT2DEC"; } | T_FUNC_OCT2HEX { $$ = "OCT2HEX"; } | T_FUNC_ODD { $$ = "ODD"; } | T_FUNC_ODDFPRICE { $$ = "ODDFPRICE"; } | T_FUNC_ODDFYIELD { $$ = "ODDFYIELD"; } | T_FUNC_ODDLPRICE { $$ = "ODDLPRICE"; } | T_FUNC_ODDLYIELD { $$ = "ODDLYIELD"; } | T_FUNC_OFFSET { $$ = "OFFSET"; } | T_FUNC_OR { $$ = "OR"; } | T_FUNC_PEARSON { $$ = "PEARSON"; } | T_FUNC_PERCENTILE { $$ = "PERCENTILE"; } | T_FUNC_PERCENTRANK { $$ = "PERCENTRANK"; } | T_FUNC_PERMUT { $$ = "PERMUT"; } | T_FUNC_PHONETIC { $$ = "PHONETIC"; } | T_FUNC_PI { $$ = "PI"; } | T_FUNC_PMT { $$ = "PMT"; } | T_FUNC_POISSON { $$ = "POISSON"; } | T_FUNC_POWER { $$ = "POWER"; } | T_FUNC_PPMT { $$ = "PPMT"; } | T_FUNC_PRICE { $$ = "PRICE"; } | T_FUNC_PRICEDISC { $$ = "PRICEDISC"; } | T_FUNC_PRICEMAT { $$ = "PRICEMAT"; } | T_FUNC_PROB { $$ = "PROB"; } | T_FUNC_PRODUCT { $$ = "PRODUCT"; } | T_FUNC_PROPER { $$ = "PROPER"; } | T_FUNC_PV { $$ = "PV"; } | T_FUNC_QUARTILE { $$ = "QUARTILE"; } | T_FUNC_QUOTIENT { $$ = "QUOTIENT"; } | T_FUNC_RADIANS { $$ = "RADIANS"; } | T_FUNC_RAND { $$ = "RAND"; } | T_FUNC_RANDBETWEEN { $$ = "RANDBETWEEN"; } | T_FUNC_RANK { $$ = "RANK"; } | T_FUNC_RATE { $$ = "RATE"; } | T_FUNC_RECEIVED { $$ = "RECEIVED"; } | T_FUNC_REPLACE { $$ = "REPLACE"; } | T_FUNC_REPLACEB { $$ = "REPLACEB"; } | T_FUNC_REPT { $$ = "REPT"; } | T_FUNC_RIGHT { $$ = "RIGHT"; } | T_FUNC_RIGHTB { $$ = "RIGHTB"; } | T_FUNC_ROMAN { $$ = "ROMAN"; } | T_FUNC_ROUND { $$ = "ROUND"; } | T_FUNC_ROUNDBAHTDOWN { $$ = "ROUNDBAHTDOWN"; } | T_FUNC_ROUNDBAHTUP { $$ = "ROUNDBAHTUP"; } | T_FUNC_ROUNDDOWN { $$ = "ROUNDDOWN"; } | T_FUNC_ROUNDUP { $$ = "ROUNDUP"; } | T_FUNC_ROW { $$ = "ROW"; } | T_FUNC_ROWS { $$ = "ROWS"; } | T_FUNC_RSQ { $$ = "RSQ"; } | T_FUNC_RTD { $$ = "RTD"; } | T_FUNC_SEARCH { $$ = "SEARCH"; } | T_FUNC_SEARCHB { $$ = "SEARCHB"; } | T_FUNC_SECOND { $$ = "SECOND"; } | T_FUNC_SERIES { $$ = "SERIES"; } | T_FUNC_SERIESSUM { $$ = "SERIESSUM"; } | T_FUNC_SIGN { $$ = "SIGN"; } | T_FUNC_SIN { $$ = "SIN"; } | T_FUNC_SINH { $$ = "SINH"; } | T_FUNC_SKEW { $$ = "SKEW"; } | T_FUNC_SLN { $$ = "SLN"; } | T_FUNC_SLOPE { $$ = "SLOPE"; } | T_FUNC_SMALL { $$ = "SMALL"; } | T_FUNC_SQRT { $$ = "SQRT"; } | T_FUNC_SQRTPI { $$ = "SQRTPI"; } | T_FUNC_STANDARDIZE { $$ = "STANDARDIZE"; } | T_FUNC_STDEV { $$ = "STDEV"; } | T_FUNC_STDEVA { $$ = "STDEVA"; } | T_FUNC_STDEVP { $$ = "STDEVP"; } | T_FUNC_STDEVPA { $$ = "STDEVPA"; } | T_FUNC_STEYX { $$ = "STEYX"; } | T_FUNC_SUBSTITUTE { $$ = "SUBSTITUTE"; } | T_FUNC_SUBTOTAL { $$ = "SUBTOTAL"; } | T_FUNC_SUM { $$ = "SUM"; } | T_FUNC_SUMIF { $$ = "SUMIF"; } | T_FUNC_SUMIFS { $$ = "SUMIFS"; } | T_FUNC_SUMPRODUCT { $$ = "SUMPRODUCT"; } | T_FUNC_SUMSQ { $$ = "SUMSQ"; } | T_FUNC_SUMX2MY2 { $$ = "SUMX2MY2"; } | T_FUNC_SUMX2PY2 { $$ = "SUMX2PY2"; } | T_FUNC_SUMXMY2 { $$ = "SUMXMY2"; } | T_FUNC_SWITCH { $$ = "SWITCH"; } | T_FUNC_SYD { $$ = "SYD"; } | T_FUNC_T { $$ = "T"; } | T_FUNC_TAN { $$ = "TAN"; } | T_FUNC_TANH { $$ = "TANH"; } | T_FUNC_TBILLEQ { $$ = "TBILLEQ"; } | T_FUNC_TBILLPRICE { $$ = "TBILLPRICE"; } | T_FUNC_TBILLYIELD { $$ = "TBILLYIELD"; } | T_FUNC_TDIST { $$ = "TDIST"; } | T_FUNC_TEXT { $$ = "TEXT"; } | T_FUNC_TEXTJOIN { $$ = "TEXTJOIN"; } | T_FUNC_THAIDAYOFWEEK { $$ = "THAIDAYOFWEEK"; } | T_FUNC_THAIDIGIT { $$ = "THAIDIGIT"; } | T_FUNC_THAIMONTHOFYEAR { $$ = "THAIMONTHOFYEAR"; } | T_FUNC_THAINUMSOUND { $$ = "THAINUMSOUND"; } | T_FUNC_THAINUMSTRING { $$ = "THAINUMSTRING"; } | T_FUNC_THAISTRINGLENGTH { $$ = "THAISTRINGLENGTH"; } | T_FUNC_THAIYEAR { $$ = "THAIYEAR"; } | T_FUNC_TIME { $$ = "TIME"; } | T_FUNC_TIMEVALUE { $$ = "TIMEVALUE"; } | T_FUNC_TINV { $$ = "TINV"; } | T_FUNC_TODAY { $$ = "TODAY"; } | T_FUNC_TRANSPOSE { $$ = "TRANSPOSE"; } | T_FUNC_TREND { $$ = "TREND"; } | T_FUNC_TRIM { $$ = "TRIM"; } | T_FUNC_TRIMMEAN { $$ = "TRIMMEAN"; } | T_FUNC_TRUNC { $$ = "TRUNC"; } | T_FUNC_TTEST { $$ = "TTEST"; } | T_FUNC_TYPE { $$ = "TYPE"; } | T_FUNC_UPPER { $$ = "UPPER"; } | T_FUNC_USDOLLAR { $$ = "USDOLLAR"; } | T_FUNC_VALUE { $$ = "VALUE"; } | T_FUNC_VAR { $$ = "VAR"; } | T_FUNC_VARA { $$ = "VARA"; } | T_FUNC_VARP { $$ = "VARP"; } | T_FUNC_VARPA { $$ = "VARPA"; } | T_FUNC_VDB { $$ = "VDB"; } | T_FUNC_VLOOKUP { $$ = "VLOOKUP"; } | T_FUNC_WEEKDAY { $$ = "WEEKDAY"; } | T_FUNC_WEEKNUM { $$ = "WEEKNUM"; } | T_FUNC_WEIBULL { $$ = "WEIBULL"; } | T_FUNC_WORKDAY { $$ = "WORKDAY"; } | T_FUNC_XIRR { $$ = "XIRR"; } | T_FUNC_XNPV { $$ = "XNPV"; } | T_FUNC_YEAR { $$ = "YEAR"; } | T_FUNC_YEARFRAC { $$ = "YEARFRAC"; } | T_FUNC_YIELD { $$ = "YIELD"; } | T_FUNC_YIELDDISC { $$ = "YIELDDISC"; } | T_FUNC_YIELDMAT { $$ = "YIELDMAT"; } | T_FUNC_ZTEST { $$ = "ZTEST"; };
future_function_name: T_FUNC_AGGREGATE { $$ = "AGGREGATE"; } | T_FUNC_ACOT { $$ = "ACOT"; } | T_FUNC_ACOTH { $$ = "ACOTH"; } | T_FUNC_ARABIC { $$ = "ARABIC"; } | T_FUNC_BASE { $$ = "BASE"; } | T_FUNC_BETA_DIST { $$ = "BETA.DIST"; } | T_FUNC_BETA_INV { $$ = "BETA.INV"; } | T_FUNC_BINOM_DIST { $$ = "BINOM.DIST"; } | T_FUNC_BINOM_DIST_RANGE { $$ = "BINOM.DIST.RANGE"; } | T_FUNC_BINOM_INV { $$ = "BINOM.INV"; } | T_FUNC_BITAND { $$ = "BITAND"; } | T_FUNC_BITLSHIFT { $$ = "BITLSHIFT"; } | T_FUNC_BITOR { $$ = "BITOR"; } | T_FUNC_BITRSHIFT { $$ = "BITRSHIFT"; } | T_FUNC_BITXOR { $$ = "BITXOR"; } | T_FUNC_BYCOL { $$ = "BYCOL"; } | T_FUNC_BYROW { $$ = "BYROW"; } | T_FUNC_CEILING_MATH { $$ = "CEILING.MATH"; } | T_FUNC_CEILING_PRECISE { $$ = "CEILING.PRECISE"; } | T_FUNC_CHISQ_DIST { $$ = "CHISQ.DIST"; } | T_FUNC_CHISQ_DIST_RT { $$ = "CHISQ.DIST.RT"; } | T_FUNC_CHISQ_INV { $$ = "CHISQ.INV"; } | T_FUNC_CHISQ_INV_RT { $$ = "CHISQ.INV.RT"; } | T_FUNC_CHISQ_TEST { $$ = "CHISQ.TEST"; } | T_FUNC_CHOOSECOLS { $$ = "CHOOSECOLS"; } | T_FUNC_CHOOSEROWS { $$ = "CHOOSEROWS"; } | T_FUNC_COMBINA { $$ = "COMBINA"; } | T_FUNC_CONFIDENCE_NORM { $$ = "CONFIDENCE.NORM"; } | T_FUNC_CONFIDENCE_T { $$ = "CONFIDENCE.T"; } | T_FUNC_COT { $$ = "COT"; } | T_FUNC_COTH { $$ = "COTH"; } | T_FUNC_COVARIANCE_P { $$ = "COVARIANCE.P"; } | T_FUNC_COVARIANCE_S { $$ = "COVARIANCE.S"; } | T_FUNC_CSC { $$ = "CSC"; } | T_FUNC_CSCH { $$ = "CSCH"; } | T_FUNC_DAYS { $$ = "DAYS"; } | T_FUNC_DECIMAL { $$ = "DECIMAL"; } | T_FUNC_DROP { $$ = "DROP"; } | T_FUNC_ERF_PRECISE { $$ = "ERF.PRECISE"; } | T_FUNC_ERFC_PRECISE { $$ = "ERFC.PRECISE"; } | T_FUNC_EXPAND { $$ = "EXPAND"; } | T_FUNC_EXPON_DIST { $$ = "EXPON.DIST"; } | T_FUNC_F_DIST { $$ = "F.DIST"; } | T_FUNC_F_DIST_RT { $$ = "F.DIST.RT"; } | T_FUNC_F_INV { $$ = "F.INV"; } | T_FUNC_F_INV_RT { $$ = "F.INV.RT"; } | T_FUNC_F_TEST { $$ = "F.TEST"; } | T_FUNC_FIELDVALUE { $$ = "FIELDVALUE"; } | T_FUNC_FILTERXML { $$ = "FILTERXML"; } | T_FUNC_FLOOR_MATH { $$ = "FLOOR.MATH"; } | T_FUNC_FLOOR_PRECISE { $$ = "FLOOR.PRECISE"; } | T_FUNC_FORMULATEXT { $$ = "FORMULATEXT"; } | T_FUNC_GAMMA { $$ = "GAMMA"; } | T_FUNC_GAMMA_DIST { $$ = "GAMMA.DIST"; } | T_FUNC_GAMMA_INV { $$ = "GAMMA.INV"; } | T_FUNC_GAMMALN_PRECISE { $$ = "GAMMALN.PRECISE"; } | T_FUNC_GAUSS { $$ = "GAUSS"; } | T_FUNC_HSTACK { $$ = "HSTACK"; } | T_FUNC_HYPGEOM_DIST { $$ = "HYPGEOM.DIST"; } | T_FUNC_IFNA { $$ = "IFNA"; } | T_FUNC_IMCOSH { $$ = "IMCOSH"; } | T_FUNC_IMCOT { $$ = "IMCOT"; } | T_FUNC_IMCSC { $$ = "IMCSC"; } | T_FUNC_IMCSCH { $$ = "IMCSCH"; } | T_FUNC_IMSEC { $$ = "IMSEC"; } | T_FUNC_IMSECH { $$ = "IMSECH"; } | T_FUNC_IMSINH { $$ = "IMSINH"; } | T_FUNC_IMTAN { $$ = "IMTAN"; } | T_FUNC_ISFORMULA { $$ = "ISFORMULA"; } | T_FUNC_ISOMITTED { $$ = "ISOMITTED"; } | T_FUNC_ISOWEEKNUM { $$ = "ISOWEEKNUM"; } | T_FUNC_LAMBDA { $$ = "LAMBDA"; } | T_FUNC_LET { $$ = "LET"; } | T_FUNC_LOGNORM_DIST { $$ = "LOGNORM.DIST"; } | T_FUNC_LOGNORM_INV { $$ = "LOGNORM.INV"; } | T_FUNC_MAKEARRAY { $$ = "MAKEARRAY"; } | T_FUNC_MAP { $$ = "MAP"; } | T_FUNC_MODE_MULT { $$ = "MODE.MULT"; } | T_FUNC_MODE_SNGL { $$ = "MODE.SNGL"; } | T_FUNC_MUNIT { $$ = "MUNIT"; } | T_FUNC_NEGBINOM_DIST { $$ = "NEGBINOM.DIST"; } | T_FUNC_NORM_DIST { $$ = "NORM.DIST"; } | T_FUNC_NORM_INV { $$ = "NORM.INV"; } | T_FUNC_NORM_S_DIST { $$ = "NORM.S.DIST"; } | T_FUNC_NORM_S_INV { $$ = "NORM.S.INV"; } | T_FUNC_NUMBERVALUE { $$ = "NUMBERVALUE"; } | T_FUNC_PDURATION { $$ = "PDURATION"; } | T_FUNC_PERCENTILE_EXC { $$ = "PERCENTILE.EXC"; } | T_FUNC_PERCENTILE_INC { $$ = "PERCENTILE.INC"; } | T_FUNC_PERCENTRANK_EXC { $$ = "PERCENTRANK.EXC"; } | T_FUNC_PERCENTRANK_INC { $$ = "PERCENTRANK.INC"; } | T_FUNC_PERMUTATIONA { $$ = "PERMUTATIONA"; } | T_FUNC_PHI { $$ = "PHI"; } | T_FUNC_POISSON_DIST { $$ = "POISSON.DIST"; } | T_FUNC_PQSOURCE { $$ = "PQSOURCE"; } | T_FUNC_PYTHON_STR { $$ = "PYTHON.STR"; } | T_FUNC_PYTHON_TYPE { $$ = "PYTHON.TYPE"; } | T_FUNC_PYTHON_TYPENAME { $$ = "PYTHON.TYPENAME"; } | T_FUNC_QUARTILE_EXC { $$ = "QUARTILE.EXC"; } | T_FUNC_QUARTILE_INC { $$ = "QUARTILE.INC"; } | T_FUNC_QUERYSTRING { $$ = "QUERYSTRING"; } | T_FUNC_RANDARRAY { $$ = "RANDARRAY"; } | T_FUNC_RANK_AVG { $$ = "RANK.AVG"; } | T_FUNC_RANK_EQ { $$ = "RANK.EQ"; } | T_FUNC_REDUCE { $$ = "REDUCE"; } | T_FUNC_RRI { $$ = "RRI"; } | T_FUNC_SCAN { $$ = "SCAN"; } | T_FUNC_SEC { $$ = "SEC"; } | T_FUNC_SECH { $$ = "SECH"; } | T_FUNC_SEQUENCE { $$ = "SEQUENCE"; } | T_FUNC_SHEET { $$ = "SHEET"; } | T_FUNC_SHEETS { $$ = "SHEETS"; } | T_FUNC_SKEW_P { $$ = "SKEW.P"; } | T_FUNC_SORTBY { $$ = "SORTBY"; } | T_FUNC_STDEV_P { $$ = "STDEV.P"; } | T_FUNC_STDEV_S { $$ = "STDEV.S"; } | T_FUNC_T_DIST { $$ = "T.DIST"; } | T_FUNC_T_DIST_2T { $$ = "T.DIST.2T"; } | T_FUNC_T_DIST_RT { $$ = "T.DIST.RT"; } | T_FUNC_T_INV { $$ = "T.INV"; } | T_FUNC_T_INV_2T { $$ = "T.INV.2T"; } | T_FUNC_T_TEST { $$ = "T.TEST"; } | T_FUNC_TAKE { $$ = "TAKE"; } | T_FUNC_TEXTAFTER { $$ = "TEXTAFTER"; } | T_FUNC_TEXTBEFORE { $$ = "TEXTBEFORE"; } | T_FUNC_TEXTSPLIT { $$ = "TEXTSPLIT"; } | T_FUNC_TOCOL { $$ = "TOCOL"; } | T_FUNC_TOROW { $$ = "TOROW"; } | T_FUNC_UNICHAR { $$ = "UNICHAR"; } | T_FUNC_UNICODE { $$ = "UNICODE"; } | T_FUNC_UNIQUE { $$ = "UNIQUE"; } | T_FUNC_VAR_P { $$ = "VAR.P"; } | T_FUNC_VAR_S { $$ = "VAR.S"; } | T_FUNC_VSTACK { $$ = "VSTACK"; } | T_FUNC_WEBSERVICE { $$ = "WEBSERVICE"; } | T_FUNC_WEIBULL_DIST { $$ = "WEIBULL.DIST"; } | T_FUNC_WRAPCOLS { $$ = "WRAPCOLS"; } | T_FUNC_WRAPROWS { $$ = "WRAPROWS"; } | T_FUNC_XLOOKUP { $$ = "XLOOKUP"; } | T_FUNC_XOR { $$ = "XOR"; } | T_FUNC_Z_TEST { $$ = "Z.TEST"; } | T_FUNC_ECMA_CEILING { $$ = "ECMA.CEILING"; } | T_FUNC_ISO_CEILING { $$ = "ISO.CEILING"; } | T_FUNC_NETWORKDAYS_INTL { $$ = "NETWORKDAYS.INTL"; } | T_FUNC_WORKDAY_INTL { $$ = "WORKDAY.INTL"; } | T_FUNC_FORECAST_ETS { $$ = "FORECAST.ETS"; } | T_FUNC_FORECAST_ETS_CONFINT { $$ = "FORECAST.ETS.CONFINT"; } | T_FUNC_FORECAST_ETS_SEASONALITY { $$ = "FORECAST.ETS.SEASONALITY"; } | T_FUNC_FORECAST_LINEAR { $$ = "FORECAST.LINEAR"; } | T_FUNC_FORECAST_ETS_STAT { $$ = "FORECAST.ETS.STAT"; };
worksheet_function_name: T_FUNC_FILTER { $$ = "FILTER"; } | T_FUNC_PY { $$ = "PY"; } | T_FUNC_SORT { $$ = "SORT"; };
macro_function_name: T_FUNC_ABSREF { $$ = "ABSREF"; } | T_FUNC_ACTIVE_CELL { $$ = "ACTIVE.CELL"; } | T_FUNC_CALL { $$ = "CALL"; } | T_FUNC_CALLER { $$ = "CALLER"; } | T_FUNC_EVALUATE { $$ = "EVALUATE"; } | T_FUNC_GET_DOCUMENT { $$ = "GET.DOCUMENT"; } | T_FUNC_INPUT { $$ = "INPUT"; } | T_FUNC_LAST_ERROR { $$ = "LAST.ERROR"; } | T_FUNC_SCENARIO_GET { $$ = "SCENARIO.GET"; } | T_FUNC_SELECTION { $$ = "SELECTION"; } | T_FUNC_TEXTREF { $$ = "TEXTREF"; } | T_FUNC_VIEW_GET { $$ = "VIEW.GET"; } | T_FUNC_ADD_BAR { $$ = "ADD.BAR"; } | T_FUNC_ADD_COMMAND { $$ = "ADD.COMMAND"; } | T_FUNC_ADD_MENU { $$ = "ADD.MENU"; } | T_FUNC_ADD_TOOLBAR { $$ = "ADD.TOOLBAR"; } | T_FUNC_APP_TITLE { $$ = "APP.TITLE"; } | T_FUNC_ARGUMENT { $$ = "ARGUMENT"; } | T_FUNC_BREAK { $$ = "BREAK"; } | T_FUNC_CANCEL_KEY { $$ = "CANCEL.KEY"; } | T_FUNC_CHECK_COMMAND { $$ = "CHECK.COMMAND"; } | T_FUNC_CREATE_OBJECT { $$ = "CREATE.OBJECT"; } | T_FUNC_CUSTOM_REPEAT { $$ = "CUSTOM.REPEAT"; } | T_FUNC_CUSTOM_UNDO { $$ = "CUSTOM.UNDO"; } | T_FUNC_DELETE_BAR { $$ = "DELETE.BAR"; } | T_FUNC_DELETE_COMMAND { $$ = "DELETE.COMMAND"; } | T_FUNC_DELETE_MENU { $$ = "DELETE.MENU"; } | T_FUNC_DELETE_TOOLBAR { $$ = "DELETE.TOOLBAR"; } | T_FUNC_DEREF { $$ = "DEREF"; } | T_FUNC_DIALOG_BOX { $$ = "DIALOG.BOX"; } | T_FUNC_DIRECTORY { $$ = "DIRECTORY"; } | T_FUNC_DOCUMENTS { $$ = "DOCUMENTS"; } | T_FUNC_ECHO { $$ = "ECHO"; } | T_FUNC_ELSE { $$ = "ELSE"; } | T_FUNC_ELSE_IF { $$ = "ELSE.IF"; } | T_FUNC_ENABLE_COMMAND { $$ = "ENABLE.COMMAND"; } | T_FUNC_ENABLE_TOOL { $$ = "ENABLE.TOOL"; } | T_FUNC_END_IF { $$ = "END.IF"; } | T_FUNC_ERROR { $$ = "ERROR"; } | T_FUNC_EXEC { $$ = "EXEC"; } | T_FUNC_EXECUTE { $$ = "EXECUTE"; } | T_FUNC_FCLOSE { $$ = "FCLOSE"; } | T_FUNC_FILES { $$ = "FILES"; } | T_FUNC_FOPEN { $$ = "FOPEN"; } | T_FUNC_FOR { $$ = "FOR"; } | T_FUNC_FOR_CELL { $$ = "FOR.CELL"; } | T_FUNC_FORMULA_CONVERT { $$ = "FORMULA.CONVERT"; } | T_FUNC_FPOS { $$ = "FPOS"; } | T_FUNC_FREAD { $$ = "FREAD"; } | T_FUNC_FREADLN { $$ = "FREADLN"; } | T_FUNC_FSIZE { $$ = "FSIZE"; } | T_FUNC_FWRITE { $$ = "FWRITE"; } | T_FUNC_FWRITELN { $$ = "FWRITELN"; } | T_FUNC_GET_BAR { $$ = "GET.BAR"; } | T_FUNC_GET_CELL { $$ = "GET.CELL"; } | T_FUNC_GET_CHART_ITEM { $$ = "GET.CHART.ITEM"; } | T_FUNC_GET_DEF { $$ = "GET.DEF"; } | T_FUNC_GET_FORMULA { $$ = "GET.FORMULA"; } | T_FUNC_GET_LINK_INFO { $$ = "GET.LINK.INFO"; } | T_FUNC_GET_MOVIE { $$ = "GET.MOVIE"; } | T_FUNC_GET_NAME { $$ = "GET.NAME"; } | T_FUNC_GET_NOTE { $$ = "GET.NOTE"; } | T_FUNC_GET_OBJECT { $$ = "GET.OBJECT"; } | T_FUNC_GET_TOOL { $$ = "GET.TOOL"; } | T_FUNC_GET_TOOLBAR { $$ = "GET.TOOLBAR"; } | T_FUNC_GET_WINDOW { $$ = "GET.WINDOW"; } | T_FUNC_GET_WORKBOOK { $$ = "GET.WORKBOOK"; } | T_FUNC_GET_WORKSPACE { $$ = "GET.WORKSPACE"; } | T_FUNC_GOTO { $$ = "GOTO"; } | T_FUNC_GROUP { $$ = "GROUP"; } | T_FUNC_HALT { $$ = "HALT"; } | T_FUNC_HELP { $$ = "HELP"; } | T_FUNC_INITIATE { $$ = "INITIATE"; } | T_FUNC_LINKS { $$ = "LINKS"; } | T_FUNC_MOVIE_COMMAND { $$ = "MOVIE.COMMAND"; } | T_FUNC_NAMES { $$ = "NAMES"; } | T_FUNC_NEXT { $$ = "NEXT"; } | T_FUNC_NOTE { $$ = "NOTE"; } | T_FUNC_OPEN_DIALOG { $$ = "OPEN.DIALOG"; } | T_FUNC_OPTIONS_LISTS_GET { $$ = "OPTIONS.LISTS.GET"; } | T_FUNC_PAUSE { $$ = "PAUSE"; } | T_FUNC_POKE { $$ = "POKE"; } | T_FUNC_PRESS_TOOL { $$ = "PRESS.TOOL"; } | T_FUNC_REFTEXT { $$ = "REFTEXT"; } | T_FUNC_REGISTER { $$ = "REGISTER"; } | T_FUNC_REGISTER_ID { $$ = "REGISTER.ID"; } | T_FUNC_RELREF { $$ = "RELREF"; } | T_FUNC_RENAME_COMMAND { $$ = "RENAME.COMMAND"; } | T_FUNC_REQUEST { $$ = "REQUEST"; } | T_FUNC_RESET_TOOLBAR { $$ = "RESET.TOOLBAR"; } | T_FUNC_RESTART { $$ = "RESTART"; } | T_FUNC_RESULT { $$ = "RESULT"; } | T_FUNC_RESUME { $$ = "RESUME"; } | T_FUNC_RETURN { $$ = "RETURN"; } | T_FUNC_SAVE_DIALOG { $$ = "SAVE.DIALOG"; } | T_FUNC_SAVE_TOOLBAR { $$ = "SAVE.TOOLBAR"; } | T_FUNC_SET_NAME { $$ = "SET.NAME"; } | T_FUNC_SET_VALUE { $$ = "SET.VALUE"; } | T_FUNC_SHOW_BAR { $$ = "SHOW.BAR"; } | T_FUNC_SPELLING_CHECK { $$ = "SPELLING.CHECK"; } | T_FUNC_STEP { $$ = "STEP"; } | T_FUNC_TERMINATE { $$ = "TERMINATE"; } | T_FUNC_TEXT_BOX { $$ = "TEXT.BOX"; } | T_FUNC_UNREGISTER { $$ = "UNREGISTER"; } | T_FUNC_VOLATILE { $$ = "VOLATILE"; } | T_FUNC_WHILE { $$ = "WHILE"; } | T_FUNC_WINDOW_TITLE { $$ = "WINDOW.TITLE"; } | T_FUNC_WINDOWS { $$ = "WINDOWS"; };
command_function_name: T_FUNC_A1_R1C1 { $$ = "A1.R1C1"; } | T_FUNC_ACTIVATE { $$ = "ACTIVATE"; } | T_FUNC_ACTIVATE_NEXT { $$ = "ACTIVATE.NEXT"; } | T_FUNC_ACTIVATE_NOTES { $$ = "ACTIVATE.NOTES"; } | T_FUNC_ACTIVATE_PREV { $$ = "ACTIVATE.PREV"; } | T_FUNC_ACTIVE_CELL_FONT { $$ = "ACTIVE.CELL.FONT"; } | T_FUNC_ADD_ARROW { $$ = "ADD.ARROW"; } | T_FUNC_ADD_CHART_AUTOFORMAT { $$ = "ADD.CHART.AUTOFORMAT"; } | T_FUNC_ADD_LIST_ITEM { $$ = "ADD.LIST.ITEM"; } | T_FUNC_ADD_OVERLAY { $$ = "ADD.OVERLAY"; } | T_FUNC_ADD_PRINT_AREA { $$ = "ADD.PRINT.AREA"; } | T_FUNC_ADD_TOOL { $$ = "ADD.TOOL"; } | T_FUNC_ADDIN_MANAGER { $$ = "ADDIN.MANAGER"; } | T_FUNC_ALERT { $$ = "ALERT"; } | T_FUNC_ALIGNMENT { $$ = "ALIGNMENT"; } | T_FUNC_APP_ACTIVATE { $$ = "APP.ACTIVATE"; } | T_FUNC_APP_ACTIVATE_MICROSOFT { $$ = "APP.ACTIVATE.MICROSOFT"; } | T_FUNC_APP_MAXIMIZE { $$ = "APP.MAXIMIZE"; } | T_FUNC_APP_MINIMIZE { $$ = "APP.MINIMIZE"; } | T_FUNC_APP_MOVE { $$ = "APP.MOVE"; } | T_FUNC_APP_RESTORE { $$ = "APP.RESTORE"; } | T_FUNC_APP_SIZE { $$ = "APP.SIZE"; } | T_FUNC_APPLY_NAMES { $$ = "APPLY.NAMES"; } | T_FUNC_APPLY_STYLE { $$ = "APPLY.STYLE"; } | T_FUNC_ARRANGE_ALL { $$ = "ARRANGE.ALL"; } | T_FUNC_ASSIGN_TO_OBJECT { $$ = "ASSIGN.TO.OBJECT"; } | T_FUNC_ASSIGN_TO_TOOL { $$ = "ASSIGN.TO.TOOL"; } | T_FUNC_ATTACH_TEXT { $$ = "ATTACH.TEXT"; } | T_FUNC_ATTACH_TOOLBARS { $$ = "ATTACH.TOOLBARS"; } | T_FUNC_ATTRIBUTES { $$ = "ATTRIBUTES"; } | T_FUNC_AUTO_OUTLINE { $$ = "AUTO.OUTLINE"; } | T_FUNC_AUTOCORRECT { $$ = "AUTOCORRECT"; } | T_FUNC_AXES { $$ = "AXES"; } | T_FUNC_BEEP { $$ = "BEEP"; } | T_FUNC_BORDER { $$ = "BORDER"; } | T_FUNC_BRING_TO_FRONT { $$ = "BRING.TO.FRONT"; } | T_FUNC_CALCULATE_DOCUMENT { $$ = "CALCULATE.DOCUMENT"; } | T_FUNC_CALCULATE_NOW { $$ = "CALCULATE.NOW"; } | T_FUNC_CALCULATION { $$ = "CALCULATION"; } | T_FUNC_CANCEL_COPY { $$ = "CANCEL.COPY"; } | T_FUNC_CELL_PROTECTION { $$ = "CELL.PROTECTION"; } | T_FUNC_CHANGE_LINK { $$ = "CHANGE.LINK"; } | T_FUNC_CHART_ADD_DATA { $$ = "CHART.ADD.DATA"; } | T_FUNC_CHART_TREND { $$ = "CHART.TREND"; } | T_FUNC_CHART_WIZARD { $$ = "CHART.WIZARD"; } | T_FUNC_CHECKBOX_PROPERTIES { $$ = "CHECKBOX.PROPERTIES"; } | T_FUNC_CLEAR { $$ = "CLEAR"; } | T_FUNC_CLEAR_OUTLINE { $$ = "CLEAR.OUTLINE"; } | T_FUNC_CLEAR_PRINT_AREA { $$ = "CLEAR.PRINT.AREA"; } | T_FUNC_CLEAR_ROUTING_SLIP { $$ = "CLEAR.ROUTING.SLIP"; } | T_FUNC_CLOSE { $$ = "CLOSE"; } | T_FUNC_CLOSE_ALL { $$ = "CLOSE.ALL"; } | T_FUNC_COLOR_PALETTE { $$ = "COLOR.PALETTE"; } | T_FUNC_COLUMN_WIDTH { $$ = "COLUMN.WIDTH"; } | T_FUNC_COMBINATION { $$ = "COMBINATION"; } | T_FUNC_CONSOLIDATE { $$ = "CONSOLIDATE"; } | T_FUNC_CONSTRAIN_NUMERIC { $$ = "CONSTRAIN.NUMERIC"; } | T_FUNC_COPY { $$ = "COPY"; } | T_FUNC_COPY_CHART { $$ = "COPY.CHART"; } | T_FUNC_COPY_PICTURE { $$ = "COPY.PICTURE"; } | T_FUNC_COPY_TOOL { $$ = "COPY.TOOL"; } | T_FUNC_CREATE_NAMES { $$ = "CREATE.NAMES"; } | T_FUNC_CREATE_PUBLISHER { $$ = "CREATE.PUBLISHER"; } | T_FUNC_CUSTOMIZE_TOOLBAR { $$ = "CUSTOMIZE.TOOLBAR"; } | T_FUNC_CUT { $$ = "CUT"; } | T_FUNC_DATA_DELETE { $$ = "DATA.DELETE"; } | T_FUNC_DATA_FIND { $$ = "DATA.FIND"; } | T_FUNC_DATA_FIND_NEXT { $$ = "DATA.FIND.NEXT"; } | T_FUNC_DATA_FIND_PREV { $$ = "DATA.FIND.PREV"; } | T_FUNC_DATA_FORM { $$ = "DATA.FORM"; } | T_FUNC_DATA_LABEL { $$ = "DATA.LABEL"; } | T_FUNC_DATA_SERIES { $$ = "DATA.SERIES"; } | T_FUNC_DEFINE_NAME { $$ = "DEFINE.NAME"; } | T_FUNC_DEFINE_STYLE { $$ = "DEFINE.STYLE"; } | T_FUNC_DELETE_ARROW { $$ = "DELETE.ARROW"; } | T_FUNC_DELETE_CHART_AUTOFORMAT { $$ = "DELETE.CHART.AUTOFORMAT"; } | T_FUNC_DELETE_FORMAT { $$ = "DELETE.FORMAT"; } | T_FUNC_DELETE_NAME { $$ = "DELETE.NAME"; } | T_FUNC_DELETE_NOTE { $$ = "DELETE.NOTE"; } | T_FUNC_DELETE_OVERLAY { $$ = "DELETE.OVERLAY"; } | T_FUNC_DELETE_STYLE { $$ = "DELETE.STYLE"; } | T_FUNC_DELETE_TOOL { $$ = "DELETE.TOOL"; } | T_FUNC_DEMOTE { $$ = "DEMOTE"; } | T_FUNC_DISABLE_INPUT { $$ = "DISABLE.INPUT"; } | T_FUNC_DISPLAY { $$ = "DISPLAY"; } | T_FUNC_DUPLICATE { $$ = "DUPLICATE"; } | T_FUNC_EDIT_COLOR { $$ = "EDIT.COLOR"; } | T_FUNC_EDIT_DELETE { $$ = "EDIT.DELETE"; } | T_FUNC_EDIT_OBJECT { $$ = "EDIT.OBJECT"; } | T_FUNC_EDIT_REPEAT { $$ = "EDIT.REPEAT"; } | T_FUNC_EDIT_SERIES { $$ = "EDIT.SERIES"; } | T_FUNC_EDIT_TOOL { $$ = "EDIT.TOOL"; } | T_FUNC_EDITBOX_PROPERTIES { $$ = "EDITBOX.PROPERTIES"; } | T_FUNC_EDITION_OPTIONS { $$ = "EDITION.OPTIONS"; } | T_FUNC_ENABLE_OBJECT { $$ = "ENABLE.OBJECT"; } | T_FUNC_ENABLE_TIPWIZARD { $$ = "ENABLE.TIPWIZARD"; } | T_FUNC_ENTER_DATA { $$ = "ENTER.DATA"; } | T_FUNC_ERRORBAR_X { $$ = "ERRORBAR.X"; } | T_FUNC_ERRORBAR_Y { $$ = "ERRORBAR.Y"; } | T_FUNC_EXTEND_POLYGON { $$ = "EXTEND.POLYGON"; } | T_FUNC_EXTRACT { $$ = "EXTRACT"; } | T_FUNC_FILE_CLOSE { $$ = "FILE.CLOSE"; } | T_FUNC_FILE_DELETE { $$ = "FILE.DELETE"; } | T_FUNC_FILL_AUTO { $$ = "FILL.AUTO"; } | T_FUNC_FILL_DOWN { $$ = "FILL.DOWN"; } | T_FUNC_FILL_GROUP { $$ = "FILL.GROUP"; } | T_FUNC_FILL_LEFT { $$ = "FILL.LEFT"; } | T_FUNC_FILL_RIGHT { $$ = "FILL.RIGHT"; } | T_FUNC_FILL_UP { $$ = "FILL.UP"; } | T_FUNC_FILTER_ADVANCED { $$ = "FILTER.ADVANCED"; } | T_FUNC_FILTER_SHOW_ALL { $$ = "FILTER.SHOW.ALL"; } | T_FUNC_FIND_FILE { $$ = "FIND.FILE"; } | T_FUNC_FONT { $$ = "FONT"; } | T_FUNC_FONT_PROPERTIES { $$ = "FONT.PROPERTIES"; } | T_FUNC_FORMAT_AUTO { $$ = "FORMAT.AUTO"; } | T_FUNC_FORMAT_CHART { $$ = "FORMAT.CHART"; } | T_FUNC_FORMAT_CHARTTYPE { $$ = "FORMAT.CHARTTYPE"; } | T_FUNC_FORMAT_FONT { $$ = "FORMAT.FONT"; } | T_FUNC_FORMAT_LEGEND { $$ = "FORMAT.LEGEND"; } | T_FUNC_FORMAT_MAIN { $$ = "FORMAT.MAIN"; } | T_FUNC_FORMAT_MOVE { $$ = "FORMAT.MOVE"; } | T_FUNC_FORMAT_NUMBER { $$ = "FORMAT.NUMBER"; } | T_FUNC_FORMAT_OVERLAY { $$ = "FORMAT.OVERLAY"; } | T_FUNC_FORMAT_SHAPE { $$ = "FORMAT.SHAPE"; } | T_FUNC_FORMAT_SIZE { $$ = "FORMAT.SIZE"; } | T_FUNC_FORMAT_TEXT { $$ = "FORMAT.TEXT"; } | T_FUNC_FORMULA { $$ = "FORMULA"; } | T_FUNC_FORMULA_ARRAY { $$ = "FORMULA.ARRAY"; } | T_FUNC_FORMULA_FILL { $$ = "FORMULA.FILL"; } | T_FUNC_FORMULA_FIND { $$ = "FORMULA.FIND"; } | T_FUNC_FORMULA_FIND_NEXT { $$ = "FORMULA.FIND.NEXT"; } | T_FUNC_FORMULA_FIND_PREV { $$ = "FORMULA.FIND.PREV"; } | T_FUNC_FORMULA_GOTO { $$ = "FORMULA.GOTO"; } | T_FUNC_FORMULA_REPLACE { $$ = "FORMULA.REPLACE"; } | T_FUNC_FREEZE_PANES { $$ = "FREEZE.PANES"; } | T_FUNC_FULL { $$ = "FULL"; } | T_FUNC_FULL_SCREEN { $$ = "FULL.SCREEN"; } | T_FUNC_FUNCTION_WIZARD { $$ = "FUNCTION.WIZARD"; } | T_FUNC_GALLERY_3D_AREA { $$ = "GALLERY.3D.AREA"; } | T_FUNC_GALLERY_3D_BAR { $$ = "GALLERY.3D.BAR"; } | T_FUNC_GALLERY_3D_COLUMN { $$ = "GALLERY.3D.COLUMN"; } | T_FUNC_GALLERY_3D_LINE { $$ = "GALLERY.3D.LINE"; } | T_FUNC_GALLERY_3D_PIE { $$ = "GALLERY.3D.PIE"; } | T_FUNC_GALLERY_3D_SURFACE { $$ = "GALLERY.3D.SURFACE"; } | T_FUNC_GALLERY_AREA { $$ = "GALLERY.AREA"; } | T_FUNC_GALLERY_BAR { $$ = "GALLERY.BAR"; } | T_FUNC_GALLERY_COLUMN { $$ = "GALLERY.COLUMN"; } | T_FUNC_GALLERY_CUSTOM { $$ = "GALLERY.CUSTOM"; } | T_FUNC_GALLERY_DOUGHNUT { $$ = "GALLERY.DOUGHNUT"; } | T_FUNC_GALLERY_LINE { $$ = "GALLERY.LINE"; } | T_FUNC_GALLERY_PIE { $$ = "GALLERY.PIE"; } | T_FUNC_GALLERY_RADAR { $$ = "GALLERY.RADAR"; } | T_FUNC_GALLERY_SCATTER { $$ = "GALLERY.SCATTER"; } | T_FUNC_GOAL_SEEK { $$ = "GOAL.SEEK"; } | T_FUNC_GRIDLINES { $$ = "GRIDLINES"; } | T_FUNC_HIDE { $$ = "HIDE"; } | T_FUNC_HIDE_DIALOG { $$ = "HIDE.DIALOG"; } | T_FUNC_HIDE_OBJECT { $$ = "HIDE.OBJECT"; } | T_FUNC_HIDEALL_INKANNOTS { $$ = "HIDEALL.INKANNOTS"; } | T_FUNC_HIDEALL_NOTES { $$ = "HIDEALL.NOTES"; } | T_FUNC_HIDECURR_NOTE { $$ = "HIDECURR.NOTE"; } | T_FUNC_HLINE { $$ = "HLINE"; } | T_FUNC_HPAGE { $$ = "HPAGE"; } | T_FUNC_HSCROLL { $$ = "HSCROLL"; } | T_FUNC_INSERT { $$ = "INSERT"; } | T_FUNC_INSERT_MAP_OBJECT { $$ = "INSERT.MAP.OBJECT"; } | T_FUNC_INSERT_OBJECT { $$ = "INSERT.OBJECT"; } | T_FUNC_INSERT_PICTURE { $$ = "INSERT.PICTURE"; } | T_FUNC_INSERT_TITLE { $$ = "INSERT.TITLE"; } | T_FUNC_INSERTDATATABLE { $$ = "INSERTDATATABLE"; } | T_FUNC_JUSTIFY { $$ = "JUSTIFY"; } | T_FUNC_LABEL_PROPERTIES { $$ = "LABEL.PROPERTIES"; } | T_FUNC_LAYOUT { $$ = "LAYOUT"; } | T_FUNC_LEGEND { $$ = "LEGEND"; } | T_FUNC_LINE_PRINT { $$ = "LINE.PRINT"; } | T_FUNC_LINK_COMBO { $$ = "LINK.COMBO"; } | T_FUNC_LINK_FORMAT { $$ = "LINK.FORMAT"; } | T_FUNC_LIST_NAMES { $$ = "LIST.NAMES"; } | T_FUNC_LISTBOX_PROPERTIES { $$ = "LISTBOX.PROPERTIES"; } | T_FUNC_MACRO_OPTIONS { $$ = "MACRO.OPTIONS"; } | T_FUNC_MAIL_ADD_MAILER { $$ = "MAIL.ADD.MAILER"; } | T_FUNC_MAIL_DELETE_MAILER { $$ = "MAIL.DELETE.MAILER"; } | T_FUNC_MAIL_EDIT_MAILER { $$ = "MAIL.EDIT.MAILER"; } | T_FUNC_MAIL_FORWARD { $$ = "MAIL.FORWARD"; } | T_FUNC_MAIL_LOGOFF { $$ = "MAIL.LOGOFF"; } | T_FUNC_MAIL_LOGON { $$ = "MAIL.LOGON"; } | T_FUNC_MAIL_NEXT_LETTER { $$ = "MAIL.NEXT.LETTER"; } | T_FUNC_MAIL_REPLY { $$ = "MAIL.REPLY"; } | T_FUNC_MAIL_REPLY_ALL { $$ = "MAIL.REPLY.ALL"; } | T_FUNC_MAIL_SEND_MAILER { $$ = "MAIL.SEND.MAILER"; } | T_FUNC_MAIN_CHART { $$ = "MAIN.CHART"; } | T_FUNC_MAIN_CHART_TYPE { $$ = "MAIN.CHART.TYPE"; } | T_FUNC_MENU_EDITOR { $$ = "MENU.EDITOR"; } | T_FUNC_MERGE_STYLES { $$ = "MERGE.STYLES"; } | T_FUNC_MESSAGE { $$ = "MESSAGE"; } | T_FUNC_MOVE_BRK { $$ = "MOVE.BRK"; } | T_FUNC_MOVE_TOOL { $$ = "MOVE.TOOL"; } | T_FUNC_NEW { $$ = "NEW"; } | T_FUNC_NEW_WINDOW { $$ = "NEW.WINDOW"; } | T_FUNC_NEWWEBQUERY { $$ = "NEWWEBQUERY"; } | T_FUNC_NORMAL { $$ = "NORMAL"; } | T_FUNC_OBJECT_PROPERTIES { $$ = "OBJECT.PROPERTIES"; } | T_FUNC_OBJECT_PROTECTION { $$ = "OBJECT.PROTECTION"; } | T_FUNC_ON_DATA { $$ = "ON.DATA"; } | T_FUNC_ON_DOUBLECLICK { $$ = "ON.DOUBLECLICK"; } | T_FUNC_ON_ENTRY { $$ = "ON.ENTRY"; } | T_FUNC_ON_KEY { $$ = "ON.KEY"; } | T_FUNC_ON_RECALC { $$ = "ON.RECALC"; } | T_FUNC_ON_SHEET { $$ = "ON.SHEET"; } | T_FUNC_ON_TIME { $$ = "ON.TIME"; } | T_FUNC_ON_WINDOW { $$ = "ON.WINDOW"; } | T_FUNC_OPEN { $$ = "OPEN"; } | T_FUNC_OPEN_LINKS { $$ = "OPEN.LINKS"; } | T_FUNC_OPEN_MAIL { $$ = "OPEN.MAIL"; } | T_FUNC_OPEN_TEXT { $$ = "OPEN.TEXT"; } | T_FUNC_OPTIONS_CALCULATION { $$ = "OPTIONS.CALCULATION"; } | T_FUNC_OPTIONS_CHART { $$ = "OPTIONS.CHART"; } | T_FUNC_OPTIONS_EDIT { $$ = "OPTIONS.EDIT"; } | T_FUNC_OPTIONS_GENERAL { $$ = "OPTIONS.GENERAL"; } | T_FUNC_OPTIONS_LISTS_ADD { $$ = "OPTIONS.LISTS.ADD"; } | T_FUNC_OPTIONS_LISTS_DELETE { $$ = "OPTIONS.LISTS.DELETE"; } | T_FUNC_OPTIONS_ME { $$ = "OPTIONS.ME"; } | T_FUNC_OPTIONS_MENONO { $$ = "OPTIONS.MENONO"; } | T_FUNC_OPTIONS_SAVE { $$ = "OPTIONS.SAVE"; } | T_FUNC_OPTIONS_SPELL { $$ = "OPTIONS.SPELL"; } | T_FUNC_OPTIONS_TRANSITION { $$ = "OPTIONS.TRANSITION"; } | T_FUNC_OPTIONS_VIEW { $$ = "OPTIONS.VIEW"; } | T_FUNC_OUTLINE { $$ = "OUTLINE"; } | T_FUNC_OVERLAY { $$ = "OVERLAY"; } | T_FUNC_OVERLAY_CHART_TYPE { $$ = "OVERLAY.CHART.TYPE"; } | T_FUNC_PAGE_SETUP { $$ = "PAGE.SETUP"; } | T_FUNC_PARSE { $$ = "PARSE"; } | T_FUNC_PASTE { $$ = "PASTE"; } | T_FUNC_PASTE_LINK { $$ = "PASTE.LINK"; } | T_FUNC_PASTE_PICTURE { $$ = "PASTE.PICTURE"; } | T_FUNC_PASTE_PICTURE_LINK { $$ = "PASTE.PICTURE.LINK"; } | T_FUNC_PASTE_SPECIAL { $$ = "PASTE.SPECIAL"; } | T_FUNC_PASTE_TOOL { $$ = "PASTE.TOOL"; } | T_FUNC_PATTERNS { $$ = "PATTERNS"; } | T_FUNC_PICKLIST { $$ = "PICKLIST"; } | T_FUNC_PIVOT_ADD_FIELDS { $$ = "PIVOT.ADD.FIELDS"; } | T_FUNC_PIVOT_FIELD { $$ = "PIVOT.FIELD"; } | T_FUNC_PIVOT_FIELD_GROUP { $$ = "PIVOT.FIELD.GROUP"; } | T_FUNC_PIVOT_FIELD_PROPERTIES { $$ = "PIVOT.FIELD.PROPERTIES"; } | T_FUNC_PIVOT_FIELD_UNGROUP { $$ = "PIVOT.FIELD.UNGROUP"; } | T_FUNC_PIVOT_ITEM { $$ = "PIVOT.ITEM"; } | T_FUNC_PIVOT_ITEM_PROPERTIES { $$ = "PIVOT.ITEM.PROPERTIES"; } | T_FUNC_PIVOT_REFRESH { $$ = "PIVOT.REFRESH"; } | T_FUNC_PIVOT_SHOW_PAGES { $$ = "PIVOT.SHOW.PAGES"; } | T_FUNC_PIVOT_TABLE_CHART { $$ = "PIVOT.TABLE.CHART"; } | T_FUNC_PIVOT_TABLE_WIZARD { $$ = "PIVOT.TABLE.WIZARD"; } | T_FUNC_POST_DOCUMENT { $$ = "POST.DOCUMENT"; } | T_FUNC_PRECISION { $$ = "PRECISION"; } | T_FUNC_PREFERRED { $$ = "PREFERRED"; } | T_FUNC_PRINT { $$ = "PRINT"; } | T_FUNC_PRINT_PREVIEW { $$ = "PRINT.PREVIEW"; } | T_FUNC_PRINTER_SETUP { $$ = "PRINTER.SETUP"; } | T_FUNC_PROMOTE { $$ = "PROMOTE"; } | T_FUNC_PROTECT_DOCUMENT { $$ = "PROTECT.DOCUMENT"; } | T_FUNC_PROTECT_REVISIONS { $$ = "PROTECT.REVISIONS"; } | T_FUNC_PUSHBUTTON_PROPERTIES { $$ = "PUSHBUTTON.PROPERTIES"; } | T_FUNC_QUIT { $$ = "QUIT"; } | T_FUNC_REMOVE_LIST_ITEM { $$ = "REMOVE.LIST.ITEM"; } | T_FUNC_REMOVE_PAGE_BREAK { $$ = "REMOVE.PAGE.BREAK"; } | T_FUNC_RENAME_OBJECT { $$ = "RENAME.OBJECT"; } | T_FUNC_REPLACE_FONT { $$ = "REPLACE.FONT"; } | T_FUNC_RESET_TOOL { $$ = "RESET.TOOL"; } | T_FUNC_RM_PRINT_AREA { $$ = "RM.PRINT.AREA"; } | T_FUNC_ROUTE_DOCUMENT { $$ = "ROUTE.DOCUMENT"; } | T_FUNC_ROUTING_SLIP { $$ = "ROUTING.SLIP"; } | T_FUNC_ROW_HEIGHT { $$ = "ROW.HEIGHT"; } | T_FUNC_RUN { $$ = "RUN"; } | T_FUNC_SAVE { $$ = "SAVE"; } | T_FUNC_SAVE_AS { $$ = "SAVE.AS"; } | T_FUNC_SAVE_COPY_AS { $$ = "SAVE.COPY.AS"; } | T_FUNC_SAVE_NEW_OBJECT { $$ = "SAVE.NEW.OBJECT"; } | T_FUNC_SAVE_WORKBOOK { $$ = "SAVE.WORKBOOK"; } | T_FUNC_SAVE_WORKSPACE { $$ = "SAVE.WORKSPACE"; } | T_FUNC_SCALE { $$ = "SCALE"; } | T_FUNC_SCENARIO_ADD { $$ = "SCENARIO.ADD"; } | T_FUNC_SCENARIO_CELLS { $$ = "SCENARIO.CELLS"; } | T_FUNC_SCENARIO_DELETE { $$ = "SCENARIO.DELETE"; } | T_FUNC_SCENARIO_EDIT { $$ = "SCENARIO.EDIT"; } | T_FUNC_SCENARIO_MERGE { $$ = "SCENARIO.MERGE"; } | T_FUNC_SCENARIO_SHOW { $$ = "SCENARIO.SHOW"; } | T_FUNC_SCENARIO_SHOW_NEXT { $$ = "SCENARIO.SHOW.NEXT"; } | T_FUNC_SCENARIO_SUMMARY { $$ = "SCENARIO.SUMMARY"; } | T_FUNC_SCROLLBAR_PROPERTIES { $$ = "SCROLLBAR.PROPERTIES"; } | T_FUNC_SELECT { $$ = "SELECT"; } | T_FUNC_SELECT_ALL { $$ = "SELECT.ALL"; } | T_FUNC_SELECT_CHART { $$ = "SELECT.CHART"; } | T_FUNC_SELECT_END { $$ = "SELECT.END"; } | T_FUNC_SELECT_LAST_CELL { $$ = "SELECT.LAST.CELL"; } | T_FUNC_SELECT_LIST_ITEM { $$ = "SELECT.LIST.ITEM"; } | T_FUNC_SELECT_PLOT_AREA { $$ = "SELECT.PLOT.AREA"; } | T_FUNC_SELECT_SPECIAL { $$ = "SELECT.SPECIAL"; } | T_FUNC_SEND_KEYS { $$ = "SEND.KEYS"; } | T_FUNC_SEND_MAIL { $$ = "SEND.MAIL"; } | T_FUNC_SEND_TO_BACK { $$ = "SEND.TO.BACK"; } | T_FUNC_SERIES_AXES { $$ = "SERIES.AXES"; } | T_FUNC_SERIES_ORDER { $$ = "SERIES.ORDER"; } | T_FUNC_SERIES_X { $$ = "SERIES.X"; } | T_FUNC_SERIES_Y { $$ = "SERIES.Y"; } | T_FUNC_SET_CONTROL_VALUE { $$ = "SET.CONTROL.VALUE"; } | T_FUNC_SET_CRITERIA { $$ = "SET.CRITERIA"; } | T_FUNC_SET_DATABASE { $$ = "SET.DATABASE"; } | T_FUNC_SET_DIALOG_DEFAULT { $$ = "SET.DIALOG.DEFAULT"; } | T_FUNC_SET_DIALOG_FOCUS { $$ = "SET.DIALOG.FOCUS"; } | T_FUNC_SET_EXTRACT { $$ = "SET.EXTRACT"; } | T_FUNC_SET_LIST_ITEM { $$ = "SET.LIST.ITEM"; } | T_FUNC_SET_PAGE_BREAK { $$ = "SET.PAGE.BREAK"; } | T_FUNC_SET_PREFERRED { $$ = "SET.PREFERRED"; } | T_FUNC_SET_PRINT_AREA { $$ = "SET.PRINT.AREA"; } | T_FUNC_SET_PRINT_TITLES { $$ = "SET.PRINT.TITLES"; } | T_FUNC_SET_UPDATE_STATUS { $$ = "SET.UPDATE.STATUS"; } | T_FUNC_SHARE { $$ = "SHARE"; } | T_FUNC_SHARE_NAME { $$ = "SHARE.NAME"; } | T_FUNC_SHEET_BACKGROUND { $$ = "SHEET.BACKGROUND"; } | T_FUNC_SHORT_MENUS { $$ = "SHORT.MENUS"; } | T_FUNC_SHOW_ACTIVE_CELL { $$ = "SHOW.ACTIVE.CELL"; } | T_FUNC_SHOW_CLIPBOARD { $$ = "SHOW.CLIPBOARD"; } | T_FUNC_SHOW_DETAIL { $$ = "SHOW.DETAIL"; } | T_FUNC_SHOW_DIALOG { $$ = "SHOW.DIALOG"; } | T_FUNC_SHOW_INFO { $$ = "SHOW.INFO"; } | T_FUNC_SHOW_LEVELS { $$ = "SHOW.LEVELS"; } | T_FUNC_SHOW_TOOLBAR { $$ = "SHOW.TOOLBAR"; } | T_FUNC_SORT_SPECIAL { $$ = "SORT.SPECIAL"; } | T_FUNC_SOUND_NOTE { $$ = "SOUND.NOTE"; } | T_FUNC_SOUND_PLAY { $$ = "SOUND.PLAY"; } | T_FUNC_SPELLING { $$ = "SPELLING"; } | T_FUNC_SPLIT { $$ = "SPLIT"; } | T_FUNC_STANDARD_FONT { $$ = "STANDARD.FONT"; } | T_FUNC_STANDARD_WIDTH { $$ = "STANDARD.WIDTH"; } | T_FUNC_STYLE { $$ = "STYLE"; } | T_FUNC_SUBSCRIBE_TO { $$ = "SUBSCRIBE.TO"; } | T_FUNC_SUBTOTAL_CREATE { $$ = "SUBTOTAL.CREATE"; } | T_FUNC_SUBTOTAL_REMOVE { $$ = "SUBTOTAL.REMOVE"; } | T_FUNC_SUMMARY_INFO { $$ = "SUMMARY.INFO"; } | T_FUNC_TAB_ORDER { $$ = "TAB.ORDER"; } | T_FUNC_TABLE { $$ = "TABLE"; } | T_FUNC_TEXT_TO_COLUMNS { $$ = "TEXT.TO.COLUMNS"; } | T_FUNC_TRACER_CLEAR { $$ = "TRACER.CLEAR"; } | T_FUNC_TRACER_DISPLAY { $$ = "TRACER.DISPLAY"; } | T_FUNC_TRACER_ERROR { $$ = "TRACER.ERROR"; } | T_FUNC_TRACER_NAVIGATE { $$ = "TRACER.NAVIGATE"; } | T_FUNC_TRAVERSE_NOTES { $$ = "TRAVERSE.NOTES"; } | T_FUNC_UNDO { $$ = "UNDO"; } | T_FUNC_UNGROUP { $$ = "UNGROUP"; } | T_FUNC_UNGROUP_SHEETS { $$ = "UNGROUP.SHEETS"; } | T_FUNC_UNHIDE { $$ = "UNHIDE"; } | T_FUNC_UNLOCKED_NEXT { $$ = "UNLOCKED.NEXT"; } | T_FUNC_UNLOCKED_PREV { $$ = "UNLOCKED.PREV"; } | T_FUNC_UNPROTECT_REVISIONS { $$ = "UNPROTECT.REVISIONS"; } | T_FUNC_UPDATE_LINK { $$ = "UPDATE.LINK"; } | T_FUNC_VBA_INSERT_FILE { $$ = "VBA.INSERT.FILE"; } | T_FUNC_VBA_MAKE_ADDIN { $$ = "VBA.MAKE.ADDIN"; } | T_FUNC_VBA_PROCEDURE_DEFINITION { $$ = "VBA.PROCEDURE.DEFINITION"; } | T_FUNC_VBAACTIVATE { $$ = "VBAACTIVATE"; } | T_FUNC_VIEW_3D { $$ = "VIEW.3D"; } | T_FUNC_VIEW_DEFINE { $$ = "VIEW.DEFINE"; } | T_FUNC_VIEW_DELETE { $$ = "VIEW.DELETE"; } | T_FUNC_VIEW_SHOW { $$ = "VIEW.SHOW"; } | T_FUNC_VLINE { $$ = "VLINE"; } | T_FUNC_VPAGE { $$ = "VPAGE"; } | T_FUNC_VSCROLL { $$ = "VSCROLL"; } | T_FUNC_WAIT { $$ = "WAIT"; } | T_FUNC_WEB_PUBLISH { $$ = "WEB.PUBLISH"; } | T_FUNC_WINDOW_MAXIMIZE { $$ = "WINDOW.MAXIMIZE"; } | T_FUNC_WINDOW_MINIMIZE { $$ = "WINDOW.MINIMIZE"; } | T_FUNC_WINDOW_MOVE { $$ = "WINDOW.MOVE"; } | T_FUNC_WINDOW_RESTORE { $$ = "WINDOW.RESTORE"; } | T_FUNC_WINDOW_SIZE { $$ = "WINDOW.SIZE"; } | T_FUNC_WORKBOOK_ACTIVATE { $$ = "WORKBOOK.ACTIVATE"; } | T_FUNC_WORKBOOK_ADD { $$ = "WORKBOOK.ADD"; } | T_FUNC_WORKBOOK_COPY { $$ = "WORKBOOK.COPY"; } | T_FUNC_WORKBOOK_DELETE { $$ = "WORKBOOK.DELETE"; } | T_FUNC_WORKBOOK_HIDE { $$ = "WORKBOOK.HIDE"; } | T_FUNC_WORKBOOK_INSERT { $$ = "WORKBOOK.INSERT"; } | T_FUNC_WORKBOOK_MOVE { $$ = "WORKBOOK.MOVE"; } | T_FUNC_WORKBOOK_NAME { $$ = "WORKBOOK.NAME"; } | T_FUNC_WORKBOOK_NEW { $$ = "WORKBOOK.NEW"; } | T_FUNC_WORKBOOK_NEXT { $$ = "WORKBOOK.NEXT"; } | T_FUNC_WORKBOOK_OPTIONS { $$ = "WORKBOOK.OPTIONS"; } | T_FUNC_WORKBOOK_PREV { $$ = "WORKBOOK.PREV"; } | T_FUNC_WORKBOOK_PROTECT { $$ = "WORKBOOK.PROTECT"; } | T_FUNC_WORKBOOK_SCROLL { $$ = "WORKBOOK.SCROLL"; } | T_FUNC_WORKBOOK_SELECT { $$ = "WORKBOOK.SELECT"; } | T_FUNC_WORKBOOK_TAB_SPLIT { $$ = "WORKBOOK.TAB.SPLIT"; } | T_FUNC_WORKBOOK_UNHIDE { $$ = "WORKBOOK.UNHIDE"; } | T_FUNC_WORKGROUP { $$ = "WORKGROUP"; } | T_FUNC_WORKGROUP_OPTIONS { $$ = "WORKGROUP.OPTIONS"; } | T_FUNC_WORKSPACE { $$ = "WORKSPACE"; } | T_FUNC_ZOOM { $$ = "ZOOM"; };

%%

public Node root;
internal Parser(OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner scanner) : base(scanner)
{
    scanner.Parser = this;
}
