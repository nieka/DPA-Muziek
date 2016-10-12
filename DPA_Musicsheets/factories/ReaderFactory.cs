
using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using DPA_Musicsheets.MidiReader;
using System;
using System.Collections.Generic;

namespace DPA_Musicsheets.factories
{
    class ReaderFactory
    {
        static Dictionary<String, InputReader> readers;
        static ReaderFactory()
        {
            readers = new Dictionary<String, InputReader>();
            readers.Add(".mid", new MidiFileReader());
            readers.Add(".ly", new LilypondFilereader());
            readers.Add("lilypond", new LilypondReader());
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
