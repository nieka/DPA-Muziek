using DPA_Musicsheets.classes;
using DPA_Musicsheets.factories;
using DPA_Musicsheets.interfaces;
using Microsoft.Win32;
using PSAMControlLibrary;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
//using System.Windows.Forms.Timer;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DPA_Musicsheets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // De OutputDevice is een midi device of het midikanaal van je PC.
        // Hierop gaan we audio streamen.
        // DeviceID 0 is je audio van je PC zelf.
        private OutputDevice _outputDevice = new OutputDevice(0);
        private ApplicationController controller;

        private Timer SaveTimer;

        public MainWindow()
        {
            InitializeComponent();
            controller = new ApplicationController(this);
            controller.attach(new StafDrawer(staff));

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

            SaveTimer = new Timer(1500);
            SaveTimer.Elapsed += OnTimedEvent;
            SaveTimer.AutoReset = false;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            controller.OpenFile();           
        }
        
        public void SetMidiFilePath(string path)
        {
            txt_MidiFilePath.Text = path;
        }

        public string GetSaveState()
        {
            return saveState.Text;
        }

        
        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btn_Save(object sender, RoutedEventArgs e)
        {
            controller.SaveFile();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            //ShowMidiTracks(MidiReader.ReadMidi(txt_MidiFilePath.Text));

            if(controller.State.Type == StateType.Play)
            {
                EditBox.IsEnabled = true;
                btn_Edit.Content = "Play mode";               

                btnPlay.IsEnabled = false;
                btn_Stop.IsEnabled = false;

                EditBox.Text = controller.GetLilypond();
            }
            else if(controller.State.Type == StateType.Edit)
            {
                EditBox.IsEnabled = false;
                btn_Edit.Content = "Edit mode";
                btnPlay.IsEnabled = true;
                btn_Stop.IsEnabled = true;
            }

            controller.SwitchState();
        }

        private void ShowMidiTracks(IEnumerable<MidiTrack> midiTracks)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!controller.HasSaved)
            {
                string msg = "Do you want to quit without saving?";
                MessageBoxResult result = MessageBox.Show(msg, "Session Ending", MessageBoxButton.YesNo);

                // End session, if specified
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void EditBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.HasSaved = false;

            if(controller.State.Type == StateType.Edit)
            {
                SaveTimer.Stop();
                SaveTimer.Start();
            }    
        }
        
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "LeftCtrl" || e.Key.ToString() == "RightCtrl" || e.Key.ToString() == "System")
            {
                if (e.Key.ToString() == "RightCtrl" || e.Key.ToString() == "LeftCtrl")
                {
                    controller.CommandKeys += "LeftCtrl ";
                }
                else if (e.Key.ToString() == "System")
                {
                    controller.CommandKeys += "System ";
                }
            }
            else
            {
                controller.CommandKeys += e.Key.ToString() + " ";
            }

            if(controller.State.ActivateCommand(controller.CommandKeys))
            {
                MessageBox.Show(controller.CommandKeys);
                controller.CommandKeys = "";
            }

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            MessageBox.Show("saved");
        }
    }
}
