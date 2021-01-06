using System;
using Xamarin.Forms;
using TestApp.Pages.Login;
using System.Resources;
using TestApp.Resources.Localization;
using TestApp.Resources.Styling;
using TestApp.Components;

namespace TestApp.Pages.Landing
{
    public class LandingPage : BaseOnBoardingPage
    {

        private Button loginButton;        

        public LandingPage()
        {
            AddLoginButton();
        }

        private void AddLoginButton()
        {
            loginButton = LoginButton();
            relativeLayout.Children.Add(
            loginButton,
            Constraint.RelativeToParent((parent) =>
            {
                return parent.Width * 0.1;
            }),
            Constraint.RelativeToParent((parent) =>
            {
                return parent.Height * 0.9;
            }),
            Constraint.RelativeToParent((parent) =>
            {
                return parent.Width * 0.8;
            })
            );
        }

        private Button LoginButton()
        {
            Button login = new OnBoardingButton
            {
                Text = LocalizedResources.getStarted.ToUpper()
            };

            login.Clicked += onLoginButtonClicked;
            return login;
        }

        async private void onLoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

    }
}
