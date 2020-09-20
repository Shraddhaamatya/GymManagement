using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class MailViewModel
    {
        [Required]
        public string Subject { get; set; }
         [Required]
        public string Message { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}