using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagement.Models.ViewModel
{
    public class GalleryViewModel
    {
        public int GalleryId { get; set; }
        [Required]
        public string Title { get; set; }
         [Required]
        public string Photo { get; set; }
         [Required]
        public string Description { get; set; }
    }
}