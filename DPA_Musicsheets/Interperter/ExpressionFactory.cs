﻿using DPA_Musicsheets.Interperter.expresions;
using DPA_Musicsheets.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Interperter
{
    class ExpressionFactory
    {
        static Dictionary<TokenType, Expresion> expressions;
        static ExpressionFactory()
        {
            expressions = new Dictionary<TokenType, Expresion>();
            expressions.Add(TokenType.Note, new NootExpresion());
            expressions.Add(TokenType.relative, new RelativeExpresion());
            expressions.Add(TokenType.timeSignaturedata, new TimeSignatureExpresion());
        }

        public static Expresion getExpresionHandler(TokenType type)
        {
            if (expressions.ContainsKey(type))
            {
                return expressions[type].clone();
            }else {
                return null;
            }
        }
    }
}
