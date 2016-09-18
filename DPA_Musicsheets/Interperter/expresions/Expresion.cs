using DPA_Musicsheets.classes;
using DPA_Musicsheets.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Interperter
{
    interface Expresion
    {
        void evaluat(LinkedListNode<Token> token, Staf staf);

        Expresion clone();
    }
}
