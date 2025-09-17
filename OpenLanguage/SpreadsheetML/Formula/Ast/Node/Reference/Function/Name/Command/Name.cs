using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class A1R1C1CommandFunctionNode : CommandFunctionNode
    {
        public A1R1C1CommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "A1.R1C1"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ActivateCommandFunctionNode : CommandFunctionNode
    {
        public ActivateCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ACTIVATE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ActivateNextCommandFunctionNode : CommandFunctionNode
    {
        public ActivateNextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ACTIVATE.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ActivateNotesCommandFunctionNode : CommandFunctionNode
    {
        public ActivateNotesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ACTIVATE.NOTES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ActivatePrevCommandFunctionNode : CommandFunctionNode
    {
        public ActivatePrevCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ACTIVATE.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ActiveCellFontCommandFunctionNode : CommandFunctionNode
    {
        public ActiveCellFontCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ACTIVE.CELL.FONT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddinManagerCommandFunctionNode : CommandFunctionNode
    {
        public AddinManagerCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ADDIN.MANAGER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddArrowCommandFunctionNode : CommandFunctionNode
    {
        public AddArrowCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ADD.ARROW"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AddChartAutoFormatCommandFunctionNode : CommandFunctionNode
    {
        public AddChartAutoFormatCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ADD.CHART.AUTOFORMAT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddListItemCommandFunctionNode : CommandFunctionNode
    {
        public AddListItemCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ADD.LIST.ITEM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddOverlayCommandFunctionNode : CommandFunctionNode
    {
        public AddOverlayCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ADD.OVERLAY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AddPrintAreaCommandFunctionNode : CommandFunctionNode
    {
        public AddPrintAreaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ADD.PRINT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AddToolCommandFunctionNode : CommandFunctionNode
    {
        public AddToolCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ADD.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AlertCommandFunctionNode : CommandFunctionNode
    {
        public AlertCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ALERT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class AlignmentCommandFunctionNode : CommandFunctionNode
    {
        public AlignmentCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ALIGNMENT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ApplyNamesCommandFunctionNode : CommandFunctionNode
    {
        public ApplyNamesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "APPLY.NAMES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ApplyStyleCommandFunctionNode : CommandFunctionNode
    {
        public ApplyStyleCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "APPLY.STYLE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AppActivateCommandFunctionNode : CommandFunctionNode
    {
        public AppActivateCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "APP.ACTIVATE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AppActivateMicrosoftCommandFunctionNode : CommandFunctionNode
    {
        public AppActivateMicrosoftCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "APP.ACTIVATE.MICROSOFT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AppMaximizeCommandFunctionNode : CommandFunctionNode
    {
        public AppMaximizeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "APP.MAXIMIZE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AppMinimizeCommandFunctionNode : CommandFunctionNode
    {
        public AppMinimizeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "APP.MINIMIZE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AppMoveCommandFunctionNode : CommandFunctionNode
    {
        public AppMoveCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "APP.MOVE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AppRestoreCommandFunctionNode : CommandFunctionNode
    {
        public AppRestoreCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "APP.RESTORE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AppSizeCommandFunctionNode : CommandFunctionNode
    {
        public AppSizeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "APP.SIZE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ArrangeAllCommandFunctionNode : CommandFunctionNode
    {
        public ArrangeAllCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ARRANGE.ALL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AssignToObjectCommandFunctionNode : CommandFunctionNode
    {
        public AssignToObjectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ASSIGN.TO.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AssignToToolCommandFunctionNode : CommandFunctionNode
    {
        public AssignToToolCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ASSIGN.TO.TOOL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AttachTextCommandFunctionNode : CommandFunctionNode
    {
        public AttachTextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ATTACH.TEXT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AttachToolbarsCommandFunctionNode : CommandFunctionNode
    {
        public AttachToolbarsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ATTACH.TOOLBARS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AttributesCommandFunctionNode : CommandFunctionNode
    {
        public AttributesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ATTRIBUTES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AutocorrectCommandFunctionNode : CommandFunctionNode
    {
        public AutocorrectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AUTOCORRECT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AutoOutlineCommandFunctionNode : CommandFunctionNode
    {
        public AutoOutlineCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "AUTO.OUTLINE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class AxesCommandFunctionNode : CommandFunctionNode
    {
        public AxesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AXES"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class BeepCommandFunctionNode : CommandFunctionNode
    {
        public BeepCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BEEP"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class BorderCommandFunctionNode : CommandFunctionNode
    {
        public BorderCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BORDER"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class BringToFrontCommandFunctionNode : CommandFunctionNode
    {
        public BringToFrontCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "BRING.TO.FRONT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CalculateDocumentCommandFunctionNode : CommandFunctionNode
    {
        public CalculateDocumentCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CALCULATE.DOCUMENT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CalculateNowCommandFunctionNode : CommandFunctionNode
    {
        public CalculateNowCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CALCULATE.NOW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CalculationCommandFunctionNode : CommandFunctionNode
    {
        public CalculationCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CALCULATION"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CancelCopyCommandFunctionNode : CommandFunctionNode
    {
        public CancelCopyCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CANCEL.COPY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CellProtectionCommandFunctionNode : CommandFunctionNode
    {
        public CellProtectionCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CELL.PROTECTION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ChangeLinkCommandFunctionNode : CommandFunctionNode
    {
        public ChangeLinkCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CHANGE.LINK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ChartAddDataCommandFunctionNode : CommandFunctionNode
    {
        public ChartAddDataCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHART.ADD.DATA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ChartTrendCommandFunctionNode : CommandFunctionNode
    {
        public ChartTrendCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CHART.TREND"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ChartWizardCommandFunctionNode : CommandFunctionNode
    {
        public ChartWizardCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHART.WIZARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CheckboxPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public CheckboxPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHECKBOX.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ClearCommandFunctionNode : CommandFunctionNode
    {
        public ClearCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CLEAR"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ClearOutlineCommandFunctionNode : CommandFunctionNode
    {
        public ClearOutlineCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CLEAR.OUTLINE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ClearPrintAreaCommandFunctionNode : CommandFunctionNode
    {
        public ClearPrintAreaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CLEAR.PRINT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ClearRoutingSlipCommandFunctionNode : CommandFunctionNode
    {
        public ClearRoutingSlipCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CLEAR.ROUTING.SLIP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CloseCommandFunctionNode : CommandFunctionNode
    {
        public CloseCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CLOSE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class CloseAllCommandFunctionNode : CommandFunctionNode
    {
        public CloseAllCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CLOSE.ALL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ColorPaletteCommandFunctionNode : CommandFunctionNode
    {
        public ColorPaletteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "COLOR.PALETTE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ColumnWidthCommandFunctionNode : CommandFunctionNode
    {
        public ColumnWidthCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "COLUMN.WIDTH"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CombinationCommandFunctionNode : CommandFunctionNode
    {
        public CombinationCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COMBINATION"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ConsolidateCommandFunctionNode : CommandFunctionNode
    {
        public ConsolidateCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CONSOLIDATE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ConstrainNumericCommandFunctionNode : CommandFunctionNode
    {
        public ConstrainNumericCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CONSTRAIN.NUMERIC"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CopyCommandFunctionNode : CommandFunctionNode
    {
        public CopyCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COPY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class CopyChartCommandFunctionNode : CommandFunctionNode
    {
        public CopyChartCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COPY.CHART"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CopyPictureCommandFunctionNode : CommandFunctionNode
    {
        public CopyPictureCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "COPY.PICTURE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CopyToolCommandFunctionNode : CommandFunctionNode
    {
        public CopyToolCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COPY.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CreateNamesCommandFunctionNode : CommandFunctionNode
    {
        public CreateNamesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CREATE.NAMES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CreatePublisherCommandFunctionNode : CommandFunctionNode
    {
        public CreatePublisherCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CREATE.PUBLISHER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CustomizeToolbarCommandFunctionNode : CommandFunctionNode
    {
        public CustomizeToolbarCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CUSTOMIZE.TOOLBAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CutCommandFunctionNode : CommandFunctionNode
    {
        public CutCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class DataDeleteCommandFunctionNode : CommandFunctionNode
    {
        public DataDeleteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATA.DELETE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DataFindCommandFunctionNode : CommandFunctionNode
    {
        public DataFindCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATA.FIND"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DataFindNextCommandFunctionNode : CommandFunctionNode
    {
        public DataFindNextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DATA.FIND.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DataFindPrevCommandFunctionNode : CommandFunctionNode
    {
        public DataFindPrevCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DATA.FIND.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DataFormCommandFunctionNode : CommandFunctionNode
    {
        public DataFormCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATA.FORM"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DataLabelCommandFunctionNode : CommandFunctionNode
    {
        public DataLabelCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATA.LABEL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DataSeriesCommandFunctionNode : CommandFunctionNode
    {
        public DataSeriesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATA.SERIES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DefineNameCommandFunctionNode : CommandFunctionNode
    {
        public DefineNameCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DEFINE.NAME"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DefineStyleCommandFunctionNode : CommandFunctionNode
    {
        public DefineStyleCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DEFINE.STYLE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteArrowCommandFunctionNode : CommandFunctionNode
    {
        public DeleteArrowCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DELETE.ARROW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteChartAutoFormatCommandFunctionNode : CommandFunctionNode
    {
        public DeleteChartAutoFormatCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DELETE.CHART.AUTOFORMAT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteFormatCommandFunctionNode : CommandFunctionNode
    {
        public DeleteFormatCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DELETE.FORMAT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteNameCommandFunctionNode : CommandFunctionNode
    {
        public DeleteNameCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DELETE.NAME"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DeleteNoteCommandFunctionNode : CommandFunctionNode
    {
        public DeleteNoteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DELETE.NOTE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DeleteOverlayCommandFunctionNode : CommandFunctionNode
    {
        public DeleteOverlayCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DELETE.OVERLAY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteStyleCommandFunctionNode : CommandFunctionNode
    {
        public DeleteStyleCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DELETE.STYLE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DeleteToolCommandFunctionNode : CommandFunctionNode
    {
        public DeleteToolCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DELETE.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DemoteCommandFunctionNode : CommandFunctionNode
    {
        public DemoteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DEMOTE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class DisableInputCommandFunctionNode : CommandFunctionNode
    {
        public DisableInputCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DISABLE.INPUT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class DisplayCommandFunctionNode : CommandFunctionNode
    {
        public DisplayCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DISPLAY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class DuplicateCommandFunctionNode : CommandFunctionNode
    {
        public DuplicateCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DUPLICATE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditboxPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public EditboxPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "EDITBOX.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class EditionOptionsCommandFunctionNode : CommandFunctionNode
    {
        public EditionOptionsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "EDITION.OPTIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class EditColorCommandFunctionNode : CommandFunctionNode
    {
        public EditColorCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EDIT.COLOR"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditDeleteCommandFunctionNode : CommandFunctionNode
    {
        public EditDeleteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EDIT.DELETE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditObjectCommandFunctionNode : CommandFunctionNode
    {
        public EditObjectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EDIT.OBJECT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditRepeatCommandFunctionNode : CommandFunctionNode
    {
        public EditRepeatCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EDIT.REPEAT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditSeriesCommandFunctionNode : CommandFunctionNode
    {
        public EditSeriesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EDIT.SERIES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EditToolCommandFunctionNode : CommandFunctionNode
    {
        public EditToolCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EDIT.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EnableObjectCommandFunctionNode : CommandFunctionNode
    {
        public EnableObjectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ENABLE.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class EnableTipwizardCommandFunctionNode : CommandFunctionNode
    {
        public EnableTipwizardCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ENABLE.TIPWIZARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class EnterDataCommandFunctionNode : CommandFunctionNode
    {
        public EnterDataCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ENTER.DATA"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ErrorbarXCommandFunctionNode : CommandFunctionNode
    {
        public ErrorbarXCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ERRORBAR.X"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ErrorbarYCommandFunctionNode : CommandFunctionNode
    {
        public ErrorbarYCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ERRORBAR.Y"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ExtendPolygonCommandFunctionNode : CommandFunctionNode
    {
        public ExtendPolygonCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "EXTEND.POLYGON"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ExtractCommandFunctionNode : CommandFunctionNode
    {
        public ExtractCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EXTRACT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FileCloseCommandFunctionNode : CommandFunctionNode
    {
        public FileCloseCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILE.CLOSE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FileDeleteCommandFunctionNode : CommandFunctionNode
    {
        public FileDeleteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILE.DELETE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillAutoCommandFunctionNode : CommandFunctionNode
    {
        public FillAutoCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILL.AUTO"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillDownCommandFunctionNode : CommandFunctionNode
    {
        public FillDownCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILL.DOWN"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillGroupCommandFunctionNode : CommandFunctionNode
    {
        public FillGroupCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILL.GROUP"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillLeftCommandFunctionNode : CommandFunctionNode
    {
        public FillLeftCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILL.LEFT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillRightCommandFunctionNode : CommandFunctionNode
    {
        public FillRightCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILL.RIGHT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FillUpCommandFunctionNode : CommandFunctionNode
    {
        public FillUpCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FILL.UP"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FilterAdvancedCommandFunctionNode : CommandFunctionNode
    {
        public FilterAdvancedCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FILTER.ADVANCED"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FilterShowAllCommandFunctionNode : CommandFunctionNode
    {
        public FilterShowAllCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FILTER.SHOW.ALL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FindFileCommandFunctionNode : CommandFunctionNode
    {
        public FindFileCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FIND.FILE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FontCommandFunctionNode : CommandFunctionNode
    {
        public FontCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FONT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FontPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public FontPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FONT.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatAutoCommandFunctionNode : CommandFunctionNode
    {
        public FormatAutoCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORMAT.AUTO"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatChartCommandFunctionNode : CommandFunctionNode
    {
        public FormatChartCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMAT.CHART"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatCharttypeCommandFunctionNode : CommandFunctionNode
    {
        public FormatCharttypeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMAT.CHARTTYPE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatFontCommandFunctionNode : CommandFunctionNode
    {
        public FormatFontCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORMAT.FONT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatLegendCommandFunctionNode : CommandFunctionNode
    {
        public FormatLegendCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMAT.LEGEND"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatMainCommandFunctionNode : CommandFunctionNode
    {
        public FormatMainCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORMAT.MAIN"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatMoveCommandFunctionNode : CommandFunctionNode
    {
        public FormatMoveCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORMAT.MOVE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatNumberCommandFunctionNode : CommandFunctionNode
    {
        public FormatNumberCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMAT.NUMBER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatOverlayCommandFunctionNode : CommandFunctionNode
    {
        public FormatOverlayCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMAT.OVERLAY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatShapeCommandFunctionNode : CommandFunctionNode
    {
        public FormatShapeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMAT.SHAPE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormatSizeCommandFunctionNode : CommandFunctionNode
    {
        public FormatSizeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORMAT.SIZE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormatTextCommandFunctionNode : CommandFunctionNode
    {
        public FormatTextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORMAT.TEXT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormulaCommandFunctionNode : CommandFunctionNode
    {
        public FormulaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORMULA"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FormulaArrayCommandFunctionNode : CommandFunctionNode
    {
        public FormulaArrayCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMULA.ARRAY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaFillCommandFunctionNode : CommandFunctionNode
    {
        public FormulaFillCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMULA.FILL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaFindCommandFunctionNode : CommandFunctionNode
    {
        public FormulaFindCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMULA.FIND"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaFindNextCommandFunctionNode : CommandFunctionNode
    {
        public FormulaFindNextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMULA.FIND.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaFindPrevCommandFunctionNode : CommandFunctionNode
    {
        public FormulaFindPrevCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMULA.FIND.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaGotoCommandFunctionNode : CommandFunctionNode
    {
        public FormulaGotoCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMULA.GOTO"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FormulaReplaceCommandFunctionNode : CommandFunctionNode
    {
        public FormulaReplaceCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMULA.REPLACE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FreezePanesCommandFunctionNode : CommandFunctionNode
    {
        public FreezePanesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FREEZE.PANES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class FullCommandFunctionNode : CommandFunctionNode
    {
        public FullCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FULL"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class FullScreenCommandFunctionNode : CommandFunctionNode
    {
        public FullScreenCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FULL.SCREEN"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FunctionWizardCommandFunctionNode : CommandFunctionNode
    {
        public FunctionWizardCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FUNCTION.WIZARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DAreaCommandFunctionNode : CommandFunctionNode
    {
        public Gallery3DAreaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.3D.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DBarCommandFunctionNode : CommandFunctionNode
    {
        public Gallery3DBarCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.3D.BAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DColumnCommandFunctionNode : CommandFunctionNode
    {
        public Gallery3DColumnCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.3D.COLUMN"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DLineCommandFunctionNode : CommandFunctionNode
    {
        public Gallery3DLineCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.3D.LINE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DPieCommandFunctionNode : CommandFunctionNode
    {
        public Gallery3DPieCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.3D.PIE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class Gallery3DSurfaceCommandFunctionNode : CommandFunctionNode
    {
        public Gallery3DSurfaceCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.3D.SURFACE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryAreaCommandFunctionNode : CommandFunctionNode
    {
        public GalleryAreaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryBarCommandFunctionNode : CommandFunctionNode
    {
        public GalleryBarCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GALLERY.BAR"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GalleryColumnCommandFunctionNode : CommandFunctionNode
    {
        public GalleryColumnCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.COLUMN"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryCustomCommandFunctionNode : CommandFunctionNode
    {
        public GalleryCustomCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.CUSTOM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryDoughnutCommandFunctionNode : CommandFunctionNode
    {
        public GalleryDoughnutCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.DOUGHNUT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryLineCommandFunctionNode : CommandFunctionNode
    {
        public GalleryLineCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.LINE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryPieCommandFunctionNode : CommandFunctionNode
    {
        public GalleryPieCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GALLERY.PIE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GalleryRadarCommandFunctionNode : CommandFunctionNode
    {
        public GalleryRadarCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.RADAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GalleryScatterCommandFunctionNode : CommandFunctionNode
    {
        public GalleryScatterCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GALLERY.SCATTER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class GoalSeekCommandFunctionNode : CommandFunctionNode
    {
        public GoalSeekCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GOAL.SEEK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GridlinesCommandFunctionNode : CommandFunctionNode
    {
        public GridlinesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GRIDLINES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class HideCommandFunctionNode : CommandFunctionNode
    {
        public HideCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HIDE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class HideallInkannotsCommandFunctionNode : CommandFunctionNode
    {
        public HideallInkannotsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "HIDEALL.INKANNOTS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class HideallNotesCommandFunctionNode : CommandFunctionNode
    {
        public HideallNotesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "HIDEALL.NOTES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class HidecurrNoteCommandFunctionNode : CommandFunctionNode
    {
        public HidecurrNoteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "HIDECURR.NOTE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class HideDialogCommandFunctionNode : CommandFunctionNode
    {
        public HideDialogCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HIDE.DIALOG"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class HideObjectCommandFunctionNode : CommandFunctionNode
    {
        public HideObjectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HIDE.OBJECT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class HLineCommandFunctionNode : CommandFunctionNode
    {
        public HLineCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HLINE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class HPageCommandFunctionNode : CommandFunctionNode
    {
        public HPageCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HPAGE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class HscrollCommandFunctionNode : CommandFunctionNode
    {
        public HscrollCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HSCROLL"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class InsertCommandFunctionNode : CommandFunctionNode
    {
        public InsertCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INSERT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class InsertdatatableCommandFunctionNode : CommandFunctionNode
    {
        public InsertdatatableCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "INSERTDATATABLE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class InsertMapObjectCommandFunctionNode : CommandFunctionNode
    {
        public InsertMapObjectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "INSERT.MAP.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class InsertObjectCommandFunctionNode : CommandFunctionNode
    {
        public InsertObjectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "INSERT.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class InsertPictureCommandFunctionNode : CommandFunctionNode
    {
        public InsertPictureCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "INSERT.PICTURE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class InsertTitleCommandFunctionNode : CommandFunctionNode
    {
        public InsertTitleCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "INSERT.TITLE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class JustifyCommandFunctionNode : CommandFunctionNode
    {
        public JustifyCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "JUSTIFY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class LabelPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public LabelPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "LABEL.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class LayoutCommandFunctionNode : CommandFunctionNode
    {
        public LayoutCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LAYOUT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class LegendCommandFunctionNode : CommandFunctionNode
    {
        public LegendCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LEGEND"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class LinePrintCommandFunctionNode : CommandFunctionNode
    {
        public LinePrintCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LINE.PRINT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class LinkComboCommandFunctionNode : CommandFunctionNode
    {
        public LinkComboCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LINK.COMBO"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class LinkFormatCommandFunctionNode : CommandFunctionNode
    {
        public LinkFormatCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LINK.FORMAT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ListboxPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public ListboxPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "LISTBOX.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ListNamesCommandFunctionNode : CommandFunctionNode
    {
        public ListNamesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LIST.NAMES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MacroOptionsCommandFunctionNode : CommandFunctionNode
    {
        public MacroOptionsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MACRO.OPTIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailAddMailerCommandFunctionNode : CommandFunctionNode
    {
        public MailAddMailerCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAIL.ADD.MAILER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailDeleteMailerCommandFunctionNode : CommandFunctionNode
    {
        public MailDeleteMailerCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAIL.DELETE.MAILER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailEditMailerCommandFunctionNode : CommandFunctionNode
    {
        public MailEditMailerCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAIL.EDIT.MAILER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailForwardCommandFunctionNode : CommandFunctionNode
    {
        public MailForwardCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAIL.FORWARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailLogOffCommandFunctionNode : CommandFunctionNode
    {
        public MailLogOffCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MAIL.LOGOFF"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MailLogOnCommandFunctionNode : CommandFunctionNode
    {
        public MailLogOnCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MAIL.LOGON"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MailNextLetterCommandFunctionNode : CommandFunctionNode
    {
        public MailNextLetterCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAIL.NEXT.LETTER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailReplyCommandFunctionNode : CommandFunctionNode
    {
        public MailReplyCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MAIL.REPLY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MailReplyAllCommandFunctionNode : CommandFunctionNode
    {
        public MailReplyAllCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAIL.REPLY.ALL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MailSendMailerCommandFunctionNode : CommandFunctionNode
    {
        public MailSendMailerCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAIL.SEND.MAILER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MainChartCommandFunctionNode : CommandFunctionNode
    {
        public MainChartCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MAIN.CHART"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MainChartTypeCommandFunctionNode : CommandFunctionNode
    {
        public MainChartTypeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAIN.CHART.TYPE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MenuEditorCommandFunctionNode : CommandFunctionNode
    {
        public MenuEditorCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MENU.EDITOR"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MergeStylesCommandFunctionNode : CommandFunctionNode
    {
        public MergeStylesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MERGE.STYLES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class MessageCommandFunctionNode : CommandFunctionNode
    {
        public MessageCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MESSAGE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class MoveBrkCommandFunctionNode : CommandFunctionNode
    {
        public MoveBrkCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MOVE.BRK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class MoveToolCommandFunctionNode : CommandFunctionNode
    {
        public MoveToolCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MOVE.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NewCommandFunctionNode : CommandFunctionNode
    {
        public NewCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NEW"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class NewwebqueryCommandFunctionNode : CommandFunctionNode
    {
        public NewwebqueryCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NEWWEBQUERY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NewWindowCommandFunctionNode : CommandFunctionNode
    {
        public NewWindowCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NEW.WINDOW"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NormalCommandFunctionNode : CommandFunctionNode
    {
        public NormalCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NORMAL"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ObjectPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public ObjectPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OBJECT.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ObjectProtectionCommandFunctionNode : CommandFunctionNode
    {
        public ObjectProtectionCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OBJECT.PROTECTION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OnDataCommandFunctionNode : CommandFunctionNode
    {
        public OnDataCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ON.DATA"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OnDoubleclickCommandFunctionNode : CommandFunctionNode
    {
        public OnDoubleclickCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ON.DOUBLECLICK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OnEntryCommandFunctionNode : CommandFunctionNode
    {
        public OnEntryCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ON.ENTRY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OnKeyCommandFunctionNode : CommandFunctionNode
    {
        public OnKeyCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ON.KEY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OnRecalcCommandFunctionNode : CommandFunctionNode
    {
        public OnRecalcCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ON.RECALC"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OnSheetCommandFunctionNode : CommandFunctionNode
    {
        public OnSheetCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ON.SHEET"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OnTimeCommandFunctionNode : CommandFunctionNode
    {
        public OnTimeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ON.TIME"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OnWindowCommandFunctionNode : CommandFunctionNode
    {
        public OnWindowCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ON.WINDOW"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OpenCommandFunctionNode : CommandFunctionNode
    {
        public OpenCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OPEN"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OpenLinksCommandFunctionNode : CommandFunctionNode
    {
        public OpenLinksCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OPEN.LINKS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OpenMailCommandFunctionNode : CommandFunctionNode
    {
        public OpenMailCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OPEN.MAIL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OpenTextCommandFunctionNode : CommandFunctionNode
    {
        public OpenTextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OPEN.TEXT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OptionsCalculationCommandFunctionNode : CommandFunctionNode
    {
        public OptionsCalculationCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.CALCULATION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsChartCommandFunctionNode : CommandFunctionNode
    {
        public OptionsChartCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.CHART"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsEditCommandFunctionNode : CommandFunctionNode
    {
        public OptionsEditCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.EDIT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsGeneralCommandFunctionNode : CommandFunctionNode
    {
        public OptionsGeneralCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.GENERAL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsListsAddCommandFunctionNode : CommandFunctionNode
    {
        public OptionsListsAddCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.LISTS.ADD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsListsDeleteCommandFunctionNode : CommandFunctionNode
    {
        public OptionsListsDeleteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.LISTS.DELETE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsMeCommandFunctionNode : CommandFunctionNode
    {
        public OptionsMeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OPTIONS.ME"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OptionsMenonoCommandFunctionNode : CommandFunctionNode
    {
        public OptionsMenonoCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.MENONO"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsSaveCommandFunctionNode : CommandFunctionNode
    {
        public OptionsSaveCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.SAVE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsSpellCommandFunctionNode : CommandFunctionNode
    {
        public OptionsSpellCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.SPELL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsTransitionCommandFunctionNode : CommandFunctionNode
    {
        public OptionsTransitionCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.TRANSITION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OptionsViewCommandFunctionNode : CommandFunctionNode
    {
        public OptionsViewCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OPTIONS.VIEW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class OutlineCommandFunctionNode : CommandFunctionNode
    {
        public OutlineCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OUTLINE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OverlayCommandFunctionNode : CommandFunctionNode
    {
        public OverlayCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OVERLAY"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class OverlayChartTypeCommandFunctionNode : CommandFunctionNode
    {
        public OverlayChartTypeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "OVERLAY.CHART.TYPE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PageSetupCommandFunctionNode : CommandFunctionNode
    {
        public PageSetupCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PAGE.SETUP"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ParseCommandFunctionNode : CommandFunctionNode
    {
        public ParseCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PARSE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class PasteCommandFunctionNode : CommandFunctionNode
    {
        public PasteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PASTE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class PasteLinkCommandFunctionNode : CommandFunctionNode
    {
        public PasteLinkCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PASTE.LINK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PastePictureCommandFunctionNode : CommandFunctionNode
    {
        public PastePictureCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PASTE.PICTURE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PastePictureLinkCommandFunctionNode : CommandFunctionNode
    {
        public PastePictureLinkCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PASTE.PICTURE.LINK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PasteSpecialCommandFunctionNode : CommandFunctionNode
    {
        public PasteSpecialCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PASTE.SPECIAL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PasteToolCommandFunctionNode : CommandFunctionNode
    {
        public PasteToolCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PASTE.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PatternsCommandFunctionNode : CommandFunctionNode
    {
        public PatternsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PATTERNS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PicklistCommandFunctionNode : CommandFunctionNode
    {
        public PicklistCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PICKLIST"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PivotAddFieldsCommandFunctionNode : CommandFunctionNode
    {
        public PivotAddFieldsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.ADD.FIELDS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotFieldCommandFunctionNode : CommandFunctionNode
    {
        public PivotFieldCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PIVOT.FIELD"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PivotFieldGroupCommandFunctionNode : CommandFunctionNode
    {
        public PivotFieldGroupCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.FIELD.GROUP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotFieldPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public PivotFieldPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.FIELD.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotFieldUngroupCommandFunctionNode : CommandFunctionNode
    {
        public PivotFieldUngroupCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.FIELD.UNGROUP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotItemCommandFunctionNode : CommandFunctionNode
    {
        public PivotItemCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PIVOT.ITEM"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PivotItemPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public PivotItemPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.ITEM.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotRefreshCommandFunctionNode : CommandFunctionNode
    {
        public PivotRefreshCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.REFRESH"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotShowPagesCommandFunctionNode : CommandFunctionNode
    {
        public PivotShowPagesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.SHOW.PAGES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotTableChartCommandFunctionNode : CommandFunctionNode
    {
        public PivotTableChartCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.TABLE.CHART"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PivotTableWizardCommandFunctionNode : CommandFunctionNode
    {
        public PivotTableWizardCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOT.TABLE.WIZARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PostDocumentCommandFunctionNode : CommandFunctionNode
    {
        public PostDocumentCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "POST.DOCUMENT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PrecisionCommandFunctionNode : CommandFunctionNode
    {
        public PrecisionCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PRECISION"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PreferredCommandFunctionNode : CommandFunctionNode
    {
        public PreferredCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PREFERRED"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PrintCommandFunctionNode : CommandFunctionNode
    {
        public PrintCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PRINT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class PrinterSetupCommandFunctionNode : CommandFunctionNode
    {
        public PrinterSetupCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PRINTER.SETUP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PrintPreviewCommandFunctionNode : CommandFunctionNode
    {
        public PrintPreviewCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PRINT.PREVIEW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PromoteCommandFunctionNode : CommandFunctionNode
    {
        public PromoteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PROMOTE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ProtectDocumentCommandFunctionNode : CommandFunctionNode
    {
        public ProtectDocumentCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PROTECT.DOCUMENT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ProtectRevisionsCommandFunctionNode : CommandFunctionNode
    {
        public ProtectRevisionsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PROTECT.REVISIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class PushbuttonPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public PushbuttonPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PUSHBUTTON.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class QuitCommandFunctionNode : CommandFunctionNode
    {
        public QuitCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "QUIT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class RemoveListItemCommandFunctionNode : CommandFunctionNode
    {
        public RemoveListItemCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "REMOVE.LIST.ITEM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RemovePageBreakCommandFunctionNode : CommandFunctionNode
    {
        public RemovePageBreakCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "REMOVE.PAGE.BREAK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RenameObjectCommandFunctionNode : CommandFunctionNode
    {
        public RenameObjectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "RENAME.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ReplaceFontCommandFunctionNode : CommandFunctionNode
    {
        public ReplaceFontCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "REPLACE.FONT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ResetToolCommandFunctionNode : CommandFunctionNode
    {
        public ResetToolCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RESET.TOOL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RmPrintAreaCommandFunctionNode : CommandFunctionNode
    {
        public RmPrintAreaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "RM.PRINT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RouteDocumentCommandFunctionNode : CommandFunctionNode
    {
        public RouteDocumentCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ROUTE.DOCUMENT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RoutingSlipCommandFunctionNode : CommandFunctionNode
    {
        public RoutingSlipCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ROUTING.SLIP"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class RowHeightCommandFunctionNode : CommandFunctionNode
    {
        public RowHeightCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROW.HEIGHT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RunCommandFunctionNode : CommandFunctionNode
    {
        public RunCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RUN"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveCommandFunctionNode : CommandFunctionNode
    {
        public SaveCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SAVE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveAsCommandFunctionNode : CommandFunctionNode
    {
        public SaveAsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SAVE.AS"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SaveCopyAsCommandFunctionNode : CommandFunctionNode
    {
        public SaveCopyAsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SAVE.COPY.AS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SaveNewObjectCommandFunctionNode : CommandFunctionNode
    {
        public SaveNewObjectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SAVE.NEW.OBJECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SaveWorkbookCommandFunctionNode : CommandFunctionNode
    {
        public SaveWorkbookCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SAVE.WORKBOOK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SaveWorkspaceCommandFunctionNode : CommandFunctionNode
    {
        public SaveWorkspaceCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SAVE.WORKSPACE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScaleCommandFunctionNode : CommandFunctionNode
    {
        public ScaleCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SCALE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ScenarioAddCommandFunctionNode : CommandFunctionNode
    {
        public ScenarioAddCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCENARIO.ADD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioCellsCommandFunctionNode : CommandFunctionNode
    {
        public ScenarioCellsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCENARIO.CELLS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioDeleteCommandFunctionNode : CommandFunctionNode
    {
        public ScenarioDeleteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCENARIO.DELETE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioEditCommandFunctionNode : CommandFunctionNode
    {
        public ScenarioEditCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCENARIO.EDIT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioMergeCommandFunctionNode : CommandFunctionNode
    {
        public ScenarioMergeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCENARIO.MERGE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioShowCommandFunctionNode : CommandFunctionNode
    {
        public ScenarioShowCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCENARIO.SHOW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioShowNextCommandFunctionNode : CommandFunctionNode
    {
        public ScenarioShowNextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCENARIO.SHOW.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScenarioSummaryCommandFunctionNode : CommandFunctionNode
    {
        public ScenarioSummaryCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCENARIO.SUMMARY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ScrollbarPropertiesCommandFunctionNode : CommandFunctionNode
    {
        public ScrollbarPropertiesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SCROLLBAR.PROPERTIES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectCommandFunctionNode : CommandFunctionNode
    {
        public SelectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SELECT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SelectAllCommandFunctionNode : CommandFunctionNode
    {
        public SelectAllCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SELECT.ALL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SelectChartCommandFunctionNode : CommandFunctionNode
    {
        public SelectChartCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SELECT.CHART"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectEndCommandFunctionNode : CommandFunctionNode
    {
        public SelectEndCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SELECT.END"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SelectLastCellCommandFunctionNode : CommandFunctionNode
    {
        public SelectLastCellCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SELECT.LAST.CELL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectListItemCommandFunctionNode : CommandFunctionNode
    {
        public SelectListItemCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SELECT.LIST.ITEM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectPlotAreaCommandFunctionNode : CommandFunctionNode
    {
        public SelectPlotAreaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SELECT.PLOT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SelectSpecialCommandFunctionNode : CommandFunctionNode
    {
        public SelectSpecialCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SELECT.SPECIAL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SendKeysCommandFunctionNode : CommandFunctionNode
    {
        public SendKeysCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SEND.KEYS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SendMailCommandFunctionNode : CommandFunctionNode
    {
        public SendMailCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SEND.MAIL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SendToBackCommandFunctionNode : CommandFunctionNode
    {
        public SendToBackCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SEND.TO.BACK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SeriesAxesCommandFunctionNode : CommandFunctionNode
    {
        public SeriesAxesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SERIES.AXES"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SeriesOrderCommandFunctionNode : CommandFunctionNode
    {
        public SeriesOrderCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SERIES.ORDER"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SeriesXCommandFunctionNode : CommandFunctionNode
    {
        public SeriesXCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SERIES.X"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SeriesYCommandFunctionNode : CommandFunctionNode
    {
        public SeriesYCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SERIES.Y"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SetControlValueCommandFunctionNode : CommandFunctionNode
    {
        public SetControlValueCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.CONTROL.VALUE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetCriteriaCommandFunctionNode : CommandFunctionNode
    {
        public SetCriteriaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.CRITERIA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetDatabaseCommandFunctionNode : CommandFunctionNode
    {
        public SetDatabaseCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.DATABASE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetDialogDefaultCommandFunctionNode : CommandFunctionNode
    {
        public SetDialogDefaultCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.DIALOG.DEFAULT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetDialogFocusCommandFunctionNode : CommandFunctionNode
    {
        public SetDialogFocusCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.DIALOG.FOCUS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetExtractCommandFunctionNode : CommandFunctionNode
    {
        public SetExtractCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SET.EXTRACT"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SetListItemCommandFunctionNode : CommandFunctionNode
    {
        public SetListItemCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.LIST.ITEM"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetPageBreakCommandFunctionNode : CommandFunctionNode
    {
        public SetPageBreakCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.PAGE.BREAK"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetPreferredCommandFunctionNode : CommandFunctionNode
    {
        public SetPreferredCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.PREFERRED"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetPrintAreaCommandFunctionNode : CommandFunctionNode
    {
        public SetPrintAreaCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.PRINT.AREA"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetPrintTitlesCommandFunctionNode : CommandFunctionNode
    {
        public SetPrintTitlesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.PRINT.TITLES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SetUpdateStatusCommandFunctionNode : CommandFunctionNode
    {
        public SetUpdateStatusCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SET.UPDATE.STATUS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ShareCommandFunctionNode : CommandFunctionNode
    {
        public ShareCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHARE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ShareNameCommandFunctionNode : CommandFunctionNode
    {
        public ShareNameCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHARE.NAME"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SheetBackgroundCommandFunctionNode : CommandFunctionNode
    {
        public SheetBackgroundCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SHEET.BACKGROUND"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ShortMenusCommandFunctionNode : CommandFunctionNode
    {
        public ShortMenusCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHORT.MENUS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowActiveCellCommandFunctionNode : CommandFunctionNode
    {
        public ShowActiveCellCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SHOW.ACTIVE.CELL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ShowClipboardCommandFunctionNode : CommandFunctionNode
    {
        public ShowClipboardCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SHOW.CLIPBOARD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ShowDetailCommandFunctionNode : CommandFunctionNode
    {
        public ShowDetailCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHOW.DETAIL"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowDialogCommandFunctionNode : CommandFunctionNode
    {
        public ShowDialogCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHOW.DIALOG"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowInfoCommandFunctionNode : CommandFunctionNode
    {
        public ShowInfoCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHOW.INFO"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowLevelsCommandFunctionNode : CommandFunctionNode
    {
        public ShowLevelsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHOW.LEVELS"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ShowToolbarCommandFunctionNode : CommandFunctionNode
    {
        public ShowToolbarCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SHOW.TOOLBAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SortSpecialCommandFunctionNode : CommandFunctionNode
    {
        public SortSpecialCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SORT.SPECIAL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SoundNoteCommandFunctionNode : CommandFunctionNode
    {
        public SoundNoteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SOUND.NOTE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SoundPlayCommandFunctionNode : CommandFunctionNode
    {
        public SoundPlayCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SOUND.PLAY"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SpellingCommandFunctionNode : CommandFunctionNode
    {
        public SpellingCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SPELLING"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SplitCommandFunctionNode : CommandFunctionNode
    {
        public SplitCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SPLIT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class StandardFontCommandFunctionNode : CommandFunctionNode
    {
        public StandardFontCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "STANDARD.FONT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class StandardWidthCommandFunctionNode : CommandFunctionNode
    {
        public StandardWidthCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "STANDARD.WIDTH"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class StyleCommandFunctionNode : CommandFunctionNode
    {
        public StyleCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "STYLE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class SubscribeToCommandFunctionNode : CommandFunctionNode
    {
        public SubscribeToCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SUBSCRIBE.TO"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SubtotalCreateCommandFunctionNode : CommandFunctionNode
    {
        public SubtotalCreateCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SUBTOTAL.CREATE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SubtotalRemoveCommandFunctionNode : CommandFunctionNode
    {
        public SubtotalRemoveCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SUBTOTAL.REMOVE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class SummaryInfoCommandFunctionNode : CommandFunctionNode
    {
        public SummaryInfoCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SUMMARY.INFO"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TableCommandFunctionNode : CommandFunctionNode
    {
        public TableCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TABLE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class TabOrderCommandFunctionNode : CommandFunctionNode
    {
        public TabOrderCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TAB.ORDER"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class TextToColumnsCommandFunctionNode : CommandFunctionNode
    {
        public TextToColumnsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TEXT.TO.COLUMNS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TracerClearCommandFunctionNode : CommandFunctionNode
    {
        public TracerClearCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TRACER.CLEAR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TracerDisplayCommandFunctionNode : CommandFunctionNode
    {
        public TracerDisplayCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TRACER.DISPLAY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TracerErrorCommandFunctionNode : CommandFunctionNode
    {
        public TracerErrorCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TRACER.ERROR"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TracerNavigateCommandFunctionNode : CommandFunctionNode
    {
        public TracerNavigateCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TRACER.NAVIGATE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class TraverseNotesCommandFunctionNode : CommandFunctionNode
    {
        public TraverseNotesCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TRAVERSE.NOTES"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UndoCommandFunctionNode : CommandFunctionNode
    {
        public UndoCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "UNDO"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class UngroupCommandFunctionNode : CommandFunctionNode
    {
        public UngroupCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "UNGROUP"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class UngroupSheetsCommandFunctionNode : CommandFunctionNode
    {
        public UngroupSheetsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "UNGROUP.SHEETS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UnhideCommandFunctionNode : CommandFunctionNode
    {
        public UnhideCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "UNHIDE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class UnlockedNextCommandFunctionNode : CommandFunctionNode
    {
        public UnlockedNextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "UNLOCKED.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UnlockedPrevCommandFunctionNode : CommandFunctionNode
    {
        public UnlockedPrevCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "UNLOCKED.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UnprotectRevisionsCommandFunctionNode : CommandFunctionNode
    {
        public UnprotectRevisionsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "UNPROTECT.REVISIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class UpdateLinkCommandFunctionNode : CommandFunctionNode
    {
        public UpdateLinkCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "UPDATE.LINK"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class VbaActivateCommandFunctionNode : CommandFunctionNode
    {
        public VbaActivateCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VBAACTIVATE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class VbaInsertFileCommandFunctionNode : CommandFunctionNode
    {
        public VbaInsertFileCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "VBA.INSERT.FILE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class VbaMakeAddinCommandFunctionNode : CommandFunctionNode
    {
        public VbaMakeAddinCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "VBA.MAKE.ADDIN"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class VbaProcedureDefinitionCommandFunctionNode : CommandFunctionNode
    {
        public VbaProcedureDefinitionCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "VBA.PROCEDURE.DEFINITION"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class View3DCommandFunctionNode : CommandFunctionNode
    {
        public View3DCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VIEW.3D"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class ViewDefineCommandFunctionNode : CommandFunctionNode
    {
        public ViewDefineCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VIEW.DEFINE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ViewDeleteCommandFunctionNode : CommandFunctionNode
    {
        public ViewDeleteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VIEW.DELETE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ViewShowCommandFunctionNode : CommandFunctionNode
    {
        public ViewShowCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VIEW.SHOW"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class VLineCommandFunctionNode : CommandFunctionNode
    {
        public VLineCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VLINE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class VPageCommandFunctionNode : CommandFunctionNode
    {
        public VPageCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VPAGE"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class VscrollCommandFunctionNode : CommandFunctionNode
    {
        public VscrollCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VSCROLL"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class WaitCommandFunctionNode : CommandFunctionNode
    {
        public WaitCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WAIT"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }

    public class WebPublishCommandFunctionNode : CommandFunctionNode
    {
        public WebPublishCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WEB.PUBLISH"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WindowMaximizeCommandFunctionNode : CommandFunctionNode
    {
        public WindowMaximizeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WINDOW.MAXIMIZE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WindowMinimizeCommandFunctionNode : CommandFunctionNode
    {
        public WindowMinimizeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WINDOW.MINIMIZE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WindowMoveCommandFunctionNode : CommandFunctionNode
    {
        public WindowMoveCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WINDOW.MOVE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WindowRestoreCommandFunctionNode : CommandFunctionNode
    {
        public WindowRestoreCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WINDOW.RESTORE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WindowSizeCommandFunctionNode : CommandFunctionNode
    {
        public WindowSizeCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WINDOW.SIZE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WorkbookActivateCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookActivateCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.ACTIVATE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookAddCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookAddCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.ADD"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookCopyCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookCopyCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.COPY"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookDeleteCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookDeleteCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.DELETE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookHideCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookHideCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.HIDE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookInsertCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookInsertCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.INSERT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookMoveCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookMoveCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.MOVE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookNameCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookNameCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.NAME"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookNewCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookNewCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.NEW"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookNextCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookNextCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.NEXT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookOptionsCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookOptionsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.OPTIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookPrevCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookPrevCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.PREV"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookProtectCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookProtectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.PROTECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookScrollCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookScrollCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.SCROLL"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookSelectCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookSelectCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.SELECT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookTabSplitCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookTabSplitCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.TAB.SPLIT"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkbookUnhideCommandFunctionNode : CommandFunctionNode
    {
        public WorkbookUnhideCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKBOOK.UNHIDE"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkgroupCommandFunctionNode : CommandFunctionNode
    {
        public WorkgroupCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WORKGROUP"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WorkgroupOptionsCommandFunctionNode : CommandFunctionNode
    {
        public WorkgroupOptionsCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKGROUP.OPTIONS"),
                questionMark,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class WorkspaceCommandFunctionNode : CommandFunctionNode
    {
        public WorkspaceCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WORKSPACE"), questionMark, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ZoomCommandFunctionNode : CommandFunctionNode
    {
        public ZoomCommandFunctionNode(
            string? rawName = null, QuestionMarkNode? questionMark = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ZOOM"), questionMark, leadingWhitespace, trailingWhitespace) { }
    }
}
