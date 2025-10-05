using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum TocArgument
    {
        CaptionIdentifier,
        BookmarkName,
        SequenceIdentifier,
        SequenceSeparator,
        TableType,
        CreateHyperlinks,
        TcFieldLevels,
        OmitPageNumbers,
        HeadingStyleRange,
        PageNumberSeparator,
        SeqFieldIdentifier,
        CustomStyles,
        UseOutlineLevels,
        PreserveTabEntries,
        PreserveNewlines,
        HideTabLeaderInWebView,
        GeneralFormat,
        EntryPageSeparator,
    }

    /// <summary>
    /// Represents a strongly-typed TOC field instruction.
    /// Builds a table of contents (which can also be a table of figures) using the entries specified by TC fields,
    /// their heading levels, and specified styles, and inserts that table at this place in the document.
    /// Each table entry is a separate paragraph.
    /// </summary>
    public class TocFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// Switch: \a field-argument
        /// Includes captioned items, but omits caption labels and numbers. The identifier designated by text
        /// in this switch's field-argument corresponds to the caption label. Use \c to build a table of captions
        /// with labels and numbers.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? CaptionIdentifier { get; set; }

        /// <summary>
        /// Switch: \b field-argument
        /// Includes entries only from the portion of the document marked by the bookmark named by text
        /// in this switch's field-argument.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Includes figures, tables, charts, and other items that are numbered by a SEQ field. The sequence
        /// identifier designated by text in this switch's field-argument, which corresponds to the caption label,
        /// shall match the identifier in the corresponding SEQ field.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SequenceIdentifier { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// When used with \s, the text in this switch's field-argument defines the separator between sequence
        /// and page numbers. The default separator is a hyphen (-).
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SequenceSeparator { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Includes only those TC fields whose type exactly matches the text in this switch's field-argument
        /// (which is typically a letter).
        /// </summary>
        public FlaggedArgument<ExpressionNode>? TableType { get; set; }

        /// <summary>
        /// Switch: \h
        /// Makes the table of contents entries hyperlinks.
        /// </summary>
        public BoolFlagNode? CreateHyperlinks { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Includes TC fields that assign entries to one of the levels specified by text in this switch's
        /// field-argument as a range having the form startLevel-endLevel, where startLevel and endLevel are
        /// integers, and startLevel has a value equal-to or less-than endLevel. TC fields that assign entries
        /// to lower levels are skipped.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? TcFieldLevels { get; set; }

        /// <summary>
        /// Switch: \n field-argument
        /// Without field-argument, omits page numbers from the table of contents. Page numbers are omitted
        /// from all levels unless a range of entry levels is specified by text in this switch's field-argument.
        /// A range is specified as for \l.
        ///
        /// For example, { TOC \n 3-4 } omits page numbers from levels 3 and 4. Delete this switch to include page numbers.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? OmitPageNumbers { get; set; }

        /// <summary>
        /// Switch: \o field-argument
        /// Uses paragraphs formatted with all or the specified range of built-in heading styles. Headings in
        /// a style range are specified by text in this switch's field-argument using the notation specified as
        /// for \l, where each integer corresponds to the style with a style ID of HeadingX (e.g. 1 corresponds
        /// to Heading1). If no heading range is specified, all heading levels used in the document are listed.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? HeadingStyleRange { get; set; }

        /// <summary>
        /// Switch: \p field-argument
        /// Text in this switch's field-argument specifies a sequence of characters that separate an entry
        /// and its page number. The default is a tab with leader dots.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? PageNumberSeparator { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// For entries numbered with a SEQ field, adds a prefix to the page number. The prefix depends on
        /// the type of entry. Text in this switch's field-argument shall match the identifier in the SEQ field.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SeqFieldIdentifier { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Uses paragraphs formatted with styles other than the built-in heading styles. Text in this switch's
        /// field-argument specifies those styles as a set of comma-separated doublets, with each doublet being
        /// a comma-separated set of style name and table of content level. \t can be combined with \o.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? CustomStyles { get; set; }

        /// <summary>
        /// Switch: \u
        /// Uses the applied paragraph outline level.
        /// </summary>
        public BoolFlagNode? UseOutlineLevels { get; set; }

        /// <summary>
        /// Switch: \w
        /// Preserves tab entries within table entries.
        /// </summary>
        public BoolFlagNode? PreserveTabEntries { get; set; }

        /// <summary>
        /// Switch: \x
        /// Preserves newline characters within table entries.
        /// </summary>
        public FlagNode? PreserveNewlines { get; set; }

        /// <summary>
        /// Switch: \z
        /// Hides tab leader and page numbers in Web layout view.
        /// </summary>
        public BoolFlagNode? HideTabLeaderInWebView { get; set; }

        /// <summary>
        /// General formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        /// <summary>
        /// Switch: \e field-argument
        /// Undocumented switch, seems to specify the character sequence that separates a table of contents entry and its page number.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? EntryPageSeparator { get; set; }

        public List<TocArgument> Order { get; set; } = new List<TocArgument>();

        public TocFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? captionIdentifier,
            FlaggedArgument<ExpressionNode>? bookmarkName,
            FlaggedArgument<ExpressionNode>? sequenceIdentifier,
            FlaggedArgument<ExpressionNode>? sequenceSeparator,
            FlaggedArgument<ExpressionNode>? tcFieldIdentifier,
            BoolFlagNode? createHyperlinks,
            FlaggedArgument<ExpressionNode>? tcFieldLevels,
            FlaggedArgument<ExpressionNode>? omitPageNumbers,
            FlaggedArgument<ExpressionNode>? headingStyleRange,
            FlaggedArgument<ExpressionNode>? pageNumberSeparator,
            FlaggedArgument<ExpressionNode>? seqFieldIdentifier,
            FlaggedArgument<ExpressionNode>? customStyles,
            BoolFlagNode? useOutlineLevels,
            BoolFlagNode? preserveTabEntries,
            FlagNode? preserveNewlines,
            BoolFlagNode? hideTabLeaderInWebView,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? entryPageSeparator,
            List<TocArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            CaptionIdentifier = captionIdentifier;
            BookmarkName = bookmarkName;
            SequenceIdentifier = sequenceIdentifier;
            SequenceSeparator = sequenceSeparator;
            TableType = tcFieldIdentifier;
            CreateHyperlinks = createHyperlinks;
            TcFieldLevels = tcFieldLevels;
            OmitPageNumbers = omitPageNumbers;
            HeadingStyleRange = headingStyleRange;
            PageNumberSeparator = pageNumberSeparator;
            SeqFieldIdentifier = seqFieldIdentifier;
            CustomStyles = customStyles;
            UseOutlineLevels = useOutlineLevels;
            PreserveTabEntries = preserveTabEntries;
            PreserveNewlines = preserveNewlines;
            HideTabLeaderInWebView = hideTabLeaderInWebView;
            GeneralFormat = generalFormat;
            EntryPageSeparator = entryPageSeparator;

            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        TocArgument.CaptionIdentifier => CaptionIdentifier?.ToString()
                            ?? string.Empty,
                        TocArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        TocArgument.SequenceIdentifier => SequenceIdentifier?.ToString()
                            ?? string.Empty,
                        TocArgument.SequenceSeparator => SequenceSeparator?.ToString()
                            ?? string.Empty,
                        TocArgument.TableType => TableType?.ToString() ?? string.Empty,
                        TocArgument.CreateHyperlinks => CreateHyperlinks?.ToString()
                            ?? string.Empty,
                        TocArgument.TcFieldLevels => TcFieldLevels?.ToString() ?? string.Empty,
                        TocArgument.OmitPageNumbers => OmitPageNumbers?.ToString() ?? string.Empty,
                        TocArgument.HeadingStyleRange => HeadingStyleRange?.ToString()
                            ?? string.Empty,
                        TocArgument.PageNumberSeparator => PageNumberSeparator?.ToString()
                            ?? string.Empty,
                        TocArgument.SeqFieldIdentifier => SeqFieldIdentifier?.ToString()
                            ?? string.Empty,
                        TocArgument.CustomStyles => CustomStyles?.ToString() ?? string.Empty,
                        TocArgument.UseOutlineLevels => UseOutlineLevels?.ToString()
                            ?? string.Empty,
                        TocArgument.PreserveTabEntries => PreserveTabEntries?.ToString()
                            ?? string.Empty,
                        TocArgument.PreserveNewlines => PreserveNewlines?.ToString()
                            ?? string.Empty,
                        TocArgument.HideTabLeaderInWebView => HideTabLeaderInWebView?.ToString()
                            ?? string.Empty,
                        TocArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        TocArgument.EntryPageSeparator => EntryPageSeparator?.ToString()
                            ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            foreach (TocArgument arg in Order)
            {
                Node? child = arg switch
                {
                    TocArgument.CaptionIdentifier => CaptionIdentifier,
                    TocArgument.BookmarkName => BookmarkName,
                    TocArgument.SequenceIdentifier => SequenceIdentifier,
                    TocArgument.SequenceSeparator => SequenceSeparator,
                    TocArgument.TableType => TableType,
                    TocArgument.CreateHyperlinks => CreateHyperlinks,
                    TocArgument.TcFieldLevels => TcFieldLevels,
                    TocArgument.OmitPageNumbers => OmitPageNumbers,
                    TocArgument.HeadingStyleRange => HeadingStyleRange,
                    TocArgument.PageNumberSeparator => PageNumberSeparator,
                    TocArgument.SeqFieldIdentifier => SeqFieldIdentifier,
                    TocArgument.CustomStyles => CustomStyles,
                    TocArgument.UseOutlineLevels => UseOutlineLevels,
                    TocArgument.PreserveTabEntries => PreserveTabEntries,
                    TocArgument.PreserveNewlines => PreserveNewlines,
                    TocArgument.HideTabLeaderInWebView => HideTabLeaderInWebView,
                    TocArgument.GeneralFormat => GeneralFormat,
                    TocArgument.EntryPageSeparator => EntryPageSeparator,
                    _ => null,
                };

                if (child is O oChild)
                {
                    yield return oChild;
                }
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0)
            {
                if (replacement is StringLiteralNode instruction)
                {
                    current = Instruction;
                    Instruction = instruction;
                }
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    TocArgument arg = Order[index];
                    switch (arg)
                    {
                        case TocArgument.CaptionIdentifier:
                            if (replacement is FlaggedArgument<ExpressionNode> captionIdentifier)
                            {
                                current = CaptionIdentifier;
                                CaptionIdentifier = captionIdentifier;
                            }
                            break;
                        case TocArgument.BookmarkName:
                            if (replacement is FlaggedArgument<ExpressionNode> bookmarkName)
                            {
                                current = BookmarkName;
                                BookmarkName = bookmarkName;
                            }
                            break;
                        case TocArgument.SequenceIdentifier:
                            if (replacement is FlaggedArgument<ExpressionNode> sequenceIdentifier)
                            {
                                current = SequenceIdentifier;
                                SequenceIdentifier = sequenceIdentifier;
                            }
                            break;
                        case TocArgument.SequenceSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> sequenceSeparator)
                            {
                                current = SequenceSeparator;
                                SequenceSeparator = sequenceSeparator;
                            }
                            break;
                        case TocArgument.TableType:
                            if (replacement is FlaggedArgument<ExpressionNode> tcFieldIdentifier)
                            {
                                current = TableType;
                                TableType = tcFieldIdentifier;
                            }
                            break;
                        case TocArgument.CreateHyperlinks:
                            if (replacement is BoolFlagNode createHyperlinks)
                            {
                                current = CreateHyperlinks;
                                CreateHyperlinks = createHyperlinks;
                            }
                            break;
                        case TocArgument.TcFieldLevels:
                            if (replacement is FlaggedArgument<ExpressionNode> tcFieldLevels)
                            {
                                current = TcFieldLevels;
                                TcFieldLevels = tcFieldLevels;
                            }
                            break;
                        case TocArgument.OmitPageNumbers:
                            if (replacement is FlaggedArgument<ExpressionNode> omitPageNumbers)
                            {
                                current = OmitPageNumbers;
                                OmitPageNumbers = omitPageNumbers;
                            }
                            break;
                        case TocArgument.HeadingStyleRange:
                            if (replacement is FlaggedArgument<ExpressionNode> headingStyleRange)
                            {
                                current = HeadingStyleRange;
                                HeadingStyleRange = headingStyleRange;
                            }
                            break;
                        case TocArgument.PageNumberSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> pageNumberSeparator)
                            {
                                current = PageNumberSeparator;
                                PageNumberSeparator = pageNumberSeparator;
                            }
                            break;
                        case TocArgument.SeqFieldIdentifier:
                            if (replacement is FlaggedArgument<ExpressionNode> seqFieldIdentifier)
                            {
                                current = SeqFieldIdentifier;
                                SeqFieldIdentifier = seqFieldIdentifier;
                            }
                            break;
                        case TocArgument.CustomStyles:
                            if (replacement is FlaggedArgument<ExpressionNode> customStyles)
                            {
                                current = CustomStyles;
                                CustomStyles = customStyles;
                            }
                            break;
                        case TocArgument.UseOutlineLevels:
                            if (replacement is BoolFlagNode useOutlineLevels)
                            {
                                current = UseOutlineLevels;
                                UseOutlineLevels = useOutlineLevels;
                            }
                            break;
                        case TocArgument.PreserveTabEntries:
                            if (replacement is BoolFlagNode preserveTabEntries)
                            {
                                current = PreserveTabEntries;
                                PreserveTabEntries = preserveTabEntries;
                            }
                            break;
                        case TocArgument.PreserveNewlines:
                            if (replacement is FlagNode preserveNewlines)
                            {
                                current = PreserveNewlines;
                                PreserveNewlines = preserveNewlines;
                            }
                            break;
                        case TocArgument.HideTabLeaderInWebView:
                            if (replacement is BoolFlagNode hideTabLeaderInWebView)
                            {
                                current = HideTabLeaderInWebView;
                                HideTabLeaderInWebView = hideTabLeaderInWebView;
                            }
                            break;
                        case TocArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> generalFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = generalFormat;
                            }
                            break;
                        case TocArgument.EntryPageSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> entryPageSeparator)
                            {
                                current = EntryPageSeparator;
                                EntryPageSeparator = entryPageSeparator;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return current;
        }
    }
}
