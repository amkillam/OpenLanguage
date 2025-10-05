using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class WhitespaceNode : Node
    {
        public string Raw { get; set; }

        public WhitespaceNode(string raw)
        {
            Raw = raw;
        }

        public override string ToRawString() => Raw;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;

        public override string ToString() => Raw;
    }
}
