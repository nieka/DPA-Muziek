using DPA_Musicsheets.classes;
using DPA_Musicsheets.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Interperter
{
    class LyInterperter
    {
        Staf staff;

        public LyInterperter()
        {
            staff = new Staf();
        }
        
        public void proces(LinkedList<Token> tokens)
        {
            LinkedListNode<Token> currentToken = tokens.First;
            while (currentToken != null)
            {
                Expresion handler = ExpressionFactory.getExpresionHandler(currentToken.Value.type);
                if (handler != null)
                {
                    handler.evaluat(currentToken, staff);
                     
                }
                currentToken = currentToken.Next;
            }

        }
    }
}
