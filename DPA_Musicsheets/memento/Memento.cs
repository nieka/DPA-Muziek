using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.memento
{
    class Memento
    {
        private ApplicationController controller;
        Node Root { get; set; }
        Node Current { get; set; }
        Node Last { get; set; }

        public Memento(ApplicationController controller)
        {
            this.controller = controller;
        }

        public void NewNode(string EditText)
        {
            if(Root == null)
            {
                Root = new Node(EditText);
                Current = Root;
            }
            else
            {
                Current.Next = new Node(EditText);
                Current.Next.Last = Current;
                Current = Current.Next;
                Last = Current;
                controller.RedrawStaf();
            }           
        }

        public void Back()
        {
            if(Current != Root && Root !=  null)
            {
                Current = Current.Last;
                controller.SetEditText(Current.EditString);
                controller.RedrawStaf();
            }           
        }

        public void Forward()
        {
            if (Current != Last && Root != null)
            {
                Current = Current.Next;
                controller.SetEditText(Current.EditString);
                controller.RedrawStaf();
            }
        }


    }
}
