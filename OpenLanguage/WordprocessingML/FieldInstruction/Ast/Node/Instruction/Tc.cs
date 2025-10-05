using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum TcArgument
    {
        EntryText,
        TableType,
        Level,
        OmitPageNumber,
        Separator,
    }

    /// <summary>
    /// Represents a strongly-typed TC field instruction.
    /// Defines the text and page number for a table of contents (including a table of figures) entry, which is used by a `TOC` field. The text of the entry is text in field-argument.
    /// </summary>
    public class TcFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The text for the table of contents entry
        /// </summary>
        public ExpressionNode? EntryText { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Table identifier
        /// </summary>
        public FlaggedArgument<ExpressionNode>? TableType { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// The level of the TC entry. If no level is specified, level 1 is assumed.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? Level { get; set; }

        /// <summary>
        /// Switch: \n
        /// Omits the page number for the entry.
        /// </summary>
        public BoolFlagNode? OmitPageNumber { get; set; }

        /// <summary>
        /// Undocumented Switch: \s field-argument
        /// </summary>
        public FlaggedArgument<ExpressionNode>? Separator { get; set; }

        public List<TcArgument> Order { get; set; } = new List<TcArgument>();

        public TcFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? entryText,
            FlaggedArgument<ExpressionNode>? tableId,
            FlaggedArgument<ExpressionNode>? level,
            BoolFlagNode? omitPageNumber,
            FlaggedArgument<ExpressionNode>? separator,
            List<TcArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            EntryText = entryText;
            TableType = tableId;
            Level = level;
            OmitPageNumber = omitPageNumber;
            Separator = separator;
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
                        TcArgument.EntryText => EntryText?.ToString() ?? string.Empty,
                        TcArgument.TableType => TableType?.ToString() ?? string.Empty,
                        TcArgument.Level => Level?.ToString() ?? string.Empty,
                        TcArgument.OmitPageNumber => OmitPageNumber?.ToString() ?? string.Empty,
                        TcArgument.Separator => Separator?.ToString() ?? string.Empty,
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

            foreach (TcArgument arg in Order)
            {
                switch (arg)
                {
                    case TcArgument.EntryText:
                        if (EntryText is O oEntryText)
                        {
                            yield return oEntryText;
                        }
                        break;
                    case TcArgument.TableType:
                        if (TableType is O oTableType)
                        {
                            yield return oTableType;
                        }
                        break;
                    case TcArgument.Level:
                        if (Level is O oLevel)
                        {
                            yield return oLevel;
                        }
                        break;
                    case TcArgument.OmitPageNumber:
                        if (OmitPageNumber is O oOmitPageNumber)
                        {
                            yield return oOmitPageNumber;
                        }
                        break;
                    case TcArgument.Separator:
                        if (Separator is O oSeparator)
                        {
                            yield return oSeparator;
                        }
                        break;
                }
            }
            yield break;
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
                    TcArgument arg = Order[index];
                    switch (arg)
                    {
                        case TcArgument.EntryText:
                            if (replacement is ExpressionNode entryText)
                            {
                                current = EntryText;
                                EntryText = entryText;
                            }
                            break;
                        case TcArgument.TableType:
                            if (replacement is FlaggedArgument<ExpressionNode> tableId)
                            {
                                current = TableType;
                                TableType = tableId;
                            }
                            break;
                        case TcArgument.Level:
                            if (replacement is FlaggedArgument<ExpressionNode> level)
                            {
                                current = Level;
                                Level = level;
                            }
                            break;
                        case TcArgument.OmitPageNumber:
                            if (replacement is BoolFlagNode omitPageNumber)
                            {
                                current = OmitPageNumber;
                                OmitPageNumber = omitPageNumber;
                            }
                            break;
                        case TcArgument.Separator:
                            if (replacement is FlaggedArgument<ExpressionNode> separator)
                            {
                                current = Separator;
                                Separator = separator;
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
