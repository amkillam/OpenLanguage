using System.Collections.Generic;
using System.IO;

namespace OpenLanguage.SpreadsheetML.Formula.Tests
{
    public static class FormulaUtils
    {
        public static IEnumerable<string> DatasetFormulae()
        {
            foreach (
                string formulaDatasetPath in FilesystemUtils.RecurseFilePaths(
                    "data/SpreadsheetML/Formula"
                )
            )
            {
                if (Path.GetExtension(formulaDatasetPath).ToLower() == ".txt")
                {
                    FileInfo fileInfo = new(formulaDatasetPath);
                    foreach (string line in fileInfo.Lines())
                    {
                        yield return line;
                    }
                }
            }

            yield break;
        }
    }
}
