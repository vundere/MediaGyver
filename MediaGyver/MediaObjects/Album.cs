using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MediaGyver.MediaObjects
{
    public class Album : MediaFile
    {
        public required int Tracktotal { get; set; }
        public int? Discs { get; set; }
        public override void FromTagFile(File tfile)
        {
            throw new NotImplementedException();
        }
    }
}
