# Typed Field Instructions

The OpenLanguage library provides strongly-typed field instruction classes for all major Microsoft Word field types, offering type-safe access to field-specific properties and switches.

## Overview

The `TypedFieldInstruction` system converts generic field instructions into strongly-typed objects with specific properties for each field type. This is achieved through the `TypedFieldInstructionFactory.Create()` method, which supports over 60 different field instruction types.

## Basic Usage

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Typed;

// Parse a generic field instruction
var instruction = FieldInstructionParser.Parse("MERGEFIELD FirstName \* Upper");

// Convert to strongly-typed
var typedInstruction = TypedFieldInstructionFactory.Create(instruction);

// Check the type and use specific properties
if (typedInstruction is MergeFieldFieldInstruction mergeField)
{
    Console.WriteLine($"Field Name: {mergeField.FieldName}");
    Console.WriteLine($"Text Format: {mergeField.TextFormat}");
}
```

## TypedFieldInstruction Base Class

All typed field instructions inherit from the `TypedFieldInstruction` base class:

```csharp
public abstract class TypedFieldInstruction
{
    public FieldInstruction Source { get; }
    public string Instruction { get; }
    public string Arguments { get; }
    public string Switches { get; }

    protected TypedFieldInstruction(FieldInstruction source) { }
}
```

### Properties

- **Source**: The original `FieldInstruction` that this typed instruction was created from
- **Instruction**: The field instruction name (e.g., "MERGEFIELD", "DATE", etc.)
- **Arguments**: The field arguments portion of the instruction
- **Switches**: The switches portion of the instruction

## Supported Field Types

The OpenLanguage library provides comprehensive support for Microsoft Word field instructions. Below is the complete list of supported field types:

### Document Information Fields

#### AUTHOR

Retrieves and optionally sets the document author's name.

```csharp
var author = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("AUTHOR "John Doe"")) as AuthorFieldInstruction;
Console.WriteLine($"Author Name: {author?.AuthorName}");
```

#### COMMENTS

Retrieves the document's comments/description property.

```csharp
var comments = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("COMMENTS")) as CommentsFieldInstruction;
```

#### CREATEDATE

Inserts the date and time the document was created.

```csharp
var createDate = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("CREATEDATE \@ "MM/dd/yyyy"")) as CreateDateFieldInstruction;
Console.WriteLine($"Date Format: {createDate?.DateFormat}");
```

#### EDITTIME

Inserts the total editing time for the document.

```csharp
var editTime = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("EDITTIME \@ "h:mm"")) as EditTimeFieldInstruction;
```

#### FILENAME

Retrieves the name of the current document as stored on disk.

```csharp
var fileName = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("FILENAME \p")) as FileNameFieldInstruction;
Console.WriteLine($"Include Path: {fileName?.IncludeFullPath}");
```

#### FILESIZE

Retrieves the file size of the current document.

```csharp
var fileSize = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("FILESIZE \k")) as FileSizeFieldInstruction;
Console.WriteLine($"Show in KB: {fileSize?.ShowInKilobytes}");
```

#### KEYWORDS

Retrieves the document's keywords property.

```csharp
var keywords = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("KEYWORDS")) as KeywordsFieldInstruction;
```

#### LASTSAVEDBY

Retrieves the name of the user who last saved the document.

```csharp
var lastSavedBy = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("LASTSAVEDBY")) as LastSavedByFieldInstruction;
```

#### NUMCHARS

Retrieves the number of characters in the document.

```csharp
var numChars = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("NUMCHARS")) as NumCharsFieldInstruction;
Console.WriteLine($"Include Spaces: {numChars?.IncludeSpaces}");
```

#### NUMPAGES

Retrieves the total number of pages in the document.

```csharp
var numPages = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("NUMPAGES")) as NumPagesFieldInstruction;
```

#### NUMWORDS

Retrieves the number of words in the document.

```csharp
var numWords = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("NUMWORDS")) as NumWordsFieldInstruction;
```

#### REVNUM

Retrieves the document's revision number.

```csharp
var revNum = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("REVNUM")) as RevNumFieldInstruction;
```

#### SAVEDATE

Inserts the date and time the document was last saved.

```csharp
var saveDate = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("SAVEDATE \@ "dddd, MMMM d, yyyy"")) as SaveDateFieldInstruction;
```

#### SUBJECT

Retrieves the document's subject property.

```csharp
var subject = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("SUBJECT")) as SubjectFieldInstruction;
Console.WriteLine($"Subject Text: {subject?.SubjectText}");
```

#### TEMPLATE

Retrieves the name of the template attached to the document.

```csharp
var template = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("TEMPLATE")) as TemplateFieldInstruction;
Console.WriteLine($"Include Path: {template?.IncludeFullPath}");
```

#### TITLE

Retrieves the document's title property.

```csharp
var title = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("TITLE")) as TitleFieldInstruction;
Console.WriteLine($"Title Text: {title?.TitleText}");
```

### Date and Time Fields

#### DATE

Inserts the current date.

```csharp
var date = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("DATE \@ "MMMM d, yyyy" \h \s")) as DateFieldInstruction;
Console.WriteLine($"Date Format: {date?.DateFormat}");
Console.WriteLine($"Use Hijri Calendar: {date?.UseHijriCalendar}");
Console.WriteLine($"Use Saka Era Calendar: {date?.UseSakaEraCalendar}");
```

#### PRINTDATE

Inserts the date and time the document was last printed.

```csharp
var printDate = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("PRINTDATE \@ "h:mm am/pm"")) as PrintDateFieldInstruction;
```

#### TIME

Inserts the current time.

```csharp
var time = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("TIME \@ "h:mm am/pm"")) as TimeFieldInstruction;
Console.WriteLine($"Time Format: {time?.TimeFormat}");
```

### Mail Merge Fields

#### ADDRESSBLOCK

Inserts a formatted address block for mail merge.

```csharp
var addressBlock = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("ADDRESSBLOCK \c 2 \d \e "Test" \f "Recipient"")) as AddressBlockFieldInstruction;
Console.WriteLine($"Country Format: {addressBlock?.CountryFormat}");
Console.WriteLine($"Exclude Country: {addressBlock?.ExcludeCountryOrRegion}");
Console.WriteLine($"Format Name: {addressBlock?.FormatNameAs}");
```

#### GREETINGLINE

Inserts a greeting line for mail merge.

```csharp
var greetingLine = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("GREETINGLINE \f "Dear" \e "Sir or Madam" \d ":"")) as GreetingLineFieldInstruction;
Console.WriteLine($"Greeting Format: {greetingLine?.GreetingFormat}");
Console.WriteLine($"Default Greeting: {greetingLine?.DefaultGreeting}");
```

#### MERGEFIELD

Inserts data from a data source during mail merge.

```csharp
var mergeField = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("MERGEFIELD FirstName \b "(" \f ")") as MergeFieldFieldInstruction;
Console.WriteLine($"Field Name: {mergeField?.FieldName}");
Console.WriteLine($"Text Before: {mergeField?.TextBefore}");
Console.WriteLine($"Text After: {mergeField?.TextAfter}");
```

#### MERGEREC

Inserts the current merge record number.

```csharp
var mergeRec = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("MERGEREC")) as MergeRecFieldInstruction;
```

#### MERGESEQ

Inserts the merge sequence number.

```csharp
var mergeSeq = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("MERGESEQ")) as MergeSeqFieldInstruction;
```

#### NEXT

Merges the next data record into the current merge document.

```csharp
var next = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("NEXT")) as NextFieldInstruction;
```

#### NEXTIF

Merges the next data record if a condition is met.

```csharp
var nextIf = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("NEXTIF Amount > 1000")) as NextIfFieldInstruction;
Console.WriteLine($"Field Name: {nextIf?.FieldName}");
Console.WriteLine($"Comparison Operator: {nextIf?.ComparisonOperator}");
Console.WriteLine($"Comparison Value: {nextIf?.ComparisonValue}");
```

#### SKIPIF

Skips the current data record if a condition is met.

```csharp
var skipIf = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("SKIPIF City = "Seattle"")) as SkipIfFieldInstruction;
Console.WriteLine($"Field Name: {skipIf?.FieldName}");
Console.WriteLine($"Comparison Value: {skipIf?.ComparisonValue}");
```

### Reference Fields

#### REF

Creates a cross-reference to a bookmark.

```csharp
var refField = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("REF MyBookmark \h \p")) as RefFieldInstruction;
Console.WriteLine($"Bookmark Name: {refField?.BookmarkName}");
Console.WriteLine($"Insert Hyperlink: {refField?.InsertHyperlink}");
Console.WriteLine($"Insert Position: {refField?.InsertRelativePosition}");
```

#### PAGEREF

Creates a cross-reference to the page number of a bookmark.

```csharp
var pageRef = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("PAGEREF MyBookmark \h")) as PageRefFieldInstruction;
Console.WriteLine($"Bookmark Name: {pageRef?.BookmarkName}");
Console.WriteLine($"Insert Hyperlink: {pageRef?.InsertHyperlink}");
```

#### STYLEREF

References text formatted with a specific style.

```csharp
var styleRef = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("STYLEREF "Heading 1" \l \n \p \r \t \w")) as StyleRefFieldInstruction;
Console.WriteLine($"Style Name: {styleRef?.StyleName}");
Console.WriteLine($"Search From Bottom: {styleRef?.SearchFromBottom}");
Console.WriteLine($"Insert Paragraph Number: {styleRef?.InsertParagraphNumber}");
```

#### NOTEREF

Creates a cross-reference to a footnote or endnote.

```csharp
var noteRef = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("NOTEREF MyNote \f \h \p")) as NoteRefFieldInstruction;
Console.WriteLine($"Bookmark Name: {noteRef?.BookmarkName}");
Console.WriteLine($"Insert Footnote Reference: {noteRef?.InsertFootnoteReference}");
```

### Page and Section Fields

#### PAGE

Inserts the current page number.

```csharp
var page = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("PAGE \* Arabic")) as PageFieldInstruction;
Console.WriteLine($"Number Format: {page?.NumberFormat}");
```

#### SECTION

Inserts the current section number.

```csharp
var section = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("SECTION")) as SectionFieldInstruction;
```

#### SECTIONPAGES

Inserts the total number of pages in the current section.

```csharp
var sectionPages = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("SECTIONPAGES")) as SectionPagesFieldInstruction;
```

### Numbering Fields

#### AUTONUM

Automatically numbers paragraphs.

```csharp
var autoNum = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("AUTONUM \s "-"")) as AutoNumFieldInstruction;
Console.WriteLine($"Separator Character: {autoNum?.SeparatorCharacter}");
```

#### AUTONUMLGL

Provides legal-style paragraph numbering.

```csharp
var autoNumLgl = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("AUTONUMLGL \e")) as AutoNumLglFieldInstruction;
Console.WriteLine($"Remove Trailing Period: {autoNumLgl?.RemoveTrailingSeparator}");
```

#### AUTONUMOUT

Provides outline-style paragraph numbering.

```csharp
var autoNumOut = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("AUTONUMOUT")) as AutoNumOutFieldInstruction;
```

#### LISTNUM

Inserts numbers for paragraphs in a list.

```csharp
var listNum = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("LISTNUM "NumberDefault" \l 2 \s 3")) as ListNumFieldInstruction;
Console.WriteLine($"List Name: {listNum?.ListName}");
Console.WriteLine($"List Level: {listNum?.ListLevel}");
Console.WriteLine($"Starting Value: {listNum?.StartingValue}");
```

#### SEQ

Creates a sequence number.

```csharp
var seq = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("SEQ Figure \c \h \n \r 5 \s 10")) as SeqFieldInstruction;
Console.WriteLine($"Sequence Identifier: {seq?.SequenceIdentifier}");
Console.WriteLine($"Insert Next Number: {seq?.InsertNextNumber}");
Console.WriteLine($"Hide Field Result: {seq?.HideFieldResult}");
Console.WriteLine($"Reset Number: {seq?.ResetNumber}");
Console.WriteLine($"Reset Value: {seq?.ResetValue}");
Console.WriteLine($"Starting Value: {seq?.StartingValue}");
```

### Index and Table Fields

#### INDEX

Creates an index.

```csharp
var index = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("INDEX \b MyBookmark \c 3 \d "-" \e "" \f A \g ":" \h "A" \k ":" \l ":" \p A-Z \r \s A \z 1033")) as IndexFieldInstruction;
Console.WriteLine($"Bookmark Name: {index?.BookmarkName}");
Console.WriteLine($"Number of Columns: {index?.NumberOfColumns}");
Console.WriteLine($"Sequence Name: {index?.SequenceName}");
```

#### TOC

Creates a table of contents.

```csharp
var toc = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("TOC \o "1-3" \h \z \u")) as TocFieldInstruction;
Console.WriteLine($"Outline Levels: {toc?.OutlineLevels}");
Console.WriteLine($"Use Hyperlinks: {toc?.UseHyperlinks}");
Console.WriteLine($"Hide Tab Leader: {toc?.HideTabLeaderAndPageNumber}");
Console.WriteLine($"Use Outline Entries: {toc?.UseOutlineEntries}");
```

#### TOA

Creates a table of authorities.

```csharp
var toa = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("TOA \c 1 \b MyBookmark \e "," \f \g "" \l "," \p \s A")) as ToaFieldInstruction;
Console.WriteLine($"Category: {toa?.Category}");
Console.WriteLine($"Bookmark Name: {toa?.BookmarkName}");
Console.WriteLine($"Entry Separator: {toa?.EntrySeparator}");
```

#### XE

Marks an index entry.

```csharp
var xe = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("XE "Main Entry:Sub Entry" \b \f A \i \r MyBookmark \t "See Also"")) as XeFieldInstruction;
Console.WriteLine($"Entry Text: {xe?.EntryText}");
Console.WriteLine($"Apply Bold: {xe?.ApplyBoldFormatting}");
Console.WriteLine($"Entry Type: {xe?.EntryType}");
Console.WriteLine($"Apply Italic: {xe?.ApplyItalicFormatting}");
Console.WriteLine($"Page Range Bookmark: {xe?.PageRangeBookmarkName}");
Console.WriteLine($"Cross Reference Text: {xe?.CrossReferenceText}");
```

#### TA

Marks a table of authorities entry.

```csharp
var ta = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("TA \c 1 \l "Long Citation" \s "Short Citation" \b \i \r MyBookmark")) as TaFieldInstruction;
Console.WriteLine($"Category: {ta?.Category}");
Console.WriteLine($"Long Citation: {ta?.LongCitation}");
Console.WriteLine($"Short Citation: {ta?.ShortCitation}");
Console.WriteLine($"Apply Bold: {ta?.ApplyBoldFormatting}");
Console.WriteLine($"Apply Italic: {ta?.ApplyItalicFormatting}");
Console.WriteLine($"Page Range Bookmark: {ta?.PageRangeBookmarkName}");
```

#### TC

Marks a table of contents entry.

```csharp
var tc = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("TC "Entry Text" \f C \l 2 \n")) as TcFieldInstruction;
Console.WriteLine($"Entry Text: {tc?.EntryText}");
Console.WriteLine($"Entry Type: {tc?.EntryType}");
Console.WriteLine($"Level: {tc?.Level}");
Console.WriteLine($"No Page Number: {tc?.NoPageNumber}");
```

### Form Fields

#### FORMCHECKBOX

Creates a checkbox form field.

```csharp
var formCheckBox = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("FORMCHECKBOX \default 1 \size 12")) as FormCheckBoxFieldInstruction;
Console.WriteLine($"Default State: {formCheckBox?.DefaultState}");
Console.WriteLine($"Size: {formCheckBox?.Size}");
```

#### FORMDROPDOWN

Creates a dropdown form field.

```csharp
var formDropDown = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("FORMDROPDOWN \l "Option1,Option2,Option3"")) as FormDropDownFieldInstruction;
Console.WriteLine($"Items: {formDropDown?.Items}");
```

#### FORMTEXT

Creates a text form field.

```csharp
var formText = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("FORMTEXT \default "Default Text" \maxlen 50 \type 0 \format "UPPERCASE"")) as FormTextFieldInstruction;
Console.WriteLine($"Default Text: {formText?.DefaultText}");
Console.WriteLine($"Maximum Length: {formText?.MaximumLength}");
Console.WriteLine($"Text Type: {formText?.TextType}");
Console.WriteLine($"Text Format: {formText?.TextFormat}");
```

### User Information Fields

#### USERNAME

Retrieves the user's name.

```csharp
var userName = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("USERNAME")) as UserNameFieldInstruction;
```

#### USERINITIALS

Retrieves the user's initials.

```csharp
var userInitials = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("USERINITIALS")) as UserInitialsFieldInstruction;
```

#### USERADDRESS

Retrieves the user's address.

```csharp
var userAddress = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("USERADDRESS")) as UserAddressFieldInstruction;
```

### Interactive Fields

#### ASK

Prompts the user to enter information and assigns it to a bookmark.

```csharp
var ask = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("ASK MyBookmark "Enter your name:" \d "Default Name" \o")) as AskFieldInstruction;
Console.WriteLine($"Bookmark Name: {ask?.BookmarkName}");
Console.WriteLine($"Prompt Text: {ask?.PromptText}");
Console.WriteLine($"Default Response: {ask?.DefaultResponse}");
Console.WriteLine($"Prompt Once: {ask?.PromptOncePerMailMerge}");
```

#### FILLIN

Prompts the user to enter text.

```csharp
var fillIn = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("FILLIN "Enter text:" \d "Default" \o")) as FillInFieldInstruction;
Console.WriteLine($"Prompt Text: {fillIn?.PromptText}");
Console.WriteLine($"Default Text: {fillIn?.DefaultText}");
Console.WriteLine($"Prompt Once: {fillIn?.PromptOncePerMailMerge}");
```

### Button Fields

#### GOTOBUTTON

Creates a button that jumps to a location in the document.

```csharp
var gotoButton = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("GOTOBUTTON MyBookmark "Click here"")) as GoToButtonFieldInstruction;
Console.WriteLine($"Location: {gotoButton?.Location}");
Console.WriteLine($"Display Text: {gotoButton?.DisplayText}");
```

#### MACROBUTTON

Creates a button that runs a macro.

```csharp
var macroButton = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("MACROBUTTON MyMacro "Run Macro"")) as MacroButtonFieldInstruction;
Console.WriteLine($"Macro Name: {macroButton?.MacroName}");
Console.WriteLine($"Display Text: {macroButton?.DisplayText}");
```

### Advanced Fields

#### DATABASE

Inserts data from an external database.

```csharp
var database = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("DATABASE \d "DSN=MyDB" \s "SELECT * FROM Table" \c FirstRecord \b Table \l LastRecord \f 1 \t \h")) as DatabaseFieldInstruction;
Console.WriteLine($"Connection String: {database?.ConnectionString}");
Console.WriteLine($"SQL Statement: {database?.SqlStatement}");
Console.WriteLine($"Connect Once: {database?.ConnectOnce}");
```

#### EQ

Creates mathematical equations.

```csharp
var eq = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("EQ \f(x,y) = x + y")) as EqFieldInstruction;
Console.WriteLine($"Equation Text: {eq?.EquationText}");
```

#### HYPERLINK

Creates a hyperlink.

```csharp
var hyperlink = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("HYPERLINK "http://example.com" \l "bookmark" \m "map" \n \o "tooltip" \t "_blank"")) as HyperlinkFieldInstruction;
Console.WriteLine($"URL: {hyperlink?.Url}");
Console.WriteLine($"Bookmark: {hyperlink?.Bookmark}");
Console.WriteLine($"Image Map: {hyperlink?.ImageMapCoordinates}");
Console.WriteLine($"Create New Window: {hyperlink?.CreateNewWindow}");
Console.WriteLine($"Screen Tip: {hyperlink?.ScreenTip}");
Console.WriteLine($"Target Frame: {hyperlink?.TargetFrame}");
```

#### QUOTE

Includes literal text in the field result.

```csharp
var quote = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("QUOTE "Literal text"")) as QuoteFieldInstruction;
Console.WriteLine($"Literal Text: {quote?.LiteralText}");
```

### Conditional Fields

#### IF

Performs conditional logic.

```csharp
var ifField = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("IF { MERGEFIELD Amount } > 1000 "Large" "Small"")) as IfFieldInstruction;
Console.WriteLine($"Expression1: {ifField?.Expression1}");
Console.WriteLine($"Comparison Operator: {ifField?.ComparisonOperator}");
Console.WriteLine($"Expression2: {ifField?.Expression2}");
Console.WriteLine($"True Text: {ifField?.TrueText}");
Console.WriteLine($"False Text: {ifField?.FalseText}");
```

#### COMPARE

Compares two expressions.

```csharp
var compare = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("COMPARE 5 = 5")) as CompareFieldInstruction;
Console.WriteLine($"Expression1: {compare?.Expression1}");
Console.WriteLine($"Comparison Operator: {compare?.ComparisonOperator}");
Console.WriteLine($"Expression2: {compare?.Expression2}");
```

### Other Fields

#### ADVANCE

Moves text to a specific position.

```csharp
var advance = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("ADVANCE \d 10 \l 5 \r 15 \u 8 \x 100 \y 50")) as AdvanceFieldInstruction;
Console.WriteLine($"Down: {advance?.Down}");
Console.WriteLine($"Left: {advance?.Left}");
Console.WriteLine($"Right: {advance?.Right}");
Console.WriteLine($"Up: {advance?.Up}");
Console.WriteLine($"Horizontal Position: {advance?.HorizontalPosition}");
Console.WriteLine($"Vertical Position: {advance?.VerticalPosition}");
```

#### AUTOTEXT

Inserts AutoText entries.

```csharp
var autoText = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("AUTOTEXT MyAutoText")) as AutoTextFieldInstruction;
Console.WriteLine($"AutoText Name: {autoText?.AutoTextName}");
```

#### AUTOTEXTLIST

Creates a list of AutoText entries.

```csharp
var autoTextList = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("AUTOTEXTLIST \s "MyStyle" \t ","")) as AutoTextListFieldInstruction;
Console.WriteLine($"Style Name: {autoTextList?.StyleName}");
Console.WriteLine($"Separator: {autoTextList?.Separator}");
```

#### BARCODE

Creates a barcode.

```csharp
var barcode = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("BARCODE "123456789" \t PostalBarcode \u \b \d \h 50 \s 100 \c CODE128 \q 3 \r 0")) as BarcodeFieldInstruction;
Console.WriteLine($"Postal Address: {barcode?.PostalAddress}");
Console.WriteLine($"Barcode Type: {barcode?.BarcodeType}");
Console.WriteLine($"US Postal: {barcode?.IsUSPostalAddress}");
Console.WriteLine($"Add Border: {barcode?.AddBorder}");
Console.WriteLine($"Display Data: {barcode?.DisplayPostalAddressData}");
Console.WriteLine($"Height: {barcode?.Height}");
Console.WriteLine($"Scale: {barcode?.Scale}");
Console.WriteLine($"Case Code: {barcode?.CaseCode}");
Console.WriteLine($"Error Correction: {barcode?.ErrorCorrectionLevel}");
Console.WriteLine($"Rotation: {barcode?.Rotation}");
```

#### BIBLIOGRAPHY

Creates a bibliography.

```csharp
var bibliography = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("BIBLIOGRAPHY \l 1033")) as BibliographyFieldInstruction;
Console.WriteLine($"Language ID: {bibliography?.LanguageId}");
```

#### CITATION

Creates a citation.

```csharp
var citation = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("CITATION Author2023 \l 1033 \m AuthorYear \n \p 25 \s 10 \t \v 2 \y")) as CitationFieldInstruction;
Console.WriteLine($"Tag: {citation?.Tag}");
Console.WriteLine($"Language ID: {citation?.LanguageId}");
Console.WriteLine($"Format Style: {citation?.FormatStyle}");
Console.WriteLine($"Suppress Author: {citation?.SuppressAuthor}");
Console.WriteLine($"Page Number: {citation?.PageNumber}");
Console.WriteLine($"Suffix: {citation?.Suffix}");
Console.WriteLine($"Suppress Title: {citation?.SuppressTitle}");
Console.WriteLine($"Volume Number: {citation?.VolumeNumber}");
Console.WriteLine($"Suppress Year: {citation?.SuppressYear}");
```

#### DOCPROPERTY

Retrieves document properties.

```csharp
var docProperty = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("DOCPROPERTY Title")) as DocPropertyFieldInstruction;
Console.WriteLine($"Property Name: {docProperty?.PropertyName}");
Console.WriteLine($"Category Argument: {docProperty?.PropertyCategoryArgument}");
```

#### DOCVARIABLE

Retrieves document variables.

```csharp
var docVariable = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("DOCVARIABLE MyVariable")) as DocVariableFieldInstruction;
Console.WriteLine($"Variable Name: {docVariable?.VariableName}");
```

#### INCLUDEPICTURE

Includes a picture from an external source.

```csharp
var includePicture = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("INCLUDEPICTURE "C:\image.jpg" \c converter \d")) as IncludePictureFieldInstruction;
Console.WriteLine($"Source Path: {includePicture?.SourcePath}");
Console.WriteLine($"Graphics Filter: {includePicture?.GraphicsFilter}");
Console.WriteLine($"Do Not Store: {includePicture?.DoNotStore}");
```

#### INCLUDETEXT

Includes text from an external source.

```csharp
var includeText = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("INCLUDETEXT "C:\document.docx" \c converter \b MyBookmark")) as IncludeTextFieldInstruction;
Console.WriteLine($"Source Path: {includeText?.SourcePath}");
Console.WriteLine($"Text Converter: {includeText?.TextConverter}");
Console.WriteLine($"Bookmark Name: {includeText?.BookmarkName}");
```

#### INFO

Retrieves document information.

```csharp
var info = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("INFO Title")) as InfoFieldInstruction;
Console.WriteLine($"Info Type: {info?.InfoType}");
```

#### LINK

Creates a link to external data.

```csharp
var link = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("LINK Excel.Sheet "C:\data.xlsx" Sheet1!R1C1:R10C5 \a \b \f 19 \h \p \t")) as LinkFieldInstruction;
Console.WriteLine($"Program Class: {link?.ProgramClass}");
Console.WriteLine($"Source File: {link?.SourceFile}");
Console.WriteLine($"Place Reference: {link?.PlaceReference}");
Console.WriteLine($"Update Automatically: {link?.UpdateAutomatically}");
Console.WriteLine($"Insert as Bitmap: {link?.InsertAsBitmap}");
Console.WriteLine($"Format: {link?.Format}");
Console.WriteLine($"Insert as HTML: {link?.InsertAsHtml}");
Console.WriteLine($"Insert as Picture: {link?.InsertAsPicture}");
Console.WriteLine($"Insert as RTF: {link?.InsertAsRtf}");
Console.WriteLine($"Insert as Text: {link?.InsertAsText}");
```

#### PRINT

Sends characters to the printer.

```csharp
var print = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("PRINT "Print this text"")) as PrintFieldInstruction;
Console.WriteLine($"Printer Instructions: {print?.PrinterInstructions}");
```

#### RD

References a document for index or table operations.

```csharp
var rd = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("RD "C:\reference.docx"")) as RdFieldInstruction;
Console.WriteLine($"Referenced Document: {rd?.ReferencedDocument}");
```

#### SET

Sets the value of a bookmark.

```csharp
var set = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("SET MyBookmark "New Value"")) as SetFieldInstruction;
Console.WriteLine($"Bookmark Name: {set?.BookmarkName}");
Console.WriteLine($"Bookmark Text: {set?.BookmarkText}");
```

#### SYMBOL

Inserts a symbol.

```csharp
var symbol = TypedFieldInstructionFactory.Create(FieldInstructionParser.Parse("SYMBOL 65 \f Arial \s 12 \u")) as SymbolFieldInstruction;
Console.WriteLine($"Character Code: {symbol?.CharacterCode}");
Console.WriteLine($"Font Name: {symbol?.FontName}");
Console.WriteLine($"Font Size: {symbol?.FontSize}");
Console.WriteLine($"Unicode: {symbol?.Unicode}");
```

## Factory Pattern

The `TypedFieldInstructionFactory` uses a factory pattern to create appropriate typed instances:

```csharp
public static class TypedFieldInstructionFactory
{
    public static TypedFieldInstruction? Create(FieldInstruction genericInstruction)
    {
        // Returns appropriate typed instruction or null if parsing fails
    }
}
```

### Error Handling

The factory returns `null` for malformed instructions or when parsing fails, allowing graceful fallback to the generic `FieldInstruction`.

## Performance Considerations

- Typed instructions are created on-demand through the factory
- The original `FieldInstruction` is preserved and accessible through the `Source` property
- Failed conversions return `null` rather than throwing exceptions for performance
- Each typed instruction parses its specific switches and arguments once during construction

## Extensibility

The typed field instruction system is designed to be extensible. New field types can be added by:

1. Creating a new class that inherits from `TypedFieldInstruction`
2. Implementing field-specific properties and parsing logic in the constructor
3. Adding the type to the `TypedFieldInstructionFactory` switch statement

## Real-World Usage Examples

### Mail Merge Document Processing

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Typed;

// Process mail merge fields in a document template
var fields = new List<string>
{
    "MERGEFIELD FirstName \b "Dear " \f ","",
    "MERGEFIELD LastName \* Upper",
    "ADDRESSBLOCK \c 2 \e "Customer" \f "Mr./Ms."",
    "GREETINGLINE \f "Dear" \e "Valued Customer" \d ":""
};

foreach (var fieldCode in fields)
{
    var instruction = FieldInstructionParser.Parse(fieldCode);
    var typedInstruction = TypedFieldInstructionFactory.Create(instruction);

    switch (typedInstruction)
    {
        case MergeFieldFieldInstruction merge:
            Console.WriteLine($"Merge Field: {merge.FieldName}");
            if (merge.TextBefore != null)
                Console.WriteLine($"  Text Before: {merge.TextBefore}");
            if (merge.TextAfter != null)
                Console.WriteLine($"  Text After: {merge.TextAfter}");
            break;

        case AddressBlockFieldInstruction address:
            Console.WriteLine($"Address Block - Country Format: {address.CountryFormat}");
            Console.WriteLine($"  Format Name As: {address.FormatNameAs}");
            break;

        case GreetingLineFieldInstruction greeting:
            Console.WriteLine($"Greeting Line - Format: {greeting.GreetingFormat}");
            Console.WriteLine($"  Default: {greeting.DefaultGreeting}");
            break;
    }
}
```

### Document Cross-References

```csharp
// Handle various types of cross-references
var referenceFields = new[]
{
    "REF MyBookmark \h \p",
    "PAGEREF ChapterStart \h",
    "STYLEREF "Heading 1" \l \n",
    "NOTEREF FootnoteRef \f \h"
};

foreach (var fieldCode in referenceFields)
{
    var instruction = FieldInstructionParser.Parse(fieldCode);
    var typedInstruction = TypedFieldInstructionFactory.Create(instruction);

    switch (typedInstruction)
    {
        case RefFieldInstruction refField:
            Console.WriteLine($"Reference to: {refField.BookmarkName}");
            Console.WriteLine($"  Insert Hyperlink: {refField.InsertHyperlink}");
            Console.WriteLine($"  Insert Position: {refField.InsertRelativePosition}");
            break;

        case PageRefFieldInstruction pageRef:
            Console.WriteLine($"Page Reference to: {pageRef.BookmarkName}");
            Console.WriteLine($"  Insert Hyperlink: {pageRef.InsertHyperlink}");
            break;

        case StyleRefFieldInstruction styleRef:
            Console.WriteLine($"Style Reference: {styleRef.StyleName}");
            Console.WriteLine($"  Search from Bottom: {styleRef.SearchFromBottom}");
            Console.WriteLine($"  Insert Paragraph Number: {styleRef.InsertParagraphNumber}");
            break;

        case NoteRefFieldInstruction noteRef:
            Console.WriteLine($"Note Reference: {noteRef.BookmarkName}");
            Console.WriteLine($"  Insert Footnote Reference: {noteRef.InsertFootnoteReference}");
            break;
    }
}
```

### Form Field Processing

```csharp
// Process form fields for data collection
var formFields = new[]
{
    "FORMTEXT \default "Enter name here" \maxlen 50 \type 0",
    "FORMCHECKBOX \default 1 \size 12",
    "FORMDROPDOWN \l "Option1,Option2,Option3""
};

foreach (var fieldCode in formFields)
{
    var instruction = FieldInstructionParser.Parse(fieldCode);
    var typedInstruction = TypedFieldInstructionFactory.Create(instruction);

    switch (typedInstruction)
    {
        case FormTextFieldInstruction textField:
            Console.WriteLine($"Text Field - Default: {textField.DefaultText}");
            Console.WriteLine($"  Max Length: {textField.MaximumLength}");
            Console.WriteLine($"  Type: {textField.TextType}");
            break;

        case FormCheckBoxFieldInstruction checkBox:
            Console.WriteLine($"Checkbox - Default State: {checkBox.DefaultState}");
            Console.WriteLine($"  Size: {checkBox.Size}");
            break;

        case FormDropDownFieldInstruction dropDown:
            Console.WriteLine($"Dropdown - Items: {dropDown.Items}");
            break;
    }
}
```

### Date and Time Formatting

```csharp
// Handle various date/time field formats
var dateTimeFields = new[]
{
    "DATE \@ "MMMM d, yyyy" \h \s",
    "TIME \@ "h:mm am/pm"",
    "CREATEDATE \@ "dddd, MMMM d, yyyy"",
    "SAVEDATE \@ "MM/dd/yy h:mm am/pm""
};

foreach (var fieldCode in dateTimeFields)
{
    var instruction = FieldInstructionParser.Parse(fieldCode);
    var typedInstruction = TypedFieldInstructionFactory.Create(instruction);

    switch (typedInstruction)
    {
        case DateFieldInstruction date:
            Console.WriteLine($"Date Field - Format: {date.DateFormat}");
            Console.WriteLine($"  Use Hijri Calendar: {date.UseHijriCalendar}");
            Console.WriteLine($"  Use Saka Calendar: {date.UseSakaCalendar}");
            break;

        case TimeFieldInstruction time:
            Console.WriteLine($"Time Field - Format: {time.TimeFormat}");
            break;

        case CreateDateFieldInstruction createDate:
            Console.WriteLine($"Create Date - Format: {createDate.DateFormat}");
            break;

        case SaveDateFieldInstruction saveDate:
            Console.WriteLine($"Save Date - Format: {saveDate.DateFormat}");
            break;
    }
}
```

### Table of Contents and Index Generation

```csharp
// Process TOC and Index fields
var tocFields = new[]
{
    "TOC \o "1-3" \h \z \u",
    "INDEX \b MyBookmark \c 3 \e "" \h "A"",
    "XE "Main Entry:Sub Entry" \b \i \r BookmarkRange"
};

foreach (var fieldCode in tocFields)
{
    var instruction = FieldInstructionParser.Parse(fieldCode);
    var typedInstruction = TypedFieldInstructionFactory.Create(instruction);

    switch (typedInstruction)
    {
        case TocFieldInstruction toc:
            Console.WriteLine($"TOC - Outline Levels: {toc.OutlineLevels}");
            Console.WriteLine($"  Use Hyperlinks: {toc.UseHyperlinks}");
            Console.WriteLine($"  Hide Tab Leaders: {toc.HideTabLeaderAndPageNumber}");
            break;

        case IndexFieldInstruction index:
            Console.WriteLine($"Index - Bookmark: {index.BookmarkName}");
            Console.WriteLine($"  Columns: {index.NumberOfColumns}");
            Console.WriteLine($"  Heading Style: {index.HeadingStyle}");
            break;

        case XeFieldInstruction xe:
            Console.WriteLine($"Index Entry - Text: {xe.EntryText}");
            Console.WriteLine($"  Bold: {xe.ApplyBoldFormatting}");
            Console.WriteLine($"  Italic: {xe.ApplyItalicFormatting}");
            break;
    }
}
```

### Conditional Field Processing

```csharp
// Handle conditional logic fields
var conditionalFields = new[]
{
    "IF { MERGEFIELD Amount } > 1000 "Large Order" "Standard Order"",
    "COMPARE 5 = 5",
    "NEXTIF State = "CA"",
    "SKIPIF Amount < 100"
};

foreach (var fieldCode in conditionalFields)
{
    var instruction = FieldInstructionParser.Parse(fieldCode);
    var typedInstruction = TypedFieldInstructionFactory.Create(instruction);

    switch (typedInstruction)
    {
        case IfFieldInstruction ifField:
            Console.WriteLine($"IF Field - Expression1: {ifField.Expression1}");
            Console.WriteLine($"  Operator: {ifField.ComparisonOperator}");
            Console.WriteLine($"  Expression2: {ifField.Expression2}");
            Console.WriteLine($"  True Text: {ifField.TrueText}");
            Console.WriteLine($"  False Text: {ifField.FalseText}");
            break;

        case CompareFieldInstruction compare:
            Console.WriteLine($"Compare - Expression1: {compare.Expression1}");
            Console.WriteLine($"  Operator: {compare.ComparisonOperator}");
            Console.WriteLine($"  Expression2: {compare.Expression2}");
            break;

        case NextIfFieldInstruction nextIf:
            Console.WriteLine($"NextIf - Field: {nextIf.FieldName}");
            Console.WriteLine($"  Operator: {nextIf.ComparisonOperator}");
            Console.WriteLine($"  Value: {nextIf.ComparisonValue}");
            break;

        case SkipIfFieldInstruction skipIf:
            Console.WriteLine($"SkipIf - Field: {skipIf.FieldName}");
            Console.WriteLine($"  Value: {skipIf.ComparisonValue}");
            break;
    }
}
```

## Best Practices

1. Always check for `null` return values from the factory
2. Use pattern matching with `is` operator for type checking
3. Access the original instruction through the `Source` property when needed
4. Handle parsing exceptions gracefully by falling back to generic `FieldInstruction`
5. Use specific typed properties instead of parsing switches manually
6. Cache typed instructions if processing the same field multiple times
7. Validate field-specific constraints (e.g., date formats, bookmark names) before creating instructions
