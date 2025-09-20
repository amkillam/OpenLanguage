using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class AcotFutureFunctionNode : FutureFunctionNode
    {
        public AcotFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ACOT"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AcothFutureFunctionNode : FutureFunctionNode
    {
        public AcothFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ACOTH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class AggregateFutureFunctionNode : FutureFunctionNode
    {
        public AggregateFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "AGGREGATE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ArabicFutureFunctionNode : FutureFunctionNode
    {
        public ArabicFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ARABIC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ArrayToTextFutureFunctionNode : FutureFunctionNode
    {
        public ArrayToTextFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ARRAYTOTEXT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class BaseFutureFunctionNode : FutureFunctionNode
    {
        public BaseFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BASE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class BetaDistFutureFunctionNode : FutureFunctionNode
    {
        public BetaDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "BETA.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class BetaInvFutureFunctionNode : FutureFunctionNode
    {
        public BetaInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "BETA.INV"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class BinomDistFutureFunctionNode : FutureFunctionNode
    {
        public BinomDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "BINOM.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class BinomDistRangeFutureFunctionNode : FutureFunctionNode
    {
        public BinomDistRangeFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "BINOM.DIST.RANGE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class BinomInvFutureFunctionNode : FutureFunctionNode
    {
        public BinomInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "BINOM.INV"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class BitAndFutureFunctionNode : FutureFunctionNode
    {
        public BitAndFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BITAND"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class BitLShiftFutureFunctionNode : FutureFunctionNode
    {
        public BitLShiftFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "BITLSHIFT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class BitOrFutureFunctionNode : FutureFunctionNode
    {
        public BitOrFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BITOR"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class BitRShiftFutureFunctionNode : FutureFunctionNode
    {
        public BitRShiftFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "BITRSHIFT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class BitXorFutureFunctionNode : FutureFunctionNode
    {
        public BitXorFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BITXOR"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class BycolFutureFunctionNode : FutureFunctionNode
    {
        public BycolFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BYCOL"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ByrowFutureFunctionNode : FutureFunctionNode
    {
        public ByrowFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BYROW"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CeilingMathFutureFunctionNode : FutureFunctionNode
    {
        public CeilingMathFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CEILING.MATH"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class CeilingPreciseFutureFunctionNode : FutureFunctionNode
    {
        public CeilingPreciseFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CEILING.PRECISE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ChisqDistFutureFunctionNode : FutureFunctionNode
    {
        public ChisqDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHISQ.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ChisqDistRtFutureFunctionNode : FutureFunctionNode
    {
        public ChisqDistRtFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHISQ.DIST.RT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ChisqInvFutureFunctionNode : FutureFunctionNode
    {
        public ChisqInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHISQ.INV"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ChisqInvRtFutureFunctionNode : FutureFunctionNode
    {
        public ChisqInvRtFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHISQ.INV.RT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ChisqTestFutureFunctionNode : FutureFunctionNode
    {
        public ChisqTestFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHISQ.TEST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ChooseColsFutureFunctionNode : FutureFunctionNode
    {
        public ChooseColsFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHOOSECOLS"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ChooseRowsFutureFunctionNode : FutureFunctionNode
    {
        public ChooseRowsFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CHOOSEROWS"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class CombinaFutureFunctionNode : FutureFunctionNode
    {
        public CombinaFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "COMBINA"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ConfidenceNormFutureFunctionNode : FutureFunctionNode
    {
        public ConfidenceNormFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CONFIDENCE.NORM"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ConfidenceTFutureFunctionNode : FutureFunctionNode
    {
        public ConfidenceTFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CONFIDENCE.T"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class CotFutureFunctionNode : FutureFunctionNode
    {
        public CotFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COT"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CothFutureFunctionNode : FutureFunctionNode
    {
        public CothFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COTH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CovariancePFutureFunctionNode : FutureFunctionNode
    {
        public CovariancePFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "COVARIANCE.P"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class CovarianceSFutureFunctionNode : FutureFunctionNode
    {
        public CovarianceSFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "COVARIANCE.S"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class CscFutureFunctionNode : FutureFunctionNode
    {
        public CscFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CSC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CschFutureFunctionNode : FutureFunctionNode
    {
        public CschFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CSCH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DaysFutureFunctionNode : FutureFunctionNode
    {
        public DaysFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DAYS"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class DetectLanguageFutureFunctionNode : FutureFunctionNode
    {
        public DetectLanguageFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DETECTLANGUAGE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class DecimalFutureFunctionNode : FutureFunctionNode
    {
        public DecimalFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "DECIMAL"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class DropFutureFunctionNode : FutureFunctionNode
    {
        public DropFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DROP"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class EcmaCeilingFutureFunctionNode : FutureFunctionNode
    {
        public EcmaCeilingFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ECMA.CEILING"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class EncodeUrlFutureFunctionNode : FutureFunctionNode
    {
        public EncodeUrlFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ENCODEURL"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ErfCPreciseFutureFunctionNode : FutureFunctionNode
    {
        public ErfCPreciseFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ERFC.PRECISE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class EuroConvertFutureFunctionNode : FutureFunctionNode
    {
        public EuroConvertFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "EUROCONVERT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ErfPreciseFutureFunctionNode : FutureFunctionNode
    {
        public ErfPreciseFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ERF.PRECISE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ExpandFutureFunctionNode : FutureFunctionNode
    {
        public ExpandFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EXPAND"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ExponDistFutureFunctionNode : FutureFunctionNode
    {
        public ExponDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "EXPON.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class FieldValueFutureFunctionNode : FutureFunctionNode
    {
        public FieldValueFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FIELDVALUE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class FilterXmlFutureFunctionNode : FutureFunctionNode
    {
        public FilterXmlFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FILTERXML"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class FloorMathFutureFunctionNode : FutureFunctionNode
    {
        public FloorMathFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FLOOR.MATH"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class FloorPreciseFutureFunctionNode : FutureFunctionNode
    {
        public FloorPreciseFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FLOOR.PRECISE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ForecastEtsFutureFunctionNode : FutureFunctionNode
    {
        public ForecastEtsFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORECAST.ETS"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ForecastEtsConfIntFutureFunctionNode : FutureFunctionNode
    {
        public ForecastEtsConfIntFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORECAST.ETS.CONFINT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ForecastEtsSeasonalityFutureFunctionNode : FutureFunctionNode
    {
        public ForecastEtsSeasonalityFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORECAST.ETS.SEASONALITY"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ForecastEtsStatFutureFunctionNode : FutureFunctionNode
    {
        public ForecastEtsStatFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORECAST.ETS.STAT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ForecastLinearFutureFunctionNode : FutureFunctionNode
    {
        public ForecastLinearFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORECAST.LINEAR"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class FormulaTextFutureFunctionNode : FutureFunctionNode
    {
        public FormulaTextFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "FORMULATEXT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class FDistFutureFunctionNode : FutureFunctionNode
    {
        public FDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "F.DIST"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FDistRtFutureFunctionNode : FutureFunctionNode
    {
        public FDistRtFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "F.DIST.RT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class FInvFutureFunctionNode : FutureFunctionNode
    {
        public FInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "F.INV"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class FInvRtFutureFunctionNode : FutureFunctionNode
    {
        public FInvRtFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "F.INV.RT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class FTestFutureFunctionNode : FutureFunctionNode
    {
        public FTestFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "F.TEST"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GammaFutureFunctionNode : FutureFunctionNode
    {
        public GammaFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GAMMA"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GammaLnPreciseFutureFunctionNode : FutureFunctionNode
    {
        public GammaLnPreciseFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GAMMALN.PRECISE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class GammaDistFutureFunctionNode : FutureFunctionNode
    {
        public GammaDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GAMMA.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class GammaInvFutureFunctionNode : FutureFunctionNode
    {
        public GammaInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GAMMA.INV"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class GaussFutureFunctionNode : FutureFunctionNode
    {
        public GaussFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GAUSS"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GroupByFutureFunctionNode : FutureFunctionNode
    {
        public GroupByFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "GROUPBY"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class HStackFutureFunctionNode : FutureFunctionNode
    {
        public HStackFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HSTACK"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class HypGeomDistFutureFunctionNode : FutureFunctionNode
    {
        public HypGeomDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "HYPGEOM.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ImageFutureFunctionNode : FutureFunctionNode
    {
        public ImageFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMAGE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class IfNaFutureFunctionNode : FutureFunctionNode
    {
        public IfNaFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IFNA"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImCoshFutureFunctionNode : FutureFunctionNode
    {
        public ImCoshFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMCOSH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImCotFutureFunctionNode : FutureFunctionNode
    {
        public ImCotFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMCOT"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImCscFutureFunctionNode : FutureFunctionNode
    {
        public ImCscFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMCSC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImCschFutureFunctionNode : FutureFunctionNode
    {
        public ImCschFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMCSCH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImSecFutureFunctionNode : FutureFunctionNode
    {
        public ImSecFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMSEC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImSechFutureFunctionNode : FutureFunctionNode
    {
        public ImSechFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMSECH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImSinhFutureFunctionNode : FutureFunctionNode
    {
        public ImSinhFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMSINH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImTanFutureFunctionNode : FutureFunctionNode
    {
        public ImTanFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMTAN"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class IsFormulaFutureFunctionNode : FutureFunctionNode
    {
        public IsFormulaFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ISFORMULA"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class IsOmittedFutureFunctionNode : FutureFunctionNode
    {
        public IsOmittedFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ISOMITTED"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class IsOWeekNumFutureFunctionNode : FutureFunctionNode
    {
        public IsOWeekNumFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ISOWEEKNUM"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class JisFutureFunctionNode : FutureFunctionNode
    {
        public JisFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "JIS"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class IsOCeilingFutureFunctionNode : FutureFunctionNode
    {
        public IsOCeilingFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "ISO.CEILING"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class LambdaFutureFunctionNode : FutureFunctionNode
    {
        public LambdaFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LAMBDA"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class LetFutureFunctionNode : FutureFunctionNode
    {
        public LetFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LET"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class LogNormDistFutureFunctionNode : FutureFunctionNode
    {
        public LogNormDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "LOGNORM.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class LogNormInvFutureFunctionNode : FutureFunctionNode
    {
        public LogNormInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "LOGNORM.INV"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class MakeArrayFutureFunctionNode : FutureFunctionNode
    {
        public MakeArrayFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MAKEARRAY"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class MapFutureFunctionNode : FutureFunctionNode
    {
        public MapFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MAP"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ModeMultFutureFunctionNode : FutureFunctionNode
    {
        public ModeMultFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MODE.MULT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ModeSnglFutureFunctionNode : FutureFunctionNode
    {
        public ModeSnglFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "MODE.SNGL"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class MUnitFutureFunctionNode : FutureFunctionNode
    {
        public MUnitFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MUNIT"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NegBinomDistFutureFunctionNode : FutureFunctionNode
    {
        public NegBinomDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "NEGBINOM.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class NetworkDaysIntlFutureFunctionNode : FutureFunctionNode
    {
        public NetworkDaysIntlFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "NETWORKDAYS.INTL"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class NormDistFutureFunctionNode : FutureFunctionNode
    {
        public NormDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "NORM.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class NormInvFutureFunctionNode : FutureFunctionNode
    {
        public NormInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "NORM.INV"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class NormSDistFutureFunctionNode : FutureFunctionNode
    {
        public NormSDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "NORM.S.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class NormSInvFutureFunctionNode : FutureFunctionNode
    {
        public NormSInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "NORM.S.INV"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class NumberValueFutureFunctionNode : FutureFunctionNode
    {
        public NumberValueFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "NUMBERVALUE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PDurationFutureFunctionNode : FutureFunctionNode
    {
        public PDurationFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PDURATION"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PercentOfFutureFunctionNode : FutureFunctionNode
    {
        public PercentOfFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PERCENTOF"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PercentileExcFutureFunctionNode : FutureFunctionNode
    {
        public PercentileExcFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PERCENTILE.EXC"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PercentileIncFutureFunctionNode : FutureFunctionNode
    {
        public PercentileIncFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PERCENTILE.INC"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PercentRankExcFutureFunctionNode : FutureFunctionNode
    {
        public PercentRankExcFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PERCENTRANK.EXC"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PercentRankIncFutureFunctionNode : FutureFunctionNode
    {
        public PercentRankIncFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PERCENTRANK.INC"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PermutationaFutureFunctionNode : FutureFunctionNode
    {
        public PermutationaFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PERMUTATIONA"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PhiFutureFunctionNode : FutureFunctionNode
    {
        public PhiFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PHI"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PivotByFutureFunctionNode : FutureFunctionNode
    {
        public PivotByFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PIVOTBY"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PoissonDistFutureFunctionNode : FutureFunctionNode
    {
        public PoissonDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "POISSON.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PqsourceFutureFunctionNode : FutureFunctionNode
    {
        public PqsourceFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PQSOURCE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class RegexExtractFutureFunctionNode : FutureFunctionNode
    {
        public RegexExtractFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "REGEXEXTRACT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class RegexReplaceFutureFunctionNode : FutureFunctionNode
    {
        public RegexReplaceFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "REGEXREPLACE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class RegexTestFutureFunctionNode : FutureFunctionNode
    {
        public RegexTestFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "REGEXTEST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PythonStrFutureFunctionNode : FutureFunctionNode
    {
        public PythonStrFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PYTHON.STR"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PythonTypeFutureFunctionNode : FutureFunctionNode
    {
        public PythonTypeFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PYTHON.TYPE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class PythonTypenameFutureFunctionNode : FutureFunctionNode
    {
        public PythonTypenameFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "PYTHON.TYPENAME"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class QuartileExcFutureFunctionNode : FutureFunctionNode
    {
        public QuartileExcFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "QUARTILE.EXC"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class QuartileIncFutureFunctionNode : FutureFunctionNode
    {
        public QuartileIncFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "QUARTILE.INC"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class QueryStringFutureFunctionNode : FutureFunctionNode
    {
        public QueryStringFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "QUERYSTRING"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class RandArrayFutureFunctionNode : FutureFunctionNode
    {
        public RandArrayFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "RANDARRAY"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class RankAvgFutureFunctionNode : FutureFunctionNode
    {
        public RankAvgFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "RANK.AVG"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class RankEqFutureFunctionNode : FutureFunctionNode
    {
        public RankEqFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "RANK.EQ"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ReduceFutureFunctionNode : FutureFunctionNode
    {
        public ReduceFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "REDUCE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RriFutureFunctionNode : FutureFunctionNode
    {
        public RriFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RRI"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ScanFutureFunctionNode : FutureFunctionNode
    {
        public ScanFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SCAN"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SecFutureFunctionNode : FutureFunctionNode
    {
        public SecFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SEC"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SechFutureFunctionNode : FutureFunctionNode
    {
        public SechFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SECH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SequenceFutureFunctionNode : FutureFunctionNode
    {
        public SequenceFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "SEQUENCE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class SheetFutureFunctionNode : FutureFunctionNode
    {
        public SheetFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHEET"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SheetsFutureFunctionNode : FutureFunctionNode
    {
        public SheetsFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SHEETS"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SkewPFutureFunctionNode : FutureFunctionNode
    {
        public SkewPFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SKEW.P"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class SortByFutureFunctionNode : FutureFunctionNode
    {
        public SortByFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SORTBY"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class StDevPFutureFunctionNode : FutureFunctionNode
    {
        public StDevPFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "STDEV.P"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class StDevSFutureFunctionNode : FutureFunctionNode
    {
        public StDevSFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "STDEV.S"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class StockHistoryFutureFunctionNode : FutureFunctionNode
    {
        public StockHistoryFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "STOCKHISTORY"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class TakeFutureFunctionNode : FutureFunctionNode
    {
        public TakeFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TAKE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class TextAfterFutureFunctionNode : FutureFunctionNode
    {
        public TextAfterFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TEXTAFTER"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class TextBeforeFutureFunctionNode : FutureFunctionNode
    {
        public TextBeforeFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TEXTBEFORE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class TextSplitFutureFunctionNode : FutureFunctionNode
    {
        public TextSplitFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TEXTSPLIT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class ToColFutureFunctionNode : FutureFunctionNode
    {
        public ToColFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TOCOL"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ToRowFutureFunctionNode : FutureFunctionNode
    {
        public ToRowFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TOROW"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class TranslateFutureFunctionNode : FutureFunctionNode
    {
        public TranslateFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TRANSLATE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class TrimRangeFutureFunctionNode : FutureFunctionNode
    {
        public TrimRangeFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "TRIMRANGE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class TDistFutureFunctionNode : FutureFunctionNode
    {
        public TDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "T.DIST"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class TDistTwoTFutureFunctionNode : FutureFunctionNode
    {
        public TDistTwoTFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "T.DIST.2T"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class TDistRtFutureFunctionNode : FutureFunctionNode
    {
        public TDistRtFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "T.DIST.RT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class TInvFutureFunctionNode : FutureFunctionNode
    {
        public TInvFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "T.INV"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class TInvToTFutureFunctionNode : FutureFunctionNode
    {
        public TInvToTFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "T.INV.2T"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class TTestFutureFunctionNode : FutureFunctionNode
    {
        public TTestFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "T.TEST"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class UnicharFutureFunctionNode : FutureFunctionNode
    {
        public UnicharFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "UNICHAR"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class UnicodeFutureFunctionNode : FutureFunctionNode
    {
        public UnicodeFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "UNICODE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class UniqueFutureFunctionNode : FutureFunctionNode
    {
        public UniqueFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "UNIQUE"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ValueToTextFutureFunctionNode : FutureFunctionNode
    {
        public ValueToTextFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "VALUETOTEXT"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class VarPFutureFunctionNode : FutureFunctionNode
    {
        public VarPFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VAR.P"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class VarSFutureFunctionNode : FutureFunctionNode
    {
        public VarSFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VAR.S"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class VStackFutureFunctionNode : FutureFunctionNode
    {
        public VStackFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VSTACK"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class WebServiceFutureFunctionNode : FutureFunctionNode
    {
        public WebServiceFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WEBSERVICE"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class WeibullDistFutureFunctionNode : FutureFunctionNode
    {
        public WeibullDistFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WEIBULL.DIST"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class WorkdayIntlFutureFunctionNode : FutureFunctionNode
    {
        public WorkdayIntlFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WORKDAY.INTL"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class WrapColsFutureFunctionNode : FutureFunctionNode
    {
        public WrapColsFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WRAPCOLS"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class WrapRowsFutureFunctionNode : FutureFunctionNode
    {
        public WrapRowsFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "WRAPROWS"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class XLookupFutureFunctionNode : FutureFunctionNode
    {
        public XLookupFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "XLOOKUP"),
                prefix,
                leadingWhitespace,
                trailingWhitespace
            ) { }
    }

    public class XMatchFutureFunctionNode : FutureFunctionNode
    {
        public XMatchFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "XMATCH"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class XorFutureFunctionNode : FutureFunctionNode
    {
        public XorFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "XOR"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ZTestFutureFunctionNode : FutureFunctionNode
    {
        public ZTestFutureFunctionNode(
            string? rawName = null,
            XlfnFunctionPrefixNode? prefix = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "Z.TEST"), prefix, leadingWhitespace, trailingWhitespace)
        { }
    }
}
