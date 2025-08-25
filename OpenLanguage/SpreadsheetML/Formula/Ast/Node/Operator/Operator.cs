using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class UnaryOperatorNode : ExpressionNode
    {
        public ExpressionNode Operand { get; set; }
        public ExpressionNode Operator { get; set; }

        protected UnaryOperatorNode(
            ExpressionNode @operator,
            ExpressionNode operand,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Operator = @operator;
            Operand = operand;
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Operand is O o)
            {
                yield return o;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (replacement is ExpressionNode expr && index == 0)
            {
                ExpressionNode current = Operand;
                Operand = expr;
                return current;
            }
            return null;
        }

        public override string ToRawString() => Operator.ToString() + Operand.ToString();
    }

    public abstract class BinaryOperatorNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Operator { get; set; }
        public ExpressionNode Right { get; set; }

        protected BinaryOperatorNode(
            ExpressionNode left,
            ExpressionNode @operator,
            ExpressionNode right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Left is O leftImp)
            {
                yield return leftImp;
            }
            if (Operator is O opImp)
            {
                yield return opImp;
            }
            if (Right is O rightImp)
            {
                yield return rightImp;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    ExpressionNode currentLeft = Left;
                    Left = expr;
                    return currentLeft;
                }
                else if (index == 1)
                {
                    ExpressionNode currentOperator = Operator;
                    Operator = expr;
                    return currentOperator;
                }
                else if (index == 2)
                {
                    ExpressionNode currentRight = Right;
                    Right = expr;
                    return currentRight;
                }
            }
            return null;
        }

        public override string ToRawString() =>
            Left.ToString() + Operator.ToString() + Right.ToString();
    }

    public class UnaryPlusNode : UnaryOperatorNode
    {
        public UnaryPlusNode(
            ExpressionNode @operator,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(operand, @operator, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;
    }

    public class DynamicNode : UnaryOperatorNode
    {
        public DynamicNode(
            ExpressionNode @operator,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(operand, @operator, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() => base.Operand.ToString() + base.Operator.ToString();
    }

    public class UnaryMinusNode : UnaryOperatorNode
    {
        public UnaryMinusNode(
            ExpressionNode @operator,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(operand, @operator, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;
    }

    public class PercentNode : UnaryOperatorNode
    {
        public PercentNode(
            ExpressionNode @operator,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(operand, @operator, lws, tws) { }

        public override int Precedence => Ast.Precedence.Percent;

        public override string ToRawString() => base.Operator.ToString() + base.Operand.ToString();
    }

    public class AddNode : BinaryOperatorNode
    {
        public AddNode(
            ExpressionNode l,
            ExpressionNode r,
            ExpressionNode @operator,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Additive;
    }

    public class SubtractNode : BinaryOperatorNode
    {
        public SubtractNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Additive;
    }

    public class MultiplyNode : BinaryOperatorNode
    {
        public MultiplyNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Multiplicative;
    }

    public class DivideNode : BinaryOperatorNode
    {
        public DivideNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Multiplicative;
    }

    public class PowerNode : BinaryOperatorNode
    {
        public PowerNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Power;
    }

    public class ConcatenateNode : BinaryOperatorNode
    {
        public ConcatenateNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Concat;
    }

    public class EqualNode : BinaryOperatorNode
    {
        public EqualNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class NotEqualNode : BinaryOperatorNode
    {
        public NotEqualNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class LessThanNode : BinaryOperatorNode
    {
        public LessThanNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class LessThanOrEqualNode : BinaryOperatorNode
    {
        public LessThanOrEqualNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class GreaterThanNode : BinaryOperatorNode
    {
        public GreaterThanNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class GreaterThanOrEqualNode : BinaryOperatorNode
    {
        public GreaterThanOrEqualNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class RangeNode : BinaryOperatorNode
    {
        public RangeNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Range;
    }

    public class IntersectionNode : BinaryOperatorNode
    {
        public List<Node> IntersectionWhitespace { get; set; }

        public IntersectionNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node> intersectionWhitespace
        )
            : base(l, @operator, r)
        {
            IntersectionWhitespace = intersectionWhitespace;
        }

        public override int Precedence => Ast.Precedence.Intersection;

        public override string ToRawString() =>
            Left.ToString()
            + string.Concat(IntersectionWhitespace.Select(w => w.ToString()))
            + Right.ToString();
    }

    public class ImplicitIntersectionNode : UnaryOperatorNode
    {
        public ImplicitIntersectionNode(
            ExpressionNode @operator,
            ExpressionNode operand,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(@operator, operand, leadingWhitespace, trailingWhitespace) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() => Operand.ToString() + Operator.ToString();
    }

    public class AtSuffixNode : UnaryOperatorNode
    {
        public AtSuffixNode(
            ExpressionNode @operator,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(@operator, operand, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() => Operand.ToString() + Operator.ToString();
    }

    public class UnionNode : BinaryOperatorNode
    {
        public UnionNode(
            ExpressionNode l,
            ExpressionNode @operator,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, @operator, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Union;
    }
}
