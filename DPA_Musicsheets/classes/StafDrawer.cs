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
        public StafDrawer(IncipitViewerWPF staff)
        {
            this.staff = staff;
        } 

        public void update(Staf data)
        {
            staff.AddMusicalSymbol(new Clef(ClefType.GClef, 2));
            String[] timeSig = data.getTimeSignature().Split('/');
            staff.AddMusicalSymbol(new TimeSignature(TimeSignatureType.Numbers,Convert.ToUInt32(timeSig[0]),Convert.ToUInt32(timeSig[1])));
 
            List<Note> noten = data.getNoten();
            for (int i = 0; i < noten.Count; i++)
            {
                Note noot = noten[i];
                //staff.AddMusicalSymbol(new Note("A", 0, 4, MusicalSymbolDuration.Sixteenth, NoteStemDirection.Down, NoteTieType.None, new List<NoteBeamType>() { NoteBeamType.Start, NoteBeamType.Start }));
                int sharp;
                if(noot.isSharp()){
                    sharp = 1;
                } else {
                    sharp = 0;
                }
                staff.AddMusicalSymbol(new PSAMControlLibrary.Note(noot.getToonhoogte(),sharp,noot.getOctaaf(),)
            }
        }
    }
}
