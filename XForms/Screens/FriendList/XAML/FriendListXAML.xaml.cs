using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XForms.Screens.FriendList.XAML
{
    public partial class FriendListXaml : ContentPage
    {
        public FriendListXaml()
        {
            InitializeComponent();
            
            BindingContext = new FriendListViewModel();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            ((ListView)sender).SelectedItem = null;
        }
    }
}
