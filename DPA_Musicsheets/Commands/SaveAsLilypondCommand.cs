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
        public string pattern
        {
            get
            {
                return "LeftCtrl S";
            }
        }

        public void execute()
        {

        }
    }
}

//met CTRL + S een bestand kunnen opslaan (als lilypondbestand)
