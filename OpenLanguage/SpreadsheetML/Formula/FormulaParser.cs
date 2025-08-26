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
            if (!string.IsNullOrEmpty(formulaText) && formulaText.Length > 0 && formulaText[0] == '=')
            {
                // Only strip the initial formula indicator '='. Leave any additional leading '='
                // characters in the input so the lexer/parser can recognise them as tokens.
                leadingEqualsCount = 1;
            }

            string formulaBody = formulaText;
            if (leadingEqualsCount > 0)
            {
                // Strip exactly one leading '=' before parsing
                formulaBody = formulaText.Substring(leadingEqualsCount);
            }

            OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner scanner = new OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner();
            scanner.SetSource(formulaBody, 0);
            OpenLanguage.SpreadsheetML.Formula.Generated.Parser parser = new OpenLanguage.SpreadsheetML.Formula.Generated.Parser(scanner);

            bool success;
            try
            {
                success = parser.Parse();
            }
            catch (Exception ex)
            {
                // Wrap lexer/parser exceptions with a consistent InvalidOperationException
                // while preserving the original diagnostic message so tests can assert on it.
                throw new System.InvalidOperationException(
                    $"Failed to parse formula due to syntax errors. {ex.Message}",
                    ex
                );
            }

            if (!success || parser.root == null)
            {
                throw new System.InvalidOperationException(
                    "Failed to parse formula due to syntax errors."
                );
            }

            Ast.Node astRoot = parser.root;
            // We only stripped the initial formula marker '=' above.
            // Any additional '=' characters were left in formulaBody and parsed normally,
            // therefore there is nothing to reinsert here.

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
