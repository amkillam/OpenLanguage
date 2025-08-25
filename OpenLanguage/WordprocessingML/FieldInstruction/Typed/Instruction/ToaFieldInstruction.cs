using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed TOA field instruction.
    /// Builds a table of authorities (that is, a list of the references in a legal document, such as references to cases, statutes, and rules, along with the numbers of the pages on which the references appear) using the entries specified by TA fields.
    /// </summary>
    public class ToaFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The category for the table of authorities
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Switch: \b field-argument
        /// Bookmark name
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Includes the entries whose integral category is that specified by text in this switch's field-argument.
        /// </summary>
        public string? CategoryNumber { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Used in conjunction with \s to specify the character sequence that separates the sequence numbers and page numbers. If \d is omitted, a hyphen (-) is used.
        /// </summary>
        public string? SequencePageSeparator { get; set; }

        /// <summary>
        /// Switch: \e field-argument
        /// Text in this switch's field-argument specifies the character sequence that separates a table of authorities entry and its page number. If \e is not specified, a tab stop with leader dots is used.
        /// </summary>
        public string? EntryPageSeparator { get; set; }

        /// <summary>
        /// Switch: \g field-argument
        /// Text in this switch's field-argument specifies the character sequence that separates the pages in a page range. If \g is omitted, an en dash (–) is used.
        /// </summary>
        public string? PageRangeSeparator { get; set; }

        /// <summary>
        /// Switch: \f
        /// Remove formatting from entries
        /// </summary>
        public bool RemoveFormatting { get; set; }

        /// <summary>
        /// Switch: \h
        /// Includes the category heading for the entries in a table of authorities.
        /// </summary>
        public bool IncludeCategoryHeading { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Text in this switch's field-argument specifies the character sequence that separates multiple page references. If \l is omitted, a comma (,) and space are used.
        /// </summary>
        public string? MultiplePageSeparator { get; set; }

        /// <summary>
        /// Switch: \p
        /// Replaces five or more different page references to the same authority with "passim", which is used to indicate that a word or passage occurs frequently in the work cited.
        /// </summary>
        public bool UsePassim { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Includes a case or section number before the page number. The entry shall be numbered with a SEQ field, and text in this switch's field-argument shall match the identifier in the SEQ field.
        /// </summary>
        public string? SequenceIdentifier { get; set; }

        /// <summary>
        /// Initializes a new instance of the ToaFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public ToaFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "TOA")
            {
                throw new ArgumentException($"Expected TOA field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                Category = firstNonSwitch.Value?.ToString();
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
                                    CategoryNumber = nextArg.Value?.ToString();
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
                                    SequencePageSeparator = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\e":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    EntryPageSeparator = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\f":
                            RemoveFormatting = true;
                            break;
                        case "\\g":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    PageRangeSeparator = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\h":
                            IncludeCategoryHeading = true;
                            break;
                        case "\\l":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    MultiplePageSeparator = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\p":
                            UsePassim = true;
                            break;
                        case "\\s":
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
            List<string> result = new List<string> { "TOA" };

            if (Category != null)
            {
                result.Add(Category.Contains(" ") ? $"\"{Category}\"" : Category);
            }

            if (BookmarkName != null)
            {
                result.Add("\\b");
                result.Add(BookmarkName.Contains(" ") ? $"\"{BookmarkName}\"" : BookmarkName);
            }

            if (CategoryNumber != null)
            {
                result.Add("\\c");
                result.Add(CategoryNumber.Contains(" ") ? $"\"{CategoryNumber}\"" : CategoryNumber);
            }

            if (SequencePageSeparator != null)
            {
                result.Add("\\d");
                result.Add(
                    SequencePageSeparator.Contains(" ")
                        ? $"\"{SequencePageSeparator}\""
                        : SequencePageSeparator
                );
            }

            if (EntryPageSeparator != null)
            {
                result.Add("\\e");
                result.Add(
                    EntryPageSeparator.Contains(" ")
                        ? $"\"{EntryPageSeparator}\""
                        : EntryPageSeparator
                );
            }

            if (RemoveFormatting)
            {
                result.Add("\\f");
            }

            if (PageRangeSeparator != null)
            {
                result.Add("\\g");
                result.Add(
                    PageRangeSeparator.Contains(" ")
                        ? $"\"{PageRangeSeparator}\""
                        : PageRangeSeparator
                );
            }

            if (IncludeCategoryHeading)
            {
                result.Add("\\h");
            }

            if (MultiplePageSeparator != null)
            {
                result.Add("\\l");
                result.Add(
                    MultiplePageSeparator.Contains(" ")
                        ? $"\"{MultiplePageSeparator}\""
                        : MultiplePageSeparator
                );
            }

            if (UsePassim)
            {
                result.Add("\\p");
            }

            if (SequenceIdentifier != null)
            {
                result.Add("\\s");
                result.Add(
                    SequenceIdentifier.Contains(" ")
                        ? $"\"{SequenceIdentifier}\""
                        : SequenceIdentifier
                );
            }

            return string.Join(" ", result);
        }
    }
}
