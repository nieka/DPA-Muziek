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

        public EditState()
        {
            Type = StateType.Edit;

            Commands = new List<ICommand>();

            Commands.Add(new InsertBarLinesCommand());
            Commands.Add(new InsertClefCommand());
            Commands.Add(new InsertTempoCommand());
            Commands.Add(new InsertTimeCommand());
            Commands.Add(new InsertTime3_4Command());
            Commands.Add(new InsertTime6_8Command());
            Commands.Add(new OpenFileCommand());
            Commands.Add(new SaveAsPDFCommand());
            Commands.Add(new SaveAsLilypondCommand());
            
        }

        public void ActivateCommand(string keys)
        {
            foreach (ICommand command in Commands)
            {
                if (keys.Contains(command.pattern))
                {
                    command.execute();
                }
            }
        }
    }
}
