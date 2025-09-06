using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class FilterWorksheetFunctionNode : BuiltInWorksheetFunctionNode
    {
        public FilterWorksheetFunctionNode(
            NameNode? xlfnPrefix = null,
            NameNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new BuiltInFunctionNode(new NameNode("FILTER")),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class SortWorksheetFunctionNode : BuiltInWorksheetFunctionNode
    {
        public SortWorksheetFunctionNode(
            NameNode? xlfnPrefix = null,
            NameNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new BuiltInFunctionNode(new NameNode("SORT")),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PyWorksheetFunctionNode : BuiltInWorksheetFunctionNode
    {
        public PyWorksheetFunctionNode(
            NameNode? xlfnPrefix = null,
            NameNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new BuiltInFunctionNode(new NameNode("PY")),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }
}
