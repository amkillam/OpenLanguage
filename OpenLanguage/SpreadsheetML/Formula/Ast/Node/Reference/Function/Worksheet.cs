using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class FilterWorksheetFunctionNode : BuiltInWorksheetFunctionNode
    {
        public FilterWorksheetFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILTER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SortWorksheetFunctionNode : BuiltInWorksheetFunctionNode
    {
        public SortWorksheetFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SORT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PyWorksheetFunctionNode : BuiltInWorksheetFunctionNode
    {
        public PyWorksheetFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PY"), leadingWhitespace, trailingWhitespace) { }
    }
}
