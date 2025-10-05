using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum TimeArgument
    {
        DateTimeFormat,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed TIME field instruction.
    /// Retrieves the current date and time.
    /// The Gregorian calendar is always used.
    /// By default, the date-and-time-formatting-switch used is implementation-defined.
    /// </summary>
    public class TimeFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public List<TimeArgument> Order { get; set; } = new List<TimeArgument>();

        public TimeFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? datetimeFormat,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<TimeArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            DateTimeFormat = datetimeFormat;
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
                        TimeArgument.DateTimeFormat => DateTimeFormat?.ToString() ?? string.Empty,
                        TimeArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }
            foreach (TimeArgument arg in Order)
            {
                switch (arg)
                {
                    case TimeArgument.DateTimeFormat:
                        if (DateTimeFormat is O oDateTimeFormat)
                        {
                            yield return oDateTimeFormat;
                        }
                        break;
                    case TimeArgument.GeneralFormat:
                        if (GeneralFormat is O oGeneralFormat)
                        {
                            yield return oGeneralFormat;
                        }
                        break;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0 && replacement is StringLiteralNode strRep)
            {
                current = Instruction;
                Instruction = strRep;
                return current;
            }

            index--;
            if (index > -1 && index < Order.Count)
            {
                TimeArgument arg = Order[index];
                switch (arg)
                {
                    case TimeArgument.DateTimeFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> flaggedDateTimeFormat)
                        {
                            current = DateTimeFormat;
                            DateTimeFormat = flaggedDateTimeFormat;
                        }
                        break;
                    case TimeArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> flaggedGeneralFormat)
                        {
                            current = GeneralFormat;
                            GeneralFormat = flaggedGeneralFormat;
                        }
                        break;
                }
            }

            return current;
        }
    }
}
