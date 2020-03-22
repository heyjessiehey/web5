using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class PlaylistBaseViewModel 
    {
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        [Display(Name = "Playlist Name")]
        public string Name { get; set; }

        [Display(Name = "Number of tracks on this playlist")]
        public int TracksCount { get; set; }
    }
}