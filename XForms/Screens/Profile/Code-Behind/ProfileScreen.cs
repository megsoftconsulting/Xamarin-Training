using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using XForms.Screens.Profile.XAML;

namespace XForms.Screens.Profile
{
    public class ProfileScreen : ContentPage
    {
        public ProfileScreen()
        {
            Content = CreateContent();

            BindingContext = new ProfileScreenViewModel();
        }

        private View CreateContent()
        {
            this.SetBinding<ProfileScreenViewModel>(TitleProperty, m => m.Title);

            BackgroundColor = Color.FromHex("004689");

            var picture = new CircleImage
            {
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 128,
                HeightRequest = 128,
                Aspect = Aspect.AspectFill
            };

            picture.SetBinding<ProfileScreenViewModel>(Image.SourceProperty, m => m.Picture);

            var changePictureHeader = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold
            };

            changePictureHeader.SetBinding<ProfileScreenViewModel>(Label.TextProperty, m => m.Header);

            var headerLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(30),
                BackgroundColor = Color.FromHex("3eb5e5"),
                HeightRequest = 200,
                Spacing = 30,
                Children =
                {
                    picture,
                    changePictureHeader
                }
            };

            var listView = new ListView
            {
                BackgroundColor = Color.FromHex("004689"),
                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemTemplate = new DataTemplate(typeof(ProfileViewCell)),
                RowHeight = 70,
                SeparatorVisibility = SeparatorVisibility.None,
                SeparatorColor = Color.Transparent
            };

            listView.SetBinding<ProfileScreenViewModel>(ListView.ItemsSourceProperty, m => m.ProfileSettings);

            listView.ItemTapped += (object sender, ItemTappedEventArgs e) => {

                if (e.Item == null) return;

                ((ListView)sender).SelectedItem = null; 

            };

            return new StackLayout
            {
                Spacing = 0,
                Children =
                {
                    headerLayout,
                    listView
                }
            };
        }
    }
}
