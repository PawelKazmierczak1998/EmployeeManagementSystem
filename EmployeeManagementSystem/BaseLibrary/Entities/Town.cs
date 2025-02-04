

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Town : BaseEntity
    {

        //Relacja wielu do 1 z County
        public County? County { get; set; }
        public int CountyId { get; set; }

        //Relacja 1 do wielu z Employee
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }

    }
}
