using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XForms.Shared;

namespace XForms.Screens.Profile
{
    public class ProfileViewCell : ViewCell
    {
        public ProfileViewCell()
        {
            View = CreateContent();
        }

        private View CreateContent()
        {
            var header = new Label
            {
                FontSize = 12,
                TextColor = Color.White
            };

            header.SetBinding<ProfileSettings>(Label.TextProperty, m => m.Title);
            
            var value = new Label
            {
                FontSize = 16,
                TextColor = Color.White
            };

            value.SetBinding<ProfileSettings>(Label.TextProperty, m => m.Subtitle);

            return new StackLayout
            {
                Padding = new Thickness(20),
                BackgroundColor = Color.FromHex("004689"),
                Children =
                {
                    header,
                    value
                }
            };
        }
    }
}
