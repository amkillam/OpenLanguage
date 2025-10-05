progid_object:
    T_PROGID_OBJECT_ADDIN { $$ = ProgrammaticIdentifier.Object.AddIn; }
  | T_PROGID_OBJECT_APPLICATION { $$ = ProgrammaticIdentifier.Object.Application; }
  | T_PROGID_OBJECT_CHART { $$ = ProgrammaticIdentifier.Object.Chart; }
  | T_PROGID_OBJECT_CHARTSPACE { $$ = ProgrammaticIdentifier.Object.ChartSpace; }
  | T_PROGID_OBJECT_CHECKBOX { $$ = ProgrammaticIdentifier.Object.CheckBox; }
  | T_PROGID_OBJECT_CODEDATA { $$ = ProgrammaticIdentifier.Object.CodeData; }
  | T_PROGID_OBJECT_CODEPROJECT { $$ = ProgrammaticIdentifier.Object.CodeProject; }
  | T_PROGID_OBJECT_COMBOBOX { $$ = ProgrammaticIdentifier.Object.ComboBox; }
  | T_PROGID_OBJECT_COMMANDBUTTON { $$ = ProgrammaticIdentifier.Object.CommandButton; }
  | T_PROGID_OBJECT_CURRENTDATA { $$ = ProgrammaticIdentifier.Object.CurrentData; }
  | T_PROGID_OBJECT_CURRENTPROJECT { $$ = ProgrammaticIdentifier.Object.CurrentProject; }
  | T_PROGID_OBJECT_DATASOURCECONTROL { $$ = ProgrammaticIdentifier.Object.DataSourceControl; }
  | T_PROGID_OBJECT_DEFAULTWEBOPTIONS { $$ = ProgrammaticIdentifier.Object.DefaultWebOptions; }
  | T_PROGID_OBJECT_DOCUMENT { $$ = ProgrammaticIdentifier.Object.Document; }
  | T_PROGID_OBJECT_DOCUMENTSUMMARYINFORMATION { $$ = ProgrammaticIdentifier.Object.DocumentSummaryInformation; }
  | T_PROGID_OBJECT_ENVELOPE { $$ = ProgrammaticIdentifier.Object.Envelope; }
  | T_PROGID_OBJECT_EXPANDCONTROL { $$ = ProgrammaticIdentifier.Object.ExpandControl; }
  | T_PROGID_OBJECT_FORM { $$ = ProgrammaticIdentifier.Object.Form; }
  | T_PROGID_OBJECT_FRAME { $$ = ProgrammaticIdentifier.Object.Frame; }
  | T_PROGID_OBJECT_GLOBAL { $$ = ProgrammaticIdentifier.Object.Global; }
  | T_PROGID_OBJECT_GRAPH { $$ = ProgrammaticIdentifier.Object.Graph; }
  | T_PROGID_OBJECT_GRAPHFRAME { $$ = ProgrammaticIdentifier.Object.GraphFrame; }
  | T_PROGID_OBJECT_IMAGE { $$ = ProgrammaticIdentifier.Object.Image; }
  | T_PROGID_OBJECT_LABEL { $$ = ProgrammaticIdentifier.Object.Label; }
  | T_PROGID_OBJECT_LISTBOX { $$ = ProgrammaticIdentifier.Object.ListBox; }
  | T_PROGID_OBJECT_MAILER { $$ = ProgrammaticIdentifier.Object.Mailer; }
  | T_PROGID_OBJECT_MAILMESSAGE { $$ = ProgrammaticIdentifier.Object.MailMessage; }
  | T_PROGID_OBJECT_MAP { $$ = ProgrammaticIdentifier.Object.Map; }
  | T_PROGID_OBJECT_MODULE { $$ = ProgrammaticIdentifier.Object.Module; }
  | T_PROGID_OBJECT_MULTIPAGE { $$ = ProgrammaticIdentifier.Object.MultiPage; }
  | T_PROGID_OBJECT_NOTE { $$ = ProgrammaticIdentifier.Object.Note; }
  | T_PROGID_OBJECT_OPTIONBUTTON { $$ = ProgrammaticIdentifier.Object.OptionButton; }
  | T_PAGE { $$ = ProgrammaticIdentifier.Object.Page; }
  | T_PROGID_OBJECT_PICTURE { $$ = ProgrammaticIdentifier.Object.Picture; }
  | T_PROGID_OBJECT_PIVOTTABLE { $$ = ProgrammaticIdentifier.Object.PivotTable; }
  | T_PROGID_OBJECT_RECORDNAVIGATIONCONTROL { $$ = ProgrammaticIdentifier.Object.RecordNavigationControl; }
  | T_PROGID_OBJECT_SCROLLBAR { $$ = ProgrammaticIdentifier.Object.ScrollBar; }
  | T_PROGID_OBJECT_SHEET { $$ = ProgrammaticIdentifier.Object.Sheet; }
  | T_PROGID_OBJECT_SLIDE { $$ = ProgrammaticIdentifier.Object.Slide; }
  | T_PROGID_OBJECT_SPINBUTTON { $$ = ProgrammaticIdentifier.Object.SpinButton; }
  | T_PROGID_OBJECT_SPREADSHEET { $$ = ProgrammaticIdentifier.Object.Spreadsheet; }
  | T_PROGID_OBJECT_TABLE { $$ = ProgrammaticIdentifier.Object.Table; }
  | T_PROGID_OBJECT_TABSTRIP { $$ = ProgrammaticIdentifier.Object.TabStrip; }
  | T_TEMPLATE_INSTRUCTION { $$ = ProgrammaticIdentifier.Object.Template; }
  | T_PROGID_OBJECT_TEXTBOX { $$ = ProgrammaticIdentifier.Object.TextBox; }
  | T_PROGID_OBJECT_TOGGLEBUTTON { $$ = ProgrammaticIdentifier.Object.ToggleButton; }
  | T_PROGID_OBJECT_VIEW { $$ = ProgrammaticIdentifier.Object.View; }
  ;

progid_application:
    T_PROGID_APPLICATION_EXCEL { $$ = ProgrammaticIdentifier.Application.Excel; }
  | T_PROGID_APPLICATION_FORMS { $$ = ProgrammaticIdentifier.Application.Forms; }
  | T_PROGID_APPLICATION_INFOPATH { $$ = ProgrammaticIdentifier.Application.InfoPath; }
  | T_PROGID_APPLICATION_INTERNETEXPLORER { $$ = ProgrammaticIdentifier.Application.InternetExplorer; }
  | T_PROGID_APPLICATION_MSGRAPH { $$ = ProgrammaticIdentifier.Application.MSGraph; }
  | T_PROGID_APPLICATION_MSPROJECT { $$ = ProgrammaticIdentifier.Application.MSProject; }
  | T_PROGID_APPLICATION_ONENOTE { $$ = ProgrammaticIdentifier.Application.OneNote; }
  | T_PROGID_APPLICATION_OUTLOOK { $$ = ProgrammaticIdentifier.Application.Outlook; }
  | T_PROGID_APPLICATION_OWC { $$ = ProgrammaticIdentifier.Application.OWC; }
  | T_PROGID_APPLICATION_POWERPOINT { $$ = ProgrammaticIdentifier.Application.PowerPoint; }
  | T_PROGID_APPLICATION_PUBLISHER { $$ = ProgrammaticIdentifier.Application.Publisher; }
  | T_PROGID_APPLICATION_VISIO { $$ = ProgrammaticIdentifier.Application.Visio; }
  | T_PROGID_APPLICATION_WORD { $$ = ProgrammaticIdentifier.Application.Word; }
  ;

progid_version:
    T_BINARY_INTEGER   { $$ = byte.Parse($1, NumberStyles.AllowBinarySpecifier | NumberStyles.BinaryNumber, System.Globalization.CultureInfo.InvariantCulture); }
  | T_HEX_INTEGER      { $$ = byte.Parse($1, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture); }
  | T_INTEGER          { $$ = byte.Parse($1, System.Globalization.CultureInfo.InvariantCulture); }
  ;

progid:
    progid whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | whitespace progid { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | quote progid quote { $$ = new Quoted<ExpressionNode>($1, $2, $3); }
  | progid_application T_PERIOD progid_object T_PERIOD progid_version { $$ = new ProgrammaticIdentifierNode(new ProgrammaticIdentifier.ProgrammaticIdentifier($1, $3, $5)); }
  | progid_application T_PERIOD progid_object { $$ = new ProgrammaticIdentifierNode(new ProgrammaticIdentifier.ProgrammaticIdentifier($1, $3)); }
  | identifier { $$ = $1; }
  ;
