using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed SYMBOL field instruction.
    /// Retrieves the character whose code point value is specified in decimal or hexadecimal (by using a leading 0x or 0X) by text in field-argument. The formatting switches over ride any formatting applied directly to the result. The XML generated for a complex field implementation shall not have the optional field value stored.
    /// </summary>
    public class SymbolFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The character code of the symbol
        /// </summary>
        public Int32? CharacterCode { get; set; }

        /// <summary>
        /// Switch: \a
        /// ANSI character
        /// </summary>
        public bool Ansi { get; set; }

        /// <summary>
        /// Switch: \h
        /// Font size in half-points
        /// </summary>
        public bool FontSizeHalfPoints { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Font size in points
        /// </summary>
        public DocumentFormat.OpenXml.Wordprocessing.FontSize? FontSizePoints { get; set; }

        /// <summary>
        /// Switch: \u
        /// Unicode character
        /// </summary>
        public bool Unicode { get; set; }

        /// <summary>
        /// Initializes a new instance of the SymbolFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public SymbolFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "SYMBOL")
            {
                throw new ArgumentException($"Expected SYMBOL field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                string? characterCodeStr = firstNonSwitch.Value?.ToString();
                if (characterCodeStr != null)
                {
                    if (Int32.TryParse(characterCodeStr, out int tempCharacterCode))
                    {
                        CharacterCode = tempCharacterCode;
                    }
                }
            }

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\a":
                            Ansi = true;
                            break;
                        case "\\h":
                            FontSizeHalfPoints = true;
                            break;
                        case "\\s":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    FontSizePoints =
                                        new DocumentFormat.OpenXml.Wordprocessing.FontSize();
                                    string? pointsValText = nextArg.Value?.ToString();
                                    if (
                                        pointsValText != null
                                        && UInt64.TryParse(pointsValText, out UInt64 pointsVal)
                                    )
                                    {
                                        bool isHalfPoints =
                                            FontSizeHalfPoints
                                            || Source.Arguments.Any(
                                                (FieldArgument arg) =>
                                                    arg.Type == FieldArgumentType.Switch
                                                    && arg.Value?.ToString()?.ToLowerInvariant()
                                                        == "\\h"
                                            );
                                        if (!isHalfPoints)
                                        {
                                            pointsVal *= 2;
                                        }

                                        FontSizePoints.Val = new StringValue(pointsVal.ToString());
                                    }
                                }
                            }
                            break;
                        case "\\u":
                            Unicode = true;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            if (CharacterCode != null)
            {
                string argString = CharacterCode!.ToString()!;
                result.Add(argString);
            }

            if (Ansi)
            {
                result.Add("\\a");
            }

            if (FontSizeHalfPoints)
            {
                result.Add("\\h");
            }

            if (FontSizePoints?.Val?.Value != null)
            {
                result.Add("\\s");
                result.Add(
                    FontSizePoints.Val.Value!.Contains(" ")
                        ? $"\"{FontSizePoints.Val.Value!}\""
                        : FontSizePoints.Val.Value!
                );
            }

            if (Unicode)
            {
                result.Add("\\u");
            }

            return string.Join(" ", result);
        }
    }
}
