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
    class MainViewModel : ViewModelBase
    {
        
        public DownloadsViewModel DownloadsVM { get; set; }

        public ConfiguracoesViewModel ConfiguracoesVM { get; set; }

        public CustomizacoesViewModel CustomizacoesVM { get; set; }

        public UtilidadesViewModel UtilidadesVM { get; set; }


        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        private CommandHandler _switchViewCommand;
        public CommandHandler SwitchViewCommand
        {
            get
            {
                return _switchViewCommand ?? (_switchViewCommand = new CommandHandler(param => SwitchView(param), true));
            }
            set
            {
                _switchViewCommand = value;
                OnPropertyChanged("PreviousPageCommand");
            }
        }

        public void SwitchView(object newView)
        {
            CurrentView = newView;
        }

        public MainViewModel()
        {
            if (!Utils.IsAdministrator())
            {
                MessageBox.Show("Favor iniciar o programa como administrador para funcionalidade completa do programa!");
            }
            DownloadsVM = new DownloadsViewModel();
            ConfiguracoesVM = new ConfiguracoesViewModel();
            CustomizacoesVM = new CustomizacoesViewModel();
            UtilidadesVM = new UtilidadesViewModel();
            SwitchView(DownloadsVM);
        }
    }
}
