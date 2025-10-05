using System;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public static class FieldInstructionParser
    {
        public static WordprocessingML.Ast.ExpressionNode Parse(string? fieldInstruction)
        {
            if (string.IsNullOrWhiteSpace(fieldInstruction))
            {
                // Throw ArgumentException for invalid input to match test expectations
                throw new ArgumentException(
                    "Field code cannot be null or whitespace.",
                    nameof(fieldInstruction)
                );
            }

            FieldInstructionScanner scanner = new FieldInstructionScanner();
            scanner.SetSource(fieldInstruction, 0);
            Parser parser = new Parser(scanner);

            if (!parser.Parse())
            {
                throw new InvalidOperationException(
                    "Failed to parse field instruction due to syntax errors."
                );
            }

            if (parser.root is not WordprocessingML.Ast.ExpressionNode node)
            {
                throw new InvalidOperationException("Parser returned a null or invalid AST root.");
            }

            return node;
        }

        public static WordprocessingML.Ast.ExpressionNode? TryParse(string? fieldInstruction)
        {
            try
            {
                return Parse(fieldInstruction);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(
                    $"Encountered error while trying to parse field instruction. Error: \"{e}\""
                );
                return null;
            }
        }
    }
}
