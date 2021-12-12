using System.Windows;
using WindowsAutoInstalls.BackEnd;
using WindowsAutoInstalls.Core;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class UtilidadesViewModel : ObservableObject
    {

        public RelayCommand ToggleFirewall { get; set; }

        public RelayCommand GetFirewallStatusString { get; set; }

        public RelayCommand ActivateWindows { get; set; }

        private bool _firewallStatus = SystemTools.GetFirewallStatus();

        public bool FirewallStatus
        {
            get { return _firewallStatus; }
            set { if (_firewallStatus != value)
                {
                    _firewallStatus = value;
                } 
            }
        }

        private string _firewallStatusString;

        public string FirewallStatusString
        {
            get { return _firewallStatusString;  }
            set { _firewallStatusString = value; }
        }

        public void UpdateFirewallString(bool status)
        {
            if (status)
            {
                _firewallStatusString = "On";
            }
            else
            {
                _firewallStatusString = "Off";
            }
        }

        public UtilidadesViewModel()
        {
            UpdateFirewallString(SystemTools.GetFirewallStatus());
            ToggleFirewall = new RelayCommand(o =>
            {
                bool firewallStatus = SystemTools.ToggleFirewallState();
                if (firewallStatus.Equals(_firewallStatus))
                {
                    MessageBox.Show("Inicie o programa como Admin para alterar configurações de Firewall!");
                }
                UpdateFirewallString(firewallStatus);
            });

            ActivateWindows = new RelayCommand(o =>
            {
                bool windowsActivated = Windows.ActivateWindows();
            });
        }
    }
}
