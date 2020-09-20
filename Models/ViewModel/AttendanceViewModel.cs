using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class AttendanceViewModel
    {
        public int AttendanceId { get; set; }
        [Required]
        public int MemberId { get; set; }

        public string MemberName { get; set; }
        [Required]
        public DateTime? AttendanceDate { get; set; }
        public string Status { get; set; }
    }
}