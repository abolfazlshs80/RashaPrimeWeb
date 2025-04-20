namespace RashaPrimeWeb.Application.CQRS.Tag.Queries.GetTag;

public record GetTagDto 
{
    public int Id { get; set; }
    public string Name { get; set; }
}
