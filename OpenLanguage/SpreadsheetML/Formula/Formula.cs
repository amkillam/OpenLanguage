using OpenLanguage.SpreadsheetML.Formula.Ast;

namespace OpenLanguage.SpreadsheetML.Formula;

/// <summary>
/// Represents a parsed Excel formula, including its original text and the resulting AST.
/// </summary>
public class Formula
{
    /// <summary>
    /// The original formula string.
    /// </summary>
    public string FormulaText { get; }

    /// <summary>
    /// The root node of the Abstract Syntax Tree representing the parsed formula.
    /// This tree can be modified.
    /// </summary>
    public Node AstRoot { get; }

    internal Formula(string formulaText, Node astRoot)
    {
        FormulaText = formulaText;
        AstRoot = astRoot;
    }

    /// <summary>
    /// Reconstructs the formula string from the current state of the AST.
    /// If the AST has been modified, this will reflect the changes.
    /// </summary>
    /// <returns>A valid Excel formula string.</returns>
    public override string ToString()
    {
        return AstRoot.ToString();
    }
}
