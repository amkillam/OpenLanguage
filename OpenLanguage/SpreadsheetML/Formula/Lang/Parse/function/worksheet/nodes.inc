worksheet_function_name:
    T_FUNC_FILTER { $$ = new FilterWorksheetFunctionNode(); }
  | T_FUNC_PY     { $$ = new PyWorksheetFunctionNode(); }
  | T_FUNC_SORT   { $$ = new SortWorksheetFunctionNode(); }
  ;
