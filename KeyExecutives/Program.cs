using HtmlAgilityPack;

namespace KeyExecutives;

public static class KeyExecutives
{
    public static void Main(string[] args)
    {
        var url = "https://finance.yahoo.com/quote/AAPL/profile";
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        
        //Columns names: Name, Title, Pay, Exercised, Year Born 
        var elements = htmlDocument.DocumentNode
            .SelectNodes("//tr[@class='C($primaryColor) BdB Bdc($seperatorColor) H(36px)']")
            .Descendants("td")
            .Where(node => 
                node.GetAttributeValue("class", "").Equals("Ta(start)") || 
                node.GetAttributeValue("class", "").Equals("Ta(start) W(45%)") ||
                node.GetAttributeValue("class", "").Equals("Ta(end)"))
            .ToList();
    }
}