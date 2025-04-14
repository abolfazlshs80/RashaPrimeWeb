namespace RashaPrimeWeb.Domain.Entities
{
    public class CategoryToService
    {
        public int CategoryId { get; set; }
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public Category Category { get; set; }

    }
}
