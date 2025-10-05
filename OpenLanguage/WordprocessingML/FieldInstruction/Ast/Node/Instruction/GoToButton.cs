using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    /// <summary>
    /// Represents the type of location target for a GOTOBUTTON field.
    /// </summary>
    public enum GoToButtonTargetType
    {
        /// <summary>
        /// A bookmark name.
        /// </summary>
        Bookmark,

        /// <summary>
        /// An annotation (A n).
        /// </summary>
        Annotation,

        /// <summary>
        /// A footnote (F n).
        /// </summary>
        Footnote,

        /// <summary>
        /// A line (L n).
        /// </summary>
        Line,

        /// <summary>
        /// A page (P n).
        /// </summary>
        Page,

        /// <summary>
        /// A section (S n).
        /// </summary>
        Section,
    }

    public enum GoToButtonArgument
    {
        TargetLocation,
        ButtonDisplayContent,
    }

    /// <summary>
    /// Represents a strongly-typed GOTOBUTTON field instruction.
    /// Inserts a jump command that moves the insertion point to a specified location when activated.
    /// </summary>
    public class GoToButtonFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The location to jump to (field-argument-1, required).
        /// </summary>
        public ExpressionNode? TargetLocation { get; set; }

        /// <summary>
        /// The text or graphic "button" that appears in the document (field-argument-2, required).
        /// </summary>
        public ExpressionNode? ButtonDisplayContent { get; set; }

        public List<GoToButtonArgument> Order { get; set; } = new List<GoToButtonArgument>();

        public GoToButtonFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? targetLocation,
            ExpressionNode? buttonDisplayContent,
            List<GoToButtonArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            TargetLocation = targetLocation;
            ButtonDisplayContent = buttonDisplayContent;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        GoToButtonArgument.TargetLocation => TargetLocation?.ToString()
                            ?? string.Empty,
                        GoToButtonArgument.ButtonDisplayContent => ButtonDisplayContent?.ToString()
                            ?? string.Empty,
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
            if (TargetLocation is O o1)
            {
                yield return o1;
            }
            if (ButtonDisplayContent is O o2)
            {
                yield return o2;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            switch (index)
            {
                case 0:
                    if (replacement is StringLiteralNode strRep)
                    {
                        current = Instruction;
                        Instruction = strRep;
                    }
                    break;
                case 1:
                    if (replacement is ExpressionNode expr)
                    {
                        current = TargetLocation;
                        TargetLocation = expr;
                    }
                    break;
                case 2:

                    if (replacement is ExpressionNode expr2)
                    {
                        current = ButtonDisplayContent;
                        ButtonDisplayContent = expr2;
                    }
                    break;
                default:
                    break;
            }
            return current;
        }
    }
}
