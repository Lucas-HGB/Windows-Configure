using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsAutoInstalls.Exceptions;

namespace WindowsAutoInstalls.BackEnd.Downloads
{

    public class Web
    {
        private static WebClient WebClient = new WebClient();

        private static string GetAppSavePath(string appName, string url)
        {
            string[] splitUrl = url.Split('.');
            string fileExtension = splitUrl[splitUrl.Count() - 1];
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // Path that program is being executed.
            switch (fileExtension)
            {
                case "exe":
                    return Path.Combine(path, $"{appName}.exe");

                case "msi":
                    return Path.Combine(path, $"{appName}.msi");

                case "zip":
                    return Path.Combine(path, $"{appName}.zip");

                default:
                    return Path.Combine(path, $"{appName}.exe");
            }
        }

        public static void DownloadAppViaFile(string appName)
        {
            string url = DownloadLinks.GetLink(appName);
            string path = GetAppSavePath(appName, url);
            MessageBox.Show(path);
            try
            {
                WebClient.DownloadFile(url, path);
            }
            catch { throw new FailedToDownloadFile(appName, url); }
            ExecuteFile(path);
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
