using DPA_Musicsheets.classes;
using DPA_Musicsheets.Facade;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.factories
{
    class ReaderFactory
    {
        static Dictionary<String, InputReader> readers;
        static ReaderFactory()
        {
            readers = new Dictionary<String, InputReader>();
            readers.Add(".mid", new MidiAdapter());
            readers.Add(".ly", new LilypondReader());
        }

        public static InputReader getReader(string readerName)
        {
            if (readers.ContainsKey(readerName))
            {
                return readers[readerName].clone();
            }
            else
            {
                //De reader bestaad niet
                return null; 
            }
        }
    }
}
