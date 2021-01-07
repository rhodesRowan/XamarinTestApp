using System;
using TestApp.Models;
using TestApp.Pages.Landing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using TestApp.Pages.Home;
using TestApp.Resources;
using TestApp.Helpers;

namespace TestApp
{
    public partial class App : Application
    {
        public static User CurrentUser;

        public App()
        {
            InitializeComponent();

            if (currentUserExists())
            {
                MainPage = new HomePage();
            }
            else
            {
                MainPage = new NavigationPage(new LandingPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public Boolean currentUserExists()
        {
            return CurrentUser != null ? true : CurrentUserExistsInPreferences();

        }

        public Boolean CurrentUserExistsInPreferences()
        {
            var currentUser = Preferences.Get(Constants.CurrentUser, null);

            if (currentUser != null)
            {
                CurrentUser = Utilities.DeserializeFromJson<User>(currentUser);
                return currentUserExists();
            }
            else
            {
                return false;
            }
        }
    }
}
