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
    class DownloadsViewModel3 : ObservableObject
    {
        public RelayCommand DownloadApp { get; set; }

        public RelayCommand SwitchPage { get; set; }

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

        public DownloadsViewModel3()
        {
            DownloadApp = new RelayCommand(obj =>
            {
                Windows.Windows.DownloadApp(obj.ToString());
            });
        }
    }
}
