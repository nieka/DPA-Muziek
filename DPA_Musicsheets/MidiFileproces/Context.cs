using DPA_Musicsheets.classes;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.MidiFileproces
{
    class Context
    {

        public Context()
        {
            musicSheet = new MusicSheet();
        }

        public TimeSignature currentTimesignature { get; set; }
        public MusicSheet musicSheet { get; set; }
        public MidiEvent nextEvent { get; set; }
        public Sequence _sequence { get; set; }
    }
}
