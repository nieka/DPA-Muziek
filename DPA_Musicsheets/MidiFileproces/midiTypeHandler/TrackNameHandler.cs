using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MidiFileproces.midiTypeHandler
{
    class TrackNameHandler : IMidiTypeHandler
    {
        public IMidiTypeHandler clone()
        {
            return new TrackNameHandler();
        }

        public void handel(Context context, MetaMessage metaMessage)
        {
            context.musicSheet.naam = Encoding.Default.GetString(metaMessage.GetBytes());
        }
    }
}
