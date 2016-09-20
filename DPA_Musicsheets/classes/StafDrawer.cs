using DPA_Musicsheets.interfaces;
using PSAMControlLibrary;
using PSAMWPFControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class StafDrawer : NoteObserver
    {
        IncipitViewerWPF staff;
        private Dictionary<double,MusicalSymbolDuration> noteLengteLookup = new Dictionary<double,MusicalSymbolDuration>();
        private Dictionary<TieType, NoteTieType> noteTieLookup = new Dictionary<TieType, NoteTieType>();
        public StafDrawer(IncipitViewerWPF staff)
        {
            this.staff = staff;
            //lookup table vullen
            noteLengteLookup.Add(1, MusicalSymbolDuration.Whole);
            noteLengteLookup.Add(2, MusicalSymbolDuration.Half);
            noteLengteLookup.Add(4, MusicalSymbolDuration.Quarter);
            noteLengteLookup.Add(8, MusicalSymbolDuration.Eighth);
            noteLengteLookup.Add(16, MusicalSymbolDuration.Sixteenth);
            noteLengteLookup.Add(32, MusicalSymbolDuration.d32nd);
            noteTieLookup.Add(TieType.None, NoteTieType.None);
            noteTieLookup.Add(TieType.start, NoteTieType.Start);
            noteTieLookup.Add(TieType.startStop, NoteTieType.StopAndStartAnother);
            noteTieLookup.Add(TieType.stop, NoteTieType.Stop);
        } 

        public void update(Staf data)
        {
            staff.AddMusicalSymbol(new Clef(ClefType.GClef, 2));
            int[] timeSig = data.getTimeSignature();
            staff.AddMusicalSymbol(new TimeSignature(TimeSignatureType.Numbers,Convert.ToUInt32(timeSig[0]),Convert.ToUInt32(timeSig[1])));

            LinkedList<Note> noten = data.getNoten();
            LinkedListNode<Note> currentNode = noten.First;
            while (currentNode != null)
            {
                Note noot = currentNode.Value;
                //staff.AddMusicalSymbol(new Note("A", 0, 4, MusicalSymbolDuration.Sixteenth, NoteStemDirection.Down, NoteTieType.None, new List<NoteBeamType>() { NoteBeamType.Start, NoteBeamType.Start }));
                int sharp;
                if (noot.isSharp())
                {
                    sharp = 1;
                }
                else
                {
                    sharp = 0;
                }

                //bepalen welke note type het is
                staff.AddMusicalSymbol(new PSAMControlLibrary.Note(noot.getToonhoogte().ToUpper(), sharp, noot.getOctaaf(), noteLengteLookup[noot.getDuur()], NoteStemDirection.Up
                    , noteTieLookup[noot.isTied()], new List<NoteBeamType>() { NoteBeamType.Single }));
                currentNode = currentNode.Next;
            }
            
        }
    }
}
