using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML.FieldInstruction.Generated;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum IncludeTextArgument
    {
        DocumentName,
        BookmarkName,
        PreventUpdateUnlessFieldsUpdated,
        DocumentFilterName,
        NamespaceMapping,
        XsltPath,
        XPathExpression,
    }

    /// <summary>
    /// Represents a strongly-typed INCLUDETEXT field instruction.
    /// Inserts all or part of the text and graphics contained in the document named by field-argument-1. If the document is a WordprocessingML document, the portion marked by the optional bookmark field-argument-2 is inserted. If no such bookmark is specified here, the whole document is inserted. If the document is an XML file, the fragment referred to by an XPath expression in the `\x` switch is inserted. If no such switch is specified, the whole XML file is inserted. If field-argument-1 contains white space, it shall be enclosed in double quotes. If field-argument-1 contains any backslash characters, each one shall be preceded directly by another backslash character.
    /// </summary>
    public class IncludeTextFieldInstruction : Ast.FieldInstruction
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

        /// <summary>
        /// Switch: \n field-argument
        /// The namespace mapping for XPath queries. Required if the \x switch refers to an element by name in an XML file that declares a namespace.
        /// Format: xmlns:prefix="URI"
        /// </summary>
        public FlaggedArgument<NamespaceDeclarationNode>? NamespaceMapping { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Specifies an XSLT for formatting XML data.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? XsltPath { get; set; }

        /// <summary>
        /// Switch: \x field-argument
        /// Specifies the XPath for returning a fragment of data in an XML file.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? XPathExpression { get; set; }

        public List<IncludeTextArgument> Order { get; set; } = new List<IncludeTextArgument>();

        public IncludeTextFieldInstruction(
            StringLiteralNode instruction,
            ExpressionNode? documentName,
            ExpressionNode? bookmarkName,
            BoolFlagNode? preventUpdateUnlessFieldsUpdated,
            FlaggedArgument<ExpressionNode>? documentFilterName,
            FlaggedArgument<NamespaceDeclarationNode>? namespaceMapping,
            FlaggedArgument<ExpressionNode>? xsltPath,
            FlaggedArgument<ExpressionNode>? xPathExpression,
            List<IncludeTextArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            DocumentName = documentName;
            BookmarkName = bookmarkName;
            PreventUpdateUnlessFieldsUpdated = preventUpdateUnlessFieldsUpdated;
            DocumentFilterName = documentFilterName;
            NamespaceMapping = namespaceMapping;
            XsltPath = xsltPath;
            XPathExpression = xPathExpression;
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
                    (IncludeTextArgument a) =>
                        a switch
                        {
                            IncludeTextArgument.DocumentName => DocumentName?.ToString()
                                ?? string.Empty,
                            IncludeTextArgument.BookmarkName => BookmarkName?.ToString()
                                ?? string.Empty,
                            IncludeTextArgument.PreventUpdateUnlessFieldsUpdated =>
                                PreventUpdateUnlessFieldsUpdated?.ToString() ?? string.Empty,
                            IncludeTextArgument.DocumentFilterName => DocumentFilterName?.ToString()
                                ?? string.Empty,
                            IncludeTextArgument.NamespaceMapping => NamespaceMapping?.ToString()
                                ?? string.Empty,
                            IncludeTextArgument.XsltPath => XsltPath?.ToString() ?? string.Empty,
                            IncludeTextArgument.XPathExpression => XPathExpression?.ToString()
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
            foreach (IncludeTextArgument arg in Order)
            {
                Node? node = arg switch
                {
                    IncludeTextArgument.DocumentName => DocumentName,
                    IncludeTextArgument.BookmarkName => BookmarkName,
                    IncludeTextArgument.PreventUpdateUnlessFieldsUpdated =>
                        PreventUpdateUnlessFieldsUpdated,
                    IncludeTextArgument.DocumentFilterName => DocumentFilterName,
                    IncludeTextArgument.NamespaceMapping => NamespaceMapping,
                    IncludeTextArgument.XsltPath => XsltPath,
                    IncludeTextArgument.XPathExpression => XPathExpression,
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
                    IncludeTextArgument arg = Order[index];
                    switch (arg)
                    {
                        case IncludeTextArgument.DocumentName:
                            if (replacement is ExpressionNode sln1)
                            {
                                current = DocumentName;
                                DocumentName = sln1;
                            }
                            break;
                        case IncludeTextArgument.BookmarkName:
                            if (replacement is ExpressionNode sln2)
                            {
                                current = BookmarkName;
                                BookmarkName = sln2;
                            }
                            break;
                        case IncludeTextArgument.PreventUpdateUnlessFieldsUpdated:
                            if (replacement is BoolFlagNode bfn)
                            {
                                current = PreventUpdateUnlessFieldsUpdated;
                                PreventUpdateUnlessFieldsUpdated = bfn;
                            }
                            break;
                        case IncludeTextArgument.DocumentFilterName:
                            if (replacement is FlaggedArgument<ExpressionNode> fa1)
                            {
                                current = DocumentFilterName;
                                DocumentFilterName = fa1;
                            }
                            break;
                        case IncludeTextArgument.NamespaceMapping:
                            if (replacement is FlaggedArgument<NamespaceDeclarationNode> fa2)
                            {
                                current = NamespaceMapping;
                                NamespaceMapping = fa2;
                            }
                            break;
                        case IncludeTextArgument.XsltPath:
                            if (replacement is FlaggedArgument<ExpressionNode> fa3)
                            {
                                current = XsltPath;
                                XsltPath = fa3;
                            }
                            break;
                        case IncludeTextArgument.XPathExpression:
                            if (replacement is FlaggedArgument<ExpressionNode> fa4)
                            {
                                current = XPathExpression;
                                XPathExpression = fa4;
                            }
                            break;
                    }
                }
            }
            return current;
        }
    }
}
