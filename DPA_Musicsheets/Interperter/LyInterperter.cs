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
        public MusicSheet proces(LinkedList<Token> tokens)
        {
            Context context = new Context();
            LinkedListNode<Token> currentToken = tokens.First;
            while (currentToken != null)
            {
                Expresion handler = ExpressionFactory.getExpresionHandler(currentToken.Value.type);
                if (handler != null)
                {
                    handler.evaluat(currentToken, context);
                     
                }
                currentToken = currentToken.Next;
            }
            context.musicSheet.staffs.Add(context.currentStaff);
            return context.musicSheet;
        }
    }
}
