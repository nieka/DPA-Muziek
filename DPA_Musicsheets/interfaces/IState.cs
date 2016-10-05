using DPA_Musicsheets.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.interfaces
{
    interface IState
    {
        List<ICommand> Commands { get; set; }
        StateType Type { get; set; }
    }
}
