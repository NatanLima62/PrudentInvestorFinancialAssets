using HtmlAgilityPack;

namespace HistoricalData;

public static class Program
{
    public static void Main(string[] args)
    {
        var url =
            "https://finance.yahoo.com/quote/AAPL/history?period1=1362441600&period2=1709596800&interval=1d&filter=history&frequency=1d&includeAdjustedClose=true";
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "teste");
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        //cada linha possui 7 colunas. Logo, a quantidade de linhas é o total de elementos dividido por 7
        //Columns names: Date, Open, High, Low, Close*, Adj Close**, Volume
        var elements = htmlDocument.DocumentNode
            .SelectNodes("//tr[@class='BdT Bdc($seperatorColor) Ta(end) Fz(s) Whs(nw)']")
            .Descendants("td")
            .Where(node => node.GetAttributeValue("class", "").Equals("Py(10px) Pstart(10px)") || node.GetAttributeValue("class", "").Equals("Py(10px) Ta(start) Pend(10px)"))
            .Select(node => node.InnerText)
            .ToList();
    }
}