using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed HYPERLINK field instruction.
    /// When selected, causes control to jump to the location specified by text in field-argument. That location can be a bookmark or a URL.
    /// </summary>
    public class HyperlinkFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The URL or path for the hyperlink
        /// </summary>
        public System.Uri? Uri { get; set; }

        /// <summary>
        /// Switch: \m coordinates
        /// Appends coordinates to a hyperlink for a server-side image map
        /// server-side image map: A graphic containing sensitive regions, or "hot spots," that a user can click to follow a hyperlink.
        /// A server-side image map requires a script on a Web server that identifies the sensitive regions and their corresponding hyperlinks
        /// </summary>
        public List<float>? ServerSideImageMapAppendCoordinates { get; set; }

        /// <summary>
        /// Switch: \n
        /// Open in new window
        /// </summary>
        public bool NewWindow { get; set; }

        /// <summary>
        /// Switch: \o text
        ///  text in this switch's field-argument specifies the ScreenTip text for the hyperlink.
        ///  ScreenTip: A short description that appears when the user holds the mouse pointer over an object, such as a button or hyperlink.
        /// </summary>
        public string? ScreenTipText { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Target frame
        /// </summary>
        public FrameTarget? InstrFrameTarget { get; set; }

        /// <summary>
        /// Switch: \L text in this switch's field-argument specifies a location in the file, such as a bookmark, where this hyperlink will jump.
        /// Target frame
        /// </summary>
        public string? InternalLocation { get; set; }

        /// <summary>
        ///
        /// Undocumented in OOXML, documented for Word 2003
        /// Used internally by Word for internally labelled, non-exported location names
        ///
        /// Left here for the sake of completeness, and also to not forget that this exists, where it's undocumented
        /// Switch: \s arbLocation
        public string? ArbLocation { get; set; }

        /// <summary>
        /// Initializes a new instance of the HyperlinkFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public HyperlinkFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "HYPERLINK")
            {
                throw new ArgumentException(
                    $"Expected HYPERLINK field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                string? uriString = firstNonSwitch.Value?.ToString();
                if (!string.IsNullOrEmpty(uriString))
                {
                    try
                    {
                        Uri = new System.Uri(uriString, UriKind.RelativeOrAbsolute);
                    }
                    catch (UriFormatException)
                    {
                        // If it's not a valid URI, it might be a relative path or bookmark
                        Uri = new System.Uri(uriString, UriKind.RelativeOrAbsolute);
                    }
                }
            }

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\l":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    InternalLocation = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\m":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    if (nextArg.Value != null)
                                    {
                                        string[] split = (nextArg.Value?.ToString() ?? string.Empty)
                                            .Split(',')
                                            .Select((e) => e.Trim())
                                            .ToArray();

                                        List<float> coords = new List<float>();

                                        for (int j = 0; j < split.Length; j++)
                                        {
                                            float coord;
                                            if (float.TryParse(split[j], out coord))
                                            {
                                                coords.Add(coord);
                                            }
                                            else if (j != split.Length - 1)
                                            {
                                                coords.Add(0.0f);
                                            }
                                        }
                                        ServerSideImageMapAppendCoordinates = coords;
                                    }
                                }
                            }
                            break;
                        case "\\n":
                            NewWindow = true;
                            break;
                        case "\\o":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    ScreenTipText = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\t":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    InstrFrameTarget = FrameTargetUtils.ParseFrameTarget(
                                        nextArg.Value?.ToString() ?? string.Empty
                                    );
                                }
                            }
                            break;
                        case "\\s":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    ArbLocation = nextArg.Value?.ToString();
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            if (Uri != null)
            {
                string argString = Uri.ToString();
                result.Add(argString.Contains(" ") ? $"\"{Uri}\"" : argString);
            }

            if (InternalLocation != null)
            {
                result.Add("\\L");
                result.Add(
                    InternalLocation.ToString().Contains(" ")
                        ? $"\"{InternalLocation}\""
                        : InternalLocation.ToString()
                );
            }

            if (NewWindow)
            {
                result.Add("\\n");
            }

            if (
                ServerSideImageMapAppendCoordinates != null
                && ServerSideImageMapAppendCoordinates.Count > 0
            )
            {
                result.Add("\\m");
                result.Add(
                    $"\"{string.Join(",", ServerSideImageMapAppendCoordinates.Select((float coord) => $"{coord}"))}\""
                );
            }

            if (!string.IsNullOrEmpty(ScreenTipText))
            {
                result.Add("\\o");
                result.Add(ScreenTipText);
            }

            if (!string.IsNullOrEmpty(ArbLocation))
            {
                result.Add("\\s");
                result.Add(
                    ArbLocation.ToString().Contains(" ")
                        ? $"\"{ArbLocation}\""
                        : ArbLocation.ToString()
                );
            }

            if (InstrFrameTarget != null)
            {
                result.Add("\\t");
                string frameTargetText = FrameTargetUtils.FrameTargetText(InstrFrameTarget.Value);
                result.Add(
                    frameTargetText.Contains(" ") ? $"\"{frameTargetText}\"" : frameTargetText
                );
            }

            return string.Join(" ", result);
        }
    }
}
