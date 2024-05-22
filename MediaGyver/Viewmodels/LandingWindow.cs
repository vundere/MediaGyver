﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediaGyver.Viewmodels
{
    public class LandingWindow : INotifyPropertyChanged
    {

        public LandingWindow()
        {

        }


        #region Interface
        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChange([CallerMemberName] string? propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion
    }
}
