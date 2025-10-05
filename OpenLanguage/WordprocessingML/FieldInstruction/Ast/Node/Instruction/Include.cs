using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum IncludeArgument
    {
        DocumentName,
        BookmarkName,
        PreventUpdateUnlessFieldsUpdated,
        DocumentFilterName,
    }

    /// <summary>
    /// Inserts all or part of the text and graphics contained in the document named by field-argument-1. If the document is a WordprocessingML document, the portion marked by the optional bookmark field-argument-2 is inserted. If no such bookmark is specified here, the whole document is inserted. If the document is an XML file, the fragment referred to by an XPath expression in the `\x` switch is inserted. If no such switch is specified, the whole XML file is inserted. If field-argument-1 contains white space, it shall be enclosed in double quotes. If field-argument-1 contains any backslash characters, each one shall be preceded directly by another backslash character.
    /// </summary>
    public class IncludeFieldInstruction : Ast.FieldInstruction
    {
        /// <summary>
        /// The document name or path to include (field-argument-1, required).
        /// </summary>
        public ExpressionNode? DocumentName { get; set; }

        /// <summary>
        /// The optional bookmark name for WordprocessingML documents (field-argument-2, optional).
        /// </summary>
        public ExpressionNode? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \!
        /// Prevents this field from being updated unless all fields in the inserted text are first updated in their original document.
        /// </summary>
        public BoolFlagNode? PreventUpdateUnlessFieldsUpdated { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Specifies that the file shall be processed by a document filter whose name matches the field-argument value.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? DocumentFilterName { get; set; }

        public List<IncludeArgument> Order { get; set; } = new List<IncludeArgument>();

        public IncludeFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? documentName,
            ExpressionNode? bookmarkName,
            BoolFlagNode? preventUpdateUnlessFieldsUpdated,
            FlaggedArgument<ExpressionNode>? documentFilterName,
            List<IncludeArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            DocumentName = documentName;
            BookmarkName = bookmarkName;
            PreventUpdateUnlessFieldsUpdated = preventUpdateUnlessFieldsUpdated;
            DocumentFilterName = documentFilterName;
            Order = order;
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(
                    (IncludeArgument a) =>
                        a switch
                        {
                            IncludeArgument.DocumentName => DocumentName?.ToString()
                                ?? string.Empty,
                            IncludeArgument.BookmarkName => BookmarkName?.ToString()
                                ?? string.Empty,
                            IncludeArgument.PreventUpdateUnlessFieldsUpdated =>
                                PreventUpdateUnlessFieldsUpdated?.ToString() ?? string.Empty,
                            IncludeArgument.DocumentFilterName => DocumentFilterName?.ToString()
                                ?? string.Empty,
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
            foreach (IncludeArgument arg in Order)
            {
                Node? node = arg switch
                {
                    IncludeArgument.DocumentName => DocumentName,
                    IncludeArgument.BookmarkName => BookmarkName,
                    IncludeArgument.PreventUpdateUnlessFieldsUpdated =>
                        PreventUpdateUnlessFieldsUpdated,
                    IncludeArgument.DocumentFilterName => DocumentFilterName,
                    _ => null,
                };

                if (node is O o)
                {
                    yield return o;
                }
            }
            yield break;
        }

        public override Node? ReplaceChild(int index, Node replacement)
        {
            Node? current = null;
            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
            }
            else
            {
                index--;
                if (index < Order.Count)
                {
                    IncludeArgument arg = Order[index];
                    switch (arg)
                    {
                        case IncludeArgument.DocumentName:
                            if (replacement is ExpressionNode sln1)
                            {
                                current = DocumentName;
                                DocumentName = sln1;
                            }
                            break;
                        case IncludeArgument.BookmarkName:
                            if (replacement is ExpressionNode sln2)
                            {
                                current = BookmarkName;
                                BookmarkName = sln2;
                            }
                            break;
                        case IncludeArgument.PreventUpdateUnlessFieldsUpdated:
                            if (replacement is BoolFlagNode bfn)
                            {
                                current = PreventUpdateUnlessFieldsUpdated;
                                PreventUpdateUnlessFieldsUpdated = bfn;
                            }
                            break;
                        case IncludeArgument.DocumentFilterName:
                            if (replacement is FlaggedArgument<ExpressionNode> fa1)
                            {
                                current = DocumentFilterName;
                                DocumentFilterName = fa1;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}
