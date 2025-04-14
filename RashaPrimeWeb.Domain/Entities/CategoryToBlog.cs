namespace RashaPrimeWeb.Domain.Entities
{
    public class CategoryToBlog
    {
        public int CategoryId { get; set; }
        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public Category Category { get; set; }

    }
}
