using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;
using DPA_Musicsheets.writers.ToLilypont.handlers;

namespace DPA_Musicsheets.writers.ToLilypont
{
    class LilypontVisitor : IVisotor
    {

        public string data { get; private set; }
        private List<NoteHandler> noteHandlers;
        private Dictionary<ClefType, String> clefTypeLookup;

        public LilypontVisitor()
        {
            data = "\\relative c' { ";
            noteHandlers = new List<NoteHandler>();
            noteHandlers.Add(new LinkHandler());
            noteHandlers.Add(new ToonhoogteHandler());
            noteHandlers.Add(new MolKruisHandler());
            noteHandlers.Add(new ApostrofHandler());
            noteHandlers.Add(new KommaHandler());
            noteHandlers.Add(new TimeHandler());
            noteHandlers.Add(new PuntHandler());

            clefTypeLookup = new Dictionary<ClefType, string>();
            clefTypeLookup.Add(ClefType.GClef, "treble");
            clefTypeLookup.Add(ClefType.FClef, "bass");
            clefTypeLookup.Add(ClefType.CClef, "alto");
        }

        public void finish()
        {
            data += "}";
        }

        public void visit(Clef clef)
        {
            data += "\\clef " + " " + clefTypeLookup[clef.cleftype] + " ";
        }

        public void visit(MaatStreep maatstreep)
        {
            data += "| ";
        }

        public void visit(Tempo tempo)
        {
            data += "\tempo " + tempo.nootLength + "=" + tempo.tempo + " ";
        }

        public void visit(TimeSignature timeSignature)
        {
            data += "\time " + timeSignature.timeSignature[0] + "/" + timeSignature.timeSignature[1] + " ";
        }

        public void visit(RustNode rustNode)
        {
            string tempNoot = "r" + rustNode.duur;
            data += tempNoot + " ";
        }

        public void visit(Note noot)
        {
            string tempNoot = "";

            for(int i=0; i < noteHandlers.Count; i++)
            {
                tempNoot += noteHandlers[i].Handle(noot);
            }

            data += tempNoot + " ";
        }
    }
}
