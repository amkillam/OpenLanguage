using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed RD field instruction.
    /// field-argument identifies a file to include when creating a table of contents, a table of authorities, or an index using a `TOC` ([TOC](TOC.md)), `TOA` ([TOA](TOA.md)), or `INDEX` field ([INDEX](INDEX.md)). `RD` fields that reference a series of files must be in the same order as the files in the final document. If the location includes a long file name containing spaces, field-argument shall contain delimiting quotes. A single backslash in the file path shall be preceded directly by a backslash. For a complex field implementation in XML the optional field-value storage is not needed.
    /// </summary>
    public class RdFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The path to the referenced document file.
        /// </summary>
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \p
        /// Indicates that the path is relative to the current document.
        /// </summary>
        public bool IsRelativePath { get; set; }

        /// <summary>
        /// Initializes a new instance of the RdFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public RdFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "RD")
            {
                throw new ArgumentException($"Expected RD field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument) - required file path
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            FilePath = firstNonSwitch?.Value?.ToString() ?? string.Empty;

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
                            IsRelativePath = true;
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

            if (!string.IsNullOrEmpty(FilePath))
            {
                result.Add(FilePath.Contains(" ") ? $"\"{FilePath}\"" : FilePath);
            }

            if (IsRelativePath)
            {
                result.Add("\\p");
            }

            return string.Join(" ", result);
        }
    }
}
