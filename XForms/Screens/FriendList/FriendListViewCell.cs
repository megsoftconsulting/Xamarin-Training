using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace XForms.Screens.FriendList
{
    public class FriendListViewCell : ViewCell
    {
        public FriendListViewCell()
        {
            this.View = CreateContent();
        }
        
        private View CreateContent()
        {

            var image = new CircleImage
            {
                WidthRequest = 64,
                HeightRequest = 64,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Start
            };

            image.SetBinding<Person>(CircleImage.SourceProperty, m => m.Picture);
            
            var name = new Label
            {
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            name.SetBinding<Person>(Label.TextProperty, m => m.UserName);

            return new StackLayout
            {
                Padding = new Thickness(20,10),
                BackgroundColor = Color.FromHex("f6f6f6"),
                Spacing = 30,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    image,
                    name
                }
            };
        }
    }
}