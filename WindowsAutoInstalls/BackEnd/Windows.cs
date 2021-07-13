using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsAutoInstalls.BackEnd;
using System.Windows;

namespace Windows
{
    static class Windows
    {
        private static WebClient WebClient = new WebClient();

        private static Process processo = CreateProcesso();

        private static NetFwTypeLib.INetFwMgr NetworkManager = GetNetWorkManager();


        private static Process CreateProcesso()
        {
            Process p = new Process();
            p.StartInfo.Verb = "runas";
            p.StartInfo.FileName = "powershell.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            return p;
        }

        public static void ActivateWindows()
        {
            processo.StartInfo.Arguments = "slmgr /ipk W269N-WFGWX-YVC9B-4J6C9-T83GX";
            processo.Start();
            processo.StartInfo.Arguments = "slmgr /skms kms8.msguides.com";
            processo.Start();
            processo.StartInfo.Arguments = "slmgr /ato";
            processo.Start();
        }

        public static String GetDesktopFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        private static void InstallChocolatey()
        {
            processo.StartInfo.Arguments = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";
            processo.Start();
            processo.WaitForExit();
        }

        private static void CheckChocolateyInstall()
        {
            processo.StartInfo.Arguments = "chocolatey";
            processo.Start();
            if (processo.ExitCode != 1)
            {
                InstallChocolatey();
            }
        }

        private static string GetAppSavePath(string appName, string url)
        {
            string[] splitUrl = url.Split(",".ToCharArray()[0]);
            string fileExtension = splitUrl[splitUrl.Count() - 1];
            switch (fileExtension)
            {
                case "exe":
                    return Path.Combine($"{appName}.exe");

                case "msi":
                    return Path.Combine($"{appName}.msi");

                case "zip":
                    return Path.Combine($"{appName}.zip");

                default:
                    return Path.Combine($"{appName}.exe");
            }
        }

        public static void DownloadApp(string appName) {
            CheckChocolateyInstall();
            // Installs via chocolatey
            string chocAppName = Downloads.GetChocolateyAppName(appName);
            if (!chocAppName.Equals("")) {
                 using (Process process = new Process())
                 {
                     process.StartInfo.Arguments = $"chocolatey install -y {chocAppName}";
                     process.Start();
                     process.WaitForExit();
                 }
            }
            else
            {
                // Downloads executable file for program
                string url = Downloads.GetLink(appName);
                MessageBox.Show($"Baixando {appName}");
                string path = GetAppSavePath(appName, url);
                WebClient.DownloadFile(url, path);
                ExecuteFile(path);
            }
        }

        private static void ExecuteFile(String filePath)
        {
            // Executes file, used by DownloadApp when chocolatye doesn't have such package
            if (!File.Exists(filePath)) {
                throw new FileNotFoundException($"Arquivo {filePath} não encontrado!");
            }
            using (Process process = new Process()) {
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Arguments = $"& '{filePath}'";
                process.Start();
            }
        }


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

        public static void ToggleFirewallState()
        {
            Process process = CreateProcesso();
            process.StartInfo.FileName = "netsh.exe";
            switch(GetFirewallStatus())
            {
                case true:
                    process.StartInfo.Arguments = "Advfirewall set allprofiles state off";
                    break;
                case false:
                    process.StartInfo.Arguments = "Advfirewall set allprofiles state on";
                    break;
            }
            process.Start();
            process.WaitForExit();
            if (process.StandardOutput.ReadToEnd().ToLower().Contains("admin"))
            {
                // Erro ao rodar o comando, notificar usuário que o programa deve ser executado como admin.
                // Como notificar o usuário?
                MessageBox.Show("ADMIN");
            }
            process.Close();
        }
    }
}
