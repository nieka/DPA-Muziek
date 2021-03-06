﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Tokenizer;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.Interperter.expresions
{
    class MaatExpresion : Expresion
    {
        public Expresion clone()
        {
            return new MaatExpresion();
        }

        public void evaluat(LinkedListNode<Token> token, Context context)
        {
            if(token.Value.type == TokenType.Maatstreep)
            {
                context.musicSheet.addmusicSymbol(new MaatStreep());
            }
        }
    }
}
