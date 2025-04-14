namespace RashaPrimeWeb.Domain.Entities
{
    public class FileToService
    {
        public int ImageId { get; set; }
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public FileManager FileManager { get; set; }
    }
}
