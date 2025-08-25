using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class AbsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AbsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ABS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AccrIntStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AccrIntStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACCRINT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AccrIntMStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AccrIntMStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACCRINTM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AcosStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AcosStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACOS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AcoshStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AcoshStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ACOSH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddressStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AddressStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ADDRESS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AmorDegrCStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AmorDegrCStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AMORDEGRC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AmorLinCStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AmorLinCStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AMORLINC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AndStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AndStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AreasStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AreasStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AREAS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AscStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AscStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ASC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AsinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AsinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ASIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AsinhStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AsinhStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ASINH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AtanStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AtanStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ATAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AtanToStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AtanToStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ATAN2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AtanhStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AtanhStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ATANH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AveDevStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AveDevStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AVEDEV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AverageStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AverageStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AVERAGE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AverageAStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AverageAStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AVERAGEA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AverageIfStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AverageIfStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AVERAGEIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AverageIfsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public AverageIfsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("AVERAGEIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BahtTextStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BahtTextStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BAHTTEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BesseliStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BesseliStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BESSELI"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BesseljStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BesseljStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BESSELJ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BesselkStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BesselkStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BESSELK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BesselyStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BesselyStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BESSELY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BetaDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BETADIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BetaInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BETAINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinToDecStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BinToDecStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BIN2DEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinToHexStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BinToHexStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BIN2HEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinToOctStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BinToOctStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BIN2OCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public BinomDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("BINOMDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CeilingStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CeilingStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CEILING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CellStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CellStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CELL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CharStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CharStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChiDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ChiDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHIDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChiInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ChiInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHIINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChiTestStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ChiTestStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHITEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChooseStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ChooseStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CHOOSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CleanStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CleanStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CLEAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CodeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CodeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CODE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ColumnStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ColumnStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COLUMN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ColumnsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ColumnsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COLUMNS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CombinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CombinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COMBIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ComplexStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ComplexStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COMPLEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConcatStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ConcatStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONCAT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConcatenateStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ConcatenateStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONCATENATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConfidenceStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ConfidenceStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONFIDENCE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConvertStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ConvertStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CONVERT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CorrelStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CorrelStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CORREL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CosStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CosStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoshStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CoshStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COSH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CountStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUNT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountAStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CountAStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUNTA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountBlankStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CountBlankStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUNTBLANK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountIfStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CountIfStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUNTIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountIfsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CountIfsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUNTIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupDayBsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CoupDayBsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUPDAYBS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupDaysStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CoupDaysStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUPDAYS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupDaysNcStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CoupDaysNcStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUPDAYSNC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupNcdStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CoupNcdStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUPNCD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupNumStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CoupNumStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUPNUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupPcdStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CoupPcdStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COUPPCD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CovarStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CovarStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("COVAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CritBinomStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CritBinomStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CRITBINOM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeKpimemberStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CubeKpimemberStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUBEKPIMEMBER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeMemberStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CubeMemberStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUBEMEMBER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeMemberpropertyStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CubeMemberpropertyStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUBEMEMBERPROPERTY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeRankedmemberStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CubeRankedmemberStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUBERANKEDMEMBER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeSetStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CubeSetStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUBESET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeSetcountStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CubeSetcountStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUBESETCOUNT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeValueStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CubeValueStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUBEVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CumIpmtStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CumIpmtStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUMIPMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CumPrIncStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public CumPrIncStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("CUMPRINC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DateStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DateStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DatedIfStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DatedIfStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATEDIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DateStringStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DateStringStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATESTRING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DateValueStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DateValueStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DATEVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DAverageStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DAverageStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DAVERAGE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DayStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DayStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class Days360StandardFunctionNode : BuiltInStandardFunctionNode
    {
        public Days360StandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DAYS360"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DBStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DBStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DBCSStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DBCSStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DBCS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DCountStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DCountStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DCOUNT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DCountAStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DCountAStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DCOUNTA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DDBStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DDBStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DDB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DecToBinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DecToBinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DEC2BIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DecToHexStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DecToHexStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DEC2HEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DecToOctStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DecToOctStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DEC2OCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DegreesStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DegreesStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DEGREES"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeltaStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DeltaStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DELTA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DevSqStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DevSqStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DEVSQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DGetStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DGetStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DGET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DiscStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DiscStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DISC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DMaxStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DMaxStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DMAX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DMinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DMinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DMIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DollarStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DollarStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DOLLAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DollarDeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DollarDeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DOLLARDE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DollarFrStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DollarFrStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DOLLARFR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DProductStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DProductStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DPRODUCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DStdDevStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DStdDevStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DSTDEV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DStdDevPStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DStdDevPStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DSTDEVP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DSumStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DSumStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DSUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DurationStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DurationStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DURATION"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DVarStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DVarStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DVAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DVarPStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public DVarPStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("DVARP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EDateStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public EDateStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EDATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EffectStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public EffectStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EFFECT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EOMonthStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public EOMonthStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EOMONTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ErfStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfCStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ErfCStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERFC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErrorTypeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ErrorTypeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ERROR.TYPE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EvenStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public EvenStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EVEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExactStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ExactStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXACT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExpStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ExpStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExponDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ExponDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("EXPONDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FactStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FactStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FACT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FactDoubleStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FactDoubleStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FACTDOUBLE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FindStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FindStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FIND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FindBStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FindBStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FINDB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FisherStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FisherStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FISHER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FisherInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FisherInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FISHERINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FixedStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FixedStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FIXED"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FloorStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FloorStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FLOOR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ForecastStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FORECAST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FrequencyStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FrequencyStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FREQUENCY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FTestStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FTestStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FTEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FvScheduleStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public FvScheduleStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("FVSCHEDULE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public GammaDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMADIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public GammaInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMAINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaLnStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public GammaLnStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GAMMALN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GcdStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public GcdStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GCD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GeoMeanStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public GeoMeanStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GEOMEAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GeStepStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public GeStepStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GESTEP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetPivotDataStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public GetPivotDataStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GETPIVOTDATA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GrowthStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public GrowthStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("GROWTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HarMeanStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public HarMeanStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HARMEAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HexToBinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public HexToBinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HEX2BIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HexToDecStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public HexToDecStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HEX2DEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HexToOctStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public HexToOctStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HEX2OCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HLookupStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public HLookupStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HLOOKUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HourStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public HourStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HOUR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HyperlinkStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public HyperlinkStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HYPERLINK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HypGeomDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public HypGeomDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("HYPGEOMDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IfStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IfStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IfErrorStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IfErrorStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IFERROR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IfsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IfsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImAbsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImAbsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMABS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImAginaryStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImAginaryStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMAGINARY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImArgumentStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImArgumentStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMARGUMENT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImConjugateStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImConjugateStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCONJUGATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImCosStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImCosStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMCOS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImDivStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImDivStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMDIV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImExpStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImExpStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMEXP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImLnStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImLnStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMLN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImLog10StandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImLog10StandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMLOG10"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImLogToStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImLogToStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMLOG2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImPowerStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImPowerStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMPOWER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImProductStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImProductStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMPRODUCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImRealStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImRealStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMREAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImSinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSqrtStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImSqrtStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSQRT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSubStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImSubStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSUB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSumStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ImSumStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IMSUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IndexStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IndexStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INDEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IndirectStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IndirectStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INDIRECT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class InfoStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public InfoStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INFO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IntStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IntStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class InterceptStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public InterceptStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INTERCEPT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IntrateStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IntrateStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("INTRATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IpmtStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IpmtStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IPMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IrrStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IrrStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("IRR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsBlankStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsBlankStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISBLANK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsErrStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsErrStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISERR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsErrorStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsErrorStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISERROR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsEvenStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsEvenStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISEVEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsLogicalStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsLogicalStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISLOGICAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsNaStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsNaStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISNA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsNontextStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsNontextStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISNONTEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsNumberStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsNumberStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISNUMBER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOddStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsOddStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISODD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsPmtStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsPmtStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISPMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsRefStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsRefStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsTextStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsTextStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISTEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsThaiDigitStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public IsThaiDigitStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ISTHAIDIGIT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class KurtStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public KurtStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("KURT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LargeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LargeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LARGE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LcmStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LcmStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LCM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LeftStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LeftStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LEFT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LeftbStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LeftbStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LEFTB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LenStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LenStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LenbStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LenbStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LENB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LinestStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LinestStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LINEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LnStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LnStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LogStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOG"), leadingWhitespace, trailingWhitespace) { }
    }

    public class Log10StandardFunctionNode : BuiltInStandardFunctionNode
    {
        public Log10StandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOG10"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogestStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LogestStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LogInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogNormDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LogNormDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOGNORMDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LookupStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LookupStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOOKUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LowerStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public LowerStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("LOWER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MatchStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MatchStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MATCH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MaxStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MaxStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MaxaStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MaxaStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAXA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MaxifsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MaxifsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MAXIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MdetermStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MdetermStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MDETERM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MdurationStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MdurationStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MDURATION"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MedianStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MedianStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MEDIAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MidStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MidStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MID"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MidbStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MidbStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MIDB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinaStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MinaStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MINA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinifsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MinifsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MINIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinuteStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MinuteStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MINUTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinverseStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MinverseStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MINVERSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MirrStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MirrStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MIRR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MmultStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MmultStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MMULT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ModStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ModStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MOD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ModeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ModeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MODE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MonthStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MonthStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MONTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MroundStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MroundStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MROUND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MultinomialStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public MultinomialStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("MULTINOMIAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("N"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NaStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NaStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NegBinomDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NegBinomDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NEGBINOMDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NetworkDaysStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NetworkDaysStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NETWORKDAYS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NominalStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NominalStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NOMINAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NormDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORMDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NormInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORMINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormsDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NormsDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORMSDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormsInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NormsInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NORMSINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NotStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NotStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NOT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NowStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NowStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NOW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NperStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NperStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NPER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NpvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NpvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NPV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NumberStringStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public NumberStringStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("NUMBERSTRING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OctToBinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OctToBinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OCT2BIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OctToDecStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OctToDecStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OCT2DEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OctToHexStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OctToHexStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OCT2HEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OddStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ODD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddFPriceStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OddFPriceStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ODDFPRICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddFYieldStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OddFYieldStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ODDFYIELD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddLPriceStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OddLPriceStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ODDLPRICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddLYieldStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OddLYieldStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ODDLYIELD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OffsetStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OffsetStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OFFSET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OrStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public OrStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("OR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PearsonStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PearsonStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PEARSON"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentileStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PercentileStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTILE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentRankStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PercentRankStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERCENTRANK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PermutStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PermutStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PERMUT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PhoneticStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PhoneticStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PHONETIC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PiStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PiStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PI"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PmtStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PmtStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PoissonStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PoissonStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("POISSON"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PowerStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PowerStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("POWER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PpmtStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PpmtStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PPMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PriceStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PriceStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PRICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PricediscStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PricediscStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PRICEDISC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PricematStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PricematStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PRICEMAT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ProbStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ProbStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PROB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ProductStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ProductStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PRODUCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ProperStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ProperStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PROPER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public PvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("PV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class QuartileStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public QuartileStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUARTILE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class QuotientStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public QuotientStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("QUOTIENT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RadiansStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RadiansStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RADIANS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RandStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RandStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RandbetweenStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RandbetweenStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANDBETWEEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RankStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RankStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RANK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RateStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RateStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReceivedStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ReceivedStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RECEIVED"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReplaceStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ReplaceStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REPLACE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReplacebStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ReplacebStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REPLACEB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReptStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ReptStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("REPT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RightStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RightStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RIGHT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RightbStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RightbStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RIGHTB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RomanStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RomanStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROMAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RoundStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RoundStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROUND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RoundBahtDownStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RoundBahtDownStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROUNDBAHTDOWN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RoundBahtUpStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RoundBahtUpStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROUNDBAHTUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RoundDownStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RoundDownStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROUNDDOWN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RoundUpStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RoundUpStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROUNDUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RowStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RowStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RowsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RowsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ROWS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RsqStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RsqStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RSQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RtdStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public RtdStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("RTD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SearchStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SearchStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEARCH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SearchbStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SearchbStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SEARCHB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SecondStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SecondStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SECOND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SeriesStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SeriesStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SERIES"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SeriessumStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SeriessumStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SERIESSUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SignStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SignStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SIGN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SinhStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SinhStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SINH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SkewStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SkewStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SKEW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SlnStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SlnStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SLN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SlopeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SlopeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SLOPE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SmallStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SmallStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SMALL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SqrtStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SqrtStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SQRT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SqrtpiStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SqrtpiStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SQRTPI"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StandardizeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public StandardizeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STANDARDIZE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public StDevStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevAStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public StDevAStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEVA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevPStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public StDevPStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEVP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevPaStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public StDevPaStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STDEVPA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SteyxStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SteyxStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("STEYX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SubstituteStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SubstituteStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUBSTITUTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SubtotalStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SubtotalStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUBTOTAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SumStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumIfStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SumIfStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUMIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumIfsStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SumIfsStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUMIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumProductStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SumProductStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUMPRODUCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumSqStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SumSqStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUMSQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumXToMyToStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SumXToMyToStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUMX2MY2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumXToPyToStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SumXToPyToStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUMX2PY2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumXMyToStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SumXMyToStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SUMXMY2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SwitchStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SwitchStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SWITCH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SydStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public SydStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("SYD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("T"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TanStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TanStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TanhStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TanhStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TANH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TBillEqStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TBillEqStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TBILLEQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TBillPriceStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TBillPriceStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TBILLPRICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TBillYieldStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TBillYieldStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TBILLYIELD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TDistStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TextStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextJoinStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TextJoinStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TEXTJOIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiDayOfWeekStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ThaiDayOfWeekStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("THAIDAYOFWEEK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiDigitStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ThaiDigitStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("THAIDIGIT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiMonthOfYearStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ThaiMonthOfYearStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("THAIMONTHOfYear"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiNumSoundStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ThaiNumSoundStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("THAINUMSOUND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiNumStringStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ThaiNumStringStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("THAINUMSTRING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiStringLengthStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ThaiStringLengthStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("THAISTRINGLENGTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiYearStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ThaiYearStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("THAIYEAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TimeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TimeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TIME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TimeValueStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TimeValueStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TIMEVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TInvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TInvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TodayStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TodayStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TODAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TransposeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TransposeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TRANSPOSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TrendStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TrendStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TREND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TrimStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TrimStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TRIM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TrimMeanStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TrimMeanStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TRIMMEAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TruncStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TruncStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TRUNC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TTestStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TTestStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TTEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TypeStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public TypeStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("TYPE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UpperStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public UpperStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("UPPER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UsDollarStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public UsDollarStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("USDOLLAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ValueStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ValueStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public VarStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarAStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public VarAStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VARA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarPStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public VarPStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VARP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarPaStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public VarPaStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VARPA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VdbStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public VdbStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VDB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VLookupStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public VLookupStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("VLOOKUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WeekdayStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public WeekdayStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEEKDAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WeekNumStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public WeekNumStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEEKNUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WeibullStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public WeibullStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WEIBULL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WorkdayStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public WorkdayStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("WORKDAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class XirrStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public XirrStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XIRR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class XnpvStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public XnpvStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("XNPV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YearStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public YearStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("YEAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YearFracStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public YearFracStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("YEARFRAC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YieldStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public YieldStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("YIELD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YieldDiscStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public YieldDiscStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("YIELDDISC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YieldMatStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public YieldMatStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("YIELDMAT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ZTestStandardFunctionNode : BuiltInStandardFunctionNode
    {
        public ZTestStandardFunctionNode(
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode("ZTEST"), leadingWhitespace, trailingWhitespace) { }
    }
}
