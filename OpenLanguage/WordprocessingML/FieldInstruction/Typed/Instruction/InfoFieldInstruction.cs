using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents the information categories available for INFO field instructions.
    /// </summary>
    public enum InfoType
    {
        /// <summary>
        /// AUTHOR - Document author information.
        /// </summary>
        Author,

        /// <summary>
        /// COMMENTS - Document comments.
        /// </summary>
        Comments,

        /// <summary>
        /// CREATEDATE - Document creation date.
        /// </summary>
        CreateDate,

        /// <summary>
        /// EDITTIME - Total editing time.
        /// </summary>
        EditTime,

        /// <summary>
        /// FILENAME - Document filename.
        /// </summary>
        FileName,

        /// <summary>
        /// FILESIZE - Document file size.
        /// </summary>
        FileSize,

        /// <summary>
        /// KEYWORDS - Document keywords.
        /// </summary>
        Keywords,

        /// <summary>
        /// LASTSAVEDBY - Last saved by information.
        /// </summary>
        LastSavedBy,

        /// <summary>
        /// NUMCHARS - Number of characters in document.
        /// </summary>
        NumChars,

        /// <summary>
        /// NUMPAGES - Number of pages in document.
        /// </summary>
        NumPages,

        /// <summary>
        /// NUMWORDS - Number of words in document.
        /// </summary>
        NumWords,

        /// <summary>
        /// PRINTDATE - Document print date.
        /// </summary>
        PrintDate,

        /// <summary>
        /// REVNUM - Document revision number.
        /// </summary>
        RevNum,

        /// <summary>
        /// SAVEDATE - Document save date.
        /// </summary>
        SaveDate,

        /// <summary>
        /// SUBJECT - Document subject.
        /// </summary>
        Subject,

        /// <summary>
        /// TEMPLATE - Template name.
        /// </summary>
        Template,

        /// <summary>
        /// TITLE - Document title.
        /// </summary>
        Title,
    }

    /// <summary>
    /// Represents a strongly-typed INFO field instruction.
    /// A field of this kind is treated as if INFO was omitted and info-category was a field-type name.
    /// </summary>
    public class InfoFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The information category to retrieve (required).
        /// </summary>
        public InfoType InformationCategory { get; set; }

        /// <summary>
        /// Optional field argument for the info category.
        /// </summary>
        public string? FieldArgument { get; set; }

        /// <summary>
        /// Initializes a new instance of the InfoFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public InfoFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "INFO")
            {
                throw new ArgumentException($"Expected INFO field, but got {Source.Instruction}");
            }

            // INFO requires at least one argument: the info-category
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            if (nonSwitchArgs.Count < 1)
            {
                throw new ArgumentException("INFO field requires an info-category argument");
            }

            // Parse required info-category
            string categoryText = nonSwitchArgs[0].Value?.ToString() ?? string.Empty;
            InformationCategory = ParseInfoCategory(categoryText);

            // Parse optional field argument
            if (nonSwitchArgs.Count >= 2)
            {
                FieldArgument = nonSwitchArgs[1].Value?.ToString();
            }
        }

        /// <summary>
        /// Parses an info category string into the InfoType enum.
        /// </summary>
        /// <param name="categoryText">The category text to parse.</param>
        /// <returns>The corresponding InfoType value.</returns>
        private InfoType ParseInfoCategory(string categoryText)
        {
            return categoryText?.ToUpperInvariant() switch
            {
                "AUTHOR" => InfoType.Author,
                "COMMENTS" => InfoType.Comments,
                "CREATEDATE" => InfoType.CreateDate,
                "EDITTIME" => InfoType.EditTime,
                "FILENAME" => InfoType.FileName,
                "FILESIZE" => InfoType.FileSize,
                "KEYWORDS" => InfoType.Keywords,
                "LASTSAVEDBY" => InfoType.LastSavedBy,
                "NUMCHARS" => InfoType.NumChars,
                "NUMPAGES" => InfoType.NumPages,
                "NUMWORDS" => InfoType.NumWords,
                "PRINTDATE" => InfoType.PrintDate,
                "REVNUM" => InfoType.RevNum,
                "SAVEDATE" => InfoType.SaveDate,
                "SUBJECT" => InfoType.Subject,
                "TEMPLATE" => InfoType.Template,
                "TITLE" => InfoType.Title,
                _ => throw new ArgumentException($"Unknown info category: {categoryText}"),
            };
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            // Add the required info-category
            result.Add(InfoCategoryToString(InformationCategory));

            // Add optional field argument
            if (!string.IsNullOrEmpty(FieldArgument))
            {
                result.Add(
                    FieldArgument.Contains(" ") && !FieldArgument.StartsWith("\"")
                        ? $"\"{FieldArgument}\""
                        : FieldArgument
                );
            }

            return string.Join(" ", result);
        }

        /// <summary>
        /// Converts an InfoType enum value to its string representation.
        /// </summary>
        /// <param name="infoType">The InfoType to convert.</param>
        /// <returns>The string representation of the info type.</returns>
        private string InfoCategoryToString(InfoType infoType)
        {
            return infoType switch
            {
                InfoType.Author => "AUTHOR",
                InfoType.Comments => "COMMENTS",
                InfoType.CreateDate => "CREATEDATE",
                InfoType.EditTime => "EDITTIME",
                InfoType.FileName => "FILENAME",
                InfoType.FileSize => "FILESIZE",
                InfoType.Keywords => "KEYWORDS",
                InfoType.LastSavedBy => "LASTSAVEDBY",
                InfoType.NumChars => "NUMCHARS",
                InfoType.NumPages => "NUMPAGES",
                InfoType.NumWords => "NUMWORDS",
                InfoType.PrintDate => "PRINTDATE",
                InfoType.RevNum => "REVNUM",
                InfoType.SaveDate => "SAVEDATE",
                InfoType.Subject => "SUBJECT",
                InfoType.Template => "TEMPLATE",
                InfoType.Title => "TITLE",
                _ => throw new ArgumentException($"Unknown info type: {infoType}"),
            };
        }
    }
}
