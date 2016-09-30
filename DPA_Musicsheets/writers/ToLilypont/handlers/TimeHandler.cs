using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.writers.ToLilypont
{
    class TimeHandler : NoteHandler
    {
        public string Handle(Note noot)
        {
            return Convert.ToString(noot.duur);
        }
    }
}
