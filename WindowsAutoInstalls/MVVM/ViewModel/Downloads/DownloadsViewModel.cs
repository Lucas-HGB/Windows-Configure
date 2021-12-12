using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsAutoInstalls.Core;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class DownloadsViewModel : ObservableObject
    {
        public DownloadsViewModel1 Downloads1VM { get; set; }
        public RelayCommand Downloads1ViewCommand { get; set; }

        public DownloadsViewModel2 Downloads2VM { get; set; }
        public RelayCommand Downloads2ViewCommand { get; set; }

        public DownloadsViewModel3 Downloads3VM { get; set; }
        public RelayCommand Downloads3ViewCommand { get; set; }

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

        public DownloadsViewModel()
        {
            Downloads1VM = new DownloadsViewModel1();
            Downloads2VM = new DownloadsViewModel2();
            Downloads3VM = new DownloadsViewModel3();
            CurrentView = Downloads1VM;
            Downloads1ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Downloads1VM;
            });
            Downloads2ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Downloads2VM;
            });

            Downloads3ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Downloads3VM;
            });

            DownloadApp = new RelayCommand(o =>
            {
                MessageBox.Show(o.ToString());
            });
        }
    }
}
