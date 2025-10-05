using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum CitationArgument
    {
        SourceTag,
        Locale,
        Prefix,
        Suffix,
        PageNumber,
        VolumeNumber,
        SuppressAuthor,
        SuppressTitle,
        SuppressYear,
        AdditionalSourceTag,
    }

    public class CitationFieldInstruction : FieldInstruction
    {
        public CitationFieldInstruction(
            StringLiteralNode instruction,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace) { }

        public ExpressionNode? SourceTag { get; set; }
        public FlaggedArgument<ExpressionNode>? Locale { get; set; }
        public FlaggedArgument<ExpressionNode>? Prefix { get; set; }
        public FlaggedArgument<ExpressionNode>? Suffix { get; set; }
        public FlaggedArgument<ExpressionNode>? PageNumber { get; set; }
        public FlaggedArgument<ExpressionNode>? VolumeNumber { get; set; }
        public BoolFlagNode? SuppressAuthor { get; set; }
        public BoolFlagNode? SuppressTitle { get; set; }
        public BoolFlagNode? SuppressYear { get; set; }
        public FlaggedArgument<ExpressionNode>? AdditionalSourceTag { get; set; }

        public List<CitationArgument> Order { get; set; } = new List<CitationArgument>();

        public CitationFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? sourceTag,
            FlaggedArgument<ExpressionNode>? locale,
            FlaggedArgument<ExpressionNode>? prefix,
            FlaggedArgument<ExpressionNode>? suffix,
            FlaggedArgument<ExpressionNode>? pageNumber,
            FlaggedArgument<ExpressionNode>? volumeNumber,
            BoolFlagNode? suppressAuthor,
            BoolFlagNode? suppressTitle,
            BoolFlagNode? suppressYear,
            FlaggedArgument<ExpressionNode>? additionalSourceTag,
            List<CitationArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            SourceTag = sourceTag;
            Locale = locale;
            Prefix = prefix;
            Suffix = suffix;
            PageNumber = pageNumber;
            VolumeNumber = volumeNumber;
            SuppressAuthor = suppressAuthor;
            SuppressTitle = suppressTitle;
            SuppressYear = suppressYear;
            AdditionalSourceTag = additionalSourceTag;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        CitationArgument.SourceTag => SourceTag?.ToString() ?? string.Empty,
                        CitationArgument.Locale => Locale?.ToString() ?? string.Empty,
                        CitationArgument.Prefix => Prefix?.ToString() ?? string.Empty,
                        CitationArgument.Suffix => Suffix?.ToString() ?? string.Empty,
                        CitationArgument.PageNumber => PageNumber?.ToString() ?? string.Empty,
                        CitationArgument.VolumeNumber => VolumeNumber?.ToString() ?? string.Empty,
                        CitationArgument.SuppressAuthor => SuppressAuthor?.ToString()
                            ?? string.Empty,
                        CitationArgument.SuppressTitle => SuppressTitle?.ToString() ?? string.Empty,
                        CitationArgument.SuppressYear => SuppressYear?.ToString() ?? string.Empty,
                        CitationArgument.AdditionalSourceTag => AdditionalSourceTag?.ToString()
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

            foreach (CitationArgument arg in Order)
            {
                Node? child = arg switch
                {
                    CitationArgument.SourceTag => SourceTag,
                    CitationArgument.Locale => Locale,
                    CitationArgument.Prefix => Prefix,
                    CitationArgument.Suffix => Suffix,
                    CitationArgument.PageNumber => PageNumber,
                    CitationArgument.VolumeNumber => VolumeNumber,
                    CitationArgument.SuppressAuthor => SuppressAuthor,
                    CitationArgument.SuppressTitle => SuppressTitle,
                    CitationArgument.SuppressYear => SuppressYear,
                    CitationArgument.AdditionalSourceTag => AdditionalSourceTag,
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
                CitationArgument arg = Order[index];
                switch (arg)
                {
                    case CitationArgument.SourceTag:
                        if (replacement is ExpressionNode st)
                        {
                            current = SourceTag;
                            SourceTag = st;
                        }
                        break;

                    case CitationArgument.Locale:
                        if (replacement is FlaggedArgument<ExpressionNode> loc)
                        {
                            current = Locale;
                            Locale = loc;
                        }
                        break;

                    case CitationArgument.Prefix:
                        if (replacement is FlaggedArgument<ExpressionNode> pre)
                        {
                            current = Prefix;
                            Prefix = pre;
                        }
                        break;

                    case CitationArgument.Suffix:
                        if (replacement is FlaggedArgument<ExpressionNode> suf)
                        {
                            current = Suffix;
                            Suffix = suf;
                        }
                        break;

                    case CitationArgument.PageNumber:
                        if (replacement is FlaggedArgument<ExpressionNode> pn)
                        {
                            current = PageNumber;
                            PageNumber = pn;
                        }
                        break;

                    case CitationArgument.VolumeNumber:
                        if (replacement is FlaggedArgument<ExpressionNode> vn)
                        {
                            current = VolumeNumber;
                            VolumeNumber = vn;
                        }
                        break;

                    case CitationArgument.SuppressAuthor:
                        if (replacement is BoolFlagNode sa)
                        {
                            current = SuppressAuthor;
                            SuppressAuthor = sa;
                        }
                        break;

                    case CitationArgument.SuppressTitle:
                        if (replacement is BoolFlagNode stl)
                        {
                            current = SuppressTitle;
                            SuppressTitle = stl;
                        }
                        break;

                    case CitationArgument.SuppressYear:
                        if (replacement is BoolFlagNode sy)
                        {
                            current = SuppressYear;
                            SuppressYear = sy;
                        }
                        break;

                    case CitationArgument.AdditionalSourceTag:
                        if (replacement is FlaggedArgument<ExpressionNode> ast)
                        {
                            current = AdditionalSourceTag;
                            AdditionalSourceTag = ast;
                        }
                        break;
                }
            }

            return current;
        }
    }
}
