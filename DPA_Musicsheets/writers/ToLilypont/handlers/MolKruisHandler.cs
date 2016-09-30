using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.writers.ToLilypont.handlers
{
    class MolKruisHandler : NoteHandler
    {
        private Dictionary<NootItem, string> noteItemLookup = new Dictionary<NootItem, string>();

        public MolKruisHandler()
        {
            noteItemLookup.Add(NootItem.Mol, "es");
            noteItemLookup.Add(NootItem.Kruis, "is");
            noteItemLookup.Add(NootItem.Geen, "");
        }
        public string Handle(Note noot)
        {
            return noteItemLookup[noot.nootItem];
        }
    }
}
