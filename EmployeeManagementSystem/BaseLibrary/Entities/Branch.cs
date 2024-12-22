

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Branch : BaseEntity
    {
        //Relacja Wielu do 1 z Department
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }

        //relacja 1 do wielu z Employee
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
