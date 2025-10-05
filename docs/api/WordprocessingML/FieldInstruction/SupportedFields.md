# Supported Field Instructions

The `FieldInstructionParser` returns strongly-typed Abstract Syntax Tree (AST) nodes for each field type. These nodes inherit from `OpenLanguage.WordprocessingML.FieldInstruction.Ast.FieldInstruction` and provide specific properties for accessing arguments and switches.

Below is a list of supported field instructions and their corresponding AST node classes.

### `ADDRESSBLOCK`

- **Class**: `AddressBlockFieldInstruction`
- **Properties**:
  - `CountryRegionInclusionSetting`: `FlaggedArgument<ExpressionNode>?`
  - `FormatByRecipientCountry`: `BoolFlagNode?`
  - `ExcludedCountriesRegions`: `List<FlaggedArgument<ExpressionNode>>`
  - `FormatTemplate`: `FlaggedArgument<ExpressionNode>?`
  - `LanguageId`: `FlaggedArgument<ExpressionNode>?`

### `ADVANCE`

- **Class**: `AdvanceFieldInstruction`
- **Properties**:
  - `DownByPoints`: `FlaggedArgument<ExpressionNode>?`
  - `LeftByPoints`: `FlaggedArgument<ExpressionNode>?`
  - `RightByPoints`: `FlaggedArgument<ExpressionNode>?`
  - `UpByPoints`: `FlaggedArgument<ExpressionNode>?`
  - `HorizontalPosition`: `FlaggedArgument<ExpressionNode>?`
  - `VerticalPosition`: `FlaggedArgument<ExpressionNode>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `ASK`

- **Class**: `AskFieldInstruction`
- **Properties**:
  - `BookmarkName`: `ExpressionNode?`
  - `PromptText`: `ExpressionNode?`
  - `DefaultText`: `FlaggedArgument<ExpressionNode>?`
  - `PromptOnce`: `BoolFlagNode?`

### `AUTHOR`

- **Class**: `AuthorFieldInstruction`
- **Properties**:
  - `NewAuthorName`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `AUTONUM`

- **Class**: `AutoNumFieldInstruction`
- **Properties**:
  - `Separator`: `FlaggedArgument<ExpressionNode>?`

### `AUTONUMLGL`

- **Class**: `AutoNumLglFieldInstruction`
- **Properties**:
  - `RemoveTrailingSeparator`: `BoolFlagNode?`
  - `Separator`: `FlaggedArgument<ExpressionNode>?`

### `AUTONUMOUT`

- **Class**: `AutoNumOutFieldInstruction`
- No special properties.

### `AUTOTEXT`

- **Class**: `AutoTextFieldInstruction`
- **Properties**:
  - `EntryName`: `ExpressionNode?`

### `AUTOTEXTLIST`

- **Class**: `AutoTextListFieldInstruction`
- **Properties**:
  - `EntryName`: `ExpressionNode?`
  - `StyleFilter`: `FlaggedArgument<ExpressionNode>?`
  - `ScreenTip`: `FlaggedArgument<ExpressionNode>?`

### `BARCODE`

- **Class**: `BarcodeFieldInstruction`
- **Properties**:
  - `Data`: `ExpressionNode?`
  - `FacingIdentificationMark`: `FlaggedArgument<ExpressionNode>?`
  - `DataIsBookmarkName`: `BoolFlagNode?`
  - `UseUSPostalAddress`: `BoolFlagNode?`

### `BIBLIOGRAPHY`

- **Class**: `BibliographyFieldInstruction`
- **Properties**:
  - `Locale`: `FlaggedArgument<ExpressionNode>?`
  - `FilterLocale`: `FlaggedArgument<ExpressionNode>?`
  - `SingleSourceTag`: `FlaggedArgument<ExpressionNode>?`

### `BIDIOUTLINE`

- **Class**: `BidiOutlineFieldInstruction`
- No special properties.

### `CITATION`

- **Class**: `CitationFieldInstruction`
- **Properties**:
  - `SourceTag`: `ExpressionNode?`
  - `Locale`: `FlaggedArgument<ExpressionNode>?`
  - `Prefix`: `FlaggedArgument<ExpressionNode>?`
  - `Suffix`: `FlaggedArgument<ExpressionNode>?`
  - `PageNumber`: `FlaggedArgument<ExpressionNode>?`
  - `VolumeNumber`: `FlaggedArgument<ExpressionNode>?`
  - `SuppressAuthor`: `BoolFlagNode?`
  - `SuppressTitle`: `BoolFlagNode?`
  - `SuppressYear`: `BoolFlagNode?`
  - `AdditionalSourceTag`: `FlaggedArgument<ExpressionNode>?`

### `COMMENTS`

- **Class**: `CommentsFieldInstruction`
- **Properties**:
  - `Value`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `COMPARE`

- **Class**: `CompareFieldInstruction`
- **Properties**:
  - `CompareExpression`: `ExpressionNode?`

### `CREATEDATE`

- **Class**: `CreateDateFieldInstruction`
- **Properties**:
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `UseHijriCalendar`: `BoolFlagNode?`
  - `UseSakaCalendar`: `BoolFlagNode?`

### `DATABASE`

- **Class**: `DatabaseFieldInstruction`
- **Properties**:
  - `TableAttributes`: `FlaggedArgument<DatabaseTableAttributesNode>?`
  - `ConnectionString`: `FlaggedArgument<OdbcConnectionStringNode>?`
  - `DatabasePath`: `FlaggedArgument<ExpressionNode>?`
  - `FirstRecord`: `FlaggedArgument<NumericLiteralNode<int>>?`
  - `IncludeHeaders`: `BoolFlagNode?`
  - `TableFormat`: `FlaggedArgument<DatabaseTableFormatNode>?`
  - `OptimizationFlag`: `FlaggedArgument<DatabaseOptimizationFlagNode>?`
  - `DatabaseQueryInstruction`: `FlaggedArgument<ExpressionNode>?`
  - `LastRecord`: `FlaggedArgument<NumericLiteralNode<int>>?`

### `DATE`

- **Class**: `DateFieldInstruction`
- **Properties**:
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `UseHijriCalendar`: `BoolFlagNode?`
  - `UseLastUsedFormat`: `BoolFlagNode?`
  - `UseSakaCalendar`: `BoolFlagNode?`

### `DDE`

- **Class**: `DdeFieldInstruction`
- **Properties**:
  - `ApplicationName`: `ExpressionNode?`
  - `FileName`: `ExpressionNode?`
  - `BookmarkName`: `ExpressionNode?`
  - `AutoUpdate`: `BoolFlagNode?`
  - `Bitmap`: `BoolFlagNode?`
  - `NoStore`: `BoolFlagNode?`
  - `Html`: `BoolFlagNode?`
  - `Picture`: `BoolFlagNode?`
  - `Rtf`: `BoolFlagNode?`
  - `Text`: `BoolFlagNode?`
  - `Unicode`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`

### `DDEAUTO`

- **Class**: `DdeAutoFieldInstruction`
- **Properties**:
  - `ApplicationName`: `ExpressionNode?`
  - `FileName`: `ExpressionNode?`
  - `BookmarkName`: `ExpressionNode?`
  - `Bitmap`: `BoolFlagNode?`
  - `NoStore`: `BoolFlagNode?`
  - `Html`: `BoolFlagNode?`
  - `Picture`: `BoolFlagNode?`
  - `Rtf`: `BoolFlagNode?`
  - `Text`: `BoolFlagNode?`
  - `Unicode`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`

### `DOCPROPERTY`

- **Class**: `DocPropertyFieldInstruction`
- **Properties**:
  - `PropertyName`: `ExpressionNode?`
  - `PropertyCategoryArgument`: `ExpressionNode?`
  - `GeneralFormats`: `List<FlaggedArgument<ExpressionNode>>`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`
  - `HyperlinkSwitch`: `BoolFlagNode?`

### `DOCVARIABLE`

- **Class**: `DocVariableFieldInstruction`
- **Properties**:
  - `VariableName`: `ExpressionNode?`

### `EDITTIME`

- **Class**: `EditTimeFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `EMBED`

- **Class**: `EmbedFieldInstruction`
- **Properties**:
  - `ProgId`: `ExpressionNode`
  - `MergeFormattingSwitch`: `FlaggedArgument<StringLiteralNode>?`

### `EQ`

- **Class**: `EqFieldInstruction`
- **Properties**:
  - `PrimarySwitch`: `FlagNode?`
  - `ArgumentList`: `List<ExpressionNode>`
  - `ArrayAlignment`: `FlaggedArgument<EqArrayAlignmentNode>?`
  - `ColumnCount`: `FlaggedArgument<ExpressionNode>?`
  - `HorizontalSpacing`: `FlaggedArgument<ExpressionNode>?`
  - `VerticalSpacing`: `FlaggedArgument<ExpressionNode>?`
  - `BothBracketCharacter`: `FlaggedArgument<CharacterLiteralNode>?`
  - `LeftBracketCharacter`: `FlaggedArgument<CharacterLiteralNode>?`
  - `RightBracketCharacter`: `FlaggedArgument<CharacterLiteralNode>?`
  - `BackwardDisplacement`: `FlaggedArgument<ExpressionNode>?`
  - `ForwardDisplacement`: `FlaggedArgument<ExpressionNode>?`
  - `UnderlineSpace`: `BoolFlagNode?`
  - `FixedHeightCharacter`: `FlaggedArgument<CharacterLiteralNode>?`
  - `InlineFormat`: `BoolFlagNode?`
  - `IntegralSymbol`: `FlaggedArgument<EqIntegralSymbolNode>?`
  - `VariableHeightCharacter`: `FlaggedArgument<CharacterLiteralNode>?`
  - `OverlayAlignment`: `FlaggedArgument<EqOverlayAlignmentNode>?`
  - `SpaceAboveLine`: `FlaggedArgument<ExpressionNode>?`
  - `SpaceBelowLine`: `FlaggedArgument<ExpressionNode>?`
  - `MoveDown`: `FlaggedArgument<ExpressionNode>?`
  - `MoveUp`: `FlaggedArgument<ExpressionNode>?`
  - `BorderBottom`: `BoolFlagNode?`
  - `BorderLeft`: `BoolFlagNode?`
  - `BorderRight`: `BoolFlagNode?`
  - `BorderTop`: `BoolFlagNode?`

### `FILENAME`

- **Class**: `FileNameFieldInstruction`
- **Properties**:
  - `IncludeFullPath`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `FILESIZE`

- **Class**: `FileSizeFieldInstruction`
- **Properties**:
  - `InKilobytes`: `BoolFlagNode?`
  - `InMegabytes`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `FILLIN`

- **Class**: `FillInFieldInstruction`
- **Properties**:
  - `PromptText`: `ExpressionNode?`
  - `DefaultText`: `FlaggedArgument<ExpressionNode>?`
  - `PromptOnce`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `FORMCHECKBOX`

- **Class**: `FormCheckBoxFieldInstruction`
- No special properties.

### `FORMDROPDOWN`

- **Class**: `FormDropDownFieldInstruction`
- No special properties.

### `FORMTEXT`

- **Class**: `FormTextFieldInstruction`
- No special properties.

### `FORMULA`

- **Class**: `FormulaFieldInstruction`
- **Properties**:
  - `Expression`: `ExpressionNode`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `GLOSSARY`

- **Class**: `GlossaryInstruction`
- **Properties**:
  - `EntryName`: `ExpressionNode?`

### `GOTOBUTTON`

- **Class**: `GoToButtonFieldInstruction`
- **Properties**:
  - `TargetLocation`: `ExpressionNode?`
  - `ButtonDisplayContent`: `ExpressionNode?`

### `GREETINGLINE`

- **Class**: `GreetingLineFieldInstruction`
- **Properties**:
  - `BlankNameText`: `FlaggedArgument<ExpressionNode>?`
  - `Format`: `FlaggedArgument<ExpressionNode>?`
  - `LanguageId`: `FlaggedArgument<ExpressionNode>?`

### `HYPERLINK`

- **Class**: `HyperlinkFieldInstruction`
- **Properties**:
  - `Uri`: `ExpressionNode?`
  - `DisplayText`: `ExpressionNode?`
  - `InternalLocation`: `FlaggedArgument<ExpressionNode>?`
  - `NewWindow`: `BoolFlagNode?`
  - `ServerSideImageMapAppendCoordinates`: `FlaggedArgument<ExpressionNode>?`
  - `ScreenTipText`: `FlaggedArgument<ExpressionNode>?`
  - `InstrFrameTarget`: `FlaggedArgument<ExpressionNode>?`
  - `ArbLocation`: `FlaggedArgument<ExpressionNode>?`
  - `UndocumentedC`: `FlaggedArgument<NumericLiteralNode<int>>?`

### `IF`

- **Class**: `IfFieldInstruction`
- **Properties**:
  - `Condition`: `ExpressionNode?`
  - `TrueExpression`: `ExpressionNode?`
  - `FalseExpression`: `ExpressionNode?`

### `IMPORT`

- **Class**: `ImportInstruction`
- **Properties**:
  - `PictureFilePath`: `ExpressionNode?`
  - `GraphicsFilterName`: `FlaggedArgument<ExpressionNode>?`
  - `ReduceFileSize`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `INCLUDE`

- **Class**: `IncludeFieldInstruction`
- **Properties**:
  - `DocumentName`: `ExpressionNode?`
  - `BookmarkName`: `ExpressionNode?`
  - `PreventUpdateUnlessFieldsUpdated`: `BoolFlagNode?`
  - `DocumentFilterName`: `FlaggedArgument<ExpressionNode>?`

### `INCLUDEPICTURE`

- **Class**: `IncludePictureFieldInstruction`
- **Properties**:
  - `PictureFilePath`: `ExpressionNode?`
  - `GraphicsFilterName`: `FlaggedArgument<ExpressionNode>?`
  - `ReduceFileSize`: `BoolFlagNode?`

### `INCLUDETEXT`

- **Class**: `IncludeTextFieldInstruction`
- **Properties**:
  - `DocumentName`: `ExpressionNode?`
  - `BookmarkName`: `ExpressionNode?`
  - `PreventUpdateUnlessFieldsUpdated`: `BoolFlagNode?`
  - `DocumentFilterName`: `FlaggedArgument<ExpressionNode>?`
  - `NamespaceMapping`: `FlaggedArgument<NamespaceDeclarationNode>?`
  - `XsltPath`: `FlaggedArgument<ExpressionNode>?`
  - `XPathExpression`: `FlaggedArgument<ExpressionNode>?`

### `INDEX`

- **Class**: `IndexFieldInstruction`
- **Properties**:
  - `BookmarkName`: `FlaggedArgument<ExpressionNode>?`
  - `NumberOfColumns`: `FlaggedArgument<NumericLiteralNode<int>>?`
  - `SequencePageSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `EntryPageSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `EntryTypeFilter`: `FlaggedArgument<ExpressionNode>?`
  - `PageRangeSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `IndexHeadingText`: `FlaggedArgument<ExpressionNode>?`
  - `CrossReferenceSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `PageNumberSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `LetterRange`: `FlaggedArgument<ExpressionNode>?`
  - `UseRunInFormat`: `BoolFlagNode?`
  - `SequenceName`: `FlaggedArgument<ExpressionNode>?`
  - `EnableYomiText`: `BoolFlagNode?`
  - `LanguageId`: `FlaggedArgument<ExpressionNode>?`

### `INFO`

- **Class**: `InfoFieldInstruction`
- **Properties**:
  - `InformationCategory`: `InfoTypeNode`
  - `FieldArgument`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`
  - `UseHijriCalendar`: `BoolFlagNode?`
  - `UseSakaCalendar`: `BoolFlagNode?`
  - `IncludeFullPath`: `BoolFlagNode?`
  - `InKilobytes`: `BoolFlagNode?`
  - `InMegabytes`: `BoolFlagNode?`

### `KEYWORDS`

- **Class**: `KeywordsFieldInstruction`
- **Properties**:
  - `FieldArgument`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`

### `LASTSAVEDBY`

- **Class**: `LastSavedByFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`

### `LINK`

- **Class**: `LinkFieldInstruction`
- **Properties**:
  - `ApplicationType`: `ExpressionNode`
  - `SourceFileLocation`: `ExpressionNode?`
  - `SourceFilePortion`: `ExpressionNode?`
  - `AutomaticallyUpdate`: `BoolFlagNode?`
  - `InsertAsBitmap`: `BoolFlagNode?`
  - `DontStoreGraphicData`: `BoolFlagNode?`
  - `FormattingMode`: `FlaggedArgument<LinkFormattingModeNode>?`
  - `InsertAsHtml`: `BoolFlagNode?`
  - `InsertAsPicture`: `BoolFlagNode?`
  - `InsertAsRtf`: `BoolFlagNode?`
  - `InsertAsTextOnly`: `BoolFlagNode?`
  - `InsertAsUnicodeText`: `BoolFlagNode?`

### `LISTNUM`

- **Class**: `ListNumFieldInstruction`
- **Properties**:
  - `ListName`: `ExpressionNode?`
  - `Level`: `FlaggedArgument<NumericLiteralNode<int>>?`
  - `StartingNumber`: `FlaggedArgument<NumericLiteralNode<int>>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `MACROBUTTON`

- **Class**: `MacroButtonFieldInstruction`
- **Properties**:
  - `MacroName`: `ExpressionNode?`
  - `ButtonText`: `ExpressionNode?`

### `MERGEFIELD`

- **Class**: `MergeFieldFieldInstruction`
- **Properties**:
  - `FieldName`: `ExpressionNode`
  - `TextBefore`: `FlaggedArgument<ExpressionNode>?`
  - `TextAfter`: `FlaggedArgument<ExpressionNode>?`
  - `IsMapped`: `BoolFlagNode?`
  - `VerticalFormatting`: `BoolFlagNode?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`

### `MERGEREC`

- **Class**: `MergeRecFieldInstruction`
- No special properties.

### `MERGESEQ`

- **Class**: `MergeSeqFieldInstruction`
- No special properties.

### `NEXT`

- **Class**: `NextFieldInstruction`
- No special properties.

### `NEXTIF`

- **Class**: `NextIfFieldInstruction`
- **Properties**:
  - `Condition`: `ExpressionNode?`

### `NOTEREF`

- **Class**: `NoteRefFieldInstruction`
- **Properties**:
  - `BookmarkName`: `ExpressionNode?`
  - `FootnoteFormat`: `BoolFlagNode?`
  - `Hyperlink`: `BoolFlagNode?`
  - `RelativePosition`: `BoolFlagNode?`

### `NUMCHARS`

- **Class**: `NumCharsFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `NUMPAGES`

- **Class**: `NumPagesFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `NUMWORDS`

- **Class**: `NumWordsFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `PAGE`

- **Class**: `PageFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `PAGEREF`

- **Class**: `PageRefFieldInstruction`
- **Properties**:
  - `BookmarkName`: `ExpressionNode?`
  - `Hyperlink`: `BoolFlagNode?`
  - `RelativePosition`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `PRINT`

- **Class**: `PrintFieldInstruction`
- **Properties**:
  - `PrinterControlCodes`: `ExpressionNode`
  - `UsePostScript`: `BoolFlagNode?`
  - `PostScriptDrawingRectangle`: `ExpressionNode?`
  - `PostScriptInstructions`: `ExpressionNode?`

### `PRINTDATE`

- **Class**: `PrintDateFieldInstruction`
- **Properties**:
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `UseHijriCalendar`: `BoolFlagNode?`
  - `UseSakaCalendar`: `BoolFlagNode?`

### `PRIVATE`

- **Class**: `PrivateFieldInstruction`
- No special properties.

### `QUOTE`

- **Class**: `QuoteFieldInstruction`
- **Properties**:
  - `QuoteText`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`

### `RD`

- **Class**: `RdFieldInstruction`
- **Properties**:
  - `FilePath`: `ExpressionNode`
  - `IsRelativePath`: `BoolFlagNode?`

### `REF`

- **Class**: `RefFieldInstruction`
- **Properties**:
  - `BookmarkName`: `ExpressionNode?`
  - `SeparatorSequence`: `FlaggedArgument<ExpressionNode>?`
  - `IncrementFootnote`: `BoolFlagNode?`
  - `CreateHyperlink`: `BoolFlagNode?`
  - `InsertParagraphNumber`: `BoolFlagNode?`
  - `RelativePosition`: `BoolFlagNode?`
  - `InsertParagraphNumberRelative`: `BoolFlagNode?`
  - `SuppressText`: `BoolFlagNode?`
  - `FullContextParagraphNumber`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `REVNUM`

- **Class**: `RevNumFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `SAVEDATE`

- **Class**: `SaveDateFieldInstruction`
- **Properties**:
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `UseHijriCalendar`: `BoolFlagNode?`
  - `UseSakaCalendar`: `BoolFlagNode?`

### `SECTION`

- **Class**: `SectionFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `SECTIONPAGES`

- **Class**: `SectionPagesFieldInstruction`
- **Properties**:
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`

### `SEQ`

- **Class**: `SeqFieldInstruction`
- **Properties**:
  - `SequenceName`: `ExpressionNode?`
  - `BookmarkName`: `ExpressionNode?`
  - `RepeatPreviousNumber`: `BoolFlagNode?`
  - `Hide`: `BoolFlagNode?`
  - `InsertNext`: `BoolFlagNode?`
  - `ResetToNumber`: `FlaggedArgument<NumericLiteralNode<int>>?`
  - `ResetToHeadingLevel`: `FlaggedArgument<NumericLiteralNode<int>>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `SET`

- **Class**: `SetFieldInstruction`
- **Properties**:
  - `BookmarkName`: `ExpressionNode?`
  - `Value`: `ExpressionNode?`

### `SHAPE`

- **Class**: `ShapeFieldInstruction`
- **Properties**:
  - `ShapeText`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `NumericFormat`: `FlaggedArgument<ExpressionNode>?`
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`

### `SKIPIF`

- **Class**: `SkipIfFieldInstruction`
- **Properties**:
  - `Condition`: `ExpressionNode?`

### `STYLEREF`

- **Class**: `StyleRefFieldInstruction`
- **Properties**:
  - `StyleName`: `ExpressionNode?`
  - `InsertNearestTextFollowing`: `BoolFlagNode?`
  - `InsertParagraphNumber`: `BoolFlagNode?`
  - `InsertRelativePosition`: `BoolFlagNode?`
  - `InsertParagraphNumberRelative`: `BoolFlagNode?`
  - `SuppressNonDelimiter`: `BoolFlagNode?`
  - `InsertParagraphNumberFull`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `UndocumentedS`: `BoolFlagNode?`

### `SUBJECT`

- **Class**: `SubjectFieldInstruction`
- **Properties**:
  - `SubjectText`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `SYMBOL`

- **Class**: `SymbolFieldInstruction`
- **Properties**:
  - `CharacterCode`: `NumericLiteralNode<int>?`
  - `Ansi`: `BoolFlagNode?`
  - `FontName`: `FlaggedArgument<ExpressionNode>?`
  - `FontSizeHalfPoints`: `BoolFlagNode?`
  - `FontSizePoints`: `FlaggedArgument<ExpressionNode>?`
  - `Unicode`: `BoolFlagNode?`
  - `ShiftJis`: `BoolFlagNode?`

### `TA`

- **Class**: `TaFieldInstruction`
- **Properties**:
  - `EntryText`: `ExpressionNode?`
  - `ApplyBoldFormatting`: `BoolFlagNode?`
  - `CategoryNumber`: `FlaggedArgument<ExpressionNode>?`
  - `ApplyItalicFormatting`: `BoolFlagNode?`
  - `LongCitation`: `FlaggedArgument<ExpressionNode>?`
  - `BookmarkName`: `FlaggedArgument<ExpressionNode>?`
  - `ShortCitation`: `FlaggedArgument<ExpressionNode>?`

### `TC`

- **Class**: `TcFieldInstruction`
- **Properties**:
  - `EntryText`: `ExpressionNode?`
  - `TableType`: `FlaggedArgument<ExpressionNode>?`
  - `Level`: `FlaggedArgument<ExpressionNode>?`
  - `OmitPageNumber`: `BoolFlagNode?`
  - `Separator`: `FlaggedArgument<ExpressionNode>?`

### `TEMPLATE`

- **Class**: `TemplateFieldInstruction`
- **Properties**:
  - `IncludeFullPath`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `TIME`

- **Class**: `TimeFieldInstruction`
- **Properties**:
  - `DateTimeFormat`: `FlaggedArgument<ExpressionNode>?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `TITLE`

- **Class**: `TitleFieldInstruction`
- **Properties**:
  - `NewTitle`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `TOA`

- **Class**: `ToaFieldInstruction`
- **Properties**:
  - `Category`: `ExpressionNode?`
  - `BookmarkName`: `FlaggedArgument<ExpressionNode>?`
  - `CategoryNumber`: `FlaggedArgument<ExpressionNode>?`
  - `SequencePageSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `EntryPageSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `PageRangeSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `RemoveFormatting`: `BoolFlagNode?`
  - `IncludeCategoryHeading`: `BoolFlagNode?`
  - `MultiplePageSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `UsePassim`: `BoolFlagNode?`
  - `SequenceIdentifier`: `FlaggedArgument<ExpressionNode>?`

### `TOC`

- **Class**: `TocFieldInstruction`
- **Properties**:
  - `CaptionIdentifier`: `FlaggedArgument<ExpressionNode>?`
  - `BookmarkName`: `FlaggedArgument<ExpressionNode>?`
  - `SequenceIdentifier`: `FlaggedArgument<ExpressionNode>?`
  - `SequenceSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `TableType`: `FlaggedArgument<ExpressionNode>?`
  - `CreateHyperlinks`: `BoolFlagNode?`
  - `TcFieldLevels`: `FlaggedArgument<ExpressionNode>?`
  - `OmitPageNumbers`: `FlaggedArgument<ExpressionNode>?`
  - `HeadingStyleRange`: `FlaggedArgument<ExpressionNode>?`
  - `PageNumberSeparator`: `FlaggedArgument<ExpressionNode>?`
  - `SeqFieldIdentifier`: `FlaggedArgument<ExpressionNode>?`
  - `CustomStyles`: `FlaggedArgument<ExpressionNode>?`
  - `UseOutlineLevels`: `BoolFlagNode?`
  - `PreserveTabEntries`: `BoolFlagNode?`
  - `PreserveNewlines`: `FlagNode?`
  - `HideTabLeaderInWebView`: `BoolFlagNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`
  - `EntryPageSeparator`: `FlaggedArgument<ExpressionNode>?`

### `USERADDRESS`

- **Class**: `UserAddressFieldInstruction`
- **Properties**:
  - `NewAddress`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `USERINITIALS`

- **Class**: `UserInitialsFieldInstruction`
- **Properties**:
  - `NewInitials`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `USERNAME`

- **Class**: `UserNameFieldInstruction`
- **Properties**:
  - `NewUserName`: `ExpressionNode?`
  - `GeneralFormat`: `FlaggedArgument<ExpressionNode>?`

### `XE`

- **Class**: `XeFieldInstruction`
- **Properties**:
  - `EntryText`: `ExpressionNode`
  - `ApplyBoldFormatting`: `BoolFlagNode?`
  - `EntryType`: `FlaggedArgument<ExpressionNode>?`
  - `ApplyItalicFormatting`: `BoolFlagNode?`
  - `BookmarkName`: `FlaggedArgument<ExpressionNode>?`
  - `CrossReferenceText`: `FlaggedArgument<ExpressionNode>?`
  - `YomiText`: `FlaggedArgument<ExpressionNode>?`
