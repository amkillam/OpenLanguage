using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    /// <summary>
    /// Represents a binary expression node in the AST.
    /// </summary>
    public class BinaryExpressionNode : ExpressionNode
    {
        public ExpressionNode LeftOperand { get; set; }
        public ExpressionNode Operator { get; set; }
        public ExpressionNode RightOperand { get; set; }

        public BinaryExpressionNode(
            ExpressionNode leftOperand,
            ExpressionNode op,
            ExpressionNode rightOperand,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            LeftOperand = leftOperand;
            Operator = op;
            RightOperand = rightOperand;
        }

        public override string ToRawString() =>
            LeftOperand.ToString() + Operator.ToString() + RightOperand.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (LeftOperand is O o1)
            {
                yield return o1;
            }
            if (Operator is O o2)
            {
                yield return o2;
            }
            if (RightOperand is O o3)
            {
                yield return o3;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            switch (index)
            {
                case 0:
                    current = LeftOperand;
                    LeftOperand = (ExpressionNode)replacement;
                    break;
                case 1:
                    current = Operator;
                    Operator = (ExpressionNode)replacement;
                    break;
                case 2:
                    current = RightOperand;
                    RightOperand = (ExpressionNode)replacement;
                    break;
            }

            return current;
        }
    }
}
