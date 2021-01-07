using System;
using System.Collections.ObjectModel;
using TestApp.Models;
using TestApp.Services;

namespace TestApp.ViewModels
{
    public class HomePageViewModel
    {
        private readonly DataManager dataManager = new DataManager();
        ObservableCollection<WebLink> webLinks   = new ObservableCollection<WebLink>();
        public ObservableCollection<WebLink> WebLinks { get { return webLinks; } }
        

        public HomePageViewModel()
        {
            addItems();
        }

        private void addItems()
        {
            var items = dataManager.getLocalWebLinks();

            foreach(WebLink item in items)
            {
                webLinks.Add(item);
            }
        }
    }
}
