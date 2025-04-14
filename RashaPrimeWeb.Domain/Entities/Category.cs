using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.Domain.Entities
{
    public class Category : BaseDomainEntity
    {

        public bool IsSugestionHomePage { get; set; }
        public bool IsMenuHomePage { get; set; }
        public string SVG_Icon { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Type { get; set; }
        public string? Text { get; set; }

        public ICollection<CategoryToBlog> CategoryToBlog { get; set; }
        public ICollection<CategoryToNews> CategoryToNews { get; set; }


        public int? Lang_Id { get; set; }
        public Language Language { get; set; }


    }
}
