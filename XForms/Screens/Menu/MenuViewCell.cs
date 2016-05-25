using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            var label = new Label
            {
                TextColor = Color.White,
                FontSize = 18
            };

            label.SetBinding<Shared.CustomMenu>(Label.TextProperty, m => m.Title);

            return new StackLayout
            {
                Margin = new Thickness(10,10),
                BackgroundColor = Color.FromHex("cfcfcf"),
                Padding = new Thickness(16,10),
                Children =
                {
                    label
                }
            };
        }
    }
}
