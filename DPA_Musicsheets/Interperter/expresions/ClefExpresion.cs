using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Tokenizer;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.Interperter.expresions
{
    class ClefExpresion : Expresion
    {
        private Dictionary<String, ClefType> clefLookup = new Dictionary<string, ClefType>();

        public ClefExpresion()
        {
            clefLookup.Add("treble", ClefType.GClef);
        }

        public Expresion clone()
        {
            return new ClefExpresion();
        }

        public void evaluat(LinkedListNode<Token> token, Context context)
        {
            if(token.Previous.Value.type == TokenType.Clef && token.Value.type == TokenType.ClefType)
            {
                Clef clef = new Clef(clefLookup[token.Value.value], 2);
                context.musicSheet.setClef(clef);
            }
        }
    }
}
