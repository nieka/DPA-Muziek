using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class InsertTimeCommand : ICommand
    {
        private ApplicationController controller;

        public InsertTimeCommand(ApplicationController controller)
        {
            this.controller = controller;
        }

        public string pattern
        {
            get
            {
                return "LeftAlt T D4 ";
            }
        }

        public void execute()
        {

        }
    }
}

//met ALT + T een time 4/4 invoegen op de huidige plek
//met ALT + T + 4 ook een time 4/4 invoegen op de huidige plek 
