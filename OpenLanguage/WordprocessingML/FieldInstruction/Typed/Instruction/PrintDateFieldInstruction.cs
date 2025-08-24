using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed PRINTDATE field instruction.
    /// Retrieves the date and time on which the document was last printed, as recorded in the `&lt;LastPrinted&gt;` element of the Core File Properties part. By default, the Gregorian calendar is used and the date-and-time-formatting-switch used is implementation-defined. For a document that has never been printed, the date and time corresponds to `0000-00-00T00:00:00` local time and each text component is `XXX`.
    /// </summary>
    public class PrintDateFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// Switch: \h
        /// Use the Hijri/Lunar calendar instead of the default Gregorian calendar.
        /// </summary>
        public bool UseHijriCalendar { get; set; }

        /// <summary>
        /// Switch: \s
        /// Use the Saka Era calendar instead of the default Gregorian calendar.
        /// </summary>
        public bool UseSakaCalendar { get; set; }

        /// <summary>
        /// Whether to use the Gregorian calendar (default behavior when no calendar switches are specified).
        /// This is true by default and becomes false when \h or \s switches are used.
        /// </summary>
        public bool UseGregorianCalendar => !UseHijriCalendar && !UseSakaCalendar;

        /// <summary>
        /// Initializes a new instance of the PrintDateFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public PrintDateFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "PRINTDATE")
            {
                throw new ArgumentException(
                    $"Expected PRINTDATE field, but got {Source.Instruction}"
                );
            }

            // Parse field-specific switches
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

            // Validate that only one calendar type is specified
            if (UseHijriCalendar && UseSakaCalendar)
            {
                throw new ArgumentException(
                    "PRINTDATE field cannot specify both \\h (Hijri) and \\s (Saka) calendar switches"
                );
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
            else if (UseSakaCalendar)
            {
                result.Add("\\s");
            }
            // Note: Gregorian calendar is the default, so no switch is needed

            return string.Join(" ", result);
        }
    }
}
