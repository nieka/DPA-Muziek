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
                return "LeftCtrl LeftAlt B";
            }
        }

        public void execute()
        {
            int bpn = 4;

            if(controller.EditString.Contains("\\time 3/4"))
            {
                bpn = 3;
            }
            else if(controller.EditString.Contains("\\time 4/4"))
            {
                bpn = 4;
            }
            else
            {
                bpn = 8;
            }


            //int location = controller.window.GetEditBoxCursorLocation();
            //controller.SetEditText(controller.EditString.Insert(location, "\\bar"));
        }
    }
}

//met ALT + B de benodigde bar lines invoegen waar deze ontbreken (in de selectie)