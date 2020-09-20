using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        [DisplayName("Member Name")]
        [Required]
        public Nullable<int> MemberId { get; set; }
        public string Membername { get; set; }
         [Required]
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> RemainingAmount { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
    }
}