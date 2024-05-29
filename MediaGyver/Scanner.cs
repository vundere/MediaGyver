using MediaGyver.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaGyver
{
    internal class Scanner
    {
        public Scanner() { }
        public List<TagLib.File>? ScannerResult { get; set; }

        public void Scan(string startpath)
        {
            List<TagLib.File> res = new List<TagLib.File>();
            List<string> files = new(Directory.EnumerateFiles(startpath, "*", SearchOption.AllDirectories));
            foreach (string file in files)
            {
                try
                {
                    res.Add(TagReader.GetTags(file));
                }
                catch (Exception ex)
                {
                    if (ex is TagLib.UnsupportedFormatException || ex is TagLib.CorruptFileException)
                    {
                        // TODO log these
                        continue;
                    }
                    else 
                    {
                        throw;
                    }
                }
            }
            ScannerResult = res;
        }
    }
}
