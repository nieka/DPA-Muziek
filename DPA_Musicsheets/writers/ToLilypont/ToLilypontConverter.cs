using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using DPA_Musicsheets.writers.ToLilypont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.writers
{
    class ToLilypontConverter 
    {
        public String ToLilypoint(MusicSheet musicSheet) 
        {
            LilypontVisitor visitor = new LilypontVisitor();

            foreach (IMusicSymbol item in musicSheet.items)
            {
                item.accept(visitor);
            }

            visitor.finish();

            return visitor.data;
        }
    }
}
