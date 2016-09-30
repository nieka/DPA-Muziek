using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Tokenizer;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.Interperter.expresions
{
    class TempoExpresioncs : Expresion
    {
        public Expresion clone()
        {
            return new TempoExpresioncs();
        }

        public void evaluat(LinkedListNode<Token> token, Context context)
        {
            if(token.Previous.Value.type == TokenType.Tempo)
            {
                String[] tempoArr = token.Value.value.Split('=');
                context.musicSheet.addmusicSymbol(new Tempo(Convert.ToInt16(tempoArr[1]), Convert.ToInt16(tempoArr[0])));
            }
        }
    }
}
