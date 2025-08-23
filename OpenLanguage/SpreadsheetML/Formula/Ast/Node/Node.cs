using System;
using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    /// <summary>
    /// The base class for all nodes in the Abstract Syntax Tree (AST).
    /// </summary>
    public abstract class Node
    {
        public abstract IEnumerable<O> Children<O>()
            where O : Node;

        public abstract Node? ReplaceChild(Int32 index, Node replacement);

        /// <summary>
        /// Converts the AST node back into its exact string representation in a formula.
        /// </summary>
        /// <returns>The formula string for this node.</returns>
        public abstract override string ToString();
    }
}
