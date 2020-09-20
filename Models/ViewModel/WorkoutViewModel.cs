using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class WorkoutViewModel
    {
        public int WorkoutId { get; set; }
        public string MemberName { get; set; }
        [Required]
        public Nullable<int> MemberId { get; set; }
        
        public string WorkoutDays { get; set; }
        [Required]
        public string Description { get; set; }
    }
}