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


        public static Process CreateProcesso()
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

        public static void DownloadApp(string appName) {
           CheckChocolateyInstall();
           try
            {

            }
            catch (Name)
           string url = DownloadLinks.GetLink(appName);
           MessageBox.Show($"Baixando {appName} de {url}");
           string[] splitUrl = url.Split(",".ToCharArray()[0]);

           string fileExtension = splitUrl[splitUrl.Count() -1];
           string filePath;

           switch (fileExtension)
           {
               case "exe":
                   filePath = Path.Combine($"{appName}.exe");
                   break;

               case "msi":
                   filePath = Path.Combine($"{appName}.msi");
                   break;

               case "zip":
                   filePath = Path.Combine($"{appName}.zip");
                   break;
           }

           //WebClient.DownloadFile(url, path);
        }

        private static void ExecuteFile(String filePath)
        {
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
