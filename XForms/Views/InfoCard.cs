using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XForms.Views
{
    public class InfoCard : StackLayout
    {
        public InfoCard()
        {
            this.Children.Add(CreateContent());
        }

        private View CreateContent()
        {
            var icon = new Image
            {
                WidthRequest = 32,
                HeightRequest = 32,
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            icon.SetBinding<Tab>(Image.SourceProperty, m => m.Icon);

            var label = new Label
            {
                TextColor = Color.Gray,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 12
            };

            label.SetBinding<Tab>(Label.TextProperty, m => m.Title);

            var layout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new StackLayout
                    {
                        Spacing = 14,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            icon,
                            label
                        }
                    }
                }
            };

            layout.SetBinding<Tab>(BackgroundColorProperty, m => m.Background);

            return layout;
        }
    }
}
