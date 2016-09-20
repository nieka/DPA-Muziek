using DPA_Musicsheets.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Interperter
{
    class Context
    {
        private Dictionary<string, Boolean> _variables;
        public Staf staf { get; set; }

        public Context()
        {
            _variables = new Dictionary<string, Boolean>();
            staf = new Staf();
        }

        public Boolean this[string variableName]
        {
            get { return _variables[variableName]; }
            set { _variables[variableName] = value; }
        }
    }
}
