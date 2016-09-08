using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Facade
{
    class MidiFacade : InputReader
    {
        // De inhoud voor de midi file. Hier zitten onder andere tracks en metadata in.
        private Sequence _sequence;
        private String[] noteLookup = { "C", "C#","D","D#","E","F","F#","G","G#","A","A#","B" };

        public Staf readNotes(String fileLocation)
        {
            this._sequence = new Sequence();
            this._sequence.Load(fileLocation);
            Staf staf = new Staf();
            // sequence number is hardcode omdat voor de opdracht de midi bestand maar 1 track hoeft in te lezen.
            Track track = _sequence[2];

            foreach (var midiEvent in track.Iterator())
            {
                // Elke messagetype komt ook overeen met een class. Daarom moet elke keer gecast worden.
                switch (midiEvent.MidiMessage.MessageType)
                {
                    // ChannelMessages zijn de inhoudelijke messages.
                    case MessageType.Channel:
                        var channelMessage = midiEvent.MidiMessage as ChannelMessage;
                        // Data1: De keycode. 0 = laagste C, 1 = laagste C#, 2 = laagste D etc.
                        // 160 is centrale C op piano.
                        if (channelMessage.Command.ToString().Equals("NoteOff"))
                        {
                            int octaaf = (int) Math.Floor((Double) channelMessage.Data1 / 12);
                            String toonHoogte = noteLookup[channelMessage.Data1 - (octaaf * 12)];
                            Boolean sharp;
                            if (toonHoogte.Contains("#"))
                            {
                                sharp = true;
                                toonHoogte.Replace("#", "");
                            }
                            else
                            {
                                sharp = false;
                            }
                            int duur = midiEvent.DeltaTicks;
                            Note note = new Note(octaaf,toonHoogte, duur,sharp);
                            staf.AddNote(note);
                        }
                        break;
                    case MessageType.SystemExclusive:
                        break;
                    case MessageType.SystemCommon:
                        break;
                    case MessageType.SystemRealtime:
                        break;
                    // Meta zegt iets over de track zelf.
                    case MessageType.Meta:
                        var metaMessage = midiEvent.MidiMessage as MetaMessage;
                        switch(metaMessage.MetaType){
                            case MetaType.TrackName:
                                staf.setNaam(Encoding.Default.GetString(metaMessage.GetBytes()));
                                break;
                            case MetaType.TimeSignature:
                                staf.settimeSignature(GetMetaString(metaMessage));
                                break;
                            case MetaType.Tempo:
                                byte[] bytes = metaMessage.GetBytes();
                                int tempo = (bytes[0] & 0xff) << 16 | (bytes[1] & 0xff) << 8 | (bytes[2] & 0xff);
                                int bpm = 60000000 / tempo;
                                staf.setTempo(bpm);
                                break;
                        }
                        break;
                }
            }

            return staf;
        }

        private static string GetMetaString(MetaMessage metaMessage)
        {
            byte[] bytes = metaMessage.GetBytes();
            switch (metaMessage.MetaType)
            {
                case MetaType.TimeSignature:                               //kwart = 1 / 0.25 = 4
                    return metaMessage.MetaType + ": (" + bytes[0] + " / " + 1 / Math.Pow(bytes[1], -2) + ") ";
                case MetaType.TrackName:
                    return metaMessage.MetaType + ": " + Encoding.Default.GetString(metaMessage.GetBytes());
                default:
                    return metaMessage.MetaType + ": " + Encoding.Default.GetString(metaMessage.GetBytes());
            }
        }

        public InputReader clone(){
            return new MidiFacade();
        }
    }
}
