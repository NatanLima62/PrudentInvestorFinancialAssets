using HtmlAgilityPack;

namespace PrudentInvestorFinancialAssets.Console;

public static class WebScraper
{
    public static void Main(string[] args)
    {
        //Url pode ser parametrizada
        var url = "https://finance.yahoo.com/quote/AAPL";
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        
        var sumaryElements = htmlDocument.DocumentNode
        .SelectNodes("//td[@class='Ta(end) Fw(600) Lh(14px)']")
        .Select(node => node.InnerText)
        .ToList();
        
        // var sumaryElements = htmlDocument.DocumentNode
        //     .SelectNodes("//tr[@class='Bxz(bb) Bdbw(1px) Bdbs(s) Bdc($seperatorColor) H(36px) '] | //tr[@class='Bxz(bb) Bdbw(1px) Bdbs(s) Bdc($seperatorColor) H(36px) Bdbw(0)! ']")
        //     .Descendants("td")
        //     .ToList();

        var sumary = new Sumary
        {
            PreviousClose = sumaryElements[0],
            Open = sumaryElements[1],
            Bid = sumaryElements[2],
            Ask = sumaryElements[3],
            DaysRange = sumaryElements[4],
            FiftyTwoWeekRange = sumaryElements[5],
            Volume = sumaryElements[6],
            AvgVolume = sumaryElements[7],
            MarketCap = sumaryElements[8],
            Beta = sumaryElements[9],
            PeRatio = sumaryElements[10],
            Eps = sumaryElements[11],
            EarningsDate = sumaryElements[12],
            ForwardDividendAndYield = sumaryElements[13],
            ExDividendDate = sumaryElements[14],
            OneYearTargetEst = sumaryElements[15]
        };
        
        System.Console.WriteLine(sumary);
    }
}

public class Sumary
{
    public string? PreviousClose { get; set; }
    public string? Open { get; set; }
    public string? Bid { get; set; }
    public string? Ask { get; set; }
    public string? DaysRange { get; set; }
    public string? FiftyTwoWeekRange { get; set; }
    public string? Volume { get; set; }
    public string? AvgVolume { get; set; }
    public string? MarketCap { get; set; }
    public string? Beta { get; set; }
    public string? PeRatio { get; set; }
    public string? Eps { get; set; }
    public string? EarningsDate { get; set; }
    public string? ForwardDividendAndYield { get; set; }
    public string? ExDividendDate { get; set; }
    public string? OneYearTargetEst { get; set; }
}

// // var stockName = htmlDocument.DocumentNode
// //     .Descendants("h1")
// //     .FirstOrDefault(node => node.GetAttributeValue("class", "")
// //         .Equals("D(ib) Fz(18px)"))
// //     ?.InnerText
//
// var sumary1 = htmlDocument.DocumentNode
//     .SelectSingleNode("//div[@class='Bxz(bb) D(ib) Va(t) Mih(250px)!--lgv2 W(100%) Mt(-6px) Mt(0px)--mobp Mt(0px)--mobl W(50%)!--lgv2 Mend(20px)!--lgv2 Pend(10px)!--lgv2 ']");
//
// var sumary2 = htmlDocument.DocumentNode
//     .SelectSingleNode("//tr[@class='Bxz(bb) Bdbw(1px) Bdbs(s) Bdc($seperatorColor) H(36px) ']");
//
// var sumary3 = htmlDocument.DocumentNode
//     .SelectSingleNode("//td[@class='C($primaryColor) W(51%)]");
        
//Get all elements with the class "Bxz(bb) Bdbw(1px) Bdbs(s) Bdc($seperatorColor) H(36px)" and html tag "tr"

//with sumaary we can get all the elements with the class C($primaryColor) W(51%) and html tag "td" or all the elements with the class "Ta(end) Fw(600) Lh(14px)" and html tag "td"
// var sumary2 = htmlDocument.DocumentNode
//     .SelectNodes("//td[@class='C($primaryColor) W(51%)'] | //td[@class='Ta(end) Fw(600) Lh(14px)']").ToList();