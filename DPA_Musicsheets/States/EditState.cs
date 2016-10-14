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
    class EditState : IState
    {
        
        public StateType Type { get; set; }
        public List<ICommand> Commands { get; set; }

        private ApplicationController controller;

        public EditState(ApplicationController controller)
        {
            Type = StateType.Edit;
            this.controller = controller;

            controller.window.ButtonFactory("Edit");
            controller.SetEditText(controller.GetLilypond());

            Commands = new List<ICommand>();

            Commands.Add(new InsertBarLinesCommand(controller));
            Commands.Add(new InsertClefCommand(controller));
            Commands.Add(new InsertTempoCommand(controller));
            Commands.Add(new InsertTimeCommand(controller));
            Commands.Add(new InsertTime3_4Command(controller));
            Commands.Add(new InsertTime6_8Command(controller));
            Commands.Add(new OpenFileCommand(controller));
            Commands.Add(new SaveAsPDFCommand(controller));
            Commands.Add(new SaveAsLilypondCommand(controller));
            
        }

        public bool ActivateCommand(string keys)
        {
            foreach (ICommand command in Commands)
            {
                if (keys.Contains(command.pattern))
                {
                    command.execute();
                    return true;
                }
            }

            return false;
        }

        public void SwitchState()
        {
            controller.State = new PlayState(controller);
        }
    }
}