using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Models
{
    public class PlaylistEditTracksFormViewModel : PlaylistWithDetailViewModel
    {
        public MultiSelectList TrackList { get; set; }

        
    }
}