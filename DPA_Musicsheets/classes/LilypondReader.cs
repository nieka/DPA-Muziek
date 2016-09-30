using DPA_Musicsheets.interfaces;
using DPA_Musicsheets.Interperter;
using DPA_Musicsheets.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class LilypondReader : InputReader
    {

        public MusicSheet readNotes(string data)
        {
            LilypondTokenizer tokenizer = new LilypondTokenizer();
            tokenizer.proces(data);
            LinkedList<Token> tokens = tokenizer.getTokens();
            LyInterperter it = new LyInterperter();
            return it.proces(tokens);
        }

        public InputReader clone()
        {
            return new LilypondReader();
        }
    }
}
