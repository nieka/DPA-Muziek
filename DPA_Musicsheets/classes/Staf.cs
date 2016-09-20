using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Staf
    {
        private LinkedList<Note> noten;
        private int tempo;
        private int[] timeSignature;
        private String naam;
        private int startOctaaf;

        public Staf (){
            noten = new LinkedList<Note>();
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
        public void AddNote(Note note)
        {
            noten.AddLast(note);
        }
        public int getOctaaf()
        {
            return startOctaaf;
        }

        public LinkedList<Note> getNoten()
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
