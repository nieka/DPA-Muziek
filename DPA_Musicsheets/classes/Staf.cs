﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class Staf
    {
        private List<Note> noten;
        private int tempo;
        private int[] timeSignature;
        private String naam;

        public Staf (){
            noten = new List<Note>();
            timeSignature = new int[2];
        }
        public void setTempo(int tempo)
        {
            this.tempo = tempo;
        }
        public void setNaam(String naam)
        {
            this.naam = naam;
        }

        public void settimeSignature(int[] timeSignature)
        {
            this.timeSignature = timeSignature;
        }
        public void AddNote(Note note)
        {
            noten.Add(note);
        }

        public List<Note> getNoten()
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
