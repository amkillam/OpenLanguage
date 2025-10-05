using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum PrintArgument
    {
        PrinterControlCodes,
        UsePostScript,
        PostScriptDrawingRectangle,
        PostScriptInstructions,
    }

    /// <summary>
    /// Represents a strongly-typed PRINT field instruction.
    /// Sends the printer-specific control code characters specified by text in field-argument to the selected printer.
    /// </summary>
    public class PrintFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The printer-specific control code characters to send to the printer.
        /// </summary>
        public ExpressionNode PrinterControlCodes { get; set; } =
            new StringLiteralNode(string.Empty);

        /// <summary>
        /// Switch: \p
        /// Allows PostScript strings to be sent to the printer as native PostScript codes.
        /// </summary>
        public BoolFlagNode? UsePostScript { get; set; }

        /// <summary>
        /// The drawing rectangle definition for PostScript commands (field-argument-1 of \p switch).
        /// Defines the drawing rectangle on which the subsequent PostScript instructions operate.
        /// </summary>
        public ExpressionNode? PostScriptDrawingRectangle { get; set; }

        /// <summary>
        /// The PostScript instructions to execute (field-argument-2 of \p switch).
        /// Contains the actual PostScript commands to be executed.
        /// </summary>
        public ExpressionNode? PostScriptInstructions { get; set; }

        public List<PrintArgument> Order { get; set; } = new List<PrintArgument>();

        public PrintFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? printerControlCodes,
            BoolFlagNode? usePostScript,
            ExpressionNode? postScriptDrawingRectangle,
            ExpressionNode? postScriptInstructions,
            List<PrintArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            PrinterControlCodes = printerControlCodes ?? new StringLiteralNode(string.Empty);
            UsePostScript = usePostScript;
            PostScriptDrawingRectangle = postScriptDrawingRectangle;
            PostScriptInstructions = postScriptInstructions;

            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString()
        {
            return Instruction.ToString()
                + string.Concat(
                    Order.Select(arg =>
                        arg switch
                        {
                            PrintArgument.PrinterControlCodes => PrinterControlCodes.ToString(),
                            PrintArgument.UsePostScript => UsePostScript?.ToString()
                                ?? string.Empty,
                            PrintArgument.PostScriptDrawingRectangle =>
                                PostScriptDrawingRectangle?.ToString() ?? string.Empty,
                            PrintArgument.PostScriptInstructions =>
                                PostScriptInstructions?.ToString() ?? string.Empty,
                            _ => string.Empty,
                        }
                    )
                );
        }

        public override IEnumerable<O> Children<O>()
        {
            foreach (PrintArgument arg in Order)
            {
                switch (arg)
                {
                    case PrintArgument.PrinterControlCodes:
                        if (PrinterControlCodes is O plc)
                        {
                            yield return plc;
                        }
                        break;
                    case PrintArgument.UsePostScript:
                        if (UsePostScript is O ups)
                        {
                            yield return ups;
                        }
                        break;
                    case PrintArgument.PostScriptDrawingRectangle:
                        if (PostScriptDrawingRectangle is O psdr)
                        {
                            yield return psdr;
                        }
                        break;
                    case PrintArgument.PostScriptInstructions:
                        if (PostScriptInstructions is O psi)
                        {
                            yield return psi;
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
                return current;
            }

            index--;
            if (index >= 0 && index < Order.Count)
            {
                PrintArgument target = Order[index];
                switch (target)
                {
                    case PrintArgument.PrinterControlCodes:
                        if (replacement is ExpressionNode plc)
                        {
                            current = PrinterControlCodes;
                            PrinterControlCodes = plc;
                        }
                        break;
                    case PrintArgument.UsePostScript:
                        if (replacement is BoolFlagNode ups)
                        {
                            current = UsePostScript;
                            UsePostScript = ups;
                        }
                        break;
                    case PrintArgument.PostScriptDrawingRectangle:
                        if (replacement is ExpressionNode psdr)
                        {
                            current = PostScriptDrawingRectangle;
                            PostScriptDrawingRectangle = psdr;
                        }
                        break;
                    case PrintArgument.PostScriptInstructions:
                        if (replacement is ExpressionNode psi)
                        {
                            current = PostScriptInstructions;
                            PostScriptInstructions = psi;
                        }
                        break;
                }
            }

            return current;
        }
    }
}
