using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.writers
{
    public class LilypondToPdfExample
    {
        //public static void SaveLilypondToPdf(String location, string fileName)
        //{
        //    string lilypondLocation = @"C:\Program Files (x86)\LilyPond\usr\bin\lilypond.exe";

        //    var process = new Process
        //    {
        //        StartInfo =
        //        {
        //            WindowStyle = ProcessWindowStyle.Hidden,
        //            Arguments = String.Format("--pdf \"{0}\"", location),
        //            FileName = lilypondLocation
        //        }
        //    };

        //    if (process.Start())
        //    {
        //        File.Copy(fileName, location, true);
        //    }
        //}

        public static void SaveLilypondToPdf()
        {
            string lilypondLocation = @"C:\Program Files (x86)\LilyPond\usr\bin\lilypond.exe";
            string sourceFolder = @"c:\temp\";
            string sourceFileName = "Twee-emmertjes-water-halen.ly";
            string targetFolder = @"c:\temp\";
            string targetFileName = "Twee-emmertjes-water-halen.pdf";

            var process = new Process
            {
                StartInfo =
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = String.Format("--pdf \"{0}{1}\"", sourceFolder, sourceFileName),
                    FileName = lilypondLocation
                }
            };

            if (process.Start())
            {
                File.Copy(targetFileName, targetFolder + targetFileName, true);
            }
        }
    }
}
