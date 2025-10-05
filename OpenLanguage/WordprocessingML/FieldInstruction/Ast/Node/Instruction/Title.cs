using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed TITLE field instruction.
    /// Retrieves, and optionally sets, the document's title, as recorded in the <Title> element of the Core File Properties part or, if field-argument is present, the name specified by text in field-argument. Specifying a field-argument shall change <Title> to text.
    /// </summary>
    public class TitleFieldInstruction : FieldInstruction
    {
        public ExpressionNode? NewTitle { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public TitleFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? newTitle = null,
            FlaggedArgument<ExpressionNode>? generalFormat = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            NewTitle = newTitle;
            GeneralFormat = generalFormat;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString()
        {
            return Instruction.ToString()
                + (NewTitle?.ToString() ?? string.Empty)
                + (GeneralFormat?.ToString() ?? string.Empty);
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }
            if (NewTitle is O oNewTitle)
            {
                yield return oNewTitle;
            }
            if (GeneralFormat is O oGeneralFormat)
            {
                yield return oGeneralFormat;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            switch (index)
            {
                case 0:
                {
                    if (replacement is StringLiteralNode strRepNode)
                    {
                        current = Instruction;
                        Instruction = strRepNode;
                    }
                    break;
                }
                case 1:
                {
                    if (replacement is ExpressionNode exprNode)
                    {
                        current = NewTitle;
                        NewTitle = exprNode;
                    }
                    break;
                }
                case 2:
                {
                    if (replacement is FlaggedArgument<ExpressionNode> gen)
                    {
                        current = GeneralFormat;
                        GeneralFormat = gen;
                    }
                    break;
                }
            }

            return current;
        }
    }
}
