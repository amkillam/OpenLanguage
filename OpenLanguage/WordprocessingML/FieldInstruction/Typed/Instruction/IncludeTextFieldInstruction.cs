using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed INCLUDETEXT field instruction.
    /// Inserts all or part of the text and graphics contained in the document named by field-argument-1. If the document is a WordprocessingML document, the portion marked by the optional bookmark field-argument-2 is inserted. If no such bookmark is specified here, the whole document is inserted. If the document is an XML file, the fragment referred to by an XPath expression in the `\x` switch is inserted. If no such switch is specified, the whole XML file is inserted. If field-argument-1 contains white space, it shall be enclosed in double quotes. If field-argument-1 contains any backslash characters, each one shall be preceded directly by another backslash character.
    /// </summary>
    public class IncludeTextFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The document name or path to include (field-argument-1, required).
        /// </summary>
        public string DocumentName { get; set; } = string.Empty;

        /// <summary>
        /// The optional bookmark name for WordprocessingML documents (field-argument-2, optional).
        /// </summary>
        public string? BookmarkName { get; set; }

        /// <summary>
        /// Switch: \!
        /// Prevents this field from being updated unless all fields in the inserted text are first updated in their original document.
        /// </summary>
        public bool PreventUpdateUnlessFieldsUpdated { get; set; }

        /// <summary>
        /// Switch: \c field-argument
        /// Specifies that the file shall be processed by a document filter whose name matches the field-argument value.
        /// </summary>
        public string? DocumentFilterName { get; set; }

        /// <summary>
        /// Switch: \n field-argument
        /// The namespace mapping for XPath queries. Required if the \x switch refers to an element by name in an XML file that declares a namespace.
        /// Format: xmlns:prefix="URI"
        /// </summary>
        public NamespaceDeclaration? NamespaceMapping { get; set; }

        /// <summary>
        /// Switch: \t field-argument
        /// Specifies an XSLT for formatting XML data.
        /// </summary>
        public string? XsltPath { get; set; }

        /// <summary>
        /// Switch: \x field-argument
        /// Specifies the XPath for returning a fragment of data in an XML file.
        /// </summary>
        public System.Xml.XPath.XPathExpression? XPathExpression { get; set; }

        /// <summary>
        /// Initializes a new instance of the IncludeTextFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public IncludeTextFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "INCLUDETEXT")
            {
                throw new ArgumentException(
                    $"Expected INCLUDETEXT field, but got {Source.Instruction}"
                );
            }

            // INCLUDETEXT requires at least 1 field argument, optionally 2
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            // Parse field-argument-1: document name (required)
            DocumentName =
                nonSwitchArgs.Count > 0
                    ? nonSwitchArgs[0].Value?.ToString() ?? string.Empty
                    : string.Empty;

            // Parse optional field-argument-2: bookmark name
            BookmarkName = nonSwitchArgs.Count > 1 ? nonSwitchArgs[1].Value?.ToString() : null;

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "!":
                            PreventUpdateUnlessFieldsUpdated = true;
                            break;
                        case "c":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    DocumentFilterName = nextArg.Value?.ToString();
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                        case "n":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    string? namespaceString = nextArg.Value?.ToString();
                                    if (!string.IsNullOrEmpty(namespaceString))
                                    {
                                        try
                                        {
                                            NamespaceMapping = new NamespaceDeclaration(
                                                namespaceString
                                            );
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            throw new ArgumentException(
                                                $"Invalid namespace declaration in \\n switch: {namespaceString}",
                                                ex
                                            );
                                        }
                                    }
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                        case "t":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    XsltPath = nextArg.Value?.ToString();
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                        case "x":
                            if (i + 1 < Source.Arguments.Count)
                            {
                                FieldArgument nextArg = Source.Arguments[i + 1];
                                if (nextArg.Type != FieldArgumentType.Switch)
                                {
                                    string? xpathString = nextArg.Value?.ToString();
                                    if (!string.IsNullOrEmpty(xpathString))
                                    {
                                        try
                                        {
                                            XPathExpression =
                                                System.Xml.XPath.XPathExpression.Compile(
                                                    xpathString!
                                                );
                                        }
                                        catch (System.Xml.XPath.XPathException ex)
                                        {
                                            throw new ArgumentException(
                                                $"Invalid XPath expression in \\x switch: {xpathString}",
                                                ex
                                            );
                                        }
                                    }
                                    i++; // Skip consumed argument
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "INCLUDETEXT" };

            // Add field-argument-1: document name
            if (!string.IsNullOrEmpty(DocumentName))
            {
                result.Add(
                    DocumentName.Contains(" ") && !DocumentName.StartsWith("\"")
                        ? $"\"{DocumentName}\""
                        : DocumentName
                );
            }

            // Add optional field-argument-2: bookmark name
            if (!string.IsNullOrEmpty(BookmarkName))
            {
                result.Add(
                    BookmarkName.Contains(" ") && !BookmarkName.StartsWith("\"")
                        ? $"\"{BookmarkName}\""
                        : BookmarkName
                );
            }

            // Add switches
            if (PreventUpdateUnlessFieldsUpdated)
            {
                result.Add("\\!");
            }

            if (!string.IsNullOrEmpty(DocumentFilterName))
            {
                result.Add("\\c");
                result.Add(
                    DocumentFilterName.Contains(" ") && !DocumentFilterName.StartsWith("\"")
                        ? $"\"{DocumentFilterName}\""
                        : DocumentFilterName
                );
            }

            if (NamespaceMapping?.Declaration != null)
            {
                result.Add("\\n");
                string declaration = NamespaceMapping.Declaration;
                result.Add(
                    declaration.Contains(" ") && !declaration.StartsWith("\"")
                        ? $"\"{declaration}\""
                        : declaration
                );
            }

            if (!string.IsNullOrEmpty(XsltPath))
            {
                result.Add("\\t");
                result.Add(
                    XsltPath.Contains(" ") && !XsltPath.StartsWith("\"")
                        ? $"\"{XsltPath}\""
                        : XsltPath
                );
            }

            if (XPathExpression != null)
            {
                result.Add("\\x");
                string expression = XPathExpression!.ToString()!;
                result.Add(
                    expression.Contains(" ") && !expression.StartsWith("\"")
                        ? $"\"{expression}\""
                        : expression
                );
            }

            return string.Join(" ", result);
        }
    }
}
