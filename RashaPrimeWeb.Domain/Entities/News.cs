using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.Domain.Entities
{
    public class News:BaseDomainEntity
    {
        public string TitleBrowser { get; set; }

        public string ShortTitle { get; set; }

        public string LongTitle { get; set; }

        public string Text { get; set; }

        public int Seen { get; set; }
        public string LinkKey { get; set; }


        public int? Lang_Id { get; set; }
        public Language Language { get; set; }
        public ICollection<CategoryToNews> CategoryToNews { get; set; }
        public ICollection<FileToNews> FileToNews { get; set; }
        // public ICollection<CommentToNews> CommentToNews { get; set; }
        public ICollection<TagToNews> TagToNews { get; set; }
    }
}
