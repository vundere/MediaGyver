using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MediaGyver.MediaObjects
{
    public abstract class MediaFile
    {
        public virtual string? FileDir { get; set; } // Path to parent directory
        public virtual string? FileName { get; set; } // Filename, no path or extension
        public virtual string? FileExtension { get; set; } // Extension, obviously
        public virtual string FullPath() {
            string extensionLessPath =  Path.Join(FileDir, FileName);
            return extensionLessPath += FileExtension;
        }
        public virtual string? Title {  get; set; }

        public abstract void FromTagFile(TagLib.File tfile);
    }
}
