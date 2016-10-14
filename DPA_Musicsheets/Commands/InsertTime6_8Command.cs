using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class InsertTime6_8Command : ICommand
    {
        private ApplicationController controller;

        public InsertTime6_8Command(ApplicationController controller)
        {
            this.controller = controller;
        }

        public string pattern
        {
            get
            {
                return "LeftCtrl LeftAlt T D6 ";
            }
        }

        public void execute()
        {
            int location = controller.window.GetEditBoxCursorLocation();
            controller.SetEditText(controller.EditString.Insert(location, "\\time 6/8 "));
        }
    }
}

// met ALT + T + 6 een time 6/8 invoegen op de huidige plek