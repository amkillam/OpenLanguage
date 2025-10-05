using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public class AskFieldInstruction : Ast.FieldInstruction
    {
        public enum AskArgument
        {
            BookmarkName,
            PromptText,
            DefaultText,
            PromptOnce,
        }

        public ExpressionNode? BookmarkName { get; set; }
        public ExpressionNode? PromptText { get; set; }
        public FlaggedArgument<ExpressionNode>? DefaultText { get; set; }
        public BoolFlagNode? PromptOnce { get; set; }
        public List<AskArgument> Order { get; set; } = new List<AskArgument>();

        public AskFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? bookmarkName,
            ExpressionNode? promptText,
            FlaggedArgument<ExpressionNode>? defaultText,
            BoolFlagNode? promptOnce,
            List<AskArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            BookmarkName = bookmarkName;
            PromptText = promptText;
            DefaultText = defaultText;
            PromptOnce = promptOnce;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        AskArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        AskArgument.PromptText => PromptText?.ToString() ?? string.Empty,
                        AskArgument.DefaultText => DefaultText?.ToString() ?? string.Empty,
                        AskArgument.PromptOnce => PromptOnce?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstr)
            {
                yield return oInstr;
            }
            foreach (AskArgument a in Order)
            {
                Node? n = a switch
                {
                    AskArgument.BookmarkName => BookmarkName,
                    AskArgument.PromptText => PromptText,
                    AskArgument.DefaultText => DefaultText,
                    AskArgument.PromptOnce => PromptOnce,
                    _ => null,
                };
                if (n is O oNode)
                {
                    yield return oNode;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode instr)
            {
                current = Instruction;
                Instruction = instr;
                return current;
            }
            index--;
            if (index >= 0 && index < Order.Count)
            {
                AskArgument arg = Order[index];
                switch (arg)
                {
                    case AskArgument.BookmarkName:
                        if (replacement is ExpressionNode bn)
                        {
                            current = BookmarkName;
                            BookmarkName = bn;
                        }
                        break;
                    case AskArgument.PromptText:
                        if (replacement is ExpressionNode pt)
                        {
                            current = PromptText;
                            PromptText = pt;
                        }
                        break;
                    case AskArgument.DefaultText:
                        if (replacement is FlaggedArgument<ExpressionNode> dt)
                        {
                            current = DefaultText;
                            DefaultText = dt;
                        }
                        break;
                    case AskArgument.PromptOnce:
                        if (replacement is BoolFlagNode po)
                        {
                            current = PromptOnce;
                            PromptOnce = po;
                        }
                        break;
                }
            }
            return current;
        }
    }
}
