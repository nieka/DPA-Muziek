using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;
using DPA_Musicsheets.MidiFileproces.midiTypeHandler;

namespace DPA_Musicsheets.MidiFileproces.midiMessageHandler
{
    class MetaHandler : IMessageTypeHandler
    {
        public IMessageTypeHandler clone()
        {
            return new MetaHandler();
        }

        public void handel(Context context, MidiEvent midiEvent)
        {
            var metaMessage = midiEvent.MidiMessage as MetaMessage;
            IMidiTypeHandler handler = MidiTypeHandlerFactory.getHandler(metaMessage.MetaType);
            if(handler != null)
            {
                handler.handel(context, metaMessage);
            }
        }
    }
}
