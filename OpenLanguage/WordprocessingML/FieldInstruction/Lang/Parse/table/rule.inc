A1_column:
    whitespace A1_column { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | A1_column whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_A1_COLUMN {

    // Column is case insensitive in WML, have to store raw string
    // to ensure lossless reconstruction
    string raw = $1;
    ulong parsed =  OpenLanguage.Utils.AlphabeticHexevigesimalProvider.Parse<ulong>(raw);
    if (parsed > 16384UL) {
      throw new System.FormatException("Column reference out of range");
    }
    $$ = new A1AbsoluteColumnNode(parsed, raw); // always absolute
  }
  ;


A1_row:
    whitespace A1_row { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | A1_row whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_A1_ROW { $$ = new A1AbsoluteRowNode($1); }
  ;

A1_cell: A1_column A1_row { $$ = new A1CellNode($1, $2); };


// A cell range where a colon (:) is used to separate the first and last cells in a \
// designated range of cells that has a contiguous rectangular shape. Specifying a row \
// or column's name only as the first and last cell in a range, selects that whole row \
// or column, regardless of the number of rows and columns the table has now or might \
// have in the future.
cell_range: A1_cell colon A1_cell { $$ = new CellRangeNode<A1CellNode, A1CellNode, ulong, A1RowNode, ulong, A1ColumnNode, ulong, A1RowNode, ulong, A1ColumnNode>($1, $2, $3); };

relative_cell_range_keyword_left:
    whitespace relative_cell_range_keyword_left { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | relative_cell_range_keyword_left whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_RELATIVE_CELL_RANGE_KEYWORD_LEFT { $$ = new RelativeCellRangeKeywordLeft(new StringLiteralNode($1)); } // "LEFT"
  ;

relative_cell_range_keyword_right:
    whitespace relative_cell_range_keyword_right { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | relative_cell_range_keyword_right whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_RELATIVE_CELL_RANGE_KEYWORD_RIGHT { $$ = new RelativeCellRangeKeywordRight(new StringLiteralNode($1)); } // "RIGHT"
  ;
relative_cell_range_keyword_above:
    whitespace relative_cell_range_keyword_above { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | relative_cell_range_keyword_above whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_RELATIVE_CELL_RANGE_KEYWORD_ABOVE { $$ = new RelativeCellRangeKeywordAbove(new StringLiteralNode($1)); } // "ABOVE"
  ;
relative_cell_range_keyword_below:
    whitespace relative_cell_range_keyword_below { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | relative_cell_range_keyword_below whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_RELATIVE_CELL_RANGE_KEYWORD_BELOW { $$ = new RelativeCellRangeKeywordBelow(new StringLiteralNode($1)); } // "BELOW"
  ;

relative_cell_range_keyword:
    relative_cell_range_keyword_above { $$ = $1; }
  | relative_cell_range_keyword_below { $$ = $1; }
  | relative_cell_range_keyword_left  { $$ = $1; }
  | relative_cell_range_keyword_right { $$ = $1; }
  ;

table_reference: identifier_or_string   { $$ = new TableReferenceNode($1); };

cell_ref:
    relative_cell_range_keyword { $$ = (CellReferenceNode)$1; }
  | cell_range { $$ = (CellReferenceNode)$1; }
  | A1_cell { $$ = (CellReferenceNode)$1; }
  | left_paren table_reference cell_ref right_paren { $$ = (CellReferenceNode)(new TableCellReferenceNode($1, $2, $3, $4)); }
  ;

cell_ref_list:
    cell_ref_list comma cell_ref { $$ = $1; $$.Separators.Add($2); $$.Items.Add($3); }
  | cell_ref { $$ = new CellReferenceNodeList(new List<CellReferenceNode>() { $1 }, new List<CommaNode>() {} ); }
  ;
