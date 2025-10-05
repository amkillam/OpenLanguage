using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum RdArgument
    {
        FilePath,
        IsRelativePath,
    }

    /// <summary>
    /// Represents a strongly-typed RD field instruction.
    /// field-argument identifies a file to include when creating a table of contents, a table of authorities, or an index using a `TOC`, `TOA`, or `INDEX` field. `RD` fields that reference a series of files must be in the same order as the files in the final document. If the location includes a long file name containing spaces, field-argument shall contain delimiting quotes. A single backslash in the file path shall be preceded directly by a backslash. For a complex field implementation in XML the optional field-value storage is not needed.
    /// </summary>
    public class RdFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The path to the referenced document file.
        /// </summary>
        public ExpressionNode FilePath { get; set; } = new StringLiteralNode(string.Empty);

        /// <summary>
        /// Switch: \f
        /// Indicates that the path is relative to the current document.
        /// </summary>
        public BoolFlagNode? IsRelativePath { get; set; }

        public List<RdArgument> Order { get; set; } = new List<RdArgument>();

        public RdFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode filePath,
            BoolFlagNode? isRelativePath,
            List<RdArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            FilePath = filePath;
            IsRelativePath = isRelativePath;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        RdArgument.FilePath => FilePath.ToString(),
                        RdArgument.IsRelativePath => IsRelativePath?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            foreach (RdArgument arg in Order)
            {
                switch (arg)
                {
                    case RdArgument.FilePath:
                        if (FilePath is O oFilePath)
                        {
                            yield return oFilePath;
                        }
                        break;
                    case RdArgument.IsRelativePath:
                        if (IsRelativePath is O oIsRelativePath)
                        {
                            yield return oIsRelativePath;
                        }
                        break;
                }
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0 && replacement is StringLiteralNode instruction)
            {
                current = Instruction;
                Instruction = instruction;
            }
            else
            {
                index--;
                if (index > -1 && index < Order.Count)
                {
                    RdArgument arg = Order[index];

                    switch (arg)
                    {
                        case RdArgument.FilePath:
                            if (replacement is ExpressionNode filePath)
                            {
                                current = FilePath;
                                FilePath = filePath;
                            }
                            break;
                        case RdArgument.IsRelativePath:
                            if (replacement is BoolFlagNode isRelativePath)
                            {
                                current = IsRelativePath;
                                IsRelativePath = isRelativePath;
                            }
                            break;
                    }
                }
            }

            return current;
        }
    }
}
