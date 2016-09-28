using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Clef : IMusicSymbol
    {
        public  ClefType cleftype { get; set; }
        public  int location  { get; set; }

        public Clef()
        {
            cleftype = ClefType.GClef;
            location = 2;
        }

        public Clef(ClefType type, int location)
        {
            this.cleftype = type;
            this.location = location;
        }

        public void accept(IVisotor visotor)
        {
            visotor.visit(this);
        }
    }
}
