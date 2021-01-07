using System;
using TestApp.Resources;
using Xamarin.Forms;

namespace TestApp.Pages
{
    public class BaseOnBoardingPage : ContentPage
    {
        public  RelativeLayout relativeLayout;
        public  ScrollView scrollView;
        private Image backgroundImage;

        public BaseOnBoardingPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Content = BuildContent();
        }

        private RelativeLayout BuildContent()
        {
            relativeLayout = new RelativeLayout();
            AddBackgroundImage();
            return relativeLayout;
        }

        private void AddBackgroundImage()
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

        private new Image BackgroundImage()
        {
            return new Image
            {
                Source = ImageSource.FromResource($"{Constants.ImagesPath}/landingPageBackground.jpg"),
                Aspect = Aspect.AspectFill
            };
        }
    }
}
