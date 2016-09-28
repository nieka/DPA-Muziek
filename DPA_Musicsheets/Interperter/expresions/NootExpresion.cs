using DPA_Musicsheets.classes;
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
                AbstractNode note = new Note();
                Staf staf = context.currentStaff;
                String value = token.Value.value;
                int pos =0;
                while (pos < value.Length)
                {
                    if (value[pos] == '~')
                    {
                        //De noot hoort aan de vorige noot
                        note.setTied(TieType.stop);
                        staf.getNoten().Last.Value.setTied(TieType.start);
                        pos++;
                        continue;
                    }
                    if(noteLookup.Contains(value[pos]) && note.getToonhoogte() == null) { 
                        //Het eerste karakter is een noot dus we kunnen er hier vanuit gaan dat we een normale noot hebben
                        note.setToonhoogte(Convert.ToString(value[pos]));
                        pos++;
                        continue;
                    }
                    else if (value[pos] == 'r')
                    {
                        note = new RustNode();
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
                if (context["relative"] && note.getToonhoogte() != "r")
                {
                    



                    //if (noten != null 
                    //    && Array.IndexOf(noteLookup, Convert.ToChar(note.toonHoogte)) < Array.IndexOf(noteLookup, Convert.ToChar(noten.Value.toonHoogte))
                    //    && note.getToonhoogte() != "r")
                    //{
                    //    staf.setOctaaf(staf.getOctaaf() + 1);
                    //}
                    //note.setOctaaf(staf.getOctaaf());
                    if(context.currentStaff.getNoten().Count != 0)
                    {
                        AbstractNode noten = context.currentStaff.getNoten().Last.Value;
                        int waardenoot = staf.getOctaaf() * 12 + Array.IndexOf(noteLookup, Convert.ToChar(note.toonHoogte));
                        int waardeEersteNoot = noten.getOctaaf() * 12 + Array.IndexOf(noteLookup, Convert.ToChar(noten.toonHoogte));
                        int diffrents = Math.Abs(waardeEersteNoot - waardenoot);
                        if (diffrents >=5 )
                        {
                            if(noten.getOctaaf() == staf.getOctaaf())
                            {
                                note.setOctaaf(staf.getOctaaf() + 1);
                            } else
                            {
                                note.setOctaaf(staf.getOctaaf());
                            }
                            
                        } else
                        {
                            note.setOctaaf(staf.getOctaaf());
                        }
                    } else
                    {
                        note.setOctaaf(staf.getOctaaf());
                    }

                } else
                {
                    note.setOctaaf(staf.getOctaaf());
                }
                

                staf.AddNote(note);
                context.currentStaff = staf;
            }
        }


        public Expresion clone()
        {
            return new NootExpresion();
        }
    }
}
