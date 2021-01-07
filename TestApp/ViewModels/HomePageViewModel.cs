using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TestApp.Models;
using TestApp.Services;
using Xamarin.Forms;

namespace TestApp.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private readonly DataManager dataManager = new DataManager();
        private ObservableCollection<WebLink> flyoutItems;
        public ObservableCollection<WebLink> FlyoutItems
        {
            get
            {
                return flyoutItems;
            }
            set
            {
                this.flyoutItems = value;
                OnPropertyChanged("FlyoutItems");

            }
        } 

        public HomePageViewModel()
        {
            addItems();
        }

        private void addItems()
        {
             var items = dataManager.getLocalWebLinks();

            foreach(WebLink item in items)
            {
                FlyoutItems.Add(item);
            }
        }

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
