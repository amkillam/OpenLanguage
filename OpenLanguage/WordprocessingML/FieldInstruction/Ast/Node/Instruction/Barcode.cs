using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum BarcodeArgument
    {
        Data,
        Facing,
        DataIsBookmarkName,
        UseUSPostalAddress,
    }

    public class BarcodeFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The BARCODE data argument. May be a literal or a nested field instruction.
        /// </summary>
        public ExpressionNode? Data { get; set; }

        /// <summary>
        /// Optional facing identification mark type (\f switch).
        /// </summary>
        public FlaggedArgument<ExpressionNode>? FacingIdentificationMark { get; set; }

        public BoolFlagNode? DataIsBookmarkName { get; set; }
        public BoolFlagNode? UseUSPostalAddress { get; set; }
        public List<BarcodeArgument> Order { get; set; } = new List<BarcodeArgument>();

        public BarcodeFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? data = null,
            FlaggedArgument<ExpressionNode>? facing = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Data = data;
            FacingIdentificationMark = facing;
        }

        public BarcodeFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? data,
            FlaggedArgument<ExpressionNode>? facing,
            BoolFlagNode? dataIsBookmarkName,
            BoolFlagNode? useUSPostalAddress,
            List<BarcodeArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            Data = data;
            FacingIdentificationMark = facing;
            DataIsBookmarkName = dataIsBookmarkName;
            UseUSPostalAddress = useUSPostalAddress;
            Order = order;
        }

        public override string ToRawString()
        {
            if (Order != null && Order.Count > 0)
            {
                return Instruction.ToString()
                    + string.Concat(
                        Order.Select(a =>
                            a switch
                            {
                                BarcodeArgument.Data => Data?.ToString() ?? string.Empty,
                                BarcodeArgument.Facing => FacingIdentificationMark?.ToString()
                                    ?? string.Empty,
                                BarcodeArgument.DataIsBookmarkName => DataIsBookmarkName?.ToString()
                                    ?? string.Empty,
                                BarcodeArgument.UseUSPostalAddress => UseUSPostalAddress?.ToString()
                                    ?? string.Empty,
                                _ => string.Empty,
                            }
                        )
                    );
            }

            StringBuilder result = new StringBuilder(Instruction.ToString());
            if (Data != null)
            {
                result.Append(Data.ToString());
            }
            if (FacingIdentificationMark != null)
            {
                result.Append(FacingIdentificationMark.ToString());
            }
            if (DataIsBookmarkName != null)
            {
                result.Append(DataIsBookmarkName.ToString());
            }
            if (UseUSPostalAddress != null)
            {
                result.Append(UseUSPostalAddress.ToString());
            }
            return result.ToString();
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Order != null && Order.Count > 0)
            {
                if (Instruction is O oInstr)
                {
                    yield return oInstr;
                }
                foreach (BarcodeArgument arg in Order)
                {
                    Node? child = arg switch
                    {
                        BarcodeArgument.Data => Data,
                        BarcodeArgument.Facing => FacingIdentificationMark,
                        BarcodeArgument.DataIsBookmarkName => DataIsBookmarkName,
                        BarcodeArgument.UseUSPostalAddress => UseUSPostalAddress,
                        _ => null,
                    };
                    if (child is O oChild)
                    {
                        yield return oChild;
                    }
                }
                yield break;
            }

            if (Instruction is O o1)
            {
                yield return o1;
            }
            if (Data is O o2)
            {
                yield return o2;
            }
            if (FacingIdentificationMark is O o3)
            {
                yield return o3;
            }
            if (DataIsBookmarkName is O o4)
            {
                yield return o4;
            }
            if (UseUSPostalAddress is O o5)
            {
                yield return o5;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;

            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
                return current;
            }

            if (Order != null && Order.Count > 0)
            {
                index--;
                if (index >= 0 && index < Order.Count)
                {
                    BarcodeArgument arg = Order[index];
                    switch (arg)
                    {
                        case BarcodeArgument.Data:
                            if (replacement is ExpressionNode en)
                            {
                                current = Data;
                                Data = en;
                            }
                            break;
                        case BarcodeArgument.Facing:
                            if (replacement is FlaggedArgument<ExpressionNode> fam)
                            {
                                current = FacingIdentificationMark;
                                FacingIdentificationMark = fam;
                            }
                            break;
                        case BarcodeArgument.DataIsBookmarkName:
                            if (replacement is BoolFlagNode b1)
                            {
                                current = DataIsBookmarkName;
                                DataIsBookmarkName = b1;
                            }
                            break;
                        case BarcodeArgument.UseUSPostalAddress:
                            if (replacement is BoolFlagNode b2)
                            {
                                current = UseUSPostalAddress;
                                UseUSPostalAddress = b2;
                            }
                            break;
                    }
                }
                return current;
            }

            // Fallback when Order is empty
            if (index == 1 && replacement is ExpressionNode expr)
            {
                current = Data;
                Data = expr;
            }
            else if (index == 2 && replacement is FlaggedArgument<ExpressionNode> fam2)
            {
                current = FacingIdentificationMark;
                FacingIdentificationMark = fam2;
            }
            else if (index == 3 && replacement is BoolFlagNode bkm)
            {
                current = DataIsBookmarkName;
                DataIsBookmarkName = bkm;
            }
            else if (index == 4 && replacement is BoolFlagNode us)
            {
                current = UseUSPostalAddress;
                UseUSPostalAddress = us;
            }

            return current;
        }
    }
}
