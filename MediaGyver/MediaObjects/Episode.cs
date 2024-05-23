using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaGyver.MediaObjects
{
    public class Episode : MediaFile
    {
        // Class for episodes of a TV show

        public int Season {  get; set; }
        public int EpisodeNumber { get; set; }
        public long Duration { get; set; }
    }
}
