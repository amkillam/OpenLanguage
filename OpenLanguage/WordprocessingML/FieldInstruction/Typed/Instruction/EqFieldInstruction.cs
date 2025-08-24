using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents the primary switch types for EQ field instructions.
    /// </summary>
    public enum EqPrimarySwitch
    {
        /// <summary>
        /// \a - Produces an array using the argument values.
        /// </summary>
        Array,

        /// <summary>
        /// \b - Brackets the single element in appropriate size.
        /// </summary>
        Bracket,

        /// <summary>
        /// \d - Controls displacement of the next character.
        /// </summary>
        Displacement,

        /// <summary>
        /// \f - Creates a fraction with numerator and denominator.
        /// </summary>
        Fraction,

        /// <summary>
        /// \i - Creates an integral using specified symbol and elements.
        /// </summary>
        Integral,

        /// <summary>
        /// \l - Creates a list from arbitrary number of arguments.
        /// </summary>
        List,

        /// <summary>
        /// \o - Displays arguments on top of each other.
        /// </summary>
        Overlay,

        /// <summary>
        /// \r - Creates a radical (square root or nth root).
        /// </summary>
        Radical,

        /// <summary>
        /// \s - Creates subscript or superscript.
        /// </summary>
        Script,

        /// <summary>
        /// \x - Creates border segments around argument.
        /// </summary>
        Box,
    }

    /// <summary>
    /// Represents alignment options for array columns.
    /// </summary>
    public enum EqArrayAlignment
    {
        /// <summary>
        /// \ac - Centered alignment in each array column.
        /// </summary>
        Center,

        /// <summary>
        /// \al - Left alignment in each array column.
        /// </summary>
        Left,

        /// <summary>
        /// \ar - Right alignment in each array column.
        /// </summary>
        Right,
    }

    /// <summary>
    /// Represents overlay alignment options.
    /// </summary>
    public enum EqOverlayAlignment
    {
        /// <summary>
        /// \ac - Character box center alignment (default).
        /// </summary>
        Center,

        /// <summary>
        /// \al - Character box left alignment.
        /// </summary>
        Left,

        /// <summary>
        /// \ar - Character box right alignment.
        /// </summary>
        Right,
    }

    /// <summary>
    /// Represents integral symbol types.
    /// </summary>
    public enum EqIntegralSymbol
    {
        /// <summary>
        /// Default integral symbol.
        /// </summary>
        Default,

        /// <summary>
        /// \pr - Product symbol (Capital Pi).
        /// </summary>
        Product,

        /// <summary>
        /// \su - Summation symbol (Capital Sigma).
        /// </summary>
        Summation,
    }

    /// <summary>
    /// Represents a strongly-typed EQ field instruction.
    /// Computes the specified mathematical equation.
    /// </summary>
    public class EqFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The primary switch that determines the equation type.
        /// </summary>
        public EqPrimarySwitch PrimarySwitch { get; set; }

        /// <summary>
        /// The equation argument list (comma or semicolon separated).
        /// </summary>
        public List<string> ArgumentList { get; set; } = new List<string>();

        // Array switches (\a)
        /// <summary>
        /// Switch: \ac, \al, \ar
        /// Alignment in each array column.
        /// </summary>
        public EqArrayAlignment? ArrayAlignment { get; set; }

        /// <summary>
        /// Switch: \co field-argument
        /// Number of columns in the array (default is 1).
        /// </summary>
        public Int32? ColumnCount { get; set; }

        /// <summary>
        /// Switch: \hs field-argument
        /// Horizontal spacing between columns in points.
        /// </summary>
        public Int32? HorizontalSpacing { get; set; }

        /// <summary>
        /// Switch: \vs field-argument
        /// Vertical spacing between lines in points.
        /// </summary>
        public Int32? VerticalSpacing { get; set; }

        // Bracket switches (\b)
        /// <summary>
        /// Switch: \bc \ char
        /// Both left and right bracket character.
        /// </summary>
        public char? BothBracketCharacter { get; set; }

        /// <summary>
        /// Switch: \lc \ char
        /// Left bracket character.
        /// </summary>
        public char? LeftBracketCharacter { get; set; }

        /// <summary>
        /// Switch: \rc \ char
        /// Right bracket character.
        /// </summary>
        public char? RightBracketCharacter { get; set; }

        // Displacement switches (\d)
        /// <summary>
        /// Switch: \ba field-argument
        /// Backward displacement in points.
        /// </summary>
        public Int32? BackwardDisplacement { get; set; }

        /// <summary>
        /// Switch: \fo field-argument
        /// Forward displacement in points.
        /// </summary>
        public Int32? ForwardDisplacement { get; set; }

        /// <summary>
        /// Switch: \li
        /// Underlines the space up to the next character.
        /// </summary>
        public bool UnderlineSpace { get; set; }

        // Integral switches (\i)
        /// <summary>
        /// Switch: \fc \ char
        /// Fixed-height character for the symbol.
        /// </summary>
        public char? FixedHeightCharacter { get; set; }

        /// <summary>
        /// Switch: \in
        /// Inline format with limits to the right instead of above/below.
        /// </summary>
        public bool InlineFormat { get; set; }

        /// <summary>
        /// Switch: \pr, \su, or default
        /// Type of integral symbol to use.
        /// </summary>
        public EqIntegralSymbol? IntegralSymbol { get; set; }

        /// <summary>
        /// Switch: \vc \ char
        /// Variable-height character for the symbol.
        /// </summary>
        public char? VariableHeightCharacter { get; set; }

        // Overlay switches (\o)
        /// <summary>
        /// Switch: \ac, \al, \ar
        /// Alignment for overlay character boxes.
        /// </summary>
        public EqOverlayAlignment? OverlayAlignment { get; set; }

        // Script switches (\s)
        /// <summary>
        /// Switch: \ai field-argument
        /// Space above line in points (default 2).
        /// </summary>
        public Int32? SpaceAboveLine { get; set; }

        /// <summary>
        /// Switch: \di field-argument
        /// Space below line in points.
        /// </summary>
        public Int32? SpaceBelowLine { get; set; }

        /// <summary>
        /// Switch: \do field-argument
        /// Move argument below adjacent text by points (default 2).
        /// </summary>
        public Int32? MoveDown { get; set; }

        /// <summary>
        /// Switch: \up field-argument
        /// Move argument above adjacent text by points.
        /// </summary>
        public Int32? MoveUp { get; set; }

        // Box switches (\x)
        /// <summary>
        /// Switch: \bo
        /// Draw horizontal border below argument.
        /// </summary>
        public bool BorderBottom { get; set; }

        /// <summary>
        /// Switch: \le
        /// Draw vertical border to the left of argument.
        /// </summary>
        public bool BorderLeft { get; set; }

        /// <summary>
        /// Switch: \ri
        /// Draw vertical border to the right of argument.
        /// </summary>
        public bool BorderRight { get; set; }

        /// <summary>
        /// Switch: \to
        /// Draw horizontal border above argument.
        /// </summary>
        public bool BorderTop { get; set; }

        /// <summary>
        /// Initializes a new instance of the EqFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public EqFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "EQ")
            {
                throw new ArgumentException($"Expected EQ field, but got {Source.Instruction}");
            }

            // Parse primary switch (required)
            FieldArgument? primarySwitchArg = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Switch
            );
            if (primarySwitchArg == null)
            {
                throw new ArgumentException(
                    "EQ field requires a primary switch (\\a, \\b, \\d, \\f, \\i, \\l, \\o, \\r, \\s, or \\x)"
                );
            }

            string primarySwitchValue = primarySwitchArg.Value?.ToString() ?? string.Empty;
            PrimarySwitch = ParsePrimarySwitch(primarySwitchValue);

            // Parse argument list from parentheses
            string argumentListText = ExtractArgumentList();
            if (!string.IsNullOrEmpty(argumentListText))
            {
                ArgumentList = ParseArgumentList(argumentListText);
            }

            // Parse additional switches
            for (Int32 i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    ParseSwitch(switchValue, i);
                }
            }

            ValidateArguments();
        }

        /// <summary>
        /// Parses the primary switch value.
        /// </summary>
        private EqPrimarySwitch ParsePrimarySwitch(string switchValue)
        {
            return switchValue.ToLowerInvariant() switch
            {
                "\\a" => EqPrimarySwitch.Array,
                "\\b" => EqPrimarySwitch.Bracket,
                "\\d" => EqPrimarySwitch.Displacement,
                "\\f" => EqPrimarySwitch.Fraction,
                "\\i" => EqPrimarySwitch.Integral,
                "\\l" => EqPrimarySwitch.List,
                "\\o" => EqPrimarySwitch.Overlay,
                "\\r" => EqPrimarySwitch.Radical,
                "\\s" => EqPrimarySwitch.Script,
                "\\x" => EqPrimarySwitch.Box,
                _ => throw new ArgumentException($"Invalid EQ primary switch: {switchValue}"),
            };
        }

        /// <summary>
        /// Extracts the argument list from parentheses in the field instruction.
        /// </summary>
        private string ExtractArgumentList()
        {
            string fullText = string.Join(
                " ",
                Source.Arguments.Select(arg => arg.Value?.ToString() ?? string.Empty)
            );
            Int32 startIndex = fullText.IndexOf('(');
            if (startIndex == -1)
            {
                return string.Empty;
            }

            Int32 endIndex = fullText.LastIndexOf(')');
            if (endIndex == -1 || endIndex <= startIndex)
            {
                return string.Empty;
            }

            return fullText.Substring(startIndex + 1, endIndex - startIndex - 1).Trim();
        }

        /// <summary>
        /// Parses the comma or semicolon separated argument list.
        /// </summary>
        private List<string> ParseArgumentList(string argumentListText)
        {
            List<string> arguments = new List<string>();
            if (!string.IsNullOrWhiteSpace(argumentListText))
            {
                // Use comma as separator for decimal point implementations, semicolon for comma decimal implementations
                char separator = argumentListText.Contains(';') ? ';' : ',';
                string[] parts = argumentListText.Split(separator);

                foreach (string part in parts)
                {
                    string trimmedPart = part.Trim();
                    if (!string.IsNullOrEmpty(trimmedPart))
                    {
                        arguments.Add(trimmedPart);
                    }
                }
            }

            return arguments;
        }

        /// <summary>
        /// Parses individual switches and their arguments.
        /// </summary>
        private void ParseSwitch(string switchValue, Int32 switchIndex)
        {
            switch (switchValue.ToLowerInvariant())
            {
                // Array switches
                case "\\ac":
                    if (PrimarySwitch == EqPrimarySwitch.Array)
                    {
                        ArrayAlignment = EqArrayAlignment.Center;
                    }
                    else if (PrimarySwitch == EqPrimarySwitch.Overlay)
                    {
                        OverlayAlignment = EqOverlayAlignment.Center;
                    }
                    break;
                case "\\al":
                    if (PrimarySwitch == EqPrimarySwitch.Array)
                    {
                        ArrayAlignment = EqArrayAlignment.Left;
                    }
                    else if (PrimarySwitch == EqPrimarySwitch.Overlay)
                    {
                        OverlayAlignment = EqOverlayAlignment.Left;
                    }
                    break;
                case "\\ar":
                    if (PrimarySwitch == EqPrimarySwitch.Array)
                    {
                        ArrayAlignment = EqArrayAlignment.Right;
                    }
                    else if (PrimarySwitch == EqPrimarySwitch.Overlay)
                    {
                        OverlayAlignment = EqOverlayAlignment.Right;
                    }
                    break;
                case "\\co":
                    ColumnCount = GetIntegerArgumentAfter(switchIndex);
                    break;
                case "\\hs":
                    HorizontalSpacing = GetIntegerArgumentAfter(switchIndex);
                    break;
                case "\\vs":
                    VerticalSpacing = GetIntegerArgumentAfter(switchIndex);
                    break;

                // Bracket switches
                case "\\bc":
                    BothBracketCharacter = GetCharacterArgumentAfter(switchIndex);
                    break;
                case "\\lc":
                    LeftBracketCharacter = GetCharacterArgumentAfter(switchIndex);
                    break;
                case "\\rc":
                    RightBracketCharacter = GetCharacterArgumentAfter(switchIndex);
                    break;

                // Displacement switches
                case "\\ba":
                    BackwardDisplacement = GetIntegerArgumentAfter(switchIndex);
                    break;
                case "\\fo":
                    ForwardDisplacement = GetIntegerArgumentAfter(switchIndex);
                    break;
                case "\\li":
                    UnderlineSpace = true;
                    break;

                // Integral switches
                case "\\fc":
                    FixedHeightCharacter = GetCharacterArgumentAfter(switchIndex);
                    break;
                case "\\in":
                    InlineFormat = true;
                    break;
                case "\\pr":
                    IntegralSymbol = EqIntegralSymbol.Product;
                    break;
                case "\\su":
                    IntegralSymbol = EqIntegralSymbol.Summation;
                    break;
                case "\\vc":
                    VariableHeightCharacter = GetCharacterArgumentAfter(switchIndex);
                    break;

                // Script switches
                case "\\ai":
                    SpaceAboveLine = GetIntegerArgumentAfter(switchIndex);
                    break;
                case "\\di":
                    SpaceBelowLine = GetIntegerArgumentAfter(switchIndex);
                    break;
                case "\\do":
                    MoveDown = GetIntegerArgumentAfter(switchIndex);
                    break;
                case "\\up":
                    MoveUp = GetIntegerArgumentAfter(switchIndex);
                    break;

                // Box switches
                case "\\bo":
                    BorderBottom = true;
                    break;
                case "\\le":
                    BorderLeft = true;
                    break;
                case "\\ri":
                    BorderRight = true;
                    break;
                case "\\to":
                    BorderTop = true;
                    break;
            }
        }

        /// <summary>
        /// Gets the integer argument following the specified switch index.
        /// </summary>
        private Int32? GetIntegerArgumentAfter(Int32 switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    string argValue = nextArg.Value?.ToString() ?? "";
                    if (int.TryParse(argValue, out Int32 result))
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the character argument following the specified switch index.
        /// </summary>
        private char? GetCharacterArgumentAfter(Int32 switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    string argValue = nextArg.Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(argValue))
                    {
                        return argValue[0];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Validates the arguments based on the primary switch requirements.
        /// </summary>
        private void ValidateArguments()
        {
            switch (PrimarySwitch)
            {
                case EqPrimarySwitch.Bracket:
                {
                    if (ArgumentList.Count != 1)
                    {
                        throw new ArgumentException(
                            "Bracket (\\b) switch requires exactly one argument"
                        );
                    }
                    break;
                }

                case EqPrimarySwitch.Displacement:
                {
                    if (ArgumentList.Count != 0)
                    {
                        throw new ArgumentException(
                            "Displacement (\\d) switch requires no arguments"
                        );
                    }
                    break;
                }

                case EqPrimarySwitch.Fraction:
                {
                    if (ArgumentList.Count != 2)
                    {
                        throw new ArgumentException(
                            "Fraction (\\f) switch requires exactly two arguments (numerator, denominator)"
                        );
                    }
                    break;
                }

                case EqPrimarySwitch.Integral:
                {
                    if (ArgumentList.Count != 3)
                    {
                        throw new ArgumentException(
                            "Integral (\\i) switch requires exactly three arguments (lower limit, upper limit, integrand)"
                        );
                    }
                    break;
                }

                case EqPrimarySwitch.Radical:
                {
                    if (ArgumentList.Count < 1 || ArgumentList.Count > 2)
                    {
                        throw new ArgumentException(
                            "Radical (\\r) switch requires one or two arguments"
                        );
                    }
                    break;
                }

                case EqPrimarySwitch.Box:
                {
                    if (ArgumentList.Count != 1)
                    {
                        throw new ArgumentException(
                            "Box (\\x) switch requires exactly one argument"
                        );
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "EQ" };

            // Add primary switch
            string primarySwitchText = PrimarySwitch switch
            {
                EqPrimarySwitch.Array => "\\a",
                EqPrimarySwitch.Bracket => "\\b",
                EqPrimarySwitch.Displacement => "\\d",
                EqPrimarySwitch.Fraction => "\\f",
                EqPrimarySwitch.Integral => "\\i",
                EqPrimarySwitch.List => "\\l",
                EqPrimarySwitch.Overlay => "\\o",
                EqPrimarySwitch.Radical => "\\r",
                EqPrimarySwitch.Script => "\\s",
                EqPrimarySwitch.Box => "\\x",
                _ => "",
            };
            result.Add(primarySwitchText);

            // Add sub-switches based on primary switch
            AddArraySwitches(result);
            AddBracketSwitches(result);
            AddDisplacementSwitches(result);
            AddIntegralSwitches(result);
            AddOverlaySwitches(result);
            AddScriptSwitches(result);
            AddBoxSwitches(result);

            // Add argument list in parentheses
            if (ArgumentList.Count > 0)
            {
                char separator = ','; // Use comma as default separator
                string argumentListText = string.Join($"{separator} ", ArgumentList);
                result.Add($"( {argumentListText} )");
            }
            else
            {
                result.Add("()");
            }

            return string.Join(" ", result);
        }

        private void AddArraySwitches(List<string> result)
        {
            if (PrimarySwitch == EqPrimarySwitch.Array)
            {
                if (ArrayAlignment.HasValue)
                {
                    result.Add(
                        ArrayAlignment.Value switch
                        {
                            EqArrayAlignment.Center => "\\ac",
                            EqArrayAlignment.Left => "\\al",
                            EqArrayAlignment.Right => "\\ar",
                            _ => "",
                        }
                    );
                }

                if (ColumnCount.HasValue)
                {
                    result.Add("\\co");
                    result.Add(ColumnCount.Value.ToString());
                }

                if (HorizontalSpacing.HasValue)
                {
                    result.Add("\\hs");
                    result.Add(HorizontalSpacing.Value.ToString());
                }

                if (VerticalSpacing.HasValue)
                {
                    result.Add("\\vs");
                    result.Add(VerticalSpacing.Value.ToString());
                }
            }
        }

        private void AddBracketSwitches(List<string> result)
        {
            if (PrimarySwitch == EqPrimarySwitch.Bracket)
            {
                if (BothBracketCharacter.HasValue)
                {
                    result.Add("\\bc");
                    result.Add($"\\ {BothBracketCharacter.Value}");
                }

                if (LeftBracketCharacter.HasValue)
                {
                    result.Add("\\lc");
                    result.Add($"\\ {LeftBracketCharacter.Value}");
                }

                if (RightBracketCharacter.HasValue)
                {
                    result.Add("\\rc");
                    result.Add($"\\ {RightBracketCharacter.Value}");
                }
            }
        }

        private void AddDisplacementSwitches(List<string> result)
        {
            if (PrimarySwitch == EqPrimarySwitch.Displacement)
            {
                if (BackwardDisplacement.HasValue)
                {
                    result.Add("\\ba");
                    result.Add(BackwardDisplacement.Value.ToString());
                }

                if (ForwardDisplacement.HasValue)
                {
                    result.Add("\\fo");
                    result.Add(ForwardDisplacement.Value.ToString());
                }

                if (UnderlineSpace)
                {
                    result.Add("\\li");
                }
            }
        }

        private void AddIntegralSwitches(List<string> result)
        {
            if (PrimarySwitch == EqPrimarySwitch.Integral)
            {
                if (FixedHeightCharacter.HasValue)
                {
                    result.Add("\\fc");
                    result.Add($"\\ {FixedHeightCharacter.Value}");
                }

                if (InlineFormat)
                {
                    result.Add("\\in");
                }

                if (IntegralSymbol.HasValue)
                {
                    result.Add(
                        IntegralSymbol.Value switch
                        {
                            EqIntegralSymbol.Product => "\\pr",
                            EqIntegralSymbol.Summation => "\\su",
                            _ => "",
                        }
                    );
                }

                if (VariableHeightCharacter.HasValue)
                {
                    result.Add("\\vc");
                    result.Add($"\\ {VariableHeightCharacter.Value}");
                }
            }
        }

        private void AddOverlaySwitches(List<string> result)
        {
            if (PrimarySwitch == EqPrimarySwitch.Overlay)
            {
                if (OverlayAlignment.HasValue)
                {
                    result.Add(
                        OverlayAlignment.Value switch
                        {
                            EqOverlayAlignment.Center => "\\ac",
                            EqOverlayAlignment.Left => "\\al",
                            EqOverlayAlignment.Right => "\\ar",
                            _ => "",
                        }
                    );
                }
            }
        }

        private void AddScriptSwitches(List<string> result)
        {
            if (PrimarySwitch == EqPrimarySwitch.Script)
            {
                if (SpaceAboveLine.HasValue)
                {
                    result.Add("\\ai");
                    result.Add(SpaceAboveLine.Value.ToString());
                }

                if (SpaceBelowLine.HasValue)
                {
                    result.Add("\\di");
                    result.Add(SpaceBelowLine.Value.ToString());
                }

                if (MoveDown.HasValue)
                {
                    result.Add("\\do");
                    result.Add(MoveDown.Value.ToString());
                }

                if (MoveUp.HasValue)
                {
                    result.Add("\\up");
                    result.Add(MoveUp.Value.ToString());
                }
            }
        }

        private void AddBoxSwitches(List<string> result)
        {
            if (PrimarySwitch == EqPrimarySwitch.Box)
            {
                if (BorderBottom)
                {
                    result.Add("\\bo");
                }

                if (BorderLeft)
                {
                    result.Add("\\le");
                }

                if (BorderRight)
                {
                    result.Add("\\ri");
                }

                if (BorderTop)
                {
                    result.Add("\\to");
                }
            }
        }
    }
}
