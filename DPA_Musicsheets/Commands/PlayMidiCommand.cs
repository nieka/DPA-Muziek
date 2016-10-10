using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class PlayMidiCommand :  ICommand
    {
        private ApplicationController controller;

        public PlayMidiCommand(ApplicationController controller)
        {
            this.controller = controller;
        }

        public string pattern
        {
            get
            {
                return "LeftCtrl M";
            }
        }

        public void execute()
        {

        }
    }
}

//met CTRL + M het bestand als midi afspelen
//(dit heb je al eerder gebouwd, nu alleen de hotkey nog)
