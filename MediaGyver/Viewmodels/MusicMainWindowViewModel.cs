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
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MediaGyver.Windows;
using System.Windows;

namespace MediaGyver.Viewmodels
{
    public class MusicMainWindowViewModel : INotifyPropertyChanged
	{
		private ICommand _openDebugPropertiesCommand;
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
			_openDebugPropertiesCommand = new RelayCommand(OpenDebugProperties);

			Actions = [new ContextAction("Debug properties", _openDebugPropertiesCommand)];
        }

		public ICommand OpenDebugPropertiesCommand => _openDebugPropertiesCommand;

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

		private Track _selectedItem;
		public Track SelectedItem
		{
			get => _selectedItem;
			set
			{
				var t = value as Track;
				_selectedItem = t;
			}
		}

		public ObservableCollection<ContextAction> Actions { get; set; }

		private void OpenDebugProperties()
		{
			DebugPropertiesWindow debugWindow = new DebugPropertiesWindow(SelectedItem);
			debugWindow.Show();
		}




		#region Interface
		public event PropertyChangedEventHandler? PropertyChanged;

		public void RaisePropertyChange([CallerMemberName] string? propertyname = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
		}
		#endregion
	}

    public class ContextAction : INotifyPropertyChanged
    {
        public ContextAction(string name, ICommand command)
        {
            Name = name;
            Action = command;
        }

        public string Name { get; set; }
		public ICommand Action { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class DoubleClickHandler
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
        "Command", typeof(ICommand), typeof(DoubleClickHandler), new PropertyMetadata(default(ICommand), OnComandChanged));

        public static void SetCommand(DependencyObject element, ICommand value)
        {
            element.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
            "CommandParameter", typeof(object), typeof(DoubleClickHandler), new PropertyMetadata(default(object)));

        public static void SetCommandParameter(DependencyObject element, object value)
        {
            element.SetValue(CommandParameterProperty, value);
        }

        public static object GetCommandParameter(DependencyObject element)
        {
            return (object)element.GetValue(CommandParameterProperty);
        }

        private static void OnComandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as System.Windows.Controls.Control;
            if (c == null)
                throw new InvalidOperationException($"can only be attached to {nameof(System.Windows.Controls.Control)}");
            c.MouseDoubleClick -= OnDoubleClick;
            if (GetCommand(c) != null)
                c.MouseDoubleClick += OnDoubleClick;
        }

        private static void OnDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var d = sender as DependencyObject;
            if (d == null)
                return;
            var command = GetCommand(d);
            if (command == null)
                return;
            var parameter = GetCommandParameter(d);
            if (!command.CanExecute(parameter))
                return;
            command.Execute(parameter);
        }
    }

    public class BindingProxy : Freezable  // For a solution that I couldn't get to work, leaving here in case I want to try again later
    {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
         DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy));
    }
}
