using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MidiReader
{
    class MidiFileReader : InputReader
    { 
        public InputReader clone()
        {
            return new MidiFileReader();
        }

        public MusicSheet readNotes(string data)
        {
            MidiAdapter midiAdapter = new MidiAdapter();
            return midiAdapter.procesMidi(data);
        }
        
    }
}
