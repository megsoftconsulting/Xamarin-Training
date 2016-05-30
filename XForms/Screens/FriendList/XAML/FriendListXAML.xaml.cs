using System;
using Xamarin.Forms;
using XForms.Screens.AddFriend;

namespace XForms.Screens.FriendList.XAML
{
    public partial class FriendListXaml : ContentPage
    {
        public FriendListXaml()
        {
            InitializeComponent();
            
            var vm = new FriendListViewModel();

            vm.NavigateTo += OnNavigateTo;

            BindingContext = vm;
        }

        private void OnNavigateTo(object sender, EventArgs eventArgs)
        {
            Navigation.PushAsync(new AddFriendScreen());
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            ((ListView)sender).SelectedItem = null;
        }
    }
}
