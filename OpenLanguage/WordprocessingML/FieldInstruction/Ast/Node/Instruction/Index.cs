using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum IndexArgument
    {
        BookmarkName,
        NumberOfColumns,
        SequencePageSeparator,
        EntryPageSeparator,
        EntryTypeFilter,
        PageRangeSeparator,
        IndexHeadingText,
        CrossReferenceSeparator,
        PageNumberSeparator,
        LetterRange,
        UseRunInFormat,
        SequenceName,
        EnableYomiText,
        LanguageId,
    }

    /// <summary>
    /// Represents a strongly-typed INDEX field instruction.
    /// Builds an index using the index entries specified by XE fields, and inserts that index at this place in the document.
    /// Each index entry and subentry is a separate paragraph unless the \r switch is used.
    /// </summary>
    public class IndexFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// Switch: \b field-argument
        /// Builds an index for the portion of the document marked by the bookmark indicated by this field argument.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Builds an index having the number of columns per page specified by this field argument.
        /// That number can be 1–4. Without this switch, the number of columns is 1.
        /// </summary>
        public FlaggedArgument<NumericLiteralNode<int>>? NumberOfColumns { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Specifies a sequence of characters that is used to separate sequence numbers and page numbers when the \s switch is used.
        /// By default, a hyphen (-) is used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SequencePageSeparator { get; set; }

        /// <summary>
        /// Switch: \e field-argument
        /// Specifies a sequence of characters that is used to separate an index entry and its first page number.
        /// By default, a comma (,) and space sequence is used. If text contains a horizontal tab character,
        /// the page number list is right justified in the column.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? EntryPageSeparator { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Builds an index using only those entries having the entry type (XE) specified by this field argument.
        /// Without this switch, all entries are included.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? EntryTypeFilter { get; set; }

        /// <summary>
        /// Switch: \g field-argument
        /// Specifies a sequence of characters that is used to separate the start and end of a page range.
        /// By default, an en dash is used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? PageRangeSeparator { get; set; }

        /// <summary>
        /// Switch: \h field-argument
        /// Builds an index such that this field argument occurs as a heading—formatted with the Index Heading style—at the start of each set of entries for any given letter.
        /// If the first letter in text is A or a, that letter is replaced with the corresponding letter for each letter set.
        /// To replace the default heading with a blank line, use a space as text.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? IndexHeadingText { get; set; }

        /// <summary>
        /// Switch: \k field-argument
        /// Specifies a sequence of characters that is used to separate an index entry and its cross reference.
        /// Used for cross references produced by XE entries having a \t switch. By default, a period (.) and space sequence is used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? CrossReferenceSeparator { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Specifies a sequence of characters that is used to separate two page numbers in a page number list.
        /// By default, a comma (,) and space sequence is used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? PageNumberSeparator { get; set; }

        /// <summary>
        /// Switch: \p field-argument
        /// Builds an index using only those entries whose first letter falls within the range specified by this field argument.
        /// Format is "startLetter-endLetter". If startLetter is "!", entries whose first character is not a letter are included,
        /// along with letters starting from A. The letters in the range can be either upper- or lowercase.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? LetterRange { get; set; }

        /// <summary>
        /// Switch: \r
        /// Runs subentries into the same line as the main entry. Colons (:) separate main entries from subentries;
        /// semicolons (;) separate subentries.
        /// </summary>
        public BoolFlagNode? UseRunInFormat { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Includes with each page number the sequence number of the sequence name specified by this field argument.
        /// The sequence number is included along with the page number, separated by a hyphen (-) by default,
        /// or by the character specified in \d switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SequenceName { get; set; }

        /// <summary>
        /// Switch: \y
        /// Enables the use of yomi text for index entries. Yomi text is used for phonetic sorting in East Asian languages.
        /// </summary>
        public BoolFlagNode? EnableYomiText { get; set; }

        /// <summary>
        /// Switch: \z field-argument
        /// Uses the language ID specified by this field argument to generate the index.
        /// This affects sorting and formatting of the index.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? LanguageId { get; set; }

        public List<IndexArgument> Order { get; set; } = new List<IndexArgument>();

        public IndexFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? bookmarkName,
            FlaggedArgument<NumericLiteralNode<int>>? numberOfColumns,
            FlaggedArgument<ExpressionNode>? sequencePageSeparator,
            FlaggedArgument<ExpressionNode>? entryPageSeparator,
            FlaggedArgument<ExpressionNode>? entryTypeFilter,
            FlaggedArgument<ExpressionNode>? pageRangeSeparator,
            FlaggedArgument<ExpressionNode>? indexHeadingText,
            FlaggedArgument<ExpressionNode>? crossReferenceSeparator,
            FlaggedArgument<ExpressionNode>? pageNumberSeparator,
            FlaggedArgument<ExpressionNode>? letterRange,
            BoolFlagNode? useRunInFormat,
            FlaggedArgument<ExpressionNode>? sequenceName,
            BoolFlagNode? enableYomiText,
            FlaggedArgument<ExpressionNode>? languageId,
            List<IndexArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            BookmarkName = bookmarkName;
            NumberOfColumns = numberOfColumns;
            SequencePageSeparator = sequencePageSeparator;
            EntryPageSeparator = entryPageSeparator;
            EntryTypeFilter = entryTypeFilter;
            PageRangeSeparator = pageRangeSeparator;
            IndexHeadingText = indexHeadingText;
            CrossReferenceSeparator = crossReferenceSeparator;
            PageNumberSeparator = pageNumberSeparator;
            LetterRange = letterRange;
            UseRunInFormat = useRunInFormat;
            SequenceName = sequenceName;
            EnableYomiText = enableYomiText;
            LanguageId = languageId;
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
                        IndexArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        IndexArgument.NumberOfColumns => NumberOfColumns?.ToString()
                            ?? string.Empty,
                        IndexArgument.SequencePageSeparator => SequencePageSeparator?.ToString()
                            ?? string.Empty,
                        IndexArgument.EntryPageSeparator => EntryPageSeparator?.ToString()
                            ?? string.Empty,
                        IndexArgument.EntryTypeFilter => EntryTypeFilter?.ToString()
                            ?? string.Empty,
                        IndexArgument.PageRangeSeparator => PageRangeSeparator?.ToString()
                            ?? string.Empty,
                        IndexArgument.IndexHeadingText => IndexHeadingText?.ToString()
                            ?? string.Empty,
                        IndexArgument.CrossReferenceSeparator => CrossReferenceSeparator?.ToString()
                            ?? string.Empty,
                        IndexArgument.PageNumberSeparator => PageNumberSeparator?.ToString()
                            ?? string.Empty,
                        IndexArgument.LetterRange => LetterRange?.ToString() ?? string.Empty,
                        IndexArgument.UseRunInFormat => UseRunInFormat?.ToString() ?? string.Empty,
                        IndexArgument.SequenceName => SequenceName?.ToString() ?? string.Empty,
                        IndexArgument.EnableYomiText => EnableYomiText?.ToString() ?? string.Empty,
                        IndexArgument.LanguageId => LanguageId?.ToString() ?? string.Empty,
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

            foreach (IndexArgument arg in Order)
            {
                Node? child = arg switch
                {
                    IndexArgument.BookmarkName => BookmarkName,
                    IndexArgument.NumberOfColumns => NumberOfColumns,
                    IndexArgument.SequencePageSeparator => SequencePageSeparator,
                    IndexArgument.EntryPageSeparator => EntryPageSeparator,
                    IndexArgument.EntryTypeFilter => EntryTypeFilter,
                    IndexArgument.PageRangeSeparator => PageRangeSeparator,
                    IndexArgument.IndexHeadingText => IndexHeadingText,
                    IndexArgument.CrossReferenceSeparator => CrossReferenceSeparator,
                    IndexArgument.PageNumberSeparator => PageNumberSeparator,
                    IndexArgument.LetterRange => LetterRange,
                    IndexArgument.UseRunInFormat => UseRunInFormat,
                    IndexArgument.SequenceName => SequenceName,
                    IndexArgument.EnableYomiText => EnableYomiText,
                    IndexArgument.LanguageId => LanguageId,
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
            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    IndexArgument arg = Order[index];
                    switch (arg)
                    {
                        case IndexArgument.BookmarkName:
                            if (replacement is FlaggedArgument<ExpressionNode> fam)
                            {
                                current = BookmarkName;
                                BookmarkName = fam;
                            }
                            break;
                        case IndexArgument.NumberOfColumns:
                            if (replacement is FlaggedArgument<NumericLiteralNode<int>> fan)
                            {
                                current = NumberOfColumns;
                                NumberOfColumns = fan;
                            }
                            break;
                        case IndexArgument.SequencePageSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> fas)
                            {
                                current = SequencePageSeparator;
                                SequencePageSeparator = fas;
                            }
                            break;
                        case IndexArgument.EntryPageSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> eps)
                            {
                                current = EntryPageSeparator;
                                EntryPageSeparator = eps;
                            }
                            break;
                        case IndexArgument.EntryTypeFilter:
                            if (replacement is FlaggedArgument<ExpressionNode> fate)
                            {
                                current = EntryTypeFilter;
                                EntryTypeFilter = fate;
                            }
                            break;
                        case IndexArgument.PageRangeSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> prs)
                            {
                                current = PageRangeSeparator;
                                PageRangeSeparator = prs;
                            }
                            break;
                        case IndexArgument.IndexHeadingText:
                            if (replacement is FlaggedArgument<ExpressionNode> fiht)
                            {
                                current = IndexHeadingText;
                                IndexHeadingText = fiht;
                            }
                            break;
                        case IndexArgument.CrossReferenceSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> facrs)
                            {
                                current = CrossReferenceSeparator;
                                CrossReferenceSeparator = facrs;
                            }
                            break;
                        case IndexArgument.PageNumberSeparator:
                            if (replacement is FlaggedArgument<ExpressionNode> fapns)
                            {
                                current = PageNumberSeparator;
                                PageNumberSeparator = fapns;
                            }
                            break;
                        case IndexArgument.LetterRange:
                            if (replacement is FlaggedArgument<ExpressionNode> falr)
                            {
                                current = LetterRange;
                                LetterRange = falr;
                            }
                            break;
                        case IndexArgument.UseRunInFormat:
                            if (replacement is BoolFlagNode brif)
                            {
                                current = UseRunInFormat;
                                UseRunInFormat = brif;
                            }
                            break;
                        case IndexArgument.SequenceName:
                            if (replacement is FlaggedArgument<ExpressionNode> fasn)
                            {
                                current = SequenceName;
                                SequenceName = fasn;
                            }
                            break;
                        case IndexArgument.EnableYomiText:
                            if (replacement is BoolFlagNode beyt)
                            {
                                current = EnableYomiText;
                                EnableYomiText = beyt;
                            }
                            break;
                        case IndexArgument.LanguageId:
                            if (replacement is FlaggedArgument<ExpressionNode> falid)
                            {
                                current = LanguageId;
                                LanguageId = falid;
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
