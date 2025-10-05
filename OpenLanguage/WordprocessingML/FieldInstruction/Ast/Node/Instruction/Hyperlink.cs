using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum HyperlinkArgument
    {
        Uri,
        DisplayText,
        InternalLocation,
        InstrFrameTarget,
        NewWindow,
        ServerSideImageMapAppendCoordinates,
        ScreenTipText,
        FrameTarget,
        ArbLocation,
        UndocumentedC,
    }

    /// <summary>
    /// Represents a strongly-typed HYPERLINK field instruction.
    /// When selected, causes control to jump to the location specified by text in field-argument. That location can be a bookmark or a URL.
    /// </summary>
    public class HyperlinkFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The URL or path for the hyperlink
        /// </summary>
        public ExpressionNode? Uri { get; set; }

        /// <summary>
        /// The display text for the hyperlink.
        /// </summary>
        public ExpressionNode? DisplayText { get; set; }

        /// <summary>
        /// Switch: \m coordinates
        /// Appends coordinates to a hyperlink for a server-side image map
        /// server-side image map: A graphic containing sensitive regions, or "hot spots," that a user can click to follow a hyperlink.
        /// A server-side image map requires a script on a Web server that identifies the sensitive regions and their corresponding hyperlinks
        /// </summary>
        public FlaggedArgument<ExpressionNode>? ServerSideImageMapAppendCoordinates { get; set; }

        /// <summary>
        /// Switch: \n
        /// Open in new window
        /// </summary>
        public BoolFlagNode? NewWindow { get; set; }

        /// <summary>
        /// Switch: \o text
        ///  text in this switch's field-argument specifies the ScreenTip text for the hyperlink.
        ///  ScreenTip: A short description that appears when the user holds the mouse pointer over an object, such as a button or hyperlink.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? ScreenTipText { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Target frame
        /// </summary>
        public FlaggedArgument<ExpressionNode>? InstrFrameTarget { get; set; }

        /// <summary>
        /// Switch: \L text in this switch's field-argument specifies a location in the file, such as a bookmark, where this hyperlink will jump.
        /// Target frame
        /// </summary>
        public FlaggedArgument<ExpressionNode>? InternalLocation { get; set; }

        /// <summary>
        /// Undocumented in OOXML, documented for Word 2003
        /// Used internally by Word for internally labelled, non-exported location names
        /// Left here for the sake of completeness, and also to not forget that this exists, where it's undocumented
        /// Switch: \s arbLocation
        /// </summary>
        public FlaggedArgument<ExpressionNode>? ArbLocation { get; set; }

        /// <summary>
        /// Undocumented switch seen in the wild.
        /// e.g. `\c 3`
        /// </summary>
        public FlaggedArgument<NumericLiteralNode<int>>? UndocumentedC { get; set; }

        public List<HyperlinkArgument> Order { get; set; } = new List<HyperlinkArgument>();

        public HyperlinkFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? uri,
            ExpressionNode? displayText,
            FlaggedArgument<ExpressionNode>? internalLocation,
            BoolFlagNode? newWindow,
            FlaggedArgument<ExpressionNode>? serverSideImageMapAppendCoordinates,
            FlaggedArgument<ExpressionNode>? screenTipText,
            FlaggedArgument<ExpressionNode>? instrFrameTarget,
            FlaggedArgument<ExpressionNode>? arbLocation,
            FlaggedArgument<NumericLiteralNode<int>>? undocumentedC,
            List<HyperlinkArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Uri = uri;
            DisplayText = displayText;
            InternalLocation = internalLocation;
            NewWindow = newWindow;
            ServerSideImageMapAppendCoordinates = serverSideImageMapAppendCoordinates;
            ScreenTipText = screenTipText;
            InstrFrameTarget = instrFrameTarget;
            ArbLocation = arbLocation;
            UndocumentedC = undocumentedC;

            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        HyperlinkArgument.Uri => Uri?.ToString() ?? string.Empty,
                        HyperlinkArgument.DisplayText => DisplayText?.ToString() ?? string.Empty,
                        HyperlinkArgument.InternalLocation => InternalLocation?.ToString()
                            ?? string.Empty,
                        HyperlinkArgument.NewWindow => NewWindow?.ToString() ?? string.Empty,
                        HyperlinkArgument.ServerSideImageMapAppendCoordinates =>
                            ServerSideImageMapAppendCoordinates?.ToString() ?? string.Empty,
                        HyperlinkArgument.ScreenTipText => ScreenTipText?.ToString()
                            ?? string.Empty,
                        HyperlinkArgument.InstrFrameTarget => InstrFrameTarget?.ToString()
                            ?? string.Empty,
                        HyperlinkArgument.ArbLocation => ArbLocation?.ToString() ?? string.Empty,
                        HyperlinkArgument.UndocumentedC => UndocumentedC?.ToString()
                            ?? string.Empty,
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

            foreach (HyperlinkArgument arg in Order)
            {
                Node? child = arg switch
                {
                    HyperlinkArgument.Uri => Uri,
                    HyperlinkArgument.DisplayText => DisplayText,
                    HyperlinkArgument.InternalLocation => InternalLocation,
                    HyperlinkArgument.NewWindow => NewWindow,
                    HyperlinkArgument.ServerSideImageMapAppendCoordinates =>
                        ServerSideImageMapAppendCoordinates,
                    HyperlinkArgument.ScreenTipText => ScreenTipText,
                    HyperlinkArgument.InstrFrameTarget => InstrFrameTarget,
                    HyperlinkArgument.ArbLocation => ArbLocation,
                    HyperlinkArgument.UndocumentedC => UndocumentedC,
                    _ => null,
                };

                if (child is O oChild)
                {
                    yield return oChild;
                }
            }

            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0)
            {
                if (replacement is StringLiteralNode instruction)
                {
                    current = Instruction;
                    Instruction = instruction;
                }
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    HyperlinkArgument arg = Order[index];
                    switch (arg)
                    {
                        case HyperlinkArgument.Uri:
                            if (replacement is ExpressionNode uri)
                            {
                                current = Uri;
                                Uri = uri;
                            }
                            break;
                        case HyperlinkArgument.DisplayText:
                            if (replacement is ExpressionNode displayText)
                            {
                                current = DisplayText;
                                DisplayText = displayText;
                            }
                            break;
                        case HyperlinkArgument.InternalLocation:
                            if (replacement is FlaggedArgument<ExpressionNode> internalLocation)
                            {
                                current = InternalLocation;
                                InternalLocation = internalLocation;
                            }
                            break;
                        case HyperlinkArgument.NewWindow:
                            if (replacement is BoolFlagNode newWindow)
                            {
                                current = NewWindow;
                                NewWindow = newWindow;
                            }
                            break;
                        case HyperlinkArgument.ServerSideImageMapAppendCoordinates:
                            if (
                                replacement
                                is FlaggedArgument<ExpressionNode> serverSideImageMapAppendCoordinates
                            )
                            {
                                current = ServerSideImageMapAppendCoordinates;
                                ServerSideImageMapAppendCoordinates =
                                    serverSideImageMapAppendCoordinates;
                            }
                            break;
                        case HyperlinkArgument.ScreenTipText:
                            if (replacement is FlaggedArgument<ExpressionNode> screenTipText)
                            {
                                current = ScreenTipText;
                                ScreenTipText = screenTipText;
                            }
                            break;
                        case HyperlinkArgument.InstrFrameTarget:
                            if (replacement is FlaggedArgument<ExpressionNode> instrFrameTarget)
                            {
                                current = InstrFrameTarget;
                                InstrFrameTarget = instrFrameTarget;
                            }
                            break;
                        case HyperlinkArgument.ArbLocation:
                            if (replacement is FlaggedArgument<ExpressionNode> arbLocation)
                            {
                                current = ArbLocation;
                                ArbLocation = arbLocation;
                            }
                            break;
                        case HyperlinkArgument.UndocumentedC:
                            if (
                                replacement
                                is FlaggedArgument<NumericLiteralNode<int>> undocumentedC
                            )
                            {
                                current = UndocumentedC;
                                UndocumentedC = undocumentedC;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

            return current;
        }
    }
}
