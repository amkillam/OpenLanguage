using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class FilterWorksheetFunctionNode : WorksheetFunctionNode
    {
        public FilterWorksheetFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? xlfnPrefix = null,
            XlwsFunctionPrefixNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FILTER"),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SortWorksheetFunctionNode : WorksheetFunctionNode
    {
        public SortWorksheetFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? xlfnPrefix = null,
            XlwsFunctionPrefixNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SORT"),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PyFunctionNode : WorksheetFunctionNode
    {
        public PyFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? xlfnPrefix = null,
            XlwsFunctionPrefixNode? xlwsPrefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PY"),
                xlfnPrefix,
                xlwsPrefix,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }
}
