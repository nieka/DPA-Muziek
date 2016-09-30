using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.classes;

namespace DPA_Musicsheets.writers
{
    class PdfSaver : ISave
    {
        public ISave clone()
        {
            return new PdfSaver();
        }

        public void save(MusicSheet musicsheet, string fileLocation)
        {
            throw new NotImplementedException();
        }
    }
}
