using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class ShiftViewModel
    {
        public int ShiftId { get; set; }
        [Required]
        public string ShiftName { get; set; }
         [Required]
        public string FromTime { get; set; }
         [Required]
        public string ToTime { get; set; }
    }
}