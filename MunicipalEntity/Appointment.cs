using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEntity
{
    public class Appointment:Entity
    {
        //[Key]
        //public int AppointId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public int SerialNo { get; set; }

        public int UserId { get; set; }

    }
}
