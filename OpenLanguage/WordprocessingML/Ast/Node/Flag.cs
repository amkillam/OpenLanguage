using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    public class FlagNode : StringLiteralNode
    {
        public FlagNode(
            string value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(value, leadingWhitespace, trailingWhitespace) { }
    }

    public class FlaggedArgument<E> : ExpressionNode
        where E : ExpressionNode
    {
        public FlagNode Flag { get; set; }
        public E Argument { get; set; }

        public FlaggedArgument(
            FlagNode flag,
            E argument,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Flag = flag;
            Argument = argument;
        }

        public override string ToRawString() => Flag.ToString() + Argument.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Flag is O o1)
            {
                yield return o1;
            }
            if (Argument is O o2)
            {
                yield return o2;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is FlagNode fn)
            {
                current = Flag;
                Flag = fn;
            }
            else if (index == 1 && replacement is E arg)
            {
                current = Argument;
                Argument = arg;
            }
            return current;
        }
    }

    public class BoolFlagNode : FlagNode
    {
        public BoolFlagNode(
            string flag,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(flag, leadingWhitespace, trailingWhitespace) { }

        public static implicit operator bool(BoolFlagNode? flag) => flag != null;
    }
}
