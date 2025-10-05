using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum TemplateArgument
    {
        IncludeFullPath,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed TEMPLATE field instruction.
    /// Retrieves the disk file name of the template used by the current document.
    /// </summary>
    public class TemplateFieldInstruction : Ast.FieldInstruction
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

        public List<TemplateArgument> Order { get; set; } = new List<TemplateArgument>();

        public TemplateFieldInstruction(
            StringLiteralNode instruction,
            BoolFlagNode? includeFullPath,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<TemplateArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            IncludeFullPath = includeFullPath;
            GeneralFormat = generalFormat;
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
                        TemplateArgument.IncludeFullPath => IncludeFullPath?.ToString()
                            ?? string.Empty,
                        TemplateArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
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

            foreach (TemplateArgument arg in Order)
            {
                Node? child = arg switch
                {
                    TemplateArgument.IncludeFullPath => IncludeFullPath,
                    TemplateArgument.GeneralFormat => GeneralFormat,
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

            if (index == 0 && replacement is StringLiteralNode strLiteral)
            {
                current = Instruction;
                Instruction = strLiteral;
                return current;
            }

            index--;
            if (index >= 0 && index < Order.Count)
            {
                TemplateArgument arg = Order[index];
                switch (arg)
                {
                    case TemplateArgument.IncludeFullPath:
                        if (replacement is BoolFlagNode path)
                        {
                            current = IncludeFullPath;
                            IncludeFullPath = path;
                        }
                        break;
                    case TemplateArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> format)
                        {
                            current = GeneralFormat;
                            GeneralFormat = format;
                        }
                        break;
                }
            }

            return current;
        }
    }
}
