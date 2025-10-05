using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace OpenLanguage
{
    public static class FilesystemUtils
    {
        public static IEnumerable<string> FilePaths(string rootPath)
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

        public static IEnumerable<string> FilePaths(string rootPath, string searchPattern)
        {
            if (!Directory.Exists(rootPath))
            {
                yield break;
            }
            foreach (
                string filePath in Directory.EnumerateFiles(
                    rootPath,
                    searchPattern,
                    SearchOption.AllDirectories
                )
            )
            {
                yield return filePath;
            }
        }

        public static IEnumerable<Stream> FileStreams(string rootPath)
        {
            foreach (string filePath in FilePaths(rootPath))
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    yield return stream;
                }
            }

            yield break;
        }

        public static IEnumerable<Stream> FileStreams(string rootPath, string searchPattern)
        {
            foreach (string filePath in FilePaths(rootPath, searchPattern))
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    yield return stream;
                }
            }

            yield break;
        }

        public static IEnumerable<Stream> FileStreams(string rootPath, Regex searchPattern)
        {
            foreach (string filePath in FilePaths(rootPath).Where(fp => searchPattern.IsMatch(fp)))
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    yield return stream;
                }
            }

            yield break;
        }

        public static IEnumerable<Stream> FileStreams(Regex searchPattern)
        {
            foreach (string filePath in FilePaths("./").Where(fp => searchPattern.IsMatch(fp)))
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    yield return stream;
                }
            }

            yield break;
        }

        public static IEnumerable<Stream> EmbeddedFileStreams(string rootNamespace)
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                if (resourceName.StartsWith(rootNamespace))
                {
                    using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (stream != null)
                        {
                            yield return stream;
                        }
                    }
                }
            }

            yield break;
        }

        public static IEnumerable<Stream> EmbeddedFileStreams(Regex pattern)
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                if (pattern.IsMatch(resourceName))
                {
                    using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (stream != null)
                        {
                            yield return stream;
                        }
                    }
                }
            }

            yield break;
        }

        public static IEnumerable<Stream> EmbeddedFileStreams()
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        yield return stream;
                    }
                }
            }

            yield break;
        }

        public static IEnumerable<string> Lines(this FileInfo file)
        {
            using (Stream fileStream = file.OpenRead())
            {
                using (
                    StreamReader reader = new(
                        fileStream,
                        System.Text.Encoding.UTF8,
                        false,
                        8192,
                        false
                    )
                )
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }

            yield break;
        }

        public static IEnumerable<string> Lines(this Stream stream)
        {
            using (StreamReader reader = new(stream, System.Text.Encoding.UTF8, false, 8192, false))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }

            yield break;
        }
    }
}
