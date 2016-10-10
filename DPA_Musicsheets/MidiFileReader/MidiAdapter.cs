using DPA_Musicsheets.classes;
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
        private String[] noteLookup = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        private Dictionary<double, double> nootLengtLookup;
        private Sequence _sequence;
        private MusicSheet musicSheet;
        private MidiEvent nextEvent;
        private TimeSignature currentTimesignature;

        public MidiAdapter()
        {
            musicSheet = new MusicSheet();
            nootLengtLookup = new Dictionary<double, double>();
            nootLengtLookup.Add(1, 1);
            nootLengtLookup.Add(2, 0.5);
            nootLengtLookup.Add(4, 0.25);
            nootLengtLookup.Add(8, 0.125);
            nootLengtLookup.Add(16, 0.0625);
            nootLengtLookup.Add(32, 0.03125);
        }


        public MusicSheet procesMidi(String fileLocation)
        {
            loadMidiFile(fileLocation);
            for (int i = 0; i < _sequence.Count; i++)
            {
                Track track = _sequence[i];
                foreach (var midiEvent in track.Iterator())
                {
                    // Elke messagetype komt ook overeen met een class. Daarom moet elke keer gecast worden.
                    switch (midiEvent.MidiMessage.MessageType)
                    {
                        // ChannelMessages zijn de inhoudelijke messages.
                        case MessageType.Channel:
                            if (nextEvent == null)
                            {
                                //Omdat er nog geen nextevent is word dat de huidige en gaan we door omdat anders de noot niet bepaalt kan worden
                                nextEvent = midiEvent;
                                continue;
                            }
                            var channelMessage = midiEvent.MidiMessage as ChannelMessage;
                            if (channelMessage.Command.ToString().Equals("NoteOn"))
                            {
                                procesNote(midiEvent);
                            }
                            nextEvent = midiEvent;
                            break;
                        // Meta zegt iets over de track zelf.
                        case MessageType.Meta:
                            var metaMessage = midiEvent.MidiMessage as MetaMessage;
                            byte[] bytes;
                            switch (metaMessage.MetaType)
                            {
                                case MetaType.TrackName:
                                    musicSheet.naam = Encoding.Default.GetString(metaMessage.GetBytes());
                                    break;
                                case MetaType.TimeSignature:
                                    bytes = metaMessage.GetBytes();
                                    int[] TimeSignature = new int[2];
                                    TimeSignature[0] = bytes[0];    //kwart = 1 / 0.25 = 4                    
                                    TimeSignature[1] = (int)Math.Pow(2, bytes[1]);
                                    currentTimesignature = new TimeSignature(TimeSignature);
                                    musicSheet.addmusicSymbol(currentTimesignature);
                                    break;
                                case MetaType.Tempo:
                                    bytes = metaMessage.GetBytes();
                                    int microSecondsPerNote = (bytes[0] & 0xff) << 16 | (bytes[1] & 0xff) << 8 | (bytes[2] & 0xff);
                                    int bpm = 60000000 / microSecondsPerNote;
                                    Tempo tempoObj = new Tempo(bpm, 1);// Midi kent bij het tempo niet een noot en daarom is de noot lengte standaart 1
                                    musicSheet.addmusicSymbol(tempoObj);
                                    break;

                            }
                            break;
                    }
                }
            }
            return musicSheet;
        }

        private static string GetMetaString(MetaMessage metaMessage)
        {
            byte[] bytes = metaMessage.GetBytes();
            switch (metaMessage.MetaType)
            {
                case MetaType.TimeSignature:  //kwart = 1 / 0.25 = 4
                    return bytes[0] + "/" + 1 / Math.Pow(bytes[1], -2);
                case MetaType.TrackName:
                    return metaMessage.MetaType + ": " + Encoding.Default.GetString(metaMessage.GetBytes());
                default:
                    return metaMessage.MetaType + ": " + Encoding.Default.GetString(metaMessage.GetBytes());
            }
        }


        private void procesNote(MidiEvent currentEvent)
        {
            var channelMessage = currentEvent.MidiMessage as ChannelMessage;
            //de noot is afgelopen dus kan die nu toegevoegd worden aan de music sheet
            if(channelMessage.Data2 == 0)
            {
                int octaaf = (int)Math.Floor((Double)channelMessage.Data1 / 12);
                String toonHoogte = noteLookup[channelMessage.Data1 - (octaaf * 12)];
                NootItem item = NootItem.Geen;
                if (toonHoogte.Contains("#"))
                {
                    item = NootItem.Kruis;
                    toonHoogte = toonHoogte.Replace("#", "");
                }
                double deltaTicks = Math.Abs(nextEvent.AbsoluteTicks - currentEvent.AbsoluteTicks);
                double percentageOfBeatNote = deltaTicks / _sequence.Division;
                double percentageOfWholeNote = (1.0 / currentTimesignature.timeSignature[1]) * percentageOfBeatNote;
                double duur = berekenDuur(percentageOfWholeNote);
                Note note = new Note(octaaf -1, toonHoogte, duur, item, TieType.None);
                if(percentageOfWholeNote != nootLengtLookup[duur])
                {
                    //er is een punt
                    note.punten++;
                    note.duur = duur * 2;
                }
                musicSheet.addmusicSymbol(note);
            } else
            {
                //check of er rusts zijn
                if(nextEvent.AbsoluteTicks != currentEvent.AbsoluteTicks)
                {
                    // er is een rust
                    double deltaTicks = Math.Abs(nextEvent.AbsoluteTicks - currentEvent.AbsoluteTicks);
                    double percentageOfBeatNote = deltaTicks / _sequence.Division;
                    double percentageOfWholeNote = (1.0 / currentTimesignature.timeSignature[1]) * percentageOfBeatNote;
                    RustNode rust = new RustNode();
                    rust.duur = berekenDuur(percentageOfWholeNote);
                    musicSheet.addmusicSymbol(rust);
                }
            }
        }

        private void loadMidiFile(String fileLocation)
        {
            this._sequence = new Sequence();
            this._sequence.Load(fileLocation);
        }

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
    }
    //data voor om te bepalen of er ene punt in zit
//    noot met punt een g noot
//toonhoogte = g
//percentageOfBeatNote = 1.5
//percentageOfWholeNote = 0.375
//noteLength = 2
//absoluteNoteLength = 0.5

//normale noot
//toonhoogte = g
//percentageOfBeatNote = 1
//percentageOfWholeNote = 0.25
//noteLength = 4
//absoluteNoteLength = 0.25
}
