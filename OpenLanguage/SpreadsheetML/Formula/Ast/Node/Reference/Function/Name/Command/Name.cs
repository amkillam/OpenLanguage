using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class A1R1C1CommandFunctionNode : BuiltInCommandFunctionNode
    {
        public A1R1C1CommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("A1.R1C1"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ActivateCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ActivateCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACTIVATE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ActivateNextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ActivateNextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ACTIVATE.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ActivateNotesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ActivateNotesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ACTIVATE.NOTES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ActivatePrevCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ActivatePrevCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ACTIVATE.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ActiveCellFontCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ActiveCellFontCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ACTIVE.CELL.FONT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddinManagerCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AddinManagerCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ADDIN.MANAGER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddArrowCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AddArrowCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ADD.ARROW"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AddChartAutoFormatCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AddChartAutoFormatCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ADD.CHART.AUTOFORMAT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddListItemCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AddListItemCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ADD.LIST.ITEM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddOverlayCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AddOverlayCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ADD.OVERLAY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AddPrintAreaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AddPrintAreaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ADD.PRINT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddToolCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AddToolCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ADD.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AlertCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AlertCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ALERT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class AlignmentCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AlignmentCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ALIGNMENT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ApplyNamesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ApplyNamesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("APPLY.NAMES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ApplyStyleCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ApplyStyleCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("APPLY.STYLE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AppActivateCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AppActivateCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("APP.ACTIVATE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AppActivateMicrosoftCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AppActivateMicrosoftCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("APP.ACTIVATE.MICROSOFT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AppMaximizeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AppMaximizeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("APP.MAXIMIZE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AppMinimizeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AppMinimizeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("APP.MINIMIZE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AppMoveCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AppMoveCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("APP.MOVE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AppRestoreCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AppRestoreCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("APP.RESTORE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AppSizeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AppSizeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("APP.SIZE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ArrangeAllCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ArrangeAllCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ARRANGE.ALL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AssignToObjectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AssignToObjectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ASSIGN.TO.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AssignToToolCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AssignToToolCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ASSIGN.TO.TOOL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AttachTextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AttachTextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ATTACH.TEXT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AttachToolbarsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AttachToolbarsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ATTACH.TOOLBARS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AttributesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AttributesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ATTRIBUTES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AutocorrectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AutocorrectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AUTOCORRECT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AutoOutlineCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AutoOutlineCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("AUTO.OUTLINE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AxesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public AxesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AXES"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class BeepCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public BeepCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BEEP"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class BorderCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public BorderCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BORDER"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class BringToFrontCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public BringToFrontCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("BRING.TO.FRONT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CalculateDocumentCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CalculateDocumentCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CALCULATE.DOCUMENT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CalculateNowCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CalculateNowCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CALCULATE.NOW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CalculationCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CalculationCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CALCULATION"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CancelCopyCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CancelCopyCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CANCEL.COPY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CellProtectionCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CellProtectionCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CELL.PROTECTION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ChangeLinkCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ChangeLinkCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHANGE.LINK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ChartAddDataCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ChartAddDataCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CHART.ADD.DATA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ChartTrendCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ChartTrendCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHART.TREND"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ChartWizardCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ChartWizardCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CHART.WIZARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CheckboxPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CheckboxPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CHECKBOX.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ClearCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ClearCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CLEAR"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ClearOutlineCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ClearOutlineCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CLEAR.OUTLINE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ClearPrintAreaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ClearPrintAreaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CLEAR.PRINT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ClearRoutingSlipCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ClearRoutingSlipCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CLEAR.ROUTING.SLIP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CloseCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CloseCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CLOSE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class CloseAllCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CloseAllCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CLOSE.ALL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ColorPaletteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ColorPaletteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("COLOR.PALETTE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ColumnWidthCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ColumnWidthCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("COLUMN.WIDTH"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CombinationCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CombinationCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COMBINATION"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ConsolidateCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ConsolidateCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONSOLIDATE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ConstrainNumericCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ConstrainNumericCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CONSTRAIN.NUMERIC"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CopyCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CopyCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COPY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class CopyChartCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CopyChartCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COPY.CHART"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CopyPictureCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CopyPictureCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("COPY.PICTURE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CopyToolCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CopyToolCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COPY.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CreateNamesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CreateNamesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CREATE.NAMES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CreatePublisherCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CreatePublisherCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CREATE.PUBLISHER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CustomizeToolbarCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CustomizeToolbarCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("CUSTOMIZE.TOOLBAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CutCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public CutCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class DataDeleteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DataDeleteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATA.DELETE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DataFindCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DataFindCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATA.FIND"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DataFindNextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DataFindNextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DATA.FIND.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DataFindPrevCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DataFindPrevCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DATA.FIND.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DataFormCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DataFormCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATA.FORM"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DataLabelCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DataLabelCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATA.LABEL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DataSeriesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DataSeriesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATA.SERIES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DefineNameCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DefineNameCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DEFINE.NAME"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DefineStyleCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DefineStyleCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DEFINE.STYLE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteArrowCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DeleteArrowCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DELETE.ARROW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteChartAutoFormatCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DeleteChartAutoFormatCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DELETE.CHART.AUTOFORMAT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteFormatCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DeleteFormatCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DELETE.FORMAT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteNameCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DeleteNameCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DELETE.NAME"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DeleteNoteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DeleteNoteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DELETE.NOTE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DeleteOverlayCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DeleteOverlayCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DELETE.OVERLAY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteStyleCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DeleteStyleCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DELETE.STYLE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteToolCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DeleteToolCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DELETE.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DemoteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DemoteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DEMOTE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class DisableInputCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DisableInputCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("DISABLE.INPUT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DisplayCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DisplayCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DISPLAY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class DuplicateCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public DuplicateCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DUPLICATE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditboxPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EditboxPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("EDITBOX.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class EditionOptionsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EditionOptionsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("EDITION.OPTIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class EditColorCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EditColorCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EDIT.COLOR"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditDeleteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EditDeleteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EDIT.DELETE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditObjectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EditObjectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EDIT.OBJECT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditRepeatCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EditRepeatCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EDIT.REPEAT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditSeriesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EditSeriesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EDIT.SERIES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditToolCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EditToolCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EDIT.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EnableObjectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EnableObjectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ENABLE.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class EnableTipwizardCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EnableTipwizardCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ENABLE.TIPWIZARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class EnterDataCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public EnterDataCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ENTER.DATA"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ErrorbarXCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ErrorbarXCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERRORBAR.X"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ErrorbarYCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ErrorbarYCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERRORBAR.Y"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ExtendPolygonCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ExtendPolygonCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("EXTEND.POLYGON"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ExtractCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ExtractCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXTRACT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FileCloseCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FileCloseCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILE.CLOSE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FileDeleteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FileDeleteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILE.DELETE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillAutoCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FillAutoCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILL.AUTO"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillDownCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FillDownCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILL.DOWN"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillGroupCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FillGroupCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILL.GROUP"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillLeftCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FillLeftCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILL.LEFT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillRightCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FillRightCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILL.RIGHT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillUpCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FillUpCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILL.UP"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FilterAdvancedCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FilterAdvancedCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FILTER.ADVANCED"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FilterShowAllCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FilterShowAllCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FILTER.SHOW.ALL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FindFileCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FindFileCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FIND.FILE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FontCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FontCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FONT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FontPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FontPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FONT.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatAutoCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatAutoCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMAT.AUTO"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatChartCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatChartCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMAT.CHART"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatCharttypeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatCharttypeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMAT.CHARTTYPE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatFontCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatFontCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMAT.FONT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatLegendCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatLegendCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMAT.LEGEND"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatMainCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatMainCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMAT.MAIN"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatMoveCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatMoveCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMAT.MOVE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatNumberCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatNumberCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMAT.NUMBER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatOverlayCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatOverlayCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMAT.OVERLAY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatShapeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatShapeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMAT.SHAPE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatSizeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatSizeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMAT.SIZE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatTextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormatTextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMAT.TEXT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormulaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormulaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMULA"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FormulaArrayCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormulaArrayCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMULA.ARRAY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaFillCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormulaFillCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMULA.FILL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaFindCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormulaFindCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMULA.FIND"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaFindNextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormulaFindNextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMULA.FIND.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaFindPrevCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormulaFindPrevCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMULA.FIND.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaGotoCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormulaGotoCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMULA.GOTO"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaReplaceCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FormulaReplaceCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORMULA.REPLACE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FreezePanesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FreezePanesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FREEZE.PANES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FullCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FullCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FULL"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FullScreenCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FullScreenCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FULL.SCREEN"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FunctionWizardCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public FunctionWizardCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FUNCTION.WIZARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DAreaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public Gallery3DAreaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.3D.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DBarCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public Gallery3DBarCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.3D.BAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DColumnCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public Gallery3DColumnCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.3D.COLUMN"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DLineCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public Gallery3DLineCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.3D.LINE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DPieCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public Gallery3DPieCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.3D.PIE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DSurfaceCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public Gallery3DSurfaceCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.3D.SURFACE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryAreaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryAreaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryBarCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryBarCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GALLERY.BAR"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GalleryColumnCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryColumnCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.COLUMN"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryCustomCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryCustomCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.CUSTOM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryDoughnutCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryDoughnutCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.DOUGHNUT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryLineCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryLineCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.LINE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryPieCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryPieCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GALLERY.PIE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GalleryRadarCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryRadarCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.RADAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryScatterCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GalleryScatterCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("GALLERY.SCATTER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GoalSeekCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GoalSeekCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GOAL.SEEK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GridlinesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public GridlinesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GRIDLINES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class HideCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HideCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HIDE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class HideallInkannotsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HideallInkannotsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("HIDEALL.INKANNOTS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class HideallNotesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HideallNotesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("HIDEALL.NOTES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class HidecurrNoteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HidecurrNoteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("HIDECURR.NOTE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class HideDialogCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HideDialogCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HIDE.DIALOG"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class HideObjectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HideObjectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HIDE.OBJECT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class HLineCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HLineCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HLINE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class HPageCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HPageCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HPAGE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class HscrollCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public HscrollCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HSCROLL"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class InsertCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public InsertCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INSERT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class InsertdatatableCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public InsertdatatableCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("INSERTDATATABLE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class InsertMapObjectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public InsertMapObjectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("INSERT.MAP.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class InsertObjectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public InsertObjectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("INSERT.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class InsertPictureCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public InsertPictureCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("INSERT.PICTURE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class InsertTitleCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public InsertTitleCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("INSERT.TITLE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class JustifyCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public JustifyCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("JUSTIFY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class LabelPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public LabelPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("LABEL.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class LayoutCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public LayoutCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LAYOUT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class LegendCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public LegendCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LEGEND"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class LinePrintCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public LinePrintCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LINE.PRINT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class LinkComboCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public LinkComboCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LINK.COMBO"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class LinkFormatCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public LinkFormatCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LINK.FORMAT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ListboxPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ListboxPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("LISTBOX.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ListNamesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ListNamesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LIST.NAMES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MacroOptionsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MacroOptionsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MACRO.OPTIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailAddMailerCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailAddMailerCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MAIL.ADD.MAILER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailDeleteMailerCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailDeleteMailerCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MAIL.DELETE.MAILER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailEditMailerCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailEditMailerCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MAIL.EDIT.MAILER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailForwardCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailForwardCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MAIL.FORWARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailLogOffCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailLogOffCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAIL.LOGOFF"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MailLogOnCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailLogOnCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAIL.LOGON"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MailNextLetterCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailNextLetterCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MAIL.NEXT.LETTER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailReplyCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailReplyCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAIL.REPLY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MailReplyAllCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailReplyAllCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MAIL.REPLY.ALL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailSendMailerCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MailSendMailerCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MAIL.SEND.MAILER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MainChartCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MainChartCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAIN.CHART"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MainChartTypeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MainChartTypeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MAIN.CHART.TYPE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MenuEditorCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MenuEditorCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MENU.EDITOR"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MergeStylesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MergeStylesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("MERGE.STYLES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MessageCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MessageCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MESSAGE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class MoveBrkCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MoveBrkCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MOVE.BRK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MoveToolCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public MoveToolCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MOVE.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NewCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public NewCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NEW"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class NewwebqueryCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public NewwebqueryCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NEWWEBQUERY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NewWindowCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public NewWindowCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NEW.WINDOW"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NormalCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public NormalCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORMAL"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ObjectPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ObjectPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OBJECT.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ObjectProtectionCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ObjectProtectionCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OBJECT.PROTECTION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OnDataCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OnDataCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ON.DATA"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OnDoubleclickCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OnDoubleclickCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ON.DOUBLECLICK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OnEntryCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OnEntryCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ON.ENTRY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OnKeyCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OnKeyCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ON.KEY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OnRecalcCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OnRecalcCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ON.RECALC"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OnSheetCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OnSheetCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ON.SHEET"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OnTimeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OnTimeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ON.TIME"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OnWindowCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OnWindowCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ON.WINDOW"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OpenCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OpenCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OPEN"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OpenLinksCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OpenLinksCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OPEN.LINKS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OpenMailCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OpenMailCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OPEN.MAIL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OpenTextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OpenTextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OPEN.TEXT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OptionsCalculationCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsCalculationCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.CALCULATION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsChartCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsChartCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.CHART"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsEditCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsEditCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.EDIT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsGeneralCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsGeneralCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.GENERAL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsListsAddCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsListsAddCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.LISTS.ADD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsListsDeleteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsListsDeleteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.LISTS.DELETE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsMeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsMeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OPTIONS.ME"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OptionsMenonoCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsMenonoCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.MENONO"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsSaveCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsSaveCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.SAVE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsSpellCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsSpellCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.SPELL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsTransitionCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsTransitionCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.TRANSITION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsViewCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OptionsViewCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OPTIONS.VIEW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OutlineCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OutlineCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OUTLINE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OverlayCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OverlayCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OVERLAY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OverlayChartTypeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public OverlayChartTypeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("OVERLAY.CHART.TYPE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PageSetupCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PageSetupCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PAGE.SETUP"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ParseCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ParseCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PARSE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class PasteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PasteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PASTE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class PasteLinkCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PasteLinkCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PASTE.LINK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PastePictureCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PastePictureCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PASTE.PICTURE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PastePictureLinkCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PastePictureLinkCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PASTE.PICTURE.LINK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PasteSpecialCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PasteSpecialCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PASTE.SPECIAL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PasteToolCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PasteToolCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PASTE.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PatternsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PatternsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PATTERNS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PicklistCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PicklistCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PICKLIST"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PivotAddFieldsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotAddFieldsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.ADD.FIELDS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotFieldCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotFieldCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PIVOT.FIELD"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PivotFieldGroupCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotFieldGroupCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.FIELD.GROUP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotFieldPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotFieldPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.FIELD.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotFieldUngroupCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotFieldUngroupCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.FIELD.UNGROUP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotItemCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotItemCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PIVOT.ITEM"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PivotItemPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotItemPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.ITEM.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotRefreshCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotRefreshCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.REFRESH"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotShowPagesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotShowPagesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.SHOW.PAGES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotTableChartCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotTableChartCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.TABLE.CHART"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotTableWizardCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PivotTableWizardCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PIVOT.TABLE.WIZARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PostDocumentCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PostDocumentCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("POST.DOCUMENT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PrecisionCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PrecisionCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PRECISION"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PreferredCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PreferredCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PREFERRED"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PrintCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PrintCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PRINT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class PrinterSetupCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PrinterSetupCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PRINTER.SETUP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PrintPreviewCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PrintPreviewCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PRINT.PREVIEW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PromoteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PromoteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PROMOTE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ProtectDocumentCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ProtectDocumentCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PROTECT.DOCUMENT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ProtectRevisionsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ProtectRevisionsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PROTECT.REVISIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PushbuttonPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public PushbuttonPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("PUSHBUTTON.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class QuitCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public QuitCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUIT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class RemoveListItemCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public RemoveListItemCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("REMOVE.LIST.ITEM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RemovePageBreakCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public RemovePageBreakCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("REMOVE.PAGE.BREAK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RenameObjectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public RenameObjectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("RENAME.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ReplaceFontCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ReplaceFontCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("REPLACE.FONT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ResetToolCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ResetToolCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RESET.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RmPrintAreaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public RmPrintAreaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("RM.PRINT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RouteDocumentCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public RouteDocumentCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ROUTE.DOCUMENT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RoutingSlipCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public RoutingSlipCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("ROUTING.SLIP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RowHeightCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public RowHeightCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROW.HEIGHT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RunCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public RunCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RUN"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SaveCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SAVE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveAsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SaveAsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SAVE.AS"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveCopyAsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SaveCopyAsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SAVE.COPY.AS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SaveNewObjectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SaveNewObjectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SAVE.NEW.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SaveWorkbookCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SaveWorkbookCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SAVE.WORKBOOK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SaveWorkspaceCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SaveWorkspaceCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SAVE.WORKSPACE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScaleCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScaleCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SCALE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ScenarioAddCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScenarioAddCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCENARIO.ADD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioCellsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScenarioCellsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCENARIO.CELLS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioDeleteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScenarioDeleteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCENARIO.DELETE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioEditCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScenarioEditCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCENARIO.EDIT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioMergeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScenarioMergeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCENARIO.MERGE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioShowCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScenarioShowCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCENARIO.SHOW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioShowNextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScenarioShowNextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCENARIO.SHOW.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioSummaryCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScenarioSummaryCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCENARIO.SUMMARY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScrollbarPropertiesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ScrollbarPropertiesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SCROLLBAR.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SelectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SELECT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SelectAllCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SelectAllCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SELECT.ALL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SelectChartCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SelectChartCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SELECT.CHART"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectEndCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SelectEndCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SELECT.END"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SelectLastCellCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SelectLastCellCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SELECT.LAST.CELL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectListItemCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SelectListItemCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SELECT.LIST.ITEM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectPlotAreaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SelectPlotAreaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SELECT.PLOT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectSpecialCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SelectSpecialCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SELECT.SPECIAL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SendKeysCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SendKeysCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEND.KEYS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SendMailCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SendMailCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEND.MAIL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SendToBackCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SendToBackCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SEND.TO.BACK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SeriesAxesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SeriesAxesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SERIES.AXES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SeriesOrderCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SeriesOrderCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SERIES.ORDER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SeriesXCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SeriesXCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SERIES.X"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SeriesYCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SeriesYCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SERIES.Y"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SetControlValueCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetControlValueCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.CONTROL.VALUE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetCriteriaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetCriteriaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.CRITERIA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetDatabaseCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetDatabaseCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.DATABASE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetDialogDefaultCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetDialogDefaultCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.DIALOG.DEFAULT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetDialogFocusCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetDialogFocusCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.DIALOG.FOCUS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetExtractCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetExtractCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SET.EXTRACT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SetListItemCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetListItemCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.LIST.ITEM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetPageBreakCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetPageBreakCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.PAGE.BREAK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetPreferredCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetPreferredCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.PREFERRED"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetPrintAreaCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetPrintAreaCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.PRINT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetPrintTitlesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetPrintTitlesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.PRINT.TITLES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetUpdateStatusCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SetUpdateStatusCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SET.UPDATE.STATUS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ShareCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShareCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHARE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ShareNameCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShareNameCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHARE.NAME"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SheetBackgroundCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SheetBackgroundCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SHEET.BACKGROUND"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ShortMenusCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShortMenusCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHORT.MENUS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowActiveCellCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShowActiveCellCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SHOW.ACTIVE.CELL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ShowClipboardCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShowClipboardCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SHOW.CLIPBOARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ShowDetailCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShowDetailCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHOW.DETAIL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowDialogCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShowDialogCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHOW.DIALOG"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowInfoCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShowInfoCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHOW.INFO"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowLevelsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShowLevelsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHOW.LEVELS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowToolbarCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ShowToolbarCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SHOW.TOOLBAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SortSpecialCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SortSpecialCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SORT.SPECIAL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SoundNoteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SoundNoteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SOUND.NOTE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SoundPlayCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SoundPlayCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SOUND.PLAY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SpellingCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SpellingCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SPELLING"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SplitCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SplitCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SPLIT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class StandardFontCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public StandardFontCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("STANDARD.FONT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class StandardWidthCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public StandardWidthCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("STANDARD.WIDTH"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class StyleCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public StyleCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STYLE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SubscribeToCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SubscribeToCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SUBSCRIBE.TO"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SubtotalCreateCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SubtotalCreateCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SUBTOTAL.CREATE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SubtotalRemoveCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SubtotalRemoveCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SUBTOTAL.REMOVE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SummaryInfoCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public SummaryInfoCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("SUMMARY.INFO"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TableCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public TableCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TABLE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class TabOrderCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public TabOrderCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TAB.ORDER"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class TextToColumnsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public TextToColumnsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("TEXT.TO.COLUMNS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TracerClearCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public TracerClearCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("TRACER.CLEAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TracerDisplayCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public TracerDisplayCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("TRACER.DISPLAY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TracerErrorCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public TracerErrorCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("TRACER.ERROR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TracerNavigateCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public TracerNavigateCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("TRACER.NAVIGATE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TraverseNotesCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public TraverseNotesCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("TRAVERSE.NOTES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UndoCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public UndoCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNDO"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class UngroupCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public UngroupCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNGROUP"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class UngroupSheetsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public UngroupSheetsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("UNGROUP.SHEETS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UnhideCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public UnhideCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNHIDE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class UnlockedNextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public UnlockedNextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("UNLOCKED.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UnlockedPrevCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public UnlockedPrevCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("UNLOCKED.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UnprotectRevisionsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public UnprotectRevisionsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("UNPROTECT.REVISIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UpdateLinkCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public UpdateLinkCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UPDATE.LINK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class VbaActivateCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public VbaActivateCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VBAACTIVATE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class VbaInsertFileCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public VbaInsertFileCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("VBA.INSERT.FILE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class VbaMakeAddinCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public VbaMakeAddinCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("VBA.MAKE.ADDIN"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class VbaProcedureDefinitionCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public VbaProcedureDefinitionCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("VBA.PROCEDURE.DEFINITION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class View3DCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public View3DCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VIEW.3D"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ViewDefineCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ViewDefineCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VIEW.DEFINE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ViewDeleteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ViewDeleteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VIEW.DELETE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ViewShowCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ViewShowCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VIEW.SHOW"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class VLineCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public VLineCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VLINE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class VPageCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public VPageCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VPAGE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class VscrollCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public VscrollCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VSCROLL"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class WaitCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WaitCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WAIT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class WebPublishCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WebPublishCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEB.PUBLISH"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WindowMaximizeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WindowMaximizeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WINDOW.MAXIMIZE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WindowMinimizeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WindowMinimizeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WINDOW.MINIMIZE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WindowMoveCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WindowMoveCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WINDOW.MOVE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WindowRestoreCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WindowRestoreCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WINDOW.RESTORE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WindowSizeCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WindowSizeCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WINDOW.SIZE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WorkbookActivateCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookActivateCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.ACTIVATE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookAddCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookAddCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.ADD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookCopyCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookCopyCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.COPY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookDeleteCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookDeleteCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.DELETE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookHideCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookHideCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.HIDE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookInsertCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookInsertCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.INSERT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookMoveCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookMoveCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.MOVE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookNameCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookNameCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.NAME"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookNewCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookNewCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.NEW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookNextCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookNextCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookOptionsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookOptionsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.OPTIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookPrevCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookPrevCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookProtectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookProtectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.PROTECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookScrollCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookScrollCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.SCROLL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookSelectCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookSelectCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.SELECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookTabSplitCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookTabSplitCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.TAB.SPLIT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookUnhideCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkbookUnhideCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKBOOK.UNHIDE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkgroupCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkgroupCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WORKGROUP"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WorkgroupOptionsCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkgroupOptionsCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("WORKGROUP.OPTIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkspaceCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public WorkspaceCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WORKSPACE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ZoomCommandFunctionNode : BuiltInCommandFunctionNode
    {
        public ZoomCommandFunctionNode(
            QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ZOOM"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }
}
