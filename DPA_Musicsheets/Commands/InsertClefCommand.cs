using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class InsertClefCommand : ICommand
    {
        private ApplicationController controller;

        public InsertClefCommand(ApplicationController controller)
        {
            this.controller = controller;
        }

        public string pattern
        {
            get
            {
                return "LeftAlt C";
            }
        }

        public void execute()
        {

        }
    }
}

//met ALT + C een clef treble invoegen op de huidige plek