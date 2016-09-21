using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Note : AbstractNode
    {
        public Note(int octaaf, String toonHoogte, double duur, NootItem item, TieType tied)
        {
            setOctaaf(octaaf);
            setDuur(duur);
            setNootItem(item);
            setToonhoogte(toonHoogte);
            setTied(tied);
        }

        public Note() {
            tied = TieType.None;
        }

        

    }
}
