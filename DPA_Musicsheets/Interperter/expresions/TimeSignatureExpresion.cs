using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Tokenizer;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.Interperter
{
    class TimeSignatureExpresion : Expresion
    {
        public Expresion clone()
        {
            return new TimeSignatureExpresion();
        }

        public void evaluat(LinkedListNode<Token> token, Context context)
        {
            if(token.Previous.Value.type == TokenType.timeSignature)
            {
                String[] splitValue = token.Value.value.Split('/');
                int[] timeSignature = new int[] { Convert.ToInt16(splitValue[0]), Convert.ToInt16(splitValue[1]) };
                context.musicSheet.addmusicSymbol(new TimeSignature(timeSignature));
            }
        }
    }
}
