using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class SaveAsPDFCommand : ICommand
    {
        private ApplicationController controller;

        public SaveAsPDFCommand(ApplicationController controller)
        {
            this.controller = controller;
        }

        public string pattern
        {
            get
            {
                return "LeftCtrl P S ";
            }
        }

        public void execute()
        {
            controller.SaveFile("Pdf");
        }
    }
}

//met CTRL + S + P een bestand als PDF opslaan
