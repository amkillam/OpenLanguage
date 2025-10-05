using System;
using System.Linq;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    // Parsing helpers for typed enums used by the grammar
    public static class NameFormatExtensions
    {
        public static NameFormat? TryParse(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            return s.Trim().ToLowerInvariant() switch
            {
                "firstname" or "first" => NameFormat.FirstName,
                "lastname" or "last" => NameFormat.LastName,
                "firstlastname" or "firstlast" or "first_last" or "first-last" =>
                    NameFormat.FirstLastName,
                "lastfirstname" or "lastfirst" or "last_first" or "last-first" =>
                    NameFormat.LastFirstName,
                "titlelastname" or "titlelast" or "title_last" or "title-last" =>
                    NameFormat.TitleLastName,
                "fullformalname" or "fullformal" or "full_formal" or "full-formal" =>
                    NameFormat.FullFormalName,
                _ => null,
            };
        }

        public static NameFormat Parse(string? s)
        {
            NameFormat? nf = TryParse(s);
            if (nf == null)
            {
                throw new ArgumentException($"Invalid name format: {s}");
            }

            return nf.Value;
        }
    }

    public static class DatabaseOptimizationFlagExtensions
    {
        public static DatabaseOptimizationFlag? TryParse(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            return s.Trim().ToLowerInvariant() switch
            {
                "none" => DatabaseOptimizationFlag.None,
                "queryonce" or "query_once" or "query-once" => DatabaseOptimizationFlag.QueryOnce,
                "cacheresults" or "cache_results" or "cache-results" =>
                    DatabaseOptimizationFlag.CacheResults,
                "useconnectionpooling" or "use_connection_pooling" or "use-connection-pooling" =>
                    DatabaseOptimizationFlag.UseConnectionPooling,
                "optimizeforlargedata" or "optimize_for_large_data" or "optimize-for-large-data" =>
                    DatabaseOptimizationFlag.OptimizeForLargeData,
                "optimizeforsmalldata" or "optimize_for_small_data" or "optimize-for-small-data" =>
                    DatabaseOptimizationFlag.OptimizeForSmallData,
                _ => null,
            };
        }

        public static DatabaseOptimizationFlag Parse(string? s)
        {
            DatabaseOptimizationFlag? val = TryParse(s);
            if (val == null)
            {
                throw new ArgumentException($"Invalid database optimization flag: {s}");
            }

            return val.Value;
        }
    }

    public static class FacingIdentificationMarkTypeExtensions
    {
        public static FacingIdentificationMarkType? TryParse(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            return s.Trim().ToLowerInvariant() switch
            {
                "a" or "courtesyreply" or "courtesy_reply" or "courtesy-reply" =>
                    FacingIdentificationMarkType.CourtesyReply,
                "c" or "businessreply" or "business_reply" or "business-reply" =>
                    FacingIdentificationMarkType.BusinessReply,
                _ => null,
            };
        }

        public static FacingIdentificationMarkType Parse(string? s)
        {
            FacingIdentificationMarkType? v = TryParse(s);
            if (v == null)
            {
                throw new ArgumentException($"Invalid Facing Identification Mark Type: {s}");
            }

            return v.Value;
        }
    }

    /// <summary>
    /// Represents the type of Facing Identification Mark (FIM) for BARCODE field instructions.
    /// </summary>
    public enum FacingIdentificationMarkType
    {
        /// <summary>
        /// A - Courtesy reply mark.
        /// </summary>
        CourtesyReply,

        /// <summary>
        /// C - Business reply mark.
        /// </summary>
        BusinessReply,
    }

    /// <summary>
    /// Represents country/region inclusion options for ADDRESSBLOCK field instructions.
    /// </summary>
    public enum CountryRegionInclusion
    {
        /// <summary>
        /// Omit the country/region from the address block.
        /// </summary>
        Omit = 0,

        /// <summary>
        /// Include the country/region in the address block.
        /// </summary>
        Include = 1,

        /// <summary>
        /// Include the country/region only if it is different from the excluded country/region.
        /// </summary>
        IncludeIfDifferent = 2,
    }

    public static class CountryRegionInclusionExtensions
    {
        public static CountryRegionInclusion Parse(string? s)
        {
            CountryRegionInclusion? result = TryParse(s);
            if (result.HasValue)
            {
                return result.Value;
            }
            throw new ArgumentException($"Invalid country/region inclusion: {s}");
        }

        public static CountryRegionInclusion? TryParse(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            if (int.TryParse(s.Trim(), out int intValue))
            {
                if (Enum.IsDefined(typeof(CountryRegionInclusion), intValue))
                {
                    return (CountryRegionInclusion)intValue;
                }
            }

            return s.Trim().ToLowerInvariant() switch
            {
                "omit" => CountryRegionInclusion.Omit,
                "include" => CountryRegionInclusion.Include,
                "includeifdifferent" or "include_if_different" or "include-if-different" =>
                    CountryRegionInclusion.IncludeIfDifferent,
                _ => null,
            };
        }

        public static string ToString(this CountryRegionInclusion cri)
        {
            return cri switch
            {
                CountryRegionInclusion.Include => "Include",
                CountryRegionInclusion.IncludeIfDifferent => "IncludeIfDifferent",
                _ => "Omit", // Default case
            };
        }
    }

    /// <summary>
    /// Represents ISO 3166-1 country and region codes for international addressing.
    /// </summary>
    public enum CountryRegion
    {
        /// <summary>Afghanistan - AF</summary>
        Afghanistan,

        /// <summary>Albania - AL</summary>
        Albania,

        /// <summary>Algeria - DZ</summary>
        Algeria,

        /// <summary>American Samoa - AS</summary>
        AmericanSamoa,

        /// <summary>Andorra - AD</summary>
        Andorra,

        /// <summary>Angola - AO</summary>
        Angola,

        /// <summary>Anguilla - AI</summary>
        Anguilla,

        /// <summary>Antarctica - AQ</summary>
        Antarctica,

        /// <summary>Antigua and Barbuda - AG</summary>
        AntiguaAndBarbuda,

        /// <summary>Argentina - AR</summary>
        Argentina,

        /// <summary>Armenia - AM</summary>
        Armenia,

        /// <summary>Aruba - AW</summary>
        Aruba,

        /// <summary>Australia - AU</summary>
        Australia,

        /// <summary>Austria - AT</summary>
        Austria,

        /// <summary>Azerbaijan - AZ</summary>
        Azerbaijan,

        /// <summary>Bahamas - BS</summary>
        Bahamas,

        /// <summary>Bahrain - BH</summary>
        Bahrain,

        /// <summary>Bangladesh - BD</summary>
        Bangladesh,

        /// <summary>Barbados - BB</summary>
        Barbados,

        /// <summary>Belarus - BY</summary>
        Belarus,

        /// <summary>Belgium - BE</summary>
        Belgium,

        /// <summary>Belize - BZ</summary>
        Belize,

        /// <summary>Benin - BJ</summary>
        Benin,

        /// <summary>Bermuda - BM</summary>
        Bermuda,

        /// <summary>Bhutan - BT</summary>
        Bhutan,

        /// <summary>Bolivia - BO</summary>
        Bolivia,

        /// <summary>Bosnia and Herzegovina - BA</summary>
        BosniaAndHerzegovina,

        /// <summary>Botswana - BW</summary>
        Botswana,

        /// <summary>Bouvet Island - BV</summary>
        BouvetIsland,

        /// <summary>Brazil - BR</summary>
        Brazil,

        /// <summary>British Indian Ocean Territory - IO</summary>
        BritishIndianOceanTerritory,

        /// <summary>Brunei Darussalam - BN</summary>
        BruneiDarussalam,

        /// <summary>Bulgaria - BG</summary>
        Bulgaria,

        /// <summary>Burkina Faso - BF</summary>
        BurkinaFaso,

        /// <summary>Burundi - BI</summary>
        Burundi,

        /// <summary>Cambodia - KH</summary>
        Cambodia,

        /// <summary>Cameroon - CM</summary>
        Cameroon,

        /// <summary>Canada - CA</summary>
        Canada,

        /// <summary>Cape Verde - CV</summary>
        CapeVerde,

        /// <summary>Cayman Islands - KY</summary>
        CaymanIslands,

        /// <summary>Central African Republic - CF</summary>
        CentralAfricanRepublic,

        /// <summary>Chad - TD</summary>
        Chad,

        /// <summary>Chile - CL</summary>
        Chile,

        /// <summary>China - CN</summary>
        China,

        /// <summary>Christmas Island - CX</summary>
        ChristmasIsland,

        /// <summary>Cocos (Keeling) Islands - CC</summary>
        CocosKeelingIslands,

        /// <summary>Colombia - CO</summary>
        Colombia,

        /// <summary>Comoros - KM</summary>
        Comoros,

        /// <summary>Congo - CG</summary>
        Congo,

        /// <summary>Congo, Democratic Republic - CD</summary>
        CongoDemocraticRepublic,

        /// <summary>Cook Islands - CK</summary>
        CookIslands,

        /// <summary>Costa Rica - CR</summary>
        CostaRica,

        /// <summary>Côte d'Ivoire - CI</summary>
        CoteDIvoire,

        /// <summary>Croatia - HR</summary>
        Croatia,

        /// <summary>Cuba - CU</summary>
        Cuba,

        /// <summary>Cyprus - CY</summary>
        Cyprus,

        /// <summary>Czech Republic - CZ</summary>
        CzechRepublic,

        /// <summary>Denmark - DK</summary>
        Denmark,

        /// <summary>Djibouti - DJ</summary>
        Djibouti,

        /// <summary>Dominica - DM</summary>
        Dominica,

        /// <summary>Dominican Republic - DO</summary>
        DominicanRepublic,

        /// <summary>Ecuador - EC</summary>
        Ecuador,

        /// <summary>Egypt - EG</summary>
        Egypt,

        /// <summary>El Salvador - SV</summary>
        ElSalvador,

        /// <summary>Equatorial Guinea - GQ</summary>
        EquatorialGuinea,

        /// <summary>Eritrea - ER</summary>
        Eritrea,

        /// <summary>Estonia - EE</summary>
        Estonia,

        /// <summary>Ethiopia - ET</summary>
        Ethiopia,

        /// <summary>Falkland Islands - FK</summary>
        FalklandIslands,

        /// <summary>Faroe Islands - FO</summary>
        FaroeIslands,

        /// <summary>Fiji - FJ</summary>
        Fiji,

        /// <summary>Finland - FI</summary>
        Finland,

        /// <summary>France - FR</summary>
        France,

        /// <summary>French Guiana - GF</summary>
        FrenchGuiana,

        /// <summary>French Polynesia - PF</summary>
        FrenchPolynesia,

        /// <summary>French Southern Territories - TF</summary>
        FrenchSouthernTerritories,

        /// <summary>Gabon - GA</summary>
        Gabon,

        /// <summary>Gambia - GM</summary>
        Gambia,

        /// <summary>Georgia - GE</summary>
        Georgia,

        /// <summary>Germany - DE</summary>
        Germany,

        /// <summary>Ghana - GH</summary>
        Ghana,

        /// <summary>Gibraltar - GI</summary>
        Gibraltar,

        /// <summary>Greece - GR</summary>
        Greece,

        /// <summary>Greenland - GL</summary>
        Greenland,

        /// <summary>Grenada - GD</summary>
        Grenada,

        /// <summary>Guadeloupe - GP</summary>
        Guadeloupe,

        /// <summary>Guam - GU</summary>
        Guam,

        /// <summary>Guatemala - GT</summary>
        Guatemala,

        /// <summary>Guernsey - GG</summary>
        Guernsey,

        /// <summary>Guinea - GN</summary>
        Guinea,

        /// <summary>Guinea-Bissau - GW</summary>
        GuineaBissau,

        /// <summary>Guyana - GY</summary>
        Guyana,

        /// <summary>Haiti - HT</summary>
        Haiti,

        /// <summary>Heard Island and McDonald Islands - HM</summary>
        HeardIslandAndMcDonaldIslands,

        /// <summary>Holy See (Vatican City State) - VA</summary>
        HolySeeVaticanCityState,

        /// <summary>Honduras - HN</summary>
        Honduras,

        /// <summary>Hong Kong - HK</summary>
        HongKong,

        /// <summary>Hungary - HU</summary>
        Hungary,

        /// <summary>Iceland - IS</summary>
        Iceland,

        /// <summary>India - IN</summary>
        India,

        /// <summary>Indonesia - ID</summary>
        Indonesia,

        /// <summary>Iran - IR</summary>
        Iran,

        /// <summary>Iraq - IQ</summary>
        Iraq,

        /// <summary>Ireland - IE</summary>
        Ireland,

        /// <summary>Isle of Man - IM</summary>
        IsleOfMan,

        /// <summary>Israel - IL</summary>
        Israel,

        /// <summary>Italy - IT</summary>
        Italy,

        /// <summary>Jamaica - JM</summary>
        Jamaica,

        /// <summary>Japan - JP</summary>
        Japan,

        /// <summary>Jersey - JE</summary>
        Jersey,

        /// <summary>Jordan - JO</summary>
        Jordan,

        /// <summary>Kazakhstan - KZ</summary>
        Kazakhstan,

        /// <summary>Kenya - KE</summary>
        Kenya,

        /// <summary>Kiribati - KI</summary>
        Kiribati,

        /// <summary>Korea, Democratic People's Republic - KP</summary>
        KoreaDemocraticPeoplesRepublic,

        /// <summary>Korea, Republic of - KR</summary>
        KoreaRepublicOf,

        /// <summary>Kuwait - KW</summary>
        Kuwait,

        /// <summary>Kyrgyzstan - KG</summary>
        Kyrgyzstan,

        /// <summary>Lao People's Democratic Republic - LA</summary>
        LaoPeoplesDemocraticRepublic,

        /// <summary>Latvia - LV</summary>
        Latvia,

        /// <summary>Lebanon - LB</summary>
        Lebanon,

        /// <summary>Lesotho - LS</summary>
        Lesotho,

        /// <summary>Liberia - LR</summary>
        Liberia,

        /// <summary>Libya - LY</summary>
        Libya,

        /// <summary>Liechtenstein - LI</summary>
        Liechtenstein,

        /// <summary>Lithuania - LT</summary>
        Lithuania,

        /// <summary>Luxembourg - LU</summary>
        Luxembourg,

        /// <summary>Macao - MO</summary>
        Macao,

        /// <summary>Madagascar - MG</summary>
        Madagascar,

        /// <summary>Malawi - MW</summary>
        Malawi,

        /// <summary>Malaysia - MY</summary>
        Malaysia,

        /// <summary>Maldives - MV</summary>
        Maldives,

        /// <summary>Mali - ML</summary>
        Mali,

        /// <summary>Malta - MT</summary>
        Malta,

        /// <summary>Marshall Islands - MH</summary>
        MarshallIslands,

        /// <summary>Martinique - MQ</summary>
        Martinique,

        /// <summary>Mauritania - MR</summary>
        Mauritania,

        /// <summary>Mauritius - MU</summary>
        Mauritius,

        /// <summary>Mayotte - YT</summary>
        Mayotte,

        /// <summary>Mexico - MX</summary>
        Mexico,

        /// <summary>Micronesia - FM</summary>
        Micronesia,

        /// <summary>Moldova - MD</summary>
        Moldova,

        /// <summary>Monaco - MC</summary>
        Monaco,

        /// <summary>Mongolia - MN</summary>
        Mongolia,

        /// <summary>Montenegro - ME</summary>
        Montenegro,

        /// <summary>Montserrat - MS</summary>
        Montserrat,

        /// <summary>Morocco - MA</summary>
        Morocco,

        /// <summary>Mozambique - MZ</summary>
        Mozambique,

        /// <summary>Myanmar - MM</summary>
        Myanmar,

        /// <summary>Namibia - NA</summary>
        Namibia,

        /// <summary>Nauru - NR</summary>
        Nauru,

        /// <summary>Nepal - NP</summary>
        Nepal,

        /// <summary>Netherlands - NL</summary>
        Netherlands,

        /// <summary>New Caledonia - NC</summary>
        NewCaledonia,

        /// <summary>New Zealand - NZ</summary>
        NewZealand,

        /// <summary>Nicaragua - NI</summary>
        Nicaragua,

        /// <summary>Niger - NE</summary>
        Niger,

        /// <summary>Nigeria - NG</summary>
        Nigeria,

        /// <summary>Niue - NU</summary>
        Niue,

        /// <summary>Norfolk Island - NF</summary>
        NorfolkIsland,

        /// <summary>North Macedonia - MK</summary>
        NorthMacedonia,

        /// <summary>Northern Mariana Islands - MP</summary>
        NorthernMarianaIslands,

        /// <summary>Norway - NO</summary>
        Norway,

        /// <summary>Oman - OM</summary>
        Oman,

        /// <summary>Pakistan - PK</summary>
        Pakistan,

        /// <summary>Palau - PW</summary>
        Palau,

        /// <summary>Palestinian Territory - PS</summary>
        PalestinianTerritory,

        /// <summary>Panama - PA</summary>
        Panama,

        /// <summary>Papua New Guinea - PG</summary>
        PapuaNewGuinea,

        /// <summary>Paraguay - PY</summary>
        Paraguay,

        /// <summary>Peru - PE</summary>
        Peru,

        /// <summary>Philippines - PH</summary>
        Philippines,

        /// <summary>Pitcairn - PN</summary>
        Pitcairn,

        /// <summary>Poland - PL</summary>
        Poland,

        /// <summary>Portugal - PT</summary>
        Portugal,

        /// <summary>Puerto Rico - PR</summary>
        PuertoRico,

        /// <summary>Qatar - QA</summary>
        Qatar,

        /// <summary>Réunion - RE</summary>
        Reunion,

        /// <summary>Romania - RO</summary>
        Romania,

        /// <summary>Russian Federation - RU</summary>
        RussianFederation,

        /// <summary>Rwanda - RW</summary>
        Rwanda,

        /// <summary>Saint Barthélemy - BL</summary>
        SaintBarthelemy,

        /// <summary>Saint Helena - SH</summary>
        SaintHelena,

        /// <summary>Saint Kitts and Nevis - KN</summary>
        SaintKittsAndNevis,

        /// <summary>Saint Lucia - LC</summary>
        SaintLucia,

        /// <summary>Saint Martin - MF</summary>
        SaintMartin,

        /// <summary>Saint Pierre and Miquelon - PM</summary>
        SaintPierreAndMiquelon,

        /// <summary>Saint Vincent and the Grenadines - VC</summary>
        SaintVincentAndTheGrenadines,

        /// <summary>Samoa - WS</summary>
        Samoa,

        /// <summary>San Marino - SM</summary>
        SanMarino,

        /// <summary>Sao Tome and Principe - ST</summary>
        SaoTomeAndPrincipe,

        /// <summary>Saudi Arabia - SA</summary>
        SaudiArabia,

        /// <summary>Senegal - SN</summary>
        Senegal,

        /// <summary>Serbia - RS</summary>
        Serbia,

        /// <summary>Seychelles - SC</summary>
        Seychelles,

        /// <summary>Sierra Leone - SL</summary>
        SierraLeone,

        /// <summary>Singapore - SG</summary>
        Singapore,

        /// <summary>Sint Maarten - SX</summary>
        SintMaarten,

        /// <summary>Slovakia - SK</summary>
        Slovakia,

        /// <summary>Slovenia - SI</summary>
        Slovenia,

        /// <summary>Solomon Islands - SB</summary>
        SolomonIslands,

        /// <summary>Somalia - SO</summary>
        Somalia,

        /// <summary>South Africa - ZA</summary>
        SouthAfrica,

        /// <summary>South Georgia and the South Sandwich Islands - GS</summary>
        SouthGeorgiaAndTheSouthSandwichIslands,

        /// <summary>South Sudan - SS</summary>
        SouthSudan,

        /// <summary>Spain - ES</summary>
        Spain,

        /// <summary>Sri Lanka - LK</summary>
        SriLanka,

        /// <summary>Sudan - SD</summary>
        Sudan,

        /// <summary>Suriname - SR</summary>
        Suriname,

        /// <summary>Svalbard and Jan Mayen - SJ</summary>
        SvalbardAndJanMayen,

        /// <summary>Swaziland - SZ</summary>
        Swaziland,

        /// <summary>Sweden - SE</summary>
        Sweden,

        /// <summary>Switzerland - CH</summary>
        Switzerland,

        /// <summary>Syrian Arab Republic - SY</summary>
        SyrianArabRepublic,

        /// <summary>Taiwan - TW</summary>
        Taiwan,

        /// <summary>Tajikistan - TJ</summary>
        Tajikistan,

        /// <summary>Tanzania - TZ</summary>
        Tanzania,

        /// <summary>Thailand - TH</summary>
        Thailand,

        /// <summary>Timor-Leste - TL</summary>
        TimorLeste,

        /// <summary>Togo - TG</summary>
        Togo,

        /// <summary>Tokelau - TK</summary>
        Tokelau,

        /// <summary>Tonga - TO</summary>
        Tonga,

        /// <summary>Trinidad and Tobago - TT</summary>
        TrinidadAndTobago,

        /// <summary>Tunisia - TN</summary>
        Tunisia,

        /// <summary>Turkey - TR</summary>
        Turkey,

        /// <summary>Turkmenistan - TM</summary>
        Turkmenistan,

        /// <summary>Turks and Caicos Islands - TC</summary>
        TurksAndCaicosIslands,

        /// <summary>Tuvalu - TV</summary>
        Tuvalu,

        /// <summary>Uganda - UG</summary>
        Uganda,

        /// <summary>Ukraine - UA</summary>
        Ukraine,

        /// <summary>United Arab Emirates - AE</summary>
        UnitedArabEmirates,

        /// <summary>United Kingdom - GB</summary>
        UnitedKingdom,

        /// <summary>United States - US</summary>
        UnitedStates,

        /// <summary>United States Minor Outlying Islands - UM</summary>
        UnitedStatesMinorOutlyingIslands,

        /// <summary>Uruguay - UY</summary>
        Uruguay,

        /// <summary>Uzbekistan - UZ</summary>
        Uzbekistan,

        /// <summary>Vanuatu - VU</summary>
        Vanuatu,

        /// <summary>Venezuela - VE</summary>
        Venezuela,

        /// <summary>Viet Nam - VN</summary>
        VietNam,

        /// <summary>Virgin Islands, British - VG</summary>
        VirginIslandsBritish,

        /// <summary>Virgin Islands, U.S. - VI</summary>
        VirginIslandsUS,

        /// <summary>Wallis and Futuna - WF</summary>
        WallisAndFutuna,

        /// <summary>Western Sahara - EH</summary>
        WesternSahara,

        /// <summary>Yemen - YE</summary>
        Yemen,

        /// <summary>Zambia - ZM</summary>
        Zambia,

        /// <summary>Zimbabwe - ZW</summary>
        Zimbabwe,
    }

    /// <summary>
    /// Represents a measurement value in points, bounded from -31 to 31.
    /// Used for positioning and spacing measurements in field instructions.
    /// </summary>
    public struct PtsMeasurementValue<T>
        where T : struct,
            System.Numerics.IBinaryNumber<T>,
            System.Numerics.ISignedNumber<T>,
            IComparable<T>
    {
        private T _value;

        public static readonly T MinValue = T.CreateChecked(-31);
        public static readonly T MaxValue = T.CreateChecked(31);

        /// <summary>
        /// The measurement value in points.
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Points measurement must be between -31 and 31"
                    );
                }
                _value = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the PtsMeasurementValue class.
        /// </summary>
        /// <param name="value">The measurement value in points (-31 to 31).</param>
        public PtsMeasurementValue(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Implicit conversion from T to PtsMeasurementValue.
        /// </summary>
        public static implicit operator PtsMeasurementValue<T>(T value)
        {
            return new PtsMeasurementValue<T>(value);
        }

        /// <summary>
        /// Implicit conversion from PtsMeasurementValue to T.
        /// </summary>
        public static implicit operator T(PtsMeasurementValue<T> measurement)
        {
            return measurement.Value;
        }

        /// <summary>
        /// Returns the string representation of the measurement value.
        /// </summary>
        public override string ToString()
        {
            return Value.ToString() ?? Convert.ToInt32(Value).ToString();
        }
    }

    /// <summary>
    /// Represents postal data that must be either a 5-digit or 9-digit ZIP code.
    /// </summary>
    public class PostalData
    {
        private string _value;

        /// <summary>
        /// The postal ZIP code value.
        /// </summary>
        public string Value
        {
            get => _value;
            set
            {
                if (!IsValidZipCode(value))
                {
                    throw new ArgumentException("Invalid postal data format.");
                }
                _value = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the PostalData class.
        /// </summary>
        /// <param name="value">The ZIP code value.</param>
        public PostalData(string value)
        {
            _value = value;
            Value = value;
        }

        /// <summary>
        /// Validates if the value is a proper ZIP code format.
        /// </summary>
        private static bool IsValidZipCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            // 5-digit ZIP code
            if (value.Length == 5 && value.All(char.IsDigit))
            {
                return true;
            }

            // 9-digit ZIP code (12345-6789)
            if (
                value.Length == 10
                && value[5] == '-'
                && value.Substring(0, 5).All(char.IsDigit)
                && value.Substring(6, 4).All(char.IsDigit)
            )
            {
                return true;
            }

            // 9-digit ZIP code without hyphen
            if (value.Length == 9 && value.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Implicit conversion from string to PostalData.
        /// </summary>
        public static implicit operator PostalData(string value)
        {
            return new PostalData(value);
        }

        /// <summary>
        /// Implicit conversion from PostalData to string.
        /// </summary>
        public static implicit operator string(PostalData postalData)
        {
            return postalData.Value;
        }

        /// <summary>
        /// Returns the string representation of the postal data.
        /// </summary>
        public override string ToString()
        {
            return Value;
        }
    }

    /// <summary>
    /// Represents a validated XML namespace declaration in the format xmlns:prefix="URI".
    /// </summary>
    public class NamespaceDeclaration
    {
        private readonly string _prefix;
        private readonly System.Xml.Linq.XNamespace _namespace;
        private readonly string _originalDeclaration;

        public NamespaceDeclaration(string declaration)
        {
            if (string.IsNullOrWhiteSpace(declaration))
            {
                throw new ArgumentException(
                    "Namespace declaration cannot be null or empty.",
                    nameof(declaration)
                );
            }

            _originalDeclaration = declaration;
            string toParse = declaration.Trim();

            if (toParse.StartsWith("\"") && toParse.EndsWith("\""))
            {
                toParse = toParse.Substring(1, toParse.Length - 2);
            }

            if (!toParse.StartsWith("xmlns:"))
            {
                int eqIndex = toParse.IndexOf('=');
                if (eqIndex > 0)
                {
                    string prefix = toParse.Substring(0, eqIndex);
                    string uri = toParse.Substring(eqIndex + 1);
                    if (prefix.Contains('\"') || uri.Contains('\"'))
                    {
                        throw new ArgumentException(
                            $"Invalid namespace declaration format. For 'prefix=URI' format, neither prefix nor URI should be quoted. Got: {declaration}"
                        );
                    }
                    toParse = $"xmlns:{prefix}=\"{uri}\"";
                }
                else
                {
                    throw new ArgumentException(
                        $"Invalid namespace declaration format. Expected 'xmlns:prefix=\"URI\"' or 'prefix=URI', got: {declaration}"
                    );
                }
            }

            // Parse xmlns:prefix="URI" format
            int equalsIndex = toParse.IndexOf('=');
            if (equalsIndex == -1)
            {
                throw new ArgumentException(
                    $"Invalid namespace declaration format. Missing '=' in: {declaration}"
                );
            }

            string prefixPart = toParse.Substring(6, equalsIndex - 6).Trim(); // Skip "xmlns:"
            string uriPart = toParse.Substring(equalsIndex + 1).Trim();

            // Validate prefix (must be valid XML name)
            if (string.IsNullOrWhiteSpace(prefixPart) || !IsValidNCName(prefixPart))
            {
                throw new ArgumentException($"Invalid namespace prefix: {prefixPart}");
            }

            // Remove quotes from URI and validate
            if (!uriPart.StartsWith("\"") || !uriPart.EndsWith("\"") || uriPart.Length < 2)
            {
                throw new ArgumentException($"Namespace URI must be quoted. Got: {uriPart}");
            }

            string uriValue = uriPart.Substring(1, uriPart.Length - 2);
            if (string.IsNullOrWhiteSpace(uriValue))
            {
                throw new ArgumentException("Namespace URI cannot be empty.");
            }

            try
            {
                // Validate URI by creating XNamespace
                _namespace = System.Xml.Linq.XNamespace.Get(uriValue);
                _prefix = prefixPart;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid namespace URI: {uriValue}", ex);
            }
        }

        /// <summary>
        /// Gets the namespace prefix (the part after xmlns:).
        /// </summary>
        public string Prefix => _prefix;

        /// <summary>
        /// Gets the validated XNamespace object.
        /// </summary>
        public System.Xml.Linq.XNamespace Namespace => _namespace;

        /// <summary>
        /// Gets the namespace URI.
        /// </summary>
        public string Uri => _namespace.NamespaceName;

        /// <summary>
        /// Gets the original declaration string.
        /// </summary>
        public string Declaration => _originalDeclaration;

        public override string ToString() => _originalDeclaration;

        public static implicit operator string(NamespaceDeclaration namespaceDeclaration) =>
            namespaceDeclaration._originalDeclaration;

        public static implicit operator NamespaceDeclaration(string declaration) =>
            new NamespaceDeclaration(declaration);

        /// <summary>
        /// Validates that a string is a valid NCName (XML name without colon).
        /// </summary>
        private static bool IsValidNCName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // NCName must start with letter or underscore
            char first = name[0];
            if (!char.IsLetter(first) && first != '_')
            {
                return false;
            }

            // Subsequent characters can be letters, digits, hyphens, periods, or underscores
            for (int i = 1; i < name.Length; i++)
            {
                char c = name[i];
                if (!char.IsLetterOrDigit(c) && c != '-' && c != '.' && c != '_')
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// Represents the format options for names in mail merge fields like GREETINGLINE and ADDRESSBLOCK.
    /// </summary>
    public enum NameFormat
    {
        /// <summary>
        /// First name only (e.g., "John").
        /// </summary>
        FirstName,

        /// <summary>
        /// Last name only (e.g., "Smith").
        /// </summary>
        LastName,

        /// <summary>
        /// First name followed by last name (e.g., "John Smith").
        /// </summary>
        FirstLastName,

        /// <summary>
        /// Last name followed by first name (e.g., "Smith, John").
        /// </summary>
        LastFirstName,

        /// <summary>
        /// Title followed by last name (e.g., "Mr. Smith").
        /// </summary>
        TitleLastName,

        /// <summary>
        /// Full formal name including title, first name, and last name (e.g., "Mr. John Smith").
        /// </summary>
        FullFormalName,
    }
}
