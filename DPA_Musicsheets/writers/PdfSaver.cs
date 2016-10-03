using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;
using System.IO;

namespace DPA_Musicsheets.writers
{
    class PdfSaver : ISave
    {
        public ISave clone()
        {
            return new PdfSaver();
        }

        public void save(MusicSheet musicsheet, string fileLocation)
        {
            LilypondSaver lilypondSaver = new LilypondSaver();
            lilypondSaver.save(musicsheet, @"c:\temp\Twee-emmertjes-water-halen");
            //fileLocation += ".pdf";
            String[] tempArr = fileLocation.Split('\\');
            //  LilypondToPdfExample.SaveLilypondToPdf(fileLocation, tempArr[tempArr.Length - 1]);
            LilypondToPdfExample.SaveLilypondToPdf();
            //File.Delete(@"c:\temp\Twee-emmertjes-water-halen.ly");
        }
    }
}
