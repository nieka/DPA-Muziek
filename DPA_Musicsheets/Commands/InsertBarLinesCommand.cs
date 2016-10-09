using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.interfaces;

namespace DPA_Musicsheets.Command.Commands
{
    class InsertBarLinesCommand : ICommand
    {
        public string pattern
        {
            get
            {
                return "LeftAlt B";
            }
        }

        public void execute()
        {

        }
    }
}

//met ALT + B de benodigde bar lines invoegen waar deze ontbreken (in de selectie)