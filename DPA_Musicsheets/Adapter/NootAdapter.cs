using PSAMControlLibrary;
using DPA_Musicsheets.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Adapter
{
    class NootAdapter
    {
        private Dictionary<NootItem, int> noteItemLookup = new Dictionary<NootItem, int>();
        private Dictionary<double, MusicalSymbolDuration> noteLengteLookup = new Dictionary<double, MusicalSymbolDuration>();
        private Dictionary<TieType, NoteTieType> noteTieLookup = new Dictionary<TieType, NoteTieType>();
        private char[] noteLookup = { 'c', 'd', 'e', 'f', 'g', 'a', 'b' };

        public NootAdapter()
        {
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

        public PSAMControlLibrary.Note NootModelToLibrary(DPA_Musicsheets.classes.AbstractNode noot)
        {

            PSAMControlLibrary.Note muziekNote = new PSAMControlLibrary.Note(
                            noot.getToonhoogte().ToUpper(),
                            noteItemLookup[noot.getNootItem()],
                            noot.getOctaaf(),
                            noteLengteLookup[noot.getDuur()],
                            getStemDirection(noot),
                            noteTieLookup[noot.isTied()],
                            new List<NoteBeamType>() { NoteBeamType.Single 
                        });

            muziekNote.NumberOfDots = noot.punten;

            return muziekNote;
        }

        public PSAMControlLibrary.Rest RestModelToLibrary(AbstractNode noot)
        {
            Rest rest = new Rest(noteLengteLookup[noot.getDuur()]);
            rest.NumberOfDots = noot.punten;

            return rest;
        }

        private  NoteStemDirection getStemDirection(AbstractNode note)
        {
            int nootWaarde = note.getOctaaf() * 12 + Array.IndexOf(noteLookup, Convert.ToChar(note.toonHoogte));
            if (nootWaarde < 54)
            {
                return NoteStemDirection.Up;
            } else
            {
                return NoteStemDirection.Down;
            }
        }
        
    }
}
