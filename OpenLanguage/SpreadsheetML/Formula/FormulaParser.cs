using System;

namespace OpenLanguage.SpreadsheetML.Formula
{
    /// <summary>
    /// A parser for Excel-like formulas using the GPLEX/GPPG toolchain.
    /// </summary>
    public static class FormulaParser
    {
        public static Ast.Node Parse(string formulaBody)
        {
            if (string.IsNullOrWhiteSpace(formulaBody))
            {
                throw new System.ArgumentException(
                    "Formula text cannot be null or empty.",
                    nameof(formulaBody)
                );
            }

            OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner scanner =
                new OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner();
            scanner.SetSource(formulaBody, 0);
            OpenLanguage.SpreadsheetML.Formula.Generated.Parser parser =
                new OpenLanguage.SpreadsheetML.Formula.Generated.Parser(scanner);

            bool success = false;
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

            if (!success)
            {
                throw new System.InvalidOperationException(
                    "Failed to parse formula due to syntax errors."
                );
            }

            if (parser.root == null)
            {
                throw new System.InvalidOperationException("Parser returned a null AST root.");
            }

            return parser.root;
        }

        public static Ast.Node? TryParse(string formulaText)
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
