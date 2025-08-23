using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage
{
    /// <summary>
    /// Represents a strongly-typed ASK field instruction.
    /// Prompts the user to enter information and assigns it to a bookmark.
    /// </summary>
    public class AskFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The bookmark name to assign the user's response to (field-argument-1).
        /// </summary>
        public string BookmarkName { get; set; } = string.Empty;

        /// <summary>
        /// The prompt text to display to the user (field-argument-2).
        /// </summary>
        public string PromptText { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \d field-argument
        /// Default response if none is entered.
        /// </summary>
        public string? DefaultResponse { get; set; }

        /// <summary>
        /// Switch: \o
        /// Display prompt once per mail merge instead of for each record.
        /// </summary>
        public bool PromptOnce { get; set; }

        /// <summary>
        /// Initializes a new instance of the AskFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public AskFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Gets the next argument after the specified switch index.
        /// </summary>
        private string GetNextArgumentAfter(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString() ?? "";
                }
            }
            return "";
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "ASK")
            {
                throw new ArgumentException($"Expected ASK field, but got {Source.Instruction}");
            }

            // ASK requires exactly 2 field arguments: bookmark name and prompt text
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg =>
                    arg.Type == FieldArgumentType.Identifier
                    || arg.Type == FieldArgumentType.StringLiteral
                )
                .ToList();

            BookmarkName = nonSwitchArgs.Count > 0 ? nonSwitchArgs[0].Value?.ToString() ?? "" : "";
            PromptText = nonSwitchArgs.Count > 1 ? nonSwitchArgs[1].Value?.ToString() ?? "" : "";

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
                            DefaultResponse = GetNextArgumentAfter(i);
                            break;
                        case "\\o":
                            PromptOnce = true;
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
            List<string> result = new List<string> { "ASK" };

            // Add bookmark name (field-argument-1)
            if (!string.IsNullOrEmpty(BookmarkName))
            {
                result.Add(
                    BookmarkName.Contains(" ") && !BookmarkName.StartsWith("\"")
                        ? $"\"{BookmarkName}\""
                        : BookmarkName
                );
            }

            // Add prompt text (field-argument-2)
            if (!string.IsNullOrEmpty(PromptText))
            {
                result.Add(
                    PromptText.Contains(" ") && !PromptText.StartsWith("\"")
                        ? $"\"{PromptText}\""
                        : PromptText
                );
            }

            // Add switches
            if (!string.IsNullOrWhiteSpace(DefaultResponse))
            {
                result.Add("\\d");
                result.Add(
                    DefaultResponse.Contains(" ") && !DefaultResponse.StartsWith("\"")
                        ? $"\"{DefaultResponse}\""
                        : DefaultResponse
                );
            }

            if (PromptOnce)
            {
                result.Add("\\o");
            }

            return string.Join(" ", result);
        }
    }
}
