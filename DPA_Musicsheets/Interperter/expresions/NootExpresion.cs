using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using DPA_Musicsheets.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPA_Musicsheets.Interperter.expresions
{
    class NootExpresion : Expresion
    {
        private char[] noteLookup = { 'c', 'd', 'e', 'f', 'g', 'a', 'b' };
       
        public void evaluat(LinkedListNode<Token> token, Context context)
        {
            if (token.Previous.Value.type != TokenType.relative)
            {
                Note note = new Note();
                Note lastNote = getLastNote(context.musicSheet);
                String value = token.Value.value;
                int pos =0;
                while (pos < value.Length)
                {
                    if (value[pos] == '~' && lastNote != null)
                    {
                        //De noot hoort aan de vorige noot
                        note.setTied(TieType.stop);
                        lastNote.setTied(TieType.start);
                        pos++;
                        continue;
                    }
                    if(noteLookup.Contains(value[pos]) && note.getToonhoogte() == null) { 
                        //Het eerste karakter is een noot dus we kunnen er hier vanuit gaan dat we een normale noot hebben
                        note.setToonhoogte(Convert.ToString(value[pos]));
                        pos++;
                        continue;
                    }
                    if(pos != value.Length - 1)
                    {
                        if(value.Substring(pos,value.Length -1).Contains("is") || value.Substring(pos, value.Length -1).Contains("es"))
                        {
                            if(value.Substring(pos, value.Length -1).Contains("is"))
                            {
                                note.setNootItem(NootItem.Kruis);
                            } else
                            {
                                note.setNootItem(NootItem.Mol);
                            }
                            pos += 2;
                            continue;
                        }
                    }
                   

                    int lastnumer = pos;
                    while (true)
                    {
                        if(lastnumer < value.Length -1)
                        {
                            if (Char.IsNumber(value[lastnumer + 1]))
                            {
                                lastnumer++;
                            } else
                            {
                                break;
                            }
                            
                        } else
                        {
                            break;
                        }
                    }
                    if (Char.IsNumber(value[pos]))
                    {
                        if(pos == lastnumer)
                        {
                            note.setDuur(Char.GetNumericValue(value[pos]));
                            pos++;
                        }
                        else
                        {
                            note.setDuur(Convert.ToInt16(value.Substring(pos,lastnumer - pos + 1 )));
                            pos = lastnumer + 1;
                        }
                        continue;
                    }
                    //kijken of er een punt is
                    if(value[pos] == '.')
                    {
                        note.punten = note.punten + 1;
                        pos++;
                        continue;
                    }
                    //mocht er een } staan dan ben je zo ie zo aan het einde van de noot en kan je dus verder met de volgende
                    if(value[pos] == '}')
                    {
                        pos++;
                        continue;
                    }
                }
                //bepaald de octaaf van de noot
                if (context["relative"] )
                {
                    int defaultOctaaf = context.musicSheet.startOctaaf;
                    AbstractNode noten = getLastNote(context.musicSheet);
                    if(noten != null)
                    {
                        int waardenoot = defaultOctaaf * 12 + Array.IndexOf(noteLookup, Convert.ToChar(note.toonHoogte));
                        int waardeEersteNoot = noten.getOctaaf() * 12 + Array.IndexOf(noteLookup, Convert.ToChar(noten.toonHoogte));
                        int diffrents = Math.Abs(waardeEersteNoot - waardenoot);
                        if (diffrents >= 5)
                        {
                            if (noten.getOctaaf() == defaultOctaaf)
                            {
                                note.setOctaaf(defaultOctaaf + 1);
                            }
                        }
                    }
                } 

                if(note.octaaf == 0)
                {
                    note.octaaf = context.musicSheet.startOctaaf;
                }

                context.musicSheet.addmusicSymbol(note);
            }
        }


        public Expresion clone()
        {
            return new NootExpresion();
        }

        private Note getLastNote(MusicSheet musicSheet)
        {
            LinkedListNode<IMusicSymbol> currentItem = musicSheet.items.Last;
            while(currentItem != null)
            {
                try
                {
                    return (Note) currentItem.Value;
                }
                catch (FormatException)
                {
                    currentItem = currentItem.Previous;
                }

               
            }
            return null;
        }
    }
}
