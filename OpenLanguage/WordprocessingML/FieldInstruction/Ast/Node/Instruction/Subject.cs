using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed SUBJECT field instruction.
    /// Retrieves, and optionally sets, the document's subject, as recorded in the <Subject> element of the Core File Properties part or, if field-argument is present, the subject specified by text in field-argument. Specifying a field-argument shall change <Subject> to text.
    /// </summary>
    public class SubjectFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Optional field argument that specifies the text to set as the document's subject.
        /// If present, this will change the document's Subject property to this value.
        /// </summary>
        public ExpressionNode? SubjectText { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public SubjectFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? subjectText = null,
            FlaggedArgument<ExpressionNode>? generalFormat = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            SubjectText = subjectText;
            GeneralFormat = generalFormat;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + (SubjectText?.ToString() ?? string.Empty)
            + (GeneralFormat?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }
            if (SubjectText is O oSubjectText)
            {
                yield return oSubjectText;
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
            if (index == 0 && replacement is StringLiteralNode str)
            {
                current = Instruction;
                Instruction = str;
            }
            else if (index == 1 && replacement is ExpressionNode expr)
            {
                current = SubjectText;
                SubjectText = expr;
            }
            else if (index == 2 && replacement is FlaggedArgument<ExpressionNode> gen)
            {
                current = GeneralFormat;
                GeneralFormat = gen;
            }
            return current;
        }
    }
}
