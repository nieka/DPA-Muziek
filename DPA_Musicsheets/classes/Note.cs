using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Note
    {
        private int octaaf;
        private String toonHoogte;
        private int duur;
        private Boolean sharp;

        public Note(int octaaf, String toonHoogte, int duur, Boolean sharp)
        {
            this.octaaf = octaaf;
            this.duur = duur;
            this.toonHoogte = toonHoogte;
            this.sharp = sharp;
            
        }

        public int getOctaaf()
        {
            return octaaf;
        }

        public String getToonhoogte(){
            return toonHoogte;
        }

        public int getDuur()
        {
            return duur;
        }

        public Boolean isSharp()
        {
            return sharp;
        }

    }
}
