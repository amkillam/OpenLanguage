using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed REF field instruction.
    /// Inserts the text or graphics represented by the bookmark specified by text in field-argument.
    /// The bookmark shall be defined in the current document.
    /// </summary>
    public class RefFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The bookmark name to reference.
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \d field-argument
        /// Specifies the character sequence that is used to separate sequence numbers and page numbers.
        /// </summary>
        public string? SeparatorSequence { get; set; }

        /// <summary>
        /// Switch: \f
        /// Increments footnote, endnote, and annotation numbers that are marked by the bookmark, and inserts the corresponding footnote, endnote, and comment text.
        /// </summary>
        public bool IncrementFootnote { get; set; }

        /// <summary>
        /// Switch: \h
        /// Creates a hyperlink to the bookmarked paragraph.
        /// </summary>
        public bool CreateHyperlink { get; set; }

        /// <summary>
        /// Switch: \n
        /// For a referenced paragraph, causes the field result to have the entire paragraph number without trailing periods.
        /// </summary>
        public bool InsertParagraphNumber { get; set; }

        /// <summary>
        /// Switch: \p
        /// Causes the field result to contain the position relative to the source bookmark using the word "above" or "below".
        /// </summary>
        public bool RelativePosition { get; set; }

        /// <summary>
        /// Switch: \r
        /// Inserts the entire paragraph number of the bookmarked paragraph in relative context.
        /// </summary>
        public bool InsertParagraphNumberRelative { get; set; }

        /// <summary>
        /// Switch: \t
        /// Causes the REF field to suppress non-delimiter or non-numerical text when used in conjunction with the \n, \r, or \w switch.
        /// </summary>
        public bool SuppressText { get; set; }

        /// <summary>
        /// Switch: \w
        /// Inserts the paragraph number of the bookmarked paragraph in full context from anywhere in the document.
        /// </summary>
        public bool FullContextParagraphNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the RefFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public RefFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "REF")
            {
                throw new ArgumentException($"Expected REF field, but got {Source.Instruction}");
            }

            // Parse primary field argument (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                BookmarkName = firstNonSwitch.Value?.ToString();
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
                        case "\\d":
                            // Find the next argument as the switch argument
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    SeparatorSequence = nextArg.Value?.ToString();
                                }
                            }
                            break;
                        case "\\f":
                            IncrementFootnote = true;
                            break;
                        case "\\h":
                            CreateHyperlink = true;
                            break;
                        case "\\n":
                            InsertParagraphNumber = true;
                            break;
                        case "\\p":
                            RelativePosition = true;
                            break;
                        case "\\r":
                            InsertParagraphNumberRelative = true;
                            break;
                        case "\\t":
                            SuppressText = true;
                            break;
                        case "\\w":
                            FullContextParagraphNumber = true;
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

            if (BookmarkName != null)
            {
                string argString = BookmarkName.ToString();
                result.Add(argString.Contains(" ") ? $"\"{BookmarkName}\"" : argString);
            }

            if (SeparatorSequence != null)
            {
                result.Add("\\d");
                result.Add(
                    SeparatorSequence.ToString().Contains(" ")
                        ? $"\"{SeparatorSequence}\""
                        : SeparatorSequence.ToString()
                );
            }

            if (IncrementFootnote)
            {
                result.Add("\\f");
            }

            if (CreateHyperlink)
            {
                result.Add("\\h");
            }

            if (InsertParagraphNumber)
            {
                result.Add("\\n");
            }

            if (RelativePosition)
            {
                result.Add("\\p");
            }

            if (InsertParagraphNumberRelative)
            {
                result.Add("\\r");
            }

            if (SuppressText)
            {
                result.Add("\\t");
            }

            if (FullContextParagraphNumber)
            {
                result.Add("\\w");
            }

            return string.Join(" ", result);
        }
    }
}
