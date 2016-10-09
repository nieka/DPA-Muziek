using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class InsertTempoCommand : ICommand
    {
        public string pattern
        {
            get
            {
                return "LeftAlt S";
            }
        }

        public void execute()
        {

        }
    }
}

//met ALT + S een tempo (speed) 4=120 invoegen op de huidige plek