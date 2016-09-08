using DPA_Musicsheets.factories;
using DPA_Musicsheets.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.classes
{
    class ApplicationController
    {
        private InputReader inputReader;
        private Staf staf;
        private List<NoteObserver> noteObservers;

        public ApplicationController()
        {
            staf = new Staf();
            noteObservers = new List<NoteObserver>();
        }

        public void convertFile(String location)
        {
            inputReader = ReaderFactory.getReader(System.IO.Path.GetExtension(location));
            staf = inputReader.readNotes(location);
        }

        public void attach(NoteObserver observer)
        {
            if (!noteObservers.Contains(observer))
            {
                noteObservers.Add(observer);
            }
        }

        private void notifyAll()
        {
            for (int i = 0; i < noteObservers.Count; i++)
            {
                noteObservers[i].update(staf);
            }
        }
    }
}
