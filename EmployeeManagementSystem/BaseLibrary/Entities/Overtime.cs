using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Overtime : OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfHours { get; set; }

        //Relacja wielu do 1 z VacationType
        public OvertimeType?    OvertimeType { get; set; }
        [Required]
        public int OvertimeTypeId { get; set; }
    }
}
