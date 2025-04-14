using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.Domain.Entities
{
    public class Faq : BaseDomainEntity
    {

        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string? ReplayText { get; set; }

        public int? Lang_Id { get; set; }
        public Language Language { get; set; }

    }
}
