using DPA_Musicsheets.classes;
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
        private ApplicationController controller;

        public InsertTempoCommand(ApplicationController controller)
        {
            this.controller = controller;
        }


        public string pattern
        {
            get
            {
                return "LeftCtrl LeftAlt S ";
            }
        }

        public void execute()
        {
            int location = controller.window.GetEditBoxCursorLocation();
            controller.SetEditText(controller.EditString.Insert(location, "\\tempo 4 = 120"));
        }
    }
}

//met ALT + S een tempo (speed) 4=120 invoegen op de huidige plek