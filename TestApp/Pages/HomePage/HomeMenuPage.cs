using System;
using TestApp.ViewModels;
using Xamarin.Forms;

namespace TestApp.Pages.HomePage
{
    public class HomeMenuPage: ContentPage
    {
        public HomeMenuPage()
        {
            Title = "Test App Menu";
            BindingContext = new HomePageViewModel();
            Content = new StackLayout
            {
                Children = { flowListView() }
            };
        }

        private ListView flowListView()
        {
            var listView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid { Padding = new Thickness(5, 10) };
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    var label = new Label { VerticalOptions = LayoutOptions.FillAndExpand };
                    label.SetBinding(Label.TextProperty, "identifier");

                    grid.Children.Add(label, 1, 0);

                    return new ViewCell { View = grid };
                }),
                SeparatorVisibility = SeparatorVisibility.None
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "FlyoutItems", BindingMode.OneWay);
            return listView;
        }
    }
}
