﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.memento
{
    class Node
    {
        public Node Last { get; set; }
        public Node Next { get; set; }
        public string EditString{ get; set; }

        public Node(string EditText)
        {
            EditString = EditText;
        }

    }

}
