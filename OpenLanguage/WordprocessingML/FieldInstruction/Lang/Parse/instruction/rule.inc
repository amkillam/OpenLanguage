addressblock_field_instruction:
    whitespace addressblock_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | addressblock_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | addressblock_field_instruction switch_c country_region_incl
      {
          $$ = $1;
          $$.CountryRegionInclusionSetting = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(AddressBlockArgument.CountryRegionInclusionSetting);
      }
  | addressblock_field_instruction switch_d
      {
          $$ = $1;
          $$.FormatByRecipientCountry = $2;
          $$.Order.Add(AddressBlockArgument.FormatByRecipientCountry);
      }
  | addressblock_field_instruction switch_e expression
      {
          $$ = $1;
          $$.ExcludedCountriesRegions.Add(new FlaggedArgument<ExpressionNode>($2, $3));
          $$.Order.Add(AddressBlockArgument.ExcludedCountriesRegions);
      }
  | addressblock_field_instruction switch_f addressblock_template
      {
          $$ = $1;
          $$.FormatTemplate = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(AddressBlockArgument.FormatTemplate);
      }
  | addressblock_field_instruction switch_l language_identifier
      {
          $$ = $1;
          $$.LanguageId = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(AddressBlockArgument.LanguageId);
      }
  | T_ADDRESSBLOCK_INSTRUCTION
      {
          $$ = new AddressBlockFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              new System.Collections.Generic.List<FlaggedArgument<OpenLanguage.WordprocessingML.Ast.ExpressionNode>>(),
              null,
              null,
              new System.Collections.Generic.List<AddressBlockArgument>()
          );
      }
  ;
advance_field_instruction:
    whitespace advance_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | advance_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | advance_field_instruction switch_d argument_expression { $$ = $1; $$.DownByPoints = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(AdvanceArgument.DownByPoints); }
  | advance_field_instruction switch_l argument_expression { $$ = $1; $$.LeftByPoints = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(AdvanceArgument.LeftByPoints); }
  | advance_field_instruction switch_r argument_expression { $$ = $1; $$.RightByPoints = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(AdvanceArgument.RightByPoints); }
  | advance_field_instruction switch_u argument_expression { $$ = $1; $$.UpByPoints = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(AdvanceArgument.UpByPoints); }
  | advance_field_instruction switch_x argument_expression { $$ = $1; $$.HorizontalPosition = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(AdvanceArgument.HorizontalPosition); }
  | advance_field_instruction switch_y argument_expression { $$ = $1; $$.VerticalPosition = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(AdvanceArgument.VerticalPosition); }
  | advance_field_instruction general_formatting_switch { $$ = $1; $$.GeneralFormat = $2; $$.Order.Add(AdvanceArgument.GeneralFormat); }
  | advance_field_instruction numeric_formatting_switch { $$ = $1; $$.NumericFormat = $2; $$.Order.Add(AdvanceArgument.NumericFormat); }
  | T_ADVANCE_INSTRUCTION
      {
          $$ = new AdvanceFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null, null, null, null, null,
              new System.Collections.Generic.List<AdvanceArgument>()
          );
      }
  ;
ask_field_instruction:
    whitespace ask_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | ask_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | ask_field_instruction switch_d expression
      {
          $$ = $1;
          $$.DefaultText = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(AskFieldInstruction.AskArgument.DefaultText);
      }
  | ask_field_instruction switch_d
      {
          $$ = $1;
          $$.DefaultText = new FlaggedArgument<ExpressionNode>($2, new EmptyExpressionNode());
          $$.Order.Add(AskFieldInstruction.AskArgument.DefaultText);
      }
  | ask_field_instruction switch_o
      {
          $$ = $1;
          $$.PromptOnce = $2;
          $$.Order.Add(AskFieldInstruction.AskArgument.PromptOnce);
      }
  | ask_field_instruction expression
      {
          $$ = $1;
          if ($$.BookmarkName == null)
          {
              $$.BookmarkName = $2;
              $$.Order.Add(AskFieldInstruction.AskArgument.BookmarkName);
          }
          else if ($$.PromptText == null)
          {
              $$.PromptText = $2;
              $$.Order.Add(AskFieldInstruction.AskArgument.PromptText);
          }
      }
  | T_ASK_INSTRUCTION
      {
          $$ = new AskFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              null,
              null,
              new System.Collections.Generic.List<AskFieldInstruction.AskArgument>()
          );
      }
  ;
author_field_instruction:
    whitespace author_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | author_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | author_field_instruction expression
      {
          $$ = $1;
          if ($$.NewAuthorName == null)
          {
              $$.NewAuthorName = $2;
          }
      }
  | author_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
      }
  | T_AUTHOR_INSTRUCTION
      { $$ = new AuthorFieldInstruction(new StringLiteralNode($1)); }
  ;
autonum_field_instruction:
    whitespace autonum_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | autonum_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | autonum_field_instruction switch_s expression
      {
          $$ = $1;
          $$.Separator = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(AutoNumArgument.Separator);
      }
  | T_AUTONUM_INSTRUCTION
      {
          $$ = new AutoNumFieldInstruction(
              new StringLiteralNode($1),
              null,
              new System.Collections.Generic.List<AutoNumArgument>()
          );
      }
  ;
autonumlgl_field_instruction:
    whitespace autonumlgl_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | autonumlgl_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | autonumlgl_field_instruction bool_switch_e
      {
          $$ = $1;
          $$.RemoveTrailingSeparator = $2;
          $$.Order.Add(AutoNumLglArgument.RemoveTrailingSeparator);
      }
  | autonumlgl_field_instruction switch_s expression
      {
          $$ = $1;
          $$.Separator = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(AutoNumLglArgument.Separator);
      }
  | T_AUTONUMLGL_INSTRUCTION
      { $$ = new AutoNumLglFieldInstruction(new StringLiteralNode($1)); }
  ;
autonumout_field_instruction:
    whitespace autonumout_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | autonumout_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_AUTONUMOUT_INSTRUCTION { $$ = new AutoNumOutFieldInstruction(new StringLiteralNode($1)); }
  ;
autotext_field_instruction:
    whitespace autotext_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | autotext_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | autotext_field_instruction expression
      {
          $$ = $1;
          if ($$.EntryName == null)
          {
              $$.EntryName = $2;
          }
      }
  | T_AUTOTEXT_INSTRUCTION { $$ = new AutoTextFieldInstruction(new StringLiteralNode($1)); }
  ;
autotextlist_field_instruction:
    whitespace autotextlist_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | autotextlist_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | autotextlist_field_instruction switch_s expression
      {
          $$ = $1;
          $$.StyleFilter = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(AutoTextListArgument.StyleFilter);
      }
  | autotextlist_field_instruction switch_t expression
      {
          $$ = $1;
          $$.ScreenTip = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(AutoTextListArgument.ScreenTip);
      }
  | autotextlist_field_instruction expression
      {
          $$ = $1;
          if ($$.EntryName == null)
          {
              $$.EntryName = $2;
              $$.Order.Add(AutoTextListArgument.EntryName);
          }
      }
  | T_AUTOTEXTLIST_INSTRUCTION
      {
          $$ = new AutoTextListFieldInstruction(
              new StringLiteralNode($1),
              null, null, null,
              new System.Collections.Generic.List<AutoTextListArgument>()
          );
      }
  ;
barcode_field_instruction:
    whitespace barcode_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | barcode_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | barcode_field_instruction expression
      {
          $$ = $1;
          if ($$.Data == null)
          {
              $$.Data = $2;
              $$.Order.Add(BarcodeArgument.Data);
          }
      }
  | barcode_field_instruction braced_field_instruction
      {
          $$ = $1;
          if ($$.Data == null)
          {
              $$.Data = $2;
              $$.Order.Add(BarcodeArgument.Data);
          }
      }
  | barcode_field_instruction switch_f facing_identification_mark_type
      {
          $$ = $1;
          $$.FacingIdentificationMark = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(BarcodeArgument.Facing);
      }
  | barcode_field_instruction switch_b
      {
          $$ = $1;
          $$.DataIsBookmarkName = $2;
          $$.Order.Add(BarcodeArgument.DataIsBookmarkName);
      }
  | barcode_field_instruction switch_u
      {
          $$ = $1;
          $$.UseUSPostalAddress = $2;
          $$.Order.Add(BarcodeArgument.UseUSPostalAddress);
      }
  | T_BARCODE_INSTRUCTION
      {
          $$ = new BarcodeFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              null,
              null,
              new System.Collections.Generic.List<BarcodeArgument>()
          );
      }
  ;

facing_identification_mark_type:
    whitespace facing_identification_mark_type { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | facing_identification_mark_type whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote facing_identification_mark_type quote { $$ = new Quoted<ExpressionNode>($1, $2, $3); }
  | T_FIM_COURTESY_REPLY { $$ = new FacingIdentificationMarkTypeNode(FacingIdentificationMarkType.CourtesyReply, $1); }
  | T_FIM_BUSINESS_REPLY { $$ = new FacingIdentificationMarkTypeNode(FacingIdentificationMarkType.BusinessReply, $1); }
  ;

bibliography_field_instruction:
    whitespace bibliography_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | bibliography_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | bibliography_field_instruction switch_l language_identifier
      {
          $$ = $1;
          $$.Locale = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(BibliographyArgument.Locale);
      }
  | bibliography_field_instruction switch_f language_identifier
      {
          $$ = $1;
          $$.FilterLocale = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(BibliographyArgument.FilterLocale);
      }
  | bibliography_field_instruction switch_m expression
      {
          $$ = $1;
          $$.SingleSourceTag = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(BibliographyArgument.SingleSourceTag);
      }
  | T_BIBLIOGRAPHY_INSTRUCTION
      { $$ = new BibliographyFieldInstruction(new StringLiteralNode($1)); }
  ;
bidioutline_field_instruction:
    whitespace bidioutline_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | bidioutline_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_BIDIOUTLINE_INSTRUCTION
      { $$ = new BidiOutlineFieldInstruction(new StringLiteralNode($1)); }
  ;
citation_field_instruction:
    whitespace citation_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | citation_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | citation_field_instruction expression
      {
          $$ = $1;
          if ($$.SourceTag == null)
          {
              $$.SourceTag = $2;
              $$.Order.Add(CitationArgument.SourceTag);
          }
      }
  | citation_field_instruction switch_l language_identifier
      {
          $$ = $1;
          $$.Locale = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(CitationArgument.Locale);
      }
  | citation_field_instruction switch_f expression
      {
          $$ = $1;
          $$.Prefix = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(CitationArgument.Prefix);
      }
  | citation_field_instruction switch_s expression
      {
          $$ = $1;
          $$.Suffix = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(CitationArgument.Suffix);
      }
  | citation_field_instruction switch_p expression
      {
          $$ = $1;
          $$.PageNumber = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(CitationArgument.PageNumber);
      }
  | citation_field_instruction switch_v expression
      {
          $$ = $1;
          $$.VolumeNumber = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(CitationArgument.VolumeNumber);
      }
  | citation_field_instruction switch_n
      {
          $$ = $1;
          $$.SuppressAuthor = $2;
          $$.Order.Add(CitationArgument.SuppressAuthor);
      }
  | citation_field_instruction switch_t
      {
          $$ = $1;
          $$.SuppressTitle = $2;
          $$.Order.Add(CitationArgument.SuppressTitle);
      }
  | citation_field_instruction switch_y
      {
          $$ = $1;
          $$.SuppressYear = $2;
          $$.Order.Add(CitationArgument.SuppressYear);
      }
  | citation_field_instruction switch_m expression
      {
          $$ = $1;
          $$.AdditionalSourceTag = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(CitationArgument.AdditionalSourceTag);
      }
  | T_CITATION_INSTRUCTION
      {
          $$ = new CitationFieldInstruction(
              new StringLiteralNode($1),
              null, // SourceTag
              null, // Locale
              null, // Prefix
              null, // Suffix
              null, // PageNumber
              null, // VolumeNumber
              null, // SuppressAuthor
              null, // SuppressTitle
              null, // SuppressYear
              null, // AdditionalSourceTag
              new System.Collections.Generic.List<CitationArgument>()
          );
      }
  ;
comments_field_instruction:
    whitespace comments_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | comments_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | comments_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(CommentsArgument.GeneralFormat);
      }
  | comments_field_instruction expression
      {
          $$ = $1;
          if ($$.Value == null)
          {
              $$.Value = $2;
              $$.Order.Add(CommentsArgument.Value);
          }
      }
  | T_COMMENTS_INSTRUCTION { $$ = new CommentsFieldInstruction(new StringLiteralNode($1), null, null, new List<CommentsArgument>()); }
  ;
compare_field_instruction:
    whitespace compare_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | compare_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_COMPARE_INSTRUCTION compare_expression { $$ = new CompareFieldInstruction(new StringLiteralNode($1), $2); }
  ;

compare_expression:
    compare_expression whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace compare_expression { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | expression  equal                 expression { $$ = new EqualNode($1, $2, $3); }
  | expression  not_equal              expression { $$ = new NotEqualNode($1, $2, $3); }
  | expression  less_than              expression { $$ = new LessThanNode($1, $2, $3); }
  | expression  less_than_or_equal     expression { $$ = new LessThanOrEqualNode($1, $2, $3); }
  | expression  greater_than           expression { $$ = new GreaterThanNode($1, $2, $3); }
  | expression  greater_than_or_equal  expression { $$ = new GreaterThanOrEqualNode($1, $2, $3); }
  ;
createdate_field_instruction:
    whitespace createdate_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | createdate_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | createdate_field_instruction switch_h
      {
          $$ = $1;
          $$.UseHijriCalendar = $2;
          $$.Order.Add(CreateDateArgument.UseHijriCalendar);
      }
  | createdate_field_instruction bool_switch_s
      {
          $$ = $1;
          $$.UseSakaCalendar = $2;
          $$.Order.Add(CreateDateArgument.UseSakaCalendar);
      }
  | createdate_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(CreateDateArgument.DateTimeFormat);
      }
  | createdate_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(CreateDateArgument.GeneralFormat);
      }
  |  T_CREATEDATE_INSTRUCTION
      {
          $$ = new CreateDateFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null,
              new System.Collections.Generic.List<CreateDateArgument>()
          );
      }
  ;
date_field_instruction:
    whitespace date_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | date_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | date_field_instruction switch_h
      {
          $$ = $1;
          $$.UseHijriCalendar = $2;
          $$.Order.Add(DateArgument.UseHijri);
      }
  | date_field_instruction bool_switch_s
      {
          $$ = $1;
          $$.UseSakaCalendar = $2;
          $$.Order.Add(DateArgument.UseSaka);
      }
  | date_field_instruction switch_l
      {
          $$ = $1;
          $$.UseLastUsedFormat = $2;
          $$.Order.Add(DateArgument.UseLastUsed);
      }
  | date_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(DateArgument.DateTimeFormat);
      }
  | date_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(DateArgument.GeneralFormat);
      }
  |  T_DATE_INSTRUCTION
      {
          $$ = new DateFieldInstruction(
              new StringLiteralNode($1),
              null,  // UseHijriCalendar
              null,  // UseSakaCalendar
              null,  // UseLastUsedFormat
              null,  // DateTimeFormat
              null,  // GeneralFormat
              new System.Collections.Generic.List<DateArgument>()
          );
      }
  ;

dde_field_instruction:
    whitespace dde_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | dde_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | dde_field_instruction switch_a { $$ = $1; $$.AutoUpdate = $2; $$.Order.Add(DdeArgument.AutoUpdate); }
  | dde_field_instruction switch_b { $$ = $1; $$.Bitmap = $2; $$.Order.Add(DdeArgument.Bitmap); }
  | dde_field_instruction switch_d { $$ = $1; $$.NoStore = $2; $$.Order.Add(DdeArgument.NoStore); }
  | dde_field_instruction switch_h { $$ = $1; $$.Html = $2; $$.Order.Add(DdeArgument.Html); }
  | dde_field_instruction switch_p { $$ = $1; $$.Picture = $2; $$.Order.Add(DdeArgument.Picture); }
  | dde_field_instruction switch_r { $$ = $1; $$.Rtf = $2; $$.Order.Add(DdeArgument.Rtf); }
  | dde_field_instruction switch_t { $$ = $1; $$.Text = $2; $$.Order.Add(DdeArgument.Text); }
  | dde_field_instruction switch_u { $$ = $1; $$.Unicode = $2; $$.Order.Add(DdeArgument.Unicode); }
  | dde_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(DdeArgument.GeneralFormat);
      }
  | dde_field_instruction expression
      {
          $$ = $1;
          if ($$.ApplicationName == null) {
              $$.ApplicationName = $2;
              $$.Order.Add(DdeArgument.ApplicationName);
          }
          else if ($$.FileName == null) {
              $$.FileName = $2;
              $$.Order.Add(DdeArgument.FileName);
          } else if ($$.BookmarkName == null) {
              $$.BookmarkName = $2;
              $$.Order.Add(DdeArgument.BookmarkName);
          }
      }
  | T_DDE_INSTRUCTION
      { $$ = new DdeFieldInstruction(new StringLiteralNode($1), null, null, null, null, null, null, null, null, null, null, null, null, null, null, new List<DdeArgument>()); }
  ;

ddeauto_field_instruction:
    whitespace ddeauto_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | ddeauto_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | ddeauto_field_instruction switch_b { $$ = $1; $$.Bitmap = $2; $$.Order.Add(DdeAutoArgument.Bitmap); }
  | ddeauto_field_instruction switch_d { $$ = $1; $$.NoStore = $2; $$.Order.Add(DdeAutoArgument.NoStore); }
  | ddeauto_field_instruction switch_h { $$ = $1; $$.Html = $2; $$.Order.Add(DdeAutoArgument.Html); }
  | ddeauto_field_instruction switch_p { $$ = $1; $$.Picture = $2; $$.Order.Add(DdeAutoArgument.Picture); }
  | ddeauto_field_instruction switch_r { $$ = $1; $$.Rtf = $2; $$.Order.Add(DdeAutoArgument.Rtf); }
  | ddeauto_field_instruction switch_t { $$ = $1; $$.Text = $2; $$.Order.Add(DdeAutoArgument.Text); }
  | ddeauto_field_instruction switch_u { $$ = $1; $$.Unicode = $2; $$.Order.Add(DdeAutoArgument.Unicode); }
  | ddeauto_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(OpenLanguage.WordprocessingML.FieldInstruction.Ast.DdeAutoArgument.GeneralFormat);
      }
  | ddeauto_field_instruction expression
      {
          $$ = $1;
          if ($$.ApplicationName == null) {
              $$.ApplicationName = $2;
              $$.Order.Add(OpenLanguage.WordprocessingML.FieldInstruction.Ast.DdeAutoArgument.ApplicationName);
          } else if ($$.FileName == null) {
              $$.FileName = $2;
              $$.Order.Add(OpenLanguage.WordprocessingML.FieldInstruction.Ast.DdeAutoArgument.FileName);
          } else if ($$.BookmarkName == null) {
              $$.BookmarkName = $2;
              $$.Order.Add(OpenLanguage.WordprocessingML.FieldInstruction.Ast.DdeAutoArgument.BookmarkName);
          }
      }
  | T_DDEAUTO_INSTRUCTION
      { $$ = new DdeAutoFieldInstruction(new StringLiteralNode($1), null, null, null, null, null, null, null, null, null, null, null, null, null, new List<OpenLanguage.WordprocessingML.FieldInstruction.Ast.DdeAutoArgument>()); }
  ;

database_table_attributes:
    whitespace database_table_attributes { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | database_table_attributes whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_INTEGER { $$ = new DatabaseTableAttributesNode((DatabaseTableAttributes)int.Parse($1, System.Globalization.CultureInfo.InvariantCulture), $1); }
  ;

database_table_format:
    whitespace database_table_format { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | database_table_format whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_INTEGER { $$ = new DatabaseTableFormatNode((DatabaseTableFormat)int.Parse($1, System.Globalization.CultureInfo.InvariantCulture), $1); }
  ;

database_field_instruction:
    whitespace database_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | database_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | database_field_instruction switch_b database_table_attributes
      {
          $$ = $1;
          $$.TableAttributes = new FlaggedArgument<DatabaseTableAttributesNode>($2, $3);
          $$.Order.Add(DatabaseArgument.TableAttributes);
      }
      // NOTE: need to change this to expression to allow evaluated database connection strings
      // DO NOT use `ToString` or `ToRawString`. Instead, just have OdbcConnectionStringNode take
      // an `ExpressionNode` in its constructor.
  | database_field_instruction switch_c identifier_or_string
      {
          $$ = $1;
          $$.ConnectionString = new FlaggedArgument<OdbcConnectionStringNode>($2, new OdbcConnectionStringNode($3));
          $$.Order.Add(DatabaseArgument.ConnectionString);
      }
  | database_field_instruction switch_d expression
      {
          $$ = $1;
          $$.DatabasePath = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(DatabaseArgument.DatabasePath);
      }
  | database_field_instruction switch_f integer
      {
          $$ = $1;
          $$.FirstRecord = new FlaggedArgument<NumericLiteralNode<int>>($2, $3);
          $$.Order.Add(DatabaseArgument.FirstRecord);
      }
  | database_field_instruction switch_h
      {
          $$ = $1;
          $$.IncludeHeaders = $2;
          $$.Order.Add(DatabaseArgument.IncludeHeaders);
      }
  | database_field_instruction switch_l database_table_format
      {
          $$ = $1;
          $$.TableFormat = new FlaggedArgument<DatabaseTableFormatNode>($2, $3);
          $$.Order.Add(DatabaseArgument.TableFormat);
      }
  | database_field_instruction switch_o optimization_flag
      {
          $$ = $1;
          $$.OptimizationFlag = new FlaggedArgument<DatabaseOptimizationFlagNode>($2, $3);
          $$.Order.Add(DatabaseArgument.OptimizationFlag);
      }
  | database_field_instruction switch_s expression
      {
          $$ = $1;
          $$.DatabaseQueryInstruction = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(DatabaseArgument.DatabaseQueryInstruction);
      }
  | database_field_instruction switch_t integer
      {
          $$ = $1;
          $$.LastRecord = new FlaggedArgument<NumericLiteralNode<int>>($2, $3);
          $$.Order.Add(DatabaseArgument.LastRecord);
      }
  | T_DATABASE_INSTRUCTION
      {
          $$ = new DatabaseFieldInstruction(
              new StringLiteralNode($1),
              null, // TableAttributes
              null, // ConnectionString
              null, // DatabasePath
              null, // FirstRecord
              null, // IncludeHeaders
              null, // TableFormat
              null, // OptimizationFlag
              null, // DatabaseQueryInstruction
              null, // LastRecord
              new System.Collections.Generic.List<DatabaseArgument>()
          );
      }
  ;

docproperty_field_instruction:
    whitespace docproperty_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | docproperty_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | docproperty_field_instruction info_category
      {
          $$ = $1;
          $$.PropertyName = $2;
          $$.Order.Add(DocPropertyArgument.PropertyName);
      }
  | docproperty_field_instruction expression
      {
          $$ = $1;
          if ($$.PropertyName == null) {
              $$.PropertyName = $2;
              $$.Order.Add(DocPropertyArgument.PropertyName);
          } else if ($$.PropertyCategoryArgument == null) {
              $$.PropertyCategoryArgument = $2;
              $$.Order.Add(DocPropertyArgument.PropertyCategoryArgument);
          }
      }
  | docproperty_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormats.Add($2);
          $$.Order.Add(DocPropertyArgument.GeneralFormat);
      }
  | docproperty_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(DocPropertyArgument.NumericFormat);
      }
  | docproperty_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(DocPropertyArgument.DateTimeFormat);
      }
  | docproperty_field_instruction switch_h
      {
          $$ = $1;
          $$.HyperlinkSwitch = $2;
          $$.Order.Add(DocPropertyArgument.HyperlinkSwitch);
      }
  | T_DOCPROPERTY_INSTRUCTION
      {
          $$ = new DocPropertyFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              new List<FlaggedArgument<ExpressionNode>>(),
              null,
              null,
              null,
              new System.Collections.Generic.List<DocPropertyArgument>()
          );
      }
  ;
docvariable_field_instruction:
    whitespace docvariable_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | docvariable_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | docvariable_field_instruction expression
      {
          $$ = $1;
          if ($$.VariableName == null)
          {
              $$.VariableName = $2;
          }
      }
  | T_DOCVARIABLE_INSTRUCTION { $$ = new DocVariableFieldInstruction(new StringLiteralNode($1)); }
  ;
edittime_field_instruction:
    whitespace edittime_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | edittime_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | edittime_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(EditTimeArgument.GeneralFormat);
      }
  | edittime_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(EditTimeArgument.NumericFormat);
      }
  | T_EDITTIME_INSTRUCTION
      {
          $$ = new EditTimeFieldInstruction(
              new StringLiteralNode($1),
              null, null,
              new System.Collections.Generic.List<EditTimeArgument>()
          );
      }
  ;
eq_field_instruction:
    whitespace eq_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | eq_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | eq_field_instruction switch_ac
      {
          $$ = $1;
          if ($$.ArrayAlignment == null && $$.OverlayAlignment == null)
          {
              $$.ArrayAlignment = new FlaggedArgument<EqArrayAlignmentNode>($2, new EqArrayAlignmentNode(EqArrayAlignment.Center));
              $$.Order.Add(EqArgument.ArrayAlignment);
          }
          else if ($$.ArrayAlignment != null && $$.OverlayAlignment == null)
          {
              $$.OverlayAlignment = new FlaggedArgument<EqOverlayAlignmentNode>($2, new EqOverlayAlignmentNode(EqOverlayAlignment.Center));
              $$.Order.Add(EqArgument.OverlayAlignment);
          }
      }
  | eq_field_instruction switch_al
      {
          $$ = $1;
          if ($$.ArrayAlignment == null && $$.OverlayAlignment == null)
          {
              $$.ArrayAlignment = new FlaggedArgument<EqArrayAlignmentNode>($2, new EqArrayAlignmentNode(EqArrayAlignment.Left));
              $$.Order.Add(EqArgument.ArrayAlignment);
          }
          else if ($$.ArrayAlignment != null && $$.OverlayAlignment == null)
          {
              $$.OverlayAlignment = new FlaggedArgument<EqOverlayAlignmentNode>($2, new EqOverlayAlignmentNode(EqOverlayAlignment.Left));
              $$.Order.Add(EqArgument.OverlayAlignment);
          }
      }
  | eq_field_instruction switch_ar
      {
          $$ = $1;
          if ($$.ArrayAlignment == null && $$.OverlayAlignment == null)
          {
              $$.ArrayAlignment = new FlaggedArgument<EqArrayAlignmentNode>($2, new EqArrayAlignmentNode(EqArrayAlignment.Right));
              $$.Order.Add(EqArgument.ArrayAlignment);
          }
          else if ($$.ArrayAlignment != null && $$.OverlayAlignment == null)
          {
              $$.OverlayAlignment = new FlaggedArgument<EqOverlayAlignmentNode>($2, new EqOverlayAlignmentNode(EqOverlayAlignment.Right));
              $$.Order.Add(EqArgument.OverlayAlignment);
          }
      }
  | eq_field_instruction switch_co expression
      {
          $$ = $1;
          $$.ColumnCount = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.ColumnCount);
      }
  | eq_field_instruction switch_hs expression
      {
          $$ = $1;
          $$.HorizontalSpacing = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.HorizontalSpacing);
      }
  | eq_field_instruction switch_vs expression
      {
          $$ = $1;
          $$.VerticalSpacing = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.VerticalSpacing);
      }
  | eq_field_instruction switch_bc char_arg
      {
          $$ = $1;
          $$.BothBracketCharacter = new FlaggedArgument<CharacterLiteralNode>($2, $3);
          $$.Order.Add(EqArgument.BothBracketCharacter);
      }
  | eq_field_instruction switch_lc char_arg
      {
          $$ = $1;
          $$.LeftBracketCharacter = new FlaggedArgument<CharacterLiteralNode>($2, $3);
          $$.Order.Add(EqArgument.LeftBracketCharacter);
      }
  | eq_field_instruction switch_rc char_arg
      {
          $$ = $1;
          $$.RightBracketCharacter = new FlaggedArgument<CharacterLiteralNode>($2, $3);
          $$.Order.Add(EqArgument.RightBracketCharacter);
      }
  | eq_field_instruction switch_ba expression
      {
          $$ = $1;
          $$.BackwardDisplacement = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.BackwardDisplacement);
      }
  | eq_field_instruction switch_fo expression
      {
          $$ = $1;
          $$.ForwardDisplacement = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.ForwardDisplacement);
      }
  | eq_field_instruction switch_fc char_arg
      {
          $$ = $1;
          $$.FixedHeightCharacter = new FlaggedArgument<CharacterLiteralNode>($2, $3);
          $$.Order.Add(EqArgument.FixedHeightCharacter);
      }
  | eq_field_instruction switch_vc char_arg
      {
          $$ = $1;
          $$.VariableHeightCharacter = new FlaggedArgument<CharacterLiteralNode>($2, $3);
          $$.Order.Add(EqArgument.VariableHeightCharacter);
      }
  | eq_field_instruction switch_ai expression
      {
          $$ = $1;
          $$.SpaceAboveLine = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.SpaceAboveLine);
      }
  | eq_field_instruction switch_di expression
      {
          $$ = $1;
          $$.SpaceBelowLine = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.SpaceBelowLine);
      }
  | eq_field_instruction switch_do expression
      {
          $$ = $1;
          $$.MoveDown = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.MoveDown);
      }
  | eq_field_instruction switch_up expression
      {
          $$ = $1;
          $$.MoveUp = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(EqArgument.MoveUp);
      }
  | eq_field_instruction switch_pr
      {
          $$ = $1;
          $$.IntegralSymbol = new FlaggedArgument<EqIntegralSymbolNode>($2, new EqIntegralSymbolNode(EqIntegralSymbol.Product));
          $$.Order.Add(EqArgument.IntegralSymbol);
      }
  | eq_field_instruction switch_su
      {
          $$ = $1;
          $$.IntegralSymbol = new FlaggedArgument<EqIntegralSymbolNode>($2, new EqIntegralSymbolNode(EqIntegralSymbol.Summation));
          $$.Order.Add(EqArgument.IntegralSymbol);
      }
  | eq_field_instruction switch_li
      {
          $$ = $1;
          $$.UnderlineSpace = $2;
          $$.Order.Add(EqArgument.UnderlineSpace);
      }
  | eq_field_instruction switch_in
      {
          $$ = $1;
          $$.InlineFormat = $2;
          $$.Order.Add(EqArgument.InlineFormat);
      }
  | eq_field_instruction switch_bo
      {
          $$ = $1;
          $$.BorderBottom = $2;
          $$.Order.Add(EqArgument.BorderBottom);
      }
  | eq_field_instruction switch_le
      {
          $$ = $1;
          $$.BorderLeft = $2;
          $$.Order.Add(EqArgument.BorderLeft);
      }
  | eq_field_instruction switch_ri
      {
          $$ = $1;
          $$.BorderRight = $2;
          $$.Order.Add(EqArgument.BorderRight);
      }
  | eq_field_instruction switch_to
      {
          $$ = $1;
          $$.BorderTop = $2;
          $$.Order.Add(EqArgument.BorderTop);
      }
  | T_EQ_INSTRUCTION
      {
          $$ = new EqFieldInstruction(
              new StringLiteralNode($1),
              null, new List<ExpressionNode>(),
              null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
              new System.Collections.Generic.List<EqArgument>()
          );
      }
  | eq_field_instruction switch_a { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction switch_b { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction switch_d { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction switch_f { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction switch_i { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction switch_l { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction switch_o { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction switch_r { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction bool_switch_s { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction switch_x { $$ = $1; $$.PrimarySwitch = $2; $$.Order.Add(EqArgument.PrimarySwitch); }
  | eq_field_instruction left_paren eq_argument_list right_paren
      {
          $$ = $1;
          $$.ArgumentList = $3.Items;
          $$.LeftParen = $2;
          $$.RightParen = $4;
          $$.ArgumentSeparators = $3.Separators;
          $$.Order.Add(EqArgument.ArgumentList);
      }
  | eq_field_instruction eq_argument_list
      {
          $$ = $1;
          $$.ArgumentList = $2.Items;
          $$.ArgumentSeparators = $2.Separators;
          $$.Order.Add(EqArgument.ArgumentList);
      }
  ;


eq_argument_list:
    eq_argument_list whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace eq_argument_list { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | eq_argument_list comma expression
      {
          $$ = $1;
          $$.Separators.Add($2);
          $$.Items.Add($3);
      }
  | eq_argument_list semicolon expression
      {
          $$ = $1;
          $$.Separators.Add($2);
          $$.Items.Add($3);
      }
  | expression
      {
          $$ = new EqArgumentList
          {
              Items = new System.Collections.Generic.List<ExpressionNode> { $1 },
              Separators = new System.Collections.Generic.List<CharacterLiteralNode>()
          };
      }
  ;
filename_field_instruction:
    whitespace filename_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | filename_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | filename_field_instruction general_formatting_switch { $$ = $1; $$.GeneralFormat = $2; }
  | filename_field_instruction switch_p { $$ = $1; $$.IncludeFullPath = $2; }
  | T_FILENAME_INSTRUCTION { $$ = new FileNameFieldInstruction(new StringLiteralNode($1), null, null); }
  ;
filesize_field_instruction:
    whitespace filesize_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | filesize_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | filesize_field_instruction switch_k
      {
          $$ = $1;
          if ($$.InKilobytes == null)
          {
              $$.InKilobytes = $2;
              $$.Order.Add(FileSizeArgument.InKilobytes);
          }
      }
  | filesize_field_instruction switch_m
      {
          $$ = $1;
          if ($$.InMegabytes == null)
          {
              $$.InMegabytes = $2;
              $$.Order.Add(FileSizeArgument.InMegabytes);
          }
      }
  | filesize_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(FileSizeArgument.GeneralFormat);
      }
  | filesize_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(FileSizeArgument.NumericFormat);
      }
  | T_FILESIZE_INSTRUCTION
      {
          $$ = new FileSizeFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null,
              new System.Collections.Generic.List<FileSizeArgument>()
          );
      }
  ;
fillin_field_instruction:
    whitespace fillin_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | fillin_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | fillin_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(FillInArgument.GeneralFormat);
      }
  | fillin_field_instruction switch_d expression
      {
          $$ = $1;
          $$.DefaultText = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(FillInArgument.DefaultText);
      }
      // 1" can be represented as `"`
  | fillin_field_instruction switch_d quote
      {
          $$ = $1;
          $$.DefaultText = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(FillInArgument.DefaultText);
      }
  | fillin_field_instruction switch_d
      {
          $$ = $1;
          $$.DefaultText = new FlaggedArgument<ExpressionNode>($2, new EmptyExpressionNode());
          $$.Order.Add(FillInArgument.DefaultText);
      }
  | fillin_field_instruction switch_o
      {
          $$ = $1;
          $$.PromptOnce = $2;
          $$.Order.Add(FillInArgument.PromptOnce);
      }
  | fillin_field_instruction expression
      {
          $$ = $1;
          $$.PromptText = $2;
          $$.Order.Add(FillInArgument.PromptText);
      }
  | T_FILLIN_INSTRUCTION
      {
          $$ = new FillInFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null,
              new System.Collections.Generic.List<FillInArgument>()
          );
      }
  ;
formcheckbox_field_instruction:
    whitespace formcheckbox_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | formcheckbox_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FORMCHECKBOX_INSTRUCTION { $$ = new FormCheckBoxFieldInstruction(new StringLiteralNode($1)); }
  ;
formdropdown_field_instruction:
    whitespace formdropdown_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | formdropdown_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FORMDROPDOWN_INSTRUCTION { $$ = new FormDropDownFieldInstruction(new StringLiteralNode($1)); }
  ;
formtext_field_instruction:
    whitespace formtext_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | formtext_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_FORMTEXT_INSTRUCTION { $$ = new FormTextFieldInstruction(new StringLiteralNode($1)); }
  ;
gotobutton_field_instruction:
    whitespace gotobutton_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | gotobutton_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | gotobutton_field_instruction whitespace gotobutton_argument
      {
          $$ = $1;
          $3.LeadingWhitespace.Insert(0, $2);
          if ($$.TargetLocation == null)
          {
              $$.TargetLocation = $3;
              $$.Order.Add(GoToButtonArgument.TargetLocation);
          }
          else if ($$.ButtonDisplayContent == null)
          {
              $$.ButtonDisplayContent = $3;
              $$.Order.Add(GoToButtonArgument.ButtonDisplayContent);
          }
      }
  | gotobutton_field_instruction whitespace gotobutton_argument
      {
          $$ = $1;
          $3.LeadingWhitespace.Insert(0, $2);
          if ($$.TargetLocation == null)
          {
              $$.TargetLocation = $3;
              $$.Order.Add(GoToButtonArgument.TargetLocation);
          }
          else if ($$.ButtonDisplayContent == null)
          {
              $$.ButtonDisplayContent = $3;
              $$.Order.Add(GoToButtonArgument.ButtonDisplayContent);
          }
      }
  | gotobutton_field_instruction gotobutton_argument
      {
          $$ = $1;
          if ($$.TargetLocation == null)
          {
              $$.TargetLocation = $2;
              $$.Order.Add(GoToButtonArgument.TargetLocation);
          }
          else if ($$.ButtonDisplayContent == null)
          {
              $$.ButtonDisplayContent = $2;
              $$.Order.Add(GoToButtonArgument.ButtonDisplayContent);
          }
      }
  | T_GOTOBUTTON_INSTRUCTION
      {
          $$ = new GoToButtonFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              new System.Collections.Generic.List<GoToButtonArgument>()
          );
      }
  ;

gotobutton_argument:
    T_PERCENT integer { $$ = new PercentPrefixedNode(new PercentLiteralNode($1), $2); }
  | primary { $$ = $1; }
  ;

glossary_instruction:
    whitespace glossary_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | glossary_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_GLOSSARY_INSTRUCTION expression
      { $$ = new GlossaryInstruction(new StringLiteralNode($1), $2); }
  | T_GLOSSARY_INSTRUCTION
      { $$ = new GlossaryInstruction(new StringLiteralNode($1), null); }
  ;

import_instruction:
    whitespace import_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | import_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | import_instruction switch_c expression
      {
          $$ = $1;
          $$.GraphicsFilterName = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(ImportArgument.GraphicsFilterName);
      }
  | import_instruction switch_d
      {
          $$ = $1;
          $$.ReduceFileSize = $2;
          $$.Order.Add(ImportArgument.ReduceFileSize);
      }
  | import_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(ImportArgument.GeneralFormat);
      }
  | import_instruction expression
      {
          $$ = $1;
          if ($$.PictureFilePath == null)
          {
              $$.PictureFilePath = $2;
              $$.Order.Add(ImportArgument.PictureFilePath);
          }
      }
  | T_IMPORT_INSTRUCTION
      {
          $$ = new ImportInstruction(
              new StringLiteralNode($1),
              null, null, null, null,
              new System.Collections.Generic.List<ImportArgument>()
          );
      }
  ;

greetingline_field_instruction:
    whitespace greetingline_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | greetingline_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | greetingline_field_instruction switch_e expression
      {
          $$ = $1;
          $$.BlankNameText = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(GreetingLineArgument.BlankNameText);
      }
  | greetingline_field_instruction switch_c expression
      {
          $$ = $1;
          $$.BlankNameText = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(GreetingLineArgument.BlankNameText);
      }
  | greetingline_field_instruction switch_f expression
      {
          $$ = $1;
          $$.Format = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(GreetingLineArgument.Format);
      }
  | greetingline_field_instruction switch_l expression
      {
          $$ = $1;
          $$.LanguageId = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(GreetingLineArgument.LanguageId);
      }
  | T_GREETINGLINE_INSTRUCTION
      {
          $$ = new GreetingLineFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              null,
              new System.Collections.Generic.List<GreetingLineArgument>()
          );
      }
  ;

hyperlink_field_instruction:
    whitespace hyperlink_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | hyperlink_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | hyperlink_field_instruction switch_l expression
      {
          $$ = $1;
          $$.InternalLocation = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(HyperlinkArgument.InternalLocation);
      }
  | hyperlink_field_instruction switch_n
      {
          $$ = $1;
          $$.NewWindow = $2;
          $$.Order.Add(HyperlinkArgument.NewWindow);
      }
  | hyperlink_field_instruction switch_m
      {
          $$ = $1;
          $$.ServerSideImageMapAppendCoordinates = new FlaggedArgument<ExpressionNode>($2, new EmptyExpressionNode());
          $$.Order.Add(HyperlinkArgument.ServerSideImageMapAppendCoordinates);
      }
  | hyperlink_field_instruction switch_m float_list
      {
          $$ = $1;
          $$.ServerSideImageMapAppendCoordinates = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(HyperlinkArgument.ServerSideImageMapAppendCoordinates);
      }
  | hyperlink_field_instruction switch_o expression
      {
          $$ = $1;
          $$.ScreenTipText = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(HyperlinkArgument.ScreenTipText);
      }
  | hyperlink_field_instruction switch_t expression
      {
          $$ = $1;
          $$.InstrFrameTarget = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(HyperlinkArgument.InstrFrameTarget);
      }
  | hyperlink_field_instruction switch_t frame_target
      {
          $$ = $1;
          $$.InstrFrameTarget = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(HyperlinkArgument.InstrFrameTarget);
      }
  | hyperlink_field_instruction switch_s expression
      {
          $$ = $1;
          $$.ArbLocation = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(HyperlinkArgument.ArbLocation);
      }
  | hyperlink_field_instruction switch_c integer
      {
          $$ = $1;
          $$.UndocumentedC = new FlaggedArgument<NumericLiteralNode<int>>((FlagNode)$2, $3);
          $$.Order.Add(HyperlinkArgument.UndocumentedC);
      }
  | hyperlink_field_instruction expression
      {
          $$ = $1;
          if ($$.Uri == null)
          {
              $$.Uri = $2;
              $$.Order.Add(HyperlinkArgument.Uri);
          }
          else if ($$.DisplayText == null)
          {
              $$.DisplayText = $2;
              $$.Order.Add(HyperlinkArgument.DisplayText);
          }
      }
  | T_HYPERLINK_INSTRUCTION
    {
      $$ = new HyperlinkFieldInstruction(
            new StringLiteralNode($1),
            null, null, null, null, null, null, null, null, null,
            new System.Collections.Generic.List<HyperlinkArgument>()
        );
    }
  ;

include_instruction:
    whitespace include_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | include_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | include_instruction switch_exclamation
      {
          $$ = $1;
          $$.PreventUpdateUnlessFieldsUpdated = new BoolFlagNode($2);
          $$.Order.Add(IncludeArgument.PreventUpdateUnlessFieldsUpdated);
      }
  | include_instruction switch_c expression
      {
          $$ = $1;
          $$.DocumentFilterName = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(IncludeArgument.DocumentFilterName);
      }
  | include_instruction expression
      {
          $$ = $1;
          if ($$.DocumentName == null)
          {
              $$.DocumentName = $2;
              $$.Order.Add(IncludeArgument.DocumentName);
          }
          else if ($$.BookmarkName == null)
          {
              $$.BookmarkName = $2;
              $$.Order.Add(IncludeArgument.BookmarkName);
          }
      }
  | T_INCLUDE_INSTRUCTION
      {
          $$ = new IncludeFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null,
              new System.Collections.Generic.List<IncludeArgument>()
          );
      }
  ;
if_field_instruction:
    whitespace if_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | if_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_IF_INSTRUCTION expression expression expression { $$ = new IfFieldInstruction(new StringLiteralNode($1), $2, $3, $4, new System.Collections.Generic.List<IfArgument>() { IfArgument.Condition, IfArgument.TrueExpression, IfArgument.FalseExpression }); }
  | T_IF_INSTRUCTION expression expression { $$ = new IfFieldInstruction(new StringLiteralNode($1), $2, $3, null, new System.Collections.Generic.List<IfArgument>() { IfArgument.Condition, IfArgument.TrueExpression }); }
  | T_IF_INSTRUCTION expression { $$ = new IfFieldInstruction(new StringLiteralNode($1), $2, null, null, new System.Collections.Generic.List<IfArgument>() { IfArgument.Condition }); }
  | T_IF_INSTRUCTION { $$ = new IfFieldInstruction(new StringLiteralNode($1), null, null, null, new System.Collections.Generic.List<IfArgument>()); }
  ;

argument_expression:
    primary { $$ = $1; }
  | argument_expression primary
    {
        if ($1 is ConcatenatedNodes cn)
        {
            cn.Add($2);
            $$ = cn;
        }
        else
        {
            $$ = new ConcatenatedNodes(new List<ExpressionNode> { $1, $2 });
        }
    }
  ;

includepicture_field_instruction:
    whitespace includepicture_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | includepicture_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | includepicture_field_instruction switch_c expression
      {
          $$ = $1;
          $$.GraphicsFilterName = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(IncludePictureArgument.GraphicsFilterName);
      }
  | includepicture_field_instruction switch_d
      {
          $$ = $1;
          $$.ReduceFileSize = $2;
          $$.Order.Add(IncludePictureArgument.ReduceFileSize);
      }
  | T_INCLUDEPICTURE_INSTRUCTION expression
      {
          $$ = new IncludePictureFieldInstruction(
              new StringLiteralNode($1),
              $2,
              null,
              null,
              new System.Collections.Generic.List<IncludePictureArgument>() { IncludePictureArgument.PictureFilePath }
          );
      }
  ;

includetext_field_instruction:
    whitespace includetext_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | includetext_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | includetext_field_instruction switch_exclamation
      {
          $$ = $1;
          $$.PreventUpdateUnlessFieldsUpdated = $2;
          $$.Order.Add(IncludeTextArgument.PreventUpdateUnlessFieldsUpdated);
      }
  | includetext_field_instruction switch_c expression
      {
          $$ = $1;
          $$.DocumentFilterName = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(IncludeTextArgument.DocumentFilterName);
      }
  | includetext_field_instruction switch_n_flag namespace_decl
      {
          $$ = $1;
          $$.NamespaceMapping = new FlaggedArgument<OpenLanguage.WordprocessingML.FieldInstruction.Ast.NamespaceDeclarationNode>($2, $3);
          $$.Order.Add(IncludeTextArgument.NamespaceMapping);
      }
  | includetext_field_instruction xslt_path
      {
          $$ = $1;
          $$.XsltPath = $2;
          $$.Order.Add(IncludeTextArgument.XsltPath);
      }
  | includetext_field_instruction xpath
      {
          $$ = $1;
          $$.XPathExpression = $2;
          $$.Order.Add(IncludeTextArgument.XPathExpression);
      }
  | includetext_field_instruction expression
      {
          $$ = $1;
          if ($$.DocumentName == null)
          {
              $$.DocumentName = $2;
              $$.Order.Add(IncludeTextArgument.DocumentName);
          }
          else if ($$.BookmarkName == null)
          {
              $$.BookmarkName = $2;
              $$.Order.Add(IncludeTextArgument.BookmarkName);
          }
      }
  | T_INCLUDETEXT_INSTRUCTION
      {
          $$ = new IncludeTextFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              null,
              null,
              null,
              null,
              null,
              new System.Collections.Generic.List<IncludeTextArgument>()
          );
      }
  ;
index_field_instruction:
    whitespace index_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | index_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | index_field_instruction switch_b expression
      { $$ = $1; $$.BookmarkName = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.BookmarkName); }
  | index_field_instruction switch_c integer
      { $$ = $1; $$.NumberOfColumns = new FlaggedArgument<NumericLiteralNode<int>>($2, $3); $$.Order.Add(IndexArgument.NumberOfColumns); }
  | index_field_instruction switch_d expression
      { $$ = $1; $$.SequencePageSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.SequencePageSeparator); }
  | index_field_instruction switch_e expression
      { $$ = $1; $$.EntryPageSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.EntryPageSeparator); }
  | index_field_instruction switch_f expression
      { $$ = $1; $$.EntryTypeFilter = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.EntryTypeFilter); }
  | index_field_instruction switch_g expression
      { $$ = $1; $$.PageRangeSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.PageRangeSeparator); }
  | index_field_instruction switch_h expression
      { $$ = $1; $$.IndexHeadingText = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.IndexHeadingText); }
  | index_field_instruction switch_k expression
      { $$ = $1; $$.CrossReferenceSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.CrossReferenceSeparator); }
  | index_field_instruction switch_l expression
      { $$ = $1; $$.PageNumberSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.PageNumberSeparator); }
  | index_field_instruction switch_p expression
      { $$ = $1; $$.LetterRange = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.LetterRange); }
  | index_field_instruction switch_r
      { $$ = $1; $$.UseRunInFormat = $2; $$.Order.Add(IndexArgument.UseRunInFormat); }
  | index_field_instruction switch_s expression
      { $$ = $1; $$.SequenceName = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.SequenceName); }
  | index_field_instruction switch_y
      { $$ = $1; $$.EnableYomiText = $2; $$.Order.Add(IndexArgument.EnableYomiText); }
  | index_field_instruction switch_z language_identifier
      { $$ = $1; $$.LanguageId = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(IndexArgument.LanguageId); }
  | T_INDEX_INSTRUCTION
      {
          $$ = new IndexFieldInstruction(
              new StringLiteralNode($1),
              null,null,null,null,null,null,null,null,null,null,
              null,null,null,null,
              new System.Collections.Generic.List<IndexArgument>()
          );
      }
  ;
info_category:
    info_category whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace info_category { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | T_AUTHOR_INSTRUCTION      { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.Author); }
  | T_COMMENTS_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.Comments); }
  | T_CREATEDATE_INSTRUCTION  { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.CreateDate); }
  | T_EDITTIME_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.EditTime); }
  | T_FILENAME_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.FileName); }
  | T_FILESIZE_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.FileSize); }
  | T_KEYWORDS_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.Keywords); }
  | T_LASTSAVEDBY_INSTRUCTION { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.LastSavedBy); }
  | T_NUMCHARS_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.NumChars); }
  | T_NUMPAGES_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.NumPages); }
  | T_NUMWORDS_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.NumWords); }
  | T_PRINTDATE_INSTRUCTION   { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.PrintDate); }
  | T_REVNUM_INSTRUCTION      { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.RevNum); }
  | T_SAVEDATE_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.SaveDate); }
  | T_SUBJECT_INSTRUCTION     { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.Subject); }
  | T_TEMPLATE_INSTRUCTION    { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.Template); }
  | T_TITLE_INSTRUCTION       { $$ = new OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeNode(OpenLanguage.WordprocessingML.FieldInstruction.InfoType.Title); }
  ;

info_field_instruction:
    T_INFO_INSTRUCTION info_category
      { $$ = new InfoFieldInstruction(new StringLiteralNode($1), (InfoTypeNode)$2, null, null, null, null, null, null, null, null, null, new List<InfoArgument>() { InfoArgument.InformationCategory }); }
  | info_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace info_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | info_field_instruction expression
      {
          $$ = $1;
          if ($$.FieldArgument == null)
          {
              $$.FieldArgument = $2;
              $$.Order.Add(InfoArgument.FieldArgument);
          }
      }
  | info_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(InfoArgument.GeneralFormat);
      }
  | info_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(InfoArgument.NumericFormat);
      }
  | info_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(InfoArgument.DateTimeFormat);
      }
  | info_field_instruction switch_h { $$ = $1; $$.UseHijriCalendar = $2; $$.Order.Add(InfoArgument.UseHijriCalendar); }
  | info_field_instruction bool_switch_s { $$ = $1; $$.UseSakaCalendar = $2; $$.Order.Add(InfoArgument.UseSakaCalendar); }
  | info_field_instruction switch_p { $$ = $1; $$.IncludeFullPath = $2; $$.Order.Add(InfoArgument.IncludeFullPath); }
  | info_field_instruction switch_k { $$ = $1; $$.InKilobytes = $2; $$.Order.Add(InfoArgument.InKilobytes); }
  | info_field_instruction switch_m { $$ = $1; $$.InMegabytes = $2; $$.Order.Add(InfoArgument.InMegabytes); }
  ;
keywords_field_instruction:
    T_KEYWORDS_INSTRUCTION { $$ = new KeywordsFieldInstruction(new StringLiteralNode($1), null, null, null, null, new List<KeywordsArgument>()); }
  | keywords_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace keywords_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | keywords_field_instruction expression
      {
          $$ = $1;
          $$.FieldArgument = $2;
          $$.Order.Add(KeywordsArgument.FieldArgument);
      }
  | keywords_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(KeywordsArgument.GeneralFormat);
      }
  | keywords_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(KeywordsArgument.NumericFormat);
      }
  | keywords_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(KeywordsArgument.DateTimeFormat);
      }
  ;
lastsavedby_field_instruction:
    whitespace lastsavedby_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | lastsavedby_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | lastsavedby_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(LastSavedByArgument.GeneralFormat);
      }
  | lastsavedby_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(LastSavedByArgument.NumericFormat);
      }
  | lastsavedby_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(LastSavedByArgument.DateTimeFormat);
      }
  | T_LASTSAVEDBY_INSTRUCTION { $$ = new LastSavedByFieldInstruction(new StringLiteralNode($1), null, null, null, new List<LastSavedByArgument>()); }
  ;

link_formatting_mode:
    whitespace link_formatting_mode { $$ = $2; $$.LeadingWhitespace.Add($1); }
  | link_formatting_mode whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_INTEGER                       { $$ = new LinkFormattingModeNode((LinkFormattingMode)int.Parse($1, System.Globalization.CultureInfo.InvariantCulture)); }
  ;

link_field_instruction:
    whitespace link_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | link_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | link_field_instruction switch_a
      {
          $$ = $1;
          $$.AutomaticallyUpdate = $2;
          $$.Order.Add(LinkArgument.AutomaticallyUpdate);
      }
  | link_field_instruction switch_b
      {
          $$ = $1;
          $$.InsertAsBitmap = $2;
          $$.Order.Add(LinkArgument.InsertAsBitmap);
      }
  | link_field_instruction switch_d
      {
          $$ = $1;
          $$.DontStoreGraphicData = $2;
          $$.Order.Add(LinkArgument.DontStoreGraphicData);
      }
  | link_field_instruction switch_f link_formatting_mode
      {
          $$ = $1;
          $$.FormattingMode = new FlaggedArgument<LinkFormattingModeNode>($2, $3);
          $$.Order.Add(LinkArgument.FormattingMode);
      }
  | link_field_instruction switch_h
      {
          $$ = $1;
          $$.InsertAsHtml = $2;
          $$.Order.Add(LinkArgument.InsertAsHtml);
      }
  | link_field_instruction switch_p
      {
          $$ = $1;
          $$.InsertAsPicture = $2;
          $$.Order.Add(LinkArgument.InsertAsPicture);
      }
  | link_field_instruction switch_r
      {
          $$ = $1;
          $$.InsertAsRtf = $2;
          $$.Order.Add(LinkArgument.InsertAsRtf);
      }
  | link_field_instruction switch_t
      {
          $$ = $1;
          $$.InsertAsTextOnly = $2;
          $$.Order.Add(LinkArgument.InsertAsTextOnly);
      }
  | link_field_instruction switch_u
      {
          $$ = $1;
          $$.InsertAsUnicodeText = $2;
          $$.Order.Add(LinkArgument.InsertAsUnicodeText);
      }
  | link_field_instruction expression
      {
          if ($$.SourceFileLocation == null)
          {
              $$.SourceFileLocation = $2;
              $$.Order.Add(LinkArgument.SourceFileLocation);
          }
          else if ($$.SourceFilePortion == null)
          {
              $$.SourceFilePortion = $2;
              $$.Order.Add(LinkArgument.SourceFilePortion);
          }
      }
  | T_LINK_INSTRUCTION progid
      {
          $$ = new LinkFieldInstruction(
              new StringLiteralNode($1),
              $2, null, null, null, null, null, null, null, null, null, null, null,
              new System.Collections.Generic.List<LinkArgument>() { LinkArgument.ApplicationType }
          );
      }
  ;
listnum_field_instruction:
    whitespace listnum_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | listnum_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | listnum_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(ListNumArgument.GeneralFormat);
      }
  | listnum_field_instruction switch_l integer
      {
          $$ = $1;
          $$.Level = new FlaggedArgument<NumericLiteralNode<int>>($2, $3);
          $$.Order.Add(ListNumArgument.Level);
      }
  | listnum_field_instruction switch_l
      {
          $$ = $1;
          $$.Level = new FlaggedArgument<NumericLiteralNode<int>>($2, new EmptyNumericLiteralNode<int>());
          $$.Order.Add(ListNumArgument.Level);
      }
  | listnum_field_instruction switch_s integer
      {
          $$ = $1;
          $$.StartingNumber = new FlaggedArgument<NumericLiteralNode<int>>($2, $3);
          $$.Order.Add(ListNumArgument.StartingNumber);
      }
  | listnum_field_instruction expression
      {
          $$ = $1;
          if ($$.ListName == null)
          {
              $$.ListName = $2;
              $$.Order.Add(ListNumArgument.ListName);
          }
      }
  | T_LISTNUM_INSTRUCTION
      {
          $$ = new ListNumFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null,
              new System.Collections.Generic.List<ListNumArgument>()
          );
      }
  ;
macrobutton_field_instruction:
    whitespace macrobutton_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | macrobutton_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | macrobutton_field_instruction expression
      {
          $$ = $1;
          if ($$.MacroName == null)
          {
              $$.MacroName = $2;
          }
          else if ($$.ButtonText == null)
          {
              $$.ButtonText = $2;
          }
          else
          {
              $$.ButtonText = new ConcatenatedNodes(new List<ExpressionNode> { $$.ButtonText, $2 });
          }
      }
  | T_MACROBUTTON_INSTRUCTION
      { $$ = new MacroButtonFieldInstruction(new StringLiteralNode($1)); }
  ;
mergefield_field_instruction:
    whitespace mergefield_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | mergefield_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | mergefield_field_instruction  numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(MergeFieldArgument.NumericFormat);
      }
  | mergefield_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(MergeFieldArgument.DateTimeFormat);
      }
  | mergefield_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(MergeFieldArgument.GeneralFormat);
      }
  | mergefield_field_instruction switch_b expression
      {
          $$ = $1;
          $$.TextBefore = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(MergeFieldArgument.TextBefore);
      }
  | mergefield_field_instruction switch_f expression
      {
          $$ = $1;
          $$.TextAfter = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(MergeFieldArgument.TextAfter);
      }
  | mergefield_field_instruction switch_m
      {
          $$ = $1;
          $$.IsMapped = $2;
          $$.Order.Add(MergeFieldArgument.IsMapped);
      }
  | mergefield_field_instruction switch_v
      {
          $$ = $1;
          $$.VerticalFormatting = $2;
          $$.Order.Add(MergeFieldArgument.VerticalFormatting);
      }
  | mergefield_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(MergeFieldArgument.NumericFormat);
      }
  | mergefield_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(MergeFieldArgument.GeneralFormat);
      }
  | T_MERGEFIELD_INSTRUCTION expression
      {
          $$ = new MergeFieldFieldInstruction(
              new StringLiteralNode($1),
              $2,
              null, null, null, null, null, null, null,
              new System.Collections.Generic.List<MergeFieldArgument>() { MergeFieldArgument.FieldName }
          );
      }
  ;

mergerec_field_instruction:
    whitespace mergerec_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | mergerec_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_MERGEREC_INSTRUCTION { $$ = new MergeRecFieldInstruction(new StringLiteralNode($1)); }
  ;
mergeseq_field_instruction:
    whitespace mergeseq_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | mergeseq_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_MERGESEQ_INSTRUCTION { $$ = new MergeSeqFieldInstruction(new StringLiteralNode($1)); }
  ;
next_field_instruction:
    whitespace next_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | next_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_NEXT_INSTRUCTION { $$ = new NextFieldInstruction(new StringLiteralNode($1)); }
  ;
nextif_field_instruction:
    whitespace nextif_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | nextif_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_NEXTIF_INSTRUCTION expression { $$ = new NextIfFieldInstruction(new StringLiteralNode($1), $2); }
  | T_NEXTIF_INSTRUCTION { $$ = new NextIfFieldInstruction(new StringLiteralNode($1), null); }
  ;
noteref_field_instruction:
    whitespace noteref_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | noteref_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | noteref_field_instruction switch_f
      {
          $$ = $1;
          $$.FootnoteFormat = $2;
          $$.Order.Add(NoteRefArgument.FootnoteFormat);
      }
  | noteref_field_instruction switch_h
      {
          $$ = $1;
          $$.Hyperlink = $2;
          $$.Order.Add(NoteRefArgument.Hyperlink);
      }
  | noteref_field_instruction switch_p
      {
          $$ = $1;
          $$.RelativePosition = $2;
          $$.Order.Add(NoteRefArgument.RelativePosition);
      }
  | noteref_field_instruction expression
      {
          $$ = $1;
          if ($$.BookmarkName == null)
          {
              $$.BookmarkName = $2;
              $$.Order.Add(NoteRefArgument.BookmarkName);
          }
      }
  | T_NOTEREF_INSTRUCTION
      {
          $$ = new NoteRefFieldInstruction(
              new StringLiteralNode($1),
              null,
              null, null, null,
              new System.Collections.Generic.List<NoteRefArgument>()
          );
      }
  ;




numchars_field_instruction:
    whitespace numchars_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | numchars_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | numchars_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(NumCharsArgument.GeneralFormat);
      }
  | numchars_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(NumCharsArgument.NumericFormat);
      }
  | T_NUMCHARS_INSTRUCTION                { $$ = new NumCharsFieldInstruction(new StringLiteralNode($1), null, null, new System.Collections.Generic.List<NumCharsArgument>()); }
  ;
numpages_field_instruction:
    whitespace numpages_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | numpages_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | numpages_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(NumPagesArgument.GeneralFormat);
      }
  | numpages_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(NumPagesArgument.NumericFormat);
      }
  | T_NUMPAGES_INSTRUCTION { $$ = new NumPagesFieldInstruction(new StringLiteralNode($1), null, null, new System.Collections.Generic.List<NumPagesArgument>()); }
  ;
numwords_field_instruction:
    whitespace numwords_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | numwords_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | numwords_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(NumWordsArgument.GeneralFormat);
      }
  | numwords_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(NumWordsArgument.NumericFormat);
      }
  | T_NUMWORDS_INSTRUCTION { $$ = new NumWordsFieldInstruction(new StringLiteralNode($1), null, null, new System.Collections.Generic.List<NumWordsArgument>()); }
  ;
page_field_instruction:
    whitespace page_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | page_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | page_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
      }
  | T_PAGE { $$ = new PageFieldInstruction(new StringLiteralNode($1)); }
  ;

pageref_field_instruction:
    whitespace pageref_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | pageref_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | pageref_field_instruction switch_h
      {
          $$ = $1;
          $$.Hyperlink = $2;
          $$.Order.Add(PageRefArgument.Hyperlink);
      }
  | pageref_field_instruction switch_p
      {
          $$ = $1;
          $$.RelativePosition = $2;
          $$.Order.Add(PageRefArgument.RelativePosition);
      }
  | pageref_field_instruction expression
      {
          $$ = $1;
          if ($$.BookmarkName == null)
          {
              $$.BookmarkName = $2;
          }
      }
  | pageref_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(PageRefArgument.GeneralFormat);
      }
  | pageref_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(PageRefArgument.NumericFormat);
      }
  | T_PAGEREF_INSTRUCTION
      {
          $$ = new PageRefFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null, null,
              new System.Collections.Generic.List<PageRefArgument>()
          );
      }
  ;
private_field_instruction:
    whitespace private_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | private_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_PRIVATE_INSTRUCTION
      { $$ = new PrivateFieldInstruction(new StringLiteralNode($1)); }
  ;
printdate_field_instruction:
    whitespace printdate_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | printdate_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | printdate_field_instruction switch_h
      {
          $$ = $1;
          $$.UseHijriCalendar = $2;
          $$.Order.Add(OpenLanguage.WordprocessingML.FieldInstruction.PrintDateArgument.UseHijri);
      }
  | printdate_field_instruction bool_switch_s
      {
          $$ = $1;
          $$.UseSakaCalendar = $2;
          $$.Order.Add(OpenLanguage.WordprocessingML.FieldInstruction.PrintDateArgument.UseSaka);
      }
  | printdate_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(OpenLanguage.WordprocessingML.FieldInstruction.PrintDateArgument.DateTimeFormat);
      }
  | printdate_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(OpenLanguage.WordprocessingML.FieldInstruction.PrintDateArgument.GeneralFormat);
      }
  | T_PRINTDATE_INSTRUCTION
      {
          $$ = new PrintDateFieldInstruction(
              new StringLiteralNode($1),
              null,  // UseHijriCalendar
              null,  // UseSakaCalendar
              null,  // DateTimeFormat
              null,  // GeneralFormat
              new System.Collections.Generic.List<OpenLanguage.WordprocessingML.FieldInstruction.PrintDateArgument>()
          );
      }
  ;
print_field_instruction:
    whitespace print_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | print_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | print_field_instruction expression
      {
          $$ = $1;
          $$.PrinterControlCodes = $2;
          $$.Order.Add(PrintArgument.PrinterControlCodes);
      }
  | print_field_instruction switch_p
      {
          $$ = $1;
          $$.UsePostScript = $2;
          $$.Order.Add(PrintArgument.UsePostScript);
      }
  | print_field_instruction switch_p expression
      {
          $$ = $1;
          $$.UsePostScript = $2;
          $$.PostScriptDrawingRectangle = $3;
          $$.Order.Add(PrintArgument.UsePostScript);
          $$.Order.Add(PrintArgument.PostScriptDrawingRectangle);
      }
  | print_field_instruction switch_p expression expression
      {
          $$ = $1;
          $$.UsePostScript = $2;
          $$.PostScriptDrawingRectangle = $3;
          $$.PostScriptInstructions = $4;
          $$.Order.Add(PrintArgument.UsePostScript);
          $$.Order.Add(PrintArgument.PostScriptDrawingRectangle);
          $$.Order.Add(PrintArgument.PostScriptInstructions);
      }
  | T_PRINT_INSTRUCTION
      {
          $$ = new PrintFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null,
              new System.Collections.Generic.List<PrintArgument>()
          );
      }
  ;
quote_field_instruction:
    whitespace quote_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | quote_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | quote_field_instruction expression
      {
          $$ = $1;
          $$.QuoteText = $2;
          $$.Order.Add(QuoteArgument.QuoteText);
      }
  | quote_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(QuoteArgument.GeneralFormat);
      }
  | quote_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(QuoteArgument.NumericFormat);
      }
  | quote_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(QuoteArgument.DateTimeFormat);
      }
  | T_QUOTE_INSTRUCTION
      { $$ = new QuoteFieldInstruction(new StringLiteralNode($1), null, null, null, null, new System.Collections.Generic.List<QuoteArgument>()); }
  ;
rd_field_instruction:
    whitespace rd_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | rd_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_RD_INSTRUCTION switch_f expression { $$ = new RdFieldInstruction(new StringLiteralNode($1), $3, $2, new System.Collections.Generic.List<RdArgument>() { RdArgument.IsRelativePath, RdArgument.FilePath }); }
  | T_RD_INSTRUCTION expression switch_f { $$ = new RdFieldInstruction(new StringLiteralNode($1), $2, $3, new System.Collections.Generic.List<RdArgument>() { RdArgument.FilePath, RdArgument.IsRelativePath }); }
  | T_RD_INSTRUCTION expression          { $$ = new RdFieldInstruction(new StringLiteralNode($1), $2, null, new System.Collections.Generic.List<RdArgument>() { RdArgument.FilePath }); }
  ;

ref_field_instruction:
    whitespace ref_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | ref_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | ref_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(RefArgument.GeneralFormat);
      }
  | ref_field_instruction switch_d expression
      {
          $$ = $1;
          $$.SeparatorSequence = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(RefArgument.SeparatorSequence);
      }
  | ref_field_instruction switch_f
      {
          $$ = $1;
          $$.IncrementFootnote = $2;
          $$.Order.Add(RefArgument.IncrementFootnote);
      }
  | ref_field_instruction switch_h
      {
          $$ = $1;
          $$.CreateHyperlink = $2;
          $$.Order.Add(RefArgument.CreateHyperlink);
      }
  | ref_field_instruction switch_n
      {
          $$ = $1;
          $$.InsertParagraphNumber = $2;
          $$.Order.Add(RefArgument.InsertParagraphNumber);
      }
  | ref_field_instruction switch_p
      {
          $$ = $1;
          $$.RelativePosition = $2;
          $$.Order.Add(RefArgument.RelativePosition);
      }
  | ref_field_instruction switch_r
      {
          $$ = $1;
          $$.InsertParagraphNumberRelative = $2;
          $$.Order.Add(RefArgument.InsertParagraphNumberRelative);
      }
  | ref_field_instruction switch_t
      {
          $$ = $1;
          $$.SuppressText = $2;
          $$.Order.Add(RefArgument.SuppressText);
      }
  | ref_field_instruction switch_w
      {
          $$ = $1;
          $$.FullContextParagraphNumber = $2;
          $$.Order.Add(RefArgument.FullContextParagraphNumber);
      }
  | ref_field_instruction expression
      {
          $$ = $1;
          if ($$.BookmarkName == null)
          {
              $$.BookmarkName = $2;
              $$.Order.Add(RefArgument.BookmarkName);
          }
      }
  | T_REF_INSTRUCTION
      {
          $$ = new RefFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null, null, null, null, null, null, null,
              new System.Collections.Generic.List<RefArgument>()
          );
      }
  ;
revnum_field_instruction:
    whitespace revnum_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | revnum_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | revnum_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(RevNumArgument.GeneralFormat);
      }
  | revnum_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(RevNumArgument.NumericFormat);
      }
  | T_REVNUM_INSTRUCTION { $$ = new RevNumFieldInstruction(new StringLiteralNode($1), null, null, new List<RevNumArgument>()); }
  ;

shape_field_instruction:
    T_SHAPE_INSTRUCTION
      { $$ = new ShapeFieldInstruction(new StringLiteralNode($1), null, null, null, null, new List<ShapeFieldInstruction.ShapeArgument>()); }
  | shape_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace shape_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | shape_field_instruction primary
      {
          $$ = $1;
          if ($$.ShapeText == null) {
              $$.ShapeText = $2;
              $$.Order.Add(ShapeFieldInstruction.ShapeArgument.ShapeText);
          }
      }
  | shape_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(ShapeFieldInstruction.ShapeArgument.GeneralFormat);
      }
  | shape_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(ShapeFieldInstruction.ShapeArgument.NumericFormat);
      }
  | shape_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(ShapeFieldInstruction.ShapeArgument.DateTimeFormat);
      }
  ;
savedate_field_instruction:
    whitespace savedate_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | savedate_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | savedate_field_instruction switch_h
      {
          $$ = $1;
          $$.UseHijriCalendar = $2;
          $$.Order.Add(SaveDateArgument.UseHijri);
      }
  | savedate_field_instruction bool_switch_s
      {
          $$ = $1;
          $$.UseSakaCalendar = $2;
          $$.Order.Add(SaveDateArgument.UseSaka);
      }
  | savedate_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(SaveDateArgument.DateTimeFormat);
      }
  | savedate_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(SaveDateArgument.GeneralFormat);
      }
  | T_SAVEDATE_INSTRUCTION
      {
          $$ = new SaveDateFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              null,
              null,
              new System.Collections.Generic.List<SaveDateArgument>()
          );
      }
  ;
section_field_instruction:
    whitespace section_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | section_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | section_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(SectionArgument.GeneralFormat);
      }
  | T_SECTION_INSTRUCTION { $$ = new SectionFieldInstruction(new StringLiteralNode($1), null, new List<SectionArgument>()); }
  ;
sectionpages_field_instruction:
    whitespace sectionpages_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | sectionpages_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | sectionpages_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(SectionPagesArgument.GeneralFormat);
      }
  | sectionpages_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(SectionPagesArgument.NumericFormat);
      }
  | T_SECTIONPAGES_INSTRUCTION { $$ = new SectionPagesFieldInstruction(new StringLiteralNode($1), null, null, new List<SectionPagesArgument>()); }
  ;
seq_field_instruction:
    whitespace seq_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | seq_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | seq_field_instruction bool_switch_c
      {
          $$ = $1;
          $$.RepeatPreviousNumber = $2;
          $$.Order.Add(SeqArgument.RepeatPreviousNumber);
      }
  | seq_field_instruction switch_h
      {
          $$ = $1;
          $$.Hide = $2;
          $$.Order.Add(SeqArgument.Hide);
      }
  | seq_field_instruction switch_n
      {
          $$ = $1;
          $$.InsertNext = $2;
          $$.Order.Add(SeqArgument.InsertNext);
      }
  | seq_field_instruction switch_r integer
      {
          $$ = $1;
          $$.ResetToNumber = new FlaggedArgument<NumericLiteralNode<int>>($2, $3);
          $$.Order.Add(SeqArgument.ResetToNumber);
      }
  | seq_field_instruction switch_s integer
      {
          $$ = $1;
          $$.ResetToHeadingLevel = new FlaggedArgument<NumericLiteralNode<int>>($2, $3);
          $$.Order.Add(SeqArgument.ResetToHeadingLevel);
      }
  | seq_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(SeqArgument.GeneralFormat);
      }
  | seq_field_instruction expression
      {
          $$ = $1;
          if ($$.SequenceName == null)
          {
              $$.SequenceName = $2;
              $$.Order.Add(SeqArgument.SequenceName);
          }
          else if ($$.BookmarkName == null)
          {
              $$.BookmarkName = $2;
              $$.Order.Add(SeqArgument.BookmarkName);
          }
      }
  | T_SEQ_INSTRUCTION
      {
          $$ = new SeqFieldInstruction(
              new StringLiteralNode($1),
              null,
              null, null, null, null, null, null, null,
              new System.Collections.Generic.List<SeqArgument>()
          );
      }
  ;
set_field_instruction:
    whitespace set_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | set_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | set_field_instruction expression
      {
          $$ = $1;
          if ($$.BookmarkName == null)
          {
              $$.BookmarkName = $2;
          }
          else if ($$.Value == null)
          {
              $$.Value = $2;
          }
          else
          {
              if ($$.Value is ConcatenatedNodes cn) {
                  cn.Add($2);
              } else {
                  $$.Value = new ConcatenatedNodes(new List<ExpressionNode> { $$.Value, $2 });
              }
          }
      }
  | T_SET_INSTRUCTION
      { $$ = new SetFieldInstruction(new StringLiteralNode($1), null, null); }
  ;
skipif_field_instruction:
    whitespace skipif_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | skipif_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SKIPIF_INSTRUCTION expression { $$ = new SkipIfFieldInstruction(new StringLiteralNode($1), $2); }
  | T_SKIPIF_INSTRUCTION { $$ = new SkipIfFieldInstruction(new StringLiteralNode($1), null); }
  ;
styleref_field_instruction:
    whitespace styleref_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | styleref_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | styleref_field_instruction switch_l
      {
          $$ = $1;
          $$.InsertNearestTextFollowing = $2;
          $$.Order.Add(StyleRefArgument.InsertNearestTextFollowing);
      }
  | styleref_field_instruction switch_n
      {
          $$ = $1;
          $$.InsertParagraphNumber = $2;
          $$.Order.Add(StyleRefArgument.InsertParagraphNumber);
      }
  | styleref_field_instruction switch_p
      {
          $$ = $1;
          $$.InsertRelativePosition = $2;
          $$.Order.Add(StyleRefArgument.InsertRelativePosition);
      }
  | styleref_field_instruction switch_r
      {
          $$ = $1;
          $$.InsertParagraphNumberRelative = $2;
          $$.Order.Add(StyleRefArgument.InsertParagraphNumberRelative);
      }
  | styleref_field_instruction switch_t
      {
          $$ = $1;
          $$.SuppressNonDelimiter = $2;
          $$.Order.Add(StyleRefArgument.SuppressNonDelimiter);
      }
  | styleref_field_instruction switch_w
      {
          $$ = $1;
          $$.InsertParagraphNumberFull = $2;
          $$.Order.Add(StyleRefArgument.InsertParagraphNumberFull);
      }
  | styleref_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(StyleRefArgument.GeneralFormat);
      }
  | styleref_field_instruction bool_switch_s
      {
          $$ = $1;
          $$.UndocumentedS = $2;
          $$.Order.Add(StyleRefArgument.UndocumentedS);
      }
  | styleref_field_instruction expression
      {
          $$ = $1;
          if ($$.StyleName == null)
          {
              $$.StyleName = $2;
              $$.Order.Add(StyleRefArgument.StyleName);
          }
      }
  | T_STYLEREF_INSTRUCTION
      {
          $$ = new StyleRefFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null, null, null, null, null, null,
              new System.Collections.Generic.List<StyleRefArgument>()
          );
      }
  ;
subject_field_instruction:
    whitespace subject_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | subject_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | subject_field_instruction expression
      {
          $$ = $1;
          if ($$.SubjectText == null)
          {
              $$.SubjectText = $2;
          }
      }
  | subject_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
      }
  | T_SUBJECT_INSTRUCTION
      { $$ = new SubjectFieldInstruction(new StringLiteralNode($1)); }
  ;
symbol_field_instruction:
    whitespace symbol_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | symbol_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | symbol_field_instruction switch_a
      {
          $$ = $1;
          $$.Ansi = $2;
          $$.Order.Add(SymbolArgument.Ansi);
      }
  | symbol_field_instruction switch_h
      {
          $$ = $1;
          $$.FontSizeHalfPoints = $2;
          $$.Order.Add(SymbolArgument.FontSizeHalfPoints);
      }
  | symbol_field_instruction switch_s font_size
      {
          $$ = $1;
          $$.FontSizePoints = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(SymbolArgument.FontSizePoints);
      }
  | symbol_field_instruction switch_u
      {
          $$ = $1;
          $$.Unicode = $2;
          $$.Order.Add(SymbolArgument.Unicode);
      }
  | symbol_field_instruction switch_f expression
      {
          $$ = $1;
          $$.FontName = new FlaggedArgument<ExpressionNode>($2, $3);
          $$.Order.Add(SymbolArgument.FontName);
      }
  | symbol_field_instruction switch_j
      {
          $$ = $1;
          $$.ShiftJis = $2;
          $$.Order.Add(SymbolArgument.ShiftJis);
      }
  | symbol_field_instruction integer
      {
          $$ = $1;
          if ($$.CharacterCode == null)
          {
              $$.CharacterCode = $2;
              $$.Order.Add(SymbolArgument.CharacterCode);
          }
      }
  | T_SYMBOL_INSTRUCTION
      {
          $$ = new SymbolFieldInstruction(
              new StringLiteralNode($1), null,
              null, null, null, null, null, null,
              new System.Collections.Generic.List<SymbolArgument>()
          );
      }
  ;
ta_field_instruction:
    whitespace ta_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | ta_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | ta_field_instruction expression
      {
          $$ = $1;
          if ($$.EntryText == null)
          {
              $$.EntryText = $2;
              $$.Order.Add(TaArgument.EntryText);
          }
      }
  | ta_field_instruction switch_b
      { $$ = $1; $$.ApplyBoldFormatting = $2; $$.Order.Add(TaArgument.ApplyBoldFormatting); }
  | ta_field_instruction switch_c expression
      { $$ = $1; $$.CategoryNumber = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TaArgument.CategoryNumber); }
  | ta_field_instruction switch_i
      { $$ = $1; $$.ApplyItalicFormatting = $2; $$.Order.Add(TaArgument.ApplyItalicFormatting); }
  | ta_field_instruction switch_l expression
      { $$ = $1; $$.LongCitation = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TaArgument.LongCitation); }
  | ta_field_instruction switch_r expression
      { $$ = $1; $$.BookmarkName = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TaArgument.BookmarkName); }
  | ta_field_instruction switch_s expression
      { $$ = $1; $$.ShortCitation = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TaArgument.ShortCitation); }
  | T_TA_INSTRUCTION
      {
          $$ = new TaFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null, null, null, null,
              new System.Collections.Generic.List<TaArgument>()
          );
      }
  ;
tc_field_instruction:
    whitespace tc_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | tc_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | tc_field_instruction switch_f expression
      { $$ = $1; $$.TableType = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TcArgument.TableType); }
  | tc_field_instruction switch_f
      { $$ = $1; $$.TableType = new FlaggedArgument<ExpressionNode>($2, new EmptyExpressionNode()); $$.Order.Add(TcArgument.TableType); }
  | tc_field_instruction switch_l expression
      { $$ = $1; $$.Level = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TcArgument.Level); }
  | tc_field_instruction switch_n
      { $$ = $1; $$.OmitPageNumber = $2; $$.Order.Add(TcArgument.OmitPageNumber); }
  | tc_field_instruction switch_s expression
      { $$ = $1; $$.Separator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TcArgument.Separator); }
  | tc_field_instruction expression
      {
          $$ = $1;
          if ($$.EntryText == null)
          {
              $$.EntryText = $2;
              $$.Order.Add(TcArgument.EntryText);
          }
      }
  | T_TC_INSTRUCTION
      {
          $$ = new TcFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null, null,
              new System.Collections.Generic.List<TcArgument>()
          );
      }
  ;
xe_field_instruction:
    whitespace xe_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | xe_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | xe_field_instruction switch_b
      { $$ = $1; $$.ApplyBoldFormatting = $2; $$.Order.Add(XeArgument.ApplyBoldFormatting); }
  | xe_field_instruction switch_f expression
      { $$ = $1; $$.EntryType = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(XeArgument.EntryType); }
  | xe_field_instruction switch_i
      { $$ = $1; $$.ApplyItalicFormatting = $2; $$.Order.Add(XeArgument.ApplyItalicFormatting); }
  | xe_field_instruction switch_r expression
      { $$ = $1; $$.BookmarkName = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(XeArgument.BookmarkName); }
  | xe_field_instruction switch_t expression
      { $$ = $1; $$.CrossReferenceText = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(XeArgument.CrossReferenceText); }
  | xe_field_instruction switch_y expression
      { $$ = $1; $$.YomiText = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(XeArgument.YomiText); }
  | T_XE_INSTRUCTION expression
      {
          $$ = new XeFieldInstruction(
              new StringLiteralNode($1),
              $2,
              null, null, null, null, null, null,
              new System.Collections.Generic.List<XeArgument>() { XeArgument.EntryText }
          );
      }
  | T_XE_INSTRUCTION
      {
          $$ = new XeFieldInstruction(
              new StringLiteralNode($1),
              new OpenLanguage.WordprocessingML.Ast.StringLiteralNode(string.Empty),
              null, null, null, null, null, null,
              new System.Collections.Generic.List<XeArgument>()
          );
      }
  ;
template_field_instruction:
    whitespace template_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | template_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | template_field_instruction switch_p
      {
          $$ = $1;
          $$.IncludeFullPath = $2;
          $$.Order.Add(TemplateArgument.IncludeFullPath);
      }
  | template_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(TemplateArgument.GeneralFormat);
      }
  | T_TEMPLATE_INSTRUCTION
      {
          $$ = new TemplateFieldInstruction(
              new StringLiteralNode($1),
              null,
              null,
              new System.Collections.Generic.List<TemplateArgument>()
          );
      }
  ;
time_field_instruction:
    whitespace time_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | time_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | time_field_instruction datetime_formatting_switch
      {
          $$ = $1;
          $$.DateTimeFormat = $2;
          $$.Order.Add(TimeArgument.DateTimeFormat);
      }
  | time_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(TimeArgument.GeneralFormat);
      }
  | T_TIME_INSTRUCTION { $$ = new TimeFieldInstruction(new StringLiteralNode($1), null, null, new List<TimeArgument>()); }
  ;
title_field_instruction:
    whitespace title_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | title_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | title_field_instruction expression
      {
          $$ = $1;
          if ($$.NewTitle == null)
          {
              $$.NewTitle = $2;
          }
      }
  | title_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
      }
  | T_TITLE_INSTRUCTION
      { $$ = new TitleFieldInstruction(new StringLiteralNode($1)); }
  ;
toa_field_instruction:
    whitespace toa_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | toa_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | toa_field_instruction expression
      {
          $$ = $1;
          if ($$.Category == null)
          {
              $$.Category = $2;
              $$.Order.Add(ToaArgument.Category);
         }
     }
  | toa_field_instruction switch_b expression
      { $$ = $1; $$.BookmarkName = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(ToaArgument.BookmarkName); }
  | toa_field_instruction switch_c expression
      { $$ = $1; $$.CategoryNumber = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(ToaArgument.CategoryNumber); }
  | toa_field_instruction switch_d expression
      { $$ = $1; $$.SequencePageSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(ToaArgument.SequencePageSeparator); }
  | toa_field_instruction switch_e expression
      { $$ = $1; $$.EntryPageSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(ToaArgument.EntryPageSeparator); }
  | toa_field_instruction switch_g expression
      { $$ = $1; $$.PageRangeSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(ToaArgument.PageRangeSeparator); }
  | toa_field_instruction switch_f
      { $$ = $1; $$.RemoveFormatting = $2; $$.Order.Add(ToaArgument.RemoveFormatting); }
  | toa_field_instruction switch_h
      { $$ = $1; $$.IncludeCategoryHeading = $2; $$.Order.Add(ToaArgument.IncludeCategoryHeading); }
  | toa_field_instruction switch_l expression
      { $$ = $1; $$.MultiplePageSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(ToaArgument.MultiplePageSeparator); }
  | toa_field_instruction switch_p
      { $$ = $1; $$.UsePassim = $2; $$.Order.Add(ToaArgument.UsePassim); }
  | toa_field_instruction switch_s expression
      { $$ = $1; $$.SequenceIdentifier = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(ToaArgument.SequenceIdentifier); }
  | T_TOA_INSTRUCTION
      {
          $$ = new ToaFieldInstruction(
              new StringLiteralNode($1),
              null, null, null, null, null, null, null, null, null, null, null,
              new System.Collections.Generic.List<ToaArgument>()
          );
      }
  ;
toc_field_instruction:
    whitespace toc_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | toc_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | toc_field_instruction switch_a expression
      { $$ = $1; $$.CaptionIdentifier = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.CaptionIdentifier); }
  | toc_field_instruction switch_b expression
      { $$ = $1; $$.BookmarkName = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.BookmarkName); }
  | toc_field_instruction switch_c expression
      { $$ = $1; $$.SequenceIdentifier = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.SequenceIdentifier);  }
  | toc_field_instruction switch_c
      { $$ = $1; $$.SequenceIdentifier = new FlaggedArgument<ExpressionNode>($2, new EmptyExpressionNode()); $$.Order.Add(TocArgument.SequenceIdentifier); }
  | toc_field_instruction switch_d expression
      { $$ = $1; $$.SequenceSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.SequenceSeparator); }
  | toc_field_instruction switch_f expression
      { $$ = $1; $$.TableType = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.TableType); }
| toc_field_instruction switch_f
      { $$ = $1; $$.TableType = new FlaggedArgument<ExpressionNode>($2, new EmptyExpressionNode()); $$.Order.Add(TocArgument.TableType); }
  | toc_field_instruction switch_h
      { $$ = $1; $$.CreateHyperlinks = $2; $$.Order.Add(TocArgument.CreateHyperlinks); }
  | toc_field_instruction switch_l expression
      { $$ = $1; $$.TcFieldLevels = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.TcFieldLevels); }
  | toc_field_instruction switch_n
      { $$ = $1; $$.OmitPageNumbers = new FlaggedArgument<ExpressionNode>($2,new StringLiteralNode(string.Empty)); $$.Order.Add(TocArgument.OmitPageNumbers); }
  | toc_field_instruction switch_n expression
      { $$ = $1; $$.OmitPageNumbers = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.OmitPageNumbers); }
  | toc_field_instruction switch_o expression
      { $$ = $1; $$.HeadingStyleRange = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.HeadingStyleRange); }
  | toc_field_instruction switch_o
      { $$ = $1; $$.HeadingStyleRange = new FlaggedArgument<ExpressionNode>($2, new EmptyExpressionNode()); $$.Order.Add(TocArgument.HeadingStyleRange); }
  | toc_field_instruction switch_p expression
      { $$ = $1; $$.PageNumberSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.PageNumberSeparator); }
  | toc_field_instruction switch_s expression
      { $$ = $1; $$.SeqFieldIdentifier = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.SeqFieldIdentifier); }
  | toc_field_instruction switch_t expression
      { $$ = $1; $$.CustomStyles = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.CustomStyles); }
  | toc_field_instruction switch_u
      { $$ = $1; $$.UseOutlineLevels = $2; $$.Order.Add(TocArgument.UseOutlineLevels); }
  | toc_field_instruction switch_w
      { $$ = $1; $$.PreserveTabEntries = $2; $$.Order.Add(TocArgument.PreserveTabEntries); }
  | toc_field_instruction switch_x
      { $$ = $1; $$.PreserveNewlines = $2; $$.Order.Add(TocArgument.PreserveNewlines); }
  | toc_field_instruction switch_z
      { $$ = $1; $$.HideTabLeaderInWebView = $2; $$.Order.Add(TocArgument.HideTabLeaderInWebView); }
  | toc_field_instruction general_formatting_switch
      { $$ = $1; $$.GeneralFormat = $2; $$.Order.Add(TocArgument.GeneralFormat); }
  | toc_field_instruction switch_e expression
      { $$ = $1; $$.EntryPageSeparator = new FlaggedArgument<ExpressionNode>($2, $3); $$.Order.Add(TocArgument.EntryPageSeparator); }
  | T_TOC_INSTRUCTION
      {
          $$ = new TocFieldInstruction(
              new StringLiteralNode($1),
              null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,
              null, null,
              new System.Collections.Generic.List<TocArgument>()
          );
      }
  ;
useraddress_field_instruction:
    whitespace useraddress_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | useraddress_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | useraddress_field_instruction expression
      {
          $$ = $1;
          if ($$.NewAddress == null)
          {
              $$.NewAddress = $2;
                $$.Order.Add(UserAddressArgument.NewAddress);
          }
      }
    | useraddress_field_instruction general_formatting_switch
        {
            $$ = $1;
            $$.GeneralFormat = $2;
            $$.Order.Add(UserAddressArgument.GeneralFormat);
        }
  | T_USERADDRESS_INSTRUCTION
      { $$ = new UserAddressFieldInstruction(new StringLiteralNode($1), null, null, new List<UserAddressArgument>()); }
  ;
userinitials_field_instruction:
    whitespace userinitials_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | userinitials_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | userinitials_field_instruction expression
      {
          $$ = $1;
          if ($$.NewInitials == null)
          {
              $$.NewInitials = $2;
              $$.Order.Add(UserInitialsArgument.NewInitials);
          }
      }
  | userinitials_field_instruction general_formatting_switch { $$ = $1; $$.GeneralFormat = $2; $$.Order.Add(UserInitialsArgument.GeneralFormat); }
  | T_USERINITIALS_INSTRUCTION
      { $$ = new UserInitialsFieldInstruction(new StringLiteralNode($1), null, null, new List<UserInitialsArgument>()); }
  ;
username_field_instruction:
    whitespace username_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | username_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | username_field_instruction expression {
          $$ = $1;
          if ($$.NewUserName == null)
          {
              $$.NewUserName = $2;
              $$.Order.Add(UserNameArgument.NewUserName);
          }
      }
  | username_field_instruction general_formatting_switch { $$ = $1; $$.GeneralFormat = $2; $$.Order.Add(UserNameArgument.GeneralFormat); }
  | T_USERNAME_INSTRUCTION
      { $$ = new UserNameFieldInstruction(new StringLiteralNode($1), null, null, new List<UserNameArgument>()); }
  ;

embed_field_instruction:
    whitespace embed_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | embed_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | embed_field_instruction switch_asterisk mergeformat { $$ = $1; $$.MergeFormattingSwitch = new FlaggedArgument<StringLiteralNode>($2, $3); }
  | T_EMBED_INSTRUCTION progid                          { $$ = new EmbedFieldInstruction(new StringLiteralNode($1), $2); }
  ;

formula_field_instruction:
    whitespace formula_field_instruction { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | formula_field_instruction whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | formula_field_instruction numeric_formatting_switch
      {
          $$ = $1;
          $$.NumericFormat = $2;
          $$.Order.Add(FormulaArgument.NumericFormat);
      }
  | formula_field_instruction general_formatting_switch
      {
          $$ = $1;
          $$.GeneralFormat = $2;
          $$.Order.Add(FormulaArgument.GeneralFormat);
      }
  | formula_prefix expression %prec T_FORMULA
      {
          $$ = new FormulaFieldInstruction(
              $1,
              $2,
              null,
              null,
              new System.Collections.Generic.List<FormulaArgument>() { FormulaArgument.Expression }
          );
      }
  ;
