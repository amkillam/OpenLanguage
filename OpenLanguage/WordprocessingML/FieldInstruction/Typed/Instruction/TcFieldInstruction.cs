using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed TC field instruction.
    /// Defines the text and page number for a table of contents (including a table of figures) entry, which is used by a `TOC` field. The text of the entry is text in field-argument.
    /// </summary>
    public class TcFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The text for the table of contents entry
        /// </summary>
        public string? EntryText { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Table identifier
        /// </summary>
        public string? TableId { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// The level of the TC entry. If no level is specified, level 1 is assumed.
        /// </summary>
        public string? Level { get; set; }

        /// <summary>
        /// Switch: \n
        /// Omits the page number for the entry.
        /// </summary>
        public bool OmitPageNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the TcFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public TcFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "TC")
            {
                throw new ArgumentException($"Expected TC field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                EntryText = firstNonSwitch.Value?.ToString();
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
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    TableId = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\l":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    Level = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\n":
                            OmitPageNumber = true;
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
            List<string> result = new List<string> { "TC" };

            if (EntryText != null)
            {
                result.Add(
                    EntryText.Contains(" ") && !EntryText.StartsWith("\"")
                        ? $"\"{EntryText}\""
                        : EntryText
                );
            }

            if (TableId != null)
            {
                result.Add("\\f");
                result.Add(
                    TableId.Contains(" ") && !(TableId.StartsWith("\""))
                        ? $"\"{TableId}\""
                        : TableId
                );
            }

            if (Level != null)
            {
                result.Add("\\l");
                result.Add(
                    Level.Contains(" ") && !(Level.StartsWith("\"")) ? $"\"{Level}\"" : Level
                );
            }

            if (OmitPageNumber)
            {
                result.Add("\\n");
            }

            return string.Join(" ", result);
        }
    }
}
