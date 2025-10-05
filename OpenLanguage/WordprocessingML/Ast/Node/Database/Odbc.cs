using System.Collections.Generic;
using System.Data.Odbc;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class OdbcConnectionStringNode : ExpressionNode
    {
        public OdbcConnectionStringBuilder Value { get; set; }
        private ExpressionNode RawExpression { get; set; }

        public OdbcConnectionStringNode(
            ExpressionNode value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            RawExpression = value;
            string connectionString;
            if (value is Quoted<ExpressionNode> quoted && quoted.Inner is StringLiteralNode sln)
            {
                connectionString = sln.Value;
            }
            else
            {
                connectionString = value.ToRawString();
            }
            Value = new OdbcConnectionStringBuilder(connectionString);
        }

        public override string ToRawString() => RawExpression.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (RawExpression is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is ExpressionNode expr)
            {
                Node? old = RawExpression;
                RawExpression = expr;
                return old;
            }
            return null;
        }
    }
}
