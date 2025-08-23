using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed FILLIN field instruction.
    /// Prompts the user to enter text. text in field-argument contains the prompt. The prompt is displayed each time the field is updated. When a new document is created based on a template containing `FILLIN` fields, those fields are updated automatically.
    /// </summary>
    public class FillInFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The prompt text to display to the user
        /// </summary>
        public string? PromptText { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Default text
        /// </summary>
        public string? DefaultText { get; set; }

        /// <summary>
        /// Switch: \o
        /// Prompt only once per mail merge
        /// </summary>
        public bool PromptOnce { get; set; }

        /// <summary>
        /// Initializes a new instance of the FillInFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public FillInFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "FILLIN")
            {
                throw new ArgumentException($"Expected FILLIN field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                PromptText = firstNonSwitch.Value?.ToString();
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
                        case "\\d":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    DefaultText = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\o":
                            PromptOnce = true;
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

            if (PromptText != null)
            {
                string argString = PromptText.ToString();
                result.Add(argString.Contains(" ") ? $"\"{PromptText}\"" : argString);
            }

            if (DefaultText != null)
            {
                result.Add("\\d");
                result.Add(
                    DefaultText.ToString().Contains(" ")
                        ? $"\"{DefaultText}\""
                        : DefaultText.ToString()
                );
            }

            if (PromptOnce)
            {
                result.Add("\\o");
            }

            return string.Join(" ", result);
        }
    }
}
