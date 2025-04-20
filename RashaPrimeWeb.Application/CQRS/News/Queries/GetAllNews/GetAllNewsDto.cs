namespace RashaPrimeWeb.Application.CQRS.News.Queries.GetAllNews;

public class GetAllNewsDto 
{
    public string TitleBrowser { get; set; }

    public string ShortTitle { get; set; }

    public string LongTitle { get; set; }

    public string Text { get; set; }

    public int Seen { get; set; }
    public string LinkKey { get; set; }

    public int? Lang_Id { get; set; }

}
