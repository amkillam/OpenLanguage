using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class AbsRefMacroFunctionNode : MacroFunctionNode
    {
        public AbsRefMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ABSREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ActiveCellMacroFunctionNode : MacroFunctionNode
    {
        public ActiveCellMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ACTIVECELL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddBarMacroFunctionNode : MacroFunctionNode
    {
        public AddBarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ADDBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddCommandMacroFunctionNode : MacroFunctionNode
    {
        public AddCommandMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ADDCOMMAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddMenuMacroFunctionNode : MacroFunctionNode
    {
        public AddMenuMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ADDMENU"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddToolbarMacroFunctionNode : MacroFunctionNode
    {
        public AddToolbarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ADDTOOLBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AppTitleMacroFunctionNode : MacroFunctionNode
    {
        public AppTitleMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "APPTITLE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ArgumentMacroFunctionNode : MacroFunctionNode
    {
        public ArgumentMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ARGUMENT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BreakMacroFunctionNode : MacroFunctionNode
    {
        public BreakMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BREAK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CallMacroFunctionNode : MacroFunctionNode
    {
        public CallMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CALL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CallerMacroFunctionNode : MacroFunctionNode
    {
        public CallerMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CALLER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CancelKeyMacroFunctionNode : MacroFunctionNode
    {
        public CancelKeyMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CANCELKEY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CheckCommandMacroFunctionNode : MacroFunctionNode
    {
        public CheckCommandMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CHECKCOMMAND"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CreateObjectMacroFunctionNode : MacroFunctionNode
    {
        public CreateObjectMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CREATEOBJECT"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CustomRepeatMacroFunctionNode : MacroFunctionNode
    {
        public CustomRepeatMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUSTOMREPEAT"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CustomUndoMacroFunctionNode : MacroFunctionNode
    {
        public CustomUndoMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUSTOMUNDO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeleteBarMacroFunctionNode : MacroFunctionNode
    {
        public DeleteBarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DELETEBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeleteCommandMacroFunctionNode : MacroFunctionNode
    {
        public DeleteCommandMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DELETECOMMAND"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DeleteMenuMacroFunctionNode : MacroFunctionNode
    {
        public DeleteMenuMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DELETEMENU"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeleteToolbarMacroFunctionNode : MacroFunctionNode
    {
        public DeleteToolbarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DELETETOOLBAR"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DeRefMacroFunctionNode : MacroFunctionNode
    {
        public DeRefMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DEREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DialogBoxMacroFunctionNode : MacroFunctionNode
    {
        public DialogBoxMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DIALOGBOX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DirectoryMacroFunctionNode : MacroFunctionNode
    {
        public DirectoryMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DIRECTORY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DocumentsMacroFunctionNode : MacroFunctionNode
    {
        public DocumentsMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DOCUMENTS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EchoMacroFunctionNode : MacroFunctionNode
    {
        public EchoMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ECHO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ElseMacroFunctionNode : MacroFunctionNode
    {
        public ElseMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ELSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ElseIfMacroFunctionNode : MacroFunctionNode
    {
        public ElseIfMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ELSEIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EnableCommandMacroFunctionNode : MacroFunctionNode
    {
        public EnableCommandMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ENABLECOMMAND"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EnableToolMacroFunctionNode : MacroFunctionNode
    {
        public EnableToolMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ENABLETOOL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EndIfMacroFunctionNode : MacroFunctionNode
    {
        public EndIfMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ENDIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErrorMacroFunctionNode : MacroFunctionNode
    {
        public ErrorMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ERROR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EvaluateMacroFunctionNode : MacroFunctionNode
    {
        public EvaluateMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EVALUATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExecMacroFunctionNode : MacroFunctionNode
    {
        public ExecMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EXEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExecuteMacroFunctionNode : MacroFunctionNode
    {
        public ExecuteMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EXECUTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FcloseMacroFunctionNode : MacroFunctionNode
    {
        public FcloseMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FCLOSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FilesMacroFunctionNode : MacroFunctionNode
    {
        public FilesMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILES"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FopenMacroFunctionNode : MacroFunctionNode
    {
        public FopenMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FOPEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForMacroFunctionNode : MacroFunctionNode
    {
        public ForMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FOR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FormulaConvertMacroFunctionNode : MacroFunctionNode
    {
        public FormulaConvertMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORMULACONVERT"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ForCellMacroFunctionNode : MacroFunctionNode
    {
        public ForCellMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORCELL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FposMacroFunctionNode : MacroFunctionNode
    {
        public FposMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FPOS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FreadMacroFunctionNode : MacroFunctionNode
    {
        public FreadMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FREAD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FreadlnMacroFunctionNode : MacroFunctionNode
    {
        public FreadlnMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FREADLN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FsizeMacroFunctionNode : MacroFunctionNode
    {
        public FsizeMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FSIZE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FwriteMacroFunctionNode : MacroFunctionNode
    {
        public FwriteMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FWRITE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FwritelnMacroFunctionNode : MacroFunctionNode
    {
        public FwritelnMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FWRITELN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetBarMacroFunctionNode : MacroFunctionNode
    {
        public GetBarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetCellMacroFunctionNode : MacroFunctionNode
    {
        public GetCellMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETCELL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetChartItemMacroFunctionNode : MacroFunctionNode
    {
        public GetChartItemMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETCHARTITEM"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GetDefMacroFunctionNode : MacroFunctionNode
    {
        public GetDefMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETDEF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetDocumentMacroFunctionNode : MacroFunctionNode
    {
        public GetDocumentMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETDOCUMENT"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GetFormulaMacroFunctionNode : MacroFunctionNode
    {
        public GetFormulaMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETFORMULA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetLinkInfoMacroFunctionNode : MacroFunctionNode
    {
        public GetLinkInfoMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETLINKINFO"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GetMovieMacroFunctionNode : MacroFunctionNode
    {
        public GetMovieMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETMOVIE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetNameMacroFunctionNode : MacroFunctionNode
    {
        public GetNameMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETNAME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetNoteMacroFunctionNode : MacroFunctionNode
    {
        public GetNoteMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETNOTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetObjectMacroFunctionNode : MacroFunctionNode
    {
        public GetObjectMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETOBJECT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetToolMacroFunctionNode : MacroFunctionNode
    {
        public GetToolMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETTOOL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetToolbarMacroFunctionNode : MacroFunctionNode
    {
        public GetToolbarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETTOOLBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetWindowMacroFunctionNode : MacroFunctionNode
    {
        public GetWindowMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETWINDOW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetWorkbookMacroFunctionNode : MacroFunctionNode
    {
        public GetWorkbookMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETWORKBOOK"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GetWorkspaceMacroFunctionNode : MacroFunctionNode
    {
        public GetWorkspaceMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETWORKSPACE"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GotoMacroFunctionNode : MacroFunctionNode
    {
        public GotoMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GOTO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GroupMacroFunctionNode : MacroFunctionNode
    {
        public GroupMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GROUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HaltMacroFunctionNode : MacroFunctionNode
    {
        public HaltMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HALT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HelpMacroFunctionNode : MacroFunctionNode
    {
        public HelpMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HELP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class InitiateMacroFunctionNode : MacroFunctionNode
    {
        public InitiateMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INITIATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class InputMacroFunctionNode : MacroFunctionNode
    {
        public InputMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INPUT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LastErrorMacroFunctionNode : MacroFunctionNode
    {
        public LastErrorMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LASTERROR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LinksMacroFunctionNode : MacroFunctionNode
    {
        public LinksMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LINKS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MovieCommandMacroFunctionNode : MacroFunctionNode
    {
        public MovieCommandMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MOVIECOMMAND"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NamesMacroFunctionNode : MacroFunctionNode
    {
        public NamesMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NAMES"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NextMacroFunctionNode : MacroFunctionNode
    {
        public NextMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NoteMacroFunctionNode : MacroFunctionNode
    {
        public NoteMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NOTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OpenDialogMacroFunctionNode : MacroFunctionNode
    {
        public OpenDialogMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OPENDIALOG"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OptionsListsGetMacroFunctionNode : MacroFunctionNode
    {
        public OptionsListsGetMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONSLISTSGET"),
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PauseMacroFunctionNode : MacroFunctionNode
    {
        public PauseMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PAUSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PokeMacroFunctionNode : MacroFunctionNode
    {
        public PokeMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "POKE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PressToolMacroFunctionNode : MacroFunctionNode
    {
        public PressToolMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PRESSTOOL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RefTextMacroFunctionNode : MacroFunctionNode
    {
        public RefTextMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "REFTEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RegisterMacroFunctionNode : MacroFunctionNode
    {
        public RegisterMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "REGISTER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RegisterIdMacroFunctionNode : MacroFunctionNode
    {
        public RegisterIdMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "REGISTERID"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RelRefMacroFunctionNode : MacroFunctionNode
    {
        public RelRefMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RELREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RenameCommandMacroFunctionNode : MacroFunctionNode
    {
        public RenameCommandMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RENAMECOMMAND"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RequestMacroFunctionNode : MacroFunctionNode
    {
        public RequestMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "REQUEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ResetToolbarMacroFunctionNode : MacroFunctionNode
    {
        public ResetToolbarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RESETTOOLBAR"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RestartMacroFunctionNode : MacroFunctionNode
    {
        public RestartMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RESTART"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ResultMacroFunctionNode : MacroFunctionNode
    {
        public ResultMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RESULT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ResumeMacroFunctionNode : MacroFunctionNode
    {
        public ResumeMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RESUME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReturnMacroFunctionNode : MacroFunctionNode
    {
        public ReturnMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RETURN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveDialogMacroFunctionNode : MacroFunctionNode
    {
        public SaveDialogMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SAVEDIALOG"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveToolbarMacroFunctionNode : MacroFunctionNode
    {
        public SaveToolbarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SAVETOOLBAR"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ScenarioGetMacroFunctionNode : MacroFunctionNode
    {
        public ScenarioGetMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SCENARIOGET"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SelectionMacroFunctionNode : MacroFunctionNode
    {
        public SelectionMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SELECTION"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SetNameMacroFunctionNode : MacroFunctionNode
    {
        public SetNameMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SETNAME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SetValueMacroFunctionNode : MacroFunctionNode
    {
        public SetValueMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SETVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ShowBarMacroFunctionNode : MacroFunctionNode
    {
        public ShowBarMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHOWBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SpellingCheckMacroFunctionNode : MacroFunctionNode
    {
        public SpellingCheckMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SPELLINGCHECK"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class StepMacroFunctionNode : MacroFunctionNode
    {
        public StepMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "STEP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TerminateMacroFunctionNode : MacroFunctionNode
    {
        public TerminateMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TERMINATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextRefMacroFunctionNode : MacroFunctionNode
    {
        public TextRefMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TEXTREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextBoxMacroFunctionNode : MacroFunctionNode
    {
        public TextBoxMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TEXTBOX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UnregisterMacroFunctionNode : MacroFunctionNode
    {
        public UnregisterMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "UNREGISTER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ViewGetMacroFunctionNode : MacroFunctionNode
    {
        public ViewGetMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VIEWGET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VolatileMacroFunctionNode : MacroFunctionNode
    {
        public VolatileMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VOLATILE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WhileMacroFunctionNode : MacroFunctionNode
    {
        public WhileMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WHILE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WindowsMacroFunctionNode : MacroFunctionNode
    {
        public WindowsMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WINDOWS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WindowTitleMacroFunctionNode : MacroFunctionNode
    {
        public WindowTitleMacroFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WINDOWTITLE"), leadingWhitespace, trailingWhitespace)
        { }
    }
}
