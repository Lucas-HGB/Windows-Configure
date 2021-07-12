﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsAutoInstalls.Core;
using WindowsAutoInstalls.BackEnd;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class DownloadsViewModel3 : ObservableObject
    {

        public RelayCommand DownloadApp { get; set; }

        public DownloadsViewModel3()
        {
            DownloadApp = new RelayCommand(o =>
            {
                Windows.Windows.DownloadApp(o.ToString());
            });
        }
    }
}
