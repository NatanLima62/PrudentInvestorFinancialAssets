using HtmlAgilityPack;

namespace Statics;

public static class Program
{
    public static void Main(string[] args)
    {
        var url = "https://finance.yahoo.com/quote/AAPL/key-statistics";
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "teste");
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        
        var sumaryElements = htmlDocument.DocumentNode
            .SelectNodes("//td[@class='Fw(500) Ta(end) Pstart(10px) Miw(60px)']")
            .Select(node => node.InnerText)
            .ToList();

        var statistic = new Statistic
        {
            ValuationMeasures = new ValuationMeasures
            {
                MarketCap = sumaryElements[0],
                EnterpriseValue = sumaryElements[1],
                TrailingPe = sumaryElements[2],
                ForwardPe = sumaryElements[3],
                PegRatio = sumaryElements[4],
                PriceSales = sumaryElements[5],
                PriceBook = sumaryElements[6],
                EnterpriseValueRevenue = sumaryElements[7],
                EnterpriseValueEbitda = sumaryElements[8]
            },
            StockPriceHistory = new StockPriceHistory
            {
                Beta = sumaryElements[9],
                FiftyTwoWeekChange = sumaryElements[10],
                Sp500FiftyTwoWeekChange = sumaryElements[11],
                FiftyTwoWeekHigh = sumaryElements[12],
                FiftyTwoWeekLow = sumaryElements[13],
                FiftyDayMovingAverage = sumaryElements[14],
                TwoHundredDayMovingAverage = sumaryElements[15]
            },
            ShareStatistics = new ShareStatistics
            {
                AvgVol3Month = sumaryElements[16],
                AvgVol10Day = sumaryElements[17],
                SharesOutstanding = sumaryElements[18],
                ImpliedSharesOutstainding = sumaryElements[19],
                Float = sumaryElements[20],
                HeldByInsiders = sumaryElements[21],
                HeldByInstitutions = sumaryElements[22],
                SharesShort = sumaryElements[23],
                ShortRatio = sumaryElements[24],
                ShortPctOfFloat = sumaryElements[25],
                ShortPctOfSharesOutstanding = sumaryElements[26],
                SharesShortPriorMonth = sumaryElements[27]
            },
            DividendsAndSplits = new DividendsAndSplits
            {
                ForwardAnnualDividendRate = sumaryElements[28],
                ForwardAnnualDividendYield = sumaryElements[29],
                TrailingAnnualDividendRate = sumaryElements[30],
                TrailingAnnualDividendYield = sumaryElements[31],
                FiveYearAverageDividendYield = sumaryElements[32],
                PayoutRatio = sumaryElements[33],
                DividendDate = sumaryElements[34],
                ExDividendDate = sumaryElements[35],
                LastSplitFactor = sumaryElements[36],
                LastSplitDate = sumaryElements[37]
            },
            FiscalYear = new FiscalYear
            {
                FiscalYearEnds = sumaryElements[38],
                MostRecentQuarter = sumaryElements[39]
            },
            Profitability = new Profitability
            {
                ProfitMargin = sumaryElements[40],
                OperatingMargin = sumaryElements[41]
            },
            ManagementEffectiveness = new ManagementEffectiveness
            {
                ReturnOnAssets = sumaryElements[42],
                ReturnOnEquity = sumaryElements[43]
            },
            IncomeStatement = new IncomeStatement
            {
                Revenue = sumaryElements[44],
                RevenuePerShare = sumaryElements[45],
                QuarterlyRevenueGrowth = sumaryElements[46],
                GrossProfit = sumaryElements[47],
                Ebitda = sumaryElements[48],
                NetIncomeAviToCommon = sumaryElements[49],
                DilutedEps = sumaryElements[50],
                QuarterlyEarningsGrowth = sumaryElements[51]
            },
            BalanceSheet = new BalanceSheet
            {
                TotalCash = sumaryElements[52],
                TotalCashPerShare = sumaryElements[53],
                TotalDebt = sumaryElements[54],
                TotalDebtEquity = sumaryElements[55],
                CurrentRatio = sumaryElements[56],
                BookValuePerShare = sumaryElements[57]
            },
            CashFlowStatement = new CashFlowStatement
            {
                OperatingCashFlow = sumaryElements[58],
                LeveredFreeCashFlow = sumaryElements[59]
            }
        };
        
        Console.WriteLine(statistic);
    }
}

public class Statistic
{
    public ValuationMeasures ValuationMeasures { get; set; } = null!;
    public StockPriceHistory StockPriceHistory { get; set; } = null!;
    public ShareStatistics ShareStatistics { get; set; } = null!;
    public DividendsAndSplits DividendsAndSplits { get; set; } = null!;
    public FiscalYear FiscalYear { get; set; } = null!;
    public Profitability Profitability { get; set; } = null!;
    public ManagementEffectiveness ManagementEffectiveness { get; set; } = null!;
    public IncomeStatement IncomeStatement { get; set; } = null!;
    public BalanceSheet BalanceSheet { get; set; } = null!;
    public CashFlowStatement CashFlowStatement { get; set; } = null!;
}

public class ValuationMeasures
{
    public string? MarketCap { get; set; }
    public string? EnterpriseValue { get; set; }
    public string? TrailingPe { get; set; }
    public string? ForwardPe { get; set; }
    public string? PegRatio { get; set; }
    public string? PriceSales { get; set; }
    public string? PriceBook { get; set; }
    public string? EnterpriseValueRevenue { get; set; }
    public string? EnterpriseValueEbitda { get; set; }
}

public class StockPriceHistory
{
    public string? Beta { get; set; }
    public string? FiftyTwoWeekChange { get; set; }
    public string? Sp500FiftyTwoWeekChange { get; set; }
    public string? FiftyTwoWeekHigh { get; set; }
    public string? FiftyTwoWeekLow { get; set; }
    public string? FiftyDayMovingAverage { get; set; }
    public string? TwoHundredDayMovingAverage { get; set; }
}

public class ShareStatistics
{
    public string? AvgVol3Month { get; set; }
    public string? AvgVol10Day { get; set; }
    public string? SharesOutstanding { get; set; }
    public string? ImpliedSharesOutstainding { get; set; }
    public string? Float { get; set; }
    public string? HeldByInsiders { get; set; }
    public string? HeldByInstitutions { get; set; }
    public string? SharesShort { get; set; }
    public string? ShortRatio { get; set; }
    public string? ShortPctOfFloat { get; set; }
    public string? ShortPctOfSharesOutstanding   { get; set; }
    public string? SharesShortPriorMonth { get; set; }
}

public class DividendsAndSplits
{
    public string? ForwardAnnualDividendRate { get; set; }
    public string? ForwardAnnualDividendYield { get; set; }
    public string? TrailingAnnualDividendRate { get; set; }
    public string? TrailingAnnualDividendYield { get; set; }
    public string? FiveYearAverageDividendYield { get; set; }
    public string? PayoutRatio { get; set; }
    public string? DividendDate { get; set; }
    public string? ExDividendDate { get; set; }
    public string? LastSplitFactor { get; set; }
    public string? LastSplitDate { get; set; }
}

public class FiscalYear
{
    public string? FiscalYearEnds { get; set; }
    public string? MostRecentQuarter { get; set; }
}

public class Profitability
{
    public string? ProfitMargin { get; set; }
    public string? OperatingMargin { get; set; }
}

public class ManagementEffectiveness
{
    public string? ReturnOnAssets { get; set; }
    public string? ReturnOnEquity { get; set; }
}

public class IncomeStatement
{
    public string? Revenue { get; set; }
    public string? RevenuePerShare { get; set; }
    public string? QuarterlyRevenueGrowth { get; set; }
    public string? GrossProfit { get; set; }
    public string? Ebitda { get; set; }
    public string? NetIncomeAviToCommon { get; set; }
    public string? DilutedEps { get; set; }
    public string? QuarterlyEarningsGrowth { get; set; }
}

public class BalanceSheet
{
    public string? TotalCash { get; set; }
    public string? TotalCashPerShare { get; set; }
    public string? TotalDebt { get; set; }
    public string? TotalDebtEquity { get; set; }
    public string? CurrentRatio { get; set; }
    public string? BookValuePerShare { get; set; }
}

public class CashFlowStatement
{
    public string? OperatingCashFlow { get; set; }
    public string? LeveredFreeCashFlow { get; set; }
}