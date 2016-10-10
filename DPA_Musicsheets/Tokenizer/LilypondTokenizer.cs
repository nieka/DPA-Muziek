﻿using DPA_Musicsheets.Tokenizer.checkers;
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
        private List<ITokenChecker> TokenChecks;

        public LilypondTokenizer()
        {
            tokens = new LinkedList<Token>();
            keyWords = new Dictionary<string,TokenType>();
            keyWords.Add("\\relative", TokenType.relative);
            keyWords.Add("{", TokenType.Startblok);
            keyWords.Add("}", TokenType.EndBlok);
            keyWords.Add("\\time", TokenType.timeSignature);
            keyWords.Add("\\clef", TokenType.Clef);
            keyWords.Add("treble", TokenType.ClefType);
            keyWords.Add("|", TokenType.Maatstreep);
            keyWords.Add("\\tempo", TokenType.Tempo);
            keyWords.Add("\\version", TokenType.Version);
            keyWords.Add("\\header", TokenType.Header);
            keyWords.Add("\\repeat", TokenType.Repeat);
            keyWords.Add("volta", TokenType.Nothing);
            TokenChecks = new List<ITokenChecker>();
            TokenChecks.Add(new NoteChecker());
            TokenChecks.Add(new RustChecker());
            TokenChecks.Add(new TempoChecker());
            TokenChecks.Add(new TimeSignatureChecker());
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
                    for(int y=0; y< TokenChecks.Count; y++)
                    {
                        if (TokenChecks[y].canhandle(input))
                        {
                            tokens.AddLast(TokenChecks[y].handle(input));
                            break;
                        }
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
