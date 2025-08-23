using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    /// <summary>
    /// Represents an expression that was explicitly enclosed in parentheses in the original formula.
    /// </summary>
    public class ParenthesizedExpressionNode : ExpressionNode
    {
        public ExpressionNode Expression { get; set; }
        public List<Node> WsAfterOpenParen { get; set; }
        public List<Node> WsBeforeCloseParen { get; set; }

        public ParenthesizedExpressionNode(
            ExpressionNode expression,
            List<Node> wsAfterOpenParen,
            List<Node> wsBeforeCloseParen,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Expression = expression;
            WsAfterOpenParen = wsAfterOpenParen;
            WsBeforeCloseParen = wsBeforeCloseParen;
        }

        public override Int32 Precedence => Ast.Precedence.Primary;

        public override IEnumerable<O> Children<O>()
        {
            if (Expression is O expr)
            {
                yield return expr;
            }
        }

        public override Node? ReplaceChild(Int32 index, Node replacement)
        {
            if (index == 0 && replacement is ExpressionNode expr)
            {
                ExpressionNode current = Expression;
                Expression = expr;
                return current;
            }
            return null;
        }

        public override string ToRawString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('(');
            builder.Append(string.Concat(WsAfterOpenParen.Select(w => w.ToString())));
            // The child expression's ToString() call will handle its own surrounding whitespace correctly.
            builder.Append(Expression.ToString());
            builder.Append(string.Concat(WsBeforeCloseParen.Select(w => w.ToString())));
            builder.Append(')');
            return builder.ToString();
        }
    }
}
