func_abs:
    whitespace func_abs { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_abs whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_ABS { $$ = new AbsFunctionNode(new StringLiteralNode($1)); }
  ;

func_and:
    whitespace func_and { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_and whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_AND { $$ = new AndFunctionNode(new StringLiteralNode($1)); }
  ;

func_average:
    whitespace func_average { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_average whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_AVERAGE { $$ = new AverageFunctionNode(new StringLiteralNode($1)); }
  ;

func_count:
    whitespace func_count { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_count whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_COUNT { $$ = new CountFunctionNode(new StringLiteralNode($1)); }
  ;

func_defined:
    whitespace func_defined { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_defined whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_DEFINED { $$ = new DefinedFunctionNode(new StringLiteralNode($1)); }
  ;

func_false:
    whitespace func_false { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_false whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_FALSE { $$ = new FalseFunctionNode(new StringLiteralNode($1)); }
  ;
func_int:
    whitespace func_int { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_int whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_INT { $$ = new IntFunctionNode(new StringLiteralNode($1)); }
  ;
func_max:
    whitespace func_max { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_max whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_MAX { $$ = new MaxFunctionNode(new StringLiteralNode($1)); }
  ;
func_min:
    whitespace func_min { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_min whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_MIN { $$ = new MinFunctionNode(new StringLiteralNode($1)); }
  ;
func_mod:
    whitespace func_mod { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_mod whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_MOD { $$ = new ModFunctionNode(new StringLiteralNode($1)); }
  ;
func_not:
    whitespace func_not { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_not whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_NOT { $$ = new NotFunctionNode(new StringLiteralNode($1)); }
  ;
func_or:
    whitespace func_or { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_or whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_OR { $$ = new OrFunctionNode(new StringLiteralNode($1)); }
  ;
func_product:
    whitespace func_product { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_product whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_PRODUCT { $$ = new ProductFunctionNode(new StringLiteralNode($1)); }
  ;
func_round:
    whitespace func_round { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_round whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_ROUND { $$ = new RoundFunctionNode(new StringLiteralNode($1)); }
  ;
func_sign:
    whitespace func_sign { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_sign whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_SIGN { $$ = new SignFunctionNode(new StringLiteralNode($1)); }
  ;
func_sum:
    whitespace func_sum { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_sum whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_SUM { $$ = new SumFunctionNode(new StringLiteralNode($1)); }
  ;
func_true:
    whitespace func_true { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_true whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FUNC_TRUE { $$ = new TrueFunctionNode(new StringLiteralNode($1)); }
  ;

// Functions
// Function Description
// ABS(x) Returns the absolute value of x.
// AND(x,y) Returns 1 if the logical expressions x and y are both true; otherwise, it returns 0.
// AVERAGE(list) Returns the average value of the items in list.
// COUNT(list) Returns the number of items in list.
// DEFINED(x) Returns 1 if the expression x is well formed; otherwise, it returns 0.
// FALSE Returns 0.
// INT(x) Returns the value of the integer part of x.
// MAX(list) Returns the largest value in list.
// MIN(list) Returns the smallest value in list.
// MOD(x,y) Returns the value x - ny, for some integer n such that, if y is nonzero, the result has the same sign as x and magnitude less than the magnitude of y. If y is zero, a diagnostic shall be issued. (y need not be a whole number.)
// NOT(x) Returns 0 if the logical expression x is true, or 1 if the expression is false.
// OR(x,y) Returns 1 if either or both logical expressions x and y are true; otherwise, it returns 0.
// PRODUCT(list) Returns the result of multiplying together all members in list.
// ROUND(x,y) Returns the value of x rounded to the specified number of decimal places indicated by floor(y), where floor has the mathematical meaning. If y is negative, any fractional part is discarded and the integer part of the value is rounded to the corresponding power of 10.
// SIGN(x) Returns 1 if x is positive; returns 0 if x is zero; and returns –1 if x is negative.
// SUM(list) Returns the sum of the items in list.
// TRUE Returns 1.

func_abs_call:
    whitespace func_abs_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_abs_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_abs left_paren expression right_paren { $$ = new AbsFunctionCallNode($1, $2, $3, $4); }
  ;

func_and_call:
    whitespace func_and_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_and_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_and left_paren expression comma expression right_paren { $$ = new AndFunctionCallNode($1, $2, $3, $4, $5, $6); }
  ;

//   ## 2.16.3.4 Functions
//
// A function is a predefined procedure that computes and returns a result. \
//   Functions defined below with a parameter list of list accept two or more arguments separated by commas (,) or semicolons (;). \
//   As to which separator is permitted, is defined by the document's listSeparator (§2.15.1.56) element. Arguments to functions can be constants, formulas, \
//   or bookmark names that refer to constants or formulas. The functions AVERAGE, COUNT, MAX, MIN, PRODUCT, and SUM can also accept references to table cells as \
//   arguments. In the context of a table cell, functions taking a list also accept a single argument that designates a named-list of contiguous cells (§2.16.3.5). \
//   Function names are not case-sensitive, and white space can occur between a function's name and its argument list, if any.
expr_list:
    expr_list whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace expr_list { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | cell_ref_list { $$ = $1; }
  | expr_list comma expression { $$ = $1; $$.Separators.Add($2); $$.Items.Add($3); }
  | expr_list semicolon expression { $$ = $1; $$.Separators.Add($2); $$.Items.Add($3); }
  | expression { $$ = new ExpressionListNode(new List<ExpressionNode>() { $1 }, new List<SeparatorNode>()); }
  ;
func_average_call:
    whitespace func_average_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_average_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_average left_paren expr_list right_paren { $$ = new AverageFunctionCallNode($1, $2, $3, $4); }
  ;

func_count_call:
    whitespace func_count_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_count_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_count left_paren expr_list right_paren { $$ = new CountFunctionCallNode($1, $2, $3, $4); }
  ;

func_defined_call:
    whitespace func_defined_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_defined_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_defined left_paren expression right_paren { $$ = new DefinedFunctionCallNode($1, $2, $3, $4); }
  ;
func_false_call:
    whitespace func_false_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_false_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_false left_paren right_paren   { $$ = new FalseFunctionCallNode($1, $2, $3); }
  | func_false                 { $$ = new FalseFunctionCallNode($1, null, null); } // constant `FALSE` value or `FALSE()`
  ;
func_int_call:
    whitespace func_int_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_int_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_int left_paren expression right_paren { $$ = new IntFunctionCallNode($1, $2, $3, $4); }
  ;

func_max_call:
    whitespace func_max_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_max_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_max left_paren expr_list right_paren { $$ = new MaxFunctionCallNode($1, $2, $3, $4); }
  ;
func_min_call:
    whitespace func_min_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_min_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_min left_paren expr_list right_paren { $$ = new MinFunctionCallNode($1, $2, $3, $4); }
  ;
func_mod_call:
    whitespace func_mod_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_mod_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_mod left_paren expression comma expression right_paren { $$ = new ModFunctionCallNode($1, $2, $3, $4, $5, $6); }
  ;
func_not_call:
    whitespace func_not_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_not_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_not left_paren expression right_paren { $$ = new NotFunctionCallNode($1, $2, $3, $4); }
  ;
func_or_call:
    whitespace func_or_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_or_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_or left_paren expression comma expression right_paren { $$ = new OrFunctionCallNode($1, $2, $3, $4, $5, $6); }
  ;
func_product_call:
    whitespace func_product_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_product_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_product left_paren expr_list right_paren { $$ = new ProductFunctionCallNode($1, $2, $3, $4); }
  ;
func_round_call:
    whitespace func_round_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_round_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_round left_paren expression comma expression right_paren { $$ = new RoundFunctionCallNode($1, $2, $3, $4, $5, $6); }
  ;
func_sign_call:
    whitespace func_sign_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_sign_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_sign left_paren expression right_paren { $$ = new SignFunctionCallNode($1, $2, $3, $4); }
  ;
func_sum_call:
    whitespace func_sum_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_sum_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_sum left_paren expr_list right_paren { $$ = new SumFunctionCallNode($1, $2, $3, $4); }
  ;
func_true_call:
    whitespace func_true_call { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | func_true_call whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | func_true left_paren right_paren   { $$ = new TrueFunctionCallNode($1, $2, $3); }
  | func_true                 { $$ = new TrueFunctionCallNode($1, null, null); } // constant `TRUE` value or `TRUE()`
  ;

func_call:
    func_abs_call { $$ = $1; }
  | func_and_call { $$ = $1; }
  | func_average_call { $$ = $1; }
  | func_count_call { $$ = $1; }
  | func_defined_call { $$ = $1; }
  | func_false_call { $$ = $1; }
  | func_int_call { $$ = $1; }
  | func_max_call { $$ = $1; }
  | func_min_call { $$ = $1; }
  | func_mod_call { $$ = $1; }
  | func_not_call { $$ = $1; }
  | func_or_call { $$ = $1; }
  | func_product_call { $$ = $1; }
  | func_round_call { $$ = $1; }
  | func_sign_call { $$ = $1; }
  | func_sum_call { $$ = $1; }
  | func_true_call { $$ = $1; }
  ;
