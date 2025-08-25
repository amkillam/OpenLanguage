using System;
using System.IO;

namespace OpenLanguage.SpreadsheetML.Formula
{
    /// <summary>
    /// A parser for Excel-like formulas using the GPLEX/GPPG toolchain.
    /// </summary>
    public static class FormulaParser
    {
        public static Formula Parse(string formulaText)
        {
            if (string.IsNullOrWhiteSpace(formulaText))
            {
                throw new System.ArgumentException(
                    "Formula text cannot be null or empty.",
                    nameof(formulaText)
                );
            }

            int leadingEqualsCount = 0;
            if (!string.IsNullOrEmpty(formulaText))
            {
                while (
                    leadingEqualsCount < formulaText.Length
                    && formulaText[leadingEqualsCount] == '='
                )
                {
                    leadingEqualsCount++;
                }
            }

            string formulaBody = leadingEqualsCount > 0 ? formulaText.Substring(1) : formulaText;

            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(formulaBody);
            MemoryStream stream = new(byteArray);

            OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner scanner = new(stream);
            OpenLanguage.SpreadsheetML.Formula.Generated.Parser parser = new(scanner);

            bool success = parser.Parse();

            if (!success || parser.root == null)
            {
                throw new System.InvalidOperationException(
                    "Failed to parse formula due to syntax errors."
                );
            }

            Ast.Node astRoot = parser.root;
            // Preserve any extra leading '=' signs (beyond the first stripped for parsing)
            if (
                astRoot is OpenLanguage.SpreadsheetML.Formula.Ast.ExpressionNode exprNode
                && leadingEqualsCount > 1
            )
            {
                int extras = leadingEqualsCount - 1;
                for (int i = 0; i < extras; i++)
                {
                    exprNode.LeadingWhitespace.Insert(
                        0,
                        new OpenLanguage.SpreadsheetML.Formula.Ast.WhitespaceNode("=")
                    );
                }
            }

            return new Formula(formulaText, astRoot);
        }

        public static Formula? TryParse(string formulaText)
        {
            try
            {
                return FormulaParser.Parse(formulaText);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(
                    $"Encountered error while trying to parse formula text: \"{e}\""
                );
                return null;
            }
        }
    }
}
