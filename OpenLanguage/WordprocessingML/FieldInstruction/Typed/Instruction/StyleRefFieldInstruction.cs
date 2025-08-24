using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed STYLEREF field instruction.
    /// Inserts the nearest piece of text prior to this field that is formatted by the style whose name is specified by text in field-argument.
    /// The style can be a paragraph style or a character style.
    /// </summary>
    public class StyleRefFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The name of the style to reference.
        /// </summary>
        public string? StyleName { get; set; }

        /// <summary>
        /// Switch: \l
        /// Inserts the nearest text following the field.
        /// </summary>
        public bool InsertNearestTextFollowing { get; set; }

        /// <summary>
        /// Switch: \n
        /// Inserts the paragraph number of the referenced paragraph exactly as it appears in the document.
        /// </summary>
        public bool InsertParagraphNumber { get; set; }

        /// <summary>
        /// Switch: \p
        /// Inserts the relative position of the referenced paragraph as being "above" or "below".
        /// </summary>
        public bool InsertRelativePosition { get; set; }

        /// <summary>
        /// Switch: \r
        /// Inserts the paragraph number of the referenced paragraph exactly in relative context.
        /// </summary>
        public bool InsertParagraphNumberRelative { get; set; }

        /// <summary>
        /// Switch: \t
        /// When used with the \n, \r, or \w switch, causes non-delimiter and non-numerical text to be suppressed.
        /// </summary>
        public bool SuppressNonDelimiter { get; set; }

        /// <summary>
        /// Switch: \w
        /// Inserts the paragraph number of the referenced paragraph in full context, from anywhere in the document.
        /// </summary>
        public bool InsertParagraphNumberFull { get; set; }

        /// <summary>
        /// Initializes a new instance of the StyleRefFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public StyleRefFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "STYLEREF")
            {
                throw new ArgumentException(
                    $"Expected STYLEREF field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                StyleName = firstNonSwitch.Value?.ToString();
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
                        case "\\l":
                            InsertNearestTextFollowing = true;
                            break;
                        case "\\n":
                            InsertParagraphNumber = true;
                            break;
                        case "\\p":
                            InsertRelativePosition = true;
                            break;
                        case "\\r":
                            InsertParagraphNumberRelative = true;
                            break;
                        case "\\t":
                            SuppressNonDelimiter = true;
                            break;
                        case "\\w":
                            InsertParagraphNumberFull = true;
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

            if (StyleName != null)
            {
                string argString = StyleName.ToString();
                result.Add(argString.Contains(" ") ? $"\"{StyleName}\"" : argString);
            }

            if (InsertNearestTextFollowing)
            {
                result.Add("\\l");
            }

            if (InsertParagraphNumber)
            {
                result.Add("\\n");
            }

            if (InsertRelativePosition)
            {
                result.Add("\\p");
            }

            if (InsertParagraphNumberRelative)
            {
                result.Add("\\r");
            }

            if (SuppressNonDelimiter)
            {
                result.Add("\\t");
            }

            if (InsertParagraphNumberFull)
            {
                result.Add("\\w");
            }

            return string.Join(" ", result);
        }
    }
}
