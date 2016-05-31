using System;
using System.Linq.Expressions;
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
            
            var firstName = CreateDash(m => m.FirstName, m => m.FirstNameHeader);

            var givenName = CreateDash(m => m.GivenName, m => m.GivenNameHeader);

            var address = CreateDash(m => m.Address, m => m.AddressHeader);

            var city = CreateDash(m => m.City, m => m.CityHeader);

            var phoneNumber = CreateDash(m => m.PhoneNumber, m => m.PhoneNumberHeader);

            var email = CreateDash(m => m.Email, m => m.EmailHeader);

            var saveButton = new Button
            {
                TextColor = Color.White,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            saveButton.SetBinding<AddFriendViewModel>(Button.TextProperty, m => m.SaveText);

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

        private View CreateDash(Expression<Func<AddFriendViewModel, object>> title,
            Expression<Func<AddFriendViewModel, object>> hint)
        {
            var tit = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Start
            };

            tit.SetBinding(Label.TextProperty, title);

            var hin = new LineEntry
            {
                TextColor = Color.Gray,
                PlaceholderColor = Color.Gray,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            hin.SetBinding(Entry.PlaceholderProperty, hint);

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
