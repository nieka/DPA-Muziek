using DPA_Musicsheets.classes;
using DPA_Musicsheets.Command.Commands;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DPA_Musicsheets.States
{
    class PlayState : IState
    {
        public StateType Type { get; set; }
        public List<ICommand> Commands { get; set; }

        private ApplicationController controller;

        public PlayState(ApplicationController controller)
        {
            Type = StateType.Play;
            this.controller = controller;

            Commands = new List<ICommand>();

            Commands.Add(new OpenFileCommand(controller));
            Commands.Add(new SaveAsPDFCommand(controller));
            Commands.Add(new SaveAsLilypondCommand(controller));
            
        }

        public bool ActivateCommand(string keys)
        {
            foreach(ICommand command in Commands)
            {
                if(keys.Contains(command.pattern))
                {
                    command.execute();
                    return true;
                }
            }

            return false;
        }
    }
}
