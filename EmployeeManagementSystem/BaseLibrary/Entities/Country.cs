using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Country : BaseEntity 
    {
        //Relacja 1 do wielu z City
        [JsonIgnore]
        public List <City>? Cities { get; set; }
    }
}
