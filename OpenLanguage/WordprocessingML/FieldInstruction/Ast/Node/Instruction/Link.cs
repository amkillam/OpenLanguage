using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum LinkArgument
    {
        ApplicationType,
        SourceFileLocation,
        SourceFilePortion,
        AutomaticallyUpdate,
        InsertAsBitmap,
        DontStoreGraphicData,
        FormattingMode,
        InsertAsHtml,
        InsertAsPicture,
        InsertAsRtf,
        InsertAsTextOnly,
        InsertAsUnicodeText,
    }

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
    /// Represents a strongly-typed LINK field instruction.
    /// For information copied from another application, this field links that information to its original source file using OLE.
    /// </summary>
    public class LinkFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The application type of the link information (field-argument-1).
        /// For example: "Excel.Sheet.8"
        /// </summary>
        public ExpressionNode ApplicationType { get; set; }

        /// <summary>
        /// The name and location of the source file (field-argument-2).
        /// </summary>
        public ExpressionNode? SourceFileLocation { get; set; }

        /// <summary>
        /// The portion of the source file being linked (field-argument-3, optional).
        /// For example: cell reference, named range, bookmark.
        ///
        /// Real example from enron dataset, with bang reference to Excel sheet:
        /// { LINK Excel.Sheet.8 "\\\\eulon\\london\\common\\Reporting Summary\\Executive Summary\\Inputs\\UK Power - Executive Summary.xls" "Delta Graphs![UK Power - Executive Summary.xls]Delta Graphs Chart 4" \p }
        /// </summary>
        public ExpressionNode? SourceFilePortion { get; set; }

        /// <summary>
        /// Switch: \a
        /// Causes this field to be updated automatically.
        /// </summary>
        public BoolFlagNode? AutomaticallyUpdate { get; set; }

        /// <summary>
        /// Switch: \b
        /// Inserts the linked object as a bitmap.
        /// </summary>
        public BoolFlagNode? InsertAsBitmap { get; set; }

        /// <summary>
        /// Switch: \d
        /// Don't store the graphic data with the document, thus reducing the file size.
        /// </summary>
        public BoolFlagNode? DontStoreGraphicData { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Causes the linked object to update its formatting in a particular way.
        /// </summary>
        public FlaggedArgument<LinkFormattingModeNode>? FormattingMode { get; set; }

        /// <summary>
        /// Switch: \h
        /// Inserts the linked object as HTML format text.
        /// </summary>
        public BoolFlagNode? InsertAsHtml { get; set; }

        /// <summary>
        /// Switch: \p
        /// Inserts the linked object as a picture.
        /// </summary>
        public BoolFlagNode? InsertAsPicture { get; set; }

        /// <summary>
        /// Switch: \r
        /// Inserts the linked object in rich-text format (RTF).
        /// </summary>
        public BoolFlagNode? InsertAsRtf { get; set; }

        /// <summary>
        /// Switch: \t
        /// Inserts the linked object in text-only format.
        /// </summary>
        public BoolFlagNode? InsertAsTextOnly { get; set; }

        /// <summary>
        /// Switch: \u
        /// Inserts the linked object as Unicode text.
        /// </summary>
        public BoolFlagNode? InsertAsUnicodeText { get; set; }

        public List<LinkArgument> Order { get; set; } = new List<LinkArgument>();

        public LinkFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode applicationType,
            ExpressionNode? sourceFileLocation,
            ExpressionNode? sourceFilePortion,
            BoolFlagNode? automaticallyUpdate,
            BoolFlagNode? insertAsBitmap,
            BoolFlagNode? dontStoreGraphicData,
            FlaggedArgument<LinkFormattingModeNode>? formattingMode,
            BoolFlagNode? insertAsHtml,
            BoolFlagNode? insertAsPicture,
            BoolFlagNode? insertAsRtf,
            BoolFlagNode? insertAsTextOnly,
            BoolFlagNode? insertAsUnicodeText,
            List<LinkArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            ApplicationType = applicationType;
            SourceFileLocation = sourceFileLocation;
            SourceFilePortion = sourceFilePortion;
            AutomaticallyUpdate = automaticallyUpdate;
            InsertAsBitmap = insertAsBitmap;
            DontStoreGraphicData = dontStoreGraphicData;
            FormattingMode = formattingMode;
            InsertAsHtml = insertAsHtml;
            InsertAsPicture = insertAsPicture;
            InsertAsRtf = insertAsRtf;
            InsertAsTextOnly = insertAsTextOnly;
            InsertAsUnicodeText = insertAsUnicodeText;

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
                        LinkArgument.ApplicationType => ApplicationType.ToString(),
                        LinkArgument.SourceFileLocation => SourceFileLocation?.ToString()
                            ?? string.Empty,
                        LinkArgument.SourceFilePortion => SourceFilePortion?.ToString()
                            ?? string.Empty,
                        LinkArgument.AutomaticallyUpdate => AutomaticallyUpdate?.ToString()
                            ?? string.Empty,
                        LinkArgument.InsertAsBitmap => InsertAsBitmap?.ToString() ?? string.Empty,
                        LinkArgument.DontStoreGraphicData => DontStoreGraphicData?.ToString()
                            ?? string.Empty,
                        LinkArgument.FormattingMode => FormattingMode?.ToString() ?? string.Empty,
                        LinkArgument.InsertAsHtml => InsertAsHtml?.ToString() ?? string.Empty,
                        LinkArgument.InsertAsPicture => InsertAsPicture?.ToString() ?? string.Empty,
                        LinkArgument.InsertAsRtf => InsertAsRtf?.ToString() ?? string.Empty,
                        LinkArgument.InsertAsTextOnly => InsertAsTextOnly?.ToString()
                            ?? string.Empty,
                        LinkArgument.InsertAsUnicodeText => InsertAsUnicodeText?.ToString()
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

            foreach (LinkArgument arg in Order)
            {
                Node? child = arg switch
                {
                    LinkArgument.ApplicationType => ApplicationType,
                    LinkArgument.SourceFileLocation => SourceFileLocation,
                    LinkArgument.SourceFilePortion => SourceFilePortion,
                    LinkArgument.AutomaticallyUpdate => AutomaticallyUpdate,
                    LinkArgument.InsertAsBitmap => InsertAsBitmap,
                    LinkArgument.DontStoreGraphicData => DontStoreGraphicData,
                    LinkArgument.FormattingMode => FormattingMode,
                    LinkArgument.InsertAsHtml => InsertAsHtml,
                    LinkArgument.InsertAsPicture => InsertAsPicture,
                    LinkArgument.InsertAsRtf => InsertAsRtf,
                    LinkArgument.InsertAsTextOnly => InsertAsTextOnly,
                    LinkArgument.InsertAsUnicodeText => InsertAsUnicodeText,
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
                    LinkArgument arg = Order[index];
                    switch (arg)
                    {
                        case LinkArgument.ApplicationType:
                            if (replacement is ExpressionNode applicationType)
                            {
                                current = ApplicationType;
                                ApplicationType = applicationType;
                            }
                            break;
                        case LinkArgument.SourceFileLocation:
                            if (replacement is ExpressionNode sourceFileLocation)
                            {
                                current = SourceFileLocation;
                                SourceFileLocation = sourceFileLocation;
                            }
                            break;
                        case LinkArgument.SourceFilePortion:
                            if (replacement is ExpressionNode sourceFilePortion)
                            {
                                current = SourceFilePortion;
                                SourceFilePortion = sourceFilePortion;
                            }
                            break;
                        case LinkArgument.AutomaticallyUpdate:
                            if (replacement is BoolFlagNode automaticallyUpdate)
                            {
                                current = AutomaticallyUpdate;
                                AutomaticallyUpdate = automaticallyUpdate;
                            }
                            break;
                        case LinkArgument.InsertAsBitmap:
                            if (replacement is BoolFlagNode insertAsBitmap)
                            {
                                current = InsertAsBitmap;
                                InsertAsBitmap = insertAsBitmap;
                            }
                            break;
                        case LinkArgument.DontStoreGraphicData:
                            if (replacement is BoolFlagNode dontStoreGraphicData)
                            {
                                current = DontStoreGraphicData;
                                DontStoreGraphicData = dontStoreGraphicData;
                            }
                            break;
                        case LinkArgument.FormattingMode:
                            if (
                                replacement
                                is FlaggedArgument<LinkFormattingModeNode> formattingMode
                            )
                            {
                                current = FormattingMode;
                                FormattingMode = formattingMode;
                            }
                            break;
                        case LinkArgument.InsertAsHtml:
                            if (replacement is BoolFlagNode insertAsHtml)
                            {
                                current = InsertAsHtml;
                                InsertAsHtml = insertAsHtml;
                            }
                            break;
                        case LinkArgument.InsertAsPicture:
                            if (replacement is BoolFlagNode insertAsPicture)
                            {
                                current = InsertAsPicture;
                                InsertAsPicture = insertAsPicture;
                            }
                            break;
                        case LinkArgument.InsertAsRtf:
                            if (replacement is BoolFlagNode insertAsRtf)
                            {
                                current = InsertAsRtf;
                                InsertAsRtf = insertAsRtf;
                            }
                            break;
                        case LinkArgument.InsertAsTextOnly:
                            if (replacement is BoolFlagNode insertAsTextOnly)
                            {
                                current = InsertAsTextOnly;
                                InsertAsTextOnly = insertAsTextOnly;
                            }
                            break;
                        case LinkArgument.InsertAsUnicodeText:
                            if (replacement is BoolFlagNode insertAsUnicodeText)
                            {
                                current = InsertAsUnicodeText;
                                InsertAsUnicodeText = insertAsUnicodeText;
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
