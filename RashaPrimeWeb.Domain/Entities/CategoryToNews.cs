namespace RashaPrimeWeb.Domain.Entities
{
    public class CategoryToNews
    {
        public int CategoryId { get; set; }
        public int NewsId { get; set; }

        public News News { get; set; }

        public Category Category { get; set; }

    }
}
