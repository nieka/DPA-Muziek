using DPA_Musicsheets.classes;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.MidiFileproces.midiTypeHandler
{
    interface IMidiTypeHandler
    {
        void handel(Context context, MetaMessage metaMessage);
        IMidiTypeHandler clone();
    }
}
