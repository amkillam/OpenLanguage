numeric_format:
    whitespace numeric_format { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | numeric_format whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | identifier_or_string      { $$ = $1; } // TODO: real numeric format parsing! Highly critical.
  ;

numeric_formatting_switch: switch_pound numeric_format { $$ = new FlaggedArgument<ExpressionNode>($1, $2); };
