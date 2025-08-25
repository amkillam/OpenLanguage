using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Typed
{
    /// <summary>
    /// Represents a strongly-typed BARCODE field instruction.
    /// Produces a U.S. Postal Service barcode in POSTNET or FIM format.
    /// </summary>
    public class BarcodeFieldInstruction : TypedFieldInstruction
    {
        /// <summary>
        /// The postal address or bookmark name for the barcode.
        /// For postal addresses, only 5-digit or 9-digit ZIP code is needed.
        /// </summary>
        public string BarcodeData { get; set; } = string.Empty;

        /// <summary>
        /// Switch: \b
        /// Indicates that the field argument is a bookmark name.
        /// </summary>
        public bool IsBookmarkReference { get; set; }

        /// <summary>
        /// Switch: \f field-argument
        /// Inserts a Facing Identification Mark (FIM).
        /// </summary>
        public FacingIdentificationMarkType? FacingIdentificationMark { get; set; }

        /// <summary>
        /// Switch: \u
        /// Indicates that the field argument is a postal address.
        /// </summary>
        public bool IsPostalAddress { get; set; }

        /// <summary>
        /// Initializes a new instance of the BarcodeFieldInstruction class.
        /// </summary>
        /// <param name="source">The source FieldInstruction to parse.</param>
        public BarcodeFieldInstruction(FieldInstruction source)
            : base(source)
        {
            ParseArguments();
        }

        /// <summary>
        /// Gets the next argument after the specified switch index.
        /// </summary>
        private string GetNextArgumentAfter(int switchIndex)
        {
            if (switchIndex + 1 < Source.Arguments.Count)
            {
                FieldArgument nextArg = Source.Arguments[switchIndex + 1];
                if (nextArg.Type != FieldArgumentType.Switch)
                {
                    return nextArg.Value?.ToString() ?? "";
                }
            }
            return "";
        }

        /// <summary>
        /// Parses a Facing Identification Mark type from text.
        /// </summary>
        private FacingIdentificationMarkType? ParseFacingIdentificationMark(string fimText)
        {
            if (string.IsNullOrWhiteSpace(fimText))
            {
                return null;
            }

            return fimText.Trim().ToUpperInvariant() switch
            {
                "A" => FacingIdentificationMarkType.CourtesyReply,
                "C" => FacingIdentificationMarkType.BusinessReply,
                _ => null,
            };
        }

        /// <summary>
        /// Parses the arguments from the source FieldInstruction.
        /// </summary>
        private void ParseArguments()
        {
            if (Source.Instruction.ToUpperInvariant() != "BARCODE")
            {
                throw new ArgumentException(
                    $"Expected BARCODE field, but got {Source.Instruction}"
                );
            }

            // Parse primary field argument (postal data - required)
            FieldArgument? firstNonSwitch = Source.Arguments.FirstOrDefault(arg =>
                arg.Type == FieldArgumentType.Identifier
                || arg.Type == FieldArgumentType.StringLiteral
            );

            BarcodeData = firstNonSwitch?.Value?.ToString() ?? string.Empty;

            // Parse switches
            for (int i = 0; i < Source.Arguments.Count; i++)
            {
                FieldArgument arg = Source.Arguments[i];
                if (arg.Type == FieldArgumentType.Switch)
                {
                    string switchValue = arg.Value?.ToString() ?? string.Empty;
                    switch (switchValue.ToLowerInvariant())
                    {
                        case "\\b":
                            IsBookmarkReference = true;
                            break;
                        case "\\f":
                            FacingIdentificationMark = ParseFacingIdentificationMark(
                                GetNextArgumentAfter(i)
                            );
                            break;
                        case "\\u":
                            IsPostalAddress = true;
                            break;
                    }
                }
            }

            // Validate switch combinations
            if (IsBookmarkReference && IsPostalAddress)
            {
                throw new ArgumentException(
                    "BARCODE field cannot have both \\b (bookmark) and \\u (postal address) switches"
                );
            }
        }

        /// <summary>
        /// Reconstructs the field instruction as a string.
        /// </summary>
        /// <returns>The field instruction string.</returns>
        public override string ToString()
        {
            List<string> result = new List<string> { "BARCODE" };

            // Handle postal data vs bookmark data
            if (!string.IsNullOrEmpty(BarcodeData))
            {
                if (IsPostalAddress && !IsBookmarkReference)
                {
                    // Validate as postal data
                    try
                    {
                        PostalData postalData = new PostalData(BarcodeData);
                        result.Add(postalData.ToString());
                    }
                    catch (ArgumentException)
                    {
                        // If validation fails, add as regular string
                        result.Add(BarcodeData.Contains(" ") ? $"\"{BarcodeData}\"" : BarcodeData);
                    }
                }
                else
                {
                    result.Add(BarcodeData.Contains(" ") ? $"\"{BarcodeData}\"" : BarcodeData);
                }
            }

            if (IsBookmarkReference)
            {
                result.Add("\\b");
            }

            if (FacingIdentificationMark.HasValue)
            {
                result.Add("\\f");
                string fimValue = FacingIdentificationMark.Value switch
                {
                    FacingIdentificationMarkType.CourtesyReply => "A",
                    FacingIdentificationMarkType.BusinessReply => "C",
                    _ => "",
                };
                result.Add(fimValue);
            }

            if (IsPostalAddress)
            {
                result.Add("\\u");
            }

            return string.Join(" ", result);
        }
    }
}
