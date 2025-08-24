using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed TA field instruction.
    /// Defines the text and page number for a table of authorities entry, which is used by a `TOA` field ([TOA](TOA.md)).
    /// </summary>
    public class TaFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The text for the table of authorities entry
        /// </summary>
        public string? EntryText { get; set; }

        /// <summary>
        /// Switch: \b
        /// Applies bold formatting to the page number for the entry. If the table of authorities style for the entry already has bold formatting, \b removes it.
        /// </summary>
        public bool ApplyBoldFormatting { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Text in this switch's field-argument specifies the integral entry category, which is a number that corresponds to the order of categories. The number determines how citations are grouped in tables of authorities. If \c is omitted, category 1 is the default.
        /// </summary>
        public string? CategoryNumber { get; set; }

        /// <summary>
        /// Switch: \i
        /// Applies italic formatting to the page number for the entry. If the table of authorities' style for the entry already has italic formatting, \i removes it.
        /// </summary>
        public bool ApplyItalicFormatting { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Text in this switch's field-argument defines the long citation for the entry.
        /// </summary>
        public string? LongCitation { get; set; }

        /// <summary>
        /// Switch: \r field-argument
        /// Inserts as the entry's page number the range of pages marked by the bookmark specified by text in this switch's field-argument.
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Text in this switch's field-argument defines the short citation for the entry.
        /// </summary>
        public string? ShortCitation { get; set; }

        /// <summary>
        /// Initializes a new instance of the TaFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public TaFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "TA")
            {
                throw new ArgumentException($"Expected TA field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                EntryText = firstNonSwitch.Value?.ToString();
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
                            ApplyBoldFormatting = true;
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
                        case "\\i":
                            ApplyItalicFormatting = true;
                            break;
                        case "\\l":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    LongCitation = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\r":
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
                        case "\\s":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    ShortCitation = nextArg.Value?.ToString();
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
            List<string> result = new List<string> { "TA" };

            if (EntryText != null)
            {
                result.Add(
                    EntryText.Contains(" ") && !EntryText.StartsWith("\"")
                        ? $"\"{EntryText}\""
                        : EntryText
                );
            }

            if (ApplyBoldFormatting)
            {
                result.Add("\\b");
            }

            if (CategoryNumber != null)
            {
                result.Add("\\c");
                result.Add(
                    CategoryNumber.Contains(" ") && !CategoryNumber.StartsWith("\"")
                        ? $"\"{CategoryNumber}\""
                        : CategoryNumber
                );
            }

            if (ApplyItalicFormatting)
            {
                result.Add("\\i");
            }

            if (LongCitation != null)
            {
                result.Add("\\l");
                result.Add(
                    LongCitation.Contains(" ") && !LongCitation.StartsWith("\"")
                        ? $"\"{LongCitation}\""
                        : LongCitation
                );
            }

            if (BookmarkName != null)
            {
                result.Add("\\r");
                result.Add(
                    BookmarkName.Contains(" ") && !BookmarkName.StartsWith("\"")
                        ? $"\"{BookmarkName}\""
                        : BookmarkName
                );
            }

            if (ShortCitation != null)
            {
                result.Add("\\s");
                result.Add(
                    ShortCitation.Contains(" ") && !ShortCitation.StartsWith("\"")
                        ? $"\"{ShortCitation}\""
                        : ShortCitation
                );
            }

            return string.Join(" ", result);
        }
    }
}
