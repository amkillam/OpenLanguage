using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Tests
{
    public static class FieldInstructionUtils
    {
        public static IEnumerable<string> DatasetFieldInstructions()
        {
            ImmutableSortedSet<string> seen = ImmutableSortedSet.CreateRange<string>(
                System.StringComparer.Ordinal,
                FilesystemUtils
                    .FileStreams(new Regex("^./data/WordprocessingML/FieldInstruction/.*\\.txt$"))
                    .SelectMany((Stream s) => s.Lines())
                    .Where((string line) => !string.IsNullOrWhiteSpace(line) && line.Length > 0)
            );

            foreach (string fieldInstr in seen)
            {
                yield return fieldInstr;
            }

            yield break;
        }
    }
}
