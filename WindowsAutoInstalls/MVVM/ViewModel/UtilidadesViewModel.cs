using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsAutoInstalls.BackEnd;
using WindowsAutoInstalls.Core;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class UtilidadesViewModel : ObservableObject
    {

        public RelayCommand CheckFirewallStatus { get; set; }


        public UtilidadesViewModel()
        {
            CheckFirewallStatus = new RelayCommand(o =>
            {
                Checks.FirewallStatus();
            });
        }
    }
}
