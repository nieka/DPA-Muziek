using DPA_Musicsheets.Adapter;
using DPA_Musicsheets.interfaces;
using PSAMControlLibrary;
using PSAMWPFControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class StafDrawer : NoteObserver
    {
        IncipitViewerWPF staff;
        //ClefAdapter clefAdapter = new ClefAdapter();
        //NootAdapter nootAdapter = new NootAdapter();

        public StafDrawer(IncipitViewerWPF staff)
        {
            this.staff = staff;
        }

        public void update(MusicSheet data)
        {
            //staff.ClearMusicalIncipit();
            ////staff.AddMusicalSymbol(clefAdapter.ModelToLibrary(data.getClef()));

            //for (int i = 0; i < data.staffs.Count; i++)
            //{
            //    Staf staf = data.staffs[i];
            //    int[] timeSig = staf.getTimeSignature();
            //    staff.AddMusicalSymbol(new TimeSignature(TimeSignatureType.Numbers, Convert.ToUInt32(timeSig[0]), Convert.ToUInt32(timeSig[1])));

            //    LinkedList<AbstractNode> noten = staf.getNoten();
            //    LinkedListNode<AbstractNode> currentNode = noten.First;
            //    while (currentNode != null)
            //    {
            //        AbstractNode noot = currentNode.Value;
            //        PSAMControlLibrary.Note muziekNote;

            //        if (noot.getToonhoogte() != "r")
            //        {
            //            staff.AddMusicalSymbol(nootAdapter.NootModelToLibrary(noot));
            //        }
            //        else
            //        {    
            //            staff.AddMusicalSymbol(nootAdapter.RestModelToLibrary(noot));
            //        }

            //        /*
            //        if(noot.isLastNoot())
            //        {
            //            staff.AddMusicalSymbol(new Barline());
            //        }
            //        */
            //        currentNode = currentNode.Next;
            //    }

            //}
        }
            
    }
}
