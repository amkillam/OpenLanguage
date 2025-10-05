using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Generated
{
    public class EqArgumentList : ExpressionNode
    {
        public List<ExpressionNode> Items { get; set; }
        public List<CharacterLiteralNode> Separators { get; set; }

        public EqArgumentList()
            : base(null, null)
        {
            Items = new List<ExpressionNode>();
            Separators = new List<CharacterLiteralNode>();
        }

        public EqArgumentList(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Items = new List<ExpressionNode>();
            Separators = new List<CharacterLiteralNode>();
        }

        public EqArgumentList(
            List<ExpressionNode> items,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Items = items;
            Separators = new List<CharacterLiteralNode>();
        }

        public EqArgumentList(
            List<CharacterLiteralNode> separators,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Items = new List<ExpressionNode>();
            Separators = separators;
        }

        public EqArgumentList(
            List<ExpressionNode> items,
            List<CharacterLiteralNode> separators,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Items = items;
            Separators = separators;
        }

        public override string ToRawString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            for (int i = 0; i < Items.Count; i++)
            {
                result.Append(Items[i].ToString());
                if (i < Separators.Count)
                {
                    result.Append(Separators[i].ToString());
                }
            }

            return result.ToString();
        }

        public override IEnumerable<O> Children<O>()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] is O o)
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
            int itemsCount = Items?.Count ?? 0;
            int separatorsCount = Separators?.Count ?? 0;

            if (index > -1 && index < itemsCount && replacement is ExpressionNode expr)
            {
                current = Items![index];
                Items![index] = expr;
            }
            else if (
                index >= itemsCount
                && index < itemsCount + separatorsCount
                && replacement is CharacterLiteralNode charNode
            )
            {
                int sepIndex = index - itemsCount;
                current = Separators![sepIndex];
                Separators![sepIndex] = charNode;
            }

            return current;
        }
    }

    public class ConcatenatedNodes : ExpressionNode
    {
        public List<ExpressionNode> Nodes { get; set; }

        public ConcatenatedNodes(
            List<ExpressionNode> nodes,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Nodes = nodes;
            Nodes.TrimExcess();
        }

        public override string ToRawString() => string.Concat(Nodes.Select(n => n.ToString()));

        public override IEnumerable<O> Children<O>()
        {
            foreach (ExpressionNode node in Nodes)
            {
                if (node is O o)
                {
                    yield return o;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index >= 0 && index < Nodes.Count && replacement is ExpressionNode expr)
            {
                current = Nodes[index];
                Nodes[index] = expr;
            }
            return current;
        }

        public void Add(ExpressionNode node) => Nodes.Add(node);
    }

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

    public class FrameTargetNode : ExpressionNode
    {
        private FrameTarget Value { get; set; }

        public FrameTargetNode(
            FrameTarget value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
        }

        public override string ToRawString() =>
            OpenLanguage.WordprocessingML.FieldInstruction.FrameTargetUtils.FrameTargetText(Value);

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

    public class DatabaseTableAttributesNode : ExpressionNode
    {
        private DatabaseTableAttributes Value { get; set; }
        private string? Raw { get; set; }

        public DatabaseTableAttributesNode(
            DatabaseTableAttributes value,
            string? raw = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            Raw = raw;
        }

        public override string ToRawString() => Raw ?? ((int)Value).ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class DatabaseTableFormatNode : ExpressionNode
    {
        private DatabaseTableFormat Value { get; set; }
        private string? Raw { get; set; }

        public DatabaseTableFormatNode(
            DatabaseTableFormat value,
            string? raw = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            Raw = raw;
        }

        public override string ToRawString() => Raw ?? ((int)Value).ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class DatabaseOptimizationFlagNode : ExpressionNode
    {
        private DatabaseOptimizationFlag Value { get; set; }
        private bool IsDefault { get; set; }

        public DatabaseOptimizationFlagNode(
            DatabaseOptimizationFlag value,
            bool isDefault = false,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            IsDefault = isDefault;
        }

        public override string ToRawString() => IsDefault ? string.Empty : Value.ToString();

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }

    public class LinkFormattingModeNode : ExpressionNode
    {
        private OpenLanguage.WordprocessingML.FieldInstruction.LinkFormattingMode Value { get; set; }

        public LinkFormattingModeNode(
            LinkFormattingMode value,
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

    public class EqPrimarySwitchNode : ExpressionNode
    {
        private EqPrimarySwitch Value { get; set; }

        public EqPrimarySwitchNode(
            EqPrimarySwitch value,
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

    public class FontSizeNode : ExpressionNode
    {
        public DocumentFormat.OpenXml.Wordprocessing.FontSize Value { get; set; }
        private readonly string _raw;

        public FontSizeNode(
            DocumentFormat.OpenXml.Wordprocessing.FontSize value,
            string raw,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
            _raw = raw;
        }

        public override string ToRawString() => _raw;

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

    public class EqArrayAlignmentNode : ExpressionNode
    {
        private EqArrayAlignment Value { get; set; }

        public EqArrayAlignmentNode(
            EqArrayAlignment value,
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

    public class EqIntegralSymbolNode : ExpressionNode
    {
        private EqIntegralSymbol Value { get; set; }

        public EqIntegralSymbolNode(
            EqIntegralSymbol value,
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

    public class EqOverlayAlignmentNode : ExpressionNode
    {
        private EqOverlayAlignment Value { get; set; }

        public EqOverlayAlignmentNode(
            EqOverlayAlignment value,
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
