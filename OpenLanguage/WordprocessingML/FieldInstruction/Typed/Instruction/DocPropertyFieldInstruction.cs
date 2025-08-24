using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed DOCPROPERTY field instruction.
    /// Retrieves the indicated document information. For some combinations of `DOCPROPERTY` and docprop-category, there is an equivalent field, in which case, the description for the combination can be obtained from that field. For those combinations not having an equivalent field, the description is shown directly. When used directly, some of the equivalent fields allow the value of the designated property to be changed. However, when the corresponding `DOCPROPERTY` field is used, such values shall not be changed. This is indicated in the following table by "Read-only operation." Docprop-category Corresponding Field Description AUTHOR AUTHOR ([AUTHOR](AUTHOR.md)) Read-only operation. BYTES FILESIZE ([FILESIZE](FILESIZE.md)) CATEGORY #### `No equivalent` The contents of the `<Category>` element of the Core File Properties part. CHARACTERS NUMCHARS ([NUMCHARS](NUMCHARS.md)) CHARACTERSWITHSPACES #### `No equivalent` Like `NUMCHARS`, but includes all white space characters as well. COMMENTS COMMENTS ([BIBLIOGRAPHYBIBLIOGR](BIBLIOGRAPHYBIBLIOGR.md)) Read-only operation. COMPANY #### `No equivalent` The contents of the `<Company>` element of the Application-Defined File Properties part. CREATETIME CREATEDATE ([CREATEDATE](CREATEDATE.md)) HYPERLINKBASE #### `No equivalent` The contents of the `<HyperlinkBase>` element of the Application-Defined File Properties part. KEYWORDS #### `No equivalent` The contents of the `<Keywords>` element of the Core File Properties part. LASTPRINTED PRINTDATE ([PRINTDATE](PRINTDATE.md)) LASTSAVEDBY LASTSAVEDBY ([LASTSAVEDBYLASTSAVED](LASTSAVEDBYLASTSAVED.md)) LASTSAVEDTIME SAVEDATE ([SAVEDATE](SAVEDATE.md)) LINES #### `No equivalent` The contents of the `<Lines>` element of the Application-Defined File Properties part. MANAGER #### `No equivalent` The contents of the `<Manager>` element of the Application-Defined File Properties part. NAMEOFAPPLICATION #### `No equivalent` The contents of the `<Application>` element of the Application-Defined File Properties part. ODMADOCID PAGES NUMPAGES ([NUMPAGES](NUMPAGES.md)) PARAGRAPHS #### `No equivalent` The contents of the `<Paragraphs>` element of the Application-Defined File Properties part. REVISIONNUMBER REVNUM ([REVNUM](REVNUM.md)) SECURITY #### `No equivalent` The contents of the `<DocSecurity>` element of the Application-Defined File Properties part. SUBJECT SUBJECT ([SUBJECT](SUBJECT.md)) Read-only operation. TEMPLATE TEMPLATE ([TEMPLATE](TEMPLATE.md)) TITLE TITLE ([TITLE](TITLE.md)) Read-only operation. TOTALEDITINGTIME EDITTIME ([EDITTIME](EDITTIME.md)) WORDS #### `No equivalent` The contents of the `<Words>` element of the Application-Defined File Properties part.
    /// </summary>
    public class DocPropertyFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The document property name to retrieve
        /// </summary>
        public string? PropertyName { get; set; }

        /// <summary>
        /// Optional field argument for the property (used with some categories)
        /// </summary>
        public string? PropertyCategoryArgument { get; set; }

        /// <summary>
        /// Initializes a new instance of the DocPropertyFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public DocPropertyFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "DOCPROPERTY")
            {
                throw new ArgumentException(
                    $"Expected DOCPROPERTY field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (property name)
            List<FieldArgument> nonSwitchArgs = Source
                .Arguments.Where(arg => arg.Type != FieldArgumentType.Switch)
                .ToList();

            if (nonSwitchArgs.Count > 0)
            {
                PropertyName = nonSwitchArgs[0].Value?.ToString();
            }

            if (nonSwitchArgs.Count > 1)
            {
                PropertyCategoryArgument = nonSwitchArgs[1].Value?.ToString();
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { Source.Instruction };

            if (!string.IsNullOrWhiteSpace(PropertyName))
            {
                result.Add(
                    PropertyName.Contains(" ") && !PropertyName.StartsWith("\"")
                        ? $"\"{PropertyName}\""
                        : PropertyName
                );
            }

            if (!string.IsNullOrWhiteSpace(PropertyCategoryArgument))
            {
                result.Add(
                    PropertyCategoryArgument.Contains(" ")
                    && !PropertyCategoryArgument.StartsWith("\"")
                        ? $"\"{PropertyCategoryArgument}\""
                        : PropertyCategoryArgument
                );
            }

            return string.Join(" ", result);
        }
    }
}
