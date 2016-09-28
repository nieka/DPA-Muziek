using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class MusicSheet
    {
        private Clef clef;

        public List<Staf> staffs {get; set;}
        

        public MusicSheet()
        {
            clef = new Clef();
            staffs = new List<Staf>();
        }

        
        public Clef getClef()
        {
            return clef;
        }

        public void setClef(Clef clef)
        {
            this.clef = clef;
        }
        
    }
}
