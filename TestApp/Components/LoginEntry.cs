using System;
using TestApp.Resources.Styling;
using Xamarin.Forms;

namespace TestApp.Components
{
    public class LoginEntry : Entry
    {
        public LoginEntry()
        {
            HorizontalTextAlignment = TextAlignment.Center;
            ClearButtonVisibility = ClearButtonVisibility.WhileEditing;
            FontFamily = Fonts.Organo;
        }
    }
}
