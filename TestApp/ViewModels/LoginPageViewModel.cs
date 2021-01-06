using System;
using System.ComponentModel;
using Xamarin.Forms;
using TestApp.Models;
using Xamarin.Essentials;
using System.Threading.Tasks;
using TestApp.Helpers;
using TestApp.Resources;
using TestApp.Pages.HomePage;
using System.Linq;
using TestApp.Resources.Localization;
using System.Runtime.CompilerServices;

namespace TestApp.ViewModels
{
    public class LoginViewModel: INotifyPropertyChanged
    {
        public string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public INavigation Navigation;
        public event PropertyChangedEventHandler PropertyChanged;

        public Command AttemptLogin { get; }

        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            AttemptLogin    = LoginUser();
        }

        private Command LoginUser()
        {
            return new Command(async () =>
            {
                if (await UserExists())
                {
                    Login();
                }
                else
                {
                    CreateNewUser();
                }

            });
        }

        async private Task<Boolean> UserExists()
        {
            var password     = await PasswordForUsername();
            return password != null;        
        }

        async private Task<String> PasswordForUsername()
        {
            try
            {
                return await SecureStorage.GetAsync(username);
            }
            catch
            {
                return null;
            }
        }

        private async void Login()
        {
            var StoredPassword = await PasswordForUsername();
            if (StoredPassword == Password)
            {
                var CurrentUser = new User(Username);
                var CurrentUserJsonString = Utilities.SerializeToJson(CurrentUser);
                Preferences.Set(Constants.CurrentUser, CurrentUserJsonString);
                App.CurrentUser = CurrentUser;
                NavigateToHome();
            }
            else
            {
                ShowAlertWithMessage(LocalizedResources.LoginWrongPassword);
            }
        }

        private async void CreateNewUser()
        {
            try
            {
                await SecureStorage.SetAsync(username, password);
                Login();
            }
            catch (Exception exception)
            {
                ShowAlertWithMessage(exception.Message);
            }
        }

        private async void NavigateToHome()
        {
            Navigation.InsertPageBefore(new Home(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

        private async void ShowAlertWithMessage(String Message)
        {
            await Application.Current.MainPage.DisplayAlert(LocalizedResources.LoginError, Message, LocalizedResources.LoginCTAMessage);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
