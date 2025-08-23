using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed PRINT field instruction.
    /// Sends the printer-specific control code characters specified by text in field-argument to the selected printer.
    /// </summary>
    public class PrintFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The printer-specific control code characters to send to the printer.
        /// </summary>
        public string PrinterControlCodes { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \p
        /// Allows PostScript strings to be sent to the printer as native PostScript codes.
        /// </summary>
        public bool UsePostScript { get; set; }

        /// <summary>
        /// The drawing rectangle definition for PostScript commands (field-argument-1 of \p switch).
        /// Defines the drawing rectangle on which the subsequent PostScript instructions operate.
        /// </summary>
        public string? PostScriptDrawingRectangle { get; set; }

        /// <summary>
        /// The PostScript instructions to execute (field-argument-2 of \p switch).
        /// Contains the actual PostScript commands to be executed.
        /// </summary>
        public string? PostScriptInstructions { get; set; }

        /// <summary>
        /// Initializes a new instance of the PrintFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public PrintFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "PRINT")
            {
                throw new ArgumentException($"Expected PRINT field, but got {Source.Instruction}");
            }

            // Parse the required field argument (printer control codes) - first non-switch argument
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type != FieldArgumentType.Switch
            );
            PrinterControlCodes = firstNonSwitch?.Value?.ToString() ?? string.Empty;

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\p":
                            UsePostScript = true;
                            // The \p switch requires two field arguments
                            if (i + 2 < Source.Arguments.Count)
                            {
                                FieldArgument drawingRectArg = Source.Arguments[i + 1];
                                FieldArgument instructionsArg = Source.Arguments[i + 2];

                                if (
                                    drawingRectArg.Type != FieldArgumentType.Switch
                                    && instructionsArg.Type != FieldArgumentType.Switch
                                )
                                {
                                    PostScriptDrawingRectangle = drawingRectArg.Value?.ToString();
                                    PostScriptInstructions = instructionsArg.Value?.ToString();
                                    i += 2; // Skip the consumed arguments
                                }
                                else
                                {
                                    throw new ArgumentException(
                                        "\\p switch requires two field arguments: drawing rectangle and PostScript instructions"
                                    );
                                }
                            }
                            else
                            {
                                throw new ArgumentException(
                                    "\\p switch requires two field arguments: drawing rectangle and PostScript instructions"
                                );
                            }
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

            // Add the required printer control codes field argument
            if (!string.IsNullOrEmpty(PrinterControlCodes))
            {
                result.Add(
                    PrinterControlCodes.Contains(" ") && !PrinterControlCodes.StartsWith("\"")
                        ? $"\"{PrinterControlCodes}\""
                        : PrinterControlCodes
                );
            }

            // Add PostScript switch and its two arguments if present
            if (UsePostScript)
            {
                result.Add("\\p");

                if (!string.IsNullOrEmpty(PostScriptDrawingRectangle))
                {
                    result.Add(
                        PostScriptDrawingRectangle.Contains(" ")
                        && !PostScriptDrawingRectangle.StartsWith("\"")
                            ? $"\"{PostScriptDrawingRectangle}\""
                            : PostScriptDrawingRectangle
                    );
                }

                if (!string.IsNullOrEmpty(PostScriptInstructions))
                {
                    result.Add(
                        PostScriptInstructions.Contains(" ")
                        && !PostScriptInstructions.StartsWith("\"")
                            ? $"\"{PostScriptInstructions}\""
                            : PostScriptInstructions
                    );
                }
            }

            return string.Join(" ", result);
        }
    }
}
