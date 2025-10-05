using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
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
}
