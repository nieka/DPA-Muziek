using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Command.Commands
{
    class OpenFileCommand : ICommand
    {
        public string pattern
        {
            get
            {
                return "LeftCtrl O";
            }
        }

        public void execute()
        {

        }
    }
}

//met CTRL + O een bestand openen
