using System.ComponentModel.DataAnnotations;

namespace RashaPrimeWeb.Domain.Entities
{
    public class Language
    {
        [Key]
        public int? Lang_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string LanguageTitle { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public List<Blog> Blog { get; set; }
        public List<Slider> Slider { get; set; }
        public List<Menu> Menu { get; set; }
        public List<Category> Category { get; set; }
        public List<News> News { get; set; }
        public List<Service> Service { get; set; }
        public List<Faq> Faq { get; set; }
        public List<Setting> Setting { get; set; }
        public List<Tag> Tag { get; set; }
    }
}
