using DPA_Musicsheets.Adapter;
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
        ClefAdapter clefAdapter = new ClefAdapter();
        private Dictionary<double,MusicalSymbolDuration> noteLengteLookup = new Dictionary<double,MusicalSymbolDuration>();
        private Dictionary<TieType, NoteTieType> noteTieLookup = new Dictionary<TieType, NoteTieType>();
        private Dictionary<NootItem, int> noteItemLookup = new Dictionary<NootItem, int>();
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
            noteItemLookup.Add(NootItem.Mol, -1);
            noteItemLookup.Add(NootItem.Kruis, 1);
            noteItemLookup.Add(NootItem.Geen, 0);
        }

        public void update(MusicSheet data)
        {
            staff.ClearMusicalIncipit();
            staff.AddMusicalSymbol(clefAdapter.ModelToLibrary(data.getClef()));

            for (int i = 0; i < data.staffs.Count; i++)
            {
                Staf staf = data.staffs[i];
                int[] timeSig = staf.getTimeSignature();
                staff.AddMusicalSymbol(new TimeSignature(TimeSignatureType.Numbers, Convert.ToUInt32(timeSig[0]), Convert.ToUInt32(timeSig[1])));

                LinkedList<AbstractNode> noten = staf.getNoten();
                LinkedListNode<AbstractNode> currentNode = noten.First;
                while (currentNode != null)
                {
                    AbstractNode noot = currentNode.Value;
                    //staff.AddMusicalSymbol(new Note("A", 0, 4, MusicalSymbolDuration.Sixteenth, NoteStemDirection.Down, NoteTieType.None, new List<NoteBeamType>() { NoteBeamType.Start, NoteBeamType.Start }));
                    PSAMControlLibrary.Note muziekNote;
                    //bepalen welke note type het is
                    if (noot.getToonhoogte() != "r")
                    {
                        muziekNote = new PSAMControlLibrary.Note(
                            noot.getToonhoogte().ToUpper(), 
                            noteItemLookup[noot.getNootItem()], 
                            noot.getOctaaf(), 
                            noteLengteLookup[noot.getDuur()], 
                            NoteStemDirection.Up, 
                            noteTieLookup[noot.isTied()], 
                            new List<NoteBeamType>() { NoteBeamType.Single 
                        });

                        muziekNote.NumberOfDots = noot.punten;
                        staff.AddMusicalSymbol(muziekNote);
                    }
                    else
                    {
                        Rest rest = new Rest(noteLengteLookup[noot.getDuur()]);
                        rest.NumberOfDots = noot.punten;
                        staff.AddMusicalSymbol(rest);
                    }
                    currentNode = currentNode.Next;
                }

            }
        }
            
    }
}
