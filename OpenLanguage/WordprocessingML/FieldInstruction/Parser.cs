using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    /// <summary>
    /// A recursive descent parser that builds a structured FieldInstruction object
    /// from a stream of tokens provided by the FieldLexer.
    /// </summary>
    public class FieldParser
    {
        private int _currentTokenIndex { get; set; } = 0;

        public FieldInstruction Parse(string fieldCode)
        {
            _currentTokenIndex = 0;
            if (string.IsNullOrEmpty(fieldCode))
            {
                throw new Exception("Failed to parse FieldInstruction: empty or null input");
            }

            IEnumerable<FieldToken> tokenEnumerable = FieldLexer.Tokenize(fieldCode);
            List<FieldToken> tokens = tokenEnumerable.ToList();

            if (tokens.Count == 0)
            {
                throw new Exception(
                    "Failed to parse FieldInstruction: could not find instruction name"
                );
            }

            FieldInstruction? parsed = TryParseInstruction(tokens);
            if (parsed == null)
            {
                throw new Exception("Failed to parse FieldInstruction");
            }

            return parsed;
        }

        public FieldInstruction? TryParse(string fieldCode)
        {
            _currentTokenIndex = 0;
            if (string.IsNullOrEmpty(fieldCode))
            {
                return null;
            }

            IEnumerable<FieldToken> tokenEnumerable = FieldLexer.Tokenize(fieldCode);
            List<FieldToken> tokens = tokenEnumerable.ToList();

            if (tokens.Count == 0)
            {
                return null;
            }

            return TryParseInstruction(tokens);
        }

        public FieldInstruction? TryParseFiltered(string fieldCode, HashSet<string> keywordFilter)
        {
            _currentTokenIndex = 0;
            if (string.IsNullOrEmpty(fieldCode))
            {
                return null;
            }

            IEnumerable<FieldToken> tokenEnumerable = FieldLexer.Tokenize(fieldCode);
            List<FieldToken> tokens = new List<FieldToken>();

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

        private FieldInstruction? TryParseInstruction(List<FieldToken> tokens)
        {
            // Find the instruction keyword (skip any leading left brace and whitespace).
            FieldToken? keywordToken = GetNextNonWhitespaceToken(tokens);
            bool startedWithBrace = false;
            if (keywordToken != null && keywordToken.Type == FieldTokenType.LeftBrace)
            {
                startedWithBrace = true;
                _currentTokenIndex++; // consume '{'
                keywordToken = GetNextNonWhitespaceToken(tokens);
            }
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
                        if (nestedInstruction is not null)
                        {
                            instruction.Arguments.Add(
                                new FieldArgument(FieldArgumentType.NestedField, nestedInstruction)
                            );
                        }
                        break;
                }
            }

            bool consumedRightBrace = false;
            // Consume the closing brace for the current scope.
            if (
                _currentTokenIndex < tokens.Count
                && tokens[_currentTokenIndex].Type == FieldTokenType.RightBrace
            )
            {
                _currentTokenIndex++;
                consumedRightBrace = true;
            }

            // If an opening brace started this instruction but no matching closing brace was found before EOF, treat as invalid.
            if (startedWithBrace && !consumedRightBrace)
            {
                return null;
            }

            return instruction;
        }

        private FieldToken? GetNextNonWhitespaceToken(List<FieldToken> tokens)
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
