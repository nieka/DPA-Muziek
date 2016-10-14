﻿using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.MidiFileproces.midiMessageHandler
{
    interface IMessageTypeHandler
    {
        IMessageTypeHandler clone();

        void handel(Context context, MidiEvent midiEvent);
    }
}
