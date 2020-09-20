using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        public int? UserId { get; set; }
        [Required]
        public string  Fullname { get; set; }
         [Required]
        public string Email { get; set; }
         [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only png,jpg,gif Image files allowed.")]
        public string Photo { get; set; }
         [Required]
        public string Phone { get; set; }
        public string Gender { get; set; }
        [Required]
        [DisplayName("Membership Type")]
        public int? MembershipTypeId { get; set; }
        public string MembershipName { get; set; }

        public decimal? Price { get; set; }
        public DateTime? RegDate { get; set; }
        public decimal? Fees { get; set; }
         [Required]
         [DisplayName("Shift")]
        public int? ShiftId { get; set; }
        public string Shift { get; set; }
        
        [Required]
        public string Username { get; set; }
         [Required]
         [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [DisplayName("RoleName")]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
       
    }
}