﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Tokenizer.checkers
{
    class RustChecker : ITokenChecker
    {
        public bool canhandle(string input)
        {
            return input.Contains('r');
        }

        public Token handle(string input)
        {
            return new Token(TokenType.Rust, input);
        }
    }
}