﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Tokenizer;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.Interperter.expresions
{
    class RustExpression : Expresion
    {
        public Expresion clone()
        {
            return new RustExpression();
        }

        public void evaluat(LinkedListNode<Token> token, Context context)
        {
            RustNode note = new RustNode();
            String input = token.Value.value;
            note.octaaf = context.musicSheet.startOctaaf;
            note.duur = Convert.ToInt16(input.Substring(1));
            context.musicSheet.addmusicSymbol(note);
        }
    }
}
