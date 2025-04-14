namespace RashaPrimeWeb.Domain.Entities
{
    public class FileToNews
    {
        public int ImageId { get; set; }
        public int NewsId { get; set; }

        public News News { get; set; }

        public FileManager FileManager { get; set; }
    }
}
