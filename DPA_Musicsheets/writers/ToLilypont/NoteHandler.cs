using DPA_Musicsheets.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.writers.ToLilypont
{
    interface NoteHandler
    {
        string Handle(Note noot);
    }
}
