using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MediaGyver.MediaObjects;


namespace MediaGyver.Viewmodels
{
    class DebugPropertiesWindowViewModel : INotifyPropertyChanged
    {
        public TagLib.File SelectedItem { get; set; }
        public DebugPropertiesWindowViewModel(Track displayItem)
        {
            SelectedItem = displayItem.File;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
