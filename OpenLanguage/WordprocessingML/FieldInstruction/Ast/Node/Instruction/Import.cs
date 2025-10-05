using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum ImportArgument
    {
        PictureFilePath,
        GraphicsFilterName,
        ReduceFileSize,
        GeneralFormat,
    }

    /// <summary>
    /// Retrieves the picture contained in the document named by field-argument.
    /// </summary>
    public class ImportInstruction : FieldInstruction
    {
        /// <summary>
        /// The path to the picture file.
        /// </summary>
        public ExpressionNode? PictureFilePath { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// The graphics filter to be used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GraphicsFilterName { get; set; }

        /// <summary>
        /// Switch: \d
        /// Reduce the file size by not storing graphics data with the document.
        /// </summary>
        public BoolFlagNode? ReduceFileSize { get; set; }

        /// <summary>
        /// Switch: \*
        /// General formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public List<ImportArgument> Order { get; set; } = new List<ImportArgument>();

        public ImportInstruction(
            StringLiteralNode instruction,
            ExpressionNode? pictureFilePath,
            FlaggedArgument<ExpressionNode>? graphicsFilterName,
            BoolFlagNode? reduceFileSize,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<ImportArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            PictureFilePath = pictureFilePath;
            GraphicsFilterName = graphicsFilterName;
            ReduceFileSize = reduceFileSize;
            GeneralFormat = generalFormat;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(
                    (ImportArgument a) =>
                        a switch
                        {
                            ImportArgument.PictureFilePath => PictureFilePath?.ToString()
                                ?? string.Empty,
                            ImportArgument.GraphicsFilterName => GraphicsFilterName?.ToString()
                                ?? string.Empty,
                            ImportArgument.ReduceFileSize => ReduceFileSize?.ToString()
                                ?? string.Empty,
                            ImportArgument.GeneralFormat => GeneralFormat?.ToString()
                                ?? string.Empty,
                            _ => string.Empty,
                        }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o1)
            {
                yield return o1;
            }
            foreach (ImportArgument arg in Order)
            {
                Node? node = arg switch
                {
                    ImportArgument.PictureFilePath => PictureFilePath,
                    ImportArgument.GraphicsFilterName => GraphicsFilterName,
                    ImportArgument.ReduceFileSize => ReduceFileSize,
                    ImportArgument.GeneralFormat => GeneralFormat,
                    _ => null,
                };

                if (node is O o)
                {
                    yield return o;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    ImportArgument arg = Order[index];
                    switch (arg)
                    {
                        case ImportArgument.PictureFilePath:
                            if (replacement is ExpressionNode sln1)
                            {
                                current = PictureFilePath;
                                PictureFilePath = sln1;
                            }
                            break;
                        case ImportArgument.GraphicsFilterName:
                            if (replacement is FlaggedArgument<ExpressionNode> fa1)
                            {
                                current = GraphicsFilterName;
                                GraphicsFilterName = fa1;
                            }
                            break;
                        case ImportArgument.ReduceFileSize:
                            if (replacement is BoolFlagNode bfn)
                            {
                                current = ReduceFileSize;
                                ReduceFileSize = bfn;
                            }
                            break;
                        case ImportArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> gf)
                            {
                                current = GeneralFormat;
                                GeneralFormat = gf;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}
