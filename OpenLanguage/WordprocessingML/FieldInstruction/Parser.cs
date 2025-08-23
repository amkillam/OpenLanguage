using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    /// <summary>
    /// A recursive descent parser that builds a structured FieldInstruction object
    /// from a stream of tokens provided by the FieldLexer.
    /// </summary>
    public static class FieldParser
    {
        private static int _currentTokenIndex;

        public static FieldInstruction Parse(string fieldCode)
        {
            if (string.IsNullOrEmpty(fieldCode))
                throw new Exception("Failed to parse FieldInstruction: empty or null input");

            IEnumerable<FieldToken> tokenEnumerable = FieldLexer.Tokenize(fieldCode);
            List<FieldToken> tokens = new List<FieldToken>();

            _currentTokenIndex = 0;
            FieldToken? firstToken = tokenEnumerable.FirstOrDefault();

            if (firstToken == null)
            {
                throw new Exception(
                    "Failed to parse FieldInstruction: could not find instruction name"
                );
            }

            // A valid field code might start with a brace, or just the instruction for simple cases.
            if (firstToken.Type == FieldTokenType.LeftBrace)
            {
                FieldInstruction? parsedNested = TryParseInstruction(tokenEnumerable.ToList());
                if (parsedNested == null)
                {
                    throw new Exception("Failed to parse FieldInstruction");
                }
                return parsedNested;
            }

            tokens.Add(firstToken!);
            foreach (FieldToken token in tokenEnumerable)
            {
                tokens.Add(token);
            }
            FieldInstruction? parsed = TryParseInstruction(tokens);
            if (parsed == null)
            {
                throw new Exception("Failed to parse FieldInstruction");
            }

            return parsed;
        }

        public static FieldInstruction? TryParse(string fieldCode)
        {
            if (string.IsNullOrEmpty(fieldCode))
            {
                return null;
            }

            IEnumerable<FieldToken> tokenEnumerable = FieldLexer.Tokenize(fieldCode);
            List<FieldToken> tokens = new List<FieldToken>();

            _currentTokenIndex = 0;
            FieldToken? firstToken = tokenEnumerable.FirstOrDefault();

            if (firstToken == null)
            {
                return null;
            }
            // A valid field code might start with a brace, or just the instruction for simple cases.
            if (firstToken.Type == FieldTokenType.LeftBrace)
            {
                return TryParseInstruction(tokenEnumerable.ToList());
            }

            tokens.Add(firstToken);
            foreach (FieldToken token in tokenEnumerable)
            {
                tokens.Add(token);
            }

            return TryParseInstruction(tokens);
        }

        public static FieldInstruction? TryParseFiltered(
            string fieldCode,
            HashSet<string> keywordFilter
        )
        {
            if (string.IsNullOrEmpty(fieldCode))
            {
                return null;
            }

            IEnumerable<FieldToken> tokenEnumerable = FieldLexer.Tokenize(fieldCode);
            List<FieldToken> tokens = new List<FieldToken>();

            _currentTokenIndex = 0;
            FieldToken? firstToken = tokenEnumerable.FirstOrDefault();

            if (firstToken == null)
            {
                return null;
            }

            // A valid field code might start with a brace, or just the instruction for simple cases.
            if (firstToken.Type == FieldTokenType.LeftBrace)
            {
                return TryParseInstruction(tokenEnumerable.ToList());
            }

            if (!keywordFilter.Contains(firstToken.Value))
            {
                return null;
            }
            tokens.Add(firstToken);
            foreach (FieldToken token in tokenEnumerable)
            {
                tokens.Add(token);
            }

            return TryParseInstruction(tokens);
        }

        private static FieldInstruction? TryParseInstruction(List<FieldToken> tokens)
        {
            // Find the instruction keyword.
            FieldToken? keywordToken = GetNextNonWhitespaceToken(tokens);
            if (keywordToken == null || keywordToken.Type != FieldTokenType.Keyword)
            {
                return null; // Invalid structure, no keyword found.
            }
            _currentTokenIndex++;

            FieldInstruction instruction = new FieldInstruction(keywordToken.Value);

            // Parse arguments until the end of the field.
            while (_currentTokenIndex < tokens.Count)
            {
                FieldToken? token = GetNextNonWhitespaceToken(tokens);
                if (
                    token == null
                    || token.Type == FieldTokenType.RightBrace
                    || token.Type == FieldTokenType.EndOfField
                )
                {
                    break; // End of the current instruction.
                }

                _currentTokenIndex++;
                switch (token.Type)
                {
                    case FieldTokenType.Identifier:
                        instruction.Arguments.Add(
                            new FieldArgument(FieldArgumentType.Identifier, token.Value)
                        );
                        break;
                    case FieldTokenType.StringLiteral:
                        instruction.Arguments.Add(
                            new FieldArgument(FieldArgumentType.StringLiteral, token.Value)
                        );
                        break;
                    case FieldTokenType.Switch:
                        instruction.Arguments.Add(
                            new FieldArgument(FieldArgumentType.Switch, token.Value)
                        );
                        break;
                    case FieldTokenType.LeftBrace:
                        // A nested field begins. Parse it recursively.
                        FieldInstruction? nestedInstruction = TryParseInstruction(tokens);
                        if (nestedInstruction != null)
                        {
                            instruction.Arguments.Add(
                                new FieldArgument(FieldArgumentType.NestedField, nestedInstruction)
                            );
                        }
                        break;
                }
            }

            // Consume the closing brace for the current scope.
            if (
                _currentTokenIndex < tokens.Count
                && tokens[_currentTokenIndex].Type == FieldTokenType.RightBrace
            )
            {
                _currentTokenIndex++;
            }

            return instruction;
        }

        private static FieldToken? GetNextNonWhitespaceToken(List<FieldToken> tokens)
        {
            while (_currentTokenIndex < tokens.Count)
            {
                if (tokens[_currentTokenIndex].Type != FieldTokenType.Whitespace)
                {
                    return tokens[_currentTokenIndex];
                }
                _currentTokenIndex++;
            }
            return null;
        }
    }
}
