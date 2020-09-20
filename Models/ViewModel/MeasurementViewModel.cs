using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class MeasurementViewModel
    {
        public int MeasurementId { get; set; }

        public string Fullname { get; set; }
         [Required]
        [DisplayName("Member Name")]
        public Nullable<int> MemberId { get; set; }
        [Required]
        public Nullable<decimal> Weight { get; set; }
          [Required]
        public Nullable<decimal> Chest { get; set; }
          [Required]
        public Nullable<decimal> Weist { get; set; }
          [Required]
        public Nullable<decimal> Hip { get; set; }
          [Required]
        public Nullable<decimal> Thigh { get; set; }
          [Required]
        public Nullable<decimal> Bicep { get; set; }
          [Required]
        public Nullable<decimal> Forearm { get; set; }
          [Required]
        public Nullable<System.DateTime> MeasurementDate { get; set; }
    }
}