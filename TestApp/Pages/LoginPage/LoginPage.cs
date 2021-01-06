using System;
using System.Linq;
using TestApp.Components;
using TestApp.Pages.HomePage;
using TestApp.Resources.Localization;
using TestApp.Resources.Styling;
using TestApp.ViewModels;
using Xamarin.Forms;

namespace TestApp.Pages.Login
{
    public class LoginPage: BaseOnBoardingPage
    {
        private  LoginEntry usernameEntry;
        private  LoginEntry passwordEntry;
        readonly double componentHeight = 60.0;

        public LoginPage()
        {
          
            BindingContext = new LoginViewModel(Navigation);
            AddLoginCard();
        }

        private void AddLoginCard()
        {
            Frame cardFrame = new Frame
            {
                BorderColor     = Color.Gray,
                CornerRadius    = 25,
                Padding         = 30,
                BackgroundColor = Color.FromHex(Colors.TAPrimaryDarkColor),
                Content         = LoginStack()
            };
            
            relativeLayout.Children.Add(
                cardFrame,
                Constraint.RelativeToParent((parent) =>
                {
                    return 0;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height - cardFrame.Height;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                })
            );
        }

        private StackLayout LoginStack()
        {
            
            StackLayout stackLayout = new StackLayout
            {
                Spacing         = 10.0,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children        =
                {
                    LoginLabel(),
                    UsernameEntry(),
                    PasswordEntry(),
                    LoginButton()
                }
            };
            return stackLayout;
        }

        private Label LoginLabel()
        {
            var loginLabel = new Label
            {
                Text                    = LocalizedResources.welcomeMessage.ToUpper(),
                FontFamily              = Fonts.Organo,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize                = 30.0,
                FontAttributes          = FontAttributes.Bold
            };

            return loginLabel;
        }

        private LoginEntry UsernameEntry()
        {
            usernameEntry = new LoginEntry
            {
                Placeholder   = LocalizedResources.username,
                HeightRequest = componentHeight,
                ReturnType    = ReturnType.Next
            };

            usernameEntry.SetBinding(LoginEntry.TextProperty, "Username", BindingMode.TwoWay);
            usernameEntry.Completed += Entry_Completed;
            return usernameEntry;
        }

        private LoginEntry PasswordEntry()
        {
            passwordEntry = new LoginEntry
            {
               
                Placeholder   = LocalizedResources.password,
                HeightRequest = componentHeight,
                IsPassword    = true,
                ReturnType    = ReturnType.Done,
            };

            passwordEntry.SetBinding(LoginEntry.TextProperty, "Password", BindingMode.TwoWay);
            passwordEntry.Completed += Entry_Completed;
            return passwordEntry;
        }

        private OnBoardingButton LoginButton()
        {
            var loginButton = new OnBoardingButton
            {
                Text          = LocalizedResources.login.ToUpper(),
                HeightRequest = componentHeight,
            };


            loginButton.SetBinding(OnBoardingButton.CommandProperty, "AttemptLogin");
            return loginButton;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            var entry = sender as LoginEntry;

            if (entry.Text == usernameEntry.Text)
            {
                passwordEntry.Focus();
            }
            else
            {
                entry.Unfocus();
            }
        }
    }
}
