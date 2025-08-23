using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed PAGEREF field instruction.
    /// Inserts the number of the page containing the bookmark specified by text in field-argument for a cross-reference.
    /// </summary>
    public class PageRefFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The bookmark name for the page reference.
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \h
        /// Creates a hyperlink to the bookmarked paragraph.
        /// </summary>
        public bool Hyperlink { get; set; }

        /// <summary>
        /// Switch: \p
        /// Causes the field to display its position relative to the source bookmark.
        /// If the PAGEREF field is on the same page as the bookmark, it omits "on page #" and returns "above" or "below" only.
        /// If the PAGEREF field is not on the same page as the bookmark, the string "on page #" is used.
        /// </summary>
        public bool RelativePosition { get; set; }

        /// <summary>
        /// Initializes a new instance of the PageRefFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public PageRefFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "PAGEREF")
            {
                throw new ArgumentException(
                    $"Expected PAGEREF field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                BookmarkName = firstNonSwitch.Value?.ToString();
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
                        case "\\h":
                            Hyperlink = true;
                            break;
                        case "\\p":
                            RelativePosition = true;
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
            List<string> result = new List<string> { Source.Instruction };

            if (BookmarkName != null)
            {
                string argString = BookmarkName.ToString();
                result.Add(argString.Contains(" ") ? $"\"{BookmarkName}\"" : argString);
            }

            if (Hyperlink)
            {
                result.Add("\\h");
            }

            if (RelativePosition)
            {
                result.Add("\\p");
            }

            return string.Join(" ", result);
        }
    }
}
