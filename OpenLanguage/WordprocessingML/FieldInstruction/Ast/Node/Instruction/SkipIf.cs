using System;
using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;
using OpenLanguage.WordprocessingML.Operators;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed SKIPIF field instruction.
    /// Evaluates the condition. If the condition is true, `SKIPIF` cancels the current merge document, moves to the next in the data source, and starts a new merge document. If the condition is false, the current merge document is continued. Operator can be any one of the six relational and equality operators specified for operator (§[2.16.3.3](https://c-rex.net/samples/ooxml/e1/Part4/OOXML_P4_DOCX_Operatorsfieldoperat_topic_ID0EUQXZ.html#topic_ID0EUQXZ)).
    /// </summary>
    public class SkipIfFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// The condition to evaluate.
        /// </summary>
        public ExpressionNode? Condition { get; set; }

        public SkipIfFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? condition,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Condition = condition;
        }

        /// <summary>
        ///
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString() + (Condition?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstr)
            {
                yield return oInstr;
            }
            if (Condition is O oCond)
            {
                yield return oCond;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode sln)
            {
                current = Instruction;
                Instruction = sln;
            }
            else if (index == 1 && replacement is ExpressionNode expr)
            {
                current = Condition;
                Condition = expr;
            }
            return current;
        }
    }
}
