using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.Ast
{
    /// <summary>
    /// Represents a template containing a sequence of text and merge field elements.
    /// </summary>
    public class TemplateNode : ExpressionNode
    {
        public List<ExpressionNode> Elements { get; set; }

        public TemplateNode(
            List<ExpressionNode>? elements,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Elements = elements ?? new List<ExpressionNode>();
        }

        public override string ToRawString() =>
            string.Concat(Elements.Select(element => element.ToString()));

        public string ToProcessedTemplate()
        {
            string result = string.Empty;
            int placeholderIndex = 0;

            foreach (ExpressionNode element in Elements)
            {
                if (element is TextElementNode textElement)
                {
                    result += textElement.Text;
                }
                else if (element is MergeFieldElementNode)
                {
                    result += "{" + placeholderIndex + "}";
                    placeholderIndex++;
                }
            }

            return result;
        }

        public List<MergeFieldElementNode> MergeFields() =>
            Elements.OfType<MergeFieldElementNode>().ToList();

        public override IEnumerable<O> Children<O>()
        {
            foreach (ExpressionNode element in Elements)
            {
                if (element is O o)
                {
                    yield return o;
                }

                foreach (O child in element.Children<O>())
                {
                    yield return child;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index < Elements.Count)
            {
                if (replacement is ExpressionNode newElement)
                {
                    current = Elements[index];
                    Elements[index] = newElement;
                }
            }
            return current;
        }
    }
}
