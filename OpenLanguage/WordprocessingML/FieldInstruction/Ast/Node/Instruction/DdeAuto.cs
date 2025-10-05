using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    /// <summary>
    /// For information copied from another application, this field links that information to its original source file using DDE and is updated automatically.
    /// </summary>
    public enum DdeAutoArgument
    {
        ApplicationName,
        FileName,
        BookmarkName,
        Bitmap,
        NoStore,
        Html,
        Picture,
        Rtf,
        Text,
        Unicode,
        GeneralFormat,
        NumericFormat,
        DateTimeFormat,
    }

    public class DdeAutoFieldInstruction : FieldInstruction
    {
        /// <summary>
        /// The application name.
        /// </summary>
        public ExpressionNode? ApplicationName { get; set; }

        /// <summary>
        /// The name and location of the source file.
        /// </summary>
        public ExpressionNode? FileName { get; set; }

        /// <summary>
        /// The portion of the source file that is being linked.
        /// </summary>
        public ExpressionNode? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \b
        /// Requests the linked object as a bitmap.
        /// </summary>
        public BoolFlagNode? Bitmap { get; set; }

        /// <summary>
        /// Switch: \d
        /// Specifies that the graphic data shall not be stored with the document, thus reducing the file size.
        /// Word does not support this switch.
        /// </summary>
        public BoolFlagNode? NoStore { get; set; }

        /// <summary>
        /// Switch: \h
        /// Requests the linked object as HTML-formatted text.
        /// </summary>
        public BoolFlagNode? Html { get; set; }

        /// <summary>
        /// Switch: \p
        /// Requests the linked object as a picture.
        /// </summary>
        public BoolFlagNode? Picture { get; set; }

        /// <summary>
        /// Switch: \r
        /// Requests the linked object in rich-text format (RTF).
        /// </summary>
        public BoolFlagNode? Rtf { get; set; }

        /// <summary>
        /// Switch: \t
        /// Requests the linked object in text-only format.
        /// </summary>
        public BoolFlagNode? Text { get; set; }

        /// <summary>
        /// General formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        /// <summary>
        /// Numeric formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }

        /// <summary>
        /// Date-time formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }

        /// <summary>
        /// Switch: \u
        /// Requests the linked object as Unicode text.
        /// Word does not support this switch.
        /// </summary>
        public BoolFlagNode? Unicode { get; set; }

        public List<DdeAutoArgument> Order { get; set; } = new List<DdeAutoArgument>();

        public DdeAutoFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? applicationName,
            ExpressionNode? fileName,
            ExpressionNode? bookmarkName,
            BoolFlagNode? bitmap,
            BoolFlagNode? noStore,
            BoolFlagNode? html,
            BoolFlagNode? picture,
            BoolFlagNode? rtf,
            BoolFlagNode? text,
            BoolFlagNode? unicode,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            List<DdeAutoArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            ApplicationName = applicationName;
            FileName = fileName;
            BookmarkName = bookmarkName;
            Bitmap = bitmap;
            NoStore = noStore;
            Html = html;
            Picture = picture;
            Rtf = rtf;
            Text = text;
            Unicode = unicode;
            Order = order;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            DateTimeFormat = dateTimeFormat;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        DdeAutoArgument.ApplicationName => ApplicationName?.ToString()
                            ?? string.Empty,
                        DdeAutoArgument.FileName => FileName?.ToString() ?? string.Empty,
                        DdeAutoArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        DdeAutoArgument.Bitmap => Bitmap?.ToString() ?? string.Empty,
                        DdeAutoArgument.NoStore => NoStore?.ToString() ?? string.Empty,
                        DdeAutoArgument.Html => Html?.ToString() ?? string.Empty,
                        DdeAutoArgument.Picture => Picture?.ToString() ?? string.Empty,
                        DdeAutoArgument.Rtf => Rtf?.ToString() ?? string.Empty,
                        DdeAutoArgument.Text => Text?.ToString() ?? string.Empty,
                        DdeAutoArgument.Unicode => Unicode?.ToString() ?? string.Empty,
                        DdeAutoArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        DdeAutoArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        DdeAutoArgument.DateTimeFormat => DateTimeFormat?.ToString()
                            ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o1)
            {
                yield return o1;
            }
            foreach (DdeAutoArgument arg in Order)
            {
                Node? child = arg switch
                {
                    DdeAutoArgument.ApplicationName => ApplicationName,
                    DdeAutoArgument.FileName => FileName,
                    DdeAutoArgument.BookmarkName => BookmarkName,
                    DdeAutoArgument.Bitmap => Bitmap,
                    DdeAutoArgument.NoStore => NoStore,
                    DdeAutoArgument.Html => Html,
                    DdeAutoArgument.Picture => Picture,
                    DdeAutoArgument.Rtf => Rtf,
                    DdeAutoArgument.Text => Text,
                    DdeAutoArgument.Unicode => Unicode,
                    DdeAutoArgument.GeneralFormat => GeneralFormat,
                    DdeAutoArgument.NumericFormat => NumericFormat,
                    DdeAutoArgument.DateTimeFormat => DateTimeFormat,
                    _ => null,
                };
                if (child is O oChild)
                {
                    yield return oChild;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0)
            {
                if (replacement is StringLiteralNode instr)
                {
                    current = Instruction;
                    Instruction = instr;
                }
                return current;
            }

            index--;
            if (index >= 0 && index < Order.Count)
            {
                DdeAutoArgument arg = Order[index];
                switch (arg)
                {
                    case DdeAutoArgument.ApplicationName:
                        if (replacement is ExpressionNode appName)
                        {
                            current = ApplicationName;
                            ApplicationName = appName;
                        }
                        break;
                    case DdeAutoArgument.FileName:
                        if (replacement is ExpressionNode fileName)
                        {
                            current = FileName;
                            FileName = fileName;
                        }
                        break;
                    case DdeAutoArgument.BookmarkName:
                        if (replacement is ExpressionNode bookmarkName)
                        {
                            current = BookmarkName;
                            BookmarkName = bookmarkName;
                        }
                        break;
                    case DdeAutoArgument.Bitmap:
                        if (replacement is BoolFlagNode bitmap)
                        {
                            current = Bitmap;
                            Bitmap = bitmap;
                        }
                        break;
                    case DdeAutoArgument.NoStore:
                        if (replacement is BoolFlagNode noStore)
                        {
                            current = NoStore;
                            NoStore = noStore;
                        }
                        break;
                    case DdeAutoArgument.Html:
                        if (replacement is BoolFlagNode html)
                        {
                            current = Html;
                            Html = html;
                        }
                        break;
                    case DdeAutoArgument.Picture:
                        if (replacement is BoolFlagNode picture)
                        {
                            current = Picture;
                            Picture = picture;
                        }
                        break;
                    case DdeAutoArgument.Rtf:
                        if (replacement is BoolFlagNode rtf)
                        {
                            current = Rtf;
                            Rtf = rtf;
                        }
                        break;
                    case DdeAutoArgument.Text:
                        if (replacement is BoolFlagNode text)
                        {
                            current = Text;
                            Text = text;
                        }
                        break;
                    case DdeAutoArgument.Unicode:
                        if (replacement is BoolFlagNode unicode)
                        {
                            current = Unicode;
                            Unicode = unicode;
                        }
                        break;
                    case DdeAutoArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> gf)
                        {
                            current = GeneralFormat;
                            GeneralFormat = gf;
                        }
                        break;
                    case DdeAutoArgument.NumericFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> nf)
                        {
                            current = NumericFormat;
                            NumericFormat = nf;
                        }
                        break;
                    case DdeAutoArgument.DateTimeFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> df)
                        {
                            current = DateTimeFormat;
                            DateTimeFormat = df;
                        }
                        break;
                }
            }
            return current;
        }
    }
}
