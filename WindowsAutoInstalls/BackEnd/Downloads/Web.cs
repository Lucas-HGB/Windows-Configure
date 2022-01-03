using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsAutoInstalls.Components;
using WindowsAutoInstalls.Exceptions;

namespace WindowsAutoInstalls.BackEnd.Downloads
{

    public class Web
    {
        private static readonly WebClient WebClient = new WebClient();

        private static string GetAppSavePath(DownloadableApp app)
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // Path that program is being executed.
            return Path.Combine(path, app.SavePath);
        }

        public static void DownloadAppViaFile(DownloadableApp app)
        {
            string path = GetAppSavePath(app);
            MessageBox.Show(path);
            try
            {
                WebClient.DownloadFile(app.DownloadLink, path);
                ExecuteFile(path);
            }
            catch { throw new FailedToDownloadFile(app.Name, app.DownloadLink); }
        }

        private static void ExecuteFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Arquivo {filePath} não encontrado!");
            }
            Process process = Utils.CreateProcess();
            process.StartInfo.Arguments = $"& '{filePath}'";
            process.Start();
            process.WaitForExit();
        }
    }
}
