using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "FullName is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Please write a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public byte[] Password { get; set; }
        [Required]
        public byte[] PasswordKey { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression("^(0|[1-9] [0-9]*)$", ErrorMessage = "Please write numeric phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public bool isAdmin { get; set; }

    }
}
