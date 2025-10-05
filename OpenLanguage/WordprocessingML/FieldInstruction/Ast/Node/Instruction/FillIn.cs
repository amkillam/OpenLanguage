using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum FillInArgument
    {
        PromptText,
        DefaultText,
        PromptOnce,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed FILLIN field instruction.
    /// Prompts the user to enter text. text in field-argument contains the prompt. The prompt is displayed each time the field is updated. When a new document is created based on a template containing `FILLIN` fields, those fields are updated automatically.
    /// </summary>
    public class FillInFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// The prompt text to display to the user
        /// </summary>
        public ExpressionNode? PromptText { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Default text
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DefaultText { get; set; }

        /// <summary>
        /// Switch: \o
        /// Prompt only once per mail merge
        /// </summary>
        public BoolFlagNode? PromptOnce { get; set; }

        /// <summary>
        /// General formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public List<FillInArgument> Order { get; set; } = new List<FillInArgument>();

        public FillInFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? promptText,
            FlaggedArgument<ExpressionNode>? defaultText,
            BoolFlagNode? promptOnce,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<FillInArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            PromptText = promptText;
            DefaultText = defaultText;
            PromptOnce = promptOnce;
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
                        FillInArgument.PromptText => PromptText?.ToString() ?? string.Empty,
                        FillInArgument.DefaultText => DefaultText?.ToString() ?? string.Empty,
                        FillInArgument.PromptOnce => PromptOnce?.ToString() ?? string.Empty,
                        FillInArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
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

            foreach (FillInArgument arg in Order)
            {
                switch (arg)
                {
                    case FillInArgument.PromptText:
                        if (PromptText is O oPromptText)
                        {
                            yield return oPromptText;
                        }
                        break;
                    case FillInArgument.DefaultText:
                        if (DefaultText is O oDefaultText)
                        {
                            yield return oDefaultText;
                        }
                        break;
                    case FillInArgument.PromptOnce:
                        if (PromptOnce is O oPromptOnce)
                        {
                            yield return oPromptOnce;
                        }
                        break;
                    case FillInArgument.GeneralFormat:
                        if (GeneralFormat is O oGeneralFormat)
                        {
                            yield return oGeneralFormat;
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
                    FillInArgument arg = Order[index];
                    switch (arg)
                    {
                        case FillInArgument.PromptText:
                            if (replacement is ExpressionNode promptText)
                            {
                                current = PromptText;
                                PromptText = promptText;
                            }
                            break;
                        case FillInArgument.DefaultText:
                            if (replacement is FlaggedArgument<ExpressionNode> defaultText)
                            {
                                current = DefaultText;
                                DefaultText = defaultText;
                            }
                            break;
                        case FillInArgument.PromptOnce:
                            if (replacement is BoolFlagNode promptOnce)
                            {
                                current = PromptOnce;
                                PromptOnce = promptOnce;
                            }
                            break;
                        case FillInArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> generalFormat)
                            {
                                current = GeneralFormat;
                                GeneralFormat = generalFormat;
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
