using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEntity
{
    public class Complain:Entity
    {
        //[Key]
        //public int ComplainId { get; set; }

        [Required]
        public String ComplainMsg { get; set; }

        public String Other { get; set; }

        public int UserId { get; set; }


    }
}
