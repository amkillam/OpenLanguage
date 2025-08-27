using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class AcotFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public AcotFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACOT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AcothFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public AcothFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACOTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AggregateFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public AggregateFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AGGREGATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ArabicFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ArabicFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ARABIC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BaseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BaseFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BASE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BetaDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BETA.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BetaInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BETA.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BinomDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomDistRangeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BinomDistRangeFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.DIST.RANGE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BinomInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOM.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BitAndFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitAndFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BitLShiftFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitLShiftFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITLSHIFT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BitOrFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitOrFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITOR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BitRShiftFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitRShiftFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITRSHIFT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BitXorFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BitXorFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BITXOR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BycolFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public BycolFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BYCOL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ByrowFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ByrowFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BYROW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CeilingMathFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CeilingMathFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CEILING.MATH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CeilingPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CeilingPreciseFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CEILING.PRECISE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqDistRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqDistRtFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.DIST.RT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqInvRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqInvRtFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.INV.RT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChisqTestFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChisqTestFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHISQ.TEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChooseColsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChooseColsFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHOOSECOLS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChooseRowsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ChooseRowsFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHOOSEROWS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CombinaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CombinaFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COMBINA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConfidenceNormFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ConfidenceNormFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONFIDENCE.NORM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConfidenceTFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ConfidenceTFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONFIDENCE.T"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CotFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CotFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CothFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CothFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CovariancePFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CovariancePFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COVARIANCE.P"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CovarianceSFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CovarianceSFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COVARIANCE.S"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CscFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CscFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CSC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CschFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public CschFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CSCH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DaysFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public DaysFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DAYS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DecimalFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public DecimalFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DECIMAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DropFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public DropFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DROP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EcmaCeilingFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public EcmaCeilingFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ECMA.CEILING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfCPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ErfCPreciseFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERFC.PRECISE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ErfPreciseFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERF.PRECISE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExpandFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ExpandFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXPAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExponDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ExponDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXPON.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FieldValueFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FieldValueFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FIELDVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FilterXmlFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FilterXmlFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FILTERXML"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FloorMathFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FloorMathFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FLOOR.MATH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FloorPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FloorPreciseFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FLOOR.PRECISE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastEtsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastEtsFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.ETS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastEtsConfIntFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastEtsConfIntFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.ETS.CONFINT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastEtsSeasonalityFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastEtsSeasonalityFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.ETS.SEASONALITY"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ForecastEtsStatFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastEtsStatFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.ETS.STAT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastLinearFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ForecastLinearFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST.LINEAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FormulaTextFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FormulaTextFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORMULATEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FDistRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FDistRtFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.DIST.RT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FInvRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FInvRtFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.INV.RT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FTestFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public FTestFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("F.TEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GammaFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaLnPreciseFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GammaLnPreciseFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMALN.PRECISE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GammaDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GammaInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMA.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GaussFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public GaussFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAUSS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HStackFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public HStackFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HSTACK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HypGeomDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public HypGeomDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HYPGEOM.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IfNaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IfNaFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IFNA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCoshFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImCoshFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCOSH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCotFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImCotFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCOT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCscFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImCscFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCSC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCschFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImCschFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCSCH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSecFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImSecFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSechFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImSechFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSECH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSinhFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImSinhFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSINH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImTanFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ImTanFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMTAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsFormulaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IsFormulaFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISFORMULA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOmittedFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IsOmittedFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISOMITTED"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOWeekNumFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IsOWeekNumFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISOWEEKNUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOCeilingFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public IsOCeilingFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISO.CEILING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LambdaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public LambdaFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LAMBDA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LetFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public LetFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogNormDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public LogNormDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGNORM.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogNormInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public LogNormInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGNORM.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MakeArrayFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public MakeArrayFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAKEARRAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MapFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public MapFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ModeMultFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ModeMultFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MODE.MULT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ModeSnglFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ModeSnglFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MODE.SNGL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MUnitFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public MUnitFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MUNIT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NegBinomDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NegBinomDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NEGBINOM.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NetworkDaysIntlFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NetworkDaysIntlFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NETWORKDAYS.INTL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NormDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NormInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormSDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NormSDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.S.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormSInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NormSInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORM.S.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NumberValueFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public NumberValueFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NUMBERVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PDurationFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PDurationFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PDURATION"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentileExcFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentileExcFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTILE.EXC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentileIncFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentileIncFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTILE.INC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentRankExcFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentRankExcFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTRANK.EXC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentRankIncFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PercentRankIncFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTRANK.INC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PermutationaFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PermutationaFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERMUTATIONA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PhiFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PhiFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PHI"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PoissonDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PoissonDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("POISSON.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PqsourceFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PqsourceFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PQSOURCE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonStrFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PythonStrFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.STR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonTypeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PythonTypeFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.TYPE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PythonTypenameFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public PythonTypenameFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PYTHON.TYPENAME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class QuartileExcFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public QuartileExcFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUARTILE.EXC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class QuartileIncFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public QuartileIncFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUARTILE.INC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class QueryStringFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public QueryStringFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUERYSTRING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RandArrayFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public RandArrayFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANDARRAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RankAvgFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public RankAvgFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANK.AVG"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RankEqFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public RankEqFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANK.EQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReduceFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ReduceFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REDUCE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RriFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public RriFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RRI"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ScanFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ScanFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SCAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SecFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SecFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SechFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SechFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SECH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SequenceFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SequenceFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEQUENCE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SheetFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SheetFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHEET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SheetsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SheetsFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SHEETS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SkewPFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SkewPFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SKEW.P"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SortByFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public SortByFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SORTBY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevPFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public StDevPFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEV.P"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevSFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public StDevSFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEV.S"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TakeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TakeFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TAKE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextAfterFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TextAfterFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTAFTER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextBeforeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TextBeforeFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTBEFORE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextSplitFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TextSplitFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTSPLIT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ToColFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ToColFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TOCOL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ToRowFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ToRowFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TOROW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistTwoTFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TDistTwoTFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST.2T"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistRtFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TDistRtFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.DIST.RT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TInvFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TInvFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.INV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TInvToTFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TInvToTFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.INV.2T"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TTestFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public TTestFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T.TEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UnicharFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public UnicharFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNICHAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UnicodeFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public UnicodeFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNICODE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UniqueFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public UniqueFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UNIQUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarPFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public VarPFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VAR.P"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarSFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public VarSFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VAR.S"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VStackFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public VStackFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VSTACK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WebServiceFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WebServiceFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEBSERVICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WeibullDistFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WeibullDistFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEIBULL.DIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WorkdayIntlFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WorkdayIntlFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WORKDAY.INTL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WrapColsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WrapColsFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WRAPCOLS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WrapRowsFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public WrapRowsFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WRAPROWS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class XLookupFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public XLookupFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XLOOKUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class XorFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public XorFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XOR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ZTestFutureFunctionNode : BuiltInFutureFunctionNode
    {
        public ZTestFutureFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("Z.TEST"), leadingWhitespace, trailingWhitespace) { }
    }
}
