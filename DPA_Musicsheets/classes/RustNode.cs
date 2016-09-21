using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class RustNode : AbstractNode
    {
        public RustNode()
        {
            setDuur(0);
            setOctaaf(0);
            setToonhoogte("r");
            setTied(TieType.None);
        }
    }
}
