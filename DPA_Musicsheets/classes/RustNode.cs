using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class RustNode : AbstractNode, IMusicSymbol  
    {
        public void accept(IVisotor visotor)
        {
            visotor.visit(this);
        }

        public MusicType getType()
        {
            return MusicType.Rust;
        }
    }
}
