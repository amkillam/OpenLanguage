using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed QUOTE field instruction.
    /// Retrieves the text specified by text in field-argument. This text can include any other fields except `AUTONUM`, `AUTONUMLGL`, `AUTONUMOUT`, and `SYMBOL`.
    /// </summary>
    public class QuoteFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The raw text content that may contain sub-field instructions.
        /// </summary>
        public string QuoteText { get; set; }

        /// <summary>
        /// List of sub-field instructions found within the quote text.
        /// </summary>
        public List<FieldInstruction> SubFields { get; set; } = new List<FieldInstruction>();

        /// <summary>
        /// Whether this quote contains sub-field instructions.
        /// </summary>
        public bool ContainsSubFields => SubFields.Count > 0;

        /// <summary>
        /// Initializes a new instance of the QuoteFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public QuoteFieldInstruction(FieldInstruction source)
            : base(source)
        {
            QuoteText = string.Empty;
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "QUOTE")
            {
                throw new ArgumentException($"Expected QUOTE field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument) - required
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            QuoteText = firstNonSwitch?.Value?.ToString() ?? string.Empty;

            // Parse sub-field instructions within the quote text
            ParseSubFields();
        }

        /// <summary>
        /// Parses sub-field instructions within the quote text.
        /// Note: QUOTE fields can contain other fields except AUTONUM, AUTONUMLGL, AUTONUMOUT, and SYMBOL.
        /// </summary>
        private void ParseSubFields()
        {
            if (!string.IsNullOrEmpty(QuoteText))
            {
                string[] forbiddenFields = { "AUTONUM", "AUTONUMLGL", "AUTONUMOUT", "SYMBOL" };

                // Parse nested field instructions recursively
                SubFields = ExtractNestedFields(QuoteText, forbiddenFields);
            }
        }

        /// <summary>
        /// Extracts nested field instructions from text, excluding forbidden field types.
        /// </summary>
        /// <param name="text">The text to parse for nested fields.</param>
        /// <param name="forbiddenFields">Array of forbidden field instruction names.</param>
        /// <returns>List of extracted field instructions.</returns>
        private List<FieldInstruction> ExtractNestedFields(string text, string[] forbiddenFields)
        {
            List<FieldInstruction> extractedFields = new List<FieldInstruction>();

            // Parse nested field instructions using comprehensive field parser
            int position = 0;
            while (position < text.Length)
            {
                // Look for field instruction patterns
                FieldInstruction? nestedField = ParseNextFieldInstruction(
                    text,
                    ref position,
                    forbiddenFields
                );
                if (nestedField != null)
                {
                    extractedFields.Add(nestedField);
                }
                else
                {
                    position++;
                }
            }

            return extractedFields;
        }

        /// <summary>
        /// Parses the next field instruction starting at the current position.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="position">The current position (will be updated).</param>
        /// <param name="forbiddenFields">Array of forbidden field instruction names.</param>
        /// <returns>The parsed field instruction, or null if none found.</returns>
        private FieldInstruction? ParseNextFieldInstruction(
            string text,
            ref int position,
            string[] forbiddenFields
        )
        {
            // Look for field instruction keywords
            string[] commonFields =
            {
                "IF",
                "DATE",
                "TIME",
                "PAGE",
                "NUMPAGES",
                "FILENAME",
                "AUTHOR",
                "TITLE",
            };

            foreach (string fieldType in commonFields)
            {
                if (position + fieldType.Length <= text.Length)
                {
                    string candidate = text.Substring(position, fieldType.Length);
                    if (candidate.Equals(fieldType, StringComparison.OrdinalIgnoreCase))
                    {
                        // Check if this is forbidden
                        if (
                            Array.Exists(
                                forbiddenFields,
                                f => f.Equals(fieldType, StringComparison.OrdinalIgnoreCase)
                            )
                        )
                        {
                            throw new ArgumentException(
                                $"QUOTE field cannot contain {fieldType} field instruction"
                            );
                        }

                        // Found a valid field instruction - parse its arguments
                        FieldInstruction? nestedField = ParseFieldInstructionAt(
                            text,
                            position,
                            fieldType
                        );
                        if (nestedField != null)
                        {
                            position += nestedField.ToString().Length;
                            return nestedField;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Parses a field instruction starting at the specified position.
        /// </summary>
        /// <param name="text">The text containing the field.</param>
        /// <param name="startPosition">The starting position of the field instruction.</param>
        /// <param name="fieldType">The field type that was identified.</param>
        /// <returns>The parsed field instruction.</returns>
        private FieldInstruction? ParseFieldInstructionAt(
            string text,
            int startPosition,
            string fieldType
        )
        {
            // Extract the field instruction and its arguments
            int endPosition = FindFieldInstructionEnd(text, startPosition);
            if (endPosition == -1)
            {
                return null;
            }

            string fieldText = text.Substring(startPosition, endPosition - startPosition + 1);

            // Create a basic FieldInstruction
            FieldInstruction field = new FieldInstruction(fieldType);

            // Parse arguments from the field text
            ParseFieldArguments(fieldText, field);

            return field;
        }

        /// <summary>
        /// Finds the end position of a field instruction.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="startPosition">The starting position.</param>
        /// <returns>The end position, or -1 if not found.</returns>
        private int FindFieldInstructionEnd(string text, int startPosition)
        {
            // Simple heuristic: find the next space, quote, or end of text that would terminate the field
            int position = startPosition;
            bool inQuotes = false;
            int depth = 0;

            while (position < text.Length)
            {
                char current = text[position];

                if (current == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (!inQuotes)
                {
                    if (current == '(' || current == '{')
                    {
                        depth++;
                    }
                    else if (current == ')' || current == '}')
                    {
                        depth--;
                    }
                    else if (
                        (current == ' ' || current == '\t' || current == '\n')
                        && depth == 0
                        // Check if this space terminates the field or is part of arguments
                        && IsFieldTerminator(text, position)
                    )
                    {
                        return position - 1;
                    }
                }

                position++;
            }

            return text.Length - 1;
        }

        /// <summary>
        /// Determines if a position represents a field terminator.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <param name="position">The position to check.</param>
        /// <returns>True if this position terminates the field.</returns>
        private bool IsFieldTerminator(string text, int position)
        {
            // Look ahead to see if the next non-whitespace character starts a new field or regular text
            int nextPos = position + 1;
            while (nextPos < text.Length && char.IsWhiteSpace(text[nextPos]))
            {
                nextPos++;
            }

            if (nextPos >= text.Length)
            {
                return true;
            }

            // Check if the next text looks like a field instruction or regular text
            string remaining = text.Substring(nextPos);
            string[] fieldKeywords =
            {
                "IF",
                "DATE",
                "TIME",
                "PAGE",
                "NUMPAGES",
                "FILENAME",
                "AUTHOR",
                "TITLE",
            };

            foreach (string keyword in fieldKeywords)
            {
                if (remaining.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Parses field arguments from field text and populates the field instruction.
        /// </summary>
        /// <param name="fieldText">The complete field text.</param>
        /// <param name="field">The field instruction to populate.</param>
        private void ParseFieldArguments(string fieldText, FieldInstruction field)
        {
            // Split the field text into tokens, respecting quotes and switches
            string[] tokens = TokenizeFieldText(fieldText);

            for (int i = 1; i < tokens.Length; i++) // Skip the first token (field name)
            {
                string token = tokens[i].Trim();
                if (!string.IsNullOrEmpty(token))
                {
                    FieldArgumentType argType = DetermineArgumentType(token);
                    FieldArgument arg = new FieldArgument(argType, token);
                    field.Arguments.Add(arg);
                }
            }
        }

        /// <summary>
        /// Tokenizes field text into individual arguments, respecting quotes.
        /// </summary>
        /// <param name="fieldText">The field text to tokenize.</param>
        /// <returns>Array of tokens.</returns>
        private string[] TokenizeFieldText(string fieldText)
        {
            List<string> tokens = new List<string>();
            bool inQuotes = false;
            string currentToken = string.Empty;

            for (int i = 0; i < fieldText.Length; i++)
            {
                char c = fieldText[i];

                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    currentToken += c;
                }
                else if (char.IsWhiteSpace(c) && !inQuotes)
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }
                }
                else
                {
                    currentToken += c;
                }
            }

            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens.ToArray();
        }

        /// <summary>
        /// Determines the argument type for a token.
        /// </summary>
        /// <param name="token">The token to analyze.</param>
        /// <returns>The argument type.</returns>
        private FieldArgumentType DetermineArgumentType(string token)
        {
            if (!string.IsNullOrEmpty(token) && token[0] == '\\')
            {
                return FieldArgumentType.Switch;
            }
            if (
                !string.IsNullOrEmpty(token)
                && token.Length >= 2
                && token[0] == '"'
                && token[token.Length - 1] == '"'
            )
            {
                return FieldArgumentType.StringLiteral;
            }
            int parsedInt;
            double parsedDouble;
            if (
                int.TryParse(
                    token,
                    System.Globalization.NumberStyles.Integer,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out parsedInt
                )
                || double.TryParse(
                    token,
                    System.Globalization.NumberStyles.Float
                        | System.Globalization.NumberStyles.AllowThousands,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out parsedDouble
                )
            )
            {
                return FieldArgumentType.Number;
            }
            return FieldArgumentType.Identifier;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            if (!string.IsNullOrEmpty(QuoteText))
            {
                // Always quote the text since it may contain complex sub-expressions
                result.Add($"\"{QuoteText}\"");
            }

            return string.Join(" ", result);
        }
    }
}
