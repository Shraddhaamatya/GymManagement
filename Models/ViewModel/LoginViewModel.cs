using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class LoginViewModel
    {

        public int UserId { get; set; }
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }
       

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

       
    }
}