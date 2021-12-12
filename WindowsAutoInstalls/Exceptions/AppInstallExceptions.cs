using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAutoInstalls.Exceptions
{
    class PackageNotFoundException : Exception
    {
        public PackageNotFoundException()
        {

        }

        public PackageNotFoundException(string appName)
            : base($"Package {appName} not found on Chocolatey!") { }
    }

    class FailedToInstallChocolateyPackage : Exception
    {
        public FailedToInstallChocolateyPackage()
        {

        }

        public FailedToInstallChocolateyPackage(string appName, Process processo)
            : base($"Failed to Install {appName} via Chocolatey!\n" +
                  $"Process args: {processo.StartInfo.Arguments}\n" +
                  $"Error: {processo.StandardError.ReadToEnd()}") 
        {
        }
    }

    class FailedToDownloadFile : Exception
    {
        public FailedToDownloadFile()
        {

        }

        public FailedToDownloadFile(string appName, string url)
            : base($"Falha ao baixar {appName} de {url}!") { }
    }
}
