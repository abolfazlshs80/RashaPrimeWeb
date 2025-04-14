using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RashaPrimeWeb.Domain.Entities
{
    public class FileToBlog
    {
     
        [Key, Column(Order = 0)]
        public int ImageId { get; set; }
        [Key, Column(Order = 1)]
        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public FileManager FileManager { get; set; }
    }
}
