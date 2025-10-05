using System;
using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum InfoArgument
    {
        InformationCategory,
        FieldArgument,
        GeneralFormat,
        NumericFormat,
        DateTimeFormat,
        UseHijriCalendar,
        UseSakaCalendar,
        IncludeFullPath,
        InKilobytes,
        InMegabytes,
    }

    /// <summary>
    /// Represents a strongly-typed INFO field instruction.
    /// A field of this kind is treated as if INFO was omitted and info-category was a field-type name.
    /// </summary>
    public class InfoFieldInstruction : Ast.FieldInstruction
    {
        public InfoTypeNode InformationCategory { get; set; }
        public ExpressionNode? FieldArgument { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? NumericFormat { get; set; }
        public FlaggedArgument<ExpressionNode>? DateTimeFormat { get; set; }
        public BoolFlagNode? UseHijriCalendar { get; set; }
        public BoolFlagNode? UseSakaCalendar { get; set; }
        public BoolFlagNode? IncludeFullPath { get; set; }
        public BoolFlagNode? InKilobytes { get; set; }
        public BoolFlagNode? InMegabytes { get; set; }
        public List<InfoArgument> Order { get; set; } = new List<InfoArgument>();

        public InfoFieldInstruction(
            StringLiteralNode instruction,
            InfoTypeNode informationCategory,
            ExpressionNode? fieldArgument,
            FlaggedArgument<ExpressionNode>? generalFormat,
            FlaggedArgument<ExpressionNode>? numericFormat,
            FlaggedArgument<ExpressionNode>? dateTimeFormat,
            BoolFlagNode? useHijriCalendar,
            BoolFlagNode? useSakaCalendar,
            BoolFlagNode? includeFullPath,
            BoolFlagNode? inKilobytes,
            BoolFlagNode? inMegabytes,
            List<InfoArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            InformationCategory = informationCategory;
            FieldArgument = fieldArgument;
            GeneralFormat = generalFormat;
            NumericFormat = numericFormat;
            DateTimeFormat = dateTimeFormat;
            UseHijriCalendar = useHijriCalendar;
            UseSakaCalendar = useSakaCalendar;
            IncludeFullPath = includeFullPath;
            InKilobytes = inKilobytes;
            InMegabytes = inMegabytes;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(a =>
                    a switch
                    {
                        InfoArgument.InformationCategory => InformationCategory.ToString(),
                        InfoArgument.FieldArgument => FieldArgument?.ToString() ?? string.Empty,
                        InfoArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        InfoArgument.NumericFormat => NumericFormat?.ToString() ?? string.Empty,
                        InfoArgument.DateTimeFormat => DateTimeFormat?.ToString() ?? string.Empty,
                        InfoArgument.UseHijriCalendar => UseHijriCalendar?.ToString()
                            ?? string.Empty,
                        InfoArgument.UseSakaCalendar => UseSakaCalendar?.ToString() ?? string.Empty,
                        InfoArgument.IncludeFullPath => IncludeFullPath?.ToString() ?? string.Empty,
                        InfoArgument.InKilobytes => InKilobytes?.ToString() ?? string.Empty,
                        InfoArgument.InMegabytes => InMegabytes?.ToString() ?? string.Empty,
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
            foreach (InfoArgument arg in Order)
            {
                Node? child = arg switch
                {
                    InfoArgument.InformationCategory => InformationCategory,
                    InfoArgument.FieldArgument => FieldArgument,
                    InfoArgument.GeneralFormat => GeneralFormat,
                    InfoArgument.NumericFormat => NumericFormat,
                    InfoArgument.DateTimeFormat => DateTimeFormat,
                    InfoArgument.UseHijriCalendar => UseHijriCalendar,
                    InfoArgument.UseSakaCalendar => UseSakaCalendar,
                    InfoArgument.IncludeFullPath => IncludeFullPath,
                    InfoArgument.InKilobytes => InKilobytes,
                    InfoArgument.InMegabytes => InMegabytes,
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
            if (index == 0 && replacement is StringLiteralNode instr)
            {
                current = Instruction;
                Instruction = instr;
                return current;
            }
            index--;
            if (index >= 0 && index < Order.Count)
            {
                InfoArgument arg = Order[index];
                switch (arg)
                {
                    case InfoArgument.InformationCategory:
                        if (replacement is InfoTypeNode itn)
                        {
                            current = InformationCategory;
                            InformationCategory = itn;
                        }
                        break;
                    case InfoArgument.FieldArgument:
                        if (replacement is ExpressionNode en)
                        {
                            current = FieldArgument;
                            FieldArgument = en;
                        }
                        break;
                    case InfoArgument.GeneralFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> faen)
                        {
                            current = GeneralFormat;
                            GeneralFormat = faen;
                        }
                        break;
                    case InfoArgument.NumericFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> faen2)
                        {
                            current = NumericFormat;
                            NumericFormat = faen2;
                        }
                        break;
                    case InfoArgument.DateTimeFormat:
                        if (replacement is FlaggedArgument<ExpressionNode> faen3)
                        {
                            current = DateTimeFormat;
                            DateTimeFormat = faen3;
                        }
                        break;
                    case InfoArgument.UseHijriCalendar:
                        if (replacement is BoolFlagNode bfn1)
                        {
                            current = UseHijriCalendar;
                            UseHijriCalendar = bfn1;
                        }
                        break;
                    case InfoArgument.UseSakaCalendar:
                        if (replacement is BoolFlagNode bfn2)
                        {
                            current = UseSakaCalendar;
                            UseSakaCalendar = bfn2;
                        }
                        break;
                    case InfoArgument.IncludeFullPath:
                        if (replacement is BoolFlagNode bfn3)
                        {
                            current = IncludeFullPath;
                            IncludeFullPath = bfn3;
                        }
                        break;
                    case InfoArgument.InKilobytes:
                        if (replacement is BoolFlagNode bfn4)
                        {
                            current = InKilobytes;
                            InKilobytes = bfn4;
                        }
                        break;
                    case InfoArgument.InMegabytes:
                        if (replacement is BoolFlagNode bfn5)
                        {
                            current = InMegabytes;
                            InMegabytes = bfn5;
                        }
                        break;
                }
            }
            return current;
        }
    }
}
