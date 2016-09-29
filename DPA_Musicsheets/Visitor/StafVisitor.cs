using DPA_Musicsheets.Adapter;
using DPA_Musicsheets.classes;
using DPA_Musicsheets.interfaces;
using PSAMControlLibrary;
using PSAMWPFControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Visitor
{
    class StafVisitor : IVisotor
    {
        IncipitViewerWPF staff;
        ClefAdapter clefAdapter;
        NootAdapter nootAdapter;
        public StafVisitor(IncipitViewerWPF staff)
        {
            this.staff = staff;
            clefAdapter = new ClefAdapter();
            nootAdapter = new NootAdapter();
        }

        public void updateStaff()
        {
            staff.ClearMusicalIncipit();

            staff.AddMusicalSymbol(clefAdapter.ModelToLibrary(new DPA_Musicsheets.classes.Clef()));
        }

        public void visit(DPA_Musicsheets.classes.Note noot)
        {
            staff.AddMusicalSymbol(nootAdapter.NootModelToLibrary(noot));
        }

        public void visit(RustNode rustNode)
        {
            staff.AddMusicalSymbol(nootAdapter.RestModelToLibrary(rustNode));
        }

        public void visit(DPA_Musicsheets.classes.Clef clef)
        {
            staff.AddMusicalSymbol(clefAdapter.ModelToLibrary(clef));
        }

        public void visit(DPA_Musicsheets.classes.TimeSignature timeSignature)
        {
            staff.AddMusicalSymbol(new PSAMControlLibrary.TimeSignature(TimeSignatureType.Numbers, Convert.ToUInt32(timeSignature.timeSignature[0]), Convert.ToUInt32(timeSignature.timeSignature[1])));
        }

        public void visit(MaatStreep rustNode)
        {
            staff.AddMusicalSymbol(new Barline());
        }
    }
}
