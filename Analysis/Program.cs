﻿using HtmlAgilityPack;

namespace Analysis;

public static class Program
{
    public static void Main(string[] args)
    {
        var url = "https://finance.yahoo.com/quote/AAPL/analysis";
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "teste");
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        var tables = htmlDocument.DocumentNode
            .SelectNodes("//table[@class='W(100%) M(0) BdB Bdc($seperatorColor) Mb(25px)']")
            .ToList();
        
        foreach (var table in tables)
        {
            var tableHead = table.SelectSingleNode(".//thead");
            var thValues = tableHead.Elements("tr")
                .SelectMany(tr => tr.Elements("th")
                    .Where(th => 
                        th.Attributes["class"]?.Value == "Fw(b) Fw(s) W(20%) Py(10px) C($primaryColor)" ||
                        th.Attributes["class"]?.Value == "Fw(400) W(20%) Fz(xs) C($tertiaryColor) Ta(end)"))
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
                        .Where(td => td.Attributes["class"]?.Value == "Py(10px) Ta(start)" || td.Attributes["class"]?.Value == "Ta(end)")
                        .Select(td => td.InnerText.Trim())
                        .ToList();
                    
                    // Adicione o valor do primeiro td com a classe específica
                    tdList.Insert(0, tr.SelectSingleNode("td[@class='Py(10px) Ta(start)']")?.InnerText.Trim());

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