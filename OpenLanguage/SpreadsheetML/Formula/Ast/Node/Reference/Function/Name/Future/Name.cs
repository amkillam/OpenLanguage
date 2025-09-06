using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class AcotFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public AcotFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACOT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class AcothFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public AcothFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACOTH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class AggregateFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public AggregateFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AGGREGATE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ArabicFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ArabicFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ARABIC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ArrayToTextFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ArrayToTextFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ARRAYTOTEXT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BaseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BaseFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BASE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BetaDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BETA.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BetaInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BETA.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BinomDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomDistRangeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BinomDistRangeFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.DIST.RANGE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class BinomInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BinomInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitAndFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitAndFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITAND"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitLShiftFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitLShiftFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITLSHIFT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitOrFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitOrFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITOR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitRShiftFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitRShiftFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITRSHIFT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitXorFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitXorFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITXOR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BycolFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BycolFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BYCOL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ByrowFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ByrowFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BYROW"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CeilingMathFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CeilingMathFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CEILING.MATH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CeilingPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CeilingPreciseFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CEILING.PRECISE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ChisqDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqDistRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqDistRtFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.DIST.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqInvRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqInvRtFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.INV.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqTestFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqTestFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.TEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChooseColsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChooseColsFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHOOSECOLS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChooseRowsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChooseRowsFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHOOSEROWS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CombinaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CombinaFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COMBINA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ConfidenceNormFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ConfidenceNormFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONFIDENCE.NORM"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ConfidenceTFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ConfidenceTFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONFIDENCE.T"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CotFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CotFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CothFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CothFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COTH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CovariancePFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CovariancePFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COVARIANCE.P"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CovarianceSFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CovarianceSFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COVARIANCE.S"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CscFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CscFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CSC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CschFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CschFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CSCH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class DaysFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public DaysFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DAYS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class DetectLanguageFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public DetectLanguageFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DETECTLANGUAGE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class DecimalFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public DecimalFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DECIMAL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class DropFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public DropFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DROP"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class EcmaCeilingFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public EcmaCeilingFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ECMA.CEILING"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class EncodeUrlFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public EncodeUrlFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ENCODEURL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfCPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ErfCPreciseFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERFC.PRECISE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class EuroConvertFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public EuroConvertFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EUROCONVERT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ErfPreciseFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERF.PRECISE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ExpandFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ExpandFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXPAND"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ExponDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ExponDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXPON.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FieldValueFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FieldValueFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FIELDVALUE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FilterXmlFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FilterXmlFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILTERXML"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FloorMathFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FloorMathFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FLOOR.MATH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FloorPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FloorPreciseFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FLOOR.PRECISE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastEtsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastEtsFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.ETS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastEtsConfIntFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastEtsConfIntFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORECAST.ETS.CONFINT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ForecastEtsSeasonalityFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastEtsSeasonalityFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORECAST.ETS.SEASONALITY"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ForecastEtsStatFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastEtsStatFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.ETS.STAT"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ForecastLinearFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastLinearFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.LINEAR"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormulaTextFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FormulaTextFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMULATEXT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FDistRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FDistRtFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.DIST.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FInvRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FInvRtFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.INV.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FTestFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FTestFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.TEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GammaFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaLnPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GammaLnPreciseFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMALN.PRECISE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GammaDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GammaDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GammaInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GaussFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GaussFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAUSS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GroupByFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GroupByFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GROUPBY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class HStackFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public HStackFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HSTACK"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class HypGeomDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public HypGeomDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HYPGEOM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImageFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImageFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMAGE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IfNaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IfNaFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IFNA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCoshFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImCoshFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCOSH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCotFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImCotFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCOT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCscFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImCscFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCSC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCschFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImCschFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCSCH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSecFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImSecFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSEC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSechFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImSechFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSECH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSinhFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImSinhFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSINH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImTanFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImTanFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMTAN"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IsFormulaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IsFormulaFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISFORMULA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOmittedFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IsOmittedFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISOMITTED"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOWeekNumFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IsOWeekNumFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISOWEEKNUM"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class JisFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public JisFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("JIS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOCeilingFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IsOCeilingFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISO.CEILING"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class LambdaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public LambdaFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LAMBDA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class LetFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public LetFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LET"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class LogNormDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public LogNormDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGNORM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class LogNormInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public LogNormInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGNORM.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class MakeArrayFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public MakeArrayFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAKEARRAY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class MapFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public MapFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAP"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ModeMultFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ModeMultFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MODE.MULT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ModeSnglFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ModeSnglFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MODE.SNGL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class MUnitFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public MUnitFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MUNIT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NegBinomDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NegBinomDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NEGBINOM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NetworkDaysIntlFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NetworkDaysIntlFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NETWORKDAYS.INTL"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NormDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NormDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NormInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NormInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NormSDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NormSDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.S.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NormSInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NormSInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.S.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NumberValueFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NumberValueFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NUMBERVALUE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PDurationFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PDurationFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PDURATION"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentOfFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentOfFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTOF"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentileExcFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentileExcFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTILE.EXC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PercentileIncFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentileIncFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTILE.INC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PercentRankExcFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentRankExcFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTRANK.EXC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PercentRankIncFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentRankIncFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTRANK.INC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PermutationaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PermutationaFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERMUTATIONA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PhiFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PhiFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PHI"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PivotByFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PivotByFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PIVOTBY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PoissonDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PoissonDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("POISSON.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PqsourceFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PqsourceFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PQSOURCE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonStrFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PythonStrFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.STR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonTypeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PythonTypeFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.TYPE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonTypenameFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PythonTypenameFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.TYPENAME"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class QuartileExcFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public QuartileExcFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUARTILE.EXC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class QuartileIncFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public QuartileIncFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUARTILE.INC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class QueryStringFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public QueryStringFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUERYSTRING"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RandArrayFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public RandArrayFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANDARRAY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RankAvgFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public RankAvgFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANK.AVG"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RankEqFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public RankEqFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANK.EQ"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ReduceFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ReduceFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REDUCE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RriFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public RriFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RRI"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ScanFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ScanFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SCAN"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SecFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SecFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SechFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SechFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SECH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SequenceFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SequenceFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEQUENCE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SheetFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SheetFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHEET"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SheetsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SheetsFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHEETS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SkewPFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SkewPFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SKEW.P"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SortByFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SortByFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SORTBY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevPFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public StDevPFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEV.P"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevSFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public StDevSFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEV.S"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TakeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TakeFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TAKE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TextAfterFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TextAfterFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTAFTER"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TextBeforeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TextBeforeFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTBEFORE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TextSplitFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TextSplitFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTSPLIT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ToColFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ToColFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TOCOL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ToRowFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ToRowFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TOROW"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistTwoTFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TDistTwoTFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST.2T"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TDistRtFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TInvFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TInvToTFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TInvToTFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.INV.2T"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TTestFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TTestFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.TEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class UnicharFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public UnicharFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNICHAR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class UnicodeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public UnicodeFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNICODE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class UniqueFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public UniqueFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNIQUE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class VarPFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public VarPFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VAR.P"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class VarSFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public VarSFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VAR.S"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class VStackFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public VStackFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VSTACK"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WebServiceFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WebServiceFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEBSERVICE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WeibullDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WeibullDistFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEIBULL.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WorkdayIntlFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WorkdayIntlFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WORKDAY.INTL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WrapColsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WrapColsFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WRAPCOLS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WrapRowsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WrapRowsFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WRAPROWS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class XLookupFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public XLookupFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XLOOKUP"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class XorFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public XorFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XOR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ZTestFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ZTestFutureFunctionNode(
            NameNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("Z.TEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }
}
