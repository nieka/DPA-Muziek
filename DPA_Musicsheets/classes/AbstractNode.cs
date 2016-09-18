using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    abstract class  AbstractNode
    {
        public int octaaf;
        public String toonHoogte;
        public double duur;
        public Boolean sharp;
        public TieType tied;

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
        public void setTied(TieType tied)
        {
            this.tied = tied;
        }

        public void setOctaaf(int octaaf)
        {
            this.octaaf = octaaf;
        }

        public void setToonhoogte(String toonHoogte)
        {
            this.toonHoogte = toonHoogte;
        }

        public void setDuur(double duur)
        {
            this.duur = duur;
        }

        public void setSharp(Boolean sharp)
        {
            this.sharp = sharp;
        }

    }
}
