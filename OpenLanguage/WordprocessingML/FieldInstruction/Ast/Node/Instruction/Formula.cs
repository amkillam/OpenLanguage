using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum FormulaArgument
    {
        Expression,
        NumericFormat,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed formula field instruction (prefixed with '=').
    /// According to §2.16.3, a field instruction can involve a calculation via a formula.
    /// </summary>
    public class FormulaFieldInstruction : FieldInstruction
    {
        public ExpressionNode Expression { get; set; }

        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public List<FormulaArgument> Order { get; set; } = new List<FormulaArgument>();

        public FormulaFieldInstruction(
            EqualLiteralNode instruction,
            ExpressionNode expression,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? generalFormat,
            System.Collections.Generic.List<FormulaArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Expression = expression;
            NumericFormat = numericFormat;
            GeneralFormat = generalFormat;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        FormulaArgument.Expression => Expression.ToString(),
                        FormulaArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        FormulaArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
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

            foreach (FormulaArgument arg in Order)
            {
                Node? child = arg switch
                {
                    FormulaArgument.Expression => Expression,
                    FormulaArgument.NumericFormat => NumericFormat,
                    FormulaArgument.GeneralFormat => GeneralFormat,
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
            switch (index)
            {
                case 0:
                    if (replacement is EqualLiteralNode str)
                    {
                        current = Instruction;
                        Instruction = str;
                    }
                    break;
                default:
                {
                    index--;
                    if (index > -1 && index < Order.Count)
                    {
                        FormulaArgument arg = Order[index];
                        switch (arg)
                        {
                            case FormulaArgument.Expression:
                                if (replacement is ExpressionNode expr)
                                {
                                    current = Expression;
                                    Expression = expr;
                                }
                                break;
                            case FormulaArgument.NumericFormat:
                                if (replacement is FlaggedArgument<ExpressionNode> nf)
                                {
                                    current = NumericFormat;
                                    NumericFormat = nf;
                                }
                                break;
                            case FormulaArgument.GeneralFormat:
                                if (replacement is FlaggedArgument<ExpressionNode> gf)
                                {
                                    current = GeneralFormat;
                                    GeneralFormat = gf;
                                }
                                break;
                        }
                    }
                    break;
                }
            }
            return current;
        }
    }
}
