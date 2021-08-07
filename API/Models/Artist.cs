using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Artist
    {
        public int ArtistID { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Bio { get; set; } = "";
        public string ImageURL { get; set; } = "";
        public string heroURL { get; set; } = "";
    }
}