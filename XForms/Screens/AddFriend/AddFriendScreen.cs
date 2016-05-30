using Xamarin.Forms;
using XForms.Views;

namespace XForms.Screens.AddFriend
{
    public class AddFriendScreen : ContentPage
    {
        public AddFriendScreen()
        {
            Content = CreatePageContent();

            BindingContext = new AddFriendViewModel();
        }

        private View CreatePageContent()
        {
            this.SetBinding<AddFriendViewModel>(TitleProperty, m => m.Title);

            this.SetBinding<AddFriendViewModel>(BackgroundColorProperty, m => m.Background);
            
            var firstName = CreateDash("Name", "Pablo");

            var givenName = CreateDash("Given name", "Hoyiat");

            var address = CreateDash("Address line 1", "Billing Address");

            var city = CreateDash("City", "New York");

            var phoneNumber = CreateDash("Phone number", "1-929-495-381");

            var email = CreateDash("MiPal", "luis@mipal.com");

            var saveButton = new Button
            {
                TextColor = Color.White,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                Text = "Save",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var saveButtonLayout = new StackLayout
            {
                 BackgroundColor = Color.FromHex("3eb5e5"),
                 HorizontalOptions = LayoutOptions.FillAndExpand,
                 VerticalOptions = LayoutOptions.End,
                 Children =
                 {
                     saveButton
                 }
            };

            return new StackLayout
            {
                 Children =
                 {
                     new StackLayout
                     {
                         VerticalOptions = LayoutOptions.FillAndExpand,
                         Children =
                         {
                             firstName,
                             givenName,
                             address,
                             city,
                             phoneNumber,
                             email
                         }
                     },
                     saveButtonLayout
                 }
            };
        }

        private View CreateDash(string title, string hint)
        {
            var tit = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black,
                Text = title,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Start
            };

            var hin = new LineEntry
            {
                TextColor = Color.Gray,
                Placeholder = hint,
                PlaceholderColor = Color.Gray,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            return new StackLayout
            {
                Spacing = 14,
                Padding = 20,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.White,
                Children =
                {
                    tit,
                    hin
                }
            };
        }
    }
}
