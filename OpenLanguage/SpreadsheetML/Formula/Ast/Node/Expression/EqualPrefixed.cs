using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class EqualPrefixedNode : ExpressionNode
    {
        public ExpressionNode Expression { get; set; }
        public EqualLiteralNode EqualPrefix { get; set; }

        public EqualPrefixedNode(
            EqualLiteralNode equalPrefix,
            ExpressionNode expression,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            EqualPrefix = equalPrefix;
            Expression = expression;
        }

        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => EqualPrefix.ToString() + Expression.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (EqualPrefix is O eq)
            {
                yield return eq;
            }
            if (Expression is O expr)
            {
                yield return expr;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            ExpressionNode? current = null;
            if (index == 0 && replacement is EqualLiteralNode eq)
            {
                current = EqualPrefix;
                EqualPrefix = eq;
            }
            else if (index == 1 && replacement is ExpressionNode expr)
            {
                current = Expression;
                Expression = expr;
            }
            return current;
        }
    }
}
