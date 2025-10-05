using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public abstract class FieldInstruction : ExpressionNode
    {
        public StringLiteralNode Instruction { get; protected set; }

        protected FieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Instruction = instruction;
        }

        public override string ToRawString() => Instruction.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o1)
            {
                yield return o1;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
            }
            return current;
        }
    }

    public class NestedFieldInstruction : ExpressionNode
    {
        public ExpressionNode NestedInstruction { get; set; }

        public LeftBraceNode? LeftBrace { get; set; }
        public RightBraceNode? RightBrace { get; set; }

        public NestedFieldInstruction(
            LeftBraceNode? leftBrace,
            ExpressionNode nestedInstruction,
            RightBraceNode? rightBrace,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            LeftBrace = leftBrace;
            NestedInstruction = nestedInstruction;
            RightBrace = rightBrace;
        }

        public override string ToRawString() =>
            (LeftBrace?.ToString() ?? string.Empty)
            + NestedInstruction.ToString()
            + (RightBrace?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (LeftBrace is O o1)
            {
                yield return o1;
            }
            if (NestedInstruction is O o2)
            {
                yield return o2;
            }
            if (RightBrace is O o3)
            {
                yield return o3;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is LeftBraceNode lbn)
            {
                current = LeftBrace;
                LeftBrace = lbn;
            }
            else if (index == 1 && replacement is ExpressionNode fin)
            {
                current = NestedInstruction;
                NestedInstruction = fin;
            }
            else if (index == 2 && replacement is RightBraceNode rbn)
            {
                current = RightBrace;
                RightBrace = rbn;
            }
            return current;
        }
    }
}
