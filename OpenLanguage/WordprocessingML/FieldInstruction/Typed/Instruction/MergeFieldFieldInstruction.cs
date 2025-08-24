using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed MERGEFIELD field instruction.
    /// Retrieves the name of a data field designated by text in field-argument within the merge characters in a mail merge main document.
    /// When the main document is merged with the selected data source, information from the specified data field is inserted in place of the merge field.
    /// The name designated by text shall match exactly the field name in the header record.
    ///
    /// Syntax: MERGEFIELD field-argument [ switch ]
    ///
    /// Field Value: The name of a data field designated by text in field-argument.
    ///
    /// Switches:
    /// - \b field-argument: The text in this switch's field-argument specifies the text to be inserted before the MERGEFIELD field if the field is not blank
    /// - \f field-argument: The text in this switch's field-argument specifies the text to be inserted after the MERGEFIELD field if the field is not blank
    /// - \m: Specifies that the MERGEFIELD field is a mapped field
    /// - \v: Enables character conversion for vertical formatting
    /// </summary>
    public class MergeFieldFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The name of the merge field
        /// </summary>
        public string? FieldName { get; set; }

        /// <summary>
        /// Switch: \b field-argument
        /// The text in this switch's field-argument specifies the text to be inserted before the MERGEFIELD field if the field is not blank.
        /// </summary>
        public string? TextBefore { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// The text in this switch's field-argument specifies the text to be inserted after the MERGEFIELD field if the field is not blank.
        /// </summary>
        public string? TextAfter { get; set; }

        /// <summary>
        /// Switch: \m
        /// Specifies that the MERGEFIELD field is a mapped field.
        /// </summary>
        public bool IsMapped { get; set; }

        /// <summary>
        /// Switch: \v
        /// Enables character conversion for vertical formatting.
        /// </summary>
        public bool VerticalFormatting { get; set; }

        /// <summary>
        /// Initializes a new instance of the MergeFieldFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public MergeFieldFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "MERGEFIELD")
            {
                throw new ArgumentException(
                    $"Expected MERGEFIELD field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                FieldName = firstNonSwitch.Value?.ToString();
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
                                    TextBefore = nextArg.Value?.ToString();
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
                                    TextAfter = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\m":
                            IsMapped = true;
                            break;
                        case "\\v":
                            VerticalFormatting = true;
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

            if (FieldName != null)
            {
                string argString = FieldName.ToString();
                result.Add(argString.Contains(" ") ? $"\"{FieldName}\"" : argString);
            }

            if (TextBefore != null)
            {
                result.Add("\\b");
                result.Add(
                    TextBefore.ToString().Contains(" ")
                        ? $"\"{TextBefore}\""
                        : TextBefore.ToString()
                );
            }

            if (TextAfter != null)
            {
                result.Add("\\f");
                result.Add(
                    TextAfter.ToString().Contains(" ") ? $"\"{TextAfter}\"" : TextAfter.ToString()
                );
            }

            if (IsMapped)
            {
                result.Add("\\m");
            }

            if (VerticalFormatting)
            {
                result.Add("\\v");
            }

            return string.Join(" ", result);
        }
    }
}
