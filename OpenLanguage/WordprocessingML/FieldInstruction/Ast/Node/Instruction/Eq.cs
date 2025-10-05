using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum EqArgument
    {
        PrimarySwitch,
        ArgumentList,
        ArrayAlignment,
        ColumnCount,
        HorizontalSpacing,
        VerticalSpacing,
        BothBracketCharacter,
        LeftBracketCharacter,
        RightBracketCharacter,
        BackwardDisplacement,
        ForwardDisplacement,
        UnderlineSpace,
        FixedHeightCharacter,
        InlineFormat,
        IntegralSymbol,
        VariableHeightCharacter,
        OverlayAlignment,
        SpaceAboveLine,
        SpaceBelowLine,
        MoveDown,
        MoveUp,
        BorderBottom,
        BorderLeft,
        BorderRight,
        BorderTop,
    }

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
    public class EqFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// The primary switch that determines the equation type.
        /// </summary>
        public FlagNode? PrimarySwitch { get; set; }

        /// <summary>
        /// The equation argument list (comma or semicolon separated).
        /// </summary>
        public List<ExpressionNode> ArgumentList { get; set; } = new List<ExpressionNode>();

        public LeftParenNode? LeftParen { get; set; }
        public RightParenNode? RightParen { get; set; }
        public List<CharacterLiteralNode> ArgumentSeparators { get; set; } =
            new List<CharacterLiteralNode>();

        // Array switches (\a)
        /// <summary>
        /// Switch: \ac, \al, \ar
        /// Alignment in each array column.
        /// </summary>
        public FlaggedArgument<EqArrayAlignmentNode>? ArrayAlignment { get; set; }

        /// <summary>
        /// Switch: \co field-argument
        /// Number of columns in the array (default is 1).
        /// </summary>
        public FlaggedArgument<ExpressionNode>? ColumnCount { get; set; }

        /// <summary>
        /// Switch: \hs field-argument
        /// Horizontal spacing between columns in points.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? HorizontalSpacing { get; set; }

        /// <summary>
        /// Switch: \vs field-argument
        /// Vertical spacing between lines in points.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? VerticalSpacing { get; set; }

        // Bracket switches (\b)
        /// <summary>
        /// Switch: \bc \ char
        /// Both left and right bracket character.
        /// </summary>
        public FlaggedArgument<CharacterLiteralNode>? BothBracketCharacter { get; set; }

        /// <summary>
        /// Switch: \lc \ char
        /// Left bracket character.
        /// </summary>
        public FlaggedArgument<CharacterLiteralNode>? LeftBracketCharacter { get; set; }

        /// <summary>
        /// Switch: \rc \ char
        /// Right bracket character.
        /// </summary>
        public FlaggedArgument<CharacterLiteralNode>? RightBracketCharacter { get; set; }

        // Displacement switches (\d)
        /// <summary>
        /// Switch: \ba field-argument
        /// Backward displacement in points.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? BackwardDisplacement { get; set; }

        /// <summary>
        /// Switch: \fo field-argument
        /// Forward displacement in points.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? ForwardDisplacement { get; set; }

        /// <summary>
        /// Switch: \li
        /// Underlines the space up to the next character.
        /// </summary>
        public BoolFlagNode? UnderlineSpace { get; set; }

        // Integral switches (\i)
        /// <summary>
        /// Switch: \fc \ char
        /// Fixed-height character for the symbol.
        /// </summary>
        public FlaggedArgument<CharacterLiteralNode>? FixedHeightCharacter { get; set; }

        /// <summary>
        /// Switch: \in
        /// Inline format with limits to the right instead of above/below.
        /// </summary>
        public BoolFlagNode? InlineFormat { get; set; }

        /// <summary>
        /// Switch: \pr, \su, or default
        /// Type of integral symbol to use.
        /// </summary>
        public FlaggedArgument<EqIntegralSymbolNode>? IntegralSymbol { get; set; }

        /// <summary>
        /// Switch: \vc \ char
        /// Variable-height character for the symbol.
        /// </summary>
        public FlaggedArgument<CharacterLiteralNode>? VariableHeightCharacter { get; set; }

        // Overlay switches (\o)
        /// <summary>
        /// Switch: \ac, \al, \ar
        /// Alignment for overlay character boxes.
        /// </summary>
        public FlaggedArgument<EqOverlayAlignmentNode>? OverlayAlignment { get; set; }

        // Script switches (\s)
        /// <summary>
        /// Switch: \ai field-argument
        /// Space above line in points (default 2).
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SpaceAboveLine { get; set; }

        /// <summary>
        /// Switch: \di field-argument
        /// Space below line in points.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? SpaceBelowLine { get; set; }

        /// <summary>
        /// Switch: \do field-argument
        /// Move argument below adjacent text by points (default 2).
        /// </summary>
        public FlaggedArgument<ExpressionNode>? MoveDown { get; set; }

        /// <summary>
        /// Switch: \up field-argument
        /// Move argument above adjacent text by points.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? MoveUp { get; set; }

        // Box switches (\x)
        /// <summary>
        /// Switch: \bo
        /// Draw horizontal border below argument.
        /// </summary>
        public BoolFlagNode? BorderBottom { get; set; }

        /// <summary>
        /// Switch: \le
        /// Draw vertical border to the left of argument.
        /// </summary>
        public BoolFlagNode? BorderLeft { get; set; }

        /// <summary>
        /// Switch: \ri
        /// Draw vertical border to the right of argument.
        /// </summary>
        public BoolFlagNode? BorderRight { get; set; }

        /// <summary>
        /// Switch: \to
        /// Draw horizontal border above argument.
        /// </summary>
        public BoolFlagNode? BorderTop { get; set; }

        public List<EqArgument> Order { get; set; } = new List<EqArgument>();

        public EqFieldInstruction(
            StringLiteralNode instruction,
            FlagNode? primarySwitch,
            List<ExpressionNode> argumentList,
            FlaggedArgument<EqArrayAlignmentNode>? arrayAlignment,
            FlaggedArgument<ExpressionNode>? columnCount,
            FlaggedArgument<ExpressionNode>? horizontalSpacing,
            FlaggedArgument<ExpressionNode>? verticalSpacing,
            FlaggedArgument<CharacterLiteralNode>? bothBracketCharacter,
            FlaggedArgument<CharacterLiteralNode>? leftBracketCharacter,
            FlaggedArgument<CharacterLiteralNode>? rightBracketCharacter,
            FlaggedArgument<ExpressionNode>? backwardDisplacement,
            FlaggedArgument<ExpressionNode>? forwardDisplacement,
            BoolFlagNode? underlineSpace,
            FlaggedArgument<CharacterLiteralNode>? fixedHeightCharacter,
            BoolFlagNode? inlineFormat,
            FlaggedArgument<EqIntegralSymbolNode>? integralSymbol,
            FlaggedArgument<CharacterLiteralNode>? variableHeightCharacter,
            FlaggedArgument<EqOverlayAlignmentNode>? overlayAlignment,
            FlaggedArgument<ExpressionNode>? spaceAboveLine,
            FlaggedArgument<ExpressionNode>? spaceBelowLine,
            FlaggedArgument<ExpressionNode>? moveDown,
            FlaggedArgument<ExpressionNode>? moveUp,
            BoolFlagNode? borderBottom,
            BoolFlagNode? borderLeft,
            BoolFlagNode? borderRight,
            BoolFlagNode? borderTop,
            List<EqArgument> order,
            LeftParenNode? leftParen = null,
            RightParenNode? rightParen = null,
            List<CharacterLiteralNode>? argumentSeparators = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            PrimarySwitch = primarySwitch;
            ArgumentList = argumentList;
            LeftParen = leftParen;
            RightParen = rightParen;
            ArgumentSeparators = argumentSeparators ?? new List<CharacterLiteralNode>();
            ArrayAlignment = arrayAlignment;
            ColumnCount = columnCount;
            HorizontalSpacing = horizontalSpacing;
            VerticalSpacing = verticalSpacing;
            BothBracketCharacter = bothBracketCharacter;
            LeftBracketCharacter = leftBracketCharacter;
            RightBracketCharacter = rightBracketCharacter;
            BackwardDisplacement = backwardDisplacement;
            ForwardDisplacement = forwardDisplacement;
            UnderlineSpace = underlineSpace;
            FixedHeightCharacter = fixedHeightCharacter;
            InlineFormat = inlineFormat;
            IntegralSymbol = integralSymbol;
            VariableHeightCharacter = variableHeightCharacter;
            OverlayAlignment = overlayAlignment;
            SpaceAboveLine = spaceAboveLine;
            SpaceBelowLine = spaceBelowLine;
            MoveDown = moveDown;
            MoveUp = moveUp;
            BorderBottom = borderBottom;
            BorderLeft = borderLeft;
            BorderRight = borderRight;
            BorderTop = borderTop;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(
                    (EqArgument a) =>
                        a switch
                        {
                            EqArgument.PrimarySwitch => PrimarySwitch?.ToString() ?? string.Empty,

                            // All switches are already stored as nodes in the relevant properties
                            EqArgument.ArrayAlignment => ArrayAlignment?.Flag.ToString()
                                ?? string.Empty,
                            EqArgument.ColumnCount => ColumnCount?.ToString() ?? string.Empty,
                            EqArgument.HorizontalSpacing => HorizontalSpacing?.ToString()
                                ?? string.Empty,
                            EqArgument.VerticalSpacing => VerticalSpacing?.ToString()
                                ?? string.Empty,
                            EqArgument.BothBracketCharacter => BothBracketCharacter?.ToString()
                                ?? string.Empty,
                            EqArgument.LeftBracketCharacter => LeftBracketCharacter?.ToString()
                                ?? string.Empty,
                            EqArgument.RightBracketCharacter => RightBracketCharacter?.ToString()
                                ?? string.Empty,
                            EqArgument.BackwardDisplacement => BackwardDisplacement?.ToString()
                                ?? string.Empty,
                            EqArgument.ForwardDisplacement => ForwardDisplacement?.ToString()
                                ?? string.Empty,
                            EqArgument.UnderlineSpace => UnderlineSpace?.ToString() ?? string.Empty,
                            EqArgument.FixedHeightCharacter => FixedHeightCharacter?.ToString()
                                ?? string.Empty,
                            EqArgument.InlineFormat => InlineFormat?.ToString() ?? string.Empty,
                            EqArgument.IntegralSymbol => IntegralSymbol?.Flag.ToString()
                                ?? string.Empty,
                            EqArgument.VariableHeightCharacter =>
                                VariableHeightCharacter?.ToString() ?? string.Empty,
                            EqArgument.OverlayAlignment => OverlayAlignment?.Flag.ToString()
                                ?? string.Empty,
                            EqArgument.SpaceAboveLine => SpaceAboveLine?.ToString() ?? string.Empty,
                            EqArgument.SpaceBelowLine => SpaceBelowLine?.ToString() ?? string.Empty,
                            EqArgument.MoveDown => MoveDown?.ToString() ?? string.Empty,
                            EqArgument.MoveUp => MoveUp?.ToString() ?? string.Empty,
                            EqArgument.BorderBottom => BorderBottom?.ToString() ?? string.Empty,
                            EqArgument.BorderLeft => BorderLeft?.ToString() ?? string.Empty,
                            EqArgument.BorderRight => BorderRight?.ToString() ?? string.Empty,
                            EqArgument.BorderTop => BorderTop?.ToString() ?? string.Empty,

                            EqArgument.ArgumentList => (LeftParen?.ToString() ?? string.Empty)
                                + (
                                    ArgumentList.Count == 0
                                        ? string.Empty
                                        : ArgumentList[0].ToString()
                                            + string.Concat(
                                                Enumerable
                                                    .Range(1, ArgumentList.Count - 1)
                                                    .Select(i =>
                                                        ArgumentSeparators
                                                            .ElementAtOrDefault(i - 1)
                                                            ?.ToString() ?? ","
                                                    )
                                                    .Zip(
                                                        ArgumentList.Skip(1),
                                                        (sep, expr) => sep + expr.ToString()
                                                    )
                                            )
                                )
                                + (RightParen?.ToString() ?? string.Empty),

                            _ => string.Empty,
                        }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O oInstruction)
            {
                yield return oInstruction;
            }

            foreach (EqArgument arg in Order)
            {
                switch (arg)
                {
                    case EqArgument.PrimarySwitch:
                        if (PrimarySwitch is O oPrimarySwitch)
                        {
                            yield return oPrimarySwitch;
                        }
                        break;
                    case EqArgument.ArgumentList:
                        if (LeftParen is O lp)
                        {
                            yield return lp;
                        }
                        if (ArgumentList != null)
                        {
                            for (int i = 0; i < ArgumentList.Count; i++)
                            {
                                if (i > 0 && ArgumentSeparators.ElementAtOrDefault(i - 1) is O sep)
                                {
                                    yield return sep;
                                }
                                if (ArgumentList[i] is O argExpr)
                                {
                                    yield return argExpr;
                                }
                            }
                        }
                        if (RightParen is O rp)
                        {
                            yield return rp;
                        }
                        break;
                    case EqArgument.ArrayAlignment:
                        if (ArrayAlignment is O oArrayAlignment)
                        {
                            yield return oArrayAlignment;
                        }
                        break;
                    case EqArgument.ColumnCount:
                        if (ColumnCount is O oColumnCount)
                        {
                            yield return oColumnCount;
                        }
                        break;
                    case EqArgument.HorizontalSpacing:
                        if (HorizontalSpacing is O oHorizontalSpacing)
                        {
                            yield return oHorizontalSpacing;
                        }
                        break;
                    case EqArgument.VerticalSpacing:
                        if (VerticalSpacing is O oVerticalSpacing)
                        {
                            yield return oVerticalSpacing;
                        }
                        break;
                    case EqArgument.BothBracketCharacter:
                        if (BothBracketCharacter is O oBothBracketCharacter)
                        {
                            yield return oBothBracketCharacter;
                        }
                        break;
                    case EqArgument.LeftBracketCharacter:
                        if (LeftBracketCharacter is O oLeftBracketCharacter)
                        {
                            yield return oLeftBracketCharacter;
                        }
                        break;
                    case EqArgument.RightBracketCharacter:
                        if (RightBracketCharacter is O oRightBracketCharacter)
                        {
                            yield return oRightBracketCharacter;
                        }
                        break;
                    case EqArgument.BackwardDisplacement:
                        if (BackwardDisplacement is O oBackwardDisplacement)
                        {
                            yield return oBackwardDisplacement;
                        }
                        break;
                    case EqArgument.ForwardDisplacement:
                        if (ForwardDisplacement is O oForwardDisplacement)
                        {
                            yield return oForwardDisplacement;
                        }
                        break;
                    case EqArgument.UnderlineSpace:
                        if (UnderlineSpace is O oUnderlineSpace)
                        {
                            yield return oUnderlineSpace;
                        }
                        break;
                    case EqArgument.FixedHeightCharacter:
                        if (FixedHeightCharacter is O oFixedHeightCharacter)
                        {
                            yield return oFixedHeightCharacter;
                        }
                        break;
                    case EqArgument.InlineFormat:
                        if (InlineFormat is O oInlineFormat)
                        {
                            yield return oInlineFormat;
                        }
                        break;
                    case EqArgument.IntegralSymbol:
                        if (IntegralSymbol is O oIntegralSymbol)
                        {
                            yield return oIntegralSymbol;
                        }
                        break;
                    case EqArgument.VariableHeightCharacter:
                        if (VariableHeightCharacter is O oVariableHeightCharacter)
                        {
                            yield return oVariableHeightCharacter;
                        }
                        break;
                    case EqArgument.OverlayAlignment:
                        if (OverlayAlignment is O oOverlayAlignment)
                        {
                            yield return oOverlayAlignment;
                        }
                        break;
                    case EqArgument.SpaceAboveLine:
                        if (SpaceAboveLine is O oSpaceAboveLine)
                        {
                            yield return oSpaceAboveLine;
                        }
                        break;
                    case EqArgument.SpaceBelowLine:
                        if (SpaceBelowLine is O oSpaceBelowLine)
                        {
                            yield return oSpaceBelowLine;
                        }
                        break;
                    case EqArgument.MoveDown:
                        if (MoveDown is O oMoveDown)
                        {
                            yield return oMoveDown;
                        }
                        break;
                    case EqArgument.MoveUp:
                        if (MoveUp is O oMoveUp)
                        {
                            yield return oMoveUp;
                        }
                        break;
                    case EqArgument.BorderBottom:
                        if (BorderBottom is O oBorderBottom)
                        {
                            yield return oBorderBottom;
                        }
                        break;
                    case EqArgument.BorderLeft:
                        if (BorderLeft is O oBorderLeft)
                        {
                            yield return oBorderLeft;
                        }
                        break;
                    case EqArgument.BorderRight:
                        if (BorderRight is O oBorderRight)
                        {
                            yield return oBorderRight;
                        }
                        break;
                    case EqArgument.BorderTop:
                        if (BorderTop is O oBorderTop)
                        {
                            yield return oBorderTop;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index < 0 || replacement == null)
            {
                return null;
            }

            Node? current = null;

            if (index == 0 && replacement is StringLiteralNode instruction)
            {
                current = Instruction;
                Instruction = instruction;
                return current;
            }

            int currentIndex = 0;
            index--;

            foreach (EqArgument argument in Order)
            {
                switch (argument)
                {
                    case EqArgument.PrimarySwitch:
                        if (PrimarySwitch != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is FlagNode primarySwitch)
                                {
                                    current = PrimarySwitch;
                                    PrimarySwitch = primarySwitch;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.ArgumentList:
                        if (LeftParen != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is LeftParenNode lp)
                                {
                                    current = LeftParen;
                                    LeftParen = lp;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        for (int argIndex = 0; argIndex < ArgumentList.Count; argIndex++)
                        {
                            if (argIndex > 0)
                            {
                                if (currentIndex == index)
                                {
                                    if (replacement is CharacterLiteralNode sep)
                                    {
                                        current = ArgumentSeparators[argIndex - 1];
                                        ArgumentSeparators[argIndex - 1] = sep;
                                    }
                                    return current;
                                }
                                currentIndex++;
                            }

                            if (currentIndex == index)
                            {
                                if (replacement is ExpressionNode expr)
                                {
                                    current = ArgumentList[argIndex];
                                    ArgumentList[argIndex] = expr;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        if (RightParen != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is RightParenNode rp)
                                {
                                    current = RightParen;
                                    RightParen = rp;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.ArrayAlignment:
                        if (ArrayAlignment != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<EqArrayAlignmentNode> arrayAlignment
                                )
                                {
                                    current = ArrayAlignment;
                                    ArrayAlignment = arrayAlignment;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.ColumnCount:
                        if (ColumnCount != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is FlaggedArgument<ExpressionNode> columnCount)
                                {
                                    current = ColumnCount;
                                    ColumnCount = columnCount;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.HorizontalSpacing:
                        if (HorizontalSpacing != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement is FlaggedArgument<ExpressionNode> horizontalSpacing
                                )
                                {
                                    current = HorizontalSpacing;
                                    HorizontalSpacing = horizontalSpacing;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.VerticalSpacing:
                        if (VerticalSpacing != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is FlaggedArgument<ExpressionNode> verticalSpacing)
                                {
                                    current = VerticalSpacing;
                                    VerticalSpacing = verticalSpacing;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.BothBracketCharacter:
                        if (BothBracketCharacter != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<CharacterLiteralNode> bothBracketCharacter
                                )
                                {
                                    current = BothBracketCharacter;
                                    BothBracketCharacter = bothBracketCharacter;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.LeftBracketCharacter:
                        if (LeftBracketCharacter != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<CharacterLiteralNode> leftBracketCharacter
                                )
                                {
                                    current = LeftBracketCharacter;
                                    LeftBracketCharacter = leftBracketCharacter;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.RightBracketCharacter:
                        if (RightBracketCharacter != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<CharacterLiteralNode> rightBracketCharacter
                                )
                                {
                                    current = RightBracketCharacter;
                                    RightBracketCharacter = rightBracketCharacter;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.BackwardDisplacement:
                        if (BackwardDisplacement != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<ExpressionNode> backwardDisplacement
                                )
                                {
                                    current = BackwardDisplacement;
                                    BackwardDisplacement = backwardDisplacement;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.ForwardDisplacement:
                        if (ForwardDisplacement != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<ExpressionNode> forwardDisplacement
                                )
                                {
                                    current = ForwardDisplacement;
                                    ForwardDisplacement = forwardDisplacement;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.UnderlineSpace:
                        if (UnderlineSpace != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is BoolFlagNode underlineSpace)
                                {
                                    current = UnderlineSpace;
                                    UnderlineSpace = underlineSpace;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.FixedHeightCharacter:
                        if (FixedHeightCharacter != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<CharacterLiteralNode> fixedHeightCharacter
                                )
                                {
                                    current = FixedHeightCharacter;
                                    FixedHeightCharacter = fixedHeightCharacter;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.InlineFormat:
                        if (InlineFormat != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is BoolFlagNode inlineFormat)
                                {
                                    current = InlineFormat;
                                    InlineFormat = inlineFormat;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.IntegralSymbol:
                        if (IntegralSymbol != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<EqIntegralSymbolNode> integralSymbol
                                )
                                {
                                    current = IntegralSymbol;
                                    IntegralSymbol = integralSymbol;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.VariableHeightCharacter:
                        if (VariableHeightCharacter != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<CharacterLiteralNode> variableHeightCharacter
                                )
                                {
                                    current = VariableHeightCharacter;
                                    VariableHeightCharacter = variableHeightCharacter;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.OverlayAlignment:
                        if (OverlayAlignment != null)
                        {
                            if (currentIndex == index)
                            {
                                if (
                                    replacement
                                    is FlaggedArgument<EqOverlayAlignmentNode> overlayAlignment
                                )
                                {
                                    current = OverlayAlignment;
                                    OverlayAlignment = overlayAlignment;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.SpaceAboveLine:
                        if (SpaceAboveLine != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is FlaggedArgument<ExpressionNode> spaceAboveLine)
                                {
                                    current = SpaceAboveLine;
                                    SpaceAboveLine = spaceAboveLine;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.SpaceBelowLine:
                        if (SpaceBelowLine != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is FlaggedArgument<ExpressionNode> spaceBelowLine)
                                {
                                    current = SpaceBelowLine;
                                    SpaceBelowLine = spaceBelowLine;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.MoveDown:
                        if (MoveDown != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is FlaggedArgument<ExpressionNode> moveDown)
                                {
                                    current = MoveDown;
                                    MoveDown = moveDown;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.MoveUp:
                        if (MoveUp != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is FlaggedArgument<ExpressionNode> moveUp)
                                {
                                    current = MoveUp;
                                    MoveUp = moveUp;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.BorderBottom:
                        if (BorderBottom != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is BoolFlagNode borderBottom)
                                {
                                    current = BorderBottom;
                                    BorderBottom = borderBottom;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.BorderLeft:
                        if (BorderLeft != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is BoolFlagNode borderLeft)
                                {
                                    current = BorderLeft;
                                    BorderLeft = borderLeft;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.BorderRight:
                        if (BorderRight != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is BoolFlagNode borderRight)
                                {
                                    current = BorderRight;
                                    BorderRight = borderRight;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    case EqArgument.BorderTop:
                        if (BorderTop != null)
                        {
                            if (currentIndex == index)
                            {
                                if (replacement is BoolFlagNode borderTop)
                                {
                                    current = BorderTop;
                                    BorderTop = borderTop;
                                }
                                return current;
                            }
                            currentIndex++;
                        }
                        break;

                    default:
                        break;
                }
            }

            return current;
        }
    }
}
