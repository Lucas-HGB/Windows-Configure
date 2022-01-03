using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WindowsAutoInstalls.BackEnd;
using WindowsAutoInstalls.BackEnd.Downloads;
using WindowsAutoInstalls.Exceptions;

namespace WindowsAutoInstalls.Components
{
    public class DownloadableApp
    {

        public string Name { get; set; }
        public string DownloadLink { get; set; }
        public string SavePath { get; set; }
        public string ChocolateyName { get; set; }

        public DownloadableApp(string name, string downloadLink)
        {
            Name = name;
            DownloadLink = downloadLink;
            SetFileExtension();
            SetChocolateyName();
        }

        private void SetFileExtension()
        {
            string[] splitUrl = DownloadLink.Split('.');
            string fileExtension = splitUrl[splitUrl.Count() - 1];
            switch (fileExtension)
            {
                case "exe":
                    SavePath = $"{Name}.exe";
                    break;

                case "msi":
                    SavePath =  $"{Name}.msi";
                    break;

                case "zip":
                    SavePath = $"{Name}.zip";
                    break;

                default:
                    SavePath = $"{Name}.exe";
                    break;
            }
        }

        private void SetChocolateyName()
        {
            try
            {
                ChocolateyName = Chocolatey.GetPackageName(Name);
            } catch (PackageNotFoundException) { }
        }

        public Exception Download()
        {
            Exception installException = null;
            if (ChocolateyName != null)
            {
                try { Chocolatey.InstallPackage(ChocolateyName); } catch (PackageNotFoundException excp) { installException = excp; }
            }
            else
            {
                try { Web.DownloadAppViaFile(this); } catch (Exception excp) { installException = excp; }
            }
            return installException;
        }
    }
}
