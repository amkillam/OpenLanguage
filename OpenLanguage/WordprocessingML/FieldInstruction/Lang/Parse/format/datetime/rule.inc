datetime_format:
    whitespace datetime_format { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | datetime_format whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | identifier_or_string       { $$ = $1; } // TODO: real date format parsing! Highly critical.
  ;

datetime_formatting_switch: switch_at datetime_format { $$ = new FlaggedArgument<ExpressionNode>($1, $2); };
