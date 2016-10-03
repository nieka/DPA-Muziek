using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Tokenizer;

namespace DPA_Musicsheets.Interperter.expresions
{
    class EndblokExpresion : Expresion
    {
        public Expresion clone()
        {
            return new EndblokExpresion();
        }

        public void evaluat(LinkedListNode<Token> token, Context context)
        {
            if (context["repeat"])
            {
                context["repeat"] = false;
            }
        }
    }
}
