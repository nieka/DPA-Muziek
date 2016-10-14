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
            lilypondSaver.save(musicsheet, fileLocation);
            fileLocation += ".ly";
            String[] tempArr = fileLocation.Split('\\');
            string sourcefile = "";
            for(int i=0; i < tempArr.Length -1; i++)
            {
                sourcefile += tempArr[i] + "\\";
            }
            LilypondToPdfExample.SaveLilypondToPdf(sourcefile, tempArr[tempArr.Length - 1]);
            
        }
    }
}
