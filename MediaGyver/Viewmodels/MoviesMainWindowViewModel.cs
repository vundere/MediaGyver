using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaGyver.Viewmodels
{
    public class MoviesMainWindowViewModel : INotifyPropertyChanged
    {

		private ICommand _searchButtonPressCommand;

        public MoviesMainWindowViewModel()
        {
			_searchButtonPressCommand = new RelayCommand(SearchButtonClicked);
		}

		public ICommand SearchButtonPressCommand => _searchButtonPressCommand;


		private void SearchButtonClicked()
		{
			

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
