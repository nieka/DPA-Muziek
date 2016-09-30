using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.writers
{
    class LilypondSaver : ISave
    {
        public ISave clone()
        {
            return new LilypondSaver();
        }

        public void save(MusicSheet musicsheet, string fileLocation)
        {
            ToLilypontConverter converter = new ToLilypontConverter();
            string data = converter.ToLilypoint(musicsheet);
            System.IO.File.WriteAllText(fileLocation + ".ly", data);
        }
    }
}
