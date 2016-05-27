using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XForms.Shared;

namespace XForms.Screens.Menu
{
    public class MenuViewCell : ViewCell
    {
        public MenuViewCell()
        {
            this.View = CreateContent();
        }

        private View CreateContent()
        {
            var icon = new Image
            {
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 16,
                HeightRequest = 16,
                Aspect = Aspect.AspectFit
            };

            icon.SetBinding<CustomMenu>(Image.SourceProperty, m => m.Icon);

            var label = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.Black,
                FontSize = 18
            };

            label.SetBinding<CustomMenu>(Label.TextProperty, m => m.Title);

            return new StackLayout
            {
                Spacing = 12,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(16,14),
                Children =
                {
                    icon,
                    label
                }
            };
        }
    }
}
