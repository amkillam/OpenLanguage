using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed SEQ field instruction.
    /// Sequentially numbers chapters, tables, figures, and other user-defined lists of items in a document.
    /// If an item and its SEQ field are added, deleted, or moved, updating the remaining SEQ fields in the
    /// document reflects the new sequence. A SEQ field in a header, footer, annotation, or footnote shall NOT affect
    /// the sequence numbering that results from SEQ fields in the document text.
    ///
    /// Syntax: SEQ identifier [ field-argument ] [ switches ]
    ///
    /// The identifier is the name assigned to the series of items that are to be numbered (e.g., Equation, Figure, Table, Thing).
    /// The identifier shall start with a Latin letter and shall consist of no more than 40 Latin letters, Arabic digits, and underscores.
    ///
    /// The optional field-argument specifies a bookmark name that refers to an item elsewhere in the document
    /// rather than in the current location.
    ///
    /// Field Value: The next number in the sequence. If no numeric-formatting-switch is present, \* Arabic is used.
    ///
    /// Switches:
    /// - \c: Repeats the closest preceding sequence number (useful for inserting chapter numbers in headers or footers)
    /// - \h: Hides the field result unless a general-formatting-switch is also present (useful for cross-references)
    /// - \n: Inserts the next sequence number for the specified item (this is the default behavior)
    /// - \r field-argument: Resets the sequence number to the integer number specified by the field-argument
    /// - \s field-argument: Resets the sequence number to the built-in (integer) heading level specified by the field-argument
    /// </summary>
    public class SeqFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The identifier - name assigned to the series of items that are to be numbered.
        /// Must start with a Latin letter and consist of no more than 40 Latin letters, Arabic digits, and underscores.
        /// Examples: Equation, Figure, Table, Thing
        /// </summary>
        public string? SequenceName { get; set; }

        /// <summary>
        /// Optional field-argument specifying a bookmark name that refers to an item elsewhere in the document
        /// rather than in the current location.
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \c
        /// Repeats the closest preceding sequence number.
        /// This is useful for inserting chapter numbers in headers or footers.
        /// </summary>
        public bool RepeatPreviousNumber { get; set; }

        /// <summary>
        /// Switch: \h
        /// Hides the field result unless a general-formatting-switch is also present.
        /// This switch can be used to refer to a SEQ field in a cross-reference without printing the number.
        /// </summary>
        public bool Hide { get; set; }

        /// <summary>
        /// Switch: \n
        /// Inserts the next sequence number for the specified item. This is the default behavior.
        /// </summary>
        public bool InsertNext { get; set; }

        /// <summary>
        /// Switch: \r field-argument
        /// Resets the sequence number to the integer number specified by text in this switch's field-argument.
        /// </summary>
        public int? ResetToNumber { get; set; }

        /// <summary>
        /// Switch: \s field-argument
        /// Resets the sequence number to the built-in (integer) heading level specified by text in this switch's field-argument.
        /// </summary>
        public int? ResetToHeadingLevel { get; set; }

        /// <summary>
        /// Initializes a new instance of the SeqFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public SeqFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "SEQ")
            {
                throw new ArgumentException($"Expected SEQ field, but got {Source.Instruction}");
            }

            // Parse identifier (first non-switch argument)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );
            if (firstNonSwitch != null)
            {
                SequenceName = firstNonSwitch.Value?.ToString();

                // Validate identifier constraints according to OOXML specification
                if (!string.IsNullOrEmpty(SequenceName))
                {
                    ValidateIdentifier(SequenceName);
                }
            }

            // Parse optional field-argument (bookmark name) - this would be the second non-switch argument
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg =>
                    arg.Type == FieldArgumentType.Identifier
                    || arg.Type == FieldArgumentType.StringLiteral
                )
                .ToList();

            if (nonSwitchArgs.Count > 1)
            {
                BookmarkName = nonSwitchArgs[1].Value?.ToString();
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
                        case "\\c":
                            RepeatPreviousNumber = true;
                            break;

                        case "\\h":
                            Hide = true;
                            break;

                        case "\\n":
                            InsertNext = true;
                            break;

                        case "\\r":
                            // Find the next argument as the switch argument
                            ResetToNumber = GetIntegerArgumentAfterSwitch(i);
                            break;

                        case "\\s":
                            // Find the next argument as the switch argument
                            ResetToHeadingLevel = GetIntegerArgumentAfterSwitch(i);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Validates the identifier according to OOXML specification constraints.
        /// Identifier shall start with a Latin letter and shall consist of no more than 40 Latin letters, Arabic digits, and underscores.
        /// </summary>
        /// <param name="identifier">The identifier to validate.</param>
        private void ValidateIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException("SEQ identifier cannot be null or empty");
            }

            if (identifier.Length > 40)
            {
                throw new ArgumentException("SEQ identifier cannot be longer than 40 characters");
            }

            if (!char.IsLetter(identifier[0]))
            {
                throw new ArgumentException("SEQ identifier must start with a Latin letter");
            }

            foreach (char c in identifier)
            {
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    throw new ArgumentException(
                        "SEQ identifier can only contain Latin letters, Arabic digits, and underscores"
                    );
                }
            }
        }

        /// <summary>
        /// Gets an integer argument following the specified switch index.
        /// </summary>
        /// <param name="switchIndex">The index of the switch.</param>
        /// <returns>The integer argument following the switch, or null if none exists or cannot be parsed.</returns>
        private int? GetIntegerArgumentAfterSwitch(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    string? argString = nextArg.Value?.ToString();
                    if (argString != null && int.TryParse(argString, out int value))
                    {
                        return value;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            // Add identifier (required)
            if (SequenceName != null)
            {
                string argString = SequenceName.ToString();
                result.Add(
                    argString.Contains(" ") && !argString.StartsWith("\"")
                        ? $"\"{SequenceName}\""
                        : argString
                );
            }

            // Add optional field-argument (bookmark name)
            if (BookmarkName != null)
            {
                string bookmarkString = BookmarkName.ToString();
                result.Add(
                    bookmarkString.Contains(" ") && !bookmarkString.StartsWith("\"")
                        ? $"\"{BookmarkName}\""
                        : bookmarkString
                );
            }

            // Add switches in alphabetical order for consistency
            if (RepeatPreviousNumber)
            {
                result.Add("\\c");
            }

            if (Hide)
            {
                result.Add("\\h");
            }

            if (InsertNext)
            {
                result.Add("\\n");
            }

            if (ResetToNumber != null)
            {
                result.Add("\\r");
                result.Add(ResetToNumber.ToString()!);
            }

            if (ResetToHeadingLevel != null)
            {
                result.Add("\\s");
                result.Add(ResetToHeadingLevel.ToString()!);
            }

            return string.Join(" ", result);
        }
    }
}
