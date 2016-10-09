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
        public string pattern
        {
            get
            {
                return "LeftCtrl S P";
            }
        }

        public void execute()
        {

        }
    }
}

//met CTRL + S + P een bestand als PDF opslaan
