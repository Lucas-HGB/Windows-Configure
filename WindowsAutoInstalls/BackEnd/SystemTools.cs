using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsAutoInstalls.BackEnd
{
    public class SystemTools
    {
        private static NetFwTypeLib.INetFwMgr NetworkManager = GetNetWorkManager();

        private static NetFwTypeLib.INetFwMgr GetNetWorkManager()
        {
            Type objectType = Type.GetTypeFromCLSID(new Guid("{304CE942-6E39-40D8-943A-B913C40C9CD4}"));
            //Creates a new GUID from CLSID_FIREWALL_MANAGER getting its type as objectType
            return Activator.CreateInstance(objectType) as NetFwTypeLib.INetFwMgr;
            //Creates an instance from the object type we gathered as an INetFwMgr object
        }

        public static bool GetFirewallStatus()
        {
            return NetworkManager.LocalPolicy.CurrentProfile.FirewallEnabled;
        }

        public static bool ToggleFirewallState()
        {
            Process process = Utils.CreateProcess();
            process.StartInfo.FileName = "netsh.exe";
            process.StartInfo.Arguments = "Advfirewall set allprofile state ";
            switch (GetFirewallStatus())
            {
                case true:
                    process.StartInfo.Arguments += "off";
                    // process.StartInfo.Arguments = "Advfirewall set allprofiles state off";
                    break;
                case false:
                    process.StartInfo.Arguments +=  "on";
                    // process.StartInfo.Arguments = "Advfirewall set allprofiles state on";
                    break;
            }
            process.Start();
            process.WaitForExit();
            process.Close();
            return GetFirewallStatus();
        }
    }
}
