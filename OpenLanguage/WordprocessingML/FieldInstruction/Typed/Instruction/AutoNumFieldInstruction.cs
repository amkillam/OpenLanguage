using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed AUTONUM field instruction.
    /// In paragraphs formatted with one of the nine built-in heading styles, paragraph numbering restarts at 1 in each successive heading level. If headings that contain `AUTONUM` fields are followed by body text paragraphs that also contain `AUTONUM` fields, the paragraph numbering of the body text is restarted at 1 after each heading. If the headings don't contain `AUTONUM` fields, body text paragraphs that contain `AUTONUM` fields are numbered in a continuous, sequential series throughout the document. ##### Note This field is supported for legacy reasons, It is recommended that `LISTNUM` (§ [LISTNUM](LISTNUM.md)) be used instead. The XML generated for a complex field implementation shall not have the optional field value stored.
    /// </summary>
    public class AutoNumFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \s field-argument
        /// Specifies the separator character to use (default is period).
        /// </summary>
        public char? SeparatorCharacter { get; set; }

        /// <summary>
        /// Initializes a new instance of the AutoNumFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public AutoNumFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Gets the next argument after the specified switch index.
        /// </summary>
        private string GetNextArgumentAfter(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString() ?? "";
                }
            }
            return "";
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "AUTONUM")
            {
                throw new ArgumentException(
                    $"Expected AUTONUM field, but got {Source.Instruction}"
                );
            }

            // AUTONUM field has no field arguments, only switches
            if (
                Source.Arguments.Any(arg =>
                    arg.Type == FieldArgumentType.Identifier
                    || arg.Type == FieldArgumentType.StringLiteral
                )
            )
            {
                throw new ArgumentException(
                    "AUTONUM field does not accept field arguments, only switches"
                );
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
                        case "\\s":
                            string separatorText = GetNextArgumentAfter(i);
                            if (!string.IsNullOrEmpty(separatorText))
                            {
                                SeparatorCharacter = separatorText[0];
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
            List<string> result = new List<string> { "AUTONUM" };

            if (SeparatorCharacter.HasValue)
            {
                result.Add("\\s");
                result.Add(SeparatorCharacter.Value.ToString());
            }

            return string.Join(" ", result);
        }
    }
}
