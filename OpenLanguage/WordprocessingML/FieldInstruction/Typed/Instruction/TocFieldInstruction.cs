using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed TOC field instruction.
    /// Builds a table of contents (which can also be a table of figures) using the entries specified by TC fields,
    /// their heading levels, and specified styles, and inserts that table at this place in the document.
    /// Each table entry is a separate paragraph.
    /// </summary>
    public class TocFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \a field-argument
        /// Includes captioned items, but omits caption labels and numbers. The identifier designated by text
        /// in this switch's field-argument corresponds to the caption label. Use \c to build a table of captions
        /// with labels and numbers.
        /// </summary>
        public string? CaptionIdentifier { get; set; }

        /// <summary>
        /// Switch: \b field-argument
        /// Includes entries only from the portion of the document marked by the bookmark named by text
        /// in this switch's field-argument.
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Includes figures, tables, charts, and other items that are numbered by a SEQ field. The sequence
        /// identifier designated by text in this switch's field-argument, which corresponds to the caption label,
        /// shall match the identifier in the corresponding SEQ field.
        /// </summary>
        public string? SequenceIdentifier { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// When used with \s, the text in this switch's field-argument defines the separator between sequence
        /// and page numbers. The default separator is a hyphen (-).
        /// </summary>
        public string? SequenceSeparator { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Includes only those TC fields whose identifier exactly matches the text in this switch's field-argument
        /// (which is typically a letter).
        /// </summary>
        public string? TcFieldIdentifier { get; set; }

        /// <summary>
        /// Switch: \h
        /// Makes the table of contents entries hyperlinks.
        /// </summary>
        public bool CreateHyperlinks { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Includes TC fields that assign entries to one of the levels specified by text in this switch's
        /// field-argument as a range having the form startLevel-endLevel, where startLevel and endLevel are
        /// integers, and startLevel has a value equal-to or less-than endLevel. TC fields that assign entries
        /// to lower levels are skipped.
        /// </summary>
        public string? TcFieldLevels { get; set; }

        /// <summary>
        /// Switch: \n field-argument
        /// Without field-argument, omits page numbers from the table of contents. Page numbers are omitted
        /// from all levels unless a range of entry levels is specified by text in this switch's field-argument.
        /// A range is specified as for \l.
        /// </summary>
        public string? OmitPageNumbers { get; set; }

        /// <summary>
        /// Switch: \o field-argument
        /// Uses paragraphs formatted with all or the specified range of built-in heading styles. Headings in
        /// a style range are specified by text in this switch's field-argument using the notation specified as
        /// for \l, where each integer corresponds to the style with a style ID of HeadingX (e.g. 1 corresponds
        /// to Heading1). If no heading range is specified, all heading levels used in the document are listed.
        /// </summary>
        public string? HeadingStyleRange { get; set; }

        /// <summary>
        /// Switch: \p field-argument
        /// Text in this switch's field-argument specifies a sequence of characters that separate an entry
        /// and its page number. The default is a tab with leader dots.
        /// </summary>
        public string? PageNumberSeparator { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// For entries numbered with a SEQ field, adds a prefix to the page number. The prefix depends on
        /// the type of entry. Text in this switch's field-argument shall match the identifier in the SEQ field.
        /// </summary>
        public string? SeqFieldIdentifier { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Uses paragraphs formatted with styles other than the built-in heading styles. Text in this switch's
        /// field-argument specifies those styles as a set of comma-separated doublets, with each doublet being
        /// a comma-separated set of style name and table of content level. \t can be combined with \o.
        /// </summary>
        public string? CustomStyles { get; set; }

        /// <summary>
        /// Switch: \u
        /// Uses the applied paragraph outline level.
        /// </summary>
        public bool UseOutlineLevels { get; set; }

        /// <summary>
        /// Switch: \w
        /// Preserves tab entries within table entries.
        /// </summary>
        public bool PreserveTabEntries { get; set; }

        /// <summary>
        /// Switch: \x
        /// Preserves newline characters within table entries.
        /// </summary>
        public bool PreserveNewlines { get; set; }

        /// <summary>
        /// Switch: \z
        /// Hides tab leader and page numbers in Web layout view.
        /// </summary>
        public bool HideTabLeaderInWebView { get; set; }

        /// <summary>
        /// Initializes a new instance of the TocFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public TocFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "TOC")
            {
                throw new ArgumentException($"Expected TOC field, but got {Source.Instruction}");
            }

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\a":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    CaptionIdentifier = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\b":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    BookmarkName = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\c":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    SequenceIdentifier = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\d":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    SequenceSeparator = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\f":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    TcFieldIdentifier = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\h":
                            CreateHyperlinks = true;
                            break;
                        case "\\l":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    TcFieldLevels = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\n":
                            // Find the next argument as the switch argument (optional)
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    OmitPageNumbers = nextArg.Value?.ToString();
                                }
                                else
                                {
                                    OmitPageNumbers = ""; // No argument means omit all page numbers
                                }
                            }
                            else
                            {
                                OmitPageNumbers = ""; // No argument means omit all page numbers
                            }
                            break;
                        case "\\o":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    HeadingStyleRange = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\p":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    PageNumberSeparator = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\s":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    SeqFieldIdentifier = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\t":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    CustomStyles = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\u":
                            UseOutlineLevels = true;
                            break;
                        case "\\w":
                            PreserveTabEntries = true;
                            break;
                        case "\\x":
                            PreserveNewlines = true;
                            break;
                        case "\\z":
                            HideTabLeaderInWebView = true;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "TOC" };

            if (CaptionIdentifier != null)
            {
                result.Add("\\a");
                result.Add(
                    CaptionIdentifier.Contains(" ") && !CaptionIdentifier.StartsWith("\"")
                        ? $"\"{CaptionIdentifier}\""
                        : CaptionIdentifier
                );
            }

            if (BookmarkName != null)
            {
                result.Add("\\b");
                result.Add(
                    BookmarkName.Contains(" ") && !BookmarkName.StartsWith("\"")
                        ? $"\"{BookmarkName}\""
                        : BookmarkName
                );
            }

            if (SequenceIdentifier != null)
            {
                result.Add("\\c");
                result.Add(
                    SequenceIdentifier.Contains(" ") && !SequenceIdentifier.StartsWith("\"")
                        ? $"\"{SequenceIdentifier}\""
                        : SequenceIdentifier
                );
            }

            if (SequenceSeparator != null)
            {
                result.Add("\\d");
                result.Add(
                    SequenceSeparator.Contains(" ") && !SequenceSeparator.StartsWith("\"")
                        ? $"\"{SequenceSeparator}\""
                        : SequenceSeparator
                );
            }

            if (TcFieldIdentifier != null)
            {
                result.Add("\\f");
                result.Add(
                    TcFieldIdentifier.Contains(" ") && !TcFieldIdentifier.StartsWith("\"")
                        ? $"\"{TcFieldIdentifier}\""
                        : TcFieldIdentifier
                );
            }

            if (CreateHyperlinks)
            {
                result.Add("\\h");
            }

            if (TcFieldLevels != null)
            {
                result.Add("\\l");
                result.Add(
                    TcFieldLevels.Contains(" ") && !TcFieldLevels.StartsWith("\"")
                        ? $"\"{TcFieldLevels}\""
                        : TcFieldLevels
                );
            }

            if (OmitPageNumbers != null)
            {
                result.Add("\\n");
                if (!string.IsNullOrEmpty(OmitPageNumbers))
                {
                    result.Add(
                        OmitPageNumbers.Contains(" ") && !OmitPageNumbers.StartsWith("\"")
                            ? $"\"{OmitPageNumbers}\""
                            : OmitPageNumbers
                    );
                }
            }

            if (HeadingStyleRange != null)
            {
                result.Add("\\o");
                result.Add(
                    HeadingStyleRange.Contains(" ") && !HeadingStyleRange.StartsWith("\"")
                        ? $"\"{HeadingStyleRange}\""
                        : HeadingStyleRange
                );
            }

            if (PageNumberSeparator != null)
            {
                result.Add("\\p");
                result.Add(
                    PageNumberSeparator.Contains(" ") && !PageNumberSeparator.StartsWith("\"")
                        ? $"\"{PageNumberSeparator}\""
                        : PageNumberSeparator
                );
            }

            if (SeqFieldIdentifier != null)
            {
                result.Add("\\s");
                result.Add(
                    SeqFieldIdentifier.Contains(" ") && !SeqFieldIdentifier.StartsWith("\"")
                        ? $"\"{SeqFieldIdentifier}\""
                        : SeqFieldIdentifier
                );
            }

            if (CustomStyles != null)
            {
                result.Add("\\t");
                result.Add(
                    CustomStyles.Contains(" ") && !CustomStyles.StartsWith("\"")
                        ? $"\"{CustomStyles}\""
                        : CustomStyles
                );
            }

            if (UseOutlineLevels)
            {
                result.Add("\\u");
            }

            if (PreserveTabEntries)
            {
                result.Add("\\w");
            }

            if (PreserveNewlines)
            {
                result.Add("\\x");
            }

            if (HideTabLeaderInWebView)
            {
                result.Add("\\z");
            }

            return string.Join(" ", result);
        }
    }
}
