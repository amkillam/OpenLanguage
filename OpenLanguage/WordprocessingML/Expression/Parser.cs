using System;
using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.Expression.Generated;

namespace OpenLanguage.WordprocessingML.Expression
{
    public static class ExpressionParser
    {
        public static ExpressionNode Parse(string? expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                List<Node> wsNodes = new List<Node>();
                if (!string.IsNullOrEmpty(expression))
                {
                    wsNodes.Add(new WhitespaceNode(expression));
                }
                return new EmptyExpressionNode(wsNodes);
            }

            ExpressionScanner scanner = new ExpressionScanner();
            scanner.SetSource(expression, 0);
            Parser parser = new Parser(scanner);

            if (!parser.Parse())
            {
                throw new InvalidOperationException(
                    "Failed to parse expression due to syntax errors."
                );
            }

            if (parser.root is not ExpressionNode node)
            {
                throw new InvalidOperationException("Parser returned a null or invalid AST root.");
            }

            return node;
        }

        public static ExpressionNode? TryParse(string? expression)
        {
            try
            {
                return Parse(expression);
            }
            catch
            {
                return null;
            }
        }
    }
}
