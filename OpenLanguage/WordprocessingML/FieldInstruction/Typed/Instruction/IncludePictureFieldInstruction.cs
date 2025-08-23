using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed INCLUDEPICTURE field instruction.
    /// Retrieves the picture contained in the document named by field-argument. If field-argument contains white space, it shall be enclosed in double quotes. If field-argument contains any backslash characters, each one shall be preceded directly by another backslash character.
    /// </summary>
    public class IncludePictureFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The path to the picture file (field-argument, required).
        /// </summary>
        public string PictureFilePath { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \c field-argument
        /// Identifies the graphics filter to be used.
        /// </summary>
        public string? GraphicsFilterName { get; set; }

        /// <summary>
        /// Switch: \d
        /// Reduces the file size by not storing graphics data with the document.
        /// </summary>
        public bool ReduceFileSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the IncludePictureFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public IncludePictureFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "INCLUDEPICTURE")
            {
                throw new ArgumentException(
                    $"Expected INCLUDEPICTURE field, but got {Source.Instruction}"
                );
            }

            // INCLUDEPICTURE requires exactly 1 field argument
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            // Parse field-argument: picture file path (required)
            PictureFilePath =
                nonSwitchArgs.Count > 0
                    ? nonSwitchArgs[0].Value?.ToString() ?? string.Empty
                    : string.Empty;

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "c":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    GraphicsFilterName = nextArg.Value?.ToString();
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                        case "d":
                            ReduceFileSize = true;
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
            List<string> result = new List<string> { "INCLUDEPICTURE" };

            // Add field-argument: picture file path
            if (!string.IsNullOrEmpty(PictureFilePath))
            {
                result.Add(
                    PictureFilePath.Contains(" ") && !PictureFilePath.StartsWith("\"")
                        ? $"\"{PictureFilePath}\""
                        : PictureFilePath
                );
            }

            // Add switches
            if (!string.IsNullOrEmpty(GraphicsFilterName))
            {
                result.Add("\\c");
                result.Add(
                    GraphicsFilterName.Contains(" ") && !GraphicsFilterName.StartsWith("\"")
                        ? $"\"{GraphicsFilterName}\""
                        : GraphicsFilterName
                );
            }

            if (ReduceFileSize)
            {
                result.Add("\\d");
            }

            return string.Join(" ", result);
        }
    }
}
