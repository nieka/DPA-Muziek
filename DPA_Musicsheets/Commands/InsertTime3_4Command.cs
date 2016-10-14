using DPA_Musicsheets.classes;
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
        private ApplicationController controller;

        public InsertTime3_4Command(ApplicationController controller)
        {
            this.controller = controller;
        }

        public string pattern
        {
            get
            {
                return "LeftCtrl LeftAlt T D3 ";
            }
        }

        public void execute()
        {
            int location = controller.window.GetEditBoxCursorLocation();
            controller.SetEditText(controller.EditString.Insert(location, "\\time 3/4 "));
        }
    }
}

//met ALT + T + 3 een time 3/4 invoegen op de huidige plek 