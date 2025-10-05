using System;

namespace OpenLanguage.WordprocessingML.ProgrammaticIdentifier
{
    public enum Application
    {
        Access,
        Excel,
        Forms,
        InfoPath,
        InternetExplorer,
        MSGraph,
        MSProject,
        OneNote,
        Outlook,
        OWC,
        PowerPoint,
        Publisher,
        Visio,
        Word,
    }

    public static class ApplicationExtensions
    {
        public static Application? TryParse(string value)
        {
            return value.ToLower() switch
            {
                "access" => Application.Access,
                "excel" => Application.Excel,
                "forms" => Application.Forms,
                "infopath" => Application.InfoPath,
                "internetexplorer" => Application.InternetExplorer,
                "msgraph" => Application.MSGraph,
                "msproject" => Application.MSProject,
                "onenote" => Application.OneNote,
                "outlook" => Application.Outlook,
                "owc" => Application.OWC,
                "powerpoint" => Application.PowerPoint,
                "publisher" => Application.Publisher,
                "visio" => Application.Visio,
                "word" => Application.Word,
                _ => null,
            };
        }

        public static Application Parse(string value)
        {
            Application? app = TryParse(value);
            if (app == null)
            {
                throw new ArgumentException($"Invalid application name: {value}");
            }
            return app.Value;
        }

        public static string ToString(this Application app)
        {
            return app switch
            {
                Application.Access => "Access",
                Application.Excel => "Excel",
                Application.Forms => "Forms",
                Application.InfoPath => "InfoPath",
                Application.InternetExplorer => "InternetExplorer",
                Application.MSGraph => "MSGraph",
                Application.MSProject => "MSProject",
                Application.OneNote => "OneNote",
                Application.Outlook => "Outlook",
                Application.OWC => "OWC",
                Application.PowerPoint => "PowerPoint",
                Application.Publisher => "Publisher",
                Application.Visio => "Visio",
                Application.Word => "Word",
                _ => throw new ArgumentOutOfRangeException(
                    nameof(app),
                    $"Not expected application value: {app}"
                ),
            };
        }
    }

    public enum Object
    {
        AddIn,
        Application,
        Chart,
        ChartSpace,
        CheckBox,
        CodeData,
        CodeProject,
        ComboBox,
        CommandButton,
        CurrentData,
        CurrentProject,
        DataSourceControl,
        DefaultWebOptions,
        Document,
        DocumentSummaryInformation,
        Envelope,
        ExpandControl,
        Form,
        Frame,
        Global,
        Graph,
        GraphFrame,
        Image,
        Label,
        ListBox,
        MailMessage,
        Mailer,
        Map,
        Module,
        MultiPage,
        Note,
        OptionButton,
        Page,
        Picture,
        PivotTable,
        RecordNavigationControl,
        ScrollBar,
        Sheet,
        Slide,
        SpinButton,
        Spreadsheet,
        Table,
        TabStrip,
        Template,
        TextBox,
        ToggleButton,
        View,
    }

    public static class ObjectExtensions
    {
        public static Object? TryParse(string value)
        {
            return value.ToLower() switch
            {
                "addin" => Object.AddIn,
                "application" => Object.Application,
                "chart" => Object.Chart,
                "chartspace" => Object.ChartSpace,
                "checkbox" => Object.CheckBox,
                "codedata" => Object.CodeData,
                "codeproject" => Object.CodeProject,
                "combobox" => Object.ComboBox,
                "commandbutton" => Object.CommandButton,
                "currentdata" => Object.CurrentData,
                "currentproject" => Object.CurrentProject,
                "datasourcecontrol" => Object.DataSourceControl,
                "defaultweboptions" => Object.DefaultWebOptions,
                "document" => Object.Document,
                "documentsummaryinformation" => Object.DocumentSummaryInformation,
                "envelope" => Object.Envelope,
                "expandcontrol" => Object.ExpandControl,
                "form" => Object.Form,
                "frame" => Object.Frame,
                "global" => Object.Global,
                "graph" => Object.Graph,
                "graphframe" => Object.GraphFrame,
                "image" => Object.Image,
                "label" => Object.Label,
                "listbox" => Object.ListBox,
                "mailmessage" => Object.MailMessage,
                "mailer" => Object.Mailer,
                "map" => Object.Map,
                "module" => Object.Module,
                "multipage" => Object.MultiPage,
                "note" => Object.Note,
                "optionbutton" => Object.OptionButton,
                "page" => Object.Page,
                "picture" => Object.Picture,
                "pivottable" => Object.PivotTable,
                "recordnavigationcontrol" => Object.RecordNavigationControl,
                "scrollbar" => Object.ScrollBar,
                "sheet" => Object.Sheet,
                "slide" => Object.Slide,
                "spinbutton" => Object.SpinButton,
                "spreadsheet" => Object.Spreadsheet,
                "table" => Object.Table,
                "tabstrip" => Object.TabStrip,
                "template" => Object.Template,
                "textbox" => Object.TextBox,
                "togglebutton" => Object.ToggleButton,
                "view" => Object.View,
                _ => null,
            };
        }

        public static Object Parse(string value)
        {
            Object? obj = TryParse(value);
            if (obj == null)
            {
                throw new ArgumentException($"Invalid object name: {value}");
            }
            return obj.Value;
        }

        public static string ToString(this Object obj)
        {
            return obj switch
            {
                Object.AddIn => "AddIn",
                Object.Application => "Application",
                Object.Chart => "Chart",
                Object.ChartSpace => "ChartSpace",
                Object.CheckBox => "CheckBox",
                Object.CodeData => "CodeData",
                Object.CodeProject => "CodeProject",
                Object.ComboBox => "ComboBox",
                Object.CommandButton => "CommandButton",
                Object.CurrentData => "CurrentData",
                Object.CurrentProject => "CurrentProject",
                Object.DataSourceControl => "DataSourceControl",
                Object.DefaultWebOptions => "DefaultWebOptions",
                Object.Document => "Document",
                Object.DocumentSummaryInformation => "DocumentSummaryInformation",
                Object.Envelope => "Envelope",
                Object.ExpandControl => "ExpandControl",
                Object.Form => "Form",
                Object.Frame => "Frame",
                Object.Global => "Global",
                Object.Graph => "Graph",
                Object.GraphFrame => "GraphFrame",
                Object.Image => "Image",
                Object.Label => "Label",
                Object.ListBox => "ListBox",
                Object.MailMessage => "MailMessage",
                Object.Mailer => "Mailer",
                Object.Map => "Map",
                Object.Module => "Module",
                Object.MultiPage => "MultiPage",
                Object.Note => "Note",
                Object.OptionButton => "OptionButton",
                Object.Page => "Page",
                Object.Picture => "Picture",
                Object.PivotTable => "PivotTable",
                Object.RecordNavigationControl => "RecordNavigationControl",
                Object.ScrollBar => "ScrollBar",
                Object.Sheet => "Sheet",
                Object.Slide => "Slide",
                Object.SpinButton => "SpinButton",
                Object.Spreadsheet => "Spreadsheet",
                Object.Table => "Table",
                Object.TabStrip => "TabStrip",
                Object.Template => "Template",
                Object.TextBox => "TextBox",
                Object.ToggleButton => "ToggleButton",
                Object.View => "View",
                _ => throw new ArgumentOutOfRangeException(
                    nameof(obj),
                    $"Not expected object value: {obj}"
                ),
            };
        }
    }

    /// <summary>
    /// Programmatic identifier (ProgID) for a specified OLE object.
    /// See [relevant VBA documentation](https://learn.microsoft.com/en-us/office/vba/project/concepts/ole-programmatic-identifiers-late-binding-and-early-binding-project).
    public class ProgrammaticIdentifier
    {
        // The `Excel` part of e.g. `Excel.Sheet.12`
        public Application Application { get; set; }

        // The `Sheet` part of e.g. `Excel.Sheet.12`
        public Object Object { get; set; }

        // The `12` part of e.g. `Excel.Sheet.12`
        // Optional; may be null or omitted. Uses latest version if not specified.
        // Last period is omitted if version is not specified - e.g. `Excel.Sheet` instead of `Excel.Sheet.`
        public byte? Version { get; set; }

        public ProgrammaticIdentifier(Application application, Object obj, byte? version = null)
        {
            Application = application;
            Object = obj;
            Version = version;
        }

        public override string ToString() =>
            $"{Application.ToString()}.{Object.ToString()}{(Version == null ? string.Empty : $".{Version.ToString()}")}";

        public ProgrammaticIdentifier? TryParse(string? value = null)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                string[] parts = value.Split('.');
                if (parts.Length == 2 || parts.Length == 3)
                {
                    Application? app = ApplicationExtensions.TryParse(parts[0]);
                    Object? obj = ObjectExtensions.TryParse(parts[1]);
                    byte? version = null;

                    if (app != null && obj != null)
                    {
                        if (parts.Length == 3)
                        {
                            if (byte.TryParse(parts[2], out byte ver))
                            {
                                version = ver;
                                return new ProgrammaticIdentifier(app.Value, obj.Value, version);
                            }
                        }
                        else
                        {
                            return new ProgrammaticIdentifier(app.Value, obj.Value, version);
                        }
                    }
                }
            }
            return null;
        }

        public ProgrammaticIdentifier Parse(string? value = null)
        {
            ProgrammaticIdentifier? pid = TryParse(value);
            if (pid == null)
            {
                throw new ArgumentException($"Invalid programmatic identifier: {value}");
            }
            return pid;
        }
    }
}
