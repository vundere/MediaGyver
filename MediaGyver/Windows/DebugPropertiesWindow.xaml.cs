using MediaGyver.MediaObjects;
using MediaGyver.Viewmodels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MediaGyver.Windows
{
    /// <summary>
    /// Interaction logic for DebugPropertiesWindow.xaml
    /// </summary>
    public partial class DebugPropertiesWindow : Window
    {
        public DebugPropertiesWindow(Track displayItem)
        {
            InitializeComponent();
            DataContext = new DebugPropertiesWindowViewModel(displayItem);
        }
    }
}
