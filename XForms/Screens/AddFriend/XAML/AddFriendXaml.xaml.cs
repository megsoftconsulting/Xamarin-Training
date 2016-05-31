using Xamarin.Forms;

namespace XForms.Screens.AddFriend.XAML
{
    public partial class AddFriendXaml : ContentPage
    {
        public AddFriendXaml()
        {
            InitializeComponent();

            BindingContext = new AddFriendViewModel();
        }
    }
}
