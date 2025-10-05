using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum AutoTextListArgument
    {
        EntryName,
        StyleFilter,
        ScreenTip,
    }

    //  { AUTOTEXTLIST "Literal text" \s ["Style name"] \t ["Tip text"] }
    //  ## Example
    //
    //  Example
    //
    //  If you have created AutoText entries that have the Salutation style applied to them, you can add the following AutoTextList field code:
    //
    //  { AUTOTEXTLIST "List of salutations" \s Salutation \t "Choose a salutation" } displays the following:
    //
    //  - In the document: Salutation list
    //  - In the ScreenTip: Choose a salutation
    //  - On the shortcut menu: the list of AutoText entries whose style is Salutation.
    public class AutoTextListFieldInstruction : FieldInstruction
    {
        // "Literal text"
        // Text that displays in the document before the user displays the shortcut menu. If the text contains spaces, enclose it in quotation marks.
        public ExpressionNode? EntryName { get; set; }

        // \s ["Style name"]
        // "Style name"
        // The name of the style of the AutoText entries that you want to appear in the list. The style can be a paragraph style or a character style. If the style name contains spaces, enclose it in quotation marks.
        public FlaggedArgument<ExpressionNode>? StyleFilter { get; set; }

        // \t ["Tip text"]
        // "Tip text"
        // Text that displays in the ScreenTip when the mouse pointer hovers over the field result. Enclose the text in quotation marks.
        public FlaggedArgument<ExpressionNode>? ScreenTip { get; set; }
        public List<AutoTextListArgument> Order { get; set; } = new List<AutoTextListArgument>();

        public AutoTextListFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? entryName,
            FlaggedArgument<ExpressionNode>? styleFilter,
            FlaggedArgument<ExpressionNode>? screenTip,
            List<AutoTextListArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            EntryName = entryName;
            StyleFilter = styleFilter;
            ScreenTip = screenTip;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        AutoTextListArgument.EntryName => EntryName?.ToString() ?? string.Empty,
                        AutoTextListArgument.StyleFilter => StyleFilter?.ToString() ?? string.Empty,
                        AutoTextListArgument.ScreenTip => ScreenTip?.ToString() ?? string.Empty,
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

            foreach (AutoTextListArgument arg in Order)
            {
                Node? child = arg switch
                {
                    AutoTextListArgument.EntryName => EntryName,
                    AutoTextListArgument.StyleFilter => StyleFilter,
                    AutoTextListArgument.ScreenTip => ScreenTip,
                    _ => null,
                };

                if (child is O oChild)
                {
                    yield return oChild;
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
                AutoTextListArgument arg = Order[index];
                switch (arg)
                {
                    case AutoTextListArgument.EntryName:
                        if (replacement is ExpressionNode name)
                        {
                            current = EntryName;
                            EntryName = name;
                        }
                        break;
                    case AutoTextListArgument.StyleFilter:
                        if (replacement is FlaggedArgument<ExpressionNode> style)
                        {
                            current = StyleFilter;
                            StyleFilter = style;
                        }
                        break;
                    case AutoTextListArgument.ScreenTip:
                        if (replacement is FlaggedArgument<ExpressionNode> tip)
                        {
                            current = ScreenTip;
                            ScreenTip = tip;
                        }
                        break;
                }
            }

            return current;
        }
    }
}
