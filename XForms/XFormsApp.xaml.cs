using TinyMessenger;
using Xamarin.Forms;
using XForms.CodeBehind;
using XForms.Screens.AddFriend;
using XForms.Screens.AddFriend.XAML;
using XForms.Screens.FriendList;
using XForms.Screens.FriendList.XAML;
using XForms.Screens.Profile;
using XForms.Screens.Profile.XAML;
using XForms.Screens.VirtualCards.Code_Behind;

namespace XForms
{
	public partial class XFormsApp : Application
	{
        public static ITinyMessengerHub Messenger { get; private set; }

		public XFormsApp ()
		{
			InitializeComponent ();

            Messenger = new TinyMessengerHub();
            
			MainPage = new NavigationPage(new VirtualCardScreen());
		}
	}
}

