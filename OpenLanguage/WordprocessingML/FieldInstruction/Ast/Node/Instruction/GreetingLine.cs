using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum GreetingLineArgument
    {
        BlankNameText,
        Format,
        LanguageId,
    }

    /// <summary>
    /// Represents a strongly-typed GREETINGLINE field instruction.
    /// Inserts a mail merge greeting line.
    /// </summary>
    public class GreetingLineFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// Switch: \e or \c field-argument
        /// Specifies the text to include in the merge field if the name field in the data source is blank.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? BlankNameText { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Specifies the format of the name included in the field.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? Format { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Specifies the language ID used to format the name. Defaults to the language ID of the first character of the document.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? LanguageId { get; set; }

        public List<GreetingLineArgument> Order { get; set; } = new List<GreetingLineArgument>();

        public GreetingLineFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? blankNameText,
            FlaggedArgument<ExpressionNode>? format,
            FlaggedArgument<ExpressionNode>? languageId,
            List<GreetingLineArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            BlankNameText = blankNameText;
            Format = format;
            LanguageId = languageId;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(
                    (GreetingLineArgument a) =>
                        a switch
                        {
                            GreetingLineArgument.BlankNameText => BlankNameText?.ToString()
                                ?? string.Empty,
                            GreetingLineArgument.Format => Format?.ToString() ?? string.Empty,
                            GreetingLineArgument.LanguageId => LanguageId?.ToString()
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

            foreach (GreetingLineArgument arg in Order)
            {
                Node? node = arg switch
                {
                    GreetingLineArgument.BlankNameText => BlankNameText,
                    GreetingLineArgument.Format => Format,
                    GreetingLineArgument.LanguageId => LanguageId,
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
                if (index >= 0 && index < Order.Count)
                {
                    GreetingLineArgument arg = Order[index];
                    switch (arg)
                    {
                        case GreetingLineArgument.BlankNameText:
                            if (replacement is FlaggedArgument<ExpressionNode> sln)
                            {
                                current = BlankNameText;
                                BlankNameText = sln;
                            }
                            break;
                        case GreetingLineArgument.Format:
                            if (replacement is FlaggedArgument<ExpressionNode> fa)
                            {
                                current = Format;
                                Format = fa;
                            }
                            break;
                        case GreetingLineArgument.LanguageId:
                            if (replacement is FlaggedArgument<ExpressionNode> la)
                            {
                                current = LanguageId;
                                LanguageId = la;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}
