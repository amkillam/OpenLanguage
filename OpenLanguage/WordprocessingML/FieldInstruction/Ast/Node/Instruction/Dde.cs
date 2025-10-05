using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum DdeArgument
    {
        ApplicationName,
        FileName,
        BookmarkName,
        AutoUpdate,
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

    /// <summary>
    /// For information copied from another application, this field links that information to its original source file using DDE.
    /// </summary>
    public class DdeFieldInstruction : FieldInstruction
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
        /// Switch: \a
        /// Causes this field to be updated automatically.
        /// Word does not support this switch.
        /// </summary>
        public BoolFlagNode? AutoUpdate { get; set; }

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
        /// Switch: \u
        /// Requests the linked object as Unicode text.
        /// Word does not support this switch.
        /// </summary>
        public BoolFlagNode? Unicode { get; set; }

        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }

        public List<DdeArgument> Order { get; set; } = new List<DdeArgument>();

        public DdeFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? applicationName,
            ExpressionNode? fileName,
            ExpressionNode? bookmarkName,
            BoolFlagNode? autoUpdate,
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
            List<DdeArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            ApplicationName = applicationName;
            FileName = fileName;
            BookmarkName = bookmarkName;
            AutoUpdate = autoUpdate;
            Bitmap = bitmap;
            NoStore = noStore;
            Html = html;
            Picture = picture;
            Rtf = rtf;
            Text = text;
            Unicode = unicode;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            DateTimeFormat = dateTimeFormat;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        DdeArgument.ApplicationName => ApplicationName?.ToString() ?? string.Empty,
                        DdeArgument.FileName => FileName?.ToString() ?? string.Empty,
                        DdeArgument.BookmarkName => BookmarkName?.ToString() ?? string.Empty,
                        DdeArgument.AutoUpdate => AutoUpdate?.ToString() ?? string.Empty,
                        DdeArgument.Bitmap => Bitmap?.ToString() ?? string.Empty,
                        DdeArgument.NoStore => NoStore?.ToString() ?? string.Empty,
                        DdeArgument.Html => Html?.ToString() ?? string.Empty,
                        DdeArgument.Picture => Picture?.ToString() ?? string.Empty,
                        DdeArgument.Rtf => Rtf?.ToString() ?? string.Empty,
                        DdeArgument.Text => Text?.ToString() ?? string.Empty,
                        DdeArgument.Unicode => Unicode?.ToString() ?? string.Empty,
                        DdeArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        DdeArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        DdeArgument.DateTimeFormat => DateTimeFormat?.ToString() ?? string.Empty,
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
            foreach (DdeArgument arg in Order)
            {
                Node? child = arg switch
                {
                    DdeArgument.ApplicationName => ApplicationName,
                    DdeArgument.FileName => FileName,
                    DdeArgument.BookmarkName => BookmarkName,
                    DdeArgument.AutoUpdate => AutoUpdate,
                    DdeArgument.Bitmap => Bitmap,
                    DdeArgument.NoStore => NoStore,
                    DdeArgument.Html => Html,
                    DdeArgument.Picture => Picture,
                    DdeArgument.Rtf => Rtf,
                    DdeArgument.Text => Text,
                    DdeArgument.Unicode => Unicode,
                    DdeArgument.GeneralFormat => GeneralFormat,
                    DdeArgument.NumericFormat => NumericFormat,
                    DdeArgument.DateTimeFormat => DateTimeFormat,
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
                DdeArgument arg = Order[index];
                switch (arg)
                {
                    case DdeArgument.ApplicationName:
                        if (replacement is ExpressionNode appName)
                        {
                            current = ApplicationName;
                            ApplicationName = appName;
                        }
                        break;
                    case DdeArgument.FileName:
                        if (replacement is ExpressionNode fileName)
                        {
                            current = FileName;
                            FileName = fileName;
                        }
                        break;
                    case DdeArgument.BookmarkName:
                        if (replacement is ExpressionNode bookmarkName)
                        {
                            current = BookmarkName;
                            BookmarkName = bookmarkName;
                        }
                        break;
                    case DdeArgument.AutoUpdate:
                        if (replacement is BoolFlagNode autoUpdate)
                        {
                            current = AutoUpdate;
                            AutoUpdate = autoUpdate;
                        }
                        break;
                    case DdeArgument.Bitmap:
                        if (replacement is BoolFlagNode bitmap)
                        {
                            current = Bitmap;
                            Bitmap = bitmap;
                        }
                        break;
                    case DdeArgument.NoStore:
                        if (replacement is BoolFlagNode noStore)
                        {
                            current = NoStore;
                            NoStore = noStore;
                        }
                        break;
                    case DdeArgument.Html:
                        if (replacement is BoolFlagNode html)
                        {
                            current = Html;
                            Html = html;
                        }
                        break;
                    case DdeArgument.Picture:
                        if (replacement is BoolFlagNode picture)
                        {
                            current = Picture;
                            Picture = picture;
                        }
                        break;
                    case DdeArgument.Rtf:
                        if (replacement is BoolFlagNode rtf)
                        {
                            current = Rtf;
                            Rtf = rtf;
                        }
                        break;
                    case DdeArgument.Text:
                        if (replacement is BoolFlagNode text)
                        {
                            current = Text;
                            Text = text;
                        }
                        break;
                    case DdeArgument.Unicode:
                        if (replacement is BoolFlagNode unicode)
                        {
                            current = Unicode;
                            Unicode = unicode;
                        }
                        break;
                    case DdeArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> genFormat)
                        {
                            current = GeneralFormat;
                            GeneralFormat = genFormat;
                        }
                        break;
                    case DdeArgument.NumericFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> numFormat)
                        {
                            current = NumericFormat;
                            NumericFormat = numFormat;
                        }
                        break;
                    case DdeArgument.DateTimeFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> dtFormat)
                        {
                            current = DateTimeFormat;
                            DateTimeFormat = dtFormat;
                        }
                        break;
                }
            }
            return current;
        }
    }
}
