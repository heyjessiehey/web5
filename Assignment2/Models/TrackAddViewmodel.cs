using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class TrackAddViewModel
    {
        [Required]
        [StringLength(200)]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        [Display(Name = "Length(ms)")]
        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int MediaTypeId { get; set; }
    }
}