using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Note : AbstractNode
    {
        public Note(int octaaf, String toonHoogte, double duur, Boolean sharp, TieType tied)
        {
            setOctaaf(octaaf);
            setDuur(duur);
            setSharp(sharp);
            setToonhoogte(toonHoogte);
            setTied(tied);
        }

        public Note() {
            sharp = false;
            tied = TieType.None;
        }

        

    }
}
