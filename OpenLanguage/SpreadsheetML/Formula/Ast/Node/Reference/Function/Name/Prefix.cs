using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class PrefixNode : ExpressionNode
    {
        public string? RawPrefix { get; set; } = null;
        public ExpressionNode? Prefix { get; set; } = null;
        public override int Precedence => Ast.Precedence.Primary;

        public override string ToRawString() =>
            Prefix == null ? (RawPrefix ?? string.Empty) : Prefix.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Prefix is O o)
            {
                yield return o;
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is ExpressionNode expr)
            {
                current = Prefix;
                Prefix = expr;
                RawPrefix = null;
                return current;
            }
            return null;
        }

        public PrefixNode(
            ExpressionNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Prefix = prefix;
            RawPrefix = null;
        }

        public PrefixNode(
            string? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            RawPrefix = prefix;
            Prefix = null;
        }
    }

    public abstract class FunctionPrefixNode : PrefixNode
    {
        protected FunctionPrefixNode(
            ExpressionNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(prefix, leadingWhitespace, trailingWhitespace) { }

        protected FunctionPrefixNode(
            string? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(prefix, leadingWhitespace, trailingWhitespace) { }
    }

    /// <summary>
    /// Represents the "_xlfn." prefix for Excel Function Name resolution.
    /// string? representation: "_xlfn."
    /// Used for new Excel functions that may not be recognized by older Excel versions.
    /// This prefix indicates that the function name should be resolved at runtime by the Excel engine.
    /// </summary>
    public class XlfnFunctionPrefixNode : FunctionPrefixNode
    {
        public XlfnFunctionPrefixNode(
            NameNode? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

        public XlfnFunctionPrefixNode(
            string? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    /// <summary>
    /// Represents the "_xll." prefix for Excel Library functions.
    /// string? representation: "_xll."
    /// Used for functions provided by Excel add-in libraries (XLL files).
    /// These functions extend Excel's capabilities through custom libraries and external add-ins.
    /// </summary>
    public class XllFunctionPrefixNode : FunctionPrefixNode
    {
        public XllFunctionPrefixNode(
            NameNode? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

        public XllFunctionPrefixNode(
            string? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    /// <summary>
    /// Represents the "_xlpm." prefix for LAMBDA/LET parameter names.
    /// string? representation: "_xlpm."
    /// Used internally in Excel for lambda and let function parameters.
    /// </summary>
    public class XlpmFunctionPrefixNode : FunctionPrefixNode
    {
        public XlpmFunctionPrefixNode(
            NameNode? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

        public XlpmFunctionPrefixNode(
            string? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    /// <summary>
    /// Represents the "_xlws." prefix for Excel Worksheet functions.
    /// string? representation: "_xlws."
    /// Used for worksheet-specific functions and operations in Excel.
    /// These functions provide worksheet manipulation, cell operations, and sheet-level functionality.
    /// </summary>
    public class XlwsFunctionPrefixNode : FunctionPrefixNode
    {
        public XlwsFunctionPrefixNode(
            NameNode? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

        public XlwsFunctionPrefixNode(
            string? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    /// <summary>
    /// Represents the "_xlnm." prefix for Excel built-in defined names.
    /// string? representation: "_xlnm."
    /// Used for internal named ranges and built-in names like Print_Area.
    /// </summary>
    public class XlnmFunctionPrefixNode : FunctionPrefixNode
    {
        public XlnmFunctionPrefixNode(
            NameNode? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

        public XlnmFunctionPrefixNode(
            string? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    /// <summary>
    /// Represents the "_xlbgnm." prefix for Big Grid Name compatibility.
    /// string? representation: "_xlbgnm."
    /// Used when old defined names conflict with new cell references in extended column ranges.
    /// </summary>
    public class XlbgnmFunctionPrefixNode : FunctionPrefixNode
    {
        public XlbgnmFunctionPrefixNode(
            NameNode? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

        public XlbgnmFunctionPrefixNode(
            string? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    /// <summary>
    /// Represents the "_xlop." prefix for LAMBDA optional parameters.
    /// string? representation: "_xlop."
    /// Used internally by Excel to identify optional arguments in LAMBDA.
    /// This prefix node derives directly from PrefixNode (not FunctionPrefixNode).
    /// </summary>
    public class XlopPrefixNode : PrefixNode
    {
        public XlopPrefixNode(
            NameNode? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }

        public XlopPrefixNode(
            string? name = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }
}
