py_worksheet_function_name:
    xlfn xlws T_FUNC_PY { $$ = new PyFunctionNode($3, $1, $2); }
  | xlfn T_FUNC_PY      { $$ = new PyFunctionNode($2, $1, null); }
  | xlws T_FUNC_PY      { $$ = new PyFunctionNode($2, null, $1); }
  | T_FUNC_PY           { $$ = new PyFunctionNode($1, null, null); }
  ;
worksheet_function_name:
    xlfn xlws T_FUNC_FILTER         { $$ = new FilterWorksheetFunctionNode($3, $1, $2); }
  | xlfn T_FUNC_FILTER              { $$ = new FilterWorksheetFunctionNode($2, $1, null); }
  | xlws T_FUNC_FILTER              { $$ = new FilterWorksheetFunctionNode($2, null, $1); }
  | T_FUNC_FILTER                   { $$ = new FilterWorksheetFunctionNode($1, null, null); }
  | xlfn xlws T_FUNC_SORT           { $$ = new SortWorksheetFunctionNode($3, $1, $2); }
  | xlfn T_FUNC_SORT                { $$ = new SortWorksheetFunctionNode($2, $1, null); }
  | xlws T_FUNC_SORT                { $$ = new SortWorksheetFunctionNode($2, null, $1); }
  | T_FUNC_SORT                     { $$ = new SortWorksheetFunctionNode($1, null, null); }
  | py_worksheet_function_name      { $$ = $1; }
  ;

worksheet_function_name_raw:
     T_FUNC_FILTER { $$ = $1; }
  |  T_FUNC_SORT   { $$ = $1; }
  |  T_FUNC_PY     { $$ = $1; }
  ;
