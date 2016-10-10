using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Tokenizer.checkers
{
    class NoteChecker : ITokenChecker
    {
        private char[] noteLookup = { 'c', 'd', 'e', 'f', 'g', 'a', 'b' };
        public bool canhandle(string input)
        {
            if(input.Length >= 2)
            {
                Boolean containsNumber = false;
                Boolean containsNote = false;

                for(int i=0; i< input.Length; i++)
                {
                    if (!containsNumber)
                    {
                        containsNumber = isNumber(input[i].ToString());
                    }
                    if (!containsNote)
                    {
                        containsNote = noteLookup.Contains(input[i]);
                    }
                }

                if(containsNote || containsNumber)
                {
                    return true;
                }
            }

            return false;
        }

        public Token handle(string input)
        {
            return new Token(TokenType.Note, input);
        }

        private Boolean isNumber(String input)
        {
            int n;
            return int.TryParse(input, out n);
        }
    }
}
