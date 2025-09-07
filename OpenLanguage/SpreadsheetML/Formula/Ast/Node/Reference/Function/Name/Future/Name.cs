using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class AcotFutureFunctionNode : FutureFunctionNode
    {
        public AcotFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACOT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class AcothFutureFunctionNode : FutureFunctionNode
    {
        public AcothFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACOTH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class AggregateFutureFunctionNode : FutureFunctionNode
    {
        public AggregateFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AGGREGATE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ArabicFutureFunctionNode : FutureFunctionNode
    {
        public ArabicFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ARABIC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ArrayToTextFutureFunctionNode : FutureFunctionNode
    {
        public ArrayToTextFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ARRAYTOTEXT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BaseFutureFunctionNode : FutureFunctionNode
    {
        public BaseFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BASE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaDistFutureFunctionNode : FutureFunctionNode
    {
        public BetaDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BETA.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaInvFutureFunctionNode : FutureFunctionNode
    {
        public BetaInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BETA.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomDistFutureFunctionNode : FutureFunctionNode
    {
        public BinomDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomDistRangeFutureFunctionNode : FutureFunctionNode
    {
        public BinomDistRangeFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.DIST.RANGE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class BinomInvFutureFunctionNode : FutureFunctionNode
    {
        public BinomInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitAndFutureFunctionNode : FutureFunctionNode
    {
        public BitAndFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITAND"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitLShiftFutureFunctionNode : FutureFunctionNode
    {
        public BitLShiftFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITLSHIFT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitOrFutureFunctionNode : FutureFunctionNode
    {
        public BitOrFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITOR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitRShiftFutureFunctionNode : FutureFunctionNode
    {
        public BitRShiftFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITRSHIFT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BitXorFutureFunctionNode : FutureFunctionNode
    {
        public BitXorFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITXOR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class BycolFutureFunctionNode : FutureFunctionNode
    {
        public BycolFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BYCOL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ByrowFutureFunctionNode : FutureFunctionNode
    {
        public ByrowFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BYROW"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CeilingMathFutureFunctionNode : FutureFunctionNode
    {
        public CeilingMathFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CEILING.MATH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CeilingPreciseFutureFunctionNode : FutureFunctionNode
    {
        public CeilingPreciseFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CEILING.PRECISE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ChisqDistFutureFunctionNode : FutureFunctionNode
    {
        public ChisqDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqDistRtFutureFunctionNode : FutureFunctionNode
    {
        public ChisqDistRtFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.DIST.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqInvFutureFunctionNode : FutureFunctionNode
    {
        public ChisqInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqInvRtFutureFunctionNode : FutureFunctionNode
    {
        public ChisqInvRtFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.INV.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqTestFutureFunctionNode : FutureFunctionNode
    {
        public ChisqTestFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.TEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChooseColsFutureFunctionNode : FutureFunctionNode
    {
        public ChooseColsFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHOOSECOLS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ChooseRowsFutureFunctionNode : FutureFunctionNode
    {
        public ChooseRowsFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHOOSEROWS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CombinaFutureFunctionNode : FutureFunctionNode
    {
        public CombinaFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COMBINA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ConfidenceNormFutureFunctionNode : FutureFunctionNode
    {
        public ConfidenceNormFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONFIDENCE.NORM"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ConfidenceTFutureFunctionNode : FutureFunctionNode
    {
        public ConfidenceTFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONFIDENCE.T"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CotFutureFunctionNode : FutureFunctionNode
    {
        public CotFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CothFutureFunctionNode : FutureFunctionNode
    {
        public CothFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COTH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CovariancePFutureFunctionNode : FutureFunctionNode
    {
        public CovariancePFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COVARIANCE.P"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CovarianceSFutureFunctionNode : FutureFunctionNode
    {
        public CovarianceSFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COVARIANCE.S"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CscFutureFunctionNode : FutureFunctionNode
    {
        public CscFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CSC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class CschFutureFunctionNode : FutureFunctionNode
    {
        public CschFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CSCH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class DaysFutureFunctionNode : FutureFunctionNode
    {
        public DaysFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DAYS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class DetectLanguageFutureFunctionNode : FutureFunctionNode
    {
        public DetectLanguageFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DETECTLANGUAGE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DecimalFutureFunctionNode : FutureFunctionNode
    {
        public DecimalFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DECIMAL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class DropFutureFunctionNode : FutureFunctionNode
    {
        public DropFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DROP"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class EcmaCeilingFutureFunctionNode : FutureFunctionNode
    {
        public EcmaCeilingFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ECMA.CEILING"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class EncodeUrlFutureFunctionNode : FutureFunctionNode
    {
        public EncodeUrlFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ENCODEURL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfCPreciseFutureFunctionNode : FutureFunctionNode
    {
        public ErfCPreciseFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERFC.PRECISE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class EuroConvertFutureFunctionNode : FutureFunctionNode
    {
        public EuroConvertFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EUROCONVERT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfPreciseFutureFunctionNode : FutureFunctionNode
    {
        public ErfPreciseFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERF.PRECISE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ExpandFutureFunctionNode : FutureFunctionNode
    {
        public ExpandFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXPAND"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ExponDistFutureFunctionNode : FutureFunctionNode
    {
        public ExponDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXPON.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FieldValueFutureFunctionNode : FutureFunctionNode
    {
        public FieldValueFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FIELDVALUE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FilterXmlFutureFunctionNode : FutureFunctionNode
    {
        public FilterXmlFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILTERXML"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FloorMathFutureFunctionNode : FutureFunctionNode
    {
        public FloorMathFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FLOOR.MATH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FloorPreciseFutureFunctionNode : FutureFunctionNode
    {
        public FloorPreciseFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FLOOR.PRECISE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastEtsFutureFunctionNode : FutureFunctionNode
    {
        public ForecastEtsFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.ETS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastEtsConfIntFutureFunctionNode : FutureFunctionNode
    {
        public ForecastEtsConfIntFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORECAST.ETS.CONFINT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ForecastEtsSeasonalityFutureFunctionNode : FutureFunctionNode
    {
        public ForecastEtsSeasonalityFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode("FORECAST.ETS.SEASONALITY"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ForecastEtsStatFutureFunctionNode : FutureFunctionNode
    {
        public ForecastEtsStatFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.ETS.STAT"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ForecastLinearFutureFunctionNode : FutureFunctionNode
    {
        public ForecastLinearFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.LINEAR"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FormulaTextFutureFunctionNode : FutureFunctionNode
    {
        public FormulaTextFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMULATEXT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FDistFutureFunctionNode : FutureFunctionNode
    {
        public FDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FDistRtFutureFunctionNode : FutureFunctionNode
    {
        public FDistRtFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.DIST.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FInvFutureFunctionNode : FutureFunctionNode
    {
        public FInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FInvRtFutureFunctionNode : FutureFunctionNode
    {
        public FInvRtFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.INV.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class FTestFutureFunctionNode : FutureFunctionNode
    {
        public FTestFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.TEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaFutureFunctionNode : FutureFunctionNode
    {
        public GammaFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaLnPreciseFutureFunctionNode : FutureFunctionNode
    {
        public GammaLnPreciseFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMALN.PRECISE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GammaDistFutureFunctionNode : FutureFunctionNode
    {
        public GammaDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaInvFutureFunctionNode : FutureFunctionNode
    {
        public GammaInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GaussFutureFunctionNode : FutureFunctionNode
    {
        public GaussFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAUSS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class GroupByFutureFunctionNode : FutureFunctionNode
    {
        public GroupByFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GROUPBY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class HStackFutureFunctionNode : FutureFunctionNode
    {
        public HStackFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HSTACK"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class HypGeomDistFutureFunctionNode : FutureFunctionNode
    {
        public HypGeomDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HYPGEOM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImageFutureFunctionNode : FutureFunctionNode
    {
        public ImageFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMAGE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IfNaFutureFunctionNode : FutureFunctionNode
    {
        public IfNaFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IFNA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCoshFutureFunctionNode : FutureFunctionNode
    {
        public ImCoshFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCOSH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCotFutureFunctionNode : FutureFunctionNode
    {
        public ImCotFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCOT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCscFutureFunctionNode : FutureFunctionNode
    {
        public ImCscFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCSC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCschFutureFunctionNode : FutureFunctionNode
    {
        public ImCschFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCSCH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSecFutureFunctionNode : FutureFunctionNode
    {
        public ImSecFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSEC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSechFutureFunctionNode : FutureFunctionNode
    {
        public ImSechFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSECH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSinhFutureFunctionNode : FutureFunctionNode
    {
        public ImSinhFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSINH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ImTanFutureFunctionNode : FutureFunctionNode
    {
        public ImTanFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMTAN"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IsFormulaFutureFunctionNode : FutureFunctionNode
    {
        public IsFormulaFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISFORMULA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOmittedFutureFunctionNode : FutureFunctionNode
    {
        public IsOmittedFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISOMITTED"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOWeekNumFutureFunctionNode : FutureFunctionNode
    {
        public IsOWeekNumFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISOWEEKNUM"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class JisFutureFunctionNode : FutureFunctionNode
    {
        public JisFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("JIS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOCeilingFutureFunctionNode : FutureFunctionNode
    {
        public IsOCeilingFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISO.CEILING"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class LambdaFutureFunctionNode : FutureFunctionNode
    {
        public LambdaFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LAMBDA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class LetFutureFunctionNode : FutureFunctionNode
    {
        public LetFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LET"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class LogNormDistFutureFunctionNode : FutureFunctionNode
    {
        public LogNormDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGNORM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class LogNormInvFutureFunctionNode : FutureFunctionNode
    {
        public LogNormInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGNORM.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class MakeArrayFutureFunctionNode : FutureFunctionNode
    {
        public MakeArrayFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAKEARRAY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class MapFutureFunctionNode : FutureFunctionNode
    {
        public MapFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAP"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ModeMultFutureFunctionNode : FutureFunctionNode
    {
        public ModeMultFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MODE.MULT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ModeSnglFutureFunctionNode : FutureFunctionNode
    {
        public ModeSnglFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MODE.SNGL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class MUnitFutureFunctionNode : FutureFunctionNode
    {
        public MUnitFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MUNIT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NegBinomDistFutureFunctionNode : FutureFunctionNode
    {
        public NegBinomDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NEGBINOM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NetworkDaysIntlFutureFunctionNode : FutureFunctionNode
    {
        public NetworkDaysIntlFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NETWORKDAYS.INTL"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NormDistFutureFunctionNode : FutureFunctionNode
    {
        public NormDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NormInvFutureFunctionNode : FutureFunctionNode
    {
        public NormInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NormSDistFutureFunctionNode : FutureFunctionNode
    {
        public NormSDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.S.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NormSInvFutureFunctionNode : FutureFunctionNode
    {
        public NormSInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.S.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class NumberValueFutureFunctionNode : FutureFunctionNode
    {
        public NumberValueFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NUMBERVALUE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PDurationFutureFunctionNode : FutureFunctionNode
    {
        public PDurationFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PDURATION"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentOfFutureFunctionNode : FutureFunctionNode
    {
        public PercentOfFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTOF"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentileExcFutureFunctionNode : FutureFunctionNode
    {
        public PercentileExcFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTILE.EXC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PercentileIncFutureFunctionNode : FutureFunctionNode
    {
        public PercentileIncFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTILE.INC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PercentRankExcFutureFunctionNode : FutureFunctionNode
    {
        public PercentRankExcFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTRANK.EXC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PercentRankIncFutureFunctionNode : FutureFunctionNode
    {
        public PercentRankIncFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTRANK.INC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PermutationaFutureFunctionNode : FutureFunctionNode
    {
        public PermutationaFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERMUTATIONA"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PhiFutureFunctionNode : FutureFunctionNode
    {
        public PhiFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PHI"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PivotByFutureFunctionNode : FutureFunctionNode
    {
        public PivotByFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PIVOTBY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PoissonDistFutureFunctionNode : FutureFunctionNode
    {
        public PoissonDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("POISSON.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PqsourceFutureFunctionNode : FutureFunctionNode
    {
        public PqsourceFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PQSOURCE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RegexExtractFutureFunctionNode : FutureFunctionNode
    {
        public RegexExtractFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REGEXEXTRACT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RegexReplaceFutureFunctionNode : FutureFunctionNode
    {
        public RegexReplaceFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REGEXREPLACE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RegexTestFutureFunctionNode : FutureFunctionNode
    {
        public RegexTestFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REGEXTEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonStrFutureFunctionNode : FutureFunctionNode
    {
        public PythonStrFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.STR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonTypeFutureFunctionNode : FutureFunctionNode
    {
        public PythonTypeFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.TYPE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonTypenameFutureFunctionNode : FutureFunctionNode
    {
        public PythonTypenameFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.TYPENAME"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class QuartileExcFutureFunctionNode : FutureFunctionNode
    {
        public QuartileExcFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUARTILE.EXC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class QuartileIncFutureFunctionNode : FutureFunctionNode
    {
        public QuartileIncFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUARTILE.INC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class QueryStringFutureFunctionNode : FutureFunctionNode
    {
        public QueryStringFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUERYSTRING"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RandArrayFutureFunctionNode : FutureFunctionNode
    {
        public RandArrayFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANDARRAY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RankAvgFutureFunctionNode : FutureFunctionNode
    {
        public RankAvgFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANK.AVG"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RankEqFutureFunctionNode : FutureFunctionNode
    {
        public RankEqFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANK.EQ"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ReduceFutureFunctionNode : FutureFunctionNode
    {
        public ReduceFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REDUCE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class RriFutureFunctionNode : FutureFunctionNode
    {
        public RriFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RRI"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ScanFutureFunctionNode : FutureFunctionNode
    {
        public ScanFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SCAN"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SecFutureFunctionNode : FutureFunctionNode
    {
        public SecFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEC"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SechFutureFunctionNode : FutureFunctionNode
    {
        public SechFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SECH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SequenceFutureFunctionNode : FutureFunctionNode
    {
        public SequenceFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEQUENCE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SheetFutureFunctionNode : FutureFunctionNode
    {
        public SheetFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHEET"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SheetsFutureFunctionNode : FutureFunctionNode
    {
        public SheetsFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHEETS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SkewPFutureFunctionNode : FutureFunctionNode
    {
        public SkewPFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SKEW.P"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class SortByFutureFunctionNode : FutureFunctionNode
    {
        public SortByFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SORTBY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevPFutureFunctionNode : FutureFunctionNode
    {
        public StDevPFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEV.P"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevSFutureFunctionNode : FutureFunctionNode
    {
        public StDevSFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEV.S"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class StockHistoryFutureFunctionNode : FutureFunctionNode
    {
        public StockHistoryFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STOCKHISTORY"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TakeFutureFunctionNode : FutureFunctionNode
    {
        public TakeFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TAKE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TextAfterFutureFunctionNode : FutureFunctionNode
    {
        public TextAfterFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTAFTER"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TextBeforeFutureFunctionNode : FutureFunctionNode
    {
        public TextBeforeFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTBEFORE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TextSplitFutureFunctionNode : FutureFunctionNode
    {
        public TextSplitFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTSPLIT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ToColFutureFunctionNode : FutureFunctionNode
    {
        public ToColFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TOCOL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ToRowFutureFunctionNode : FutureFunctionNode
    {
        public ToRowFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TOROW"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TranslateFutureFunctionNode : FutureFunctionNode
    {
        public TranslateFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TRANSLATE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TrimRangeFutureFunctionNode : FutureFunctionNode
    {
        public TrimRangeFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TRIMRANGE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistFutureFunctionNode : FutureFunctionNode
    {
        public TDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistTwoTFutureFunctionNode : FutureFunctionNode
    {
        public TDistTwoTFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST.2T"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistRtFutureFunctionNode : FutureFunctionNode
    {
        public TDistRtFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST.RT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TInvFutureFunctionNode : FutureFunctionNode
    {
        public TInvFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.INV"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TInvToTFutureFunctionNode : FutureFunctionNode
    {
        public TInvToTFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.INV.2T"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class TTestFutureFunctionNode : FutureFunctionNode
    {
        public TTestFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.TEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class UnicharFutureFunctionNode : FutureFunctionNode
    {
        public UnicharFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNICHAR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class UnicodeFutureFunctionNode : FutureFunctionNode
    {
        public UnicodeFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNICODE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class UniqueFutureFunctionNode : FutureFunctionNode
    {
        public UniqueFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNIQUE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ValueToTextFutureFunctionNode : FutureFunctionNode
    {
        public ValueToTextFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VALUETOTEXT"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class VarPFutureFunctionNode : FutureFunctionNode
    {
        public VarPFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VAR.P"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class VarSFutureFunctionNode : FutureFunctionNode
    {
        public VarSFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VAR.S"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class VStackFutureFunctionNode : FutureFunctionNode
    {
        public VStackFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VSTACK"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WebServiceFutureFunctionNode : FutureFunctionNode
    {
        public WebServiceFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEBSERVICE"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WeibullDistFutureFunctionNode : FutureFunctionNode
    {
        public WeibullDistFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEIBULL.DIST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WorkdayIntlFutureFunctionNode : FutureFunctionNode
    {
        public WorkdayIntlFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WORKDAY.INTL"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WrapColsFutureFunctionNode : FutureFunctionNode
    {
        public WrapColsFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WRAPCOLS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class WrapRowsFutureFunctionNode : FutureFunctionNode
    {
        public WrapRowsFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WRAPROWS"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class XLookupFutureFunctionNode : FutureFunctionNode
    {
        public XLookupFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XLOOKUP"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class XMatchFutureFunctionNode : FutureFunctionNode
    {
        public XMatchFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XMATCH"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class XorFutureFunctionNode : FutureFunctionNode
    {
        public XorFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XOR"), prefix, leadingWhitespace, trailingWhitespace) { }
    }

    public class ZTestFutureFunctionNode : FutureFunctionNode
    {
        public ZTestFutureFunctionNode(
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("Z.TEST"), prefix, leadingWhitespace, trailingWhitespace) { }
    }
}
