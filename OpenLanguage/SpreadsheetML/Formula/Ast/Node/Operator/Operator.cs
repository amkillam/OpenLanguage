using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class UnaryOperatorNode : ExpressionNode
    {
        public ExpressionNode Operand { get; set; }
        public ExpressionNode Operator { get; set; }

        protected UnaryOperatorNode(
            ExpressionNode op,
            ExpressionNode operand,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Operator = op;
            Operand = operand;
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Operator is O operatorMatch)
            {
                yield return operatorMatch;
            }
            if (Operand is O operandMatch)
            {
                yield return operandMatch;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            ExpressionNode? current = null;
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    current = Operator;
                    Operator = expr;
                }
                else if (index == 1)
                {
                    current = Operand;
                    Operand = expr;
                }
            }
            return current;
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
            ExpressionNode op,
            ExpressionNode right,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Operator = op;
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
            Node? current = null;
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    current = Left;
                    Left = expr;
                }
                else if (index == 1)
                {
                    current = Operator;
                    Operator = expr;
                }
                else if (index == 2)
                {
                    current = Right;
                    Right = expr;
                }
            }
            return current;
        }

        public override string ToRawString() =>
            Left.ToString() + Operator.ToString() + Right.ToString();
    }

    public class UnaryPlusNode : UnaryOperatorNode
    {
        public UnaryPlusNode(
            ExpressionNode op,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, operand, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;
    }

    public class DynamicNode : UnaryOperatorNode
    {
        public DynamicNode(
            ExpressionNode op,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, operand, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() => base.Operand.ToString() + base.Operator.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Operand is O operandMatch)
            {
                yield return operandMatch;
            }
            if (Operator is O operatorMatch)
            {
                yield return operatorMatch;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            ExpressionNode? current = null;
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    current = Operand;
                    Operand = expr;
                }
                else if (index == 1)
                {
                    current = Operator;
                    Operator = expr;
                }
            }
            return current;
        }
    }

    public class UnaryMinusNode : UnaryOperatorNode
    {
        public UnaryMinusNode(
            ExpressionNode op,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, operand, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;
    }

    public class PercentNode : UnaryOperatorNode
    {
        public PercentNode(
            ExpressionNode op,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, operand, lws, tws) { }

        public override int Precedence => Ast.Precedence.Percent;

        // Percent is a suffix operator: render operand then operator
        public override string ToRawString() => base.Operand.ToString() + base.Operator.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Operand is O operandMatch)
            {
                yield return operandMatch;
            }
            if (Operator is O operatorMatch)
            {
                yield return operatorMatch;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            ExpressionNode? current = null;
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    current = Operand;
                    Operand = expr;
                }
                else if (index == 1)
                {
                    current = Operator;
                    Operator = expr;
                }
            }
            return current;
        }
    }

    public class AddNode : BinaryOperatorNode
    {
        public AddNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Additive;
    }

    public class SubtractNode : BinaryOperatorNode
    {
        public SubtractNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Additive;
    }

    public class MultiplyNode : BinaryOperatorNode
    {
        public MultiplyNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Multiplicative;
    }

    public class DivideNode : BinaryOperatorNode
    {
        public DivideNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Multiplicative;
    }

    public class PowerNode : BinaryOperatorNode
    {
        public PowerNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Power;
    }

    public class ConcatenateNode : BinaryOperatorNode
    {
        public ConcatenateNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Concat;
    }

    public class EqualNode : BinaryOperatorNode
    {
        public EqualNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class NotEqualNode : BinaryOperatorNode
    {
        public NotEqualNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class LessThanNode : BinaryOperatorNode
    {
        public LessThanNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class LessThanOrEqualNode : BinaryOperatorNode
    {
        public LessThanOrEqualNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class GreaterThanNode : BinaryOperatorNode
    {
        public GreaterThanNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class GreaterThanOrEqualNode : BinaryOperatorNode
    {
        public GreaterThanOrEqualNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;
    }

    public class RangeNode : BinaryOperatorNode
    {
        public RangeNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Range;
    }

    public class IntersectionNode : BinaryOperatorNode
    {
        public IntersectionNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Intersection;
    }

    public class ImplicitIntersectionNode : UnaryOperatorNode
    {
        public ImplicitIntersectionNode(
            ExpressionNode op,
            ExpressionNode operand,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(op, operand, leadingWhitespace, trailingWhitespace) { }

        public override int Precedence => Ast.Precedence.Unary;
    }

    public class AtSuffixNode : UnaryOperatorNode
    {
        public AtSuffixNode(
            ExpressionNode op,
            ExpressionNode operand,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, operand, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() => Operand.ToString() + Operator.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (Operand is O operandMatch)
            {
                yield return operandMatch;
            }
            if (Operator is O operatorMatch)
            {
                yield return operatorMatch;
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            ExpressionNode? current = null;
            if (replacement is ExpressionNode expr)
            {
                if (index == 0)
                {
                    current = Operand;
                    Operand = expr;
                }
                else if (index == 1)
                {
                    current = Operator;
                    Operator = expr;
                }
            }
            return current;
        }
    }

    public class UnionNode : BinaryOperatorNode
    {
        public UnionNode(
            ExpressionNode l,
            ExpressionNode op,
            ExpressionNode r,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, op, r, lws, tws) { }

        public override int Precedence => Ast.Precedence.Union;
    }
}
