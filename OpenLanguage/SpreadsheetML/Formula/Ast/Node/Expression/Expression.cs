using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    /// <summary>
    /// Represents a node that can be evaluated to a value.
    /// This base class now includes properties to retain all surrounding whitespace for lossless parsing.
    /// </summary>
    public abstract class ExpressionNode : Node
    {
        /// <summary>
        /// Whitespace characters that appeared before this expression in the original formula.
        /// </summary>
        public List<Node> LeadingWhitespace { get; set; }

        /// <summary>
        /// Whitespace characters that appeared after this expression in the original formula.
        /// </summary>
        public List<Node> TrailingWhitespace { get; set; }

        protected ExpressionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
        {
            LeadingWhitespace = leadingWhitespace ?? new List<Node>();
            TrailingWhitespace = trailingWhitespace ?? new List<Node>();
        }

        /// <summary>
        /// Gets the operator precedence for this expression node.
        /// </summary>
        public abstract int Precedence { get; }

        /// <summary>
        /// Renders the core content of the node without its own leading/trailing whitespace.
        /// </summary>
        /// <returns>The raw string representation of this node's specific content.</returns>
        public abstract string ToRawString();

        /// <summary>
        /// Converts the AST node back into its string representation, including all captured whitespace.
        /// </summary>
        public sealed override string ToString() =>
            string.Concat(LeadingWhitespace.Select((Node w) => w.ToString()))
            + ToRawString()
            + string.Concat(TrailingWhitespace.Select((Node w) => w.ToString()));
    }
}
