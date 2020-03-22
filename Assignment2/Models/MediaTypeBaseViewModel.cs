using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class MediaTypeBaseViewModel
    {
        [Key]
        public int MediaTypeId { get; set; }

        [StringLength(120)]
        [Display (Name = "Type Name")]
        public string Name { get; set; }

    }
}