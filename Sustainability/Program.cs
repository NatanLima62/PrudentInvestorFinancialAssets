using HtmlAgilityPack;

namespace Sustainability;

public static class Program
{
    public static void Main(string[] args)
    {
        var url = "https://finance.yahoo.com/quote/AAPL/sustainability";
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "teste");
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);
        
        var totalEsgRiskScore = htmlDocument.DocumentNode
            .SelectNodes("//div[@class='Pos(r) H(55px) smartphone_Mb(15px)']")
            .Descendants("div")
            .Where(node =>
                node.GetAttributeValue("class", "").Equals("C($tertiaryColor) Fz(s)") ||
                node.GetAttributeValue("class", "").Equals("Fz(36px) Fw(600) D(ib) Mend(5px)") ||
                node.GetAttributeValue("class", "").Equals("D(ib)") ||
                node.GetAttributeValue("class", "").Equals("smartphone_D(n)"))
            .Select(node => node.InnerText)
            .ToList();
        
        var elements = htmlDocument.DocumentNode
            .SelectNodes("//div[@class='Va(t) D(ib) W(22%) smartphone_W(33%) Wow(bw) Bxz(bb) Px(5px)']")
            .Descendants("div")
            .Where(node =>
                node.GetAttributeValue("class", "").Equals("D(ib) Fz(23px) smartphone_Fz(22px) Fw(600)"))
            .Select(node => node.InnerText)
            .ToList();
    }
}

public class EsgRiskRating
{
    public TotalEsgRiskScore TotalEsgRiskScore { get; set; } = null!;
    public string EnvironmentRiskScore { get; set; } = null!;
    public string SocialRiskScore { get; set; } = null!;
    public string GovernanceRiskScore { get; set; } = null!;
}

public class TotalEsgRiskScore
{
    public string Value { get; set; } = null!;
    public string Rate { get; set; } = null!;
    public string RiskLevel { get; set; } = null!;
}