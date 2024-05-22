using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MediaGyver.MediaObjects
{
    internal abstract class MediaFile
    {
        public virtual required string FileDir { get; set } // Path to parent directory
        public virtual required string FileName { get; set } // Filename, no path or extension
        public virtual required string FileExtension { get; set } // Extension, obviously
        public virtual string FullPath() {
            string extensionLessPath =  Path.Join(FileDir, FileName);
            return extensionLessPath += FileExtension;
        }
    }
}
