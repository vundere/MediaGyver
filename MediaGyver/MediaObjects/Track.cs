﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MediaGyver.MediaObjects
{
    public class Track : MediaFile
    {
        public override void FromTagFile(File tfile)
        {
            throw new NotImplementedException();
        }
    }
}
