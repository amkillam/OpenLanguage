using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum SymbolArgument
    {
        CharacterCode,
        Ansi,
        FontName,
        FontSizeHalfPoints,
        FontSizePoints,
        Unicode,
        ShiftJis,
    }

    /// <summary>
    /// Represents a strongly-typed SYMBOL field instruction.
    /// Retrieves the character whose code point value is specified in decimal or hexadecimal (by using a leading 0x or 0X) by text in field-argument. The formatting switches over ride any formatting applied directly to the result. The XML generated for a complex field implementation shall not have the optional field value stored.
    /// </summary>
    public class SymbolFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The character code of the symbol
        /// </summary>
        public NumericLiteralNode<int>? CharacterCode { get; set; }

        /// <summary>
        /// Switch: \a
        /// ANSI character
        /// </summary>
        public BoolFlagNode? Ansi { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Font name
        /// </summary>
        public FlaggedArgument<ExpressionNode>? FontName { get; set; }

        /// <summary>
        /// Switch: \h
        /// Font size in half-points
        /// </summary>
        public BoolFlagNode? FontSizeHalfPoints { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Font size in points
        /// </summary>
        public FlaggedArgument<ExpressionNode>? FontSizePoints { get; set; }

        /// <summary>
        /// Switch: \u
        /// Unicode character
        /// </summary>
        public BoolFlagNode? Unicode { get; set; }

        /// <summary>
        /// Switch: \j
        /// Interprets text in field-argument as the value of a SHIFT-JIS character.
        /// </summary>
        public BoolFlagNode? ShiftJis { get; set; }

        public List<SymbolArgument> Order { get; set; } = new List<SymbolArgument>();

        public SymbolFieldInstruction(
            StringLiteralNode instruction,
            NumericLiteralNode<int>? characterCode,
            BoolFlagNode? ansi,
            FlaggedArgument<ExpressionNode>? fontName,
            BoolFlagNode? fontSizeHalfPoints,
            FlaggedArgument<ExpressionNode>? fontSizePoints,
            BoolFlagNode? unicode,
            BoolFlagNode? shiftJis,
            List<SymbolArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            CharacterCode = characterCode;
            Ansi = ansi;
            FontName = fontName;
            FontSizeHalfPoints = fontSizeHalfPoints;
            FontSizePoints = fontSizePoints;
            Unicode = unicode;
            ShiftJis = shiftJis;

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
                        SymbolArgument.CharacterCode => CharacterCode?.ToString() ?? string.Empty,
                        SymbolArgument.Ansi => Ansi?.ToString() ?? string.Empty,
                        SymbolArgument.FontName => FontName?.ToString() ?? string.Empty,
                        SymbolArgument.FontSizeHalfPoints => FontSizeHalfPoints?.ToString()
                            ?? string.Empty,
                        SymbolArgument.FontSizePoints => FontSizePoints?.ToString() ?? string.Empty,
                        SymbolArgument.Unicode => Unicode?.ToString() ?? string.Empty,
                        SymbolArgument.ShiftJis => ShiftJis?.ToString() ?? string.Empty,
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

            foreach (SymbolArgument arg in Order)
            {
                Node? child = arg switch
                {
                    SymbolArgument.CharacterCode => CharacterCode,
                    SymbolArgument.Ansi => Ansi,
                    SymbolArgument.FontName => FontName,
                    SymbolArgument.FontSizeHalfPoints => FontSizeHalfPoints,
                    SymbolArgument.FontSizePoints => FontSizePoints,
                    SymbolArgument.Unicode => Unicode,
                    SymbolArgument.ShiftJis => ShiftJis,
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
                    SymbolArgument arg = Order[index];
                    switch (arg)
                    {
                        case SymbolArgument.CharacterCode:
                            if (replacement is NumericLiteralNode<int> characterCode)
                            {
                                current = CharacterCode;
                                CharacterCode = characterCode;
                            }
                            break;
                        case SymbolArgument.Ansi:
                            if (replacement is BoolFlagNode ansi)
                            {
                                current = Ansi;
                                Ansi = ansi;
                            }
                            break;
                        case SymbolArgument.FontName:
                            if (replacement is FlaggedArgument<ExpressionNode> fontName)
                            {
                                current = FontName;
                                FontName = fontName;
                            }
                            break;
                        case SymbolArgument.FontSizeHalfPoints:
                            if (replacement is BoolFlagNode fontSizeHalfPoints)
                            {
                                current = FontSizeHalfPoints;
                                FontSizeHalfPoints = fontSizeHalfPoints;
                            }
                            break;
                        case SymbolArgument.FontSizePoints:
                            if (replacement is FlaggedArgument<ExpressionNode> fontSizePoints)
                            {
                                current = FontSizePoints;
                                FontSizePoints = fontSizePoints;
                            }
                            break;
                        case SymbolArgument.Unicode:
                            if (replacement is BoolFlagNode unicode)
                            {
                                current = Unicode;
                                Unicode = unicode;
                            }
                            break;
                        case SymbolArgument.ShiftJis:
                            if (replacement is BoolFlagNode shiftJis)
                            {
                                current = ShiftJis;
                                ShiftJis = shiftJis;
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
