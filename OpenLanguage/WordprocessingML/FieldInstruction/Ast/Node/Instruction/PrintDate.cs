using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum PrintDateArgument
    {
        DateTimeFormat,
        GeneralFormat,
        UseHijri,
        UseSaka,
    }

    /// <summary>
    /// Represents a strongly-typed PRINTDATE field instruction.
    /// Retrieves the date and time on which the document was last printed, as recorded in the `<LastPrinted>` element of the Core File Properties part.
    /// By default, the calendar used is locale-specific, and the date-and-time-formatting-switch used is implementation-defined.
    /// For a document that has never been printed, the date and time corresponds to `0000-00-00T00:00:00` local time and each text component is `XXX`.
    /// </summary>
    public class PrintDateFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// Switch: \@ field-argument
        /// Specifies the date and time format to be used.
        /// The format is specified using a string of picture items.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        /// <summary>
        /// Switch: \h
        /// Use the Hijri/Lunar calendar instead of the default Gregorian calendar.
        /// </summary>
        public BoolFlagNode? UseHijriCalendar { get; set; }

        /// <summary>
        /// Switch: \s
        /// Use the Saka Era calendar instead of the default Gregorian calendar.
        /// </summary>
        public BoolFlagNode? UseSakaCalendar { get; set; }

        /// <summary>
        /// Whether to use the Gregorian calendar (default behavior when no calendar switches are specified).
        /// This is true by default and becomes false when \h or \s switches are used.
        /// </summary>
        public bool UseGregorianCalendar => UseHijriCalendar == null && UseSakaCalendar == null;

        public List<PrintDateArgument> Order { get; set; } = new List<PrintDateArgument>();

        public PrintDateFieldInstruction(
            StringLiteralNode instruction,
            BoolFlagNode? useHijriCalendar,
            BoolFlagNode? useSakaCalendar,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<PrintDateArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            UseHijriCalendar = useHijriCalendar;
            UseSakaCalendar = useSakaCalendar;
            if (UseHijriCalendar != null && UseSakaCalendar != null)
            {
                throw new ArgumentException(
                    "PRINTDATE field cannot specify both \\h (Hijri) and \\s (Saka) calendar switches"
                );
            }
            DateTimeFormat = dateTimeFormat;
            GeneralFormat = generalFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        PrintDateArgument.DateTimeFormat => DateTimeFormat?.ToString()
                            ?? string.Empty,
                        PrintDateArgument.GeneralFormat => GeneralFormat?.ToString()
                            ?? string.Empty,
                        PrintDateArgument.UseHijri => UseHijriCalendar?.ToString() ?? string.Empty,
                        PrintDateArgument.UseSaka => UseSakaCalendar?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            foreach (PrintDateArgument arg in Order)
            {
                Node? child = arg switch
                {
                    PrintDateArgument.DateTimeFormat => DateTimeFormat,
                    PrintDateArgument.GeneralFormat => GeneralFormat,
                    PrintDateArgument.UseHijri => UseHijriCalendar,
                    PrintDateArgument.UseSaka => UseSakaCalendar,
                    _ => null,
                };

                if (child is O oChild)
                {
                    yield return oChild;
                }
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0)
            {
                if (replacement is StringLiteralNode instruction)
                {
                    current = Instruction;
                    Instruction = instruction;
                }
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    PrintDateArgument arg = Order[index];
                    switch (arg)
                    {
                        case PrintDateArgument.DateTimeFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> format)
                            {
                                current = DateTimeFormat;
                                DateTimeFormat = format;
                            }
                            break;
                        case PrintDateArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> generalFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = generalFormat;
                            }
                            break;
                        case PrintDateArgument.UseHijri:
                            if (replacement is BoolFlagNode useHijriCalendar)
                            {
                                current = UseHijriCalendar;
                                UseHijriCalendar = useHijriCalendar;
                            }
                            break;
                        case PrintDateArgument.UseSaka:
                            if (replacement is BoolFlagNode useSakaCalendar)
                            {
                                current = UseSakaCalendar;
                                UseSakaCalendar = useSakaCalendar;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return current;
        }
    }
}
