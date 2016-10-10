using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.interfaces;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.Command.Commands
{
    class InsertBarLinesCommand : ICommand
    {
        private ApplicationController controller;

        public InsertBarLinesCommand(ApplicationController controller)
        {
            this.controller = controller;
        }


        public string pattern
        {
            get
            {
                return "LeftAlt B";
            }
        }

        public void execute()
        {

        }
    }
}

//met ALT + B de benodigde bar lines invoegen waar deze ontbreken (in de selectie)