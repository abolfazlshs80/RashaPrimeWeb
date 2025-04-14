namespace RashaPrimeWeb.Domain.Entities
{
    public class TagToBlog
    {


        public int TagId { get; set; }
        public int BlogId { get; set; }

        public Tag Tag { get; set; }
        public Blog Blog { get; set; }

    }
}
