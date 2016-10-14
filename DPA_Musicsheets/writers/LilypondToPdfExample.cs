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
        public static void SaveLilypondToPdf(string sourceFolder, string sourceFileName)
        {
            string lilypondLocation = @"C:\Program Files (x86)\LilyPond\usr\bin\lilypond.exe";
            //string sourceFolder = @"c:\temp\";
            //string sourceFileName = "Twee-emmertjes-water-halen.ly";

            var process = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = sourceFolder,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = String.Format("--pdf \"{0}\"", sourceFileName),
                    FileName = lilypondLocation
                }
            };
            process.Start();
            process.WaitForExit();
            File.Delete(sourceFolder + sourceFileName);
            //process.Exited += (sender, e) => {
            //    File.Delete(sourceFolder + sourceFileName);
            //};
        }
    }
}
