using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenLanguage.SpreadsheetML.Formula.Tests
{
    public static class FormulaUtils
    {
        public static IEnumerable<string> DatasetFormulae() =>
            FilesystemUtils
                .FileStreams(new Regex("^./data/SpreadsheetML/Formula/.*\\.txt$"))
                .SelectMany((Stream s) => s.Lines())
                .Where((string line) => !string.IsNullOrWhiteSpace(line) && line.Length > 0)
                .Distinct()
                .OrderBy(line => line, System.StringComparer.Ordinal);
    }
}
