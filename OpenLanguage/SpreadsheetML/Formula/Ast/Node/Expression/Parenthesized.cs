using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    /// <summary>
    /// Represents an expression that was explicitly enclosed in parentheses in the original formula.
    /// </summary>
    public class ParenthesizedExpressionNode : ExpressionNode
    {
        public ExpressionNode Expression { get; set; }

        public ParenthesizedExpressionNode(
            ExpressionNode expression,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Expression = expression;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override IEnumerable<O> Children<O>()
        {
            if (Expression is O expr)
            {
                yield return expr;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is ExpressionNode expr)
            {
                ExpressionNode current = Expression;
                Expression = expr;
                return current;
            }
            return null;
        }

        public override string ToRawString() => "(" + Expression.ToRawString() + ")";
    }
}
