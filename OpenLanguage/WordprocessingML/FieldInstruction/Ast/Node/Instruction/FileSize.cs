using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum FileSizeArgument
    {
        InKilobytes,
        InMegabytes,
        GeneralFormat,
        NumericFormat,
    }

    /// <summary>
    /// Represents a strongly-typed FILESIZE field instruction.
    /// Retrieves the size of the current document in bytes. ##### Note This information is not stored inside the document's XML. It needs to be obtained from the file system.
    /// </summary>
    public class FileSizeFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// Switch: \k
        /// Display in kilobytes
        /// </summary>
        public BoolFlagNode? InKilobytes { get; set; }

        /// <summary>
        /// Switch: \m
        /// Display in megabytes
        /// </summary>
        public BoolFlagNode? InMegabytes { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }

        public List<FileSizeArgument> Order { get; set; } = new List<FileSizeArgument>();

        public FileSizeFieldInstruction(
            StringLiteralNode instruction,
            BoolFlagNode? inKilobytes,
            BoolFlagNode? inMegabytes,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            List<FileSizeArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            InKilobytes = inKilobytes;
            InMegabytes = inMegabytes;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString()
        {
            return Instruction.ToString()
                + string.Concat(
                    Order.Select(a =>
                        a switch
                        {
                            FileSizeArgument.InKilobytes => InKilobytes?.ToString() ?? string.Empty,
                            FileSizeArgument.InMegabytes => InMegabytes?.ToString() ?? string.Empty,
                            FileSizeArgument.GeneralFormat => GeneralFormat?.ToString()
                                ?? string.Empty,
                            FileSizeArgument.NumericFormat => NumericFormat?.ToString()
                                ?? string.Empty,
                            _ => string.Empty,
                        }
                    )
                );
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            foreach (FileSizeArgument arg in Order)
            {
                Node? child = arg switch
                {
                    FileSizeArgument.InKilobytes => InKilobytes,
                    FileSizeArgument.InMegabytes => InMegabytes,
                    FileSizeArgument.GeneralFormat => GeneralFormat,
                    FileSizeArgument.NumericFormat => NumericFormat,
                    _ => null,
                };

                if (child is O oChild)
                {
                    yield return oChild;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0)
            {
                if (replacement is StringLiteralNode instruction)
                {
                    current = Instruction;
                    Instruction = instruction;
                }
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    FileSizeArgument arg = Order[index];
                    switch (arg)
                    {
                        case FileSizeArgument.InKilobytes:
                            if (replacement is BoolFlagNode inKilobytes)
                            {
                                current = InKilobytes;
                                InKilobytes = inKilobytes;
                            }
                            break;
                        case FileSizeArgument.InMegabytes:
                            if (replacement is BoolFlagNode inMegabytes)
                            {
                                current = InMegabytes;
                                InMegabytes = inMegabytes;
                            }
                            break;
                        case FileSizeArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> generalFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = generalFormat;
                            }
                            break;
                        case FileSizeArgument.NumericFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> numericFormat)
                            {
                                current = NumericFormat;
                                NumericFormat = numericFormat;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return current;
        }
    }
}
