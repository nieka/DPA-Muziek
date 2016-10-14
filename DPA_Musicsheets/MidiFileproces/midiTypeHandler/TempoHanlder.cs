using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MidiFileproces.midiTypeHandler
{
    class TempoHanlder : IMidiTypeHandler
    {
        public IMidiTypeHandler clone()
        {
            return new TempoHanlder();
        }

        public void handel(Context context, MetaMessage metaMessage)
        {
            byte[] bytes = metaMessage.GetBytes();
            int microSecondsPerNote = (bytes[0] & 0xff) << 16 | (bytes[1] & 0xff) << 8 | (bytes[2] & 0xff);
            int bpm = 60000000 / microSecondsPerNote;
            Tempo tempoObj = new Tempo(bpm, 1);// Midi kent bij het tempo niet een noot en daarom is de noot lengte standaart 1
            context.musicSheet.addmusicSymbol(tempoObj);
        }
    }
}
