using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class RustNode : AbstractNode
    {
        public RustNode(double duur)
        {
            setDuur(duur);
            setOctaaf(0);
            setSharp(false);
            setToonhoogte("");
            setTied(TieType.None);
        }
    }
}
