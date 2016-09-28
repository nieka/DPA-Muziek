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
    class MidiAdapter : InputReader
    {
        // De inhoud voor de midi file. Hier zitten onder andere tracks en metadata in.
        private Sequence _sequence;
        private String[] noteLookup = { "C", "C#","D","D#","E","F","F#","G","G#","A","A#","B" };
        public MusicSheet readNotes(String fileLocation)
        {
            this._sequence = new Sequence();
            this._sequence.Load(fileLocation);
            int TicksPerBeat = _sequence.Division;
            //Staf staf = new Staf();
            for (int i = 0; i < _sequence.Count; i++)
            {
                Track track = _sequence[i];
                double prevDeltaTime = 0;
                MidiEvent prevEvent = null;
                foreach (var midiEvent in track.Iterator())
                {
                    // Elke messagetype komt ook overeen met een class. Daarom moet elke keer gecast worden.
                    switch (midiEvent.MidiMessage.MessageType)
                    {
                        // ChannelMessages zijn de inhoudelijke messages.
                        case MessageType.Channel:
                            //if (prevEvent == null)
                            //{
                            //    prevEvent = midiEvent;
                            //    break;
                            //}
                            //var channelMessage = prevEvent.MidiMessage as ChannelMessage;
                            //if (channelMessage.Command.ToString().Equals("NoteOn"))
                            //{
                            //    int octaaf = (int)Math.Floor((Double)channelMessage.Data1 / 12);
                            //    String toonHoogte = noteLookup[channelMessage.Data1 - (octaaf * 12)];
                            //    NootItem item = NootItem.Geen;
                            //    if (toonHoogte.Contains("#"))
                            //    {
                            //        item = NootItem.Kruis;
                            //        toonHoogte.Replace("#", "");
                            //    }
                            //    double deltaTicks = midiEvent.AbsoluteTicks - prevEvent.AbsoluteTicks;
                            //    double percentageOfBeatNote = deltaTicks / _sequence.Division;
                            //    double percentageOfWholeNote = (1.0 / staf.getTimeSignature()[1]) * percentageOfBeatNote;
                            //    Note note = new Note(octaaf, toonHoogte, berekenDuur(percentageOfWholeNote),item, TieType.None);
                            //    staf.AddNote(note);
                            //    prevDeltaTime = midiEvent.DeltaTicks;
                                
                            //}
                            //prevEvent = midiEvent;
                            break;
                        // Meta zegt iets over de track zelf.
                        case MessageType.Meta:
                            var metaMessage = midiEvent.MidiMessage as MetaMessage;
                            //switch (metaMessage.MetaType)
                            //{
                            //    case MetaType.TrackName:
                            //        staf.setNaam(Encoding.Default.GetString(metaMessage.GetBytes()));
                            //        break;
                            //    case MetaType.TimeSignature:
                            //        String[] timSig = GetMetaString(metaMessage).Split('/');
                            //        int[] timeSignature = new int[2];
                            //        timeSignature[0] = Convert.ToInt16(timSig[0]);
                            //        timeSignature[1] = Convert.ToInt16(timSig[1]);
                            //        staf.settimeSignature(timeSignature);
                            //        break;
                            //    case MetaType.Tempo:
                            //        byte[] bytes = metaMessage.GetBytes();
                            //        int tempo = (bytes[0] & 0xff) << 16 | (bytes[1] & 0xff) << 8 | (bytes[2] & 0xff);
                            //        int bpm = 60000000 / tempo;
                            //        staf.setTempo(bpm);
                            //        break;
                            //}
                            break;
                    }
                }
            }
            MusicSheet musicSheet = new MusicSheet();
            //musicSheet.staffs.Add(staf);
            return musicSheet;
        }

        private static string GetMetaString(MetaMessage metaMessage)
        {
            byte[] bytes = metaMessage.GetBytes();
            switch (metaMessage.MetaType)
            {
                case MetaType.TimeSignature:  //kwart = 1 / 0.25 = 4
                    return  bytes[0] + "/" + 1 / Math.Pow(bytes[1], -2) ;
                case MetaType.TrackName:
                    return metaMessage.MetaType + ": " + Encoding.Default.GetString(metaMessage.GetBytes());
                default:
                    return metaMessage.MetaType + ": " + Encoding.Default.GetString(metaMessage.GetBytes());
            }
        }

        //bepaald aan de hand van de duur de preciese noot lengte
        private double berekenDuur(double percentageOfWholeNote)
        {
            for (int noteLength = 32; noteLength >= 1; noteLength /= 2)
            {
                double absoluteNoteLength = (1.0 / noteLength);

                if (percentageOfWholeNote <= absoluteNoteLength)
                {
                     return noteLength;
                }
                // Hoe met punten om te gaan...?
                // Tip: Deze zijn 1.5 keer de absoluteNoteLength. (1 keer voor de noot en 0.5 keer voor de punt)           

            }
            return 0.0;

        }

        public InputReader clone(){
            return new MidiAdapter();
        }
    }
}
