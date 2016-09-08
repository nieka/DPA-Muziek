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

        public MainWindow()
        {
            InitializeComponent();
            controller = new ApplicationController();
            controller.attach(new StafDrawer(staff));

        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Midi Files(.mid)|*.mid" };
            if (openFileDialog.ShowDialog() == true)
            {
                txt_MidiFilePath.Text = openFileDialog.FileName;
                controller.convertFile(openFileDialog.FileName);
            }
        }

        
        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_ShowContent_Click(object sender, RoutedEventArgs e)
        {
            ShowMidiTracks(MidiReader.ReadMidi(txt_MidiFilePath.Text));
        }

        private void ShowMidiTracks(IEnumerable<MidiTrack> midiTracks)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
