using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaGyver.Helpers
{
    internal class TagReader
    {

        public static TagLib.File GetTags(string path)
        {
            // Returns all tags
            return TagLib.File.Create(path);
        }

        public static Dictionary<string, string> GetTagDict(string filepath)
        {
            // Returns tags from a music file
            Dictionary<string, string> tags = new Dictionary<string, string>();
            var tfile = TagLib.File.Create(filepath);

            // Yep I know this could be done with half the lines
            string artist = tfile.Tag.FirstAlbumArtist;
            string album = tfile.Tag.Album;
            string title = tfile.Tag.Title;
            string format = Path.GetExtension(filepath);
            int bitrate = tfile.Properties.AudioBitrate;

            tags.Add("artist", artist);
            tags.Add("album", album);
            tags.Add("title", title);
            tags.Add("format", format);
            tags.Add("bitrate", bitrate.ToString());
            tags.Add("path", filepath);


            return tags;
        }
    }
}
