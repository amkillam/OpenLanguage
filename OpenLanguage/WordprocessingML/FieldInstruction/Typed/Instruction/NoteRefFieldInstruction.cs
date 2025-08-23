using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed NOTEREF field instruction.
    /// Inserts the mark of the footnote or endnote that is marked by the bookmark specified by text in field-argument.
    /// </summary>
    public class NoteRefFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The bookmark name for the note reference.
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \f
        /// For a footnote, inserts the reference mark with the same character formatting as the Footnote Reference style.
        /// For an endnote, inserts the reference mark with the same character formatting as the Endnote Reference style.
        /// </summary>
        public bool FootnoteFormat { get; set; }

        /// <summary>
        /// Switch: \h
        /// Inserts a hyperlink to the bookmarked endnote or footnote.
        /// </summary>
        public bool Hyperlink { get; set; }

        /// <summary>
        /// Switch: \p
        /// Inserts the relative position of the footnote or endnote. If the NOTEREF field occurs before the bookmark, the result is "below". If the NOTEREF field occurs after the bookmark, the result is "above".
        /// </summary>
        public bool RelativePosition { get; set; }

        /// <summary>
        /// Initializes a new instance of the NoteRefFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public NoteRefFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "NOTEREF")
            {
                throw new ArgumentException(
                    $"Expected NOTEREF field, but got {Source.Instruction}"
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
                        case "\\f":
                            FootnoteFormat = true;
                            break;
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

            if (FootnoteFormat)
            {
                result.Add("\\f");
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
