using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.writers.ToLilypont.handlers
{
    class LinkHandler : NoteHandler
    {
        public string Handle(Note noot)
        {
            if(noot.tied == TieType.stop)
            {
                return "~";
            }

            return "";
        }
    }
}
