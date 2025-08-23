using System;
using System.IO;
using OpenLanguage.SpreadsheetML.Formula.Ast;

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

            string formulaBody = formulaText.StartsWith('=')
                ? formulaText.Substring(1)
                : formulaText;

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

            return new Formula(formulaText, parser.root);
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
