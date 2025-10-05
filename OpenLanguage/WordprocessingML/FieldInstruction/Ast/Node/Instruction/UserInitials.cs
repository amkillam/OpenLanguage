using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum UserInitialsArgument
    {
        GeneralFormat,
        NewInitials,
    }

    /// <summary>
    /// Represents a strongly-typed USERINITIALS field instruction.
    /// Retrieves the current user's initials or, if field-argument is present, the initials specified by text in field-argument. Specifying a field-argument shall not change the initials of the current user.
    /// </summary>
    public class UserInitialsFieldInstruction : FieldInstruction
    {
        public ExpressionNode? NewInitials { get; set; }

        /// <summary>
        /// General formatting switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }

        public List<UserInitialsArgument> Order { get; set; }

        /// <summary>
        /// Initializes a new instance of the UserInitialsFieldInstruction class.
        /// </summary>
        public UserInitialsFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? newInitials,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<UserInitialsArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            NewInitials = newInitials;
            GeneralFormat = generalFormat;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString()
        {
            return Instruction.ToString()
                + string.Concat(
                    Order.Select(arg =>
                        arg switch
                        {
                            UserInitialsArgument.GeneralFormat => GeneralFormat?.ToString()
                                ?? string.Empty,
                            UserInitialsArgument.NewInitials => NewInitials?.ToString()
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
            foreach (UserInitialsArgument arg in Order)
            {
                Node? child = arg switch
                {
                    UserInitialsArgument.GeneralFormat => GeneralFormat,
                    UserInitialsArgument.NewInitials => NewInitials,
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
                current = Instruction;
                Instruction = instr;
            }
            else
            {
                index--;
                if (index > -1 && index < Order.Count)
                {
                    UserInitialsArgument arg = Order[index];
                    switch (arg)
                    {
                        case UserInitialsArgument.GeneralFormat
                            when replacement is FlaggedArgument<ExpressionNode> flaggedArg:
                            current = GeneralFormat;
                            GeneralFormat = flaggedArg;
                            break;
                        case UserInitialsArgument.NewInitials
                            when replacement is ExpressionNode expr:
                            current = NewInitials;
                            NewInitials = expr;
                            break;
                    }
                }
            }

            return current;
        }
    }
}
