using DPA_Musicsheets.Adapter;
using DPA_Musicsheets.interfaces;
using DPA_Musicsheets.Visitor;
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
        StafVisitor visitor;

        public StafDrawer(IncipitViewerWPF staff)
        {
            this.staff = staff;
            visitor = new StafVisitor(staff);
        }

        public void update(MusicSheet data)
        {
            visitor.updateStaff();

            foreach(IMusicSymbol item in data.items)
            {
                item.accept(visitor);
            }
        }
            
    }
}
