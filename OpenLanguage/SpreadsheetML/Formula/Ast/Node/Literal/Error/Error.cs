using System;
using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class ErrorNode : ExpressionNode
    {
        public string ErrorType { get; set; }
        public override int Precedence => Ast.Precedence.Primary;

        public ErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            ErrorType = errorType;
        }

        public override string ToRawString() => ErrorType;

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(Int32 index, Node replacement) => null;
    }

    public class DivZeroErrorNode : ErrorNode
    {
        public DivZeroErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class NAErrorNode : ErrorNode
    {
        public NAErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class NameErrorNode : ErrorNode
    {
        public NameErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class NullErrorNode : ErrorNode
    {
        public NullErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class NumErrorNode : ErrorNode
    {
        public NumErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class ValueErrorNode : ErrorNode
    {
        public ValueErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class GettingDataErrorNode : ErrorNode
    {
        public GettingDataErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class SpillErrorNode : ErrorNode
    {
        public SpillErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class CalcErrorNode : ErrorNode
    {
        public CalcErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class BlockedErrorNode : ErrorNode
    {
        public BlockedErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class BusyErrorNode : ErrorNode
    {
        public BusyErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class CircularErrorNode : ErrorNode
    {
        public CircularErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class ConnectErrorNode : ErrorNode
    {
        public ConnectErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class ExternalErrorNode : ErrorNode
    {
        public ExternalErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class FieldErrorNode : ErrorNode
    {
        public FieldErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonErrorNode : ErrorNode
    {
        public PythonErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }

    public class UnknownErrorNode : ErrorNode
    {
        public UnknownErrorNode(
            string errorType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(errorType, leadingWhitespace, trailingWhitespace) { }
    }
}
