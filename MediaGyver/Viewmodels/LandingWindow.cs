using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaGyver.Viewmodels
{
    public class LandingWindow : INotifyPropertyChanged
    {

        private ICommand _browseAddLibraryFolder;

        public LandingWindow()
        {
            _browseAddLibraryFolder = new RelayCommand(BrowseAddLibraryFolder);
        }

        private void BrowseAddLibraryFolder()
        {
            using (FolderBrowserDialog dialog = new())
            {
                dialog.Description = "Select Folder...";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Do something with dialog.SelectedPath;
                    
                }
            }
        }


        #region Interface
        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChange([CallerMemberName] string? propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion
    }
}
