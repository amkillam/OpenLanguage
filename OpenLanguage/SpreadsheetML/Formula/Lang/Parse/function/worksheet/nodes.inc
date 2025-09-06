
py_worksheet_function_name: opt_xlfn opt_xlws T_FUNC_PY { $$ = new PyFunctionNode($1, $2); };
worksheet_function_name:
    opt_xlfn opt_xlws T_FUNC_FILTER { $$ = new FilterWorksheetFunctionNode($1, $2); }
  | opt_xlfn opt_xlws T_FUNC_SORT   { $$ = new SortWorksheetFunctionNode($1, $2); }
  | py_worksheet_function_name      { $$ = $1; }
  ;
