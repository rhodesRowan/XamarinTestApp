using System;
using TestApp.Pages.HomePage;
using Xamarin.Forms;

namespace TestApp.Pages.Home
{
    public class HomePage : FlyoutPage
    {
        HomeMenuPage homeMenuPage;
        public HomePage()
        {
            homeMenuPage = new HomeMenuPage();
            Flyout = homeMenuPage;
            Detail = new NavigationPage(new HomeDetailPage());
        }
    }
}
