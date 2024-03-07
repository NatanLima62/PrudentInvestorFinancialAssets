using HtmlAgilityPack;

namespace Holders;

public static class Program
{
    public static void Main(string[] args)
    {
        // var url = "https://finance.yahoo.com/quote/AAPL/holders";
        // var httpClient = new HttpClient();
        // httpClient.DefaultRequestHeaders.Add("User-Agent", "teste");
        // var html = httpClient.GetStringAsync(url).Result;
        // var htmlDocument = new HtmlDocument();
        // htmlDocument.LoadHtml(html);
        
        // var majorHolders = htmlDocument.DocumentNode
        //     .SelectNodes("//table[@class='W(100%) M(0) BdB Bdc($seperatorColor)']")
        //     .Descendants("td")
        //     .Where(node =>
        //         node.GetAttributeValue("class", "").Equals("Py(10px) Va(m) Fw(600) W(15%)"))
        //     .Select(node => node.InnerText)
        //     .ToList();
        //
        // var tables = htmlDocument.DocumentNode
        //     .SelectNodes("//table[@class='W(100%) BdB Bdc($seperatorColor)']")
        //     .ToList();
        //
        // foreach (var table in tables)
        // {
        //     var tableHead = table.SelectSingleNode(".//thead");
        //     var thValues = tableHead.Elements("tr")
        //         .SelectMany(tr => tr.Elements("th")
        //             .Where(th =>
        //                 th.Attributes["class"]?.Value == "Ta(start) Fw(400) Py(6px)" ||
        //                 th.Attributes["class"]?.Value == "Ta(end) Fw(400) Py(6px) Pstart(15px)"))
        //         .Select(th => th.InnerText.Trim())
        //         .ToList();
        //
        //     Console.WriteLine("Valores dos th:");
        //     Console.WriteLine(string.Join(", ", thValues));
        //
        //
        //     var tableBody = table.SelectSingleNode(".//tbody");
        //
        //     // Extrair os valores dos th no thead
        //     // Extrair os valores dos td no tbody
        //     var tdValues = tableBody.Elements("tr")
        //         .Select(tr =>
        //         {
        //             var tdList = tr.Elements("td")
        //                 .Where(td =>
        //                     td.Attributes["class"]?.Value == "Ta(start) Pend(10px)" ||
        //                     td.Attributes["class"]?.Value == "Ta(end) Pstart(10px)")
        //                 .Select(td => td.InnerText.Trim())
        //                 .ToList();
        //
        //             // Adicione o valor do primeiro td com a classe específica
        //             tdList.Insert(0, tr.SelectSingleNode("td[@class='Py(10px) Ta(start)']")?.InnerText.Trim());
        //
        //             return tdList;
        //         })
        //         .ToList();
        //
        //     Console.WriteLine("Valores dos td:");
        //     foreach (var tdList in tdValues)
        //     {
        //         Console.WriteLine(string.Join(", ", tdList));
        //     }
        // }

        ///////////
        var url2 = "https://finance.yahoo.com/quote/AAPL/insider-transactions";
        var httpClient2 = new HttpClient();
        httpClient2.DefaultRequestHeaders.Add("User-Agent", "teste");
        var html2 = httpClient2.GetStringAsync(url2).Result;
        var htmlDocument2 = new HtmlDocument();
        htmlDocument2.LoadHtml(html2);

        // var insiderTransactions = htmlDocument2.DocumentNode
        //     .SelectNodes("//table[@class='W(100%) M(0) BdB Bdc($seperatorColor)']")
        //     .Descendants("td")
        //     .Where(node =>
        //         node.GetAttributeValue("class", "").Equals("Py(10px) Va(m) Fw(600) W(15%)"))
        //     .Select(node => node.InnerText)
        //     .ToList();

        var tables2 = htmlDocument2.DocumentNode
            .SelectNodes("//table[@class='W(100%) M(0)']")
            .ToList();
        
        foreach (var table in tables2)
        {
            var tableHead = table.SelectSingleNode(".//thead");
            var thValues = tableHead.Elements("tr")
                .SelectMany(tr => tr.Elements("th"))
                .Select(th => th.InnerText.Trim())
                .ToList();
        
            Console.WriteLine("Valores dos th:");
            Console.WriteLine(string.Join(", ", thValues));
        
        
            var tableBody = table.SelectSingleNode(".//tbody");
        
            // Extrair os valores dos th no thead
            // Extrair os valores dos td no tbody
            var tdValues = tableBody.Elements("tr")
                .Select(tr =>
                {
                    var tdList = tr.Elements("td")
                        .Select(td => td.InnerText.Trim())
                        .ToList();
        
                    // Adicione o valor do primeiro td com a classe específica
                    tdList.Insert(0, tr.SelectSingleNode("td[@class='Ta(end) BdB Bdc($seperatorColor)']")?.InnerText.Trim());
        
                    return tdList;
                })
                .ToList();
        
            Console.WriteLine("Valores dos td:");
            foreach (var tdList in tdValues)
            {
                Console.WriteLine(string.Join(", ", tdList));
            }
        }
    }
}