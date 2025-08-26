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

#include "function/command.inc"
#include "function/future.inc"
#include "function/macro.inc"
#include "function/standard.inc"
#include "function/worksheet.inc"



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

%type <expressionVal>     array_constant cell_or_ref_constant cell_range cell intra_table_reference
%type <expressionVal>           name opt_name
%type <rowsVal>           constant_list_rows
%type <expressionListVal> constant_list_row inner_reference opt_inner_reference intra_table_reference_list
%type <expressionVal>     external_cell_reference sheet_range_reference single_sheet_reference
%type <expressionVal>     cell_or_ref_constant single_sheet sheet_range
%type <expressionVal>     external_cell_reference bang_reference
%type <expressionVal>     function_call_head  argument
%type <argParseResultVal> argument_list
%type <expressionVal> Standard_function_name future_function_name worksheet_function_name macro_function_name command_function_name
%type <nodeListVal>       opt_whitespace
%type <expressionVal>     opt_expression opt_solo_function
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

opt_expression: /* empty */ { $$ = null; }
    | expression { $$ = $1; }
    ;

opt_solo_function: /* empty */ { $$ = null; }
    | solo_function { $$ = $1; }
    ;

expression:
    T_LPAREN expression T_RPAREN { $$ = new ParenthesizedExpressionNode($2); }
    | expression T_PLUS  expression        { $$ = new AddNode($1, new PlusOperatorLiteralNode($2), $3); }
    | expression T_MINUS  expression        { $$ = new SubtractNode($1, new MinusOperatorLiteralNode($2), $3); }
    | expression T_ASTERISK expression     { $$ = new MultiplyNode($1, new AsteriskOperatorLiteralNode($2), $3); }
    | expression T_SLASH expression        { $$ = new DivideNode($1, new SlashOperatorLiteralNode($2), $3); }
    | expression T_CARET expression        { $$ = new PowerNode($1, new CaretOperatorLiteralNode($2), $3); }
    | expression T_AMPERSAND expression    { $$ = new ConcatenateNode($1, new AmpersandOperatorLiteralNode($2), $3); }
    | expression T_NE expression           { $$ = new NotEqualNode($1, new NotEqualOperatorLiteralNode($2), $3); }
    | expression T_LE expression           { $$ = new LessThanOrEqualNode($1, new LessThanOrEqualOperatorLiteralNode($2), $3); }
    | expression T_LT expression           { $$ = new LessThanNode($1, new LessThanOperatorLiteralNode($2), $3); }
    | expression T_GE expression           { $$ = new GreaterThanOrEqualNode($1, new GreaterThanOrEqualOperatorLiteralNode($2), $3); }
    | expression T_GT expression           { $$ = new GreaterThanNode($1, new GreaterThanOperatorLiteralNode($2), $3); }
    | expression T_EQ expression           { $$ = new EqualNode($1, new EqualOperatorLiteralNode($2), $3); }
    | expression T_COLON expression        { $$ = new RangeNode($1, new ColonNode($2), $3); }
    | expression T_COMMA expression        { $$ = new UnionNode($1, new CommaNode($2), $3); }
    | expression T_PERCENT %prec T_PERCENT                { $$ = new PercentNode(new PercentOperatorLiteralNode($2), $1); }
    | expression T_HASH                                 { $$ = new DynamicNode(new HashOperatorLiteralNode($2), $1); }
    | T_PLUS expression %prec UMINUS                      { $$ = new UnaryPlusNode(new PlusOperatorLiteralNode($1), $2); }
    | T_MINUS expression %prec UMINUS                     { $$ = new UnaryMinusNode(new MinusOperatorLiteralNode($1), $2); }
    | expression T_INTERSECTION expression { $$ = new IntersectionNode($1, new IntersectionOperatorLiteralNode($2), $3); }
    | T_AT_SYMBOL expression %prec UMINUS { $$ = new ImplicitIntersectionNode(new AtSymbolLiteralNode($1), $2); }
    | primary { $$ = $1; }
    | opt_whitespace expression opt_whitespace { $$ = $2; $$.LeadingWhitespace.AddRange($1); $$.TrailingWhitespace.AddRange($3); }
    ;

primary: constant { $$ = $1; }
    | ref_constant { $$ = $1; }
    | structure_reference { $$ = $1; }
    | cell_reference { $$ = $1; }
    | A1_row { $$ = $1; }
    | A1_column { $$ = $1; }
    | function_call { $$ = $1; }
    | function_call_head { $$ = $1; }
    | name_reference { $$ = $1; }
    // | pivot_items { $$ = $1; }
    ;

function_call_head: opt_whitespace Standard_function_name opt_whitespace { $$ = new BuiltInStandardFunctionNode($2, $1, $3); }
    | opt_whitespace future_function_name opt_whitespace { $$ = new BuiltInFutureFunctionNode($2, $1, $3); }
    | opt_whitespace macro_function_name opt_whitespace { $$ = new BuiltInMacroFunctionNode($2, $1, $3); }
    | opt_whitespace command_function_name opt_whitespace T_QUESTIONMARK opt_whitespace { $$ = new BuiltInCommandFunctionNode($2, new QuestionMarkNode($4, $3, $5), $1, null); }
    | opt_whitespace command_function_name opt_whitespace { $$ = new BuiltInCommandFunctionNode($2, null, $1, $3); }
    | opt_whitespace T_XLFN_XLWS_  worksheet_function_name opt_whitespace { $$ = new BuiltInWorksheetFunctionNode($2, new BuiltInFunctionNode($3), $1, $4); }
    ;

function_call: opt_whitespace function_call_head T_LPAREN argument_list  T_RPAREN opt_whitespace
        {
            ArgumentParseResult result = $4;
            $$ = new FunctionCallNode($2, result.Arguments,  $1, $6);
        };

solo_function: opt_whitespace T_XLFN_XLWS_ T_FUNC_PY opt_whitespace T_LPAREN opt_whitespace T_LONG opt_whitespace T_COMMA opt_whitespace T_NUMERICAL_CONSTANT opt_whitespace argument_list opt_whitespace T_RPAREN opt_whitespace
        {
            BuiltInWorksheetFunctionNode pyNode = new PyWorksheetFunctionNode($1, $4);
            NumericLiteralNode<long> arg1 = new NumericLiteralNode<long>($7, $6, $8);
            NumericLiteralNode<double> arg2 = new NumericLiteralNode<double>($11, $10, $12);

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




constant: opt_whitespace T_NUMERICAL_CONSTANT opt_whitespace { $$ = new NumericLiteralNode<double>($2, $1, $3); }
             | opt_whitespace T_LONG opt_whitespace { $$ = new NumericLiteralNode<long>($2, $1, $3); }
             | opt_whitespace T_STRING_CONSTANT opt_whitespace { $$ = new StringNode($2, $1, $3); }
             | opt_whitespace T_TRUE opt_whitespace { $$ = new LogicalNode(true, $1, $3); }
             | opt_whitespace T_FALSE opt_whitespace { $$ = new LogicalNode(false, $1, $3); }
             | error_constant { $$ = $1; }
             | array_constant { $$ = $1; };

error_constant: T_DIV0_ERROR { $$ = new ErrorNode($1); } | T_NA_ERROR { $$ = new ErrorNode($1); } | T_NAME_ERROR { $$ = new ErrorNode($1); } |  T_NULL_ERROR { $$ = new ErrorNode($1); } |  T_NUM_ERROR { $$ = new ErrorNode($1); } |  T_VALUE_ERROR { $$ = new ErrorNode($1); } |  T_GETTING_DATA_ERROR { $$ = new ErrorNode($1); } | T_SPILL_ERROR { $$ = new ErrorNode($1); } | T_CALC_ERROR { $$ = new ErrorNode($1); } | T_BLOCKED_ERROR { $$ = new ErrorNode($1); } | T_BUSY_ERROR { $$ = new ErrorNode($1); } | T_CIRCULAR_ERROR { $$ = new ErrorNode($1); } | T_CONNECT_ERROR { $$ = new ErrorNode($1); } | T_EXTERNAL_ERROR { $$ = new ErrorNode($1); } | T_FIELD_ERROR { $$ = new ErrorNode($1); } | T_PYTHON_ERROR { $$ = new ErrorNode($1); } | T_UNKNOWN_ERROR { $$ = new ErrorNode($1); };

ref_constant: opt_whitespace T_REF_ERROR opt_whitespace { $$ = new ErrorNode($2, $1, $3); }
    ;

array_constant: T_LBRACE opt_whitespace constant_list_rows opt_whitespace T_RBRACE
        {
            $$ = new ArrayNode($3, $2, $4);
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

cell_reference : external_cell_reference { $$ = $1; } | cell_range { $$ = $1; } | cell { $$ = $1; };
name_reference: opt_whitespace T_IDENTIFIER opt_whitespace T_LPAREN opt_whitespace argument_list opt_whitespace T_RPAREN opt_whitespace
    {
        // This logic is moved from the old function_call rule.
        // $2 is a string, we need to wrap it in a NameNode.
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

cell: R1C1_cell { $$ = $1; } | A1_cell { $$ = $1; };
cell_range :
           A1_cell T_COLON  A1_cell { $$ = new CellRangeNode<A1CellNode, A1CellNode, UInt64, A1RowNode, UInt64, A1ColumnNode, UInt64, A1RowNode, UInt64, A1ColumnNode>($1, $3); }
           | A1_cell T_COLON  R1C1_cell { $$ = new CellRangeNode<A1CellNode, R1C1CellNode, UInt64, A1RowNode, UInt64, A1ColumnNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode>($1, $3); }
           | R1C1_cell T_COLON A1_cell  { $$ = new CellRangeNode<R1C1CellNode, A1CellNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode, UInt64, A1RowNode, UInt64, A1ColumnNode>($1, $3); }
                       | R1C1_cell T_COLON  R1C1_cell { $$ = new CellRangeNode<R1C1CellNode, R1C1CellNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode, Int64, R1C1RowNode, Int64, R1C1ColumnNode>($1, $3); }
            | A1_column T_COLON A1_column { $$ = new RangeNode($1, new ColonNode($2, null, null), $3); }
            | A1_row T_COLON A1_row { $$ = new RangeNode($1, new ColonNode($2, null, null), $3); };



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

whitespace: T_NEWLINE { $$ = new WhitespaceNode($1); }
          | T_INTERSECTION { $$ = new WhitespaceNode($1); };
opt_whitespace:
     opt_whitespace whitespace { $1.Add($2); $$ = $1; }
    | whitespace { $$ = new List<Node>() { $1 }; }
    | /* empty */ { $$ = new List<Node>(); }
    ;

Standard_function_name:
      T_FUNC_ABS { $$ = new AbsStandardFunctionNode(); }
    | T_FUNC_ACCRINT { $$ = new AccrIntStandardFunctionNode(); }
    | T_FUNC_ACCRINTM { $$ = new AccrIntMStandardFunctionNode(); }
    | T_FUNC_ACOS { $$ = new AcosStandardFunctionNode(); }
    | T_FUNC_ACOSH { $$ = new AcoshStandardFunctionNode(); }
    | T_FUNC_ADDRESS { $$ = new AddressStandardFunctionNode(); }
    | T_FUNC_AMORDEGRC { $$ = new AmorDegrCStandardFunctionNode(); }
    | T_FUNC_AMORLINC { $$ = new AmorLinCStandardFunctionNode(); }
    | T_FUNC_AND { $$ = new AndStandardFunctionNode(); }
    | T_FUNC_AREAS { $$ = new AreasStandardFunctionNode(); }
    | T_FUNC_ASC { $$ = new AscStandardFunctionNode(); }
    | T_FUNC_ASIN { $$ = new AsinStandardFunctionNode(); }
    | T_FUNC_ASINH { $$ = new AsinhStandardFunctionNode(); }
    | T_FUNC_ATAN { $$ = new AtanStandardFunctionNode(); }
    | T_FUNC_ATAN2 { $$ = new AtanToStandardFunctionNode(); }
    | T_FUNC_ATANH { $$ = new AtanhStandardFunctionNode(); }
    | T_FUNC_AVEDEV { $$ = new AveDevStandardFunctionNode(); }
    | T_FUNC_AVERAGE { $$ = new AverageStandardFunctionNode(); }
    | T_FUNC_AVERAGEA { $$ = new AverageAStandardFunctionNode(); }
    | T_FUNC_AVERAGEIF { $$ = new AverageIfStandardFunctionNode(); }
    | T_FUNC_AVERAGEIFS { $$ = new AverageIfsStandardFunctionNode(); }
    | T_FUNC_BAHTTEXT { $$ = new BahtTextStandardFunctionNode(); }
    | T_FUNC_BESSELI { $$ = new BesseliStandardFunctionNode(); }
    | T_FUNC_BESSELJ { $$ = new BesseljStandardFunctionNode(); }
    | T_FUNC_BESSELK { $$ = new BesselkStandardFunctionNode(); }
    | T_FUNC_BESSELY { $$ = new BesselyStandardFunctionNode(); }
    | T_FUNC_BETADIST { $$ = new BetaDistStandardFunctionNode(); }
    | T_FUNC_BETAINV { $$ = new BetaInvStandardFunctionNode(); }
    | T_FUNC_BIN2DEC { $$ = new BinToDecStandardFunctionNode(); }
    | T_FUNC_BIN2HEX { $$ = new BinToHexStandardFunctionNode(); }
    | T_FUNC_BIN2OCT { $$ = new BinToOctStandardFunctionNode(); }
    | T_FUNC_BINOMDIST { $$ = new BinomDistStandardFunctionNode(); }
    | T_FUNC_CEILING { $$ = new CeilingStandardFunctionNode(); }
    | T_FUNC_CELL { $$ = new CellStandardFunctionNode(); }
    | T_FUNC_CHAR { $$ = new CharStandardFunctionNode(); }
    | T_FUNC_CHIDIST { $$ = new ChiDistStandardFunctionNode(); }
    | T_FUNC_CHIINV { $$ = new ChiInvStandardFunctionNode(); }
    | T_FUNC_CHITEST { $$ = new ChiTestStandardFunctionNode(); }
    | T_FUNC_CHOOSE { $$ = new ChooseStandardFunctionNode(); }
    | T_FUNC_CLEAN { $$ = new CleanStandardFunctionNode(); }
    | T_FUNC_CODE { $$ = new CodeStandardFunctionNode(); }
    | T_FUNC_COLUMN { $$ = new ColumnStandardFunctionNode(); }
    | T_FUNC_COLUMNS { $$ = new ColumnsStandardFunctionNode(); }
    | T_FUNC_COMBIN { $$ = new CombinStandardFunctionNode(); }
    | T_FUNC_COMPLEX { $$ = new ComplexStandardFunctionNode(); }
    | T_FUNC_CONCAT { $$ = new ConcatStandardFunctionNode(); }
    | T_FUNC_CONCATENATE { $$ = new ConcatenateStandardFunctionNode(); }
    | T_FUNC_CONFIDENCE { $$ = new ConfidenceStandardFunctionNode(); }
    | T_FUNC_CONVERT { $$ = new ConvertStandardFunctionNode(); }
    | T_FUNC_CORREL { $$ = new CorrelStandardFunctionNode(); }
    | T_FUNC_COS { $$ = new CosStandardFunctionNode(); }
    | T_FUNC_COSH { $$ = new CoshStandardFunctionNode(); }
    | T_FUNC_COUNT { $$ = new CountStandardFunctionNode(); }
    | T_FUNC_COUNTA { $$ = new CountAStandardFunctionNode(); }
    | T_FUNC_COUNTBLANK { $$ = new CountBlankStandardFunctionNode(); }
    | T_FUNC_COUNTIF { $$ = new CountIfStandardFunctionNode(); }
    | T_FUNC_COUNTIFS { $$ = new CountIfsStandardFunctionNode(); }
    | T_FUNC_COUPDAYBS { $$ = new CoupDayBsStandardFunctionNode(); }
    | T_FUNC_COUPDAYS { $$ = new CoupDaysStandardFunctionNode(); }
    | T_FUNC_COUPDAYSNC { $$ = new CoupDaysNcStandardFunctionNode(); }
    | T_FUNC_COUPNCD { $$ = new CoupNcdStandardFunctionNode(); }
    | T_FUNC_COUPNUM { $$ = new CoupNumStandardFunctionNode(); }
    | T_FUNC_COUPPCD { $$ = new CoupPcdStandardFunctionNode(); }
    | T_FUNC_COVAR { $$ = new CovarStandardFunctionNode(); }
    | T_FUNC_CRITBINOM { $$ = new CritBinomStandardFunctionNode(); }
    | T_FUNC_CUBEKPIMEMBER { $$ = new CubeKpimemberStandardFunctionNode(); }
    | T_FUNC_CUBEMEMBER { $$ = new CubeMemberStandardFunctionNode(); }
    | T_FUNC_CUBEMEMBERPROPERTY { $$ = new CubeMemberpropertyStandardFunctionNode(); }
    | T_FUNC_CUBERANKEDMEMBER { $$ = new CubeRankedmemberStandardFunctionNode(); }
    | T_FUNC_CUBESET { $$ = new CubeSetStandardFunctionNode(); }
    | T_FUNC_CUBESETCOUNT { $$ = new CubeSetcountStandardFunctionNode(); }
    | T_FUNC_CUBEVALUE { $$ = new CubeValueStandardFunctionNode(); }
    | T_FUNC_CUMIPMT { $$ = new CumIpmtStandardFunctionNode(); }
    | T_FUNC_CUMPRINC { $$ = new CumPrIncStandardFunctionNode(); }
    | T_FUNC_DATE { $$ = new DateStandardFunctionNode(); }
    | T_FUNC_DATEDIF { $$ = new DatedIfStandardFunctionNode(); }
    | T_FUNC_DATESTRING { $$ = new DateStringStandardFunctionNode(); }
    | T_FUNC_DATEVALUE { $$ = new DateValueStandardFunctionNode(); }
    | T_FUNC_DAVERAGE { $$ = new DAverageStandardFunctionNode(); }
    | T_FUNC_DAY { $$ = new DayStandardFunctionNode(); }
    | T_FUNC_DAYS360 { $$ = new Days360StandardFunctionNode(); }
    | T_FUNC_DB { $$ = new DBStandardFunctionNode(); }
    | T_FUNC_DBCS { $$ = new DBCSStandardFunctionNode(); }
    | T_FUNC_DCOUNT { $$ = new DCountStandardFunctionNode(); }
    | T_FUNC_DCOUNTA { $$ = new DCountAStandardFunctionNode(); }
    | T_FUNC_DDB { $$ = new DDBStandardFunctionNode(); }
    | T_FUNC_DEC2BIN { $$ = new DecToBinStandardFunctionNode(); }
    | T_FUNC_DEC2HEX { $$ = new DecToHexStandardFunctionNode(); }
    | T_FUNC_DEC2OCT { $$ = new DecToOctStandardFunctionNode(); }
    | T_FUNC_DEGREES { $$ = new DegreesStandardFunctionNode(); }
    | T_FUNC_DELTA { $$ = new DeltaStandardFunctionNode(); }
    | T_FUNC_DEVSQ { $$ = new DevSqStandardFunctionNode(); }
    | T_FUNC_DGET { $$ = new DGetStandardFunctionNode(); }
    | T_FUNC_DISC { $$ = new DiscStandardFunctionNode(); }
    | T_FUNC_DMAX { $$ = new DMaxStandardFunctionNode(); }
    | T_FUNC_DMIN { $$ = new DMinStandardFunctionNode(); }
    | T_FUNC_DOLLAR { $$ = new DollarStandardFunctionNode(); }
    | T_FUNC_DOLLARDE { $$ = new DollarDeStandardFunctionNode(); }
    | T_FUNC_DOLLARFR { $$ = new DollarFrStandardFunctionNode(); }
    | T_FUNC_DPRODUCT { $$ = new DProductStandardFunctionNode(); }
    | T_FUNC_DSTDEV { $$ = new DStdDevStandardFunctionNode(); }
    | T_FUNC_DSTDEVP { $$ = new DStdDevPStandardFunctionNode(); }
    | T_FUNC_DSUM { $$ = new DSumStandardFunctionNode(); }
    | T_FUNC_DURATION { $$ = new DurationStandardFunctionNode(); }
    | T_FUNC_DVAR { $$ = new DVarStandardFunctionNode(); }
    | T_FUNC_DVARP { $$ = new DVarPStandardFunctionNode(); }
    | T_FUNC_EDATE { $$ = new EDateStandardFunctionNode(); }
    | T_FUNC_EFFECT { $$ = new EffectStandardFunctionNode(); }
    | T_FUNC_EOMONTH { $$ = new EOMonthStandardFunctionNode(); }
    | T_FUNC_ERF { $$ = new ErfStandardFunctionNode(); }
    | T_FUNC_ERFC { $$ = new ErfCStandardFunctionNode(); }
    | T_FUNC_ERROR_TYPE { $$ = new ErrorTypeStandardFunctionNode(); }
    | T_FUNC_EVEN { $$ = new EvenStandardFunctionNode(); }
    | T_FUNC_EXACT { $$ = new ExactStandardFunctionNode(); }
    | T_FUNC_EXP { $$ = new ExpStandardFunctionNode(); }
    | T_FUNC_EXPONDIST { $$ = new ExponDistStandardFunctionNode(); }
    | T_FUNC_FACT { $$ = new FactStandardFunctionNode(); }
    | T_FUNC_FACTDOUBLE { $$ = new FactDoubleStandardFunctionNode(); }
    | T_FUNC_FDIST { $$ = new FDistStandardFunctionNode(); }
    | T_FUNC_FIND { $$ = new FindStandardFunctionNode(); }
    | T_FUNC_FINDB { $$ = new FindBStandardFunctionNode(); }
    | T_FUNC_FINV { $$ = new FInvStandardFunctionNode(); }
    | T_FUNC_FISHER { $$ = new FisherStandardFunctionNode(); }
    | T_FUNC_FISHERINV { $$ = new FisherInvStandardFunctionNode(); }
    | T_FUNC_FIXED { $$ = new FixedStandardFunctionNode(); }
    | T_FUNC_FLOOR { $$ = new FloorStandardFunctionNode(); }
    | T_FUNC_FORECAST { $$ = new ForecastStandardFunctionNode(); }
    | T_FUNC_FREQUENCY { $$ = new FrequencyStandardFunctionNode(); }
    | T_FUNC_FTEST { $$ = new FTestStandardFunctionNode(); }
    | T_FUNC_FV { $$ = new FvStandardFunctionNode(); }
    | T_FUNC_FVSCHEDULE { $$ = new FvScheduleStandardFunctionNode(); }
    | T_FUNC_GAMMADIST { $$ = new GammaDistStandardFunctionNode(); }
    | T_FUNC_GAMMAINV { $$ = new GammaInvStandardFunctionNode(); }
    | T_FUNC_GAMMALN { $$ = new GammaLnStandardFunctionNode(); }
    | T_FUNC_GCD { $$ = new GcdStandardFunctionNode(); }
    | T_FUNC_GEOMEAN { $$ = new GeoMeanStandardFunctionNode(); }
    | T_FUNC_GESTEP { $$ = new GeStepStandardFunctionNode(); }
    | T_FUNC_GETPIVOTDATA { $$ = new GetPivotDataStandardFunctionNode(); }
    | T_FUNC_GROWTH { $$ = new GrowthStandardFunctionNode(); }
    | T_FUNC_HARMEAN { $$ = new HarMeanStandardFunctionNode(); }
    | T_FUNC_HEX2BIN { $$ = new HexToBinStandardFunctionNode(); }
    | T_FUNC_HEX2DEC { $$ = new HexToDecStandardFunctionNode(); }
    | T_FUNC_HEX2OCT { $$ = new HexToOctStandardFunctionNode(); }
    | T_FUNC_HLOOKUP { $$ = new HLookupStandardFunctionNode(); }
    | T_FUNC_HOUR { $$ = new HourStandardFunctionNode(); }
    | T_FUNC_HYPERLINK { $$ = new HyperlinkStandardFunctionNode(); }
    | T_FUNC_HYPGEOMDIST { $$ = new HypGeomDistStandardFunctionNode(); }
    | T_FUNC_IF { $$ = new IfStandardFunctionNode(); }
    | T_FUNC_IFERROR { $$ = new IfErrorStandardFunctionNode(); }
    | T_FUNC_IFS { $$ = new IfsStandardFunctionNode(); }
    | T_FUNC_IMABS { $$ = new ImAbsStandardFunctionNode(); }
    | T_FUNC_IMAGINARY { $$ = new ImAginaryStandardFunctionNode(); }
    | T_FUNC_IMARGUMENT { $$ = new ImArgumentStandardFunctionNode(); }
    | T_FUNC_IMCONJUGATE { $$ = new ImConjugateStandardFunctionNode(); }
    | T_FUNC_IMCOS { $$ = new ImCosStandardFunctionNode(); }
    | T_FUNC_IMDIV { $$ = new ImDivStandardFunctionNode(); }
    | T_FUNC_IMEXP { $$ = new ImExpStandardFunctionNode(); }
    | T_FUNC_IMLN { $$ = new ImLnStandardFunctionNode(); }
    | T_FUNC_IMLOG10 { $$ = new ImLog10StandardFunctionNode(); }
    | T_FUNC_IMLOG2 { $$ = new ImLogToStandardFunctionNode(); }
    | T_FUNC_IMPOWER { $$ = new ImPowerStandardFunctionNode(); }
    | T_FUNC_IMPRODUCT { $$ = new ImProductStandardFunctionNode(); }
    | T_FUNC_IMREAL { $$ = new ImRealStandardFunctionNode(); }
    | T_FUNC_IMSIN { $$ = new ImSinStandardFunctionNode(); }
    | T_FUNC_IMSQRT { $$ = new ImSqrtStandardFunctionNode(); }
    | T_FUNC_IMSUB { $$ = new ImSubStandardFunctionNode(); }
    | T_FUNC_IMSUM { $$ = new ImSumStandardFunctionNode(); }
    | T_FUNC_INDEX { $$ = new IndexStandardFunctionNode(); }
    | T_FUNC_INDIRECT { $$ = new IndirectStandardFunctionNode(); }
    | T_FUNC_INFO { $$ = new InfoStandardFunctionNode(); }
    | T_FUNC_INT { $$ = new IntStandardFunctionNode(); }
    | T_FUNC_INTERCEPT { $$ = new InterceptStandardFunctionNode(); }
    | T_FUNC_INTRATE { $$ = new IntrateStandardFunctionNode(); }
    | T_FUNC_IPMT { $$ = new IpmtStandardFunctionNode(); }
    | T_FUNC_IRR { $$ = new IrrStandardFunctionNode(); }
    | T_FUNC_ISBLANK { $$ = new IsBlankStandardFunctionNode(); }
    | T_FUNC_ISERR { $$ = new IsErrStandardFunctionNode(); }
    | T_FUNC_ISERROR { $$ = new IsErrorStandardFunctionNode(); }
    | T_FUNC_ISEVEN { $$ = new IsEvenStandardFunctionNode(); }
    | T_FUNC_ISLOGICAL { $$ = new IsLogicalStandardFunctionNode(); }
    | T_FUNC_ISNA { $$ = new IsNaStandardFunctionNode(); }
    | T_FUNC_ISNONTEXT { $$ = new IsNontextStandardFunctionNode(); }
    | T_FUNC_ISNUMBER { $$ = new IsNumberStandardFunctionNode(); }
    | T_FUNC_ISODD { $$ = new IsOddStandardFunctionNode(); }
    | T_FUNC_ISPMT { $$ = new IsPmtStandardFunctionNode(); }
    | T_FUNC_ISREF { $$ = new IsRefStandardFunctionNode(); }
    | T_FUNC_ISTEXT { $$ = new IsTextStandardFunctionNode(); }
    | T_FUNC_ISTHAIDIGIT { $$ = new IsThaiDigitStandardFunctionNode(); }
    | T_FUNC_KURT { $$ = new KurtStandardFunctionNode(); }
    | T_FUNC_LARGE { $$ = new LargeStandardFunctionNode(); }
    | T_FUNC_LCM { $$ = new LcmStandardFunctionNode(); }
    | T_FUNC_LEFT { $$ = new LeftStandardFunctionNode(); }
    | T_FUNC_LEFTB { $$ = new LeftbStandardFunctionNode(); }
    | T_FUNC_LEN { $$ = new LenStandardFunctionNode(); }
    | T_FUNC_LENB { $$ = new LenbStandardFunctionNode(); }
    | T_FUNC_LINEST { $$ = new LinestStandardFunctionNode(); }
    | T_FUNC_LN { $$ = new LnStandardFunctionNode(); }
    | T_FUNC_LOG { $$ = new LogStandardFunctionNode(); }
    | T_FUNC_LOG10 { $$ = new Log10StandardFunctionNode(); }
    | T_FUNC_LOGEST { $$ = new LogestStandardFunctionNode(); }
    | T_FUNC_LOGINV { $$ = new LogInvStandardFunctionNode(); }
    | T_FUNC_LOGNORMDIST { $$ = new LogNormDistStandardFunctionNode(); }
    | T_FUNC_LOOKUP { $$ = new LookupStandardFunctionNode(); }
    | T_FUNC_LOWER { $$ = new LowerStandardFunctionNode(); }
    | T_FUNC_MATCH { $$ = new MatchStandardFunctionNode(); }
    | T_FUNC_MAX { $$ = new MaxStandardFunctionNode(); }
    | T_FUNC_MAXA { $$ = new MaxaStandardFunctionNode(); }
    | T_FUNC_MAXIFS { $$ = new MaxifsStandardFunctionNode(); }
    | T_FUNC_MDETERM { $$ = new MdetermStandardFunctionNode(); }
    | T_FUNC_MDURATION { $$ = new MdurationStandardFunctionNode(); }
    | T_FUNC_MEDIAN { $$ = new MedianStandardFunctionNode(); }
    | T_FUNC_MID { $$ = new MidStandardFunctionNode(); }
    | T_FUNC_MIDB { $$ = new MidbStandardFunctionNode(); }
    | T_FUNC_MIN { $$ = new MinStandardFunctionNode(); }
    | T_FUNC_MINA { $$ = new MinaStandardFunctionNode(); }
    | T_FUNC_MINIFS { $$ = new MinifsStandardFunctionNode(); }
    | T_FUNC_MINUTE { $$ = new MinuteStandardFunctionNode(); }
    | T_FUNC_MINVERSE { $$ = new MinverseStandardFunctionNode(); }
    | T_FUNC_MIRR { $$ = new MirrStandardFunctionNode(); }
    | T_FUNC_MMULT { $$ = new MmultStandardFunctionNode(); }
    | T_FUNC_MOD { $$ = new ModStandardFunctionNode(); }
    | T_FUNC_MODE { $$ = new ModeStandardFunctionNode(); }
    | T_FUNC_MONTH { $$ = new MonthStandardFunctionNode(); }
    | T_FUNC_MROUND { $$ = new MroundStandardFunctionNode(); }
    | T_FUNC_MULTINOMIAL { $$ = new MultinomialStandardFunctionNode(); }
    | T_FUNC_N { $$ = new NStandardFunctionNode(); }
    | T_FUNC_NA { $$ = new NaStandardFunctionNode(); }
    | T_FUNC_NEGBINOMDIST { $$ = new NegBinomDistStandardFunctionNode(); }
    | T_FUNC_NETWORKDAYS { $$ = new NetworkDaysStandardFunctionNode(); }
    | T_FUNC_NOMINAL { $$ = new NominalStandardFunctionNode(); }
    | T_FUNC_NORMDIST { $$ = new NormDistStandardFunctionNode(); }
    | T_FUNC_NORMINV { $$ = new NormInvStandardFunctionNode(); }
    | T_FUNC_NORMSDIST { $$ = new NormsDistStandardFunctionNode(); }
    | T_FUNC_NORMSINV { $$ = new NormsInvStandardFunctionNode(); }
    | T_FUNC_NOT { $$ = new NotStandardFunctionNode(); }
    | T_FUNC_NOW { $$ = new NowStandardFunctionNode(); }
    | T_FUNC_NPER { $$ = new NperStandardFunctionNode(); }
    | T_FUNC_NPV { $$ = new NpvStandardFunctionNode(); }
    | T_FUNC_NUMBERSTRING { $$ = new NumberStringStandardFunctionNode(); }
    | T_FUNC_OCT2BIN { $$ = new OctToBinStandardFunctionNode(); }
    | T_FUNC_OCT2DEC { $$ = new OctToDecStandardFunctionNode(); }
    | T_FUNC_OCT2HEX { $$ = new OctToHexStandardFunctionNode(); }
    | T_FUNC_ODD { $$ = new OddStandardFunctionNode(); }
    | T_FUNC_ODDFPRICE { $$ = new OddFPriceStandardFunctionNode(); }
    | T_FUNC_ODDFYIELD { $$ = new OddFYieldStandardFunctionNode(); }
    | T_FUNC_ODDLPRICE { $$ = new OddLPriceStandardFunctionNode(); }
    | T_FUNC_ODDLYIELD { $$ = new OddLYieldStandardFunctionNode(); }
    | T_FUNC_OFFSET { $$ = new OffsetStandardFunctionNode(); }
    | T_FUNC_OR { $$ = new OrStandardFunctionNode(); }
    | T_FUNC_PEARSON { $$ = new PearsonStandardFunctionNode(); }
    | T_FUNC_PERCENTILE { $$ = new PercentileStandardFunctionNode(); }
    | T_FUNC_PERCENTRANK { $$ = new PercentRankStandardFunctionNode(); }
    | T_FUNC_PERMUT { $$ = new PermutStandardFunctionNode(); }
    | T_FUNC_PHONETIC { $$ = new PhoneticStandardFunctionNode(); }
    | T_FUNC_PI { $$ = new PiStandardFunctionNode(); }
    | T_FUNC_PMT { $$ = new PmtStandardFunctionNode(); }
    | T_FUNC_POISSON { $$ = new PoissonStandardFunctionNode(); }
    | T_FUNC_POWER { $$ = new PowerStandardFunctionNode(); }
    | T_FUNC_PPMT { $$ = new PpmtStandardFunctionNode(); }
    | T_FUNC_PRICE { $$ = new PriceStandardFunctionNode(); }
    | T_FUNC_PRICEDISC { $$ = new PricediscStandardFunctionNode(); }
    | T_FUNC_PRICEMAT { $$ = new PricematStandardFunctionNode(); }
    | T_FUNC_PROB { $$ = new ProbStandardFunctionNode(); }
    | T_FUNC_PRODUCT { $$ = new ProductStandardFunctionNode(); }
    | T_FUNC_PROPER { $$ = new ProperStandardFunctionNode(); }
    | T_FUNC_PV { $$ = new PvStandardFunctionNode(); }
    | T_FUNC_QUARTILE { $$ = new QuartileStandardFunctionNode(); }
    | T_FUNC_QUOTIENT { $$ = new QuotientStandardFunctionNode(); }
    | T_FUNC_RADIANS { $$ = new RadiansStandardFunctionNode(); }
    | T_FUNC_RAND { $$ = new RandStandardFunctionNode(); }
    | T_FUNC_RANDBETWEEN { $$ = new RandbetweenStandardFunctionNode(); }
    | T_FUNC_RANK { $$ = new RankStandardFunctionNode(); }
    | T_FUNC_RATE { $$ = new RateStandardFunctionNode(); }
    | T_FUNC_RECEIVED { $$ = new ReceivedStandardFunctionNode(); }
    | T_FUNC_REPLACE { $$ = new ReplaceStandardFunctionNode(); }
    | T_FUNC_REPLACEB { $$ = new ReplacebStandardFunctionNode(); }
    | T_FUNC_REPT { $$ = new ReptStandardFunctionNode(); }
    | T_FUNC_RIGHT { $$ = new RightStandardFunctionNode(); }
    | T_FUNC_RIGHTB { $$ = new RightBStandardFunctionNode(); }
    | T_FUNC_ROMAN { $$ = new RomanStandardFunctionNode(); }
    | T_FUNC_ROUND { $$ = new RoundStandardFunctionNode(); }
    | T_FUNC_ROUNDBAHTDOWN { $$ = new RoundBahtDownStandardFunctionNode(); }
    | T_FUNC_ROUNDBAHTUP { $$ = new RoundBahtUpStandardFunctionNode(); }
    | T_FUNC_ROUNDDOWN { $$ = new RoundDownStandardFunctionNode(); }
    | T_FUNC_ROUNDUP { $$ = new RoundUpStandardFunctionNode(); }
    | T_FUNC_ROW { $$ = new RowStandardFunctionNode(); }
    | T_FUNC_ROWS { $$ = new RowsStandardFunctionNode(); }
    | T_FUNC_RSQ { $$ = new RsqStandardFunctionNode(); }
    | T_FUNC_RTD { $$ = new RtdStandardFunctionNode(); }
    | T_FUNC_SEARCH { $$ = new SearchStandardFunctionNode(); }
    | T_FUNC_SEARCHB { $$ = new SearchbStandardFunctionNode(); }
    | T_FUNC_SECOND { $$ = new SecondStandardFunctionNode(); }
    | T_FUNC_SERIES { $$ = new SeriesStandardFunctionNode(); }
    | T_FUNC_SERIESSUM { $$ = new SeriessumStandardFunctionNode(); }
    | T_FUNC_SIGN { $$ = new SignStandardFunctionNode(); }
    | T_FUNC_SIN { $$ = new SinStandardFunctionNode(); }
    | T_FUNC_SINH { $$ = new SinhStandardFunctionNode(); }
    | T_FUNC_SKEW { $$ = new SkewStandardFunctionNode(); }
    | T_FUNC_SLN { $$ = new SlnStandardFunctionNode(); }
    | T_FUNC_SLOPE { $$ = new SlopeStandardFunctionNode(); }
    | T_FUNC_SMALL { $$ = new SmallStandardFunctionNode(); }
    | T_FUNC_SQRT { $$ = new SqrtStandardFunctionNode(); }
    | T_FUNC_SQRTPI { $$ = new SqrtpiStandardFunctionNode(); }
    | T_FUNC_STANDARDIZE { $$ = new StandardizeStandardFunctionNode(); }
    | T_FUNC_STDEV { $$ = new StDevStandardFunctionNode(); }
    | T_FUNC_STDEVA { $$ = new StDevAStandardFunctionNode(); }
    | T_FUNC_STDEVP { $$ = new StDevPStandardFunctionNode(); }
    | T_FUNC_STDEVPA { $$ = new StDevPaStandardFunctionNode(); }
    | T_FUNC_STEYX { $$ = new SteyxStandardFunctionNode(); }
    | T_FUNC_SUBSTITUTE { $$ = new SubstituteStandardFunctionNode(); }
    | T_FUNC_SUBTOTAL { $$ = new SubtotalStandardFunctionNode(); }
    | T_FUNC_SUM { $$ = new SumStandardFunctionNode(); }
    | T_FUNC_SUMIF { $$ = new SumIfStandardFunctionNode(); }
    | T_FUNC_SUMIFS { $$ = new SumIfsStandardFunctionNode(); }
    | T_FUNC_SUMPRODUCT { $$ = new SumProductStandardFunctionNode(); }
    | T_FUNC_SUMSQ { $$ = new SumSqStandardFunctionNode(); }
    | T_FUNC_SUMX2MY2 { $$ = new SumXToMyToStandardFunctionNode(); }
    | T_FUNC_SUMX2PY2 { $$ = new SumXToPyToStandardFunctionNode(); }
    | T_FUNC_SUMXMY2 { $$ = new SumXMyToStandardFunctionNode(); }
    | T_FUNC_SWITCH { $$ = new SwitchStandardFunctionNode(); }
    | T_FUNC_SYD { $$ = new SydStandardFunctionNode(); }
    | T_FUNC_T { $$ = new TStandardFunctionNode(); }
    | T_FUNC_TAN { $$ = new TanStandardFunctionNode(); }
    | T_FUNC_TANH { $$ = new TanhStandardFunctionNode(); }
    | T_FUNC_TBILLEQ { $$ = new TBillEqStandardFunctionNode(); }
    | T_FUNC_TBILLPRICE { $$ = new TBillPriceStandardFunctionNode(); }
    | T_FUNC_TBILLYIELD { $$ = new TBillYieldStandardFunctionNode(); }
    | T_FUNC_TDIST { $$ = new TDistStandardFunctionNode(); }
    | T_FUNC_TEXT { $$ = new TextStandardFunctionNode(); }
    | T_FUNC_TEXTJOIN { $$ = new TextJoinStandardFunctionNode(); }
    | T_FUNC_THAIDAYOFWEEK { $$ = new ThaiDayOfWeekStandardFunctionNode(); }
    | T_FUNC_THAIDIGIT { $$ = new ThaiDigitStandardFunctionNode(); }
    | T_FUNC_THAIMONTHOFYEAR { $$ = new ThaiMonthOfYearStandardFunctionNode(); }
    | T_FUNC_THAINUMSOUND { $$ = new ThaiNumSoundStandardFunctionNode(); }
    | T_FUNC_THAINUMSTRING { $$ = new ThaiNumStringStandardFunctionNode(); }
    | T_FUNC_THAISTRINGLENGTH { $$ = new ThaiStringLengthStandardFunctionNode(); }
    | T_FUNC_THAIYEAR { $$ = new ThaiYearStandardFunctionNode(); }
    | T_FUNC_TIME { $$ = new TimeStandardFunctionNode(); }
    | T_FUNC_TIMEVALUE { $$ = new TimeValueStandardFunctionNode(); }
    | T_FUNC_TINV { $$ = new TInvStandardFunctionNode(); }
    | T_FUNC_TODAY { $$ = new TodayStandardFunctionNode(); }
    | T_FUNC_TRANSPOSE { $$ = new TransposeStandardFunctionNode(); }
    | T_FUNC_TREND { $$ = new TrendStandardFunctionNode(); }
    | T_FUNC_TRIM { $$ = new TrimStandardFunctionNode(); }
    | T_FUNC_TRIMMEAN { $$ = new TrimMeanStandardFunctionNode(); }
    | T_FUNC_TRUNC { $$ = new TruncStandardFunctionNode(); }
    | T_FUNC_TTEST { $$ = new TTestStandardFunctionNode(); }
    | T_FUNC_TYPE { $$ = new TypeStandardFunctionNode(); }
    | T_FUNC_UPPER { $$ = new UpperStandardFunctionNode(); }
    | T_FUNC_USDOLLAR { $$ = new UsDollarStandardFunctionNode(); }
    | T_FUNC_VALUE { $$ = new ValueStandardFunctionNode(); }
    | T_FUNC_VAR { $$ = new VarStandardFunctionNode(); }
    | T_FUNC_VARA { $$ = new VarAStandardFunctionNode(); }
    | T_FUNC_VARP { $$ = new VarPStandardFunctionNode(); }
    | T_FUNC_VARPA { $$ = new VarPaStandardFunctionNode(); }
    | T_FUNC_VDB { $$ = new VdbStandardFunctionNode(); }
    | T_FUNC_VLOOKUP { $$ = new VLookupStandardFunctionNode(); }
    | T_FUNC_WEEKDAY { $$ = new WeekdayStandardFunctionNode(); }
    | T_FUNC_WEEKNUM { $$ = new WeekNumStandardFunctionNode(); }
    | T_FUNC_WEIBULL { $$ = new WeibullStandardFunctionNode(); }
    | T_FUNC_WORKDAY { $$ = new WorkdayStandardFunctionNode(); }
    | T_FUNC_XIRR { $$ = new XirrStandardFunctionNode(); }
    | T_FUNC_XNPV { $$ = new XnpvStandardFunctionNode(); }
    | T_FUNC_YEAR { $$ = new YearStandardFunctionNode(); }
    | T_FUNC_YEARFRAC { $$ = new YearFracStandardFunctionNode(); }
    | T_FUNC_YIELD { $$ = new YieldStandardFunctionNode(); }
    | T_FUNC_YIELDDISC { $$ = new YieldDiscStandardFunctionNode(); }
    | T_FUNC_YIELDMAT { $$ = new YieldMatStandardFunctionNode(); }
    | T_FUNC_ZTEST { $$ = new ZTestStandardFunctionNode(); }
    ;
future_function_name:
      T_FUNC_ACOT { $$ = new AcotFutureFunctionNode(); }
    | T_FUNC_ACOTH { $$ = new AcothFutureFunctionNode(); }
    | T_FUNC_AGGREGATE { $$ = new AggregateFutureFunctionNode(); }
    | T_FUNC_ARABIC { $$ = new ArabicFutureFunctionNode(); }
    | T_FUNC_BASE { $$ = new BaseFutureFunctionNode(); }
    | T_FUNC_BETA_DIST { $$ = new BetaDistFutureFunctionNode(); }
    | T_FUNC_BETA_INV { $$ = new BetaInvFutureFunctionNode(); }
    | T_FUNC_BINOM_DIST { $$ = new BinomDistFutureFunctionNode(); }
    | T_FUNC_BINOM_DIST_RANGE { $$ = new BinomDistRangeFutureFunctionNode(); }
    | T_FUNC_BINOM_INV { $$ = new BinomInvFutureFunctionNode(); }
    | T_FUNC_BITAND { $$ = new BitAndFutureFunctionNode(); }
    | T_FUNC_BITLSHIFT { $$ = new BitLShiftFutureFunctionNode(); }
    | T_FUNC_BITOR { $$ = new BitOrFutureFunctionNode(); }
    | T_FUNC_BITRSHIFT { $$ = new BitRShiftFutureFunctionNode(); }
    | T_FUNC_BITXOR { $$ = new BitXorFutureFunctionNode(); }
    | T_FUNC_BYCOL { $$ = new BycolFutureFunctionNode(); }
    | T_FUNC_BYROW { $$ = new ByrowFutureFunctionNode(); }
    | T_FUNC_CEILING_MATH { $$ = new CeilingMathFutureFunctionNode(); }
    | T_FUNC_CEILING_PRECISE { $$ = new CeilingPreciseFutureFunctionNode(); }
    | T_FUNC_CHISQ_DIST { $$ = new ChisqDistFutureFunctionNode(); }
    | T_FUNC_CHISQ_DIST_RT { $$ = new ChisqDistRtFutureFunctionNode(); }
    | T_FUNC_CHISQ_INV { $$ = new ChisqInvFutureFunctionNode(); }
    | T_FUNC_CHISQ_INV_RT { $$ = new ChisqInvRtFutureFunctionNode(); }
    | T_FUNC_CHISQ_TEST { $$ = new ChisqTestFutureFunctionNode(); }
    | T_FUNC_CHOOSECOLS { $$ = new ChooseColsFutureFunctionNode(); }
    | T_FUNC_CHOOSEROWS { $$ = new ChooseRowsFutureFunctionNode(); }
    | T_FUNC_COMBINA { $$ = new CombinaFutureFunctionNode(); }
    | T_FUNC_CONFIDENCE_NORM { $$ = new ConfidenceNormFutureFunctionNode(); }
    | T_FUNC_CONFIDENCE_T { $$ = new ConfidenceTFutureFunctionNode(); }
    | T_FUNC_COT { $$ = new CotFutureFunctionNode(); }
    | T_FUNC_COTH { $$ = new CothFutureFunctionNode(); }
    | T_FUNC_COVARIANCE_P { $$ = new CovariancePFutureFunctionNode(); }
    | T_FUNC_COVARIANCE_S { $$ = new CovarianceSFutureFunctionNode(); }
    | T_FUNC_CSC { $$ = new CscFutureFunctionNode(); }
    | T_FUNC_CSCH { $$ = new CschFutureFunctionNode(); }
    | T_FUNC_DAYS { $$ = new DaysFutureFunctionNode(); }
    | T_FUNC_DECIMAL { $$ = new DecimalFutureFunctionNode(); }
    | T_FUNC_DROP { $$ = new DropFutureFunctionNode(); }
    | T_FUNC_ECMA_CEILING { $$ = new EcmaCeilingFutureFunctionNode(); }
    | T_FUNC_ERFC_PRECISE { $$ = new ErfCPreciseFutureFunctionNode(); }
    | T_FUNC_ERF_PRECISE { $$ = new ErfPreciseFutureFunctionNode(); }
    | T_FUNC_EXPAND { $$ = new ExpandFutureFunctionNode(); }
    | T_FUNC_EXPON_DIST { $$ = new ExponDistFutureFunctionNode(); }
    | T_FUNC_FIELDVALUE { $$ = new FieldValueFutureFunctionNode(); }
    | T_FUNC_FILTERXML { $$ = new FilterXmlFutureFunctionNode(); }
    | T_FUNC_FLOOR_MATH { $$ = new FloorMathFutureFunctionNode(); }
    | T_FUNC_FLOOR_PRECISE { $$ = new FloorPreciseFutureFunctionNode(); }
    | T_FUNC_FORECAST_ETS { $$ = new ForecastEtsFutureFunctionNode(); }
    | T_FUNC_FORECAST_ETS_CONFINT { $$ = new ForecastEtsConfIntFutureFunctionNode(); }
    | T_FUNC_FORECAST_ETS_SEASONALITY { $$ = new ForecastEtsSeasonalityFutureFunctionNode(); }
    | T_FUNC_FORECAST_ETS_STAT { $$ = new ForecastEtsStatFutureFunctionNode(); }
    | T_FUNC_FORECAST_LINEAR { $$ = new ForecastLinearFutureFunctionNode(); }
    | T_FUNC_FORMULATEXT { $$ = new FormulaTextFutureFunctionNode(); }
    | T_FUNC_F_DIST { $$ = new FDistFutureFunctionNode(); }
    | T_FUNC_F_DIST_RT { $$ = new FDistRtFutureFunctionNode(); }
    | T_FUNC_F_INV { $$ = new FInvFutureFunctionNode(); }
    | T_FUNC_F_INV_RT { $$ = new FInvRtFutureFunctionNode(); }
    | T_FUNC_F_TEST { $$ = new FTestFutureFunctionNode(); }
    | T_FUNC_GAMMA { $$ = new GammaFutureFunctionNode(); }
    | T_FUNC_GAMMALN_PRECISE { $$ = new GammaLnPreciseFutureFunctionNode(); }
    | T_FUNC_GAMMA_DIST { $$ = new GammaDistFutureFunctionNode(); }
    | T_FUNC_GAMMA_INV { $$ = new GammaInvFutureFunctionNode(); }
    | T_FUNC_GAUSS { $$ = new GaussFutureFunctionNode(); }
    | T_FUNC_HSTACK { $$ = new HStackFutureFunctionNode(); }
    | T_FUNC_HYPGEOM_DIST { $$ = new HypGeomDistFutureFunctionNode(); }
    | T_FUNC_IFNA { $$ = new IfNaFutureFunctionNode(); }
    | T_FUNC_IMCOSH { $$ = new ImCoshFutureFunctionNode(); }
    | T_FUNC_IMCOT { $$ = new ImCotFutureFunctionNode(); }
    | T_FUNC_IMCSC { $$ = new ImCscFutureFunctionNode(); }
    | T_FUNC_IMCSCH { $$ = new ImCschFutureFunctionNode(); }
    | T_FUNC_IMSEC { $$ = new ImSecFutureFunctionNode(); }
    | T_FUNC_IMSECH { $$ = new ImSechFutureFunctionNode(); }
    | T_FUNC_IMSINH { $$ = new ImSinhFutureFunctionNode(); }
    | T_FUNC_IMTAN { $$ = new ImTanFutureFunctionNode(); }
    | T_FUNC_ISFORMULA { $$ = new IsFormulaFutureFunctionNode(); }
    | T_FUNC_ISOMITTED { $$ = new IsOmittedFutureFunctionNode(); }
    | T_FUNC_ISOWEEKNUM { $$ = new IsOWeekNumFutureFunctionNode(); }
    | T_FUNC_ISO_CEILING { $$ = new IsOCeilingFutureFunctionNode(); }
    | T_FUNC_LAMBDA { $$ = new LambdaFutureFunctionNode(); }
    | T_FUNC_LET { $$ = new LetFutureFunctionNode(); }
    | T_FUNC_LOGNORM_DIST { $$ = new LogNormDistFutureFunctionNode(); }
    | T_FUNC_LOGNORM_INV { $$ = new LogNormInvFutureFunctionNode(); }
    | T_FUNC_MAKEARRAY { $$ = new MakeArrayFutureFunctionNode(); }
    | T_FUNC_MAP { $$ = new MapFutureFunctionNode(); }
    | T_FUNC_MODE_MULT { $$ = new ModeMultFutureFunctionNode(); }
    | T_FUNC_MODE_SNGL { $$ = new ModeSnglFutureFunctionNode(); }
    | T_FUNC_MUNIT { $$ = new MUnitFutureFunctionNode(); }
    | T_FUNC_NEGBINOM_DIST { $$ = new NegBinomDistFutureFunctionNode(); }
    | T_FUNC_NETWORKDAYS_INTL { $$ = new NetworkDaysIntlFutureFunctionNode(); }
    | T_FUNC_NORM_DIST { $$ = new NormDistFutureFunctionNode(); }
    | T_FUNC_NORM_INV { $$ = new NormInvFutureFunctionNode(); }
    | T_FUNC_NORM_S_DIST { $$ = new NormSDistFutureFunctionNode(); }
    | T_FUNC_NORM_S_INV { $$ = new NormSInvFutureFunctionNode(); }
    | T_FUNC_NUMBERVALUE { $$ = new NumberValueFutureFunctionNode(); }
    | T_FUNC_PDURATION { $$ = new PDurationFutureFunctionNode(); }
    | T_FUNC_PERCENTILE_EXC { $$ = new PercentileExcFutureFunctionNode(); }
    | T_FUNC_PERCENTILE_INC { $$ = new PercentileIncFutureFunctionNode(); }
    | T_FUNC_PERCENTRANK_EXC { $$ = new PercentRankExcFutureFunctionNode(); }
    | T_FUNC_PERCENTRANK_INC { $$ = new PercentRankIncFutureFunctionNode(); }
    | T_FUNC_PERMUTATIONA { $$ = new PermutationaFutureFunctionNode(); }
    | T_FUNC_PHI { $$ = new PhiFutureFunctionNode(); }
    | T_FUNC_POISSON_DIST { $$ = new PoissonDistFutureFunctionNode(); }
    | T_FUNC_PQSOURCE { $$ = new PqsourceFutureFunctionNode(); }
    | T_FUNC_PYTHON_STR { $$ = new PythonStrFutureFunctionNode(); }
    | T_FUNC_PYTHON_TYPE { $$ = new PythonTypeFutureFunctionNode(); }
    | T_FUNC_PYTHON_TYPENAME { $$ = new PythonTypenameFutureFunctionNode(); }
    | T_FUNC_QUARTILE_EXC { $$ = new QuartileExcFutureFunctionNode(); }
    | T_FUNC_QUARTILE_INC { $$ = new QuartileIncFutureFunctionNode(); }
    | T_FUNC_QUERYSTRING { $$ = new QueryStringFutureFunctionNode(); }
    | T_FUNC_RANDARRAY { $$ = new RandArrayFutureFunctionNode(); }
    | T_FUNC_RANK_AVG { $$ = new RankAvgFutureFunctionNode(); }
    | T_FUNC_RANK_EQ { $$ = new RankEqFutureFunctionNode(); }
    | T_FUNC_REDUCE { $$ = new ReduceFutureFunctionNode(); }
    | T_FUNC_RRI { $$ = new RriFutureFunctionNode(); }
    | T_FUNC_SCAN { $$ = new ScanFutureFunctionNode(); }
    | T_FUNC_SEC { $$ = new SecFutureFunctionNode(); }
    | T_FUNC_SECH { $$ = new SechFutureFunctionNode(); }
    | T_FUNC_SEQUENCE { $$ = new SequenceFutureFunctionNode(); }
    | T_FUNC_SHEET { $$ = new SheetFutureFunctionNode(); }
    | T_FUNC_SHEETS { $$ = new SheetsFutureFunctionNode(); }
    | T_FUNC_SKEW_P { $$ = new SkewPFutureFunctionNode(); }
    | T_FUNC_SORTBY { $$ = new SortByFutureFunctionNode(); }
    | T_FUNC_STDEV_P { $$ = new StDevPFutureFunctionNode(); }
    | T_FUNC_STDEV_S { $$ = new StDevSFutureFunctionNode(); }
    | T_FUNC_TAKE { $$ = new TakeFutureFunctionNode(); }
    | T_FUNC_TEXTAFTER { $$ = new TextAfterFutureFunctionNode(); }
    | T_FUNC_TEXTBEFORE { $$ = new TextBeforeFutureFunctionNode(); }
    | T_FUNC_TEXTSPLIT { $$ = new TextSplitFutureFunctionNode(); }
    | T_FUNC_TOCOL { $$ = new ToColFutureFunctionNode(); }
    | T_FUNC_TOROW { $$ = new ToRowFutureFunctionNode(); }
    | T_FUNC_T_DIST { $$ = new TDistFutureFunctionNode(); }
    | T_FUNC_T_DIST_2T { $$ = new TDistTwoTFutureFunctionNode(); }
    | T_FUNC_T_DIST_RT { $$ = new TDistRtFutureFunctionNode(); }
    | T_FUNC_T_INV { $$ = new TInvFutureFunctionNode(); }
    | T_FUNC_T_INV_2T { $$ = new TInvToTFutureFunctionNode(); }
    | T_FUNC_T_TEST { $$ = new TTestFutureFunctionNode(); }
    | T_FUNC_UNICHAR { $$ = new UnicharFutureFunctionNode(); }
    | T_FUNC_UNICODE { $$ = new UnicodeFutureFunctionNode(); }
    | T_FUNC_UNIQUE { $$ = new UniqueFutureFunctionNode(); }
    | T_FUNC_VAR_P { $$ = new VarPFutureFunctionNode(); }
    | T_FUNC_VAR_S { $$ = new VarSFutureFunctionNode(); }
    | T_FUNC_VSTACK { $$ = new VStackFutureFunctionNode(); }
    | T_FUNC_WEBSERVICE { $$ = new WebServiceFutureFunctionNode(); }
    | T_FUNC_WEIBULL_DIST { $$ = new WeibullDistFutureFunctionNode(); }
    | T_FUNC_WORKDAY_INTL { $$ = new WorkdayIntlFutureFunctionNode(); }
    | T_FUNC_WRAPCOLS { $$ = new WrapColsFutureFunctionNode(); }
    | T_FUNC_WRAPROWS { $$ = new WrapRowsFutureFunctionNode(); }
    | T_FUNC_XLOOKUP { $$ = new XLookupFutureFunctionNode(); }
    | T_FUNC_XOR { $$ = new XorFutureFunctionNode(); }
    | T_FUNC_Z_TEST { $$ = new ZTestFutureFunctionNode(); }
    ;
macro_function_name: T_FUNC_ABSREF { $$ = new AbsRefMacroFunctionNode(); }
  | T_FUNC_ACTIVE_CELL { $$ = new ActiveCellMacroFunctionNode(); }
  | T_FUNC_CALL { $$ = new CallMacroFunctionNode(); }
  | T_FUNC_CALLER { $$ = new CallerMacroFunctionNode(); }
  | T_FUNC_EVALUATE { $$ = new EvaluateMacroFunctionNode(); }
  | T_FUNC_GET_DOCUMENT { $$ = new GetDocumentMacroFunctionNode(); }
  | T_FUNC_INPUT { $$ = new InputMacroFunctionNode(); }
  | T_FUNC_LAST_ERROR { $$ = new LastErrorMacroFunctionNode(); }
  | T_FUNC_SCENARIO_GET { $$ = new ScenarioGetMacroFunctionNode(); }
  | T_FUNC_SELECTION { $$ = new SelectionMacroFunctionNode(); }
  | T_FUNC_TEXTREF { $$ = new TextRefMacroFunctionNode(); }
  | T_FUNC_VIEW_GET { $$ = new ViewGetMacroFunctionNode(); }
  | T_FUNC_ADD_BAR { $$ = new AddBarMacroFunctionNode(); }
  | T_FUNC_ADD_COMMAND { $$ = new AddCommandMacroFunctionNode(); }
  | T_FUNC_ADD_MENU { $$ = new AddMenuMacroFunctionNode(); }
  | T_FUNC_ADD_TOOLBAR { $$ = new AddToolbarMacroFunctionNode(); }
  | T_FUNC_APP_TITLE { $$ = new AppTitleMacroFunctionNode(); }
  | T_FUNC_ARGUMENT { $$ = new ArgumentMacroFunctionNode(); }
  | T_FUNC_BREAK { $$ = new BreakMacroFunctionNode(); }
  | T_FUNC_CANCEL_KEY { $$ = new CancelKeyMacroFunctionNode(); }
  | T_FUNC_CHECK_COMMAND { $$ = new CheckCommandMacroFunctionNode(); }
  | T_FUNC_CREATE_OBJECT { $$ = new CreateObjectMacroFunctionNode(); }
  | T_FUNC_CUSTOM_REPEAT { $$ = new CustomRepeatMacroFunctionNode(); }
  | T_FUNC_CUSTOM_UNDO { $$ = new CustomUndoMacroFunctionNode(); }
  | T_FUNC_DELETE_BAR { $$ = new DeleteBarMacroFunctionNode(); }
  | T_FUNC_DELETE_COMMAND { $$ = new DeleteCommandMacroFunctionNode(); }
  | T_FUNC_DELETE_MENU { $$ = new DeleteMenuMacroFunctionNode(); }
  | T_FUNC_DELETE_TOOLBAR { $$ = new DeleteToolbarMacroFunctionNode(); }
  | T_FUNC_DEREF { $$ = new DeRefMacroFunctionNode(); }
  | T_FUNC_DIALOG_BOX { $$ = new DialogBoxMacroFunctionNode(); }
  | T_FUNC_DIRECTORY { $$ = new DirectoryMacroFunctionNode(); }
  | T_FUNC_DOCUMENTS { $$ = new DocumentsMacroFunctionNode(); }
  | T_FUNC_ECHO { $$ = new EchoMacroFunctionNode(); }
  | T_FUNC_ELSE { $$ = new ElseMacroFunctionNode(); }
  | T_FUNC_ELSE_IF { $$ = new ElseIfMacroFunctionNode(); }
  | T_FUNC_ENABLE_COMMAND { $$ = new EnableCommandMacroFunctionNode(); }
  | T_FUNC_ENABLE_TOOL { $$ = new EnableToolMacroFunctionNode(); }
  | T_FUNC_END_IF { $$ = new EndIfMacroFunctionNode(); }
  | T_FUNC_ERROR { $$ = new ErrorMacroFunctionNode(); }
  | T_FUNC_EXEC { $$ = new ExecMacroFunctionNode(); }
  | T_FUNC_EXECUTE { $$ = new ExecuteMacroFunctionNode(); }
  | T_FUNC_FCLOSE { $$ = new FcloseMacroFunctionNode(); }
  | T_FUNC_FILES { $$ = new FilesMacroFunctionNode(); }
  | T_FUNC_FOPEN { $$ = new FopenMacroFunctionNode(); }
  | T_FUNC_FOR { $$ = new ForMacroFunctionNode(); }
  | T_FUNC_FOR_CELL { $$ = new ForCellMacroFunctionNode(); }
  | T_FUNC_FORMULA_CONVERT { $$ = new FormulaConvertMacroFunctionNode(); }
  | T_FUNC_FPOS { $$ = new FposMacroFunctionNode(); }
  | T_FUNC_FREAD { $$ = new FreadMacroFunctionNode(); }
  | T_FUNC_FREADLN { $$ = new FreadlnMacroFunctionNode(); }
  | T_FUNC_FSIZE { $$ = new FsizeMacroFunctionNode(); }
  | T_FUNC_FWRITE { $$ = new FwriteMacroFunctionNode(); }
  | T_FUNC_FWRITELN { $$ = new FwritelnMacroFunctionNode(); }
  | T_FUNC_GET_BAR { $$ = new GetBarMacroFunctionNode(); }
  | T_FUNC_GET_CELL { $$ = new GetCellMacroFunctionNode(); }
  | T_FUNC_GET_CHART_ITEM { $$ = new GetChartItemMacroFunctionNode(); }
  | T_FUNC_GET_DEF { $$ = new GetDefMacroFunctionNode(); }
  | T_FUNC_GET_FORMULA { $$ = new GetFormulaMacroFunctionNode(); }
  | T_FUNC_GET_LINK_INFO { $$ = new GetLinkInfoMacroFunctionNode(); }
  | T_FUNC_GET_MOVIE { $$ = new GetMovieMacroFunctionNode(); }
  | T_FUNC_GET_NAME { $$ = new GetNameMacroFunctionNode(); }
  | T_FUNC_GET_NOTE { $$ = new GetNoteMacroFunctionNode(); }
  | T_FUNC_GET_OBJECT { $$ = new GetObjectMacroFunctionNode(); }
  | T_FUNC_GET_TOOL { $$ = new GetToolMacroFunctionNode(); }
  | T_FUNC_GET_TOOLBAR { $$ = new GetToolbarMacroFunctionNode(); }
  | T_FUNC_GET_WINDOW { $$ = new GetWindowMacroFunctionNode(); }
  | T_FUNC_GET_WORKBOOK { $$ = new GetWorkbookMacroFunctionNode(); }
  | T_FUNC_GET_WORKSPACE { $$ = new GetWorkspaceMacroFunctionNode(); }
  | T_FUNC_GOTO { $$ = new GotoMacroFunctionNode(); }
  | T_FUNC_GROUP { $$ = new GroupMacroFunctionNode(); }
  | T_FUNC_HALT { $$ = new HaltMacroFunctionNode(); }
  | T_FUNC_HELP { $$ = new HelpMacroFunctionNode(); }
  | T_FUNC_INITIATE { $$ = new InitiateMacroFunctionNode(); }
  | T_FUNC_LINKS { $$ = new LinksMacroFunctionNode(); }
  | T_FUNC_MOVIE_COMMAND { $$ = new MovieCommandMacroFunctionNode(); }
  | T_FUNC_NAMES { $$ = new NamesMacroFunctionNode(); }
  | T_FUNC_NEXT { $$ = new NextMacroFunctionNode(); }
  | T_FUNC_NOTE { $$ = new NoteMacroFunctionNode(); }
  | T_FUNC_OPEN_DIALOG { $$ = new OpenDialogMacroFunctionNode(); }
  | T_FUNC_OPTIONS_LISTS_GET { $$ = new OptionsListsGetMacroFunctionNode(); }
  | T_FUNC_PAUSE { $$ = new PauseMacroFunctionNode(); }
  | T_FUNC_POKE { $$ = new PokeMacroFunctionNode(); }
  | T_FUNC_PRESS_TOOL { $$ = new PressToolMacroFunctionNode(); }
  | T_FUNC_REFTEXT { $$ = new RefTextMacroFunctionNode(); }
  | T_FUNC_REGISTER { $$ = new RegisterMacroFunctionNode(); }
  | T_FUNC_REGISTER_ID { $$ = new RegisterIdMacroFunctionNode(); }
  | T_FUNC_RELREF { $$ = new RelRefMacroFunctionNode(); }
  | T_FUNC_RENAME_COMMAND { $$ = new RenameCommandMacroFunctionNode(); }
  | T_FUNC_REQUEST { $$ = new RequestMacroFunctionNode(); }
  | T_FUNC_RESET_TOOLBAR { $$ = new ResetToolbarMacroFunctionNode(); }
  | T_FUNC_RESTART { $$ = new RestartMacroFunctionNode(); }
  | T_FUNC_RESULT { $$ = new ResultMacroFunctionNode(); }
  | T_FUNC_RESUME { $$ = new ResumeMacroFunctionNode(); }
  | T_FUNC_RETURN { $$ = new ReturnMacroFunctionNode(); }
  | T_FUNC_SAVE_DIALOG { $$ = new SaveDialogMacroFunctionNode(); }
  | T_FUNC_SAVE_TOOLBAR { $$ = new SaveToolbarMacroFunctionNode(); }
  | T_FUNC_SET_NAME { $$ = new SetNameMacroFunctionNode(); }
  | T_FUNC_SET_VALUE { $$ = new SetValueMacroFunctionNode(); }
  | T_FUNC_SHOW_BAR { $$ = new ShowBarMacroFunctionNode(); }
  | T_FUNC_SPELLING_CHECK { $$ = new SpellingCheckMacroFunctionNode(); }
  | T_FUNC_STEP { $$ = new StepMacroFunctionNode(); }
  | T_FUNC_TERMINATE { $$ = new TerminateMacroFunctionNode(); }
  | T_FUNC_TEXT_BOX { $$ = new TextBoxMacroFunctionNode(); }
  | T_FUNC_UNREGISTER { $$ = new UnregisterMacroFunctionNode(); }
  | T_FUNC_VOLATILE { $$ = new VolatileMacroFunctionNode(); }
  | T_FUNC_WHILE { $$ = new WhileMacroFunctionNode(); }
  | T_FUNC_WINDOW_TITLE { $$ = new WindowTitleMacroFunctionNode(); }
  | T_FUNC_WINDOWS { $$ = new WindowsMacroFunctionNode(); };

command_function_name: T_FUNC_A1_R1C1 { $$ = new A1R1C1CommandFunctionNode(); }
  | T_FUNC_ACTIVATE { $$ = new ActivateCommandFunctionNode(); }
  | T_FUNC_ACTIVATE_NEXT { $$ = new ActivateNextCommandFunctionNode(); }
  | T_FUNC_ACTIVATE_NOTES { $$ = new ActivateNotesCommandFunctionNode(); }
  | T_FUNC_ACTIVATE_PREV { $$ = new ActivatePrevCommandFunctionNode(); }
  | T_FUNC_ACTIVE_CELL_FONT { $$ = new ActiveCellFontCommandFunctionNode(); }
  | T_FUNC_ADD_ARROW { $$ = new AddArrowCommandFunctionNode(); }
  | T_FUNC_ADD_CHART_AUTOFORMAT { $$ = new AddChartAutoFormatCommandFunctionNode(); }
  | T_FUNC_ADD_LIST_ITEM { $$ = new AddListItemCommandFunctionNode(); }
  | T_FUNC_ADD_OVERLAY { $$ = new AddOverlayCommandFunctionNode(); }
  | T_FUNC_ADD_PRINT_AREA { $$ = new AddPrintAreaCommandFunctionNode(); }
  | T_FUNC_ADD_TOOL { $$ = new AddToolCommandFunctionNode(); }
  | T_FUNC_ADDIN_MANAGER { $$ = new AddinManagerCommandFunctionNode(); }
  | T_FUNC_ALERT { $$ = new AlertCommandFunctionNode(); }
  | T_FUNC_ALIGNMENT { $$ = new AlignmentCommandFunctionNode(); }
  | T_FUNC_APP_ACTIVATE { $$ = new AppActivateCommandFunctionNode(); }
  | T_FUNC_APP_ACTIVATE_MICROSOFT { $$ = new AppActivateMicrosoftCommandFunctionNode(); }
  | T_FUNC_APP_MAXIMIZE { $$ = new AppMaximizeCommandFunctionNode(); }
  | T_FUNC_APP_MINIMIZE { $$ = new AppMinimizeCommandFunctionNode(); }
  | T_FUNC_APP_MOVE { $$ = new AppMoveCommandFunctionNode(); }
  | T_FUNC_APP_RESTORE { $$ = new AppRestoreCommandFunctionNode(); }
  | T_FUNC_APP_SIZE { $$ = new AppSizeCommandFunctionNode(); }
  | T_FUNC_APPLY_NAMES { $$ = new ApplyNamesCommandFunctionNode(); }
  | T_FUNC_APPLY_STYLE { $$ = new ApplyStyleCommandFunctionNode(); }
  | T_FUNC_ARRANGE_ALL { $$ = new ArrangeAllCommandFunctionNode(); }
  | T_FUNC_ASSIGN_TO_OBJECT { $$ = new AssignToObjectCommandFunctionNode(); }
  | T_FUNC_ASSIGN_TO_TOOL { $$ = new AssignToToolCommandFunctionNode(); }
  | T_FUNC_ATTACH_TEXT { $$ = new AttachTextCommandFunctionNode(); }
  | T_FUNC_ATTACH_TOOLBARS { $$ = new AttachToolbarsCommandFunctionNode(); }
  | T_FUNC_ATTRIBUTES { $$ = new AttributesCommandFunctionNode(); }
  | T_FUNC_AUTO_OUTLINE { $$ = new AutoOutlineCommandFunctionNode(); }
  | T_FUNC_AUTOCORRECT { $$ = new AutocorrectCommandFunctionNode(); }
  | T_FUNC_AXES { $$ = new AxesCommandFunctionNode(); }
  | T_FUNC_BEEP { $$ = new BeepCommandFunctionNode(); }
  | T_FUNC_BORDER { $$ = new BorderCommandFunctionNode(); }
  | T_FUNC_BRING_TO_FRONT { $$ = new BringToFrontCommandFunctionNode(); }
  | T_FUNC_CALCULATE_DOCUMENT { $$ = new CalculateDocumentCommandFunctionNode(); }
  | T_FUNC_CALCULATE_NOW { $$ = new CalculateNowCommandFunctionNode(); }
  | T_FUNC_CALCULATION { $$ = new CalculationCommandFunctionNode(); }
  | T_FUNC_CANCEL_COPY { $$ = new CancelCopyCommandFunctionNode(); }
  | T_FUNC_CELL_PROTECTION { $$ = new CellProtectionCommandFunctionNode(); }
  | T_FUNC_CHANGE_LINK { $$ = new ChangeLinkCommandFunctionNode(); }
  | T_FUNC_CHART_ADD_DATA { $$ = new ChartAddDataCommandFunctionNode(); }
  | T_FUNC_CHART_TREND { $$ = new ChartTrendCommandFunctionNode(); }
  | T_FUNC_CHART_WIZARD { $$ = new ChartWizardCommandFunctionNode(); }
  | T_FUNC_CHECKBOX_PROPERTIES { $$ = new CheckboxPropertiesCommandFunctionNode(); }
  | T_FUNC_CLEAR { $$ = new ClearCommandFunctionNode(); }
  | T_FUNC_CLEAR_OUTLINE { $$ = new ClearOutlineCommandFunctionNode(); }
  | T_FUNC_CLEAR_PRINT_AREA { $$ = new ClearPrintAreaCommandFunctionNode(); }
  | T_FUNC_CLEAR_ROUTING_SLIP { $$ = new ClearRoutingSlipCommandFunctionNode(); }
  | T_FUNC_CLOSE { $$ = new CloseCommandFunctionNode(); }
  | T_FUNC_CLOSE_ALL { $$ = new CloseAllCommandFunctionNode(); }
  | T_FUNC_COLOR_PALETTE { $$ = new ColorPaletteCommandFunctionNode(); }
  | T_FUNC_COLUMN_WIDTH { $$ = new ColumnWidthCommandFunctionNode(); }
  | T_FUNC_COMBINATION { $$ = new CombinationCommandFunctionNode(); }
  | T_FUNC_CONSOLIDATE { $$ = new ConsolidateCommandFunctionNode(); }
  | T_FUNC_CONSTRAIN_NUMERIC { $$ = new ConstrainNumericCommandFunctionNode(); }
  | T_FUNC_COPY { $$ = new CopyCommandFunctionNode(); }
  | T_FUNC_COPY_CHART { $$ = new CopyChartCommandFunctionNode(); }
  | T_FUNC_COPY_PICTURE { $$ = new CopyPictureCommandFunctionNode(); }
  | T_FUNC_COPY_TOOL { $$ = new CopyToolCommandFunctionNode(); }
  | T_FUNC_CREATE_NAMES { $$ = new CreateNamesCommandFunctionNode(); }
  | T_FUNC_CREATE_PUBLISHER { $$ = new CreatePublisherCommandFunctionNode(); }
  | T_FUNC_CUSTOMIZE_TOOLBAR { $$ = new CustomizeToolbarCommandFunctionNode(); }
  | T_FUNC_CUT { $$ = new CutCommandFunctionNode(); }
  | T_FUNC_DATA_DELETE { $$ = new DataDeleteCommandFunctionNode(); }
  | T_FUNC_DATA_FIND { $$ = new DataFindCommandFunctionNode(); }
  | T_FUNC_DATA_FIND_NEXT { $$ = new DataFindNextCommandFunctionNode(); }
  | T_FUNC_DATA_FIND_PREV { $$ = new DataFindPrevCommandFunctionNode(); }
  | T_FUNC_DATA_FORM { $$ = new DataFormCommandFunctionNode(); }
  | T_FUNC_DATA_LABEL { $$ = new DataLabelCommandFunctionNode(); }
  | T_FUNC_DATA_SERIES { $$ = new DataSeriesCommandFunctionNode(); }
  | T_FUNC_DEFINE_NAME { $$ = new DefineNameCommandFunctionNode(); }
  | T_FUNC_DEFINE_STYLE { $$ = new DefineStyleCommandFunctionNode(); }
  | T_FUNC_DELETE_ARROW { $$ = new DeleteArrowCommandFunctionNode(); }
  | T_FUNC_DELETE_CHART_AUTOFORMAT { $$ = new DeleteChartAutoFormatCommandFunctionNode(); }
  | T_FUNC_DELETE_FORMAT { $$ = new DeleteFormatCommandFunctionNode(); }
  | T_FUNC_DELETE_NAME { $$ = new DeleteNameCommandFunctionNode(); }
  | T_FUNC_DELETE_NOTE { $$ = new DeleteNoteCommandFunctionNode(); }
  | T_FUNC_DELETE_OVERLAY { $$ = new DeleteOverlayCommandFunctionNode(); }
  | T_FUNC_DELETE_STYLE { $$ = new DeleteStyleCommandFunctionNode(); }
  | T_FUNC_DELETE_TOOL { $$ = new DeleteToolCommandFunctionNode(); }
  | T_FUNC_DEMOTE { $$ = new DemoteCommandFunctionNode(); }
  | T_FUNC_DISABLE_INPUT { $$ = new DisableInputCommandFunctionNode(); }
  | T_FUNC_DISPLAY { $$ = new DisplayCommandFunctionNode(); }
  | T_FUNC_DUPLICATE { $$ = new DuplicateCommandFunctionNode(); }
  | T_FUNC_EDIT_COLOR { $$ = new EditColorCommandFunctionNode(); }
  | T_FUNC_EDIT_DELETE { $$ = new EditDeleteCommandFunctionNode(); }
  | T_FUNC_EDIT_OBJECT { $$ = new EditObjectCommandFunctionNode(); }
  | T_FUNC_EDIT_REPEAT { $$ = new EditRepeatCommandFunctionNode(); }
  | T_FUNC_EDIT_SERIES { $$ = new EditSeriesCommandFunctionNode(); }
  | T_FUNC_EDIT_TOOL { $$ = new EditToolCommandFunctionNode(); }
  | T_FUNC_EDITBOX_PROPERTIES { $$ = new EditboxPropertiesCommandFunctionNode(); }
  | T_FUNC_EDITION_OPTIONS { $$ = new EditionOptionsCommandFunctionNode(); }
  | T_FUNC_ENABLE_OBJECT { $$ = new EnableObjectCommandFunctionNode(); }
  | T_FUNC_ENABLE_TIPWIZARD { $$ = new EnableTipwizardCommandFunctionNode(); }
  | T_FUNC_ENTER_DATA { $$ = new EnterDataCommandFunctionNode(); }
  | T_FUNC_ERRORBAR_X { $$ = new ErrorbarXCommandFunctionNode(); }
  | T_FUNC_ERRORBAR_Y { $$ = new ErrorbarYCommandFunctionNode(); }
  | T_FUNC_EXTEND_POLYGON { $$ = new ExtendPolygonCommandFunctionNode(); }
  | T_FUNC_EXTRACT { $$ = new ExtractCommandFunctionNode(); }
  | T_FUNC_FILE_CLOSE { $$ = new FileCloseCommandFunctionNode(); }
  | T_FUNC_FILE_DELETE { $$ = new FileDeleteCommandFunctionNode(); }
  | T_FUNC_FILL_AUTO { $$ = new FillAutoCommandFunctionNode(); }
  | T_FUNC_FILL_DOWN { $$ = new FillDownCommandFunctionNode(); }
  | T_FUNC_FILL_GROUP { $$ = new FillGroupCommandFunctionNode(); }
  | T_FUNC_FILL_LEFT { $$ = new FillLeftCommandFunctionNode(); }
  | T_FUNC_FILL_RIGHT { $$ = new FillRightCommandFunctionNode(); }
  | T_FUNC_FILL_UP { $$ = new FillUpCommandFunctionNode(); }
  | T_FUNC_FILTER_ADVANCED { $$ = new FilterAdvancedCommandFunctionNode(); }
  | T_FUNC_FILTER_SHOW_ALL { $$ = new FilterShowAllCommandFunctionNode(); }
  | T_FUNC_FIND_FILE { $$ = new FindFileCommandFunctionNode(); }
  | T_FUNC_FONT { $$ = new FontCommandFunctionNode(); }
  | T_FUNC_FONT_PROPERTIES { $$ = new FontPropertiesCommandFunctionNode(); }
  | T_FUNC_FORMAT_AUTO { $$ = new FormatAutoCommandFunctionNode(); }
  | T_FUNC_FORMAT_CHART { $$ = new FormatChartCommandFunctionNode(); }
  | T_FUNC_FORMAT_CHARTTYPE { $$ = new FormatCharttypeCommandFunctionNode(); }
  | T_FUNC_FORMAT_FONT { $$ = new FormatFontCommandFunctionNode(); }
  | T_FUNC_FORMAT_LEGEND { $$ = new FormatLegendCommandFunctionNode(); }
  | T_FUNC_FORMAT_MAIN { $$ = new FormatMainCommandFunctionNode(); }
  | T_FUNC_FORMAT_MOVE { $$ = new FormatMoveCommandFunctionNode(); }
  | T_FUNC_FORMAT_NUMBER { $$ = new FormatNumberCommandFunctionNode(); }
  | T_FUNC_FORMAT_OVERLAY { $$ = new FormatOverlayCommandFunctionNode(); }
  | T_FUNC_FORMAT_SHAPE { $$ = new FormatShapeCommandFunctionNode(); }
  | T_FUNC_FORMAT_SIZE { $$ = new FormatSizeCommandFunctionNode(); }
  | T_FUNC_FORMAT_TEXT { $$ = new FormatTextCommandFunctionNode(); }
  | T_FUNC_FORMULA { $$ = new FormulaCommandFunctionNode(); }
  | T_FUNC_FORMULA_ARRAY { $$ = new FormulaArrayCommandFunctionNode(); }
  | T_FUNC_FORMULA_FILL { $$ = new FormulaFillCommandFunctionNode(); }
  | T_FUNC_FORMULA_FIND { $$ = new FormulaFindCommandFunctionNode(); }
  | T_FUNC_FORMULA_FIND_NEXT { $$ = new FormulaFindNextCommandFunctionNode(); }
  | T_FUNC_FORMULA_FIND_PREV { $$ = new FormulaFindPrevCommandFunctionNode(); }
  | T_FUNC_FORMULA_GOTO { $$ = new FormulaGotoCommandFunctionNode(); }
  | T_FUNC_FORMULA_REPLACE { $$ = new FormulaReplaceCommandFunctionNode(); }
  | T_FUNC_FREEZE_PANES { $$ = new FreezePanesCommandFunctionNode(); }
  | T_FUNC_FULL { $$ = new FullCommandFunctionNode(); }
  | T_FUNC_FULL_SCREEN { $$ = new FullScreenCommandFunctionNode(); }
  | T_FUNC_FUNCTION_WIZARD { $$ = new FunctionWizardCommandFunctionNode(); }
  | T_FUNC_GALLERY_3D_AREA { $$ = new Gallery3DAreaCommandFunctionNode(); }
  | T_FUNC_GALLERY_3D_BAR { $$ = new Gallery3DBarCommandFunctionNode(); }
  | T_FUNC_GALLERY_3D_COLUMN { $$ = new Gallery3DColumnCommandFunctionNode(); }
  | T_FUNC_GALLERY_3D_LINE { $$ = new Gallery3DLineCommandFunctionNode(); }
  | T_FUNC_GALLERY_3D_PIE { $$ = new Gallery3DPieCommandFunctionNode(); }
  | T_FUNC_GALLERY_3D_SURFACE { $$ = new Gallery3DSurfaceCommandFunctionNode(); }
  | T_FUNC_GALLERY_AREA { $$ = new GalleryAreaCommandFunctionNode(); }
  | T_FUNC_GALLERY_BAR { $$ = new GalleryBarCommandFunctionNode(); }
  | T_FUNC_GALLERY_COLUMN { $$ = new GalleryColumnCommandFunctionNode(); }
  | T_FUNC_GALLERY_CUSTOM { $$ = new GalleryCustomCommandFunctionNode(); }
  | T_FUNC_GALLERY_DOUGHNUT { $$ = new GalleryDoughnutCommandFunctionNode(); }
  | T_FUNC_GALLERY_LINE { $$ = new GalleryLineCommandFunctionNode(); }
  | T_FUNC_GALLERY_PIE { $$ = new GalleryPieCommandFunctionNode(); }
  | T_FUNC_GALLERY_RADAR { $$ = new GalleryRadarCommandFunctionNode(); }
  | T_FUNC_GALLERY_SCATTER { $$ = new GalleryScatterCommandFunctionNode(); }
  | T_FUNC_GOAL_SEEK { $$ = new GoalSeekCommandFunctionNode(); }
  | T_FUNC_GRIDLINES { $$ = new GridlinesCommandFunctionNode(); }
  | T_FUNC_HIDE { $$ = new HideCommandFunctionNode(); }
  | T_FUNC_HIDE_DIALOG { $$ = new HideDialogCommandFunctionNode(); }
  | T_FUNC_HIDE_OBJECT { $$ = new HideObjectCommandFunctionNode(); }
  | T_FUNC_HIDEALL_INKANNOTS { $$ = new HideallInkannotsCommandFunctionNode(); }
  | T_FUNC_HIDEALL_NOTES { $$ = new HideallNotesCommandFunctionNode(); }
  | T_FUNC_HIDECURR_NOTE { $$ = new HidecurrNoteCommandFunctionNode(); }
  | T_FUNC_HLINE { $$ = new HLineCommandFunctionNode(); }
  | T_FUNC_HPAGE { $$ = new HPageCommandFunctionNode(); }
  | T_FUNC_HSCROLL { $$ = new HscrollCommandFunctionNode(); }
  | T_FUNC_INSERT { $$ = new InsertCommandFunctionNode(); }
  | T_FUNC_INSERT_MAP_OBJECT { $$ = new InsertMapObjectCommandFunctionNode(); }
  | T_FUNC_INSERT_OBJECT { $$ = new InsertObjectCommandFunctionNode(); }
  | T_FUNC_INSERT_PICTURE { $$ = new InsertPictureCommandFunctionNode(); }
  | T_FUNC_INSERT_TITLE { $$ = new InsertTitleCommandFunctionNode(); }
  | T_FUNC_INSERTDATATABLE { $$ = new InsertdatatableCommandFunctionNode(); }
  | T_FUNC_JUSTIFY { $$ = new JustifyCommandFunctionNode(); }
  | T_FUNC_LABEL_PROPERTIES { $$ = new LabelPropertiesCommandFunctionNode(); }
  | T_FUNC_LAYOUT { $$ = new LayoutCommandFunctionNode(); }
  | T_FUNC_LEGEND { $$ = new LegendCommandFunctionNode(); }
  | T_FUNC_LINE_PRINT { $$ = new LinePrintCommandFunctionNode(); }
  | T_FUNC_LINK_COMBO { $$ = new LinkComboCommandFunctionNode(); }
  | T_FUNC_LINK_FORMAT { $$ = new LinkFormatCommandFunctionNode(); }
  | T_FUNC_LIST_NAMES { $$ = new ListNamesCommandFunctionNode(); }
  | T_FUNC_LISTBOX_PROPERTIES { $$ = new ListboxPropertiesCommandFunctionNode(); }
  | T_FUNC_MACRO_OPTIONS { $$ = new MacroOptionsCommandFunctionNode(); }
  | T_FUNC_MAIL_ADD_MAILER { $$ = new MailAddMailerCommandFunctionNode(); }
  | T_FUNC_MAIL_DELETE_MAILER { $$ = new MailDeleteMailerCommandFunctionNode(); }
  | T_FUNC_MAIL_EDIT_MAILER { $$ = new MailEditMailerCommandFunctionNode(); }
  | T_FUNC_MAIL_FORWARD { $$ = new MailForwardCommandFunctionNode(); }
  | T_FUNC_MAIL_LOGOFF { $$ = new MailLogOffCommandFunctionNode(); }
  | T_FUNC_MAIL_LOGON { $$ = new MailLogOnCommandFunctionNode(); }
  | T_FUNC_MAIL_NEXT_LETTER { $$ = new MailNextLetterCommandFunctionNode(); }
  | T_FUNC_MAIL_REPLY { $$ = new MailReplyCommandFunctionNode(); }
  | T_FUNC_MAIL_REPLY_ALL { $$ = new MailReplyAllCommandFunctionNode(); }
  | T_FUNC_MAIL_SEND_MAILER { $$ = new MailSendMailerCommandFunctionNode(); }
  | T_FUNC_MAIN_CHART { $$ = new MainChartCommandFunctionNode(); }
  | T_FUNC_MAIN_CHART_TYPE { $$ = new MainChartTypeCommandFunctionNode(); }
  | T_FUNC_MENU_EDITOR { $$ = new MenuEditorCommandFunctionNode(); }
  | T_FUNC_MERGE_STYLES { $$ = new MergeStylesCommandFunctionNode(); }
  | T_FUNC_MESSAGE { $$ = new MessageCommandFunctionNode(); }
  | T_FUNC_MOVE_BRK { $$ = new MoveBrkCommandFunctionNode(); }
  | T_FUNC_MOVE_TOOL { $$ = new MoveToolCommandFunctionNode(); }
  | T_FUNC_NEW { $$ = new NewCommandFunctionNode(); }
  | T_FUNC_NEW_WINDOW { $$ = new NewWindowCommandFunctionNode(); }
  | T_FUNC_NEWWEBQUERY { $$ = new NewwebqueryCommandFunctionNode(); }
  | T_FUNC_NORMAL { $$ = new NormalCommandFunctionNode(); }
  | T_FUNC_OBJECT_PROPERTIES { $$ = new ObjectPropertiesCommandFunctionNode(); }
  | T_FUNC_OBJECT_PROTECTION { $$ = new ObjectProtectionCommandFunctionNode(); }
  | T_FUNC_ON_DATA { $$ = new OnDataCommandFunctionNode(); }
  | T_FUNC_ON_DOUBLECLICK { $$ = new OnDoubleclickCommandFunctionNode(); }
  | T_FUNC_ON_ENTRY { $$ = new OnEntryCommandFunctionNode(); }
  | T_FUNC_ON_KEY { $$ = new OnKeyCommandFunctionNode(); }
  | T_FUNC_ON_RECALC { $$ = new OnRecalcCommandFunctionNode(); }
  | T_FUNC_ON_SHEET { $$ = new OnSheetCommandFunctionNode(); }
  | T_FUNC_ON_TIME { $$ = new OnTimeCommandFunctionNode(); }
  | T_FUNC_ON_WINDOW { $$ = new OnWindowCommandFunctionNode(); }
  | T_FUNC_OPEN { $$ = new OpenCommandFunctionNode(); }
  | T_FUNC_OPEN_LINKS { $$ = new OpenLinksCommandFunctionNode(); }
  | T_FUNC_OPEN_MAIL { $$ = new OpenMailCommandFunctionNode(); }
  | T_FUNC_OPEN_TEXT { $$ = new OpenTextCommandFunctionNode(); }
  | T_FUNC_OPTIONS_CALCULATION { $$ = new OptionsCalculationCommandFunctionNode(); }
  | T_FUNC_OPTIONS_CHART { $$ = new OptionsChartCommandFunctionNode(); }
  | T_FUNC_OPTIONS_EDIT { $$ = new OptionsEditCommandFunctionNode(); }
  | T_FUNC_OPTIONS_GENERAL { $$ = new OptionsGeneralCommandFunctionNode(); }
  | T_FUNC_OPTIONS_LISTS_ADD { $$ = new OptionsListsAddCommandFunctionNode(); }
  | T_FUNC_OPTIONS_LISTS_DELETE { $$ = new OptionsListsDeleteCommandFunctionNode(); }
  | T_FUNC_OPTIONS_ME { $$ = new OptionsMeCommandFunctionNode(); }
  | T_FUNC_OPTIONS_MENONO { $$ = new OptionsMenonoCommandFunctionNode(); }
  | T_FUNC_OPTIONS_SAVE { $$ = new OptionsSaveCommandFunctionNode(); }
  | T_FUNC_OPTIONS_SPELL { $$ = new OptionsSpellCommandFunctionNode(); }
  | T_FUNC_OPTIONS_TRANSITION { $$ = new OptionsTransitionCommandFunctionNode(); }
  | T_FUNC_OPTIONS_VIEW { $$ = new OptionsViewCommandFunctionNode(); }
  | T_FUNC_OUTLINE { $$ = new OutlineCommandFunctionNode(); }
  | T_FUNC_OVERLAY { $$ = new OverlayCommandFunctionNode(); }
  | T_FUNC_OVERLAY_CHART_TYPE { $$ = new OverlayChartTypeCommandFunctionNode(); }
  | T_FUNC_PAGE_SETUP { $$ = new PageSetupCommandFunctionNode(); }
  | T_FUNC_PARSE { $$ = new ParseCommandFunctionNode(); }
  | T_FUNC_PASTE { $$ = new PasteCommandFunctionNode(); }
  | T_FUNC_PASTE_LINK { $$ = new PasteLinkCommandFunctionNode(); }
  | T_FUNC_PASTE_PICTURE { $$ = new PastePictureCommandFunctionNode(); }
  | T_FUNC_PASTE_PICTURE_LINK { $$ = new PastePictureLinkCommandFunctionNode(); }
  | T_FUNC_PASTE_SPECIAL { $$ = new PasteSpecialCommandFunctionNode(); }
  | T_FUNC_PASTE_TOOL { $$ = new PasteToolCommandFunctionNode(); }
  | T_FUNC_PATTERNS { $$ = new PatternsCommandFunctionNode(); }
  | T_FUNC_PICKLIST { $$ = new PicklistCommandFunctionNode(); }
  | T_FUNC_PIVOT_ADD_FIELDS { $$ = new PivotAddFieldsCommandFunctionNode(); }
  | T_FUNC_PIVOT_FIELD { $$ = new PivotFieldCommandFunctionNode(); }
  | T_FUNC_PIVOT_FIELD_GROUP { $$ = new PivotFieldGroupCommandFunctionNode(); }
  | T_FUNC_PIVOT_FIELD_PROPERTIES { $$ = new PivotFieldPropertiesCommandFunctionNode(); }
  | T_FUNC_PIVOT_FIELD_UNGROUP { $$ = new PivotFieldUngroupCommandFunctionNode(); }
  | T_FUNC_PIVOT_ITEM { $$ = new PivotItemCommandFunctionNode(); }
  | T_FUNC_PIVOT_ITEM_PROPERTIES { $$ = new PivotItemPropertiesCommandFunctionNode(); }
  | T_FUNC_PIVOT_REFRESH { $$ = new PivotRefreshCommandFunctionNode(); }
  | T_FUNC_PIVOT_SHOW_PAGES { $$ = new PivotShowPagesCommandFunctionNode(); }
  | T_FUNC_PIVOT_TABLE_CHART { $$ = new PivotTableChartCommandFunctionNode(); }
  | T_FUNC_PIVOT_TABLE_WIZARD { $$ = new PivotTableWizardCommandFunctionNode(); }
  | T_FUNC_POST_DOCUMENT { $$ = new PostDocumentCommandFunctionNode(); }
  | T_FUNC_PRECISION { $$ = new PrecisionCommandFunctionNode(); }
  | T_FUNC_PREFERRED { $$ = new PreferredCommandFunctionNode(); }
  | T_FUNC_PRINT { $$ = new PrintCommandFunctionNode(); }
  | T_FUNC_PRINT_PREVIEW { $$ = new PrintPreviewCommandFunctionNode(); }
  | T_FUNC_PRINTER_SETUP { $$ = new PrinterSetupCommandFunctionNode(); }
  | T_FUNC_PROMOTE { $$ = new PromoteCommandFunctionNode(); }
  | T_FUNC_PROTECT_DOCUMENT { $$ = new ProtectDocumentCommandFunctionNode(); }
  | T_FUNC_PROTECT_REVISIONS { $$ = new ProtectRevisionsCommandFunctionNode(); }
  | T_FUNC_PUSHBUTTON_PROPERTIES { $$ = new PushbuttonPropertiesCommandFunctionNode(); }
  | T_FUNC_QUIT { $$ = new QuitCommandFunctionNode(); }
  | T_FUNC_REMOVE_LIST_ITEM { $$ = new RemoveListItemCommandFunctionNode(); }
  | T_FUNC_REMOVE_PAGE_BREAK { $$ = new RemovePageBreakCommandFunctionNode(); }
  | T_FUNC_RENAME_OBJECT { $$ = new RenameObjectCommandFunctionNode(); }
  | T_FUNC_REPLACE_FONT { $$ = new ReplaceFontCommandFunctionNode(); }
  | T_FUNC_RESET_TOOL { $$ = new ResetToolCommandFunctionNode(); }
  | T_FUNC_RM_PRINT_AREA { $$ = new RmPrintAreaCommandFunctionNode(); }
  | T_FUNC_ROUTE_DOCUMENT { $$ = new RouteDocumentCommandFunctionNode(); }
  | T_FUNC_ROUTING_SLIP { $$ = new RoutingSlipCommandFunctionNode(); }
  | T_FUNC_ROW_HEIGHT { $$ = new RowHeightCommandFunctionNode(); }
  | T_FUNC_RUN { $$ = new RunCommandFunctionNode(); }
  | T_FUNC_SAVE { $$ = new SaveCommandFunctionNode(); }
  | T_FUNC_SAVE_AS { $$ = new SaveAsCommandFunctionNode(); }
  | T_FUNC_SAVE_COPY_AS { $$ = new SaveCopyAsCommandFunctionNode(); }
  | T_FUNC_SAVE_NEW_OBJECT { $$ = new SaveNewObjectCommandFunctionNode(); }
  | T_FUNC_SAVE_WORKBOOK { $$ = new SaveWorkbookCommandFunctionNode(); }
  | T_FUNC_SAVE_WORKSPACE { $$ = new SaveWorkspaceCommandFunctionNode(); }
  | T_FUNC_SCALE { $$ = new ScaleCommandFunctionNode(); }
  | T_FUNC_SCENARIO_ADD { $$ = new ScenarioAddCommandFunctionNode(); }
  | T_FUNC_SCENARIO_CELLS { $$ = new ScenarioCellsCommandFunctionNode(); }
  | T_FUNC_SCENARIO_DELETE { $$ = new ScenarioDeleteCommandFunctionNode(); }
  | T_FUNC_SCENARIO_EDIT { $$ = new ScenarioEditCommandFunctionNode(); }
  | T_FUNC_SCENARIO_MERGE { $$ = new ScenarioMergeCommandFunctionNode(); }
  | T_FUNC_SCENARIO_SHOW { $$ = new ScenarioShowCommandFunctionNode(); }
  | T_FUNC_SCENARIO_SHOW_NEXT { $$ = new ScenarioShowNextCommandFunctionNode(); }
  | T_FUNC_SCENARIO_SUMMARY { $$ = new ScenarioSummaryCommandFunctionNode(); }
  | T_FUNC_SCROLLBAR_PROPERTIES { $$ = new ScrollbarPropertiesCommandFunctionNode(); }
  | T_FUNC_SELECT { $$ = new SelectCommandFunctionNode(); }
  | T_FUNC_SELECT_ALL { $$ = new SelectAllCommandFunctionNode(); }
  | T_FUNC_SELECT_CHART { $$ = new SelectChartCommandFunctionNode(); }
  | T_FUNC_SELECT_END { $$ = new SelectEndCommandFunctionNode(); }
  | T_FUNC_SELECT_LAST_CELL { $$ = new SelectLastCellCommandFunctionNode(); }
  | T_FUNC_SELECT_LIST_ITEM { $$ = new SelectListItemCommandFunctionNode(); }
  | T_FUNC_SELECT_PLOT_AREA { $$ = new SelectPlotAreaCommandFunctionNode(); }
  | T_FUNC_SELECT_SPECIAL { $$ = new SelectSpecialCommandFunctionNode(); }
  | T_FUNC_SEND_KEYS { $$ = new SendKeysCommandFunctionNode(); }
  | T_FUNC_SEND_MAIL { $$ = new SendMailCommandFunctionNode(); }
  | T_FUNC_SEND_TO_BACK { $$ = new SendToBackCommandFunctionNode(); }
  | T_FUNC_SERIES_AXES { $$ = new SeriesAxesCommandFunctionNode(); }
  | T_FUNC_SERIES_ORDER { $$ = new SeriesOrderCommandFunctionNode(); }
  | T_FUNC_SERIES_X { $$ = new SeriesXCommandFunctionNode(); }
  | T_FUNC_SERIES_Y { $$ = new SeriesYCommandFunctionNode(); }
  | T_FUNC_SET_CONTROL_VALUE { $$ = new SetControlValueCommandFunctionNode(); }
  | T_FUNC_SET_CRITERIA { $$ = new SetCriteriaCommandFunctionNode(); }
  | T_FUNC_SET_DATABASE { $$ = new SetDatabaseCommandFunctionNode(); }
  | T_FUNC_SET_DIALOG_DEFAULT { $$ = new SetDialogDefaultCommandFunctionNode(); }
  | T_FUNC_SET_DIALOG_FOCUS { $$ = new SetDialogFocusCommandFunctionNode(); }
  | T_FUNC_SET_EXTRACT { $$ = new SetExtractCommandFunctionNode(); }
  | T_FUNC_SET_LIST_ITEM { $$ = new SetListItemCommandFunctionNode(); }
  | T_FUNC_SET_PAGE_BREAK { $$ = new SetPageBreakCommandFunctionNode(); }
  | T_FUNC_SET_PREFERRED { $$ = new SetPreferredCommandFunctionNode(); }
  | T_FUNC_SET_PRINT_AREA { $$ = new SetPrintAreaCommandFunctionNode(); }
  | T_FUNC_SET_PRINT_TITLES { $$ = new SetPrintTitlesCommandFunctionNode(); }
  | T_FUNC_SET_UPDATE_STATUS { $$ = new SetUpdateStatusCommandFunctionNode(); }
  | T_FUNC_SHARE { $$ = new ShareCommandFunctionNode(); }
  | T_FUNC_SHARE_NAME { $$ = new ShareNameCommandFunctionNode(); }
  | T_FUNC_SHEET_BACKGROUND { $$ = new SheetBackgroundCommandFunctionNode(); }
  | T_FUNC_SHORT_MENUS { $$ = new ShortMenusCommandFunctionNode(); }
  | T_FUNC_SHOW_ACTIVE_CELL { $$ = new ShowActiveCellCommandFunctionNode(); }
  | T_FUNC_SHOW_CLIPBOARD { $$ = new ShowClipboardCommandFunctionNode(); }
  | T_FUNC_SHOW_DETAIL { $$ = new ShowDetailCommandFunctionNode(); }
  | T_FUNC_SHOW_DIALOG { $$ = new ShowDialogCommandFunctionNode(); }
  | T_FUNC_SHOW_INFO { $$ = new ShowInfoCommandFunctionNode(); }
  | T_FUNC_SHOW_LEVELS { $$ = new ShowLevelsCommandFunctionNode(); }
  | T_FUNC_SHOW_TOOLBAR { $$ = new ShowToolbarCommandFunctionNode(); }
  | T_FUNC_SORT_SPECIAL { $$ = new SortSpecialCommandFunctionNode(); }
  | T_FUNC_SOUND_NOTE { $$ = new SoundNoteCommandFunctionNode(); }
  | T_FUNC_SOUND_PLAY { $$ = new SoundPlayCommandFunctionNode(); }
  | T_FUNC_SPELLING { $$ = new SpellingCommandFunctionNode(); }
  | T_FUNC_SPLIT { $$ = new SplitCommandFunctionNode(); }
  | T_FUNC_STANDARD_FONT { $$ = new StandardFontCommandFunctionNode(); }
  | T_FUNC_STANDARD_WIDTH { $$ = new StandardWidthCommandFunctionNode(); }
  | T_FUNC_STYLE { $$ = new StyleCommandFunctionNode(); }
  | T_FUNC_SUBSCRIBE_TO { $$ = new SubscribeToCommandFunctionNode(); }
  | T_FUNC_SUBTOTAL_CREATE { $$ = new SubtotalCreateCommandFunctionNode(); }
  | T_FUNC_SUBTOTAL_REMOVE { $$ = new SubtotalRemoveCommandFunctionNode(); }
  | T_FUNC_SUMMARY_INFO { $$ = new SummaryInfoCommandFunctionNode(); }
  | T_FUNC_TAB_ORDER { $$ = new TabOrderCommandFunctionNode(); }
  | T_FUNC_TABLE { $$ = new TableCommandFunctionNode(); }
  | T_FUNC_TEXT_TO_COLUMNS { $$ = new TextToColumnsCommandFunctionNode(); }
  | T_FUNC_TRACER_CLEAR { $$ = new TracerClearCommandFunctionNode(); }
  | T_FUNC_TRACER_DISPLAY { $$ = new TracerDisplayCommandFunctionNode(); }
  | T_FUNC_TRACER_ERROR { $$ = new TracerErrorCommandFunctionNode(); }
  | T_FUNC_TRACER_NAVIGATE { $$ = new TracerNavigateCommandFunctionNode(); }
  | T_FUNC_TRAVERSE_NOTES { $$ = new TraverseNotesCommandFunctionNode(); }
  | T_FUNC_UNDO { $$ = new UndoCommandFunctionNode(); }
  | T_FUNC_UNGROUP { $$ = new UngroupCommandFunctionNode(); }
  | T_FUNC_UNGROUP_SHEETS { $$ = new UngroupSheetsCommandFunctionNode(); }
  | T_FUNC_UNHIDE { $$ = new UnhideCommandFunctionNode(); }
  | T_FUNC_UNLOCKED_NEXT { $$ = new UnlockedNextCommandFunctionNode(); }
  | T_FUNC_UNLOCKED_PREV { $$ = new UnlockedPrevCommandFunctionNode(); }
  | T_FUNC_UNPROTECT_REVISIONS { $$ = new UnprotectRevisionsCommandFunctionNode(); }
  | T_FUNC_UPDATE_LINK { $$ = new UpdateLinkCommandFunctionNode(); }
  | T_FUNC_VBA_INSERT_FILE { $$ = new VbaInsertFileCommandFunctionNode(); }
  | T_FUNC_VBA_MAKE_ADDIN { $$ = new VbaMakeAddinCommandFunctionNode(); }
  | T_FUNC_VBA_PROCEDURE_DEFINITION { $$ = new VbaProcedureDefinitionCommandFunctionNode(); }
  | T_FUNC_VBAACTIVATE { $$ = new VbaActivateCommandFunctionNode(); }
  | T_FUNC_VIEW_3D { $$ = new View3DCommandFunctionNode(); }
  | T_FUNC_VIEW_DEFINE { $$ = new ViewDefineCommandFunctionNode(); }
  | T_FUNC_VIEW_DELETE { $$ = new ViewDeleteCommandFunctionNode(); }
  | T_FUNC_VIEW_SHOW { $$ = new ViewShowCommandFunctionNode(); }
  | T_FUNC_VLINE { $$ = new VLineCommandFunctionNode(); }
  | T_FUNC_VPAGE { $$ = new VPageCommandFunctionNode(); }
  | T_FUNC_VSCROLL { $$ = new VscrollCommandFunctionNode(); }
  | T_FUNC_WAIT { $$ = new WaitCommandFunctionNode(); }
  | T_FUNC_WEB_PUBLISH { $$ = new WebPublishCommandFunctionNode(); }
  | T_FUNC_WINDOW_MAXIMIZE { $$ = new WindowMaximizeCommandFunctionNode(); }
  | T_FUNC_WINDOW_MINIMIZE { $$ = new WindowMinimizeCommandFunctionNode(); }
  | T_FUNC_WINDOW_MOVE { $$ = new WindowMoveCommandFunctionNode(); }
  | T_FUNC_WINDOW_RESTORE { $$ = new WindowRestoreCommandFunctionNode(); }
  | T_FUNC_WINDOW_SIZE { $$ = new WindowSizeCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_ACTIVATE { $$ = new WorkbookActivateCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_ADD { $$ = new WorkbookAddCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_COPY { $$ = new WorkbookCopyCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_DELETE { $$ = new WorkbookDeleteCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_HIDE { $$ = new WorkbookHideCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_INSERT { $$ = new WorkbookInsertCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_MOVE { $$ = new WorkbookMoveCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_NAME { $$ = new WorkbookNameCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_NEW { $$ = new WorkbookNewCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_NEXT { $$ = new WorkbookNextCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_OPTIONS { $$ = new WorkbookOptionsCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_PREV { $$ = new WorkbookPrevCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_PROTECT { $$ = new WorkbookProtectCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_SCROLL { $$ = new WorkbookScrollCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_SELECT { $$ = new WorkbookSelectCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_TAB_SPLIT { $$ = new WorkbookTabSplitCommandFunctionNode(); }
  | T_FUNC_WORKBOOK_UNHIDE { $$ = new WorkbookUnhideCommandFunctionNode(); }
  | T_FUNC_WORKGROUP { $$ = new WorkgroupCommandFunctionNode(); }
  | T_FUNC_WORKGROUP_OPTIONS { $$ = new WorkgroupOptionsCommandFunctionNode(); }
  | T_FUNC_WORKSPACE { $$ = new WorkspaceCommandFunctionNode(); }
  | T_FUNC_ZOOM { $$ = new ZoomCommandFunctionNode(); };

worksheet_function_name:
      T_FUNC_FILTER { $$ = new FilterWorksheetFunctionNode(); }
    | T_FUNC_PY { $$ = new PyWorksheetFunctionNode(); }
    | T_FUNC_SORT { $$ = new SortWorksheetFunctionNode(); }
;
%%

public Node root;
internal Parser(OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner scanner) : base(scanner)
{
    scanner.Parser = this;
}
