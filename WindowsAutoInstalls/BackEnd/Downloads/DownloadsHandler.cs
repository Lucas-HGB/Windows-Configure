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
    public class DownloadsHandler
    {

        public static Exception DownloadApp(DownloadableApp app)
        {
            string chocolateyAppName;
            Exception installException = null;
            if (!Chocolatey.IsInstalled()) { 
                MessageBox.Show($"Instalando o Package Manager Chocolatey"); 
                Chocolatey.InstallChocolatey(); 
            }

            try
            {
                chocolateyAppName = Chocolatey.GetPackageName(app.Name);
            } catch (PackageNotFoundException) { chocolateyAppName = ""; }

            if (String.IsNullOrEmpty(chocolateyAppName))
            {
                try
                {
                    Web.DownloadAppViaFile(app);
                } catch(FailedToDownloadFile excp) { installException = excp; }
                
            }
            else
            {
                try
                {
                    Chocolatey.InstallPackage(app.Name);
                } catch(Exception excp) { installException = excp; }
                
            }
            return installException;
        }

    }
}
