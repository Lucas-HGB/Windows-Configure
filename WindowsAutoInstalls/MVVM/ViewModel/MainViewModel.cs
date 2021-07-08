using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsAutoInstalls.Core;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        
        public DownloadsViewModel1 DownloadsVM { get; set; }
        public RelayCommand DownloadsViewCommand { get; set; }

        public ConfiguracoesViewModel ConfiguracoesVM { get; set; }
        public RelayCommand ConfiguracoesViewCommand { get; set; }

        public CustomizacoesViewModel CustomizacoesVM { get; set; }
        public RelayCommand CustomizacoesViewCommand { get; set; }

        public UtilidadesViewModel UtilidadesVM { get; set; }
        public RelayCommand UtilidadesViewCommand { get; set; }


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
        public MainViewModel()
        {
            DownloadsVM = new DownloadsViewModel1();
            ConfiguracoesVM = new ConfiguracoesViewModel();
            CustomizacoesVM = new CustomizacoesViewModel();
            UtilidadesVM = new UtilidadesViewModel();
            CurrentView = DownloadsVM;
            DownloadsViewCommand = new RelayCommand(o =>
            {
                CurrentView = DownloadsVM;
            });

            ConfiguracoesViewCommand = new RelayCommand(o =>
            {
                CurrentView = ConfiguracoesVM;
            });

            CustomizacoesViewCommand = new RelayCommand(o =>
            {
                CurrentView = CustomizacoesVM;
            });

            UtilidadesViewCommand = new RelayCommand(o =>
            {
                CurrentView = UtilidadesVM;
            });
        }
    }
}
