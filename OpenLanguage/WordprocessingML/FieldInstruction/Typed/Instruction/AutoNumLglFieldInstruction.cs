using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed AUTONUMLGL field instruction.
    /// For legal and technical publications, use the nine built-in heading styles to format headings in the document, and then insert an `AUTONUMLGL` field at the beginning of each heading paragraph. The numbers reflect the heading levels that correspond to the heading styles. If an `AUTONUMLGL` field is inserted in paragraphs of body text paragraphs not formatted with built-in heading styles, the number of the preceding heading is included in the paragraph number. ##### Note This field is supported for legacy reasons, It is recommended that `LISTNUM` (§ [LISTNUM](LISTNUM.md)) be used instead. This field only makes sense in terms of multi-level headings. Given the following headings: Heading 1Heading 2Heading 2Heading 1 This field allows 1\. Heading 11.1. Heading 21.2. Heading 22. Heading 1 At each level, the numbering sequence does two things—it increments specific to that level, and it includes the value from the previous level. The XML generated for a complex field implementation shall not have the optional field value stored.
    /// </summary>
    public class AutoNumLglFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \e
        /// Removes the trailing separator (default period).
        /// </summary>
        public bool RemoveTrailingSeparator { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Specifies the separator character to use (default is period).
        /// </summary>
        public char? SeparatorCharacter { get; set; }

        /// <summary>
        /// Initializes a new instance of the AutoNumLglFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public AutoNumLglFieldInstruction(FieldInstruction source)
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
            if (Source.Instruction.ToUpperInvariant() != "AUTONUMLGL")
            {
                throw new ArgumentException(
                    $"Expected AUTONUMLGL field, but got {Source.Instruction}"
                );
            }

            // AUTONUMLGL field has no field arguments, only switches
            if (
                Source.Arguments.Any(arg =>
                    arg.Type == FieldArgumentType.Identifier
                    || arg.Type == FieldArgumentType.StringLiteral
                )
            )
            {
                throw new ArgumentException(
                    "AUTONUMLGL field does not accept field arguments, only switches"
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
                        case "\\e":
                            RemoveTrailingSeparator = true;
                            break;
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
            List<string> result = new List<string> { "AUTONUMLGL" };

            if (RemoveTrailingSeparator)
            {
                result.Add("\\e");
            }

            if (SeparatorCharacter.HasValue)
            {
                result.Add("\\s");
                result.Add(SeparatorCharacter.Value.ToString());
            }

            return string.Join(" ", result);
        }
    }
}
