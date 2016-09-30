using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class TimeSignature : IMusicSymbol
    {
        public int[] timeSignature = new int[2];

        public TimeSignature(int[] timeSignature)
        {
            this.timeSignature = timeSignature;
        }

        public void accept(IVisotor visotor)
        {
            visotor.visit(this);
        }

        public MusicType getType()
        {
            return MusicType.TimeSignature;
        }
    }
}
