using System.Collections.Generic;
using System.IO;

namespace OpenLanguage
{
    public static class FilesystemUtils
    {
        public static IEnumerable<string> RecurseFilePaths(string rootPath)
        {
            if (!Directory.Exists(rootPath))
            {
                yield break;
            }
            foreach (
                string filePath in Directory.EnumerateFiles(
                    rootPath,
                    "*",
                    SearchOption.AllDirectories
                )
            )
            {
                yield return filePath;
            }
        }

        public static IEnumerable<string> Lines(this FileInfo file)
        {
            using StreamReader reader = new(file.FullName);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }

            yield break;
        }
    }
}
