using System.Diagnostics;
using System.IO;
using System.Windows;
using WindowsAutoInstalls.Exceptions;

namespace WindowsAutoInstalls.BackEnd.Downloads
{
    public class Chocolatey
    {
        private static readonly Process processo = Utils.CreateProcess();

        private static readonly string chocoPath = "C:\\ProgramData\\chocolatey\\bin\\chocolatey.exe";

        public static bool IsInstalled()
        {
            return File.Exists(chocoPath);
        }

        public static bool InstallChocolatey()
        {
            processo.StartInfo.Arguments = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";
            processo.Start();
            processo.WaitForExit();
            return processo.ExitCode == 0;
        }

        public static string GetPackageName(string appName)
        {
            string bestHit;
            processo.StartInfo.Arguments = $"choco search {appName} -r --approved-only --not-broken";
            processo.Start();
            processo.WaitForExit();
            try { 
                bestHit = processo.StandardOutput.ReadLine().ToString().Split('|')[0]; 
            } catch (System.NullReferenceException) { throw new PackageNotFoundException(appName); }
            
            // MessageBox.Show(bestHit);
            if (!appName.ToLower().Contains(bestHit.ToLower()))
            {
                throw new PackageNotFoundException(appName);
            }
            return bestHit;
        }

        public static int InstallPackage(string appName)
        {
            processo.StartInfo.Arguments = chocoPath + $" install {appName} -y";
            processo.Start();
            processo.WaitForExit();
            if (processo.ExitCode != 0)
            {
                throw new FailedToInstallChocolateyPackage(appName, processo);
            }
            return processo.ExitCode;
        }
    }
}
