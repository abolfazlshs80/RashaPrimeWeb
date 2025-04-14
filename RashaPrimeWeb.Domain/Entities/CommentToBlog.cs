using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.Domain.Entities
{
    public class CommentToBlog : BaseDomainEntity
    {

        [AllowHtml]
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? WebSite { get; set; }
        public int BlogId { get; set; }




        public bool? Status { get; set; } = false;
        public int? CommentSubId { get; set; } = 0;
        public int? Like { get; set; } = 0;
        public virtual Blog? Blog { get; set; }
    }
}
