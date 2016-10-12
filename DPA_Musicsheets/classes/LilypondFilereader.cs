using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class LilypondFilereader : InputReader
    {
        public InputReader clone()
        {
            return new LilypondFilereader();
        }

        public MusicSheet readNotes(string fileLocation)
        {
            LilypondReader reader = new LilypondReader();
            return reader.readNotes(System.IO.File.ReadAllText(fileLocation));
        }
    }
}
