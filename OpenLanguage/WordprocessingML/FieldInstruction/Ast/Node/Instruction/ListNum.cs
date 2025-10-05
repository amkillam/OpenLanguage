using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum ListNumArgument
    {
        ListName,
        Level,
        StartingNumber,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed LISTNUM field instruction.
    /// Computes the next integral number from the current or a specific series,
    /// or a specific number from the next or specific series.
    ///
    /// This field can be used anywhere in a paragraph, not just at its start.
    /// A `LISTNUM` field can be incorporated into numbering from a simple or
    /// outline-numbered list.
    ///
    /// Text in field-argument is used to associates a `LISTNUM` field with a
    /// specific list.
    ///
    /// To emulate the behavior of the `AUTONUM`, `AUTONUMLGL`, and `AUTONUMOUT` fields,
    /// use the list names `NumberDefault`, `LegalDefault`, and `OutlineDefault` names,
    /// respectively.
    ///
    /// By default, the `NumberFormat` list is used. The XML generated for a complex
    /// field implementation shall not have the optional field value stored.
    ///
    /// There are nine levels of list, and, assuming `\s 1` for each,
    /// the result style used for each is as follows:
    /// 1. 1)
    /// 2. A)
    /// 3. Iii)
    /// 4. (1)
    /// 5. (a)
    /// 6. (iii)
    /// 7. 1.
    /// 8. A.
    /// 9. Iii.
    ///
    /// ## Syntax
    ///  { LISTNUM ["Name"] [Switches] }
    ///
    /// ### Switches
    /// - \l field-argument
    ///   List level
    /// - \s field-argument
    ///   Starting number
    ///
    /// ## Examples
    /// LISTNUM fields were used in this example to generate the numbers (i),(ii), and (iii):
    /// The Borrower shall deliver to the Bank a certificate of its chief financial officer, \
    /// certifying that (i) no Default has occurred, (ii)the attached financial statements have \
    /// been prepared in accordance with generally accepted accounting principles, and (iii) the \
    /// attached certificate correctly sets forth the calculations for determining the ratios specified \
    /// in Sections 5.08, 5.09, and 5.10.
    ///
    /// The first LISTNUM field in the example includes the name and the level switch:
    ///
    /// { LISTNUM NumberDefault \l 6}
    /// </summary>
    public class ListNumFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The name of the list.
        ///
        /// </summary>
        public ExpressionNode? ListName { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// List level
        /// </summary>
        public FlaggedArgument<NumericLiteralNode<int>>? Level { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Starting number
        /// </summary>
        public FlaggedArgument<NumericLiteralNode<int>>? StartingNumber { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public List<ListNumArgument> Order { get; set; } = new List<ListNumArgument>();

        public ListNumFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? listName,
            FlaggedArgument<NumericLiteralNode<int>>? level,
            FlaggedArgument<NumericLiteralNode<int>>? startingNumber,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<ListNumArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            ListName = listName;
            Level = level;
            StartingNumber = startingNumber;
            GeneralFormat = generalFormat;
            Order = order;
        }

        public ListNumFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }

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
                            ListNumArgument.ListName => ListName?.ToString() ?? string.Empty,
                            ListNumArgument.Level => Level?.ToString() ?? string.Empty,
                            ListNumArgument.StartingNumber => StartingNumber?.ToString()
                                ?? string.Empty,
                            ListNumArgument.GeneralFormat => GeneralFormat?.ToString()
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

            foreach (ListNumArgument arg in Order)
            {
                Node? child = arg switch
                {
                    ListNumArgument.ListName => ListName,
                    ListNumArgument.Level => Level,
                    ListNumArgument.StartingNumber => StartingNumber,
                    ListNumArgument.GeneralFormat => GeneralFormat,
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
                    ListNumArgument arg = Order[index];
                    switch (arg)
                    {
                        case ListNumArgument.ListName:
                            if (replacement is ExpressionNode listName)
                            {
                                current = ListName;
                                ListName = listName;
                            }
                            break;
                        case ListNumArgument.Level:
                            if (replacement is FlaggedArgument<NumericLiteralNode<int>> level)
                            {
                                current = Level;
                                Level = level;
                            }
                            break;
                        case ListNumArgument.StartingNumber:
                            if (
                                replacement
                                is FlaggedArgument<NumericLiteralNode<int>> startingNumber
                            )
                            {
                                current = StartingNumber;
                                StartingNumber = startingNumber;
                            }
                            break;
                        case ListNumArgument.GeneralFormat:
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
