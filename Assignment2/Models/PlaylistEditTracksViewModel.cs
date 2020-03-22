using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class PlaylistEditTracksViewModel
    {
        public PlaylistEditTracksViewModel()
        {
            TrackIds = new List<int>();
        }

        [Key]
        public int PlaylistId { get; set; }

    
        public IEnumerable<int> TrackIds { get; set; }
    }
}