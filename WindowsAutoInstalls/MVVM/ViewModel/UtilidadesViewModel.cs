using System.Windows;
using System.Windows.Input;
using WindowsAutoInstalls.BackEnd;
using WindowsAutoInstalls.Core;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class UtilidadesViewModel : ViewModelBase
    {


        private CommandHandler _toggleFirewallCommand;
        public CommandHandler ToggleFirewallCommand
        {
            get
            {
                return _toggleFirewallCommand ?? (_toggleFirewallCommand = new CommandHandler(param => ToggleFirewall(), true));
            }
            protected set
            {
                _toggleFirewallCommand = value;
            }
        }

        private void ToggleFirewall()
        {
            bool firewallStatus = SystemTools.ToggleFirewallState();
            if (firewallStatus.Equals(_firewallStatus))
            {
                MessageBox.Show("Inicie o programa como Admin para alterar configurações de Firewall!");
            }
            if (firewallStatus)
            {
                FirewallStatusString = "On";
            } else { FirewallStatusString = "Off";  }
        }

        private bool _firewallStatus = SystemTools.GetFirewallStatus();
        public bool FirewallStatus
        {
            get { return _firewallStatus; }
            set 
            { 
                _firewallStatus = SystemTools.GetFirewallStatus();
            }
        }

        private string _firewallStatusString;
        public string FirewallStatusString
        {
            get { return _firewallStatusString;  }
            set 
            { 
                if (SystemTools.GetFirewallStatus())
                {
                    _firewallStatusString = "On";
                } else { _firewallStatusString = "Off"; }
                OnPropertyChanged("FirewallStatusString");
            }
        }

        public UtilidadesViewModel()
        {
            FirewallStatusString = "On";
        }
    }
}
