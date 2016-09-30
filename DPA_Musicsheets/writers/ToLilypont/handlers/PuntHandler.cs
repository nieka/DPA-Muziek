using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.writers.ToLilypont.handlers
{
    class PuntHandler : NoteHandler
    {
        public string Handle(Note noot)
        {
            string temp = "";
            for (int i = 0; i < noot.punten; i++)
            {
                temp += ".";
            }

            return temp;
        }
    }
}
