using Xamarin.Forms;
using XForms.Screens.Profile;
using XForms.Screens.Profile.XAML;

namespace XForms.Screens.FriendList
{
    public class FriendListScreen : ContentPage
    {
        public FriendListScreen()
        {
            Content = CreateContent();

            BindingContext = new FriendListViewModel();
        }

        private View CreateContent()
        {
            this.SetBinding<FriendListViewModel>(TitleProperty, m => m.Title);

            var listView = new ListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemTemplate = new DataTemplate(typeof(FriendListViewCell)),
                HasUnevenRows = true,
                SeparatorVisibility = SeparatorVisibility.None,
                SeparatorColor = Color.Transparent
            };

            listView.SetBinding<FriendListViewModel>(ListView.ItemsSourceProperty, m => m.Friends);

            listView.ItemTapped += (object sender, ItemTappedEventArgs e) => {

                if (e.Item == null) return;

                ((ListView)sender).SelectedItem = null;

            };

            return listView;
        }
    }
}

