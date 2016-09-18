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

        public void evaluat(LinkedListNode<Token> token, classes.Staf staf)
        {
            if (token.Previous.Value.type != TokenType.relative)
            {
                Note note = new Note();
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
                if (Char.IsNumber(value[pos]))
                {
                    note.setDuur(Char.GetNumericValue(value[pos]));
                }

                staf.AddNote(note);
            }
        }


        public Expresion clone()
        {
            return new NootExpresion();
        }
    }
}
