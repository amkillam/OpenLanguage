using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// Represents document property categories used in DOCPROPERTY field instructions.
    /// </summary>
    public enum DocumentPropertyCategory
    {
        /// <summary>
        /// AUTHOR - Document author information.
        /// </summary>
        Author,

        /// <summary>
        /// BYTES - Document file size in bytes.
        /// </summary>
        Bytes,

        /// <summary>
        /// CATEGORY - Document category from Core File Properties.
        /// </summary>
        Category,

        /// <summary>
        /// CHARACTERS - Number of characters in the document.
        /// </summary>
        Characters,

        /// <summary>
        /// CHARACTERSWITHSPACES - Number of characters including spaces.
        /// </summary>
        CharactersWithSpaces,

        /// <summary>
        /// COMMENTS - Document comments.
        /// </summary>
        Comments,

        /// <summary>
        /// COMPANY - Company name from Application-Defined File Properties.
        /// </summary>
        Company,

        /// <summary>
        /// CREATETIME - Document creation time.
        /// </summary>
        CreateTime,

        /// <summary>
        /// HYPERLINKBASE - Hyperlink base from Application-Defined File Properties.
        /// </summary>
        HyperlinkBase,

        /// <summary>
        /// KEYWORDS - Document keywords from Core File Properties.
        /// </summary>
        Keywords,

        /// <summary>
        /// LASTPRINTED - Last printed date.
        /// </summary>
        LastPrinted,

        /// <summary>
        /// LASTSAVEDBY - Last saved by user.
        /// </summary>
        LastSavedBy,

        /// <summary>
        /// LASTSAVEDTIME - Last saved time.
        /// </summary>
        LastSavedTime,

        /// <summary>
        /// LINES - Number of lines from Application-Defined File Properties.
        /// </summary>
        Lines,

        /// <summary>
        /// MANAGER - Manager name from Application-Defined File Properties.
        /// </summary>
        Manager,

        /// <summary>
        /// NAMEOFAPPLICATION - Application name from Application-Defined File Properties.
        /// </summary>
        NameOfApplication,

        /// <summary>
        /// ODMADOCID - ODMA document ID.
        /// </summary>
        OdmaDocId,

        /// <summary>
        /// PAGES - Number of pages in the document.
        /// </summary>
        Pages,

        /// <summary>
        /// PARAGRAPHS - Number of paragraphs from Application-Defined File Properties.
        /// </summary>
        Paragraphs,

        /// <summary>
        /// REVISIONNUMBER - Document revision number.
        /// </summary>
        RevisionNumber,

        /// <summary>
        /// SECURITY - Document security level from Application-Defined File Properties.
        /// </summary>
        Security,

        /// <summary>
        /// SUBJECT - Document subject.
        /// </summary>
        Subject,

        /// <summary>
        /// TEMPLATE - Document template.
        /// </summary>
        Template,

        /// <summary>
        /// TITLE - Document title.
        /// </summary>
        Title,

        /// <summary>
        /// TOTALEDITINGTIME - Total editing time.
        /// </summary>
        TotalEditingTime,

        /// <summary>
        /// WORDS - Number of words from Application-Defined File Properties.
        /// </summary>
        Words,
    }

    public enum DocPropertyArgument
    {
        PropertyName,
        PropertyCategoryArgument,
        GeneralFormat,
        HyperlinkSwitch,
        NumericFormat,
        DateTimeFormat,
    }

    /// <summary>
    /// Represents a strongly-typed DOCPROPERTY field instruction.
    /// Retrieves the indicated document information. For some combinations of DOCPROPERTY and docprop-category, there is an equivalent field, in which case, the description for the combination can be obtained from that field. For those combinations not having an equivalent field, the description is shown directly. When used directly, some of the equivalent fields allow the value of the designated property to be changed. However, when the corresponding DOCPROPERTY field is used, such values shall not be changed. This is indicated in the following table by "Read-only operation." Docprop-category Corresponding Field Description AUTHOR AUTHOR (AUTHOR) Read-only operation. BYTES FILESIZE (FILESIZE) CATEGORY No equivalent The contents of the <Category> element of the Core File Properties part. CHARACTERS NUMCHARS (NUMCHARS) CHARACTERSWITHSPACES No equivalent Like NUMCHARS, but includes all white space characters as well. COMMENTS COMMENTS (BIBLIOGRAPHYBIBLIOGR) Read-only operation. COMPANY No equivalent The contents of the <Company> element of the Application-Defined File Properties part. CREATETIME CREATEDATE (CREATEDATE) HYPERLINKBASE No equivalent The contents of the <HyperlinkBase> element of the Application-Defined File Properties part. KEYWORDS No equivalent The contents of the <Keywords> element of the Core File Properties part. LASTPRINTED PRINTDATE (PRINTDATE) LASTSAVEDBY LASTSAVEDBY (LASTSAVEDBYLASTSAVED) LASTSAVEDTIME SAVEDATE (SAVEDATE) LINES No equivalent The contents of the <Lines> element of the Application-Defined File Properties part. MANAGER No equivalent The contents of the <Manager> element of the Application-Defined File Properties part. NAMEOFAPPLICATION No equivalent The contents of the <Application> element of the Application-Defined File Properties part. ODMADOCID PAGES NUMPAGES (NUMPAGES) PARAGRAPHS No equivalent The contents of the <Paragraphs> element of the Application-Defined File Properties part. REVISIONNUMBER REVNUM (REVNUM) SECURITY No equivalent The contents of the <DocSecurity> element of the Application-Defined File Properties part. SUBJECT SUBJECT (SUBJECT) Read-only operation. TEMPLATE TEMPLATE (TEMPLATE) TITLE TITLE (TITLE) Read-only operation. TOTALEDITINGTIME EDITTIME (EDITTIME) WORDS No equivalent The contents of the <Words> element of the Application-Defined File Properties part.
    /// </summary>
    public class DocPropertyFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// The document property name to retrieve
        /// </summary>
        public ExpressionNode? PropertyName { get; set; }

        /// <summary>
        /// Optional field argument for the property (used with some categories)
        /// </summary>
        public ExpressionNode? PropertyCategoryArgument { get; set; }

        /// <summary>
        /// Switch: \*
        /// General formatting switch for the field value.
        /// </summary>
        public List<FlaggedArgument<ExpressionNode>> GeneralFormats { get; set; } =
            new List<FlaggedArgument<ExpressionNode>>();
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }
        public BoolFlagNode? HyperlinkSwitch { get; set; }

        public List<DocPropertyArgument> Order { get; set; } = new List<DocPropertyArgument>();

        public DocPropertyFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? propertyName,
            ExpressionNode? propertyCategoryArgument,
            List<FlaggedArgument<ExpressionNode>>? generalFormats,
            BoolFlagNode? hyperlinkSwitch,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            List<DocPropertyArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            PropertyName = propertyName;
            PropertyCategoryArgument = propertyCategoryArgument;
            GeneralFormats = generalFormats ?? new List<FlaggedArgument<ExpressionNode>>();
            HyperlinkSwitch = hyperlinkSwitch;
            NumericFormat = numericFormat;
            DateTimeFormat = dateTimeFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString()
        {
            Queue<FlaggedArgument<ExpressionNode>> generalFormatsQueue = new Queue<
                FlaggedArgument<ExpressionNode>
            >(GeneralFormats);
            return Instruction.ToString()
                + string.Concat(
                    Order.Select(o =>
                        o switch
                        {
                            DocPropertyArgument.PropertyName => PropertyName?.ToString()
                                ?? string.Empty,
                            DocPropertyArgument.PropertyCategoryArgument =>
                                PropertyCategoryArgument?.ToString() ?? string.Empty,
                            DocPropertyArgument.GeneralFormat => generalFormatsQueue.Any()
                                ? generalFormatsQueue.Dequeue().ToString()
                                : string.Empty,
                            DocPropertyArgument.HyperlinkSwitch => HyperlinkSwitch?.ToString()
                                ?? string.Empty,
                            DocPropertyArgument.NumericFormat => NumericFormat?.ToString()
                                ?? string.Empty,
                            DocPropertyArgument.DateTimeFormat => DateTimeFormat?.ToString()
                                ?? string.Empty,
                            _ => string.Empty,
                        }
                    )
                );
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }
            Queue<FlaggedArgument<ExpressionNode>> generalFormatsQueue = new Queue<
                FlaggedArgument<ExpressionNode>
            >(GeneralFormats);
            foreach (DocPropertyArgument child in Order)
            {
                Node? node = child switch
                {
                    DocPropertyArgument.PropertyName => PropertyName,
                    DocPropertyArgument.PropertyCategoryArgument => PropertyCategoryArgument,
                    DocPropertyArgument.GeneralFormat => generalFormatsQueue.Any()
                        ? generalFormatsQueue.Dequeue()
                        : null,
                    DocPropertyArgument.HyperlinkSwitch => HyperlinkSwitch,
                    DocPropertyArgument.NumericFormat => NumericFormat,
                    DocPropertyArgument.DateTimeFormat => DateTimeFormat,
                    _ => null,
                };
                if (node is O oChild)
                {
                    yield return oChild;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is StringLiteralNode newInstruction)
            {
                Node? oldInstruction = Instruction;
                Instruction = newInstruction;
                return oldInstruction;
            }

            int childIndex = 1;
            int generalFormatIndex = 0;

            foreach (DocPropertyArgument arg in Order)
            {
                if (childIndex == index)
                {
                    Node? current = null;
                    switch (arg)
                    {
                        case DocPropertyArgument.PropertyName:
                            if (replacement is ExpressionNode newPropertyName)
                            {
                                current = PropertyName;
                                PropertyName = newPropertyName;
                            }
                            return current;
                        case DocPropertyArgument.PropertyCategoryArgument:
                            if (replacement is ExpressionNode newPropertyCategoryArgument)
                            {
                                current = PropertyCategoryArgument;
                                PropertyCategoryArgument = newPropertyCategoryArgument;
                            }
                            return current;
                        case DocPropertyArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> newGeneralFormat)
                            {
                                current = GeneralFormats[generalFormatIndex];
                                GeneralFormats[generalFormatIndex] = newGeneralFormat;
                            }
                            return current;
                        case DocPropertyArgument.HyperlinkSwitch:
                            if (replacement is BoolFlagNode newHyperlinkSwitch)
                            {
                                current = HyperlinkSwitch;
                                HyperlinkSwitch = newHyperlinkSwitch;
                            }
                            return current;
                        case DocPropertyArgument.NumericFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> newNumericFormat)
                            {
                                current = NumericFormat;
                                NumericFormat = newNumericFormat;
                            }
                            return current;
                        case DocPropertyArgument.DateTimeFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> newDateTimeFormat)
                            {
                                current = DateTimeFormat;
                                DateTimeFormat = newDateTimeFormat;
                            }
                            return current;
                    }
                }

                if (arg == DocPropertyArgument.GeneralFormat)
                {
                    generalFormatIndex++;
                }
                childIndex++;
            }

            return null;
        }
    }
}
