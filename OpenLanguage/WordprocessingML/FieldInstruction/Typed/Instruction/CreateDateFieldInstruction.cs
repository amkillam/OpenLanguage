using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed CREATEDATE field instruction.
    /// Retrieves the date and time at which the document was created, as recorded in the `&lt;DateCreated&gt;` element of the Core File Properties part. By default, the Gregorian calendar is used and the date-and-time-formatting-switch used is implementation-defined.
    /// </summary>
    public class CreateDateFieldInstruction : TypedFieldInstruction
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
        /// Initializes a new instance of the CreateDateFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public CreateDateFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "CREATEDATE")
            {
                throw new ArgumentException(
                    $"Expected CREATEDATE field, but got {Source.Instruction}"
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
                    "CREATEDATE field cannot specify both \\h (Hijri) and \\s (Saka) calendar switches"
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
