using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaGyver.MediaObjects
{
    public class Movie : MediaFile
    {

        public string? Director {  get; set; }
        public string? Genre { get; set; }
        public int Year { get; set; }
        public long? Runtime { get; set; }
        public string? ImdbId { get; set; }
    }
}
