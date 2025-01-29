

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Town : BaseEntity
    {
        //Relacja 1 do wielu z Employee
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }

        //Relacja wielu do 1 z County
        public County? County { get; set; }
        public int CountyId { get; set; }

    }
}
