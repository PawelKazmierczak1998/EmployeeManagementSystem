using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Country : BaseEntity 
    {
        //Relacja 1 do wielu z County
        [JsonIgnore]
        public List <County>? Counties { get; set; }
    }
}
