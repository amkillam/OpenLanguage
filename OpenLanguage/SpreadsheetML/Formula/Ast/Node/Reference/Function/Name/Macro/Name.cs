using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class AbsRefMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public AbsRefMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ABSREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ActiveCellMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ActiveCellMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACTIVECELL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddBarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public AddBarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ADDBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddCommandMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public AddCommandMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ADDCOMMAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddMenuMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public AddMenuMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ADDMENU"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddToolbarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public AddToolbarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ADDTOOLBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AppTitleMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public AppTitleMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("APPTITLE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ArgumentMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ArgumentMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ARGUMENT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BreakMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public BreakMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BREAK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CallMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public CallMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CALL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CallerMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public CallerMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CALLER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CancelKeyMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public CancelKeyMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CANCELKEY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CheckCommandMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public CheckCommandMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHECKCOMMAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CreateObjectMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public CreateObjectMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CREATEOBJECT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CustomRepeatMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public CustomRepeatMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUSTOMREPEAT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CustomUndoMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public CustomUndoMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUSTOMUNDO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeleteBarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public DeleteBarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DELETEBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeleteCommandMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public DeleteCommandMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DELETECOMMAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeleteMenuMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public DeleteMenuMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DELETEMENU"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeleteToolbarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public DeleteToolbarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DELETETOOLBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeRefMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public DeRefMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DEREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DialogBoxMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public DialogBoxMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DIALOGBOX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DirectoryMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public DirectoryMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DIRECTORY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DocumentsMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public DocumentsMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DOCUMENTS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EchoMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public EchoMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ECHO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ElseMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ElseMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ELSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ElseIfMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ElseIfMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ELSEIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EnableCommandMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public EnableCommandMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ENABLECOMMAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EnableToolMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public EnableToolMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ENABLETOOL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EndIfMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public EndIfMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ENDIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErrorMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ErrorMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERROR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EvaluateMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public EvaluateMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EVALUATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExecMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ExecMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExecuteMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ExecuteMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXECUTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FcloseMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FcloseMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FCLOSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FilesMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FilesMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILES"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FopenMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FopenMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FOPEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ForMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FOR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FormulaConvertMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FormulaConvertMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMULACONVERT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForCellMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ForCellMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORCELL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FposMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FposMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FPOS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FreadMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FreadMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FREAD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FreadlnMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FreadlnMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FREADLN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FsizeMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FsizeMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FSIZE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FwriteMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FwriteMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FWRITE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FwritelnMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public FwritelnMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FWRITELN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetBarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetBarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetCellMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetCellMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETCELL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetChartItemMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetChartItemMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETCHARTITEM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetDefMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetDefMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETDEF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetDocumentMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetDocumentMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETDOCUMENT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetFormulaMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetFormulaMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETFORMULA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetLinkInfoMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetLinkInfoMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETLINKINFO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetMovieMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetMovieMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETMOVIE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetNameMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetNameMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETNAME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetNoteMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetNoteMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETNOTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetObjectMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetObjectMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETOBJECT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetToolMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetToolMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETTOOL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetToolbarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetToolbarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETTOOLBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetWindowMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetWindowMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETWINDOW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetWorkbookMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetWorkbookMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETWORKBOOK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetWorkspaceMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GetWorkspaceMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETWORKSPACE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GotoMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GotoMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GOTO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GroupMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public GroupMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GROUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HaltMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public HaltMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HALT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HelpMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public HelpMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HELP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class InitiateMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public InitiateMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INITIATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class InputMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public InputMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INPUT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LastErrorMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public LastErrorMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LASTERROR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LinksMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public LinksMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LINKS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MovieCommandMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public MovieCommandMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MOVIECOMMAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NamesMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public NamesMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NAMES"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NextMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public NextMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NoteMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public NoteMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NOTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OpenDialogMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public OpenDialogMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OPENDIALOG"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OptionsListsGetMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public OptionsListsGetMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OPTIONSLISTSGET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PauseMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public PauseMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PAUSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PokeMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public PokeMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("POKE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PressToolMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public PressToolMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PRESSTOOL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RefTextMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public RefTextMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REFTEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RegisterMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public RegisterMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REGISTER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RegisterIdMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public RegisterIdMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REGISTERID"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RelRefMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public RelRefMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RELREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RenameCommandMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public RenameCommandMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RENAMECOMMAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RequestMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public RequestMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REQUEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ResetToolbarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ResetToolbarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RESETTOOLBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RestartMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public RestartMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RESTART"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ResultMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ResultMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RESULT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ResumeMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ResumeMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RESUME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReturnMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ReturnMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RETURN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveDialogMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public SaveDialogMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SAVEDIALOG"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveToolbarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public SaveToolbarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SAVETOOLBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ScenarioGetMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ScenarioGetMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SCENARIOGET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SelectionMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public SelectionMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SELECTION"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SetNameMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public SetNameMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SETNAME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SetValueMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public SetValueMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SETVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ShowBarMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ShowBarMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHOWBAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SpellingCheckMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public SpellingCheckMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SPELLINGCHECK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StepMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public StepMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STEP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TerminateMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public TerminateMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TERMINATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextRefMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public TextRefMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextBoxMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public TextBoxMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTBOX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UnregisterMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public UnregisterMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNREGISTER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ViewGetMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public ViewGetMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VIEWGET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VolatileMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public VolatileMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VOLATILE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WhileMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public WhileMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WHILE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WindowsMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public WindowsMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WINDOWS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WindowTitleMacroFunctionNode : BuiltInMacroFunctionNode
    {
        public WindowTitleMacroFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WINDOWTITLE"), leadingWhitespace, trailingWhitespace) { }
    }
}
