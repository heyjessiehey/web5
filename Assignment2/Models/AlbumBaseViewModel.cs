﻿using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class AlbumBaseViewModel
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

    }
}