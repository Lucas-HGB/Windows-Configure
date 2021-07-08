using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsAutoInstalls.Core;
using WindowsAutoInstalls.BackEnd;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class HomeViewModel : ObservableObject
    {
        public RelayCommand DownloadApp { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            DownloadApp = new RelayCommand(o =>
            {
                MessageBox.Show(o.ToString());
                // Do Stuff here
            });
        }
    }
}
