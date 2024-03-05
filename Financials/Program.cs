using HtmlAgilityPack;

namespace Financials;

public static class Financial
{
    public static void Main(string[] args)
    {
        
        //Possui 3 tabelas Income Statement, Balance Sheet, Cash Flow
        //Cada tabela pode mostrar dados do tipo Quarterly ou Annual
        
        //Income Statement
        var url = "https://finance.yahoo.com/quote/AAPL/financials";
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        
        //Columns: Breakdown, TTM, {9/30/2023, 9/30/2022, 9/30/2021, 9/30/2020}
        var columns = htmlDocument.DocumentNode
            .SelectNodes("//div[@class='D(tbr) C($primaryColor)']")
            .Descendants("div")
            .Select(node => node.InnerText).Where(text => !string.IsNullOrWhiteSpace(text))
            .ToList();
        
        var elements = htmlDocument.DocumentNode
            .SelectNodes("//div[@class='D(tbr) fi-row Bgc($hoverBgColor):h']")
            .Descendants("div")
            .Select(node => node.InnerText).Where(text => !string.IsNullOrWhiteSpace(text))
            .ToList();
        
        //Balance Sheet
        var url2 = "https://finance.yahoo.com/quote/AAPL/balance-sheet";
        var httpClient2 = new HttpClient();
        var html2 = httpClient2.GetStringAsync(url2).Result;
        var htmlDocument2 = new HtmlDocument();
        htmlDocument2.LoadHtml(html2);
        
        var columns2 = htmlDocument2.DocumentNode
            .SelectNodes("//div[@class='D(tbr) C($primaryColor)']")
            .Descendants("div")
            .Select(node => node.InnerText).Where(text => !string.IsNullOrWhiteSpace(text))
            .ToList();
        
        var elements2 = htmlDocument2.DocumentNode
            .SelectNodes("//div[@class='D(tbr) fi-row Bgc($hoverBgColor):h']")
            .Descendants("div")
            .Select(node => node.InnerText).Where(text => !string.IsNullOrWhiteSpace(text))
            .ToList();
        
        //Cash Flow
        var url3 = "https://finance.yahoo.com/quote/AAPL/cash-flow";
        var httpClient3 = new HttpClient();
        var html3 = httpClient3.GetStringAsync(url3).Result;
        var htmlDocument3 = new HtmlDocument();
        htmlDocument3.LoadHtml(html3);
        
        var columns3 = htmlDocument3.DocumentNode
            .SelectNodes("//div[@class='D(tbr) C($primaryColor)']")
            .Descendants("div")
            .Select(node => node.InnerText).Where(text => !string.IsNullOrWhiteSpace(text))
            .ToList();
        
        var elements3 = htmlDocument3.DocumentNode
            .SelectNodes("//div[@class='D(tbr) fi-row Bgc($hoverBgColor):h']")
            .Descendants("div")
            .Select(node => node.InnerText).Where(text => !string.IsNullOrWhiteSpace(text))
            .ToList();
    }
}