

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class GeneralDepartment: BaseEntity
    {
        // Reracje 1 do wielu z Department
        [JsonIgnore]
        public List<Department>? Departments { get; set; }
    }
}
