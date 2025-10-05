using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents a strongly-typed FILENAME field instruction.
    /// Retrieves the name of the current document as stored on disk.
    /// </summary>
    public class FileNameFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Switch: \p
        /// Include the full file path name.
        /// </summary>
        public BoolFlagNode? IncludeFullPath { get; set; }

        /// <summary>
        /// Switch: \*
        /// General formatting switch for the field value.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public FileNameFieldInstruction(
            StringLiteralNode instruction,
            BoolFlagNode? includeFullPath = null,
            FlaggedArgument<ExpressionNode>? generalFormat = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            IncludeFullPath = includeFullPath;
            GeneralFormat = generalFormat;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + (IncludeFullPath?.ToString() ?? string.Empty)
            + (GeneralFormat?.ToString() ?? string.Empty);

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }
            if (IncludeFullPath is O oIncludeFullPath)
            {
                yield return oIncludeFullPath;
            }
            if (GeneralFormat is O oGen)
            {
                yield return oGen;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (replacement is StringLiteralNode strRep && index == 0)
            {
                current = Instruction;
                Instruction = strRep;
            }
            else if (replacement is BoolFlagNode boolRep && index == 1)
            {
                current = IncludeFullPath;
                IncludeFullPath = boolRep;
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
