using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XForms.Screens.Profile.XAML
{
    public partial class ProfileScreenXaml : ContentPage
    {
        public ProfileScreenXaml()
        {
            InitializeComponent();

            BindingContext = new ProfileScreenViewModel();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            ((ListView)sender).SelectedItem = null;

        }
    }
}
