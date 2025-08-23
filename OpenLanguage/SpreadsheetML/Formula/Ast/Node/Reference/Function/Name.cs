using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class UserDefinedFunctionNode : NameNode
    {
        public UserDefinedFunctionNode(
            string name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInFunctionNode : NameNode
    {
        public BuiltInFunctionNode(
            string name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInStandardFunctionNode : BuiltInFunctionNode
    {
        public BuiltInStandardFunctionNode(
            string name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInFutureFunctionNode : BuiltInFunctionNode
    {
        public BuiltInFutureFunctionNode(
            string name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInMacroFunctionNode : BuiltInFunctionNode
    {
        public BuiltInMacroFunctionNode(
            string name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace) { }
    }

    public class BuiltInCommandFunctionNode : BuiltInFunctionNode
    {
        QuestionMarkNode QuestionMark { get; set; }

        public BuiltInCommandFunctionNode(
            string name,
            QuestionMarkNode qMarkNode,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(name, leadingWhitespace, trailingWhitespace)
        {
            QuestionMark = qMarkNode;
        }

        public override string ToRawString() => base.ToRawString() + QuestionMark.ToString();
    }

    public class BuiltInWorksheetFunctionNode : BuiltInFunctionNode
    {
        public string Prefix { get; set; }
        public List<Node> WsAfterPrefix { get; set; }
        public string FunctionName { get; set; }

        public BuiltInWorksheetFunctionNode(
            string prefix,
            List<Node> wsAfterPrefix,
            string functionName,
            List<Node>? leadingWs = null,
            List<Node>? trailingWs = null
        )
            : base(
                prefix + string.Concat(wsAfterPrefix.Select(w => w.ToString())) + functionName,
                leadingWs,
                trailingWs
            )
        {
            Prefix = prefix;
            WsAfterPrefix = wsAfterPrefix;
            FunctionName = functionName;
        }

        public override string ToRawString()
        {
            return Prefix + string.Concat(WsAfterPrefix.Select(w => w.ToString())) + FunctionName;
        }
    }
}
