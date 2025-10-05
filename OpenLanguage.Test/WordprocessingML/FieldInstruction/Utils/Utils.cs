using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Tests
{
    public static class FieldInstructionUtils
    {
        public static IEnumerable<string> DatasetFieldInstructions() =>
            FilesystemUtils
                .FileStreams(new Regex("^./data/WordprocessingML/FieldInstruction/.*\\.txt$"))
                .SelectMany((Stream s) => s.Lines())
                .Where((string line) => !string.IsNullOrWhiteSpace(line) && line.Length > 0)
                .Distinct()
                .OrderBy(line => line, System.StringComparer.Ordinal);
    }
}
