using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed XE field instruction.
    /// Defines the text and page number for an index entry, which is used by an INDEX field.
    /// The text of the entry is specified in the field argument. To indicate a subentry, the main entry text
    /// and the subentry text shall be separated by a colon (:). Subentries beyond one level are permitted.
    /// </summary>
    public class XeFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The text for the index entry (field-argument). Required.
        /// To indicate a subentry, separate main entry and subentry text with a colon (:).
        /// </summary>
        public string EntryText { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \b
        /// Applies bold formatting to the entry's page number. However, if the index style for that entry
        /// is already bold, this switch removes that formatting for that entry.
        /// </summary>
        public bool ApplyBoldFormatting { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Defines an index entry type. If an INDEX field has the same \f switch and field-argument,
        /// this entry is included in the resulting index; otherwise, it is excluded.
        /// </summary>
        public string? EntryType { get; set; }

        /// <summary>
        /// Switch: \i
        /// Applies italic formatting to the entry's page number. However, if the index style for that entry
        /// is already italic, this switch removes that formatting for that entry.
        /// </summary>
        public bool ApplyItalicFormatting { get; set; }

        /// <summary>
        /// Switch: \r field-argument
        /// Instead of the entry's page number, uses the range of pages marked by the bookmark
        /// specified by this field argument.
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Uses text from this field argument in place of a page number.
        /// Useful for "See …" or "See also …" entries.
        /// </summary>
        public string? CrossReferenceText { get; set; }

        /// <summary>
        /// Switch: \y field-argument
        /// Specifies that the text from this field argument defines the yomi (first phonetic character for sorting indexes) for the index entry.
        /// </summary>
        public string? YomiText { get; set; }

        /// <summary>
        /// Initializes a new instance of the XeFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public XeFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "XE")
            {
                throw new ArgumentException($"Expected XE field, but got {Source.Instruction}");
            }

            // Parse the required field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );

            if (firstNonSwitch == null)
            {
                throw new ArgumentException(
                    "XE field requires a field-argument for the entry text"
                );
            }

            EntryText = firstNonSwitch.Value?.ToString() ?? string.Empty;

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    ParseSwitch(switchValue, i);
                }
            }
        }

        /// <summary>
        /// Parses individual switches and their arguments.
        /// </summary>
        /// <param name="switchValue">The switch value to parse.</param>
        /// <param name="switchIndex">The index of the switch in the arguments list.</param>
        private void ParseSwitch(string switchValue, int switchIndex)
        {
            switch (switchValue.ToLowerInvariant())
            {
                case "\\b":
                    ApplyBoldFormatting = true;
                    break;
                case "\\f":
                    EntryType = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\i":
                    ApplyItalicFormatting = true;
                    break;
                case "\\r":
                    BookmarkName = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\t":
                    CrossReferenceText = GetArgumentAfterSwitch(switchIndex);
                    break;
                case "\\y":
                    YomiText = GetArgumentAfterSwitch(switchIndex);
                    break;
                default:
                    // Unknown switch - could be a general formatting switch handled by base class
                    break;
            }
        }

        /// <summary>
        /// Gets the argument following the specified switch index.
        /// </summary>
        /// <param name="switchIndex">The index of the switch.</param>
        /// <returns>The argument following the switch, or null if none exists.</returns>
        private string? GetArgumentAfterSwitch(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString();
                }
            }
            return null;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "XE" };

            // Add the required field argument
            if (!string.IsNullOrEmpty(EntryText))
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

            if (!string.IsNullOrEmpty(EntryType))
            {
                result.Add("\\f");
                result.Add(
                    EntryType.Contains(" ") && !EntryType.StartsWith("\"")
                        ? $"\"{EntryType}\""
                        : EntryType
                );
            }

            if (ApplyItalicFormatting)
            {
                result.Add("\\i");
            }

            if (!string.IsNullOrEmpty(BookmarkName))
            {
                result.Add("\\r");
                result.Add(
                    BookmarkName.Contains(" ") && BookmarkName.StartsWith("\"")
                        ? $"\"{BookmarkName}\""
                        : BookmarkName
                );
            }

            if (!string.IsNullOrEmpty(CrossReferenceText))
            {
                result.Add("\\t");
                result.Add(
                    CrossReferenceText.Contains(" ") && !CrossReferenceText.StartsWith("\"")
                        ? $"\"{CrossReferenceText}\""
                        : CrossReferenceText
                );
            }

            if (!string.IsNullOrEmpty(YomiText))
            {
                result.Add("\\y");
                result.Add(
                    YomiText.Contains(" ") && !(YomiText.StartsWith("\""))
                        ? $"\"{YomiText}\""
                        : YomiText
                );
            }

            return string.Join(" ", result);
        }
    }
}
