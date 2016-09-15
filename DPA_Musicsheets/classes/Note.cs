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
        private double duur;
        private Boolean sharp;
        private TieType tied;

        public Note(int octaaf, String toonHoogte, double duur, Boolean sharp, TieType tied)
        {
            this.octaaf = octaaf;
            this.duur = duur;
            this.toonHoogte = toonHoogte;
            this.sharp = sharp;
            this.tied = tied;
            
        }

        public TieType isTied()
        {
            return tied;
        }

        public int getOctaaf()
        {
            return octaaf;
        }

        public String getToonhoogte(){
            return toonHoogte;
        }

        public double getDuur()
        {
            return duur;
        }

        public Boolean isSharp()
        {
            return sharp;
        }

    }
}
