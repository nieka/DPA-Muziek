using DPA_Musicsheets.classes;
using DPA_Musicsheets.MidiFileproces;
using DPA_Musicsheets.MidiFileproces.midiMessageHandler;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.MidiReader
{
    class MidiAdapter
    {
        private Context context;

        public MidiAdapter()
        {
            context = new Context();
        }

        public MusicSheet procesMidi(String fileLocation)
        {
            loadMidiFile(fileLocation);
            for (int i = 0; i < context._sequence.Count; i++)
            {
                Track track = context._sequence[i];
                foreach (var midiEvent in track.Iterator())
                {
                    IMessageTypeHandler handler = ChannelHandlerFactory.getHandler(midiEvent.MidiMessage.MessageType);
                    if(handler != null)
                    {
                        handler.handel(context, midiEvent);
                    }
                }
            }
            return context.musicSheet;
        }
       

        private void loadMidiFile(String fileLocation)
        {
            context._sequence = new Sequence();
            context._sequence.Load(fileLocation);
        }

       
    }
}
