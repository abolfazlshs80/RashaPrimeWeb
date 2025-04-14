using System.Text.Json.Serialization;
using RashaPrimeWeb.Domain.Entities.Common;
//using Newtonsoft.Json;

namespace RashaPrimeWeb.Domain.Entities
{
    public class Tag : BaseDomainEntity
    {


        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<TagToBlog> TagToBlog { get; set; }
        public IEnumerable<TagToNews> TagToNews { get; set; }
        public IEnumerable<TagToService> TagToService { get; set; }


        public int? Lang_Id { get; set; }
        public Language Language { get; set; }

    }
}
