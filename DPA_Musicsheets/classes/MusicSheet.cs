using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class MusicSheet
    {
        public List<Staf> staffs {get; set;}

        public MusicSheet()
        {
            staffs = new List<Staf>();
        }

    }
}
