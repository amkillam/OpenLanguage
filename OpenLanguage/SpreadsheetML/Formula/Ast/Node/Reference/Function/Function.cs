using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class FunctionCallNode : ExpressionNode
    {
        public ExpressionNode FunctionIdentifier { get; set; }
        public List<Node> WsAfterIdentifier { get; set; }
        public List<Node> WsAfterOpenParen { get; set; }
        public List<ExpressionNode> Arguments { get; }
        public List<Node> WsBeforeCloseParen { get; set; }
        public List<List<Node>> WsBeforeCommas { get; set; }
        public List<List<Node>> WsAfterCommas { get; set; }

        public override int Precedence => Ast.Precedence.Primary;

        public FunctionCallNode(
            ExpressionNode functionIdentifier,
            List<Node>? wsAfterIdentifier,
            List<Node>? wsAfterOpenParen,
            List<ExpressionNode> arguments,
            List<List<Node>>? wsBeforeCommas,
            List<List<Node>>? wsAfterCommas,
            List<Node>? wsBeforeCloseParen,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            FunctionIdentifier = functionIdentifier;
            WsAfterIdentifier = wsAfterIdentifier ?? new List<Node>();
            WsAfterOpenParen = wsAfterOpenParen ?? new List<Node>();
            Arguments = arguments;
            WsBeforeCommas = wsBeforeCommas ?? new List<List<Node>>();
            WsAfterCommas = wsAfterCommas ?? new List<List<Node>>();
            WsBeforeCloseParen = wsBeforeCloseParen ?? new List<Node>();
        }

        // Back-compat constructors for generated parser calls that don't provide per-comma whitespace
        public FunctionCallNode(
            ExpressionNode functionIdentifier,
            List<Node>? wsAfterIdentifier,
            List<Node>? wsAfterOpenParen,
            List<ExpressionNode> arguments,
            List<Node>? wsBeforeCloseParen
        )
            : this(
                functionIdentifier,
                wsAfterIdentifier,
                wsAfterOpenParen,
                arguments,
                null,
                null,
                wsBeforeCloseParen,
                null,
                null
            ) { }

        public FunctionCallNode(
            ExpressionNode functionIdentifier,
            List<Node>? wsAfterIdentifier,
            List<Node>? wsAfterOpenParen,
            List<ExpressionNode> arguments,
            List<Node>? wsBeforeCloseParen,
            List<Node>? leadingWhitespace,
            List<Node>? trailingWhitespace
        )
            : this(
                functionIdentifier,
                wsAfterIdentifier,
                wsAfterOpenParen,
                arguments,
                null,
                null,
                wsBeforeCloseParen,
                leadingWhitespace,
                trailingWhitespace
            ) { }

        public override string ToRawString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(FunctionIdentifier.ToString());
            builder.Append(string.Concat(WsAfterIdentifier.Select(w => w.ToString())));
            builder.Append('(');
            builder.Append(string.Concat(WsAfterOpenParen.Select(w => w.ToString())));

            for (int i = 0; i < Arguments.Count; i++)
            {
                builder.Append(Arguments[i].ToString());
                if (i < Arguments.Count - 1)
                {
                    // If the caller provided explicit whitespace that should appear
                    // before the comma, render it. (Rare; preserve existing behavior.)
                    if (
                        i < WsBeforeCommas.Count
                        && WsBeforeCommas[i] != null
                        && WsBeforeCommas[i].Count > 0
                    )
                    {
                        builder.Append(string.Concat(WsBeforeCommas[i].Select(w => w.ToString())));
                    }

                    // Always emit the comma
                    builder.Append(',');

                    // Prefer explicit whitespace after the comma when available;
                    // otherwise, normalize to a single space for human-friendly formatting
                    // (many tests expect a space after commas).
                    if (
                        i < WsAfterCommas.Count
                        && WsAfterCommas[i] != null
                        && WsAfterCommas[i].Count > 0
                    )
                    {
                        builder.Append(string.Concat(WsAfterCommas[i].Select(w => w.ToString())));
                    }
                    else
                    {
                        builder.Append(' ');
                    }
                }
            }

            builder.Append(string.Concat(WsBeforeCloseParen.Select(w => w.ToString())));
            builder.Append(')');
            return builder.ToString();
        }

        public override IEnumerable<O> Children<O>()
        {
            if (FunctionIdentifier is O funcImp)
            {
                yield return funcImp;
            }
            foreach (ExpressionNode child in Arguments)
            {
                if (child is O childImp)
                {
                    yield return childImp;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    ExpressionNode currentIdent = FunctionIdentifier;
                    FunctionIdentifier = expr;
                    return currentIdent;
                }

                int argIdx = index - 1;
                if (argIdx < Arguments.Count)
                {
                    ExpressionNode currentArgNode = Arguments[argIdx];
                    Arguments[argIdx] = expr;
                    return currentArgNode;
                }
            }
            return null;
        }
    }
}
