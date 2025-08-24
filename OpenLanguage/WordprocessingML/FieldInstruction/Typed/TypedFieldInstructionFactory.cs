using System;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Factory for creating strongly-typed field instructions.
    /// </summary>
    public static class TypedFieldInstructionFactory
    {
        /// <summary>
        /// Creates a strongly-typed field instruction from a generic FieldInstruction.
        /// </summary>
        /// <param name="genericInstruction">The generic field instruction to convert.</param>
        /// <returns>A strongly-typed field instruction, or null if the type is not supported.</returns>
        public static TypedFieldInstruction? Create(FieldInstruction? genericInstruction)
        {
            if (genericInstruction == null)
            {
                throw new ArgumentNullException(nameof(genericInstruction));
            }

            switch (genericInstruction.Instruction.ToUpperInvariant())
            {
                case "ADDRESSBLOCK":
                    try
                    {
                        return new AddressBlockFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "ADVANCE":
                    try
                    {
                        return new AdvanceFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "ASK":
                    try
                    {
                        return new AskFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "AUTHOR":
                    try
                    {
                        return new AuthorFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "AUTONUM":
                    try
                    {
                        return new AutoNumFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "AUTONUMLGL":
                    try
                    {
                        return new AutoNumLglFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "AUTONUMOUT":
                    try
                    {
                        return new AutoNumOutFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "AUTOTEXT":
                    try
                    {
                        return new AutoTextFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "AUTOTEXTLIST":
                    try
                    {
                        return new AutoTextListFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "BARCODE":
                    try
                    {
                        return new BarcodeFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "BIBLIOGRAPHY":
                    try
                    {
                        return new BibliographyFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "CITATION":
                    try
                    {
                        return new CitationFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "COMMENTS":
                    try
                    {
                        return new CommentsFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "COMPARE":
                    try
                    {
                        return new CompareFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "CREATEDATE":
                    try
                    {
                        return new CreateDateFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "DATABASE":
                    try
                    {
                        return new DatabaseFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "DATE":
                    try
                    {
                        return new DateFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "DOCPROPERTY":
                    try
                    {
                        return new DocPropertyFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "DOCVARIABLE":
                    try
                    {
                        return new DocVariableFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "EDITTIME":
                    try
                    {
                        return new EditTimeFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "EQ":
                    try
                    {
                        return new EqFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "FILENAME":
                    try
                    {
                        return new FileNameFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "FILESIZE":
                    try
                    {
                        return new FileSizeFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "FILLIN":
                    try
                    {
                        return new FillInFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "FORMCHECKBOX":
                    try
                    {
                        return new FormCheckBoxFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "FORMDROPDOWN":
                    try
                    {
                        return new FormDropDownFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "FORMTEXT":
                    try
                    {
                        return new FormTextFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "GOTOBUTTON":
                    try
                    {
                        return new GoToButtonFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "GREETINGLINE":
                    try
                    {
                        return new GreetingLineFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "HYPERLINK":
                    try
                    {
                        return new HyperlinkFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "IF":
                    try
                    {
                        return new IfFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "INCLUDEPICTURE":
                    try
                    {
                        return new IncludePictureFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "INCLUDETEXT":
                    try
                    {
                        return new IncludeTextFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "INDEX":
                    try
                    {
                        return new IndexFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "INFO":
                    try
                    {
                        return new InfoFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "KEYWORDS":
                    try
                    {
                        return new KeywordsFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "LASTSAVEDBY":
                    try
                    {
                        return new LastSavedByFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "LINK":
                    try
                    {
                        return new LinkFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "LISTNUM":
                    try
                    {
                        return new ListNumFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "MACROBUTTON":
                    try
                    {
                        return new MacroButtonFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "MERGEFIELD":
                    try
                    {
                        return new MergeFieldFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "MERGEREC":
                    try
                    {
                        return new MergeRecFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "MERGESEQ":
                    try
                    {
                        return new MergeSeqFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "NEXT":
                    try
                    {
                        return new NextFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "NEXTIF":
                    try
                    {
                        return new NextIfFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "NOTEREF":
                    try
                    {
                        return new NoteRefFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "NUMCHARS":
                    try
                    {
                        return new NumCharsFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "NUMPAGES":
                    try
                    {
                        return new NumPagesFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "NUMWORDS":
                    try
                    {
                        return new NumWordsFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "PAGE":
                    try
                    {
                        return new PageFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "PAGEREF":
                    try
                    {
                        return new PageRefFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "PRINT":
                    try
                    {
                        return new PrintFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "PRINTDATE":
                    try
                    {
                        return new PrintDateFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "QUOTE":
                    try
                    {
                        return new QuoteFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "RD":
                    try
                    {
                        return new RdFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "REF":
                    try
                    {
                        return new RefFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "REVNUM":
                    try
                    {
                        return new RevNumFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "SAVEDATE":
                    try
                    {
                        return new SaveDateFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "SECTION":
                    try
                    {
                        return new SectionFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "SECTIONPAGES":
                    try
                    {
                        return new SectionPagesFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "SEQ":
                    try
                    {
                        return new SeqFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "SET":
                    try
                    {
                        return new SetFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "SKIPIF":
                    try
                    {
                        return new SkipIfFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "STYLEREF":
                    try
                    {
                        return new StyleRefFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "SUBJECT":
                    try
                    {
                        return new SubjectFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "SYMBOL":
                    try
                    {
                        return new SymbolFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "TA":
                    try
                    {
                        return new TaFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "TC":
                    try
                    {
                        return new TcFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "TEMPLATE":
                    try
                    {
                        return new TemplateFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "TIME":
                    try
                    {
                        return new TimeFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "TITLE":
                    try
                    {
                        return new TitleFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "TOA":
                    try
                    {
                        return new ToaFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "TOC":
                    try
                    {
                        return new TocFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "USERADDRESS":
                    try
                    {
                        return new UserAddressFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "USERINITIALS":
                    try
                    {
                        return new UserInitialsFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "USERNAME":
                    try
                    {
                        return new UserNameFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                case "XE":
                    try
                    {
                        return new XeFieldInstruction(genericInstruction);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }
                default:
                    return null;
            }
        }
    }
}
