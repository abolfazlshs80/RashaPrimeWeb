using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.Domain.Entities;

public class Blog:BaseDomainEntity
{
    public string TitleBrowser { get; set; }

    public string ShortTitle { get; set; }

    public string LongTitle { get; set; }

    public string Text { get; set; }

    public int Seen { get; set; }
    public string LinkKey { get; set; }

    public int? Lang_Id { get; set; }
    public Language Language { get; set; }
    public ICollection<CategoryToBlog> CategoryToBlog { get; set; }
    public ICollection<FileToBlog> FileToBlog { get; set; }
    public ICollection<CommentToBlog> CommentToBlog { get; set; }
    public ICollection<TagToBlog> TagToBlog { get; set; }
}