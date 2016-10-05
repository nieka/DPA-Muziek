using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.States
{
    class EditState : IState
    {
        public List<ICommand> Commands { get; set; }
        public StateType Type { get; set; }

        public EditState()
        {
            Commands = new List<ICommand>();
            Type = StateType.Play;
        }
    }
}
