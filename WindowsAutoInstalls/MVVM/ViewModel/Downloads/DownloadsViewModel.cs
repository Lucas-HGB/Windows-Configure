using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowsAutoInstalls.Core;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class DownloadsViewModel : ViewModelBase
    {

        public List<ViewModelBase> Pages = new List<ViewModelBase>();

        public Dictionary<string, List<string>> CategoryApps;

        private ViewModelBase _currentPageView;
        public ViewModelBase CurrentPageView
        {
            get { return _currentPageView; }
            set
            {
                _currentPageView = value;
                OnPropertyChanged("CurrentPageView");
            }
        }

        private CommandHandler _previousPageCommand;
        public CommandHandler PreviousPageCommand
        {
            get 
            {
                return _previousPageCommand ?? (_previousPageCommand = new CommandHandler(param => PreviousPage(), true));
            }
            set 
            { 
                _previousPageCommand = value; 
                OnPropertyChanged("PreviousPageCommand"); 
            }
        }

        private CommandHandler _nextPageCommand;
        public CommandHandler NextPageCommand
        {
            get 
            {
                return _nextPageCommand ?? (_nextPageCommand = new CommandHandler(param => NextPage(), true));
            }
            set
            {
                _nextPageCommand = value;
                OnPropertyChanged("NextPageCommand");
            }
        }

        private void PreviousPage()
        {
            int currentIdx = Pages.IndexOf(CurrentPageView);
            if (currentIdx == 0)
            {
                return;
            }
            CurrentPageView = Pages[currentIdx-1];
        }

        private void NextPage()
        {
            int currentIdx = Pages.IndexOf(CurrentPageView);
            if (currentIdx + 1 == Pages.Count)
            {
                return;
            }
            CurrentPageView = Pages[currentIdx + 1];
        }

        public DownloadsViewModel()
        {
            Pages.Add(new DownloadsViewModel1());
            Pages.Add(new DownloadsViewModel2());
            Pages.Add(new DownloadsViewModel3());
            CurrentPageView = Pages[0];
        }
    }
}
