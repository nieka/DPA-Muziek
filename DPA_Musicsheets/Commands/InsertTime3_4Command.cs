using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class InsertTime3_4Command : ICommand
    {
        public string pattern
        {
            get
            {
                return "LeftAlt + T + 3";
            }
        }

        public void execute()
        {

        }
    }
}

//met ALT + T + 3 een time 3/4 invoegen op de huidige plek 