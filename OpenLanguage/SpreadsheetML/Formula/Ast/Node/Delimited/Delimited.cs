using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class CharacterDelimitedExpressionNodes<L, D, R> : ExpressionNode
        where L : ExpressionNode
        where D : CharacterLiteralNode
        where R : ExpressionNode
    {
        public L Left { get; set; }
        public D Delimiter { get; set; }
        public R Right { get; set; }

        public CharacterDelimitedExpressionNodes(
            L left,
            D delimiter,
            R right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Delimiter = delimiter;
            Right = right;
        }

        public override string ToRawString() =>
            Left.ToString() + Delimiter.ToString() + Right.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Left is O l)
            {
                yield return l;
            }
            if (Delimiter is O d)
            {
                yield return d;
            }
            if (Right is O r)
            {
                yield return r;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is L leftRep)
            {
                current = Left as Node;
                Left = leftRep;
            }
            else if (index == 1 && replacement is D delRep)
            {
                current = Delimiter as Node;
                Delimiter = delRep;
            }
            else if (index == 2 && replacement is R rightRep)
            {
                current = Right as Node;
                Right = rightRep;
            }
            return current;
        }

        public override int Precedence => Ast.Precedence.Primary;
    }

    public class ColonDelimitedNodes<L, R> : CharacterDelimitedExpressionNodes<L, ColonNode, R>
        where L : ExpressionNode
        where R : ExpressionNode
    {
        public ColonDelimitedNodes(L left, ColonNode delimiter, R right)
            : base(left, delimiter, right) { }
    }

    public class CommaDelimitedNodes<L, R> : CharacterDelimitedExpressionNodes<L, CommaNode, R>
        where L : ExpressionNode
        where R : ExpressionNode
    {
        public CommaDelimitedNodes(L left, CommaNode delimiter, R right)
            : base(left, delimiter, right) { }
    }

    public class SemicolonDelimitedNodes<L, R>
        : CharacterDelimitedExpressionNodes<L, SemicolonNode, R>
        where L : ExpressionNode
        where R : ExpressionNode
    {
        public SemicolonDelimitedNodes(L left, SemicolonNode delimiter, R right)
            : base(left, delimiter, right) { }
    }
}
