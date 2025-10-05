using System;
using System.Collections.Generic;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
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

    public static class InfoTypeExtensions
    {
        public static string ToString(this InfoType infoType)
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
                _ => throw new ArgumentOutOfRangeException(
                    nameof(infoType),
                    $"Unhandled info type: {infoType}"
                ),
            };
        }
    }

    public class InfoTypeNode : ExpressionNode
    {
        public InfoType InfoType { get; set; }

        public InfoTypeNode(
            InfoType infoType,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            InfoType = infoType;
        }

        public override string ToRawString()
        {
            return OpenLanguage.WordprocessingML.FieldInstruction.InfoTypeExtensions.ToString(
                InfoType
            );
        }

        public override IEnumerable<O> Children<O>()
        {
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement) => null;
    }
}
