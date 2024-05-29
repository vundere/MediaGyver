using MediaGyver.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediaGyver.MediaObjects;
using TagLib;
using System.Windows.Controls;

namespace MediaGyver.Viewmodels
{
    public class MusicMainWindowViewModel : INotifyPropertyChanged
	{
		public MusicMainWindowViewModel() 
		{
			// TODO this view should be populate from database when it exists, not scanning on startup
            Scanner scanner = new();
            scanner.Scan(Testvars.INITFOLDER); // Uncomment to run scanner at startup - for testing purposes only
            List<Track> tracklist = [];
            LibraryFiles = new ObservableCollection<Track>(tracklist as List<Track>);
            foreach (TagLib.File tf in scanner.ScannerResult)
            {
                Track currentTrack = new(tf);
                tracklist.Add(currentTrack);
				LibraryFiles.Add(currentTrack);
            }

        }

		private ObservableCollection<Track> _libraryFiles = new ObservableCollection<Track>();
		public ObservableCollection<Track> LibraryFiles
		{
            get { return _libraryFiles; }
			set 
			{	
				_libraryFiles = value;
				RaisePropertyChange();
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
