using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEntity
{
   public class User:Entity
    {
        //[Key]
        //public int UserId { get; set; }
        [Required]
        [MinLength(5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must be between 4 and 8 digits long and include at least one numeric digit")]
        [RegularExpression(@"^(?=.*\d).{4,8}$")]
        public string Password { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
       [RegularExpression(@"^(?:\+88|01)?\d{11}$",ErrorMessage = "Invalid Mobile No!.")]
        public string MobileNo { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }
        
       [DefaultValue(false)]
        public bool AdminCheck { get; set; }

    }
}
