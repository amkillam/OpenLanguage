using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed LISTNUM field instruction.
    /// Computes the next integral number from the current or a specific series, or a specific number from the next or specific series. This field can be used anywhere in a paragraph, not just at its start. A `LISTNUM` field can be incorporated into numbering from a simple or outline-numbered list. text in field-argument is used to associates a `LISTNUM` field with a specific list. To emulate the behavior of the `AUTONUM` ([AUTONUM](AUTONUM.md)), `AUTONUMLGL` ([AUTONUMLGL](AUTONUMLGL.md)), and `AUTONUMOUT` ([AUTONUMOUT](AUTONUMOUT.md)) fields, use the list names `NumberDefault`, `LegalDefault`, and `OutlineDefault` names, respectively. By default, the `NumberFormat` list is used. The XML generated for a complex field implementation shall not have the optional field value stored. There are nine levels of list, and, assuming `\s 1` for each, the result style used for each is as follows: 1 1\) 4 (1) 7 1\. 2 A) 5 (a) 8 A. 3 Iii) 6 (iii) 9 Iii.
    /// </summary>
    public class ListNumFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The name of the list
        /// </summary>
        public string? ListName { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// List level
        /// </summary>
        public string? Level { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Starting number
        /// </summary>
        public string? StartingNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the ListNumFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public ListNumFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "LISTNUM")
            {
                throw new ArgumentException(
                    $"Expected LISTNUM field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                ListName = firstNonSwitch.Value?.ToString();
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
                        case "\\s":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    StartingNumber = nextArg.Value?.ToString();
                                }
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
            List<string> result = new List<string> { Source.Instruction };

            if (ListName != null)
            {
                string argString = ListName.ToString();
                result.Add(argString.Contains(" ") ? $"\"{ListName}\"" : argString);
            }

            if (Level != null)
            {
                result.Add("\\l");
                result.Add(Level.ToString().Contains(" ") ? $"\"{Level}\"" : Level.ToString());
            }

            if (StartingNumber != null)
            {
                result.Add("\\s");
                result.Add(
                    StartingNumber.ToString().Contains(" ")
                        ? $"\"{StartingNumber}\""
                        : StartingNumber.ToString()
                );
            }

            return string.Join(" ", result);
        }
    }
}
