using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MidiFileproces.midiTypeHandler
{
    class TimeSignatureHandler : IMidiTypeHandler
    {
        public IMidiTypeHandler clone()
        {
            return new TimeSignatureHandler();
        }

        public void handel(Context context, MetaMessage metaMessage)
        {
            byte[] bytes = metaMessage.GetBytes();
            int[] TimeSignature = new int[2];
            TimeSignature[0] = bytes[0];    //kwart = 1 / 0.25 = 4                    
            TimeSignature[1] = (int)Math.Pow(2, bytes[1]);
            context.currentTimesignature = new TimeSignature(TimeSignature);
            context.musicSheet.addmusicSymbol(context.currentTimesignature);
        }
    }
}
