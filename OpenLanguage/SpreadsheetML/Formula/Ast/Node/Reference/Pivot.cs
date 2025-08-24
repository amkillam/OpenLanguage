using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class PivotField : ExpressionNode
    {
        public ExpressionNode Name { get; set; }

        public PivotField(
            ExpressionNode name,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Name = name;
        }

        public override Int32 Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => Name.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Name is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(Int32 index, Node replacement)
        {
            if (index == 0 && replacement is ExpressionNode expr)
            {
                ExpressionNode current = Name;
                Name = expr;
                return current;
            }
            return null;
        }
    }

    public class IndexedPivotField : ExpressionNode
    {
        public ExpressionNode Name { get; set; }
        public ExpressionNode Item { get; set; }

        public IndexedPivotField(ExpressionNode name, ExpressionNode item)
        {
            Name = name;
            Item = item;
        }

        public override Int32 Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => $"{Name.ToRawString()}[{Item.ToRawString()}]";

        public override IEnumerable<O> Children<O>()
        {
            if (Name is O n)
            {
                yield return n;
            }
            if (Item is O i)
            {
                yield return i;
            }
        }

        public override Node? ReplaceChild(Int32 index, Node replacement)
        {
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    ExpressionNode current = Name;
                    Name = expr;
                    return current;
                }
                if (index == 1)
                {
                    ExpressionNode current = Item;
                    Item = expr;
                    return current;
                }
            }
            return null;
        }
    }

    public class PivotFieldOffset : ExpressionNode
    {
        public ExpressionNode Value { get; set; }

        public PivotFieldOffset(
            ExpressionNode value,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Value = value;
        }

        public override Int32 Precedence => Ast.Precedence.Primary;

        public override string ToRawString() => Value.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Value is O v)
            {
                yield return v;
            }

            yield break;
        }

        public override Node? ReplaceChild(Int32 index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is ExpressionNode exprRep)
            {
                current = Value;
                Value = exprRep;
            }
            return current;
        }
    }
}
