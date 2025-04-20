namespace RashaPrimeWeb.Application.CQRS.Language.Queries.GetLanguage;

public record GetLanguageDto 
{
    public int? Lang_Id { get; set; }

    public string LanguageTitle { get; set; }


    public string Title { get; set; }
}
