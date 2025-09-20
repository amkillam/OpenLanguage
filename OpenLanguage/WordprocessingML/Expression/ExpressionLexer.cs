using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using OpenLanguage.WordprocessingML.Operators;

namespace OpenLanguage.WordprocessingML.Expression
{
    /// <summary>
    /// Represents a parsed expression.
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// The raw expression text.
        /// </summary>
        public string RawText { get; set; } = string.Empty;

        /// <summary>
        /// The parsed tokens from the expression.
        /// </summary>
        public List<ExpressionToken> Tokens { get; set; } = new List<ExpressionToken>();

        /// <summary>
        /// The left operand for binary expressions.
        /// </summary>
        public string? LeftOperand { get; set; }

        /// <summary>
        /// The operator for binary expressions.
        /// </summary>
        public ComparisonOperator? Operator { get; set; }

        /// <summary>
        /// The right operand for binary expressions.
        /// </summary>
        public string? RightOperand { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Expression() { }

        /// <summary>
        /// Constructor for creating a expression from raw text.
        /// </summary>
        public Expression(string? rawText)
        {
            RawText = rawText ?? string.Empty;
            // Parse the expression to populate tokens and binary expression properties
            Expression parsed = ExpressionLexer.ParseExpression(rawText ?? string.Empty);
            Tokens = parsed.Tokens;
            LeftOperand = parsed.LeftOperand;
            Operator = parsed.Operator;
            RightOperand = parsed.RightOperand;
        }

        /// <summary>
        /// Constructor for creating a binary expression.
        /// </summary>
        public Expression(string? leftOperand, ComparisonOperator op, string? rightOperand)
        {
            LeftOperand = leftOperand;
            Operator = op;
            RightOperand = rightOperand;
            RawText =
                $"{leftOperand ?? string.Empty} {GetOperatorString(op)} {rightOperand ?? string.Empty}";

            // Create tokens for the binary expression
            Tokens = new List<ExpressionToken>();
            if (!string.IsNullOrEmpty(leftOperand))
            {
                Tokens.Add(
                    new ExpressionToken { Type = ExpressionTokenType.String, Value = leftOperand }
                );
            }
            Tokens.Add(
                new ExpressionToken
                {
                    Type = ExpressionTokenType.Operator,
                    Value = GetOperatorString(op),
                }
            );
            if (!string.IsNullOrEmpty(rightOperand))
            {
                Tokens.Add(
                    new ExpressionToken { Type = ExpressionTokenType.String, Value = rightOperand }
                );
            }
        }

        /// <summary>
        /// Gets the string representation of a comparison operator.
        /// </summary>
        private static string GetOperatorString(ComparisonOperator op) =>
            op switch
            {
                ComparisonOperator.Equal => "=",
                ComparisonOperator.NotEqual => "<>",
                ComparisonOperator.LessThan => "<",
                ComparisonOperator.LessThanOrEqual => "<=",
                ComparisonOperator.GreaterThan => ">",
                ComparisonOperator.GreaterThanOrEqual => ">=",
                _ => "=",
            };

        /// <summary>
        /// Whether this expression contains merge field references.
        /// </summary>
        public bool ContainsMergeFields =>
            Tokens.Exists(t => t.Type == ExpressionTokenType.MergeField);

        /// <summary>
        /// Whether this expression is a literal value.
        /// </summary>
        public bool IsLiteral =>
            Tokens.Count == 1
            && (
                Tokens[0].Type == ExpressionTokenType.String
                || Tokens[0].Type == ExpressionTokenType.Number
            );

        /// <summary>
        /// Returns a string representation of this expression.
        /// </summary>
        public override string ToString()
        {
            // If we have binary expression properties set, use those
            if (LeftOperand != null || Operator != null || RightOperand != null)
            {
                string left = LeftOperand ?? string.Empty;
                string op = Operator.HasValue
                    ? ComparisonOperatorExtensions.OperatorToString(Operator.Value)
                    : string.Empty;
                string right = RightOperand ?? string.Empty;
                return $"{left} {op} {right}";
            }

            // Otherwise, use the raw text or reconstruct from tokens
            if (!string.IsNullOrEmpty(RawText))
            {
                return RawText;
            }

            // Fallback: reconstruct from tokens
            if (Tokens.Count > 0)
            {
                return string.Join(" ", Tokens.Select(t => t.Value ?? string.Empty));
            }

            return string.Empty;
        }
    }

    /// <summary>
    /// Represents a token within a expression.
    /// </summary>
    public class ExpressionToken
    {
        /// <summary>
        /// The type of token.
        /// </summary>
        public ExpressionTokenType Type { get; set; }

        /// <summary>
        /// The token value.
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// The original position in the source text.
        /// </summary>
        public int Position { get; set; }
    }

    /// <summary>
    /// Types of tokens that can appear in expressions.
    /// </summary>
    public enum ExpressionTokenType
    {
        /// <summary>
        /// A string literal (quoted text).
        /// </summary>
        String,

        /// <summary>
        /// A numeric literal.
        /// </summary>
        Number,

        /// <summary>
        /// A merge field reference.
        /// </summary>
        MergeField,

        /// <summary>
        /// A comparison operator.
        /// </summary>
        Operator,

        /// <summary>
        /// An identifier or field name.
        /// </summary>
        Identifier,

        /// <summary>
        /// Whitespace.
        /// </summary>
        Whitespace,

        /// <summary>
        /// Unknown or unrecognized token.
        /// </summary>
        Unknown,
    }

    /// <summary>
    /// Lexer states for expression parsing.
    /// </summary>
    internal enum LexerState
    {
        Initial,
        InString,
        InNumber,
        InIdentifier,
        InOperator,
        InMergeField,
        InWhitespace,
    }

    /// <summary>
    /// Lexer for parsing expressions.
    /// </summary>
    public static class ExpressionLexer
    {
        /// <summary>
        /// Parses a expression string into a Expression object.
        /// </summary>
        /// <param name="expressionText">The expression text to parse.</param>
        /// <returns>A parsed Expression object.</returns>
        public static Expression Parse(string expressionText)
        {
            return ParseExpression(expressionText);
        }

        /// <summary>
        /// Parses a expression string into a Expression object.
        /// </summary>
        /// <param name="expressionText">The expression text to parse.</param>
        /// <returns>A parsed Expression object.</returns>
        public static Expression ParseExpression(string? expressionText)
        {
            if (string.IsNullOrEmpty(expressionText))
            {
                return new Expression { RawText = expressionText ?? string.Empty };
            }

            ValidateStringSyntax(expressionText);
            ValidateNumberFormats(expressionText);
            Expression expression = new Expression { RawText = expressionText };
            List<ExpressionToken> tokens = TokenizeExpression(expressionText);
            expression.Tokens = tokens;

            // Try to extract binary expression components for simple comparisons
            ExtractBinaryExpressionComponents(expression, tokens);

            return expression;
        }

        /// <summary>
        /// Attempts to extract binary expression components (left operand, operator, right operand) from tokens.
        /// </summary>
        private static void ExtractBinaryExpressionComponents(
            Expression expression,
            List<ExpressionToken> tokens
        )
        {
            // Look for simple binary expressions: operand operator operand
            if (tokens.Count >= 3)
            {
                // Find the first operator token
                ExpressionToken? operatorToken = null;
                int operatorIndex = -1;

                for (int i = 0; i < tokens.Count; i++)
                {
                    if (tokens[i].Type == ExpressionTokenType.Operator)
                    {
                        operatorToken = tokens[i];
                        operatorIndex = i;
                        break;
                    }
                }

                if (operatorToken != null && operatorIndex > 0 && operatorIndex < tokens.Count - 1)
                {
                    // Extract left operand (all tokens before the operator)
                    List<string> leftTokens = new List<string>();
                    for (int i = 0; i < operatorIndex; i++)
                    {
                        leftTokens.Add(tokens[i].Value ?? string.Empty);
                    }
                    expression.LeftOperand = string.Join(" ", leftTokens).Trim();

                    // Extract operator
                    if (TryParseOperator(operatorToken.Value, out ComparisonOperator op))
                    {
                        expression.Operator = op;
                    }

                    // Extract right operand (all tokens after the operator)
                    List<string> rightTokens = new List<string>();
                    for (int i = operatorIndex + 1; i < tokens.Count; i++)
                    {
                        rightTokens.Add(tokens[i].Value ?? string.Empty);
                    }
                    expression.RightOperand = string.Join(" ", rightTokens).Trim();
                }
            }
        }

        /// <summary>
        /// Tries to parse a string into a comparison operator.
        /// </summary>
        private static bool TryParseOperator(string? operatorText, out ComparisonOperator op)
        {
            op = ComparisonOperator.Equal;

            if (string.IsNullOrEmpty(operatorText))
            {
                return false;
            }

            switch (operatorText.Trim())
            {
                case "=":
                    op = ComparisonOperator.Equal;
                    return true;
                case "<>":
                    op = ComparisonOperator.NotEqual;
                    return true;
                case "<":
                    op = ComparisonOperator.LessThan;
                    return true;
                case "<=":
                    op = ComparisonOperator.LessThanOrEqual;
                    return true;
                case ">":
                    op = ComparisonOperator.GreaterThan;
                    return true;
                case ">=":
                    op = ComparisonOperator.GreaterThanOrEqual;
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Tokenizes an expression string into individual tokens using a character-by-character state machine.
        /// </summary>
        /// <param name="text">The text to tokenize.</param>
        /// <returns>A list of expression tokens.</returns>
        public static List<ExpressionToken> TokenizeExpression(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<ExpressionToken>();
            }

            List<ExpressionToken> tokens = new List<ExpressionToken>();
            int position = 0;

            while (position < text.Length)
            {
                char currentChar = text[position];
                int tokenStart = position;

                if (char.IsWhiteSpace(currentChar))
                {
                    StringBuilder sb = new StringBuilder();
                    while (position < text.Length && char.IsWhiteSpace(text[position]))
                    {
                        sb.Append(text[position]);
                        position++;
                    }
                    tokens.Add(
                        new ExpressionToken
                        {
                            Type = ExpressionTokenType.Whitespace,
                            Value = sb.ToString(),
                            Position = tokenStart,
                        }
                    );
                    continue;
                }

                if (currentChar == '[' || currentChar == '`')
                {
                    char startChar = currentChar;
                    char endChar = (startChar == '[') ? ']' : '`';
                    StringBuilder sb = new StringBuilder();
                    position++; // Skip opening delimiter
                    while (position < text.Length && text[position] != endChar)
                    {
                        sb.Append(text[position]);
                        position++;
                    }
                    if (position < text.Length && text[position] == endChar)
                    {
                        position++; // Skip closing delimiter
                    }
                    tokens.Add(
                        new ExpressionToken
                        {
                            Type = ExpressionTokenType.Identifier,
                            Value = sb.ToString(),
                            Position = tokenStart,
                        }
                    );
                    continue;
                }

                if (currentChar == '"' || currentChar == '\'')
                {
                    char quoteChar = currentChar;
                    StringBuilder sb = new StringBuilder();
                    position++; // Skip opening quote
                    while (position < text.Length)
                    {
                        if (
                            text[position] == quoteChar
                            && position + 1 < text.Length
                            && text[position + 1] == quoteChar
                        )
                        {
                            // Escaped quote
                            sb.Append(quoteChar);
                            position += 2;
                            continue;
                        }

                        if (text[position] == '\\' && position + 1 < text.Length)
                        {
                            char nextChar = text[position + 1];
                            if (nextChar == quoteChar || nextChar == '\\')
                            {
                                sb.Append(nextChar);
                                position += 2;
                            }
                            else
                            {
                                sb.Append(text[position]);
                                position++;
                            }
                        }
                        else if (text[position] == quoteChar)
                        {
                            position++; // Skip closing quote
                            break;
                        }
                        else
                        {
                            sb.Append(text[position]);
                            position++;
                        }
                    }
                    tokens.Add(
                        new ExpressionToken
                        {
                            Type = ExpressionTokenType.String,
                            Value = sb.ToString(),
                            Position = tokenStart,
                        }
                    );
                    continue;
                }

                if (IsOperatorStart(currentChar))
                {
                    string op = currentChar.ToString();
                    if (
                        position + 1 < text.Length
                        && IsOperatorContinuation(op, text[position + 1])
                    )
                    {
                        op += text[position + 1];
                        position++;
                    }
                    tokens.Add(
                        new ExpressionToken
                        {
                            Type = ExpressionTokenType.Operator,
                            Value = op,
                            Position = tokenStart,
                        }
                    );
                    position++;
                    continue;
                }

                // Numeric literal (supports optional sign, hex 0x, binary 0b, decimals with exponent)
                if (char.IsDigit(currentChar) || currentChar == '+' || currentChar == '-')
                {
                    int startIndex = position;

                    // Determine if a leading + or - is a numeric sign (only when appropriate)
                    bool isLeadingSign = false;
                    if (
                        (currentChar == '+' || currentChar == '-')
                        && position + 1 < text.Length
                        && char.IsDigit(text[position + 1])
                    )
                    {
                        // Look back for previous non-whitespace character
                        int prevIndex = startIndex - 1;
                        while (prevIndex >= 0 && char.IsWhiteSpace(text[prevIndex]))
                        {
                            prevIndex--;
                        }
                        // Allow sign at start of string or after typical assignment/grouping characters
                        bool allowSignedNumber =
                            prevIndex < 0
                            || text[prevIndex] == '='
                            || text[prevIndex] == '('
                            || text[prevIndex] == ','
                            || text[prevIndex] == ':';
                        if (allowSignedNumber)
                        {
                            isLeadingSign = true;
                        }
                    }

                    if (!char.IsDigit(currentChar) && !isLeadingSign)
                    {
                        // Not a number start; fall through to other token kinds
                    }
                    else
                    {
                        int scanPos = position;
                        if (isLeadingSign)
                        {
                            scanPos++; // skip sign for parsing core number
                        }

                        // Hexadecimal: 0x... or 0X...
                        if (
                            scanPos + 1 < text.Length
                            && text[scanPos] == '0'
                            && (text[scanPos + 1] == 'x' || text[scanPos + 1] == 'X')
                        )
                        {
                            int hexPos = scanPos + 2;
                            while (hexPos < text.Length)
                            {
                                char hc = text[hexPos];
                                bool isHex =
                                    (hc >= '0' && hc <= '9')
                                    || (hc >= 'a' && hc <= 'f')
                                    || (hc >= 'A' && hc <= 'F');
                                if (!isHex)
                                {
                                    break;
                                }
                                hexPos++;
                            }
                            if (hexPos > scanPos + 2)
                            {
                                string hexToken = text.Substring(startIndex, hexPos - startIndex);
                                tokens.Add(
                                    new ExpressionToken
                                    {
                                        Type = ExpressionTokenType.Number,
                                        Value = hexToken,
                                        Position = tokenStart,
                                    }
                                );
                                position = hexPos;
                                continue;
                            }
                        }

                        // Binary: 0b... or 0B...
                        if (
                            scanPos + 1 < text.Length
                            && text[scanPos] == '0'
                            && (text[scanPos + 1] == 'b' || text[scanPos + 1] == 'B')
                        )
                        {
                            int binPos = scanPos + 2;
                            while (binPos < text.Length)
                            {
                                char bc = text[binPos];
                                if (bc != '0' && bc != '1')
                                {
                                    break;
                                }
                                binPos++;
                            }
                            if (binPos > scanPos + 2)
                            {
                                string binToken = text.Substring(startIndex, binPos - startIndex);
                                tokens.Add(
                                    new ExpressionToken
                                    {
                                        Type = ExpressionTokenType.Number,
                                        Value = binToken,
                                        Position = tokenStart,
                                    }
                                );
                                position = binPos;
                                continue;
                            }
                        }

                        // Decimal (with optional fractional part and exponent)
                        int decPos = scanPos;

                        // Integral part
                        while (decPos < text.Length && char.IsDigit(text[decPos]))
                        {
                            decPos++;
                        }

                        // Fractional part
                        if (
                            decPos < text.Length
                            && text[decPos] == '.'
                            && decPos + 1 < text.Length
                            && char.IsDigit(text[decPos + 1])
                        )
                        {
                            decPos++; // consume '.'
                            while (decPos < text.Length && char.IsDigit(text[decPos]))
                            {
                                decPos++;
                            }
                        }

                        // Exponent part: E[+/-]digits or e[+/-]digits
                        if (decPos < text.Length && (text[decPos] == 'e' || text[decPos] == 'E'))
                        {
                            int expStart = decPos;
                            int tempPos = decPos + 1;
                            if (
                                tempPos < text.Length
                                && (text[tempPos] == '+' || text[tempPos] == '-')
                            )
                            {
                                tempPos++;
                            }
                            int digitStart = tempPos;
                            while (tempPos < text.Length && char.IsDigit(text[tempPos]))
                            {
                                tempPos++;
                            }
                            if (tempPos > digitStart)
                            {
                                // Valid exponent; include it
                                decPos = tempPos;
                            }
                            // else: leave exponent out; will be tokenized separately and validated later
                        }

                        // If we consumed at least one digit (or valid hex/binary covered earlier), emit number
                        if (decPos > scanPos)
                        {
                            string numToken = text.Substring(startIndex, decPos - startIndex);
                            tokens.Add(
                                new ExpressionToken
                                {
                                    Type = ExpressionTokenType.Number,
                                    Value = numToken,
                                    Position = tokenStart,
                                }
                            );
                            position = decPos;
                            continue;
                        }
                    }
                }

                if (char.IsLetter(currentChar) || currentChar == '_')
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(currentChar);
                    position++;
                    while (
                        position < text.Length
                        && (
                            char.IsLetterOrDigit(text[position])
                            || text[position] == '_'
                            || text[position] == '$'
                            || text[position] == '@'
                            || text[position] == '.'
                        )
                    )
                    {
                        sb.Append(text[position]);
                        position++;
                    }
                    tokens.Add(
                        new ExpressionToken
                        {
                            Type = ExpressionTokenType.Identifier,
                            Value = sb.ToString(),
                            Position = tokenStart,
                        }
                    );
                    continue;
                }

                if (currentChar == '«')
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(currentChar);
                    position++;
                    while (position < text.Length)
                    {
                        sb.Append(text[position]);
                        if (text[position] == '»')
                        {
                            position++;
                            break;
                        }
                        position++;
                    }
                    tokens.Add(
                        new ExpressionToken
                        {
                            Type = ExpressionTokenType.MergeField,
                            Value = sb.ToString(),
                            Position = tokenStart,
                        }
                    );
                    continue;
                }

                // Unknown token
                tokens.Add(
                    new ExpressionToken
                    {
                        Type = ExpressionTokenType.Unknown,
                        Value = currentChar.ToString(),
                        Position = position,
                    }
                );
                position++;
            }

            return tokens;
        }

        /// <summary>
        /// Determines if a character can start an operator.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>True if the character can start an operator.</returns>
        private static bool IsOperatorStart(char c)
        {
            return c == '<' || c == '>' || c == '=';
        }

        /// <summary>
        /// Determines if a character can continue the current operator.
        /// </summary>
        /// <param name="currentOperator">The current operator being built.</param>
        /// <param name="nextChar">The next character.</param>
        /// <returns>True if the character continues the operator.</returns>
        private static bool IsOperatorContinuation(string currentOperator, char nextChar)
        {
            return currentOperator switch
            {
                "<" => nextChar == '=' || nextChar == '>',
                ">" => nextChar == '=',
                _ => false,
            };
        }

        // Validation for string literal syntax expected by tests
        private static void ValidateStringSyntax(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            bool inString = false;
            char quoteChar = '\0';
            int i = 0;
            int length = text.Length;

            while (i < length)
            {
                char c = text[i];

                if (!inString)
                {
                    if (c == '"' || c == '\'')
                    {
                        inString = true;
                        quoteChar = c;
                    }
                    i++;
                    continue;
                }

                // Inside a string literal
                if (c == '\\')
                {
                    if (i + 1 < length)
                    {
                        char next = text[i + 1];
                        if (next == quoteChar || next == '\\')
                        {
                            i += 2;
                            continue;
                        }
                    }
                    i++;
                    continue;
                }

                if (c == quoteChar)
                {
                    // Handle doubled-quote escape (e.g., "" inside a " string or '' inside a ' string)
                    if (i + 1 < length && text[i + 1] == quoteChar)
                    {
                        i += 2;
                        continue;
                    }

                    // Close string
                    inString = false;
                    quoteChar = '\0';
                    i++;
                    continue;
                }

                i++;
            }

            if (inString)
            {
                throw new FormatException("Unterminated string literal in expression.");
            }
        }

        // Validation for numeric formats expected by tests
        private static void ValidateNumberFormats(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            string masked = MaskQuotedSegments(text);

            // Multiple decimal points in a single literal (e.g., 123.45.67)
            if (Regex.IsMatch(masked, @"\b\d+\.\d+\.\d+\b"))
            {
                throw new FormatException("Invalid number format: multiple decimal points.");
            }

            // Incomplete exponent (e.g., 123E or 123E+)
            // Match numbers where an exponent indicator is present but not followed by optional sign and at least one digit
            if (Regex.IsMatch(masked, @"\b\d+(?:\.\d+)?[eE](?![+-]?\d+)"))
            {
                throw new FormatException("Invalid number format: incomplete exponent.");
            }

            // Missing mantissa before exponent (e.g., .E5)
            if (Regex.IsMatch(masked, @"(?<!\d)\.[eE][+-]?\d+"))
            {
                throw new FormatException(
                    "Invalid number format: missing mantissa before exponent."
                );
            }
        }

        private static string MaskQuotedSegments(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            bool inQuotes = false;
            char quoteChar = '\0';

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (inQuotes)
                {
                    if (c == '\\' && i + 1 < text.Length)
                    {
                        // Replace escaped sequence with spaces to preserve indices
                        sb.Append(' ');
                        i++;
                        sb.Append(' ');
                        continue;
                    }

                    if (c == quoteChar)
                    {
                        inQuotes = false;
                        sb.Append(' ');
                        continue;
                    }

                    sb.Append(' ');
                }
                else
                {
                    if (c == '"' || c == '\'')
                    {
                        inQuotes = true;
                        quoteChar = c;
                        sb.Append(' ');
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            return sb.ToString();
        }
    }
}
