using DPA_Musicsheets.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.interfaces
{
    interface IVisotor
    {
        void visit(Note noot);
        void visit(RustNode rustNode);
        void visit(Clef clef);
        void visit(TimeSignature timeSignature);
        void visit(MaatStreep maatstreep);
        void visit(Tempo tempo);
        void visit(Repeater repeater);
    }
}
