using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed TEMPLATE field instruction.
    /// Retrieves the disk file name of the template used by the current document.
    /// </summary>
    public class TemplateFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \p
        /// Include the full file path name.
        /// </summary>
        public bool IncludeFullPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the TemplateFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public TemplateFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "TEMPLATE")
            {
                throw new ArgumentException(
                    $"Expected TEMPLATE field, but got {Source.Instruction}"
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
                        case "\\p":
                            IncludeFullPath = true;
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

            if (IncludeFullPath)
            {
                result.Add("\\p");
            }

            return string.Join(" ", result);
        }
    }
}
