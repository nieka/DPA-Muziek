using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Tempo : IMusicSymbol
    {
        public int tempo { set; get; }
        public int nootLength { set; get; }

        public Tempo (int temp, int nootLength)
        {
            this.tempo = tempo;
            this.nootLength = nootLength;
        }

        public void accept(IVisotor visotor)
        {
            visotor.visit(this);
        }
    }
}
