using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public class NamespaceDeclarationNode : ExpressionNode
    {
        private NamespaceDeclaration Declaration { get; set; }

        public NamespaceDeclarationNode(
            NamespaceDeclaration declaration,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Declaration = declaration;
        }

        public override string ToRawString() => Declaration.ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class UriNode : ExpressionNode
    {
        public System.Uri Value { get; set; }
        private readonly string _raw;

        public UriNode(
            System.Uri value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            _raw = value.OriginalString;
        }

        public UriNode(
            string value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            _raw = value;
            Value = new System.Uri(value, System.UriKind.RelativeOrAbsolute);
        }

        public override string ToRawString() => _raw;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class CountryRegionInclusionNode : ExpressionNode
    {
        private CountryRegionInclusion Value { get; set; }
        private string? Raw { get; set; } = null;

        public CountryRegionInclusionNode(
            CountryRegionInclusion value,
            string? raw = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            Raw = raw;
        }

        public override string ToRawString() => Raw ?? Value.ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class LanguageIdentifierNode : ExpressionNode
    {
        public LanguageIdentifier Value { get; set; }
        public string? Raw { get; set; } = null;

        public LanguageIdentifierNode(
            LanguageIdentifier value,
            string? raw = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            Raw = raw;
        }

        public override string ToRawString() => Raw ?? Value.ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class NameFormatNode : ExpressionNode
    {
        private NameFormat Value { get; set; }

        public NameFormatNode(
            NameFormat value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
        }

        public override string ToRawString() => Value.ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class FacingIdentificationMarkTypeNode : ExpressionNode
    {
        private FacingIdentificationMarkType Value { get; set; }
        private string? Raw { get; set; } = null;

        public FacingIdentificationMarkTypeNode(
            FacingIdentificationMarkType value,
            string? raw = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            Raw = raw;
        }

        public override string ToRawString() => Raw ?? Value.ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class FloatListNode : ExpressionNode
    {
        public List<OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<float>> Values { get; set; }
        public List<CommaNode> Separators { get; set; }

        public FloatListNode(
            List<OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<float>> values,
            List<CommaNode> separators,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Values =
                values ?? new List<OpenLanguage.WordprocessingML.Ast.NumericLiteralNode<float>>();
            Values.TrimExcess();
            Separators = separators ?? new List<CommaNode>();
            Separators.TrimExcess();
        }

        public override string ToRawString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("\"");
            for (int i = 0; i < Values.Count; i++)
            {
                sb.Append(Values[i].ToString());
                if (i < Separators.Count)
                {
                    sb.Append(Separators[i].ToString());
                }
            }
            sb.Append("\"");
            return sb.ToString();
        }

        public override IEnumerable<O> Children<O>()
        {
            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i] is O o)
                {
                    yield return o;
                }
                if (i < Separators.Count && Separators[i] is O oSep)
                {
                    yield return oSep;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            int childIndex = 0;
            for (int i = 0; i < Values.Count; i++)
            {
                if (childIndex == index)
                {
                    if (replacement is NumericLiteralNode<float> val)
                    {
                        current = Values[i];
                        Values[i] = val;
                        return current;
                    }
                }
                childIndex++;

                if (i < Separators.Count)
                {
                    if (childIndex == index)
                    {
                        if (replacement is CommaNode sep)
                        {
                            current = Separators[i];
                            Separators[i] = sep;
                            return current;
                        }
                    }
                    childIndex++;
                }
            }
            return null;
        }
    }
}
