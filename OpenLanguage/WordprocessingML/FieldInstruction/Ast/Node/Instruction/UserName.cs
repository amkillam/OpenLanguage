using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum UserNameArgument
    {
        NewUserName,
        GeneralFormat,
    }

    /// <summary>
    /// Represents a strongly-typed USERNAME field instruction.
    /// Retrieves the current user's name or, if field-argument is present,
    /// the name specified by text in field-argument.
    ///
    /// Specifying a field-argument shall not change the name of the current user.
    /// </summary>
    public class UserNameFieldInstruction : FieldInstruction
    {
        public ExpressionNode? NewUserName { get; set; }
        public FlaggedArgument<ExpressionNode>? GeneralFormat { get; set; }
        public List<UserNameArgument> Order { get; set; } = new List<UserNameArgument>();

        /// <summary>
        /// Initializes a new instance of the UserNameFieldInstruction class.
        /// </summary>
        public UserNameFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? newUserName,
            FlaggedArgument<ExpressionNode>? generalFormat,
            List<UserNameArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            NewUserName = newUserName;
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
                        UserNameArgument.GeneralFormat => GeneralFormat?.ToString() ?? string.Empty,
                        UserNameArgument.NewUserName => NewUserName?.ToString() ?? string.Empty,
                        _ => string.Empty,
                    }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o)
            {
                yield return o;
            }
            foreach (UserNameArgument arg in Order)
            {
                Node? child = arg switch
                {
                    UserNameArgument.GeneralFormat => GeneralFormat,
                    UserNameArgument.NewUserName => NewUserName,
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
                    UserNameArgument arg = Order[index];
                    switch (arg)
                    {
                        case UserNameArgument.GeneralFormat:
                            if (replacement is FlaggedArgument<ExpressionNode> gen)
                            {
                                current = GeneralFormat;
                                GeneralFormat = gen;
                            }
                            break;
                        case UserNameArgument.NewUserName:
                            if (replacement is ExpressionNode expr)
                            {
                                current = NewUserName;
                                NewUserName = expr;
                            }
                            break;
                    }
                }
            }

            return current;
        }
    }
}
