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

        private bool _firewallStatus;

        public bool FirewallStatus
        {
            get { return _firewallStatus; }
            set { if (_firewallStatus != value)
                {
                    _firewallStatus = value;
                } 
            }
        }



        public UtilidadesViewModel()
        {
            _firewallStatus = Windows.Windows.GetFirewallStatus(); // Seta toggle do Firewall para devido valor
            ToggleFirewall = new RelayCommand(o =>
            {
                Windows.Windows.ToggleFirewallState();
            });
        }

    }
}
