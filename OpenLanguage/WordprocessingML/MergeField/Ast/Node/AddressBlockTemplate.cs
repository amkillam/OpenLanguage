using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    /// <summary>
    /// Represents an address block template node in the AST.
    /// </summary>
    public class AddressBlockTemplateNode : ExpressionNode
    {
        public string RawTemplate { get; set; }
        public List<MergeFieldNode> Placeholders { get; set; }
        public string ProcessedTemplate { get; set; }

        public AddressBlockTemplateNode(
            string rawTemplate,
            List<MergeFieldNode> placeholders,
            string processedTemplate,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            RawTemplate = rawTemplate;
            Placeholders = placeholders;
            ProcessedTemplate = processedTemplate;
        }

        public override string ToRawString() => RawTemplate;

        public override IEnumerable<O> Children<O>()
        {
            foreach (MergeFieldNode placeholder in Placeholders)
            {
                if (placeholder is O o)
                {
                    yield return o;
                }

                foreach (O child in placeholder.Children<O>())
                {
                    yield return child;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index < Placeholders.Count)
            {
                if (replacement is MergeFieldNode newPlaceholder)
                {
                    current = Placeholders[index];
                    Placeholders[index] = newPlaceholder;
                }
            }

            return current;
        }
    }
}
