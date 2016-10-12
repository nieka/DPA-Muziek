using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.interfaces;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.Command.Commands
{
    class InsertBarLinesCommand : ICommand
    {
        private ApplicationController controller;

        public InsertBarLinesCommand(ApplicationController controller)
        {
            this.controller = controller;
        }


        public string pattern
        {
            get
            {
                return "LeftCtrl LeftAlt B";
            }
        }

        public void execute()
        {
            int location = controller.window.GetEditBoxCursorLocation();
            int SelectedLenght = controller.window.GetSelectedArea();
            int e = controller.EditString.Length;
            string selectedpart = controller.EditString.Substring(location, SelectedLenght);
            int counter = 0;
            string[] notes = selectedpart.Split(' ');
            string result = "";

            foreach (string note in notes)
            {
                result += note + " ";
                counter++;

                if (counter == 3)
                {
                    result += "| ";
                    counter = 0;
                }
            }

            result = controller.EditString.Replace(selectedpart, result);
            controller.SetEditText(result);
        }
    }
}

//met ALT + B de benodigde bar lines invoegen waar deze ontbreken (in de selectie)