using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class XPathExpressionNode : ExpressionNode
    {
        public System.Xml.XPath.XPathExpression Value { get; set; }
        private readonly string _raw;

        public XPathExpressionNode(
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = System.Xml.XPath.XPathExpression.Compile(raw);
            _raw = raw;
        }

        public override string ToRawString() => _raw;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }
}
