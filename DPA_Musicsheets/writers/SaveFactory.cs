using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.writers
{
    class SaveFactory
    {
        static Dictionary<String, ISave> saver;
        static SaveFactory()
        {
            saver = new Dictionary<String, ISave>();
            saver.Add("Lilypont", new LilypondSaver());
            saver.Add("Pdf", new PdfSaver());
            saver.Add("Midi", new MidiSaver());
        }

        public static ISave getSaver(string readerName)
        {
            if (saver.ContainsKey(readerName))
            {
                return saver[readerName].clone();
            }
            else
            {
                //De saver bestaad niet
                return null;
            }
        }
    }
}
