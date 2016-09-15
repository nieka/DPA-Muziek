using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Tokenizer
{
    class LilypondTokenizer
    {
        private String[] inputList;


        public LilypondTokenizer()
        {

        }

        public void proces(String input)
        {
            input = input.Replace("\r\n", string.Empty);
            inputList = input.Split(' ');
            for (int i = 0; i < inputList.Length; i++)
            {
                Console.WriteLine(inputList[i]);
            }
            Console.ReadKey();
        }
        
    }
}
