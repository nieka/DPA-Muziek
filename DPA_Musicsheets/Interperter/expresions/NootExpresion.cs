using DPA_Musicsheets.classes;
using DPA_Musicsheets.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Staf staf = context.staf;
                String value = token.Value.value;
                int pos = 0;
                if (value[pos] == '~')
                {
                    //De noot hoort aan de vorige noot
                    note.setTied(TieType.stop);
                    staf.getNoten().Last.Value.setTied(TieType.start);
                    pos++;
                }
                if(noteLookup.Contains(value[pos])) { 
                    //Het eerste karakter is een noot dus we kunnen er hier vanuit gaan dat we een normale noot hebben
                    note.setToonhoogte(Convert.ToString(value[pos]));
                    pos++;
                }
                else if (value[pos] == 'r')
                {
                    note = new RustNode();
                    pos++;
                }
                if (Char.IsNumber(value[pos]))
                {
                    note.setDuur(Char.GetNumericValue(value[pos]));
                }
                if (context["relative"])
                {
                    LinkedListNode<AbstractNode> noten = context.staf.getNoten().Last;
                    int temp = Array.IndexOf(noteLookup, Convert.ToChar(note.toonHoogte));

                    if (noten != null && Array.IndexOf(noteLookup, Convert.ToChar(note.toonHoogte)) < Array.IndexOf(noteLookup, Convert.ToChar(noten.Value.toonHoogte)))
                    {
                        note.setOctaaf(noten.Value.octaaf + 1);
                    }
                    else
                    {
                        note.setOctaaf(staf.getOctaaf());
                    }
                }
                else
                {
                    note.setOctaaf(staf.getOctaaf());
                }
                
                staf.AddNote(note);
                context.staf = staf;
            }
        }


        public Expresion clone()
        {
            return new NootExpresion();
        }
    }
}
