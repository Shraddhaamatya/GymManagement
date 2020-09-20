using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class ProteinViewModel
    {
        public int ProteinId { get; set; }
        [Required]
        public string ProteinName { get; set; }
         [Required]
        public decimal? Price { get; set; }
         [Required]
        public string Description { get; set; }
    }
}