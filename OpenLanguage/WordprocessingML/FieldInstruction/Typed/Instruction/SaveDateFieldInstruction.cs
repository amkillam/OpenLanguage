using System;
using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed SAVEDATE field instruction.
    /// Retrieves the date and time on which the document was last saved, as recorded in the &lt;DateModified&gt; element of the Core File Properties part. By default, the Gregorian calendar is used and the date-and-time-formatting-switch used is implementation-defined. For a document that has never been saved, the date and time corresponds to 0000-00-00T00:00:00 local time and each text component is XXX.
    /// </summary>
    public class SaveDateFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \h
        /// Use Hijri/Lunar calendar
        /// </summary>
        public bool UseHijriCalendar { get; set; }

        /// <summary>
        /// Switch: \s
        /// Use Saka Era calendar
        /// </summary>
        public bool UseSakaCalendar { get; set; }

        /// <summary>
        /// Initializes a new instance of the SaveDateFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public SaveDateFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "SAVEDATE")
            {
                throw new ArgumentException(
                    $"Expected SAVEDATE field, but got {Source.Instruction}"
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
                        case "\\h":
                            UseHijriCalendar = true;
                            break;
                        case "\\s":
                            UseSakaCalendar = true;
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

            if (UseHijriCalendar)
            {
                result.Add("\\h");
            }

            if (UseSakaCalendar)
            {
                result.Add("\\s");
            }

            return string.Join(" ", result);
        }
    }
}
