using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEntity
{
    public class VoterId:Entity
    {
        //[Key]
        //public int RegistrationNo { get; set; }

        [Required]
        public DateTime DateOfissue { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid Name format!.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid Name format!.")]
        public string FathersName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid Name format!.")]
        public string MothersName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string PermanentAddress { get; set; }

        [Required]
        public string PresentAddress { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string VotingArea { get; set; }

        public int UserId { get; set; }
    }
}
