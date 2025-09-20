using System;
using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula
{
    /// <summary>
    /// A parser for Excel-like formulas using the GPLEX/GPPG toolchain.
    /// </summary>
    public static class FormulaParser
    {
        public static Ast.Node Parse(string? formulaText)
        {
            if (string.IsNullOrWhiteSpace(formulaText) || formulaText.Length == 0)
            {
                throw new System.ArgumentException(
                    "Formula text cannot be null, empty, or only whitespace.",
                    nameof(formulaText)
                );
            }

            OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner scanner =
                new OpenLanguage.SpreadsheetML.Formula.Generated.FormulaScanner();
            scanner.SetSource(formulaText, 0);
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

        public static Ast.Node Parse(IEnumerable<char>? chars)
        {
            if (chars == null)
            {
                throw new System.ArgumentException(
                    "Formula text cannot be null, empty, or only whitespace.",
                    nameof(chars)
                );
            }
            string formulaText = string.Concat(chars);

            return Parse(formulaText);
        }

        public static Ast.Node? TryParse(IEnumerable<char>? chars)
        {
            try
            {
                return FormulaParser.Parse(chars);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(
                    $"Encountered error while trying to parse formula text: \"{e}\""
                );
                return null;
            }
        }

        public static Ast.Node? TryParse(string? chars)
        {
            try
            {
                return FormulaParser.Parse(chars);
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
