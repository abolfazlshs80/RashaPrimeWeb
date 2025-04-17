using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.Domain.Entities
{
    public class Menu : BaseDomainEntity
    {
     
        public bool StatusInUserFooterMenu { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public int Order { get; set; }
        public bool StatusInFooter { get; set; }

        public bool StatusInMainMenu { get; set; }

        public bool StatusInUserMenu { get; set; }

        public bool StatusInAdminMenu { get; set; }
        public string RoleName { get; set; }
        public string Icons { get; set; }
        public string ControllerName { get; set; }

        public int? Lang_Id { get; set; }
        public Language Language { get; set; }
    }
}
