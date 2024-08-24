using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MediaGyver.MediaObjects
{
    public class Track : MediaFile
    {
        public Track() { }
        public Track(TagLib.File file) : this ()
        {
            FromTagFile(file);
        }
        //public MediaObjects.Artist Artist { get; set; }
        //public MediaObjects.Album Album { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public string? Format { get; set; } // Need to check if we can get path or format from tag file
        public int? Bitrate { get; set; }
        public uint? Year { get; set; }
        public TagLib.File File { get; set; }
        public Track Me { get; set; }


        public override void FromTagFile(TagLib.File tfile)
        {

            string artist = tfile.Tag.FirstPerformer;
            this.Artist = artist;
            string album = tfile.Tag.Album;
            this.Album = album;
            string title = tfile.Tag.Title;
            this.Title = title;
            // string format = Path.GetExtension(filepath);
            int bitrate = tfile.Properties.AudioBitrate;
            this.Bitrate = bitrate;
            uint year = tfile.Tag.Year;
            this.Year = year;
            this.File = tfile;
            this.Me = this;
        }

        public override string ToString()
        {
            return this.Title + " - " + this.Artist;
        }
    }
}
