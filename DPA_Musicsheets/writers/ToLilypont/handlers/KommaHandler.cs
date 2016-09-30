using DPA_Musicsheets.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.writers.ToLilypont.handlers
{
    class KommaHandler : NoteHandler
    {
        public string Handle(Note noot)
        {
            string temp = "";
            for (int i = 0; i < noot.kommas; i++)
            {
                temp += ",";
            }

            return temp;
        }
    }
}
