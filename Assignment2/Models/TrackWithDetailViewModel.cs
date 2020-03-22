using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        [Display(Name = "Album Title")]
        public string AlbumTitle { get; set; }

        [Display(Name = "Artist Name")]
        public string AlbumArtistName { get; set; }

        [Display(Name = "Media Type")]
        public string MediaTypeName { get; set; }

    }
}