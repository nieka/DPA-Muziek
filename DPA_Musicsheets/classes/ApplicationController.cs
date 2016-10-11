using DPA_Musicsheets.factories;
using DPA_Musicsheets.interfaces;
using DPA_Musicsheets.States;
using DPA_Musicsheets.writers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using DPA_Musicsheets.memento;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DPA_Musicsheets.classes
{
    class ApplicationController
    {
        private InputReader inputReader;
        private MusicSheet musicSheet;
        private List<NoteObserver> noteObservers;
        private ToLilypontConverter LilypondConverter;
        public MainWindow window { get; set; }
        public Memento memento { get; set; }
        public bool HasSaved { get; set; }
        public string CommandKeys { get; set; }
        public string EditString { get; set; }
        public IState State { get; private set; }

        public ApplicationController(MainWindow window)
        {
            musicSheet = new MusicSheet();
            noteObservers = new List<NoteObserver>();
            LilypondConverter = new ToLilypontConverter();
            this.window = window;
            HasSaved = true;
            CommandKeys = "";
            EditString = "";
            State = new PlayState(this);
            memento = new Memento(this);
        }

        public void convertFile(String location)
        {
            inputReader = ReaderFactory.getReader(System.IO.Path.GetExtension(location));
            musicSheet = inputReader.readNotes(System.IO.File.ReadAllText(location));
            notifyAll();
        }

        public void save(String type, String fileLocation)
        {
            ISave saver = SaveFactory.getSaver(type);
            saver.save(musicSheet, fileLocation);
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
                noteObservers[i].update(musicSheet);
            }
        }

        public string GetLilypond()
        {
            return LilypondConverter.ToLilypoint(musicSheet);
        }

        public void SwitchState()
        {
            if(State.Type == StateType.Play)
            {
                State = new EditState(this);
            }
            else if(State.Type == StateType.Edit)
            {
                State = new PlayState(this);
            }
        }

        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //txt_MidiFilePath.Text = openFileDialog.FileName;
                convertFile(openFileDialog.FileName);

                window.SetMidiFilePath(openFileDialog.FileName);
            }
        }

        public void SaveFile()
        {
            String type = window.GetSaveState();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Sla je muziek op";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                save(type, saveFileDialog1.FileName);
                HasSaved = true;
            }
        }

        public void SetEditText(string txt)
        {
            EditString = txt;
            window.SetEditBox(txt);
        }
    }
}
