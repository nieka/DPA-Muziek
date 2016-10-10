using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class SaveAsLilypondCommand : ICommand
    {
        private ApplicationController controller;

        public SaveAsLilypondCommand(ApplicationController controller)
        {
            this.controller = controller;
        }

        public string pattern
        {
            get
            {
                return "LeftCtrl S ";
            }
        }

        public void execute()
        {
            controller.SaveFile();
        }
    }
}

//met CTRL + S een bestand kunnen opslaan (als lilypondbestand)
