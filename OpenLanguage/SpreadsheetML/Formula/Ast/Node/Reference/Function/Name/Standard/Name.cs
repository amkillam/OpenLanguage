using System.Collections.Generic;

namespace OpenLanguage.SpreadsheetML.Formula.Ast
{
    public class AbsStandardFunctionNode : StandardFunctionNode
    {
        public AbsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ABS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AccrIntStandardFunctionNode : StandardFunctionNode
    {
        public AccrIntStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ACCRINT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AccrIntMStandardFunctionNode : StandardFunctionNode
    {
        public AccrIntMStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ACCRINTM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AcosStandardFunctionNode : StandardFunctionNode
    {
        public AcosStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ACOS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AcoshStandardFunctionNode : StandardFunctionNode
    {
        public AcoshStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ACOSH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AddressStandardFunctionNode : StandardFunctionNode
    {
        public AddressStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ADDRESS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AmorDegrCStandardFunctionNode : StandardFunctionNode
    {
        public AmorDegrCStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AMORDEGRC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AmorLinCStandardFunctionNode : StandardFunctionNode
    {
        public AmorLinCStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AMORLINC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AndStandardFunctionNode : StandardFunctionNode
    {
        public AndStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AreasStandardFunctionNode : StandardFunctionNode
    {
        public AreasStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AREAS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AscStandardFunctionNode : StandardFunctionNode
    {
        public AscStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ASC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AsinStandardFunctionNode : StandardFunctionNode
    {
        public AsinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ASIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AsinhStandardFunctionNode : StandardFunctionNode
    {
        public AsinhStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ASINH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AtanStandardFunctionNode : StandardFunctionNode
    {
        public AtanStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ATAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AtanToStandardFunctionNode : StandardFunctionNode
    {
        public AtanToStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ATAN2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AtanhStandardFunctionNode : StandardFunctionNode
    {
        public AtanhStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ATANH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AveDevStandardFunctionNode : StandardFunctionNode
    {
        public AveDevStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AVEDEV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AverageStandardFunctionNode : StandardFunctionNode
    {
        public AverageStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AVERAGE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AverageAStandardFunctionNode : StandardFunctionNode
    {
        public AverageAStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AVERAGEA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AverageIfStandardFunctionNode : StandardFunctionNode
    {
        public AverageIfStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AVERAGEIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class AverageIfsStandardFunctionNode : StandardFunctionNode
    {
        public AverageIfsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "AVERAGEIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BahtTextStandardFunctionNode : StandardFunctionNode
    {
        public BahtTextStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BAHTTEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BesseliStandardFunctionNode : StandardFunctionNode
    {
        public BesseliStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BESSELI"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BesseljStandardFunctionNode : StandardFunctionNode
    {
        public BesseljStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BESSELJ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BesselkStandardFunctionNode : StandardFunctionNode
    {
        public BesselkStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BESSELK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BesselyStandardFunctionNode : StandardFunctionNode
    {
        public BesselyStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BESSELY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaDistStandardFunctionNode : StandardFunctionNode
    {
        public BetaDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BETADIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BetaInvStandardFunctionNode : StandardFunctionNode
    {
        public BetaInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BETAINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinToDecStandardFunctionNode : StandardFunctionNode
    {
        public BinToDecStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BIN2DEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinToHexStandardFunctionNode : StandardFunctionNode
    {
        public BinToHexStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BIN2HEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinToOctStandardFunctionNode : StandardFunctionNode
    {
        public BinToOctStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BIN2OCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class BinomDistStandardFunctionNode : StandardFunctionNode
    {
        public BinomDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "BINOMDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CeilingStandardFunctionNode : StandardFunctionNode
    {
        public CeilingStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CEILING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CellStandardFunctionNode : StandardFunctionNode
    {
        public CellStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CELL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CharStandardFunctionNode : StandardFunctionNode
    {
        public CharStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CHAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChiDistStandardFunctionNode : StandardFunctionNode
    {
        public ChiDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CHIDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChiInvStandardFunctionNode : StandardFunctionNode
    {
        public ChiInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CHIINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChiTestStandardFunctionNode : StandardFunctionNode
    {
        public ChiTestStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CHITEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ChooseStandardFunctionNode : StandardFunctionNode
    {
        public ChooseStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CHOOSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CleanStandardFunctionNode : StandardFunctionNode
    {
        public CleanStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CLEAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CodeStandardFunctionNode : StandardFunctionNode
    {
        public CodeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CODE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ColumnStandardFunctionNode : StandardFunctionNode
    {
        public ColumnStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COLUMN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ColumnsStandardFunctionNode : StandardFunctionNode
    {
        public ColumnsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COLUMNS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CombinStandardFunctionNode : StandardFunctionNode
    {
        public CombinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COMBIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ComplexStandardFunctionNode : StandardFunctionNode
    {
        public ComplexStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COMPLEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConcatStandardFunctionNode : StandardFunctionNode
    {
        public ConcatStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CONCAT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConcatenateStandardFunctionNode : StandardFunctionNode
    {
        public ConcatenateStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CONCATENATE"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ConfidenceStandardFunctionNode : StandardFunctionNode
    {
        public ConfidenceStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CONFIDENCE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ConvertStandardFunctionNode : StandardFunctionNode
    {
        public ConvertStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CONVERT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CorrelStandardFunctionNode : StandardFunctionNode
    {
        public CorrelStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CORREL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CosStandardFunctionNode : StandardFunctionNode
    {
        public CosStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoshStandardFunctionNode : StandardFunctionNode
    {
        public CoshStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COSH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountStandardFunctionNode : StandardFunctionNode
    {
        public CountStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUNT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountAStandardFunctionNode : StandardFunctionNode
    {
        public CountAStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUNTA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountBlankStandardFunctionNode : StandardFunctionNode
    {
        public CountBlankStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUNTBLANK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountIfStandardFunctionNode : StandardFunctionNode
    {
        public CountIfStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUNTIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CountIfsStandardFunctionNode : StandardFunctionNode
    {
        public CountIfsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUNTIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupDayBsStandardFunctionNode : StandardFunctionNode
    {
        public CoupDayBsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUPDAYBS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupDaysStandardFunctionNode : StandardFunctionNode
    {
        public CoupDaysStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUPDAYS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupDaysNcStandardFunctionNode : StandardFunctionNode
    {
        public CoupDaysNcStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUPDAYSNC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupNcdStandardFunctionNode : StandardFunctionNode
    {
        public CoupNcdStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUPNCD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupNumStandardFunctionNode : StandardFunctionNode
    {
        public CoupNumStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUPNUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CoupPcdStandardFunctionNode : StandardFunctionNode
    {
        public CoupPcdStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COUPPCD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CovarStandardFunctionNode : StandardFunctionNode
    {
        public CovarStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "COVAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CritBinomStandardFunctionNode : StandardFunctionNode
    {
        public CritBinomStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CRITBINOM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeKpimemberStandardFunctionNode : StandardFunctionNode
    {
        public CubeKpimemberStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUBEKPIMEMBER"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CubeMemberStandardFunctionNode : StandardFunctionNode
    {
        public CubeMemberStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUBEMEMBER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeMemberpropertyStandardFunctionNode : StandardFunctionNode
    {
        public CubeMemberpropertyStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CUBEMEMBERPROPERTY"),
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CubeRankedmemberStandardFunctionNode : StandardFunctionNode
    {
        public CubeRankedmemberStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "CUBERANKEDMEMBER"),
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class CubeSetStandardFunctionNode : StandardFunctionNode
    {
        public CubeSetStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUBESET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CubeSetcountStandardFunctionNode : StandardFunctionNode
    {
        public CubeSetcountStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUBESETCOUNT"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class CubeValueStandardFunctionNode : StandardFunctionNode
    {
        public CubeValueStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUBEVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CumIpmtStandardFunctionNode : StandardFunctionNode
    {
        public CumIpmtStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUMIPMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class CumPrIncStandardFunctionNode : StandardFunctionNode
    {
        public CumPrIncStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "CUMPRINC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DateStandardFunctionNode : StandardFunctionNode
    {
        public DateStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DatedIfStandardFunctionNode : StandardFunctionNode
    {
        public DatedIfStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATEDIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DateStringStandardFunctionNode : StandardFunctionNode
    {
        public DateStringStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATESTRING"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DateValueStandardFunctionNode : StandardFunctionNode
    {
        public DateValueStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DATEVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DAverageStandardFunctionNode : StandardFunctionNode
    {
        public DAverageStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DAVERAGE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DayStandardFunctionNode : StandardFunctionNode
    {
        public DayStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class Days360StandardFunctionNode : StandardFunctionNode
    {
        public Days360StandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DAYS360"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DBStandardFunctionNode : StandardFunctionNode
    {
        public DBStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DBCSStandardFunctionNode : StandardFunctionNode
    {
        public DBCSStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DBCS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DCountStandardFunctionNode : StandardFunctionNode
    {
        public DCountStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DCOUNT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DCountAStandardFunctionNode : StandardFunctionNode
    {
        public DCountAStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DCOUNTA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DDBStandardFunctionNode : StandardFunctionNode
    {
        public DDBStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DDB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DecToBinStandardFunctionNode : StandardFunctionNode
    {
        public DecToBinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DEC2BIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DecToHexStandardFunctionNode : StandardFunctionNode
    {
        public DecToHexStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DEC2HEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DecToOctStandardFunctionNode : StandardFunctionNode
    {
        public DecToOctStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DEC2OCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DegreesStandardFunctionNode : StandardFunctionNode
    {
        public DegreesStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DEGREES"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DeltaStandardFunctionNode : StandardFunctionNode
    {
        public DeltaStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DELTA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DevSqStandardFunctionNode : StandardFunctionNode
    {
        public DevSqStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DEVSQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DGetStandardFunctionNode : StandardFunctionNode
    {
        public DGetStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DGET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DiscStandardFunctionNode : StandardFunctionNode
    {
        public DiscStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DISC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DMaxStandardFunctionNode : StandardFunctionNode
    {
        public DMaxStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DMAX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DMinStandardFunctionNode : StandardFunctionNode
    {
        public DMinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DMIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DollarStandardFunctionNode : StandardFunctionNode
    {
        public DollarStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DOLLAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DollarDeStandardFunctionNode : StandardFunctionNode
    {
        public DollarDeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DOLLARDE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DollarFrStandardFunctionNode : StandardFunctionNode
    {
        public DollarFrStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DOLLARFR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DProductStandardFunctionNode : StandardFunctionNode
    {
        public DProductStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DPRODUCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DStdDevStandardFunctionNode : StandardFunctionNode
    {
        public DStdDevStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DSTDEV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DStdDevPStandardFunctionNode : StandardFunctionNode
    {
        public DStdDevPStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DSTDEVP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DSumStandardFunctionNode : StandardFunctionNode
    {
        public DSumStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DSUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DurationStandardFunctionNode : StandardFunctionNode
    {
        public DurationStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DURATION"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DVarStandardFunctionNode : StandardFunctionNode
    {
        public DVarStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DVAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class DVarPStandardFunctionNode : StandardFunctionNode
    {
        public DVarPStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "DVARP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EDateStandardFunctionNode : StandardFunctionNode
    {
        public EDateStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EDATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EffectStandardFunctionNode : StandardFunctionNode
    {
        public EffectStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EFFECT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EOMonthStandardFunctionNode : StandardFunctionNode
    {
        public EOMonthStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EOMONTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfStandardFunctionNode : StandardFunctionNode
    {
        public ErfStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ERF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErfCStandardFunctionNode : StandardFunctionNode
    {
        public ErfCStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ERFC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ErrorTypeStandardFunctionNode : StandardFunctionNode
    {
        public ErrorTypeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ERROR.TYPE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class EvenStandardFunctionNode : StandardFunctionNode
    {
        public EvenStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EVEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExactStandardFunctionNode : StandardFunctionNode
    {
        public ExactStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EXACT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExpStandardFunctionNode : StandardFunctionNode
    {
        public ExpStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EXP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ExponDistStandardFunctionNode : StandardFunctionNode
    {
        public ExponDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "EXPONDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FactStandardFunctionNode : StandardFunctionNode
    {
        public FactStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FACT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FactDoubleStandardFunctionNode : StandardFunctionNode
    {
        public FactDoubleStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FACTDOUBLE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FalseStandardFunctionNode : StandardFunctionNode
    {
        public FalseStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FALSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FDistStandardFunctionNode : StandardFunctionNode
    {
        public FDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FindStandardFunctionNode : StandardFunctionNode
    {
        public FindStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FIND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FindBStandardFunctionNode : StandardFunctionNode
    {
        public FindBStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FINDB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FInvStandardFunctionNode : StandardFunctionNode
    {
        public FInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FisherStandardFunctionNode : StandardFunctionNode
    {
        public FisherStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FISHER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FisherInvStandardFunctionNode : StandardFunctionNode
    {
        public FisherInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FISHERINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FixedStandardFunctionNode : StandardFunctionNode
    {
        public FixedStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FIXED"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FloorStandardFunctionNode : StandardFunctionNode
    {
        public FloorStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FLOOR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ForecastStandardFunctionNode : StandardFunctionNode
    {
        public ForecastStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FORECAST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FrequencyStandardFunctionNode : StandardFunctionNode
    {
        public FrequencyStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FREQUENCY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FTestStandardFunctionNode : StandardFunctionNode
    {
        public FTestStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FTEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FvStandardFunctionNode : StandardFunctionNode
    {
        public FvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class FvScheduleStandardFunctionNode : StandardFunctionNode
    {
        public FvScheduleStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "FVSCHEDULE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaDistStandardFunctionNode : StandardFunctionNode
    {
        public GammaDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GAMMADIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaInvStandardFunctionNode : StandardFunctionNode
    {
        public GammaInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GAMMAINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GammaLnStandardFunctionNode : StandardFunctionNode
    {
        public GammaLnStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GAMMALN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GcdStandardFunctionNode : StandardFunctionNode
    {
        public GcdStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GCD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GeoMeanStandardFunctionNode : StandardFunctionNode
    {
        public GeoMeanStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GEOMEAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GeStepStandardFunctionNode : StandardFunctionNode
    {
        public GeStepStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GESTEP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class GetPivotDataStandardFunctionNode : StandardFunctionNode
    {
        public GetPivotDataStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GETPIVOTDATA"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class GrowthStandardFunctionNode : StandardFunctionNode
    {
        public GrowthStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "GROWTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HarMeanStandardFunctionNode : StandardFunctionNode
    {
        public HarMeanStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HARMEAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HexToBinStandardFunctionNode : StandardFunctionNode
    {
        public HexToBinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HEX2BIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HexToDecStandardFunctionNode : StandardFunctionNode
    {
        public HexToDecStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HEX2DEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HexToOctStandardFunctionNode : StandardFunctionNode
    {
        public HexToOctStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HEX2OCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HLookupStandardFunctionNode : StandardFunctionNode
    {
        public HLookupStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HLOOKUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HourStandardFunctionNode : StandardFunctionNode
    {
        public HourStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HOUR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HyperlinkStandardFunctionNode : StandardFunctionNode
    {
        public HyperlinkStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HYPERLINK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class HypGeomDistStandardFunctionNode : StandardFunctionNode
    {
        public HypGeomDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "HYPGEOMDIST"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class IfStandardFunctionNode : StandardFunctionNode
    {
        public IfStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IfErrorStandardFunctionNode : StandardFunctionNode
    {
        public IfErrorStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IFERROR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IfsStandardFunctionNode : StandardFunctionNode
    {
        public IfsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImAbsStandardFunctionNode : StandardFunctionNode
    {
        public ImAbsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMABS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImAginaryStandardFunctionNode : StandardFunctionNode
    {
        public ImAginaryStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMAGINARY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImArgumentStandardFunctionNode : StandardFunctionNode
    {
        public ImArgumentStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMARGUMENT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImConjugateStandardFunctionNode : StandardFunctionNode
    {
        public ImConjugateStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMCONJUGATE"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ImCosStandardFunctionNode : StandardFunctionNode
    {
        public ImCosStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMCOS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImDivStandardFunctionNode : StandardFunctionNode
    {
        public ImDivStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMDIV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImExpStandardFunctionNode : StandardFunctionNode
    {
        public ImExpStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMEXP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImLnStandardFunctionNode : StandardFunctionNode
    {
        public ImLnStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMLN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImLog10StandardFunctionNode : StandardFunctionNode
    {
        public ImLog10StandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMLOG10"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImLogToStandardFunctionNode : StandardFunctionNode
    {
        public ImLogToStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMLOG2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImPowerStandardFunctionNode : StandardFunctionNode
    {
        public ImPowerStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMPOWER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImProductStandardFunctionNode : StandardFunctionNode
    {
        public ImProductStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMPRODUCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImRealStandardFunctionNode : StandardFunctionNode
    {
        public ImRealStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMREAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSinStandardFunctionNode : StandardFunctionNode
    {
        public ImSinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMSIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSqrtStandardFunctionNode : StandardFunctionNode
    {
        public ImSqrtStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMSQRT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSubStandardFunctionNode : StandardFunctionNode
    {
        public ImSubStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMSUB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ImSumStandardFunctionNode : StandardFunctionNode
    {
        public ImSumStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IMSUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IndexStandardFunctionNode : StandardFunctionNode
    {
        public IndexStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INDEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IndirectStandardFunctionNode : StandardFunctionNode
    {
        public IndirectStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INDIRECT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class InfoStandardFunctionNode : StandardFunctionNode
    {
        public InfoStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INFO"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IntStandardFunctionNode : StandardFunctionNode
    {
        public IntStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class InterceptStandardFunctionNode : StandardFunctionNode
    {
        public InterceptStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INTERCEPT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IntrateStandardFunctionNode : StandardFunctionNode
    {
        public IntrateStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "INTRATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IpmtStandardFunctionNode : StandardFunctionNode
    {
        public IpmtStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IPMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IrrStandardFunctionNode : StandardFunctionNode
    {
        public IrrStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "IRR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsBlankStandardFunctionNode : StandardFunctionNode
    {
        public IsBlankStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISBLANK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsErrStandardFunctionNode : StandardFunctionNode
    {
        public IsErrStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISERR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsErrorStandardFunctionNode : StandardFunctionNode
    {
        public IsErrorStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISERROR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsEvenStandardFunctionNode : StandardFunctionNode
    {
        public IsEvenStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISEVEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsLogicalStandardFunctionNode : StandardFunctionNode
    {
        public IsLogicalStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISLOGICAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsNaStandardFunctionNode : StandardFunctionNode
    {
        public IsNaStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISNA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsNontextStandardFunctionNode : StandardFunctionNode
    {
        public IsNontextStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISNONTEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsNumberStandardFunctionNode : StandardFunctionNode
    {
        public IsNumberStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISNUMBER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsOddStandardFunctionNode : StandardFunctionNode
    {
        public IsOddStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISODD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsPmtStandardFunctionNode : StandardFunctionNode
    {
        public IsPmtStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISPMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsRefStandardFunctionNode : StandardFunctionNode
    {
        public IsRefStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISREF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsTextStandardFunctionNode : StandardFunctionNode
    {
        public IsTextStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISTEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class IsThaiDigitStandardFunctionNode : StandardFunctionNode
    {
        public IsThaiDigitStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ISTHAIDIGIT"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class KurtStandardFunctionNode : StandardFunctionNode
    {
        public KurtStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "KURT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LargeStandardFunctionNode : StandardFunctionNode
    {
        public LargeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LARGE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LcmStandardFunctionNode : StandardFunctionNode
    {
        public LcmStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LCM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LeftStandardFunctionNode : StandardFunctionNode
    {
        public LeftStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LEFT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LeftbStandardFunctionNode : StandardFunctionNode
    {
        public LeftbStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LEFTB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LenStandardFunctionNode : StandardFunctionNode
    {
        public LenStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LEN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LenbStandardFunctionNode : StandardFunctionNode
    {
        public LenbStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LENB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LinestStandardFunctionNode : StandardFunctionNode
    {
        public LinestStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LINEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LnStandardFunctionNode : StandardFunctionNode
    {
        public LnStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogStandardFunctionNode : StandardFunctionNode
    {
        public LogStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LOG"), leadingWhitespace, trailingWhitespace) { }
    }

    public class Log10StandardFunctionNode : StandardFunctionNode
    {
        public Log10StandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LOG10"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogestStandardFunctionNode : StandardFunctionNode
    {
        public LogestStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LOGEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogInvStandardFunctionNode : StandardFunctionNode
    {
        public LogInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LOGINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LogNormDistStandardFunctionNode : StandardFunctionNode
    {
        public LogNormDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LOGNORMDIST"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class LookupStandardFunctionNode : StandardFunctionNode
    {
        public LookupStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LOOKUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class LowerStandardFunctionNode : StandardFunctionNode
    {
        public LowerStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "LOWER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MatchStandardFunctionNode : StandardFunctionNode
    {
        public MatchStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MATCH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MaxStandardFunctionNode : StandardFunctionNode
    {
        public MaxStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MAX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MaxaStandardFunctionNode : StandardFunctionNode
    {
        public MaxaStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MAXA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MaxifsStandardFunctionNode : StandardFunctionNode
    {
        public MaxifsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MAXIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MdetermStandardFunctionNode : StandardFunctionNode
    {
        public MdetermStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MDETERM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MdurationStandardFunctionNode : StandardFunctionNode
    {
        public MdurationStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MDURATION"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MedianStandardFunctionNode : StandardFunctionNode
    {
        public MedianStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MEDIAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MidStandardFunctionNode : StandardFunctionNode
    {
        public MidStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MID"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MidbStandardFunctionNode : StandardFunctionNode
    {
        public MidbStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MIDB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinStandardFunctionNode : StandardFunctionNode
    {
        public MinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinaStandardFunctionNode : StandardFunctionNode
    {
        public MinaStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MINA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinifsStandardFunctionNode : StandardFunctionNode
    {
        public MinifsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MINIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinuteStandardFunctionNode : StandardFunctionNode
    {
        public MinuteStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MINUTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MinverseStandardFunctionNode : StandardFunctionNode
    {
        public MinverseStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MINVERSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MirrStandardFunctionNode : StandardFunctionNode
    {
        public MirrStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MIRR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MmultStandardFunctionNode : StandardFunctionNode
    {
        public MmultStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MMULT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ModStandardFunctionNode : StandardFunctionNode
    {
        public ModStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MOD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ModeStandardFunctionNode : StandardFunctionNode
    {
        public ModeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MODE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MonthStandardFunctionNode : StandardFunctionNode
    {
        public MonthStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MONTH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MroundStandardFunctionNode : StandardFunctionNode
    {
        public MroundStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MROUND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class MultinomialStandardFunctionNode : StandardFunctionNode
    {
        public MultinomialStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "MULTINOMIAL"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NStandardFunctionNode : StandardFunctionNode
    {
        public NStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "N"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NaStandardFunctionNode : StandardFunctionNode
    {
        public NaStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NegBinomDistStandardFunctionNode : StandardFunctionNode
    {
        public NegBinomDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NEGBINOMDIST"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NetworkDaysStandardFunctionNode : StandardFunctionNode
    {
        public NetworkDaysStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NETWORKDAYS"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class NominalStandardFunctionNode : StandardFunctionNode
    {
        public NominalStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NOMINAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormDistStandardFunctionNode : StandardFunctionNode
    {
        public NormDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NORMDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormInvStandardFunctionNode : StandardFunctionNode
    {
        public NormInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NORMINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormsDistStandardFunctionNode : StandardFunctionNode
    {
        public NormsDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NORMSDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NormsInvStandardFunctionNode : StandardFunctionNode
    {
        public NormsInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NORMSINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NotStandardFunctionNode : StandardFunctionNode
    {
        public NotStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NOT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NowStandardFunctionNode : StandardFunctionNode
    {
        public NowStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NOW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NperStandardFunctionNode : StandardFunctionNode
    {
        public NperStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NPER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NpvStandardFunctionNode : StandardFunctionNode
    {
        public NpvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NPV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class NumberStringStandardFunctionNode : StandardFunctionNode
    {
        public NumberStringStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "NUMBERSTRING"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class OctToBinStandardFunctionNode : StandardFunctionNode
    {
        public OctToBinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OCT2BIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OctToDecStandardFunctionNode : StandardFunctionNode
    {
        public OctToDecStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OCT2DEC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OctToHexStandardFunctionNode : StandardFunctionNode
    {
        public OctToHexStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OCT2HEX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddStandardFunctionNode : StandardFunctionNode
    {
        public OddStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ODD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddFPriceStandardFunctionNode : StandardFunctionNode
    {
        public OddFPriceStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ODDFPRICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddFYieldStandardFunctionNode : StandardFunctionNode
    {
        public OddFYieldStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ODDFYIELD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddLPriceStandardFunctionNode : StandardFunctionNode
    {
        public OddLPriceStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ODDLPRICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OddLYieldStandardFunctionNode : StandardFunctionNode
    {
        public OddLYieldStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ODDLYIELD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OffsetStandardFunctionNode : StandardFunctionNode
    {
        public OffsetStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OFFSET"), leadingWhitespace, trailingWhitespace) { }
    }

    public class OrStandardFunctionNode : StandardFunctionNode
    {
        public OrStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "OR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PearsonStandardFunctionNode : StandardFunctionNode
    {
        public PearsonStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PEARSON"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentileStandardFunctionNode : StandardFunctionNode
    {
        public PercentileStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PERCENTILE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PercentRankStandardFunctionNode : StandardFunctionNode
    {
        public PercentRankStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PERCENTRANK"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class PermutStandardFunctionNode : StandardFunctionNode
    {
        public PermutStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PERMUT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PhoneticStandardFunctionNode : StandardFunctionNode
    {
        public PhoneticStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PHONETIC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PiStandardFunctionNode : StandardFunctionNode
    {
        public PiStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PI"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PmtStandardFunctionNode : StandardFunctionNode
    {
        public PmtStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PoissonStandardFunctionNode : StandardFunctionNode
    {
        public PoissonStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "POISSON"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PowerStandardFunctionNode : StandardFunctionNode
    {
        public PowerStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "POWER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PpmtStandardFunctionNode : StandardFunctionNode
    {
        public PpmtStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PPMT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PriceStandardFunctionNode : StandardFunctionNode
    {
        public PriceStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PRICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PricediscStandardFunctionNode : StandardFunctionNode
    {
        public PricediscStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PRICEDISC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PricematStandardFunctionNode : StandardFunctionNode
    {
        public PricematStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PRICEMAT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ProbStandardFunctionNode : StandardFunctionNode
    {
        public ProbStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PROB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ProductStandardFunctionNode : StandardFunctionNode
    {
        public ProductStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PRODUCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ProperStandardFunctionNode : StandardFunctionNode
    {
        public ProperStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PROPER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class PvStandardFunctionNode : StandardFunctionNode
    {
        public PvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "PV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class QuartileStandardFunctionNode : StandardFunctionNode
    {
        public QuartileStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "QUARTILE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class QuotientStandardFunctionNode : StandardFunctionNode
    {
        public QuotientStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "QUOTIENT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RadiansStandardFunctionNode : StandardFunctionNode
    {
        public RadiansStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RADIANS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RandStandardFunctionNode : StandardFunctionNode
    {
        public RandStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RAND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RandbetweenStandardFunctionNode : StandardFunctionNode
    {
        public RandbetweenStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RANDBETWEEN"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RankStandardFunctionNode : StandardFunctionNode
    {
        public RankStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RANK"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RateStandardFunctionNode : StandardFunctionNode
    {
        public RateStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RATE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReceivedStandardFunctionNode : StandardFunctionNode
    {
        public ReceivedStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RECEIVED"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReplaceStandardFunctionNode : StandardFunctionNode
    {
        public ReplaceStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "REPLACE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReplacebStandardFunctionNode : StandardFunctionNode
    {
        public ReplacebStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "REPLACEB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ReptStandardFunctionNode : StandardFunctionNode
    {
        public ReptStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "REPT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RightStandardFunctionNode : StandardFunctionNode
    {
        public RightStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RIGHT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RightBStandardFunctionNode : StandardFunctionNode
    {
        public RightBStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RIGHTB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RomanStandardFunctionNode : StandardFunctionNode
    {
        public RomanStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROMAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RoundStandardFunctionNode : StandardFunctionNode
    {
        public RoundStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROUND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RoundBahtDownStandardFunctionNode : StandardFunctionNode
    {
        public RoundBahtDownStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROUNDBAHTDOWN"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RoundBahtUpStandardFunctionNode : StandardFunctionNode
    {
        public RoundBahtUpStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROUNDBAHTUP"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class RoundDownStandardFunctionNode : StandardFunctionNode
    {
        public RoundDownStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROUNDDOWN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RoundUpStandardFunctionNode : StandardFunctionNode
    {
        public RoundUpStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROUNDUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RowStandardFunctionNode : StandardFunctionNode
    {
        public RowStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RowsStandardFunctionNode : StandardFunctionNode
    {
        public RowsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ROWS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RsqStandardFunctionNode : StandardFunctionNode
    {
        public RsqStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RSQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class RtdStandardFunctionNode : StandardFunctionNode
    {
        public RtdStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "RTD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SearchStandardFunctionNode : StandardFunctionNode
    {
        public SearchStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SEARCH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SearchbStandardFunctionNode : StandardFunctionNode
    {
        public SearchbStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SEARCHB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SecondStandardFunctionNode : StandardFunctionNode
    {
        public SecondStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SECOND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SeriesStandardFunctionNode : StandardFunctionNode
    {
        public SeriesStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SERIES"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SeriessumStandardFunctionNode : StandardFunctionNode
    {
        public SeriessumStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SERIESSUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SignStandardFunctionNode : StandardFunctionNode
    {
        public SignStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SIGN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SinStandardFunctionNode : StandardFunctionNode
    {
        public SinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SinhStandardFunctionNode : StandardFunctionNode
    {
        public SinhStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SINH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SkewStandardFunctionNode : StandardFunctionNode
    {
        public SkewStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SKEW"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SlnStandardFunctionNode : StandardFunctionNode
    {
        public SlnStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SLN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SlopeStandardFunctionNode : StandardFunctionNode
    {
        public SlopeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SLOPE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SmallStandardFunctionNode : StandardFunctionNode
    {
        public SmallStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SMALL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SqrtStandardFunctionNode : StandardFunctionNode
    {
        public SqrtStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SQRT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SqrtpiStandardFunctionNode : StandardFunctionNode
    {
        public SqrtpiStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SQRTPI"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StandardizeStandardFunctionNode : StandardFunctionNode
    {
        public StandardizeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "STANDARDIZE"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class StDevStandardFunctionNode : StandardFunctionNode
    {
        public StDevStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "STDEV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevAStandardFunctionNode : StandardFunctionNode
    {
        public StDevAStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "STDEVA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevPStandardFunctionNode : StandardFunctionNode
    {
        public StDevPStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "STDEVP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class StDevPaStandardFunctionNode : StandardFunctionNode
    {
        public StDevPaStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "STDEVPA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SteyxStandardFunctionNode : StandardFunctionNode
    {
        public SteyxStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "STEYX"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SubstituteStandardFunctionNode : StandardFunctionNode
    {
        public SubstituteStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUBSTITUTE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SubtotalStandardFunctionNode : StandardFunctionNode
    {
        public SubtotalStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUBTOTAL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumStandardFunctionNode : StandardFunctionNode
    {
        public SumStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumIfStandardFunctionNode : StandardFunctionNode
    {
        public SumIfStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUMIF"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumIfsStandardFunctionNode : StandardFunctionNode
    {
        public SumIfsStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUMIFS"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumProductStandardFunctionNode : StandardFunctionNode
    {
        public SumProductStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUMPRODUCT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumSqStandardFunctionNode : StandardFunctionNode
    {
        public SumSqStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUMSQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumXToMyToStandardFunctionNode : StandardFunctionNode
    {
        public SumXToMyToStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUMX2MY2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumXToPyToStandardFunctionNode : StandardFunctionNode
    {
        public SumXToPyToStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUMX2PY2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SumXMyToStandardFunctionNode : StandardFunctionNode
    {
        public SumXMyToStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SUMXMY2"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SwitchStandardFunctionNode : StandardFunctionNode
    {
        public SwitchStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SWITCH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class SydStandardFunctionNode : StandardFunctionNode
    {
        public SydStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "SYD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TStandardFunctionNode : StandardFunctionNode
    {
        public TStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "T"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TanStandardFunctionNode : StandardFunctionNode
    {
        public TanStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TanhStandardFunctionNode : StandardFunctionNode
    {
        public TanhStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TANH"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TBillEqStandardFunctionNode : StandardFunctionNode
    {
        public TBillEqStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TBILLEQ"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TBillPriceStandardFunctionNode : StandardFunctionNode
    {
        public TBillPriceStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TBILLPRICE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TBillYieldStandardFunctionNode : StandardFunctionNode
    {
        public TBillYieldStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TBILLYIELD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TDistStandardFunctionNode : StandardFunctionNode
    {
        public TDistStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TDIST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextStandardFunctionNode : StandardFunctionNode
    {
        public TextStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TEXT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TextJoinStandardFunctionNode : StandardFunctionNode
    {
        public TextJoinStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TEXTJOIN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiDayOfWeekStandardFunctionNode : StandardFunctionNode
    {
        public ThaiDayOfWeekStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "THAIDAYOFWEEK"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ThaiDigitStandardFunctionNode : StandardFunctionNode
    {
        public ThaiDigitStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "THAIDIGIT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ThaiMonthOfYearStandardFunctionNode : StandardFunctionNode
    {
        public ThaiMonthOfYearStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "THAIMONTHOfYear"),
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ThaiNumSoundStandardFunctionNode : StandardFunctionNode
    {
        public ThaiNumSoundStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "THAINUMSOUND"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ThaiNumStringStandardFunctionNode : StandardFunctionNode
    {
        public ThaiNumStringStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "THAINUMSTRING"), leadingWhitespace, trailingWhitespace)
        { }
    }

    public class ThaiStringLengthStandardFunctionNode : StandardFunctionNode
    {
        public ThaiStringLengthStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(
                new NameNode(rawName ?? "THAISTRINGLENGTH"),
                leadingWhitespace,
                trailingWhitespace
            )
        { }
    }

    public class ThaiYearStandardFunctionNode : StandardFunctionNode
    {
        public ThaiYearStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "THAIYEAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TimeStandardFunctionNode : StandardFunctionNode
    {
        public TimeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TIME"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TimeValueStandardFunctionNode : StandardFunctionNode
    {
        public TimeValueStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TIMEVALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TInvStandardFunctionNode : StandardFunctionNode
    {
        public TInvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TINV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TodayStandardFunctionNode : StandardFunctionNode
    {
        public TodayStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TODAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TransposeStandardFunctionNode : StandardFunctionNode
    {
        public TransposeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TRANSPOSE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TrendStandardFunctionNode : StandardFunctionNode
    {
        public TrendStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TREND"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TrimStandardFunctionNode : StandardFunctionNode
    {
        public TrimStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TRIM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TrimMeanStandardFunctionNode : StandardFunctionNode
    {
        public TrimMeanStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TRIMMEAN"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TrueStandardFunctionNode : StandardFunctionNode
    {
        public TrueStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TRUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TruncStandardFunctionNode : StandardFunctionNode
    {
        public TruncStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TRUNC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TTestStandardFunctionNode : StandardFunctionNode
    {
        public TTestStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TTEST"), leadingWhitespace, trailingWhitespace) { }
    }

    public class TypeStandardFunctionNode : StandardFunctionNode
    {
        public TypeStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "TYPE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UpperStandardFunctionNode : StandardFunctionNode
    {
        public UpperStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "UPPER"), leadingWhitespace, trailingWhitespace) { }
    }

    public class UsDollarStandardFunctionNode : StandardFunctionNode
    {
        public UsDollarStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "USDOLLAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ValueStandardFunctionNode : StandardFunctionNode
    {
        public ValueStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VALUE"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarStandardFunctionNode : StandardFunctionNode
    {
        public VarStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarAStandardFunctionNode : StandardFunctionNode
    {
        public VarAStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VARA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarPStandardFunctionNode : StandardFunctionNode
    {
        public VarPStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VARP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VarPaStandardFunctionNode : StandardFunctionNode
    {
        public VarPaStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VARPA"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VdbStandardFunctionNode : StandardFunctionNode
    {
        public VdbStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VDB"), leadingWhitespace, trailingWhitespace) { }
    }

    public class VLookupStandardFunctionNode : StandardFunctionNode
    {
        public VLookupStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "VLOOKUP"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WeekdayStandardFunctionNode : StandardFunctionNode
    {
        public WeekdayStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WEEKDAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WeekNumStandardFunctionNode : StandardFunctionNode
    {
        public WeekNumStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WEEKNUM"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WeibullStandardFunctionNode : StandardFunctionNode
    {
        public WeibullStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WEIBULL"), leadingWhitespace, trailingWhitespace) { }
    }

    public class WorkdayStandardFunctionNode : StandardFunctionNode
    {
        public WorkdayStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "WORKDAY"), leadingWhitespace, trailingWhitespace) { }
    }

    public class XirrStandardFunctionNode : StandardFunctionNode
    {
        public XirrStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "XIRR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class XnpvStandardFunctionNode : StandardFunctionNode
    {
        public XnpvStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "XNPV"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YearStandardFunctionNode : StandardFunctionNode
    {
        public YearStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "YEAR"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YearFracStandardFunctionNode : StandardFunctionNode
    {
        public YearFracStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "YEARFRAC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YieldStandardFunctionNode : StandardFunctionNode
    {
        public YieldStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "YIELD"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YieldDiscStandardFunctionNode : StandardFunctionNode
    {
        public YieldDiscStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "YIELDDISC"), leadingWhitespace, trailingWhitespace) { }
    }

    public class YieldMatStandardFunctionNode : StandardFunctionNode
    {
        public YieldMatStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "YIELDMAT"), leadingWhitespace, trailingWhitespace) { }
    }

    public class ZTestStandardFunctionNode : StandardFunctionNode
    {
        public ZTestStandardFunctionNode(
            string? rawName = null,
            List<Node>? leadingWhitespace = null,
            List<Node>? trailingWhitespace = null
        )
            : base(new NameNode(rawName ?? "ZTEST"), leadingWhitespace, trailingWhitespace) { }
    }
}
