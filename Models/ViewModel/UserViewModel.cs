using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class UserViewModel
    {
       
            public int UserId { get; set; }
        [Required(ErrorMessage = "Username Required")]
            public string Username { get; set; }
            [Required(ErrorMessage = "Email Required")]
            [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Not a valid email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password Required")]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage = "Password Mismatch")]
            public string RetypePassword { get; set; }

            [Required(ErrorMessage = "Contact No Required")]
            public string Phone { get; set; }

           

            [Required(ErrorMessage = "Fullname Required")]
            public string Fullname { get; set; }

          
           
            public string Photo { get; set; }

            [Required(ErrorMessage = "Role Required")]
            public int? RoleId { get; set; }

            public string Rolename { get; set; }
            [Required]
            public string Gender { get; set; }

        
    }
}