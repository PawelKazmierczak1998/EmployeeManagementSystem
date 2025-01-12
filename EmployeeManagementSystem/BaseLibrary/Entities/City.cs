using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        //Relacja wielu do 1 z Country
        public Country? Country { get; set; }
        public int CountryId { get; set; }

        //Relacja 1 do wielu z Town
        [JsonIgnore]
        public List<Town>? Towns { get; set; }
    }
}
