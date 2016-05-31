using Xamarin.Forms;
using XForms.Screens.AddFriend;
using XForms.Screens.Profile;
using XForms.Screens.Profile.XAML;

namespace XForms.Screens.FriendList
{
    public class FriendListScreen : ContentPage
    {
        private readonly FriendListViewModel _vm;

        public FriendListScreen()
        {
            Content = CreateContent();

			_vm = new FriendListViewModel();

            _vm.NavigateTo += OnNavigateTo;

			BindingContext = _vm;
        }

        void OnNavigateTo (object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddFriendScreen());
        }

        private View CreateContent()
        {
            this.SetBinding<FriendListViewModel>(TitleProperty, m => m.Title);

			var addItem = new ToolbarItem();

			addItem.SetBinding<FriendListViewModel>(ToolbarItem.TextProperty, m => m.AddItemTitle);
			addItem.SetBinding<FriendListViewModel>(ToolbarItem.CommandProperty, m => m.AddItemCommand);

			ToolbarItems.Add(addItem);

            var listView = new ListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemTemplate = new DataTemplate(() => new FriendListViewCell
                {
                    Option1Command = _vm.DeleteItemCommand
                }),
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

