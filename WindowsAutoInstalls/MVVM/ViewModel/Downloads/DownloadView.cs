using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsAutoInstalls.Core;
using WindowsAutoInstalls.BackEnd.Downloads;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class DownloadView : ObservableObject
    {
        public RelayCommand DownloadApp { get; set; }

        public DownloadView()
        {
            DownloadApp = new RelayCommand(o =>
            {
                DownloadsHandler.DownloadApp(o.ToString());
            });
        }
    }
}