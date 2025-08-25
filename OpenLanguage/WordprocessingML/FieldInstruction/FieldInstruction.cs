using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLanguage.WordprocessingML.FieldInstruction
{
    public enum FrameTarget
    {
        // "_top": Whole page, default
        Top,

        // "_self": same frame
        Self,

        // "_blank": new window
        Blank,

        // "_parent": Parent frame
        Parent,
    }

    public static class FrameTargetUtils
    {
        /// <summary>
        /// Parses a frame target from text.
        /// </summary>
        /// <param name="frameTargetText">The operator text to parse.</param>
        /// <returns>The parsed FrameTarget.</returns>
        public static FrameTarget ParseFrameTarget(string frameTargetText)
        {
            switch (frameTargetText?.Trim().ToLowerInvariant())
            {
                case "_top":
                case "top":
                    {
                        return FrameTarget.Top;
                    }
                case "_self":
                case "self":
                    {
                        return FrameTarget.Self;
                    }

                case "_blank":
                case "blank":
                    {
                        return FrameTarget.Blank;
                    }
                case "_parent":
                case "parent":
                    {
                        return FrameTarget.Parent;
                    }
                default:
                    {
                        throw new ArgumentException($"Invalid frame target: {frameTargetText}");
                    }
            }
        }

        /// <summary>
        /// Converts a frame target enumeration to text.
        /// </summary>
        /// <param name="frameTarget">The frame target enumeration to convert.</param>
        /// <returns>The converted string.</returns>
        public static string FrameTargetText(FrameTarget frameTarget)
        {
            return frameTarget switch
            {
                FrameTarget.Blank => "_blank",
                FrameTarget.Self => "_self",
                FrameTarget.Parent => "_parent",
                FrameTarget.Top => "_top",
                _ => "_top", // Default case
            };
        }
    }

    /// <summary>
    /// Defines the type of a parsed argument within a field instruction.
    /// </summary>
    public enum FieldArgumentType
    {
        /// <summary>
        /// An identifier or a simple value (e.g., a bookmark name, a number).
        /// </summary>
        Identifier,

        /// <summary>
        /// A string literal enclosed in double quotes.
        /// </summary>
        StringLiteral,

        /// <summary>
        /// A field switch, which always begins with a backslash (e.g., \h, \@, \b).
        /// </summary>
        Switch,

        /// <summary>
        /// A complete, nested field instruction enclosed in braces.
        /// </summary>
        NestedField,

        /// <summary>
        /// A text value.
        /// </summary>
        Text,

        /// <summary>
        /// A numeric value.
        /// </summary>
        Number,
    }

    /// <summary>
    /// Represents document property categories used in DOCPROPERTY field instructions.
    /// </summary>
    public enum DocumentPropertyCategory
    {
        /// <summary>
        /// AUTHOR - Document author information.
        /// </summary>
        Author,

        /// <summary>
        /// BYTES - Document file size in bytes.
        /// </summary>
        Bytes,

        /// <summary>
        /// CATEGORY - Document category from Core File Properties.
        /// </summary>
        Category,

        /// <summary>
        /// CHARACTERS - Number of characters in the document.
        /// </summary>
        Characters,

        /// <summary>
        /// CHARACTERSWITHSPACES - Number of characters including spaces.
        /// </summary>
        CharactersWithSpaces,

        /// <summary>
        /// COMMENTS - Document comments.
        /// </summary>
        Comments,

        /// <summary>
        /// COMPANY - Company name from Application-Defined File Properties.
        /// </summary>
        Company,

        /// <summary>
        /// CREATETIME - Document creation time.
        /// </summary>
        CreateTime,

        /// <summary>
        /// HYPERLINKBASE - Hyperlink base from Application-Defined File Properties.
        /// </summary>
        HyperlinkBase,

        /// <summary>
        /// KEYWORDS - Document keywords from Core File Properties.
        /// </summary>
        Keywords,

        /// <summary>
        /// LASTPRINTED - Last printed date.
        /// </summary>
        LastPrinted,

        /// <summary>
        /// LASTSAVEDBY - Last saved by user.
        /// </summary>
        LastSavedBy,

        /// <summary>
        /// LASTSAVEDTIME - Last saved time.
        /// </summary>
        LastSavedTime,

        /// <summary>
        /// LINES - Number of lines from Application-Defined File Properties.
        /// </summary>
        Lines,

        /// <summary>
        /// MANAGER - Manager name from Application-Defined File Properties.
        /// </summary>
        Manager,

        /// <summary>
        /// NAMEOFAPPLICATION - Application name from Application-Defined File Properties.
        /// </summary>
        NameOfApplication,

        /// <summary>
        /// ODMADOCID - ODMA document ID.
        /// </summary>
        OdmaDocId,

        /// <summary>
        /// PAGES - Number of pages in the document.
        /// </summary>
        Pages,

        /// <summary>
        /// PARAGRAPHS - Number of paragraphs from Application-Defined File Properties.
        /// </summary>
        Paragraphs,

        /// <summary>
        /// REVISIONNUMBER - Document revision number.
        /// </summary>
        RevisionNumber,

        /// <summary>
        /// SECURITY - Document security level from Application-Defined File Properties.
        /// </summary>
        Security,

        /// <summary>
        /// SUBJECT - Document subject.
        /// </summary>
        Subject,

        /// <summary>
        /// TEMPLATE - Document template.
        /// </summary>
        Template,

        /// <summary>
        /// TITLE - Document title.
        /// </summary>
        Title,

        /// <summary>
        /// TOTALEDITINGTIME - Total editing time.
        /// </summary>
        TotalEditingTime,

        /// <summary>
        /// WORDS - Number of words from Application-Defined File Properties.
        /// </summary>
        Words,
    }

    /// <summary>
    /// Represents table formatting attributes for DATABASE field instructions.
    /// Values can be combined using bitwise OR operations.
    /// </summary>
    [Flags]
    public enum DatabaseTableAttributes
    {
        /// <summary>
        /// No formatting attributes (0).
        /// </summary>
        None = 0,

        /// <summary>
        /// Apply borders to the table (1).
        /// </summary>
        Borders = 1,

        /// <summary>
        /// Apply shading to the table (2).
        /// </summary>
        Shading = 2,

        /// <summary>
        /// Apply font formatting to the table (4).
        /// </summary>
        Font = 4,

        /// <summary>
        /// Apply color formatting to the table (8).
        /// </summary>
        Color = 8,

        /// <summary>
        /// Apply AutoFit to the table (16).
        /// </summary>
        AutoFit = 16,

        /// <summary>
        /// Apply special formatting to heading rows (32).
        /// </summary>
        HeadingRows = 32,

        /// <summary>
        /// Apply special formatting to the last row (64).
        /// </summary>
        LastRow = 64,

        /// <summary>
        /// Apply special formatting to the first column (128).
        /// </summary>
        FirstColumn = 128,

        /// <summary>
        /// Apply special formatting to the last column (256).
        /// </summary>
        LastColumn = 256,
    }

    /// <summary>
    /// Represents table format options for DATABASE field instructions.
    /// Word supports 42 pre-formatted table styles numbered 0-41.
    /// </summary>
    public enum DatabaseTableFormat
    {
        /// <summary>Format 0 - None/Default</summary>
        None = 0,

        /// <summary>Format 1 - Simple 1</summary>
        Simple1 = 1,

        /// <summary>Format 2 - Simple 2</summary>
        Simple2 = 2,

        /// <summary>Format 3 - Simple 3</summary>
        Simple3 = 3,

        /// <summary>Format 4 - Classic 1</summary>
        Classic1 = 4,

        /// <summary>Format 5 - Classic 2</summary>
        Classic2 = 5,

        /// <summary>Format 6 - Classic 3</summary>
        Classic3 = 6,

        /// <summary>Format 7 - Classic 4</summary>
        Classic4 = 7,

        /// <summary>Format 8 - Colorful 1</summary>
        Colorful1 = 8,

        /// <summary>Format 9 - Colorful 2</summary>
        Colorful2 = 9,

        /// <summary>Format 10 - Colorful 3</summary>
        Colorful3 = 10,

        /// <summary>Format 11 - Columns 1</summary>
        Columns1 = 11,

        /// <summary>Format 12 - Columns 2</summary>
        Columns2 = 12,

        /// <summary>Format 13 - Columns 3</summary>
        Columns3 = 13,

        /// <summary>Format 14 - Columns 4</summary>
        Columns4 = 14,

        /// <summary>Format 15 - Columns 5</summary>
        Columns5 = 15,

        /// <summary>Format 16 - Grid 1</summary>
        Grid1 = 16,

        /// <summary>Format 17 - Grid 2</summary>
        Grid2 = 17,

        /// <summary>Format 18 - Grid 3</summary>
        Grid3 = 18,

        /// <summary>Format 19 - Grid 4</summary>
        Grid4 = 19,

        /// <summary>Format 20 - Grid 5</summary>
        Grid5 = 20,

        /// <summary>Format 21 - Grid 6</summary>
        Grid6 = 21,

        /// <summary>Format 22 - Grid 7</summary>
        Grid7 = 22,

        /// <summary>Format 23 - Grid 8</summary>
        Grid8 = 23,

        /// <summary>Format 24 - List 1</summary>
        List1 = 24,

        /// <summary>Format 25 - List 2</summary>
        List2 = 25,

        /// <summary>Format 26 - List 3</summary>
        List3 = 26,

        /// <summary>Format 27 - List 4</summary>
        List4 = 27,

        /// <summary>Format 28 - List 5</summary>
        List5 = 28,

        /// <summary>Format 29 - List 6</summary>
        List6 = 29,

        /// <summary>Format 30 - List 7</summary>
        List7 = 30,

        /// <summary>Format 31 - List 8</summary>
        List8 = 31,

        /// <summary>Format 32 - 3D Effects 1</summary>
        ThreeDEffects1 = 32,

        /// <summary>Format 33 - 3D Effects 2</summary>
        ThreeDEffects2 = 33,

        /// <summary>Format 34 - 3D Effects 3</summary>
        ThreeDEffects3 = 34,

        /// <summary>Format 35 - Contemporary</summary>
        Contemporary = 35,

        /// <summary>Format 36 - Elegant</summary>
        Elegant = 36,

        /// <summary>Format 37 - Professional</summary>
        Professional = 37,

        /// <summary>Format 38 - Subtle 1</summary>
        Subtle1 = 38,

        /// <summary>Format 39 - Subtle 2</summary>
        Subtle2 = 39,

        /// <summary>Format 40 - Web 1</summary>
        Web1 = 40,

        /// <summary>Format 41 - Web 2</summary>
        Web2 = 41,
    }

    /// <summary>
    /// Represents optimization flag options for DATABASE field instructions.
    /// </summary>
    public enum DatabaseOptimizationFlag
    {
        /// <summary>
        /// No optimization - query runs for each record.
        /// </summary>
        None,

        /// <summary>
        /// Query once at beginning of merge operation.
        /// </summary>
        QueryOnce,

        /// <summary>
        /// Cache results for improved performance.
        /// </summary>
        CacheResults,

        /// <summary>
        /// Use connection pooling.
        /// </summary>
        UseConnectionPooling,

        /// <summary>
        /// Optimize for large datasets.
        /// </summary>
        OptimizeForLargeData,

        /// <summary>
        /// Optimize for small datasets.
        /// </summary>
        OptimizeForSmallData,
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
    public class PtsMeasurementValue
    {
        private int _value;

        /// <summary>
        /// The measurement value in points.
        /// </summary>
        public int Value
        {
            get => _value;
            set
            {
                if (value < -31 || value > 31)
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
        public PtsMeasurementValue(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Implicit conversion from Int32 to PtsMeasurementValue.
        /// </summary>
        public static implicit operator PtsMeasurementValue(int value)
        {
            return new PtsMeasurementValue(value);
        }

        /// <summary>
        /// Implicit conversion from PtsMeasurementValue to int.
        /// </summary>
        public static implicit operator int(PtsMeasurementValue measurement)
        {
            return measurement.Value;
        }

        /// <summary>
        /// Returns the string representation of the measurement value.
        /// </summary>
        public override string ToString()
        {
            return Value.ToString();
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

            _originalDeclaration = declaration.Trim();

            // Parse xmlns:prefix="URI" format
            if (!_originalDeclaration.StartsWith("xmlns:"))
            {
                throw new ArgumentException(
                    $"Invalid namespace declaration format. Expected 'xmlns:prefix=\"URI\"', got: {declaration}"
                );
            }

            int equalsIndex = _originalDeclaration.IndexOf('=');
            if (equalsIndex == -1)
            {
                throw new ArgumentException(
                    $"Invalid namespace declaration format. Missing '=' in: {declaration}"
                );
            }

            string prefixPart = _originalDeclaration.Substring(6, equalsIndex - 6).Trim(); // Skip "xmlns:"
            string uriPart = _originalDeclaration.Substring(equalsIndex + 1).Trim();

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

            string uri = uriPart.Substring(1, uriPart.Length - 2);
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentException("Namespace URI cannot be empty.");
            }

            try
            {
                // Validate URI by creating XNamespace
                _namespace = System.Xml.Linq.XNamespace.Get(uri);
                _prefix = prefixPart;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid namespace URI: {uri}", ex);
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
    /// Represents a single argument for a field instruction. An argument has a type
    /// and a value. The value can be a string or another FieldInstruction for nested fields.
    /// </summary>
    public class FieldArgument
    {
        /// <summary>
        /// The type of the argument.
        /// </summary>
        public FieldArgumentType Type { get; }

        /// <summary>
        /// The value of the argument. This is a string for simple types
        /// and a FieldInstruction object for the NestedField type.
        /// </summary>
        public object? Value { get; }

        public FieldArgument(FieldArgumentType type, object? value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// Recompiles the argument back into its valid field code string representation.
        /// </summary>
        /// <returns>A string representing the argument as it would appear in a field code.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case FieldArgumentType.Identifier:
                case FieldArgumentType.Switch:
                case FieldArgumentType.Text:
                case FieldArgumentType.Number:
                    return Value?.ToString() ?? string.Empty;

                case FieldArgumentType.StringLiteral:
                    // When recompiling, quotes within the string must be escaped with a backslash.
                    // The Value for StringLiteral is already the unescaped string.
                    return $"\"{Value?.ToString()?.Replace("\"", "\\\"") ?? string.Empty}\"";

                case FieldArgumentType.NestedField:
                    // Recompile the nested instruction and wrap it in braces with standard spacing.
                    return Value == null ? string.Empty : $"{{ {Value.ToString()} }}";

                default:
                    return string.Empty;
            }
        }
    }

    /// <summary>
    /// Represents a fully parsed Word field instruction, including its main
    /// instruction keyword (e.g., "MERGEFIELD") and a list of its arguments.
    /// This object can be modified and recompiled back into a field code string.
    /// </summary>
    public class FieldInstruction
    {
        /// <summary>
        /// The primary keyword of the field (e.g., IF, REF, HYPERLINK).
        /// </summary>
        public string Instruction { get; set; }

        /// <summary>
        /// A list of arguments that belong to this instruction.
        /// You can directly manipulate this list (add, remove, replace arguments)
        /// before recompiling the instruction to a string.
        /// </summary>
        public List<FieldArgument> Arguments { get; }

        public FieldInstruction(string instruction)
        {
            if (string.IsNullOrWhiteSpace(instruction))
            {
                throw new ArgumentException(
                    "Instruction cannot be null or empty.",
                    nameof(instruction)
                );
            }
            Instruction = instruction;
            Arguments = new List<FieldArgument>();
        }

        public FieldInstruction(string instruction, List<FieldArgument> arguments)
        {
            Instruction = instruction;
            Arguments = new List<FieldArgument>(arguments);
        }

        /// <summary>
        /// Recompiles the entire FieldInstruction object back into a valid,
        /// standards-compliant field code string.
        /// </summary>
        /// <returns>The reconstructed field code string.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Instruction);

            foreach (FieldArgument arg in Arguments)
            {
                sb.Append(" ");
                sb.Append(arg.ToString());
            }

            return sb.ToString();
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
