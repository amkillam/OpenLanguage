using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public abstract class UnaryOperatorNode : ExpressionNode
    {
        public ExpressionNode Operand { get; set; }
        public List<Node> WsBetween { get; set; }

        protected UnaryOperatorNode(
            ExpressionNode operand,
            List<Node>? wsBetween = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Operand = operand;
            WsBetween = wsBetween ?? new List<Node>();
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
    }

    public abstract class BinaryOperatorNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }
        public List<Node> WsBeforeOp { get; set; }
        public List<Node> WsAfterOp { get; set; }

        protected BinaryOperatorNode(
            ExpressionNode left,
            ExpressionNode right,
            List<Node>? wsBeforeOp = null,
            List<Node>? wsAfterOp = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            Left = left;
            Right = right;
            WsBeforeOp = wsBeforeOp ?? new List<Node>();
            WsAfterOp = wsAfterOp ?? new List<Node>();
        }

        public override IEnumerable<O> Children<O>()
        {
            if (Left is O leftImp)
            {
                yield return leftImp;
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
                    ExpressionNode currentRight = Right;
                    Right = expr;
                    return currentRight;
                }
            }
            return null;
        }
    }

    public class UnaryPlusNode : UnaryOperatorNode
    {
        public UnaryPlusNode(
            ExpressionNode op,
            List<Node>? ws = null,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, ws, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() =>
            $"+{string.Concat(WsBetween.Select(w => w.ToString()))}{Operand.ToString()}";
    }

    public class DynamicNode : UnaryOperatorNode
    {
        public DynamicNode(
            ExpressionNode op,
            List<Node>? ws = null,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, ws, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() =>
            $"{Operand.ToString()}{string.Concat(WsBetween.Select(w => w.ToString()))}#";
    }

    public class UnaryMinusNode : UnaryOperatorNode
    {
        public UnaryMinusNode(
            ExpressionNode op,
            List<Node>? ws = null,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, ws, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() =>
            $"-{string.Concat(WsBetween.Select(w => w.ToString()))}{Operand.ToString()}";
    }

    public class PercentNode : UnaryOperatorNode
    {
        public PercentNode(
            ExpressionNode op,
            List<Node>? ws,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, ws, lws, tws) { }

        public override int Precedence => Ast.Precedence.Percent;

        public override string ToRawString() =>
            $"{Operand.ToString()}{string.Concat(WsBetween.Select(w => w.ToString()))}%";
    }

    public class AddNode : BinaryOperatorNode
    {
        public AddNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Additive;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}+{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class SubtractNode : BinaryOperatorNode
    {
        public SubtractNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Additive;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}-{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class MultiplyNode : BinaryOperatorNode
    {
        public MultiplyNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Multiplicative;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}*{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class DivideNode : BinaryOperatorNode
    {
        public DivideNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Multiplicative;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}/{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class PowerNode : BinaryOperatorNode
    {
        public PowerNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Power;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}^{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class ConcatenateNode : BinaryOperatorNode
    {
        public ConcatenateNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Concat;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}&{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class EqualNode : BinaryOperatorNode
    {
        public EqualNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}={string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class NotEqualNode : BinaryOperatorNode
    {
        public NotEqualNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}<>{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class LessThanNode : BinaryOperatorNode
    {
        public LessThanNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}<{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class LessThanOrEqualNode : BinaryOperatorNode
    {
        public LessThanOrEqualNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}<={string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class GreaterThanNode : BinaryOperatorNode
    {
        public GreaterThanNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;

        public override string ToRawString()
        {
            string leftStr = Left.ToString();
            leftStr += string.Concat(WsBeforeOp.Select(w => w.ToString()));
            leftStr += ">";
            leftStr += string.Concat(WsAfterOp.Select(w => w.ToString()));
            leftStr += Right.ToString();
            return leftStr;
        }
    }

    public class GreaterThanOrEqualNode : BinaryOperatorNode
    {
        public GreaterThanOrEqualNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Comparison;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}>={string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class RangeNode : BinaryOperatorNode
    {
        public RangeNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Range;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))}:{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }

    public class IntersectionNode : BinaryOperatorNode
    {
        public List<Node> IntersectionWhitespace { get; set; }

        public IntersectionNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node> intersectionWhitespace
        )
            : base(l, r)
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
            ExpressionNode operand,
            List<Node>? wsBetween = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(operand, wsBetween, leadingWhitespace, trailingWhitespace) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() =>
            $"@{string.Concat(WsBetween.Select(w => w.ToString()))}{Operand.ToString()}";
    }

    public class AtSuffixNode : UnaryOperatorNode
    {
        public AtSuffixNode(
            ExpressionNode op,
            List<Node>? ws = null,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(op, ws, lws, tws) { }

        public override int Precedence => Ast.Precedence.Unary;

        public override string ToRawString() =>
            $"{Operand.ToString()}{string.Concat(WsBetween.Select(w => w.ToString()))}@";
    }

    public class UnionNode : BinaryOperatorNode
    {
        public UnionNode(
            ExpressionNode l,
            ExpressionNode r,
            List<Node>? wsB,
            List<Node>? wsA,
            List<Node>? lws = null,
            List<Node>? tws = null
        )
            : base(l, r, wsB, wsA, lws, tws) { }

        public override int Precedence => Ast.Precedence.Union;

        public override string ToRawString() =>
            $"{Left.ToString()}{string.Concat(WsBeforeOp.Select(w => w.ToString()))},{string.Concat(WsAfterOp.Select(w => w.ToString()))}{Right.ToString()}";
    }
}
