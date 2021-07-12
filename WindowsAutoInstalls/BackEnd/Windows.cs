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


        private static Process CreateProcesso()
        {
            Process p = new Process();
            p.StartInfo.FileName = "powershell.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.Verb = "runas";
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

        private static string GetAppSaveName(string appName, string url)
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
                string path = GetAppSaveName(appName, url);
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
    }
}
