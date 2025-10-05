using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum IncludePictureArgument
    {
        PictureFilePath,
        GraphicsFilterName,
        ReduceFileSize,
    }

    /// <summary>
    /// Represents a strongly-typed INCLUDEPICTURE field instruction.
    /// Retrieves the picture contained in the document named by field-argument. If field-argument contains white space, it shall be enclosed in double quotes. If field-argument contains any backslash characters, each one shall be preceded directly by another backslash character.
    /// </summary>
    public class IncludePictureFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The path to the picture file (field-argument, required).
        /// </summary>
        public ExpressionNode? PictureFilePath { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Identifies the graphics filter to be used.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GraphicsFilterName { get; set; }

        /// <summary>
        /// Switch: \d
        /// Reduces the file size by not storing graphics data with the document.
        /// </summary>
        public BoolFlagNode? ReduceFileSize { get; set; }

        public List<IncludePictureArgument> Order { get; set; } =
            new List<IncludePictureArgument>();

        public IncludePictureFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? pictureFilePath,
            FlaggedArgument<ExpressionNode>? graphicsFilterName,
            BoolFlagNode? reduceFileSize,
            List<IncludePictureArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            PictureFilePath = pictureFilePath;
            GraphicsFilterName = graphicsFilterName;
            ReduceFileSize = reduceFileSize;
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
                        IncludePictureArgument.PictureFilePath => PictureFilePath?.ToString()
                            ?? string.Empty,
                        IncludePictureArgument.GraphicsFilterName => GraphicsFilterName?.ToString()
                            ?? string.Empty,
                        IncludePictureArgument.ReduceFileSize => ReduceFileSize?.ToString()
                            ?? string.Empty,
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
            foreach (IncludePictureArgument arg in Order)
            {
                switch (arg)
                {
                    case IncludePictureArgument.PictureFilePath:
                        if (PictureFilePath is O oPictureFilePath)
                        {
                            yield return oPictureFilePath;
                        }
                        break;
                    case IncludePictureArgument.GraphicsFilterName:
                        if (GraphicsFilterName is O oGraphicsFilterName)
                        {
                            yield return oGraphicsFilterName;
                        }
                        break;
                    case IncludePictureArgument.ReduceFileSize:
                        if (ReduceFileSize is O oReduceFileSize)
                        {
                            yield return oReduceFileSize;
                        }
                        break;
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
                    IncludePictureArgument arg = Order[index];
                    switch (arg)
                    {
                        case IncludePictureArgument.PictureFilePath:
                            if (replacement is ExpressionNode pictureFilePath)
                            {
                                current = PictureFilePath;
                                PictureFilePath = pictureFilePath;
                            }
                            break;
                        case IncludePictureArgument.GraphicsFilterName:
                            if (replacement is FlaggedArgument<ExpressionNode> graphicsFilterName)
                            {
                                current = GraphicsFilterName;
                                GraphicsFilterName = graphicsFilterName;
                            }
                            break;
                        case IncludePictureArgument.ReduceFileSize:
                            if (replacement is BoolFlagNode reduceFileSize)
                            {
                                current = ReduceFileSize;
                                ReduceFileSize = reduceFileSize;
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
