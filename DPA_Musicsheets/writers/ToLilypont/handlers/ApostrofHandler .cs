using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.writers.ToLilypont.handlers
{
    class ApostrofHandler : NoteHandler
    {
        public string Handle(Note noot)
        {
            string temp = "";
            for(int i=0; i< noot.apostrof; i++)
            {
                temp += "'";
            }

            return temp;
        }
    }
}
