using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed FILESIZE field instruction.
    /// Retrieves the size of the current document in bytes. ##### Note This information is not stored inside the document's XML. It needs to be obtained from the file system.
    /// </summary>
    public class FileSizeFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \k
        /// Display in kilobytes
        /// </summary>
        public bool InKilobytes { get; set; }

        /// <summary>
        /// Switch: \m
        /// Display in megabytes
        /// </summary>
        public bool InMegabytes { get; set; }

        /// <summary>
        /// Initializes a new instance of the FileSizeFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public FileSizeFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "FILESIZE")
            {
                throw new ArgumentException(
                    $"Expected FILESIZE field, but got {Source.Instruction}"
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
                        case "\\k":
                            InKilobytes = true;
                            break;
                        case "\\m":
                            InMegabytes = true;
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

            if (InKilobytes)
            {
                result.Add("\\k");
            }

            if (InMegabytes)
            {
                result.Add("\\m");
            }

            return string.Join(" ", result);
        }
    }
}
