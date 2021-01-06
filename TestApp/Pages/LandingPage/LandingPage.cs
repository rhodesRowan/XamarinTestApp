using System;
using Xamarin.Forms;
using TestApp.Pages.Login;

namespace TestApp.Pages.Landing
{
    public class LandingPage : ContentPage
    {

        private Button loginButton;
        private Image backgroundImage;
        private RelativeLayout relativeLayout;

        public LandingPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Content = BuildContent();
        }

        private RelativeLayout BuildContent()
        {
            relativeLayout= new RelativeLayout();
            addBackgroundImage();
            addLoginButton();
            return relativeLayout;
        }

        private void addBackgroundImage()
        {
            backgroundImage = BackgroundImage();
            relativeLayout.Children.Add(
                backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height;
                })
            );
        }

        private void addLoginButton()
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
            Constraint.RelativeToParent((parent =>
            {
                return parent.Width * 0.8;
            }))
            );
        }

        private Button LoginButton()
        {
            Button login = new Button
            {
                Text = "Login",
                FontFamily = "Organo",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 24.0,
                BackgroundColor = Color.FromHex("abd1d4"),
            };
            login.Clicked += onLoginButtonClicked;
            return login;
        }

        private new Image BackgroundImage()
        {
            return new Image
            {
                Source = ImageSource.FromResource("TestApp.Resources.Images.landingPageBackground.jpg"),
                Aspect = Aspect.AspectFill
            };
        }

        async private void onLoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

    }
}
