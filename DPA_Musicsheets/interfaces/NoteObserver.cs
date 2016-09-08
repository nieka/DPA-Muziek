using DPA_Musicsheets.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.interfaces
{
    interface NoteObserver
    {
        void update(Staf data);
    }
}
