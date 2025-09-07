using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class FilterWorksheetFunctionNode : BuiltInWorksheetFunctionNode
    {
        public FilterWorksheetFunctionNode(
            XlfnFunctionPrefixNode? xlfnPrefix = null,
            XlwsFunctionPrefixNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FILTER"),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SortWorksheetFunctionNode : BuiltInWorksheetFunctionNode
    {
        public SortWorksheetFunctionNode(
            XlfnFunctionPrefixNode? xlfnPrefix = null,
            XlwsFunctionPrefixNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SORT"),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PyFunctionNode : BuiltInWorksheetFunctionNode
    {
        public PyFunctionNode(
            XlfnFunctionPrefixNode? xlfnPrefix = null,
            XlwsFunctionPrefixNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PY"),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }
}
