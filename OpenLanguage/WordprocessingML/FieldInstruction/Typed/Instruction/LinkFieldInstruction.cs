using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed LINK field instruction.
    /// For information copied from another application, this field links that information to its original source file using OLE.
    /// </summary>
    public class LinkFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The application type of the link information (field-argument-1).
        /// For example: "Excel.Sheet.8"
        /// </summary>
        public string ApplicationType { get; set; } = string.Empty;

        /// <summary>
        /// The name and location of the source file (field-argument-2).
        /// </summary>
        public string SourceFileLocation { get; set; } = string.Empty;

        /// <summary>
        /// The portion of the source file being linked (field-argument-3, optional).
        /// For example: cell reference, named range, bookmark.
        /// </summary>
        public string? SourceFilePortion { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \a
        /// Causes this field to be updated automatically.
        /// </summary>
        public bool AutomaticallyUpdate { get; set; }

        /// <summary>
        /// Switch: \b
        /// Inserts the linked object as a bitmap.
        /// </summary>
        public bool InsertAsBitmap { get; set; }

        /// <summary>
        /// Switch: \d
        /// Don't store the graphic data with the document, thus reducing the file size.
        /// </summary>
        public bool DontStoreGraphicData { get; set; }

        /// <summary>
        /// <summary>
        /// Enum for the formatting mode of a LINK field.
        /// </summary>
        public enum LinkFormattingMode
        {
            MaintainSourceFormatting = 0,
            NotSupportedOne = 1,
            MatchDestinationFormatting = 2,
            NotSupportedThree = 3,
            MaintainSourceFormattingSpreadsheet = 4,
            MatchDestinationFormattingSpreadsheet = 5,
        }

        /// <summary>
        /// Switch: \f field-argument
        /// Causes the linked object to update its formatting in a particular way.
        /// </summary>
        public LinkFormattingMode? FormattingMode { get; set; }

        /// <summary>
        /// Switch: \h
        /// Inserts the linked object as HTML format text.
        /// </summary>
        public bool InsertAsHtml { get; set; }

        /// <summary>
        /// Switch: \p
        /// Inserts the linked object as a picture.
        /// </summary>
        public bool InsertAsPicture { get; set; }

        /// <summary>
        /// Switch: \r
        /// Inserts the linked object in rich-text format (RTF).
        /// </summary>
        public bool InsertAsRtf { get; set; }

        /// <summary>
        /// Switch: \t
        /// Inserts the linked object in text-only format.
        /// </summary>
        public bool InsertAsTextOnly { get; set; }

        /// <summary>
        /// Switch: \u
        /// Inserts the linked object as Unicode text.
        /// </summary>
        public bool InsertAsUnicodeText { get; set; }

        /// <summary>
        /// Initializes a new instance of the LinkFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public LinkFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "LINK")
            {
                throw new ArgumentException($"Expected LINK field, but got {Source.Instruction}");
            }

            // LINK requires at least 2 field arguments, optionally 3
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            // Parse field-argument-1: application type
            ApplicationType =
                nonSwitchArgs.Count > 0
                    ? nonSwitchArgs[0].Value?.ToString() ?? string.Empty
                    : string.Empty;

            // Parse field-argument-2: source file location
            SourceFileLocation =
                nonSwitchArgs.Count > 1
                    ? nonSwitchArgs[1].Value?.ToString() ?? string.Empty
                    : string.Empty;

            // Parse optional field-argument-3: source file portion
            if (nonSwitchArgs.Count > 2)
            {
                string? argString = nonSwitchArgs[2].Value?.ToString();
                if (!string.IsNullOrEmpty(argString))
                {
                    SourceFilePortion = argString;
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
                        case "\\a":
                            AutomaticallyUpdate = true;
                            break;
                        case "\\b":
                            InsertAsBitmap = true;
                            break;
                        case "\\d":
                            DontStoreGraphicData = true;
                            break;
                        case "\\f":
                            // Parse the formatting mode argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    if (
                                        int.TryParse(nextArg.Value?.ToString(), out int mode)
                                        && Enum.IsDefined(typeof(LinkFormattingMode), mode)
                                    )
                                    {
                                        FormattingMode = (LinkFormattingMode)mode;
                                        i++; // Skip the consumed argument
                                    }
                                }
                            }
                            break;
                        case "\\h":
                            InsertAsHtml = true;
                            break;
                        case "\\p":
                            InsertAsPicture = true;
                            break;
                        case "\\r":
                            InsertAsRtf = true;
                            break;
                        case "\\t":
                            InsertAsTextOnly = true;
                            break;
                        case "\\u":
                            InsertAsUnicodeText = true;
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

            // Add field-argument-1: application type
            if (!string.IsNullOrEmpty(ApplicationType))
            {
                result.Add(
                    ApplicationType.Contains(" ") ? $"\"{ApplicationType}\"" : ApplicationType
                );
            }

            // Add field-argument-2: source file location
            if (!string.IsNullOrEmpty(SourceFileLocation))
            {
                result.Add(
                    SourceFileLocation.Contains(" ")
                        ? $"\"{SourceFileLocation}\""
                        : SourceFileLocation
                );
            }

            // Add optional field-argument-3: source file portion
            if (!string.IsNullOrEmpty(SourceFilePortion))
            {
                result.Add(
                    SourceFilePortion.Contains(" ") ? $"\"{SourceFilePortion}\"" : SourceFilePortion
                );
            }

            // Add switches
            if (AutomaticallyUpdate)
            {
                result.Add("\\a");
            }

            if (InsertAsBitmap)
            {
                result.Add("\\b");
            }

            if (DontStoreGraphicData)
            {
                result.Add("\\d");
            }

            if (FormattingMode.HasValue)
            {
                result.Add("\\f");
                result.Add(((int)FormattingMode.Value).ToString());
            }

            if (InsertAsHtml)
            {
                result.Add("\\h");
            }

            if (InsertAsPicture)
            {
                result.Add("\\p");
            }

            if (InsertAsRtf)
            {
                result.Add("\\r");
            }

            if (InsertAsTextOnly)
            {
                result.Add("\\t");
            }

            if (InsertAsUnicodeText)
            {
                result.Add("\\u");
            }

            return string.Join(" ", result);
        }
    }
}
