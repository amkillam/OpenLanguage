using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum CreateDateArgument
    {
        DateTimeFormat,
        GeneralFormat,
        UseHijriCalendar,
        UseSakaCalendar,
    }

    /// <summary>
    /// Represents a strongly-typed CREATEDATE field instruction.
    /// Retrieves the date and time at which the document was created, as recorded in the `<DateCreated>` element of the Core File Properties part.
    /// By default, the calendar used is locale-specific, and the date-and-time-formatting-switch used is implementation-defined.
    /// </summary>
    public class CreateDateFieldInstruction : FieldInstruction
    {
        // <summary>
        // Switch: \@
        // Specifies the date and time format to be used.
        // The format is specified using a string in the same format as used by the Microsoft
        // Word application.
        // </summary>
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

        public List<CreateDateArgument> Order { get; set; } = new List<CreateDateArgument>();

        public CreateDateFieldInstruction(
            StringLiteralNode instruction,
            BoolFlagNode? useHijriCalendar,
            BoolFlagNode? useSakaCalendar,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<CreateDateArgument> order,
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
                    "CREATEDATE field cannot specify both \\h (Hijri) and \\s (Saka) calendar switches"
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
                        CreateDateArgument.DateTimeFormat => DateTimeFormat?.ToString()
                            ?? string.Empty,
                        CreateDateArgument.GeneralFormat => GeneralFormat?.ToString()
                            ?? string.Empty,
                        CreateDateArgument.UseHijriCalendar => UseHijriCalendar?.ToString()
                            ?? string.Empty,
                        CreateDateArgument.UseSakaCalendar => UseSakaCalendar?.ToString()
                            ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o1)
            {
                yield return o1;
            }
            foreach (CreateDateArgument arg in Order)
            {
                Node? child = arg switch
                {
                    CreateDateArgument.DateTimeFormat => DateTimeFormat,
                    CreateDateArgument.GeneralFormat => GeneralFormat,
                    CreateDateArgument.UseHijriCalendar => UseHijriCalendar,
                    CreateDateArgument.UseSakaCalendar => UseSakaCalendar,
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
                if (index > -1 && index < Order.Count)
                {
                    CreateDateArgument arg = Order[index];
                    switch (arg)
                    {
                        case CreateDateArgument.DateTimeFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> format)
                            {
                                current = DateTimeFormat;
                                DateTimeFormat = format;
                            }
                            break;
                        case CreateDateArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> generalFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = generalFormat;
                            }
                            break;
                        case CreateDateArgument.UseHijriCalendar:
                            if (replacement is BoolFlagNode hijri)
                            {
                                current = UseHijriCalendar;
                                UseHijriCalendar = hijri;
                            }
                            break;
                        case CreateDateArgument.UseSakaCalendar:
                            if (replacement is BoolFlagNode saka)
                            {
                                current = UseSakaCalendar;
                                UseSakaCalendar = saka;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}
