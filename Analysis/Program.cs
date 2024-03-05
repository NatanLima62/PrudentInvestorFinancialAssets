using HtmlAgilityPack;

namespace Analysis;

public static class Program
{
    public static void Main(string[] args)
    {
        var url = "https://finance.yahoo.com/quote/AAPL/analysis";
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        var colums = htmlDocument.DocumentNode
            .SelectNodes("//table[@class='W(100%) M(0) BdB Bdc($seperatorColor) Mb(25px)']/thead/tr[@class='Ta(start)']")
            .Select(node => node.InnerText).Where(text => !string.IsNullOrWhiteSpace(text))
            .ToList();
    }
}