using Microsoft.TeamFoundation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WindowsAutoInstalls.BackEnd;
using WindowsAutoInstalls.Core;
using NATUPNPLib;
using NETCONLib;
using NetFwTypeLib;
using System.Windows;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class UtilidadesViewModel : ObservableObject
    {

        public RelayCommand ToggleFirewall { get; set; }

        public RelayCommand GetFirewallStatusString { get; set; }

        public RelayCommand ActivateWindows { get; set; }

        private bool _firewallStatus = Windows.Windows.GetFirewallStatus();

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

        public void ToggleFirewallString()
        {
            if (Windows.Windows.GetFirewallStatus())
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
            ToggleFirewallString();
            ToggleFirewall = new RelayCommand(o =>
            {
                Windows.Windows.ToggleFirewallState();
                FirewallStatus = Windows.Windows.GetFirewallStatus();
                ToggleFirewallString();
            });

            ActivateWindows = new RelayCommand(o =>
            {
                Windows.Windows.ActivateWindows();
            });
        }

    }
}
