using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.Ast
{
    /// <summary>
    /// Represents a node that can be evaluated to a value.
    /// This base class includes properties to retain all surrounding whitespace for lossless parsing.
    /// </summary>
    public abstract class ExpressionNode : Node
    {
        /// <summary>
        /// Whitespace characters that appeared before this expression in the original text.
        /// </summary>
        public List<Node> LeadingWhitespace { get; set; }

        /// <summary>
        /// Whitespace characters that appeared after this expression in the original text.
        /// </summary>
        public List<Node> TrailingWhitespace { get; set; }

        protected ExpressionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
        {
            LeadingWhitespace = leadingWhitespace ?? new List<Node>();
            TrailingWhitespace = trailingWhitespace ?? new List<Node>();

            LeadingWhitespace.TrimExcess();
            TrailingWhitespace.TrimExcess();
        }

        /// <summary>
        /// Converts the AST node back into its string representation, including all captured whitespace.
        /// </summary>
        public sealed override string ToString() =>
            string.Concat(LeadingWhitespace.Select((Node w) => w.ToString()))
            + ToRawString()
            + string.Concat(TrailingWhitespace.Select((Node w) => w.ToString()));

        public virtual int Precedence => Ast.Precedence.Default;

        public abstract override string ToRawString();

        public abstract override IEnumerable<O> Children<O>();

        public abstract override Node? ReplaceChild(int index, Node replacement);
    }
}
