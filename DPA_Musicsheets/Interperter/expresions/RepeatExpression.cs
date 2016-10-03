using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Tokenizer;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.Interperter.expresions
{
    class RepeatExpression : Expresion
    {
        public Expresion clone()
        {
            return new RepeatExpression();
        }

        public void evaluat(LinkedListNode<Token> token, Context context)
        {
            if(token.Next.Next.Value.type == TokenType.Number)
            {
                context["repeat"] = true;
                Repeater repeat = new Repeater();
                repeat.repeats = Convert.ToInt16(token.Next.Next.Value.value);
                context.musicSheet.addmusicSymbol(repeat);
            }
        }
    }
}
