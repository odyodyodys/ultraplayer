using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model;
using System.IO;
using UltraPlayerController.Model.Addon;
using UltraPlayerController.Model.SoundFx;
using System.Drawing;

namespace UltraPlayerController.View.Events
{
    public class Delegates
    {
        public delegate void ActionEventHandler();
        public delegate void IntegerValueActionEventHandler(int value);
        public delegate void FloatValyeActionEventHandler(float value);
        public delegate void ParameterValueActionEventHandler(int paramId, float value);
        public delegate void VisibleLayoutChangedEventHandler(VisibleLayout layout);
        public delegate void LayoutChangedEventHandler(Layout layout);
        public delegate void SwitchOptionChangedEventHandler(bool newState);
        public delegate void FileChangedEventHandler(FileInfo fileInfo);
        public delegate void AddonEventHandler(AAddon addon);
        public delegate void TextChangedEventHandler(string text);
        public delegate void SkinEventHandler(SkinInfo skin);
        public delegate void SoundFxEventHandler(ASoundFx soundFx);
        public delegate void WaveformChangedEventHandler(WaveformType waveform);
        public delegate void PhaseChangedEventHandler(PhaseType phase);
        public delegate void Sound3dEventHandler(Sound3d sound3d);
        public delegate void SetSkinInfo(SkinInfo skin, Point position);
    }
}
