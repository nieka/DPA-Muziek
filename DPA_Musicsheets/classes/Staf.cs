using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Staf
    {
        private LinkedList<AbstractNode> noten;
        private int tempo;
        private int[] timeSignature;
        private String naam;
        private int startOctaaf;

        public Staf (){
            noten = new LinkedList<AbstractNode>();
            timeSignature = new int[] {4,4};
        }
        public void setTempo(int tempo)
        {
            this.tempo = tempo;
        }
        public void setNaam(String naam)
        {
            this.naam = naam;
        }

        public void setOctaaf(int octaaf)
        {
            this.startOctaaf = octaaf;
        }

        public void settimeSignature(int[] timeSignature)
        {
            this.timeSignature = timeSignature;
        }
        public void AddNote(AbstractNode note)
        {
            noten.AddLast(note);
        }
        public int getOctaaf()
        {
            return startOctaaf;
        }

        public LinkedList<AbstractNode> getNoten()
        {
            return noten;
        }

        public int getTempo()
        {
            return tempo;
        }

        public int[] getTimeSignature()
        {
            return timeSignature;
        }

        public String getNaam()
        {
            return naam;
        }
    }
}
