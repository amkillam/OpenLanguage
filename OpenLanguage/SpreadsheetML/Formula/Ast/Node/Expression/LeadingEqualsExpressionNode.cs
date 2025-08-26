using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    // Wraps an expression and renders a leading '=' before it.
    // Whitespace:
    //  - LeadingWhitespace: before the '='
    //  - TrailingWhitespace: after the wrapped expression
    //  - Any whitespace immediately after '=' should be placed in the wrapped Expression.LeadingWhitespace by the parser action.
    public class LeadingEqualsExpressionNode : ExpressionNode
    {
        public ExpressionNode Expression { get; set; }

        public LeadingEqualsExpressionNode(
            ExpressionNode expression,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Expression = expression;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => "=" + Expression.ToString();

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
    }
}
