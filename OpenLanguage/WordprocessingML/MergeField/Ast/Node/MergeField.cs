using System.Collections.Generic;

namespace OpenLanguage.WordprocessingML.Ast
{
    /// <summary>
    /// Represents a merge field node in the AST.
    /// </summary>
    public class MergeFieldNode : ExpressionNode
    {
        public LeftGuillemetLiteralNode LeftGuillemet { get; set; }
        public ExpressionNode FieldName { get; set; }
        public BoolFlagNode? FormattingSwitch { get; set; }
        public RightGuillemetLiteralNode RightGuillemet { get; set; }

        // Constructor for merge field without formatting switch
        public MergeFieldNode(
            LeftGuillemetLiteralNode leftGuillemet,
            ExpressionNode fieldName,
            RightGuillemetLiteralNode rightGuillemet,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            LeftGuillemet = leftGuillemet;
            FieldName = fieldName;
            FormattingSwitch = null;
            RightGuillemet = rightGuillemet;
        }

        // Constructor for merge field with formatting switch
        public MergeFieldNode(
            LeftGuillemetLiteralNode leftGuillemet,
            ExpressionNode fieldName,
            BoolFlagNode? formattingSwitch,
            RightGuillemetLiteralNode rightGuillemet,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(leadingWhitespace, trailingWhitespace)
        {
            LeftGuillemet = leftGuillemet;
            FieldName = fieldName;
            FormattingSwitch = formattingSwitch;
            RightGuillemet = rightGuillemet;
        }

        public override string ToRawString() =>
            LeftGuillemet.ToString()
            + FieldName.ToString()
            + (FormattingSwitch?.ToString() ?? string.Empty)
            + RightGuillemet.ToString();

        public override IEnumerable<O> Children<O>()
        {
            if (LeftGuillemet is O leftGuillemet)
            {
                yield return leftGuillemet;
            }

            foreach (O child in LeftGuillemet.Children<O>())
            {
                yield return child;
            }

            if (FieldName is O fieldName)
            {
                yield return fieldName;
            }

            foreach (O child in FieldName.Children<O>())
            {
                yield return child;
            }

            if (FormattingSwitch is O formattingSwitch)
            {
                yield return formattingSwitch;
            }

            if (FormattingSwitch != null)
            {
                foreach (O child in FormattingSwitch.Children<O>())
                {
                    yield return child;
                }
            }

            if (RightGuillemet is O rightGuillemet)
            {
                yield return rightGuillemet;
            }

            foreach (O child in RightGuillemet.Children<O>())
            {
                yield return child;
            }
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            if (index == 0 && replacement is LeftGuillemetLiteralNode leftGuillemet)
            {
                LeftGuillemetLiteralNode current = LeftGuillemet;
                LeftGuillemet = leftGuillemet;
                return current;
            }
            else if (index == 1 && replacement is ExpressionNode fieldName)
            {
                ExpressionNode current = FieldName;
                FieldName = fieldName;
                return current;
            }
            else if (
                index == 2
                && FormattingSwitch != null
                && replacement is BoolFlagNode formattingSwitch
            )
            {
                BoolFlagNode? current = FormattingSwitch;
                FormattingSwitch = formattingSwitch;
                return current;
            }
            else if (
                (index == 2 && FormattingSwitch == null) || (index == 3 && FormattingSwitch != null)
            )
            {
                if (replacement is RightGuillemetLiteralNode rightGuillemet)
                {
                    RightGuillemetLiteralNode current = RightGuillemet;
                    RightGuillemet = rightGuillemet;
                    return current;
                }
            }

            return null;
        }
    }
}
