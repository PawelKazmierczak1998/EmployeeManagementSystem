

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {
        // Relacja  Wiele do 1 z GeneralDepartment

        public int GeneralDepartmentId { get; set; }
        public GeneralDepartment? GeneralDepartment { get; set; }


        //Relacja 1 do wielu z Brench
        [JsonIgnore]
        public List<Branch>? Branches { get; set; }
    }
}
