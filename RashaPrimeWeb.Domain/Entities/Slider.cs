using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.Domain.Entities
{
    public class Slider : BaseDomainEntity
    {
        public string Title { get; set; }
        [AllowHtml]
        public string Text { get; set; }
        public string PathImage { get; set; }
        public int Order { get; set; }

        public int? Lang_Id { get; set; }
        public Language Language { get; set; }

    }
}
