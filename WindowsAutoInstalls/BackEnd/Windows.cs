using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsAutoInstalls.BackEnd;

namespace Windows
{
    static class Windows
    {
        private static WebClient WebClient = new WebClient();


        public static void ActivateWindows()
        {
            Process processo = new Process();
            processo.StartInfo.FileName = "powershell.exe";
            processo.StartInfo.UseShellExecute = false;
            processo.StartInfo.RedirectStandardOutput = true;
            processo.StartInfo.Verb = "runas";
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

        public static void DownloadApp(Uri url, string filePath) {
            WebClient.DownloadFile(url, filePath);
        }

        public static void ExecuteFile(String filePath)
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
