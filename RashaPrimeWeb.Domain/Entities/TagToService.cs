namespace RashaPrimeWeb.Domain.Entities
{
    public class TagToService
    {


        public int TagId { get; set; }
        public int ServiceId { get; set; }

        public Tag Tag { get; set; }
        public Service Service { get; set; }

    }
}
