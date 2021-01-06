using System;
using TestApp.Resources.Styling;
using Xamarin.Forms;

namespace TestApp.Components
{
    public class OnBoardingButton: Button
    {
        public OnBoardingButton()
        {
            FontFamily = Fonts.Organo;
            TextColor = Color.FromHex(Colors.TATextColor);
            FontAttributes = FontAttributes.Bold;
            FontSize = 24.0;
            BackgroundColor = Color.FromHex(Colors.TAButtonColor);
        }
    }
}
