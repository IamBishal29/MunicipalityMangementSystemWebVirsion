using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEntity
{
    public class Bill:Entity
    {
        //[Key]
        //public int BillId { get; set; }

        [Required]
        public double WaterBill { get; set; }

        [Required]
        public double ElectricityBill { get; set; }

        [Required]
        public double GasBill { get; set; }

        [Required]
        public DateTime BillDate { get; set; }

        public bool Billstatus { get; set; }

        public int UserId { get; set; }
    }
}
