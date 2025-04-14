using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.Domain.Entities
{
    public class FileManager : BaseDomainEntity
    {


        public string Path { get; set; }

        public string Title { get; set; }
        public string? Type { get; set; }
        public bool IsUploaderFile { get; set; }
        public ICollection<FileToBlog> FileToBlog { get; set; }
        public ICollection<FileToNews> FileToNews { get; set; }
        public ICollection<FileToService> FileToService { get; set; }



    }
}
