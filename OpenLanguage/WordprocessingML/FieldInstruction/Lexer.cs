using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    /// <summary>
    /// Defines the types of tokens that can be found in a Word field code.
    /// </summary>
    public enum FieldTokenType
    {
        Unknown,
        Keyword,
        Identifier,
        StringLiteral,
        Switch,
        Whitespace,
        LeftBrace, // {
        RightBrace, // }
        EndOfField,
    }

    /// <summary>
    /// Represents a token extracted from a field code string by the lexer.
    /// </summary>
    public class FieldToken
    {
        public FieldTokenType Type { get; }
        public string Value { get; }
        public int StartIndex { get; }

        public FieldToken(FieldTokenType type, string value, int startIndex)
        {
            Type = type;
            Value = value;
            StartIndex = startIndex;
        }

        public override string ToString() => $"[{Type}] '{Value}'";
    }

    /// <summary>
    /// A lexer for tokenizing Word field codes into a stream of tokens.
    /// </summary>
    public static class FieldLexer
    {
        public static IEnumerable<FieldToken> Tokenize(string fieldCode)
        {
            if (!string.IsNullOrEmpty(fieldCode))
            {
                int currentIndex = 0;
                bool isFirstToken = true;

                while (currentIndex < fieldCode.Length)
                {
                    char currentChar = fieldCode[currentIndex];

                    if (char.IsWhiteSpace(currentChar))
                    {
                        int startIndex = currentIndex;
                        while (
                            currentIndex < fieldCode.Length
                            && char.IsWhiteSpace(fieldCode[currentIndex])
                        )
                        {
                            currentIndex++;
                        }
                        yield return (
                            new FieldToken(
                                FieldTokenType.Whitespace,
                                fieldCode.Substring(startIndex, currentIndex - startIndex),
                                startIndex
                            )
                        );
                        continue;
                    }

                    if (currentChar == '{')
                    {
                        yield return (new FieldToken(FieldTokenType.LeftBrace, "{", currentIndex));
                        currentIndex++;
                        isFirstToken = true; // The next token inside the brace is a keyword.
                        continue;
                    }

                    if (currentChar == '}')
                    {
                        yield return (new FieldToken(FieldTokenType.RightBrace, "}", currentIndex));
                        currentIndex++;
                        continue;
                    }

                    if (currentChar == '"')
                    {
                        int startIndex = currentIndex;
                        currentIndex++; // Skip opening quote
                        StringBuilder sb = new StringBuilder();
                        while (currentIndex < fieldCode.Length)
                        {
                            if (
                                fieldCode[currentIndex] == '\\'
                                && currentIndex + 1 < fieldCode.Length
                            )
                            {
                                // Handle escaped characters
                                char nextChar = fieldCode[currentIndex + 1];
                                if (nextChar == '"' || nextChar == '\\') // Common escaped characters
                                {
                                    sb.Append(nextChar);
                                    currentIndex += 2; // Consume both backslash and escaped char
                                    continue;
                                }
                                // If not a recognized escape sequence, treat backslash as literal
                                sb.Append(currentChar);
                                currentIndex++;
                                continue;
                            }
                            if (fieldCode[currentIndex] == '"')
                            {
                                // End of string literal
                                currentIndex++; // Consume closing quote
                                break;
                            }
                            sb.Append(fieldCode[currentIndex++]);
                        }
                        yield return (
                            new FieldToken(FieldTokenType.StringLiteral, sb.ToString(), startIndex)
                        );
                        isFirstToken = false;
                        continue;
                    }

                    if (currentChar == '\\')
                    {
                        int startIndex = currentIndex;
                        currentIndex++; // Consume '\'
                        if (
                            currentIndex < fieldCode.Length
                            && char.IsLetterOrDigit(fieldCode[currentIndex])
                        )
                        {
                            currentIndex++; // Consume switch char
                        }

                        yield return (
                            new FieldToken(
                                FieldTokenType.Switch,
                                fieldCode.Substring(startIndex, currentIndex - startIndex),
                                startIndex
                            )
                        );
                        isFirstToken = false;
                        continue;
                    }

                    if (char.IsLetter(currentChar) || currentChar == '_')
                    {
                        int startIndex = currentIndex;
                        while (
                            currentIndex < fieldCode.Length
                            && (
                                char.IsLetterOrDigit(fieldCode[currentIndex])
                                || fieldCode[currentIndex] == '_'
                            )
                        )
                        {
                            currentIndex++;
                        }
                        string value = fieldCode.Substring(startIndex, currentIndex - startIndex);
                        FieldTokenType type = isFirstToken
                            ? FieldTokenType.Keyword
                            : FieldTokenType.Identifier;
                        yield return (new FieldToken(type, value, startIndex));
                        isFirstToken = false;
                        continue;
                    }

                    // Fallback for any other characters (e.g., operators in formulas)

                    yield return (
                        new FieldToken(
                            FieldTokenType.Identifier,
                            currentChar.ToString(),
                            currentIndex
                        )
                    );
                    currentIndex++;
                    isFirstToken = false;
                }
                yield return (
                    new FieldToken(FieldTokenType.EndOfField, string.Empty, fieldCode.Length)
                );
            }
            yield break;
        }
    }
}
