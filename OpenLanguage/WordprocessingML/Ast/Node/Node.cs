using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    /// <summary>
    /// The base class for all nodes in the Abstract Syntax Tree (AST).
    /// </summary>
    public abstract class Node
    {
        public abstract IEnumerable<O> Children<O>()
            where O : Node;

        public abstract Node? ReplaceChild(int index, Node replacement);

        /// <summary>
        /// Converts the AST node back into its exact string representation.
        /// </summary>
        /// <returns>The string representation for this node.</returns>
        public abstract override string ToString();

        /// <summary>
        /// Renders the core content of the node without its own leading/trailing whitespace.
        /// </summary>
        /// <returns>The raw string representation of this node's specific content.</returns>
        public abstract string ToRawString();
    }
}
