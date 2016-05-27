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

			var vm = new FriendListViewModel();

			vm.NavigateTo += OnNavigateTo;

			BindingContext = vm;
        }

        void OnNavigateTo (object sender, System.EventArgs e)
        {
			
        }

        private View CreateContent()
        {
            this.SetBinding<FriendListViewModel>(TitleProperty, m => m.Title);

			var addItem = new ToolbarItem();

			addItem.SetBinding<FriendListViewModel>(ToolbarItem.IconProperty, m => m.AddItemIcon);
			addItem.SetBinding<FriendListViewModel>(ToolbarItem.CommandProperty, m => m.AddItemCommand);

			ToolbarItems.Add(addItem);

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

