namespace RashaPrimeWeb.Application.CQRS.Faq.Queries.GetFaq;

public record GetFaqDto 
{
    public int Id { get; set; }
    public string Text { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }
    public string Phone { get; set; }

    public string? ReplayText { get; set; }

    public int? Lang_Id { get; set; }
}
