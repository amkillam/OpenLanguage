using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum BibliographyArgument
    {
        Locale,
        FilterLocale,
        SingleSourceTag,
    }

    public class BibliographyFieldInstruction : FieldInstruction
    {
        public FlaggedArgument<ExpressionNode>? Locale { get; set; }
        public FlaggedArgument<ExpressionNode>? FilterLocale { get; set; }
        public FlaggedArgument<ExpressionNode>? SingleSourceTag { get; set; }
        public List<BibliographyArgument> Order { get; set; } = new List<BibliographyArgument>();

        public BibliographyFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }

        public BibliographyFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? locale,
            FlaggedArgument<ExpressionNode>? filterLocale,
            FlaggedArgument<ExpressionNode>? singleSourceTag,
            List<BibliographyArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Locale = locale;
            FilterLocale = filterLocale;
            SingleSourceTag = singleSourceTag;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        BibliographyArgument.Locale => Locale?.ToString() ?? string.Empty,
                        BibliographyArgument.FilterLocale => FilterLocale?.ToString()
                            ?? string.Empty,
                        BibliographyArgument.SingleSourceTag => SingleSourceTag?.ToString()
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

            foreach (BibliographyArgument arg in Order)
            {
                Node? child = arg switch
                {
                    BibliographyArgument.Locale => Locale,
                    BibliographyArgument.FilterLocale => FilterLocale,
                    BibliographyArgument.SingleSourceTag => SingleSourceTag,
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

            if (index == 0 && replacement is StringLiteralNode instr)
            {
                current = Instruction;
                Instruction = instr;
            }
            else
            {
                index--;
                if (index >= 0 && index < Order.Count)
                {
                    BibliographyArgument arg = Order[index];
                    switch (arg)
                    {
                        case BibliographyArgument.Locale:
                            if (replacement is FlaggedArgument<ExpressionNode> l)
                            {
                                current = Locale;
                                Locale = l;
                            }
                            break;
                        case BibliographyArgument.FilterLocale:
                            if (replacement is FlaggedArgument<ExpressionNode> fl)
                            {
                                current = FilterLocale;
                                FilterLocale = fl;
                            }
                            break;
                        case BibliographyArgument.SingleSourceTag:
                            if (replacement is FlaggedArgument<ExpressionNode> sst)
                            {
                                current = SingleSourceTag;
                                SingleSourceTag = sst;
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
