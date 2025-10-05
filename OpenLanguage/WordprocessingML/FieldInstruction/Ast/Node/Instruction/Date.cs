using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum DateArgument
    {
        UseHijri,
        UseSaka,
        UseLastUsed,
        DateTimeFormat,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed DATE field instruction.
    /// Retrieves the current date and time. By default, the calendar used is locale-specific, and the date-and-time-formatting-switch used is implementation-defined.
    /// </summary>
    public class DateFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Switch: \@ field-argument
        /// Specifies the date and time format to be used.
        /// The format is specified using a string of picture items. If the result of a field is not a date or time, this switch has no effect.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        /// <summary>
        /// Switch: \h
        /// Use the Hijri/Lunar calendar instead of the default Gregorian calendar.
        /// </summary>
        public BoolFlagNode? UseHijriCalendar { get; set; }

        /// <summary>
        /// Switch: \l
        /// If no date-and-time-formatting-switch is used, the date shall use the date format last used by the hosting application when inserting a new DATE field.
        /// </summary>
        public BoolFlagNode? UseLastUsedFormat { get; set; }

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

        public List<DateArgument> Order { get; set; } = new List<DateArgument>();

        public DateFieldInstruction(
            StringLiteralNode instruction,
            BoolFlagNode? useHijriCalendar,
            BoolFlagNode? useSakaCalendar,
            BoolFlagNode? useLastUsedFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<DateArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            DateTimeFormat = dateTimeFormat;
            GeneralFormat = generalFormat;
            UseHijriCalendar = useHijriCalendar;
            UseSakaCalendar = useSakaCalendar;
            UseLastUsedFormat = useLastUsedFormat;
            if (UseHijriCalendar != null && UseSakaCalendar != null)
            {
                throw new ArgumentException(
                    "DATE field cannot specify both \\h (Hijri) and \\s (Saka) calendar switches"
                );
            }

            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        DateArgument.DateTimeFormat => DateTimeFormat?.ToString() ?? string.Empty,
                        DateArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        DateArgument.UseHijri => UseHijriCalendar?.ToString() ?? string.Empty,
                        DateArgument.UseLastUsed => UseLastUsedFormat?.ToString() ?? string.Empty,
                        DateArgument.UseSaka => UseSakaCalendar?.ToString() ?? string.Empty,

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
            foreach (DateArgument arg in Order)
            {
                switch (arg)
                {
                    case DateArgument.DateTimeFormat:
                        if (DateTimeFormat is O oFormat)
                        {
                            yield return oFormat;
                        }
                        break;
                    case DateArgument.GeneralFormat:
                        if (GeneralFormat is O oGenFormat)
                        {
                            yield return oGenFormat;
                        }
                        break;

                    case DateArgument.UseHijri:
                        if (UseHijriCalendar is O oHijri)
                        {
                            yield return oHijri;
                        }
                        break;

                    case DateArgument.UseLastUsed:
                        if (UseLastUsedFormat is O oLastUsed)
                        {
                            yield return oLastUsed;
                        }
                        break;
                    case DateArgument.UseSaka:
                        if (UseSakaCalendar is O oSaka)
                        {
                            yield return oSaka;
                        }

                        break;
                    default:
                        break;
                }
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode sl)
            {
                current = Instruction;
                Instruction = sl;
            }
            else
            {
                index--;
                if (index >= 0 && index < Order.Count)
                {
                    DateArgument arg = Order[index];
                    switch (arg)
                    {
                        case DateArgument.DateTimeFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> rfa)
                            {
                                current = DateTimeFormat;
                                DateTimeFormat = rfa;
                            }
                            break;
                        case DateArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> rga)
                            {
                                current = GeneralFormat;
                                GeneralFormat = rga;
                            }
                            break;
                        case DateArgument.UseHijri:
                            if (replacement is BoolFlagNode rha)
                            {
                                current = UseHijriCalendar;
                                UseHijriCalendar = rha;
                            }
                            break;
                        case DateArgument.UseLastUsed:
                            if (replacement is BoolFlagNode rla)
                            {
                                current = UseLastUsedFormat;
                                UseLastUsedFormat = rla;
                            }
                            break;
                        case DateArgument.UseSaka:
                            if (replacement is BoolFlagNode rsa)
                            {
                                current = UseSakaCalendar;
                                UseSakaCalendar = rsa;
                            }
                            break;
                    }
                }
            }

            return current;
        }
    }
}
