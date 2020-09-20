using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class MembershipTypeViewModel
    {
        public int MembershipTypeId { get; set; }
        [Required]
        public string MembershipName { get; set; }
          [Required]
        public decimal Price { get; set; }
         [Required]
          public int AllowedMonth { get; set; }
    }
}