using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAutoInstalls.Components
{
    class Page : Dictionary<string, List<DownloadableApp>>
    {

        public void AddCategory(string category, Dictionary<string, string> apps)
        {
            Add(category, new List<DownloadableApp>());
            foreach(KeyValuePair<string, string> entry in apps)
            {
                DownloadableApp appObj = new DownloadableApp(entry.Key, entry.Value);
                this[category].Add(appObj);
            }
        }

        public void Render()
        {
            
        }

        public void Show()
        {

        }

        public void Hide()
        {

        }
    }
}
