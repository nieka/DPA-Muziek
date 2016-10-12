using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Tokenizer
{
    interface ITokenChecker
    {
        Boolean canhandle(String input);

        Token handle(String input);
    }
}
