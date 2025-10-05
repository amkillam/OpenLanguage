using System.Collections.Generic;
using System.Linq;
using OpenLanguage.WordprocessingML.Ast;

namespace OpenLanguage.WordprocessingML.FieldInstruction.Ast
{
    public enum AddressBlockArgument
    {
        CountryRegionInclusionSetting,
        FormatByRecipientCountry,
        ExcludedCountriesRegions,
        FormatTemplate,
        LanguageId,
    }

    /// <summary>
    /// Represents a strongly-typed ADDRESSBLOCK field instruction.
    /// The ADDRESSBLOCK field inserts a mail merge address block.
    /// </summary>
    public class AddressBlockFieldInstruction : Ast.FieldInstruction
    {
        public List<AddressBlockArgument> Order { get; set; } = new List<AddressBlockArgument>();

        /// <summary>
        /// Switch: \c field-argument
        /// Specifies whether to include the country/region in the address block.
        /// 0 omits the country/region.
        /// 1 includes the country/region.
        /// 2 includes the country/region only if it is different from the value for the \e switch.
        /// </summary>
        public FlaggedArgument<ExpressionNode>? CountryRegionInclusionSetting { get; set; }

        /// <summary>
        /// Switch: \d
        /// Gets or sets whether the address should be formatted according to the recipient's country/region.
        /// If false or null, addresses are formatted according to implementation-specific preference.
        /// </summary>
        public OpenLanguage.WordprocessingML.Ast.BoolFlagNode? FormatByRecipientCountry { get; set; }

        /// <summary>
        /// Switch: \e field-argument
        /// Gets the list of countries/regions to exclude from the address block.
        /// Multiple exclusions are supported by using the switch multiple times.
        /// </summary>
        public List<FlaggedArgument<ExpressionNode>> ExcludedCountriesRegions { get; }

        /// <summary>
        /// Switch: \f field-argument
        /// Specifies the name and address format using a template of merge-field placeholders.
        /// The placeholders are:
        /// <<_TITLE0_>> or /t0: Courtesy Title
        /// <<_NICK0_>> or /n0: Nickname
        /// <<_FIRST0_>> or /f0: First Name
        /// <<_MIDDLE0_>> or /m0: Middle Name
        /// <<_LAST0_>> or /l0: Last Name
        /// <<_SUFFIX0_>> or /s0: Suffix
        /// <<_TITLE1_>> or /t1: Spouse/Partner Courtesy Title
        /// <<_NICK1_>> or /n1: Spouse/Partner Nickname (mapped to empty string in Word)
        /// <<_FIRST1_>> or /f1: Spouse/Partner First Name
        /// <<_MIDDLE1_>> or /m1: Spouse/Partner Middle Name
        /// <<_LAST1_>> or /l1: Spouse/Partner Last Name
        /// <<_SUFFIX1_>> or /s1: Spouse/Partner Suffix (mapped to Spouse/Partner Nickname in Word)
        /// <<_COMPANY_>> or /c: Company
        /// <<_STREET1_>> or /r: Address 1
        /// <<_STREET2_>> or /e: Address 2
        /// <<_CITY_>> or /i: City
        /// <<_STATE_>> or /a: State
        /// <<_POSTAL_>> or /z: Postal Code
        /// <<_COUNTRY_>> or /d: Country or Region
        /// </summary>
        public FlaggedArgument<ExpressionNode>? FormatTemplate { get; set; }

        /// <summary>
        /// Switch: \l field-argument
        /// Gets or sets the language ID used to format the address.
        /// If null, uses the language ID of the first character of the document.
        /// The argument is a language code value from ST_LangCode (e.g., "en-US").
        /// </summary>
        public FlaggedArgument<ExpressionNode>? LanguageId { get; set; }

        public AddressBlockFieldInstruction(
            StringLiteralNode instruction,
            FlaggedArgument<ExpressionNode>? countryRegionInclusionSetting,
            OpenLanguage.WordprocessingML.Ast.BoolFlagNode? formatByRecipientCountry,
            List<FlaggedArgument<ExpressionNode>>? excludedCountriesRegions,
            FlaggedArgument<ExpressionNode>? formatTemplate,
            FlaggedArgument<ExpressionNode>? languageId,
            List<AddressBlockArgument> order,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(instruction, leadingWhitespace, trailingWhitespace)
        {
            CountryRegionInclusionSetting = countryRegionInclusionSetting;
            FormatByRecipientCountry = formatByRecipientCountry;
            ExcludedCountriesRegions =
                excludedCountriesRegions ?? new List<FlaggedArgument<ExpressionNode>>();
            FormatTemplate = formatTemplate;
            LanguageId = languageId;
            Order = order;
        }

        public override string ToRawString() =>
            Instruction.ToString()
            + string.Concat(
                Order.Select(
                    (AddressBlockArgument a) =>
                        a switch
                        {
                            AddressBlockArgument.CountryRegionInclusionSetting =>
                                CountryRegionInclusionSetting?.ToString() ?? string.Empty,
                            AddressBlockArgument.FormatByRecipientCountry =>
                                FormatByRecipientCountry?.ToString() ?? string.Empty,
                            AddressBlockArgument.ExcludedCountriesRegions => string.Concat(
                                ExcludedCountriesRegions.Select(er => er.ToString())
                            ),
                            AddressBlockArgument.FormatTemplate => FormatTemplate?.ToString()
                                ?? string.Empty,
                            AddressBlockArgument.LanguageId => LanguageId?.ToString()
                                ?? string.Empty,
                            _ => string.Empty,
                        }
                )
            );

        public override IEnumerable<O> Children<O>()
        {
            if (Instruction is O o1)
            {
                yield return o1;
            }
            foreach (AddressBlockArgument arg in Order)
            {
                switch (arg)
                {
                    case AddressBlockArgument.CountryRegionInclusionSetting:
                        if (CountryRegionInclusionSetting is O crin)
                        {
                            yield return crin;
                        }
                        break;

                    case AddressBlockArgument.FormatByRecipientCountry:
                        if (FormatByRecipientCountry is O fbcr)
                        {
                            yield return fbcr;
                        }
                        break;

                    case AddressBlockArgument.ExcludedCountriesRegions:
                        foreach (FlaggedArgument<ExpressionNode> ex in ExcludedCountriesRegions)
                        {
                            if (ex is O exr)
                            {
                                yield return exr;
                            }
                        }
                        break;

                    case AddressBlockArgument.FormatTemplate:
                        if (FormatTemplate is O ftn)
                        {
                            yield return ftn;
                        }
                        break;

                    case AddressBlockArgument.LanguageId:
                        if (LanguageId is O lin)
                        {
                            yield return lin;
                        }
                        break;
                }
            }
        }

        public override Node? ReplaceChild(int index, Node? replacement)
        {
            Node? current = null;

            int currentIndex = 0;

            if (index == 0 && replacement is StringLiteralNode bon)
            {
                current = Instruction;
                Instruction = bon;
            }
            else
            {
                index--;
                if (index >= 0 && index < Order.Count + ExcludedCountriesRegions.Count - 1)
                {
                    foreach (AddressBlockArgument argument in Order)
                    {
                        switch (argument)
                        {
                            case AddressBlockArgument.CountryRegionInclusionSetting:
                                if (CountryRegionInclusionSetting != null)
                                {
                                    if (currentIndex == index)
                                    {
                                        if (replacement is FlaggedArgument<ExpressionNode> crin)
                                        {
                                            current = CountryRegionInclusionSetting;
                                            CountryRegionInclusionSetting = crin;
                                        }
                                        return current;
                                    }
                                    currentIndex++;
                                }
                                break;
                            case AddressBlockArgument.FormatByRecipientCountry:
                                if (FormatByRecipientCountry != null)
                                {
                                    if (currentIndex == index)
                                    {
                                        if (
                                            replacement
                                            is OpenLanguage.WordprocessingML.Ast.BoolFlagNode fbcr
                                        )
                                        {
                                            current = FormatByRecipientCountry;
                                            FormatByRecipientCountry = fbcr;
                                        }
                                        return current;
                                    }
                                    currentIndex++;
                                }
                                break;
                            case AddressBlockArgument.ExcludedCountriesRegions:
                                for (
                                    int exIndex = 0;
                                    exIndex < ExcludedCountriesRegions.Count;
                                    exIndex++
                                )
                                {
                                    FlaggedArgument<ExpressionNode> excludedCountryRegion =
                                        ExcludedCountriesRegions[exIndex];
                                    if (excludedCountryRegion != null)
                                    {
                                        if (currentIndex == index)
                                        {
                                            if (
                                                replacement
                                                is FlaggedArgument<ExpressionNode> newExcluded
                                            )
                                            {
                                                current = excludedCountryRegion;
                                                ExcludedCountriesRegions[exIndex] = newExcluded;
                                            }
                                            return current;
                                        }
                                        currentIndex++;
                                    }
                                }
                                break;
                            case AddressBlockArgument.FormatTemplate:
                                if (FormatTemplate != null)
                                {
                                    if (currentIndex == index)
                                    {
                                        if (replacement is FlaggedArgument<ExpressionNode> ftn)
                                        {
                                            current = FormatTemplate;
                                            FormatTemplate = ftn;
                                        }
                                        return current;
                                    }
                                    currentIndex++;
                                }
                                break;
                            case AddressBlockArgument.LanguageId:
                                if (LanguageId != null)
                                {
                                    if (currentIndex == index)
                                    {
                                        if (replacement is FlaggedArgument<ExpressionNode> lin)
                                        {
                                            current = LanguageId;
                                            LanguageId = lin;
                                        }
                                        return current;
                                    }
                                    currentIndex++;
                                }
                                break;
                        }
                    }
                }
            }
            return current;
        }
    }
}
