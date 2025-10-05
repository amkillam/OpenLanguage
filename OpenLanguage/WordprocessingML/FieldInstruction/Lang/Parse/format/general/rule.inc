general_format:
    whitespace general_format { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | general_format whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | identifier_or_string      { $$ = $1; } // TODO: real general format parsing! Highly critical.
  ;

general_formatting_switch:
    whitespace general_formatting_switch { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | general_formatting_switch whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | switch_asterisk mergeformat          { $$ = new FlaggedArgument<ExpressionNode>($1, $2); }
  | switch_asterisk charformat           { $$ = new FlaggedArgument<ExpressionNode>($1, $2); }
  | switch_asterisk general_format       { $$ = new FlaggedArgument<ExpressionNode>($1, $2); }
  ;
