using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Tokenizer
{
    class LilypondTokenizer
    {
        private LinkedList<Token> tokens;
        private String[] inputList;
        private Dictionary<String, TokenType> keyWords;


        public LilypondTokenizer()
        {
            tokens = new LinkedList<Token>();
            keyWords = new Dictionary<string,TokenType>();
            keyWords.Add("\\relative", TokenType.relative);
            keyWords.Add("{", TokenType.Startblok);
            keyWords.Add("}", TokenType.EndBlok);
            keyWords.Add("\\time", TokenType.timeSignature);
        }

        public void proces(String music)
        {
            music = music.Replace("\r\n", string.Empty);
            inputList = music.Split(' ');
            for (int i = 0; i < inputList.Length; i++)
            {
                String input = inputList[i];
                if (keyWords.ContainsKey(input))
                {
                    setKeyWord(input);
                }
                else
                {
                    if (input.Contains("/"))
                    {
                        Token token = new Token(TokenType.timeSignaturedata, input);
                        tokens.AddLast(token);
                    } else if (input.Length > 0)
                    {
                        Token token = new Token(TokenType.Note, input);
                        tokens.AddLast(token);
                    }
                }
            }
        }

        public LinkedList<Token> getTokens()
        {
            return tokens;
        }

        private void setKeyWord(String keyword){
            Token token = new Token(keyWords[keyword], keyword);
            tokens.AddLast(token);
        }        
    }
}
