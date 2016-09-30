using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Note : AbstractNode , IMusicSymbol
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

        public void accept(IVisotor visotor)
        {
            visotor.visit(this);
        }

        public MusicType getType()
        {
            return MusicType.Note;
        }
    }
}
