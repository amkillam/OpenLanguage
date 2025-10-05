using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum AdvanceArgument
    {
        DownByPoints,
        LeftByPoints,
        RightByPoints,
        UpByPoints,
        HorizontalPosition,
        VerticalPosition,
        GeneralFormat,
        NumericFormat,
    }

    public class AdvanceFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? DownByPoints { get; set; }
        public FlaggedArgument<ExpressionNode>? LeftByPoints { get; set; }
        public FlaggedArgument<ExpressionNode>? RightByPoints { get; set; }
        public FlaggedArgument<ExpressionNode>? UpByPoints { get; set; }
        public FlaggedArgument<ExpressionNode>? HorizontalPosition { get; set; }
        public FlaggedArgument<ExpressionNode>? VerticalPosition { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public List<AdvanceArgument> Order { get; set; } = new List<AdvanceArgument>();

        public AdvanceFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? down,
            FlaggedArgument<ExpressionNode>? left,
            FlaggedArgument<ExpressionNode>? right,
            FlaggedArgument<ExpressionNode>? up,
            FlaggedArgument<ExpressionNode>? x,
            FlaggedArgument<ExpressionNode>? y,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<AdvanceArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            DownByPoints = down;
            LeftByPoints = left;
            RightByPoints = right;
            UpByPoints = up;
            HorizontalPosition = x;
            VerticalPosition = y;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        AdvanceArgument.DownByPoints => DownByPoints?.ToString() ?? string.Empty,
                        AdvanceArgument.LeftByPoints => LeftByPoints?.ToString() ?? string.Empty,
                        AdvanceArgument.RightByPoints => RightByPoints?.ToString() ?? string.Empty,
                        AdvanceArgument.UpByPoints => UpByPoints?.ToString() ?? string.Empty,
                        AdvanceArgument.HorizontalPosition => HorizontalPosition?.ToString()
                            ?? string.Empty,
                        AdvanceArgument.VerticalPosition => VerticalPosition?.ToString()
                            ?? string.Empty,
                        AdvanceArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        AdvanceArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstr)
            {
                yield return oInstr;
            }
            foreach (AdvanceArgument arg in Order)
            {
                Node? child = arg switch
                {
                    AdvanceArgument.DownByPoints => DownByPoints,
                    AdvanceArgument.LeftByPoints => LeftByPoints,
                    AdvanceArgument.RightByPoints => RightByPoints,
                    AdvanceArgument.UpByPoints => UpByPoints,
                    AdvanceArgument.HorizontalPosition => HorizontalPosition,
                    AdvanceArgument.VerticalPosition => VerticalPosition,
                    AdvanceArgument.GeneralFormat => GeneralFormat,
                    AdvanceArgument.NumericFormat => NumericFormat,
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
                if (replacement is StringLiteralNode instr)
                {
                    current = Instruction;
                    Instruction = instr;
                }
                return current;
            }

            index--;
            if (index >= 0 && index < Order.Count)
            {
                AdvanceArgument arg = Order[index];
                switch (arg)
                {
                    case AdvanceArgument.DownByPoints:
                        if (replacement is FlaggedArgument<ExpressionNode> down)
                        {
                            current = DownByPoints;
                            DownByPoints = down;
                        }
                        break;
                    case AdvanceArgument.LeftByPoints:
                        if (replacement is FlaggedArgument<ExpressionNode> left)
                        {
                            current = LeftByPoints;
                            LeftByPoints = left;
                        }
                        break;
                    case AdvanceArgument.RightByPoints:
                        if (replacement is FlaggedArgument<ExpressionNode> right)
                        {
                            current = RightByPoints;
                            RightByPoints = right;
                        }
                        break;
                    case AdvanceArgument.UpByPoints:
                        if (replacement is FlaggedArgument<ExpressionNode> up)
                        {
                            current = UpByPoints;
                            UpByPoints = up;
                        }
                        break;
                    case AdvanceArgument.HorizontalPosition:
                        if (replacement is FlaggedArgument<ExpressionNode> x)
                        {
                            current = HorizontalPosition;
                            HorizontalPosition = x;
                        }
                        break;
                    case AdvanceArgument.VerticalPosition:
                        if (replacement is FlaggedArgument<ExpressionNode> y)
                        {
                            current = VerticalPosition;
                            VerticalPosition = y;
                        }
                        break;
                    case AdvanceArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> gen)
                        {
                            current = GeneralFormat;
                            GeneralFormat = gen;
                        }
                        break;
                    case AdvanceArgument.NumericFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> num)
                        {
                            current = NumericFormat;
                            NumericFormat = num;
                        }
                        break;
                }
            }

            return current;
        }
    }
}
