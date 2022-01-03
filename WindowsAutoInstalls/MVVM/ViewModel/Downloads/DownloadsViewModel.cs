using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowsAutoInstalls.BackEnd.Downloads;
using WindowsAutoInstalls.Components;
using WindowsAutoInstalls.Core;

namespace WindowsAutoInstalls.MVVM.ViewModel
{
    class DownloadsViewModel : ViewModelBase
    {

        public List<Page> Pages = new List<Page>();

        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private Dictionary<string, Dictionary<string, string>> AppsByCategory { get; set; }

        private void AddAllPages()
        {
            int category_count = 0;
            Page currentPage = new Page();
            foreach (KeyValuePair<string, Dictionary<string, string>> entry in AppsByCategory)
            {
                if (category_count % 3 == 0)
                {
                    Pages.Add(currentPage);
                    currentPage.Render();
                    currentPage = new Page();
                }
                string category = entry.Key;
                currentPage.AddCategory(category, entry.Value);
                category_count++;
            };
        }

        public DownloadsViewModel()
        {
            AppsByCategory = new DownloadLinks().GetCategoryApps();
            AddAllPages();
            CurrentPage = Pages[0];
            Console.WriteLine(CurrentPage.Keys);
        }
    }
}
