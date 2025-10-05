using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum UserAddressArgument
    {
        NewAddress,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed USERADDRESS field instruction.
    /// Retrieves the current user's postal address or, if field-argument is present, the address specified by text in field-argument. Specifying a field-argument shall not change the address of the current user.
    /// </summary>
    public class UserAddressFieldInstruction : FieldInstruction
    {
        public ExpressionNode? NewAddress { get; set; }

        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public List<UserAddressArgument> Order { get; set; } = new List<UserAddressArgument>();

        /// <summary>
        /// Initializes a new instance of the UserAddressFieldInstruction class.
        /// </summary>
        public UserAddressFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? newAddress,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<UserAddressArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            NewAddress = newAddress;
            GeneralFormat = generalFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(arg =>
                    arg switch
                    {
                        UserAddressArgument.GeneralFormat => GeneralFormat?.ToString()
                            ?? string.Empty,
                        UserAddressArgument.NewAddress => NewAddress?.ToString() ?? string.Empty,
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
            foreach (UserAddressArgument arg in Order)
            {
                Node? child = arg switch
                {
                    UserAddressArgument.GeneralFormat => GeneralFormat,
                    UserAddressArgument.NewAddress => NewAddress,
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
            if (index == 0 && replacement is StringLiteralNode instr)
            {
                current = NewAddress;
                NewAddress = instr;
            }
            else
            {
                index--;
                if (index > -1 && index < Order.Count)
                {
                    switch (Order[index])
                    {
                        case UserAddressArgument.NewAddress when replacement is ExpressionNode expr:
                            current = NewAddress;
                            NewAddress = expr;
                            break;
                        case UserAddressArgument.GeneralFormat
                            when replacement is FlaggedArgument<ExpressionNode> flagged:
                            current = GeneralFormat;
                            GeneralFormat = flagged;
                            break;
                    }
                }
            }
            return current;
        }
    }
}
