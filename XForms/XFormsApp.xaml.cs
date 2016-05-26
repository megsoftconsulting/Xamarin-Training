using Xamarin.Forms;
using XForms.Screens.FriendList;
using XForms.Screens.Profile;
using XForms.Screens.Profile.XAML;

namespace XForms
{
	public partial class XFormsApp : Application
	{
		public XFormsApp ()
		{
			InitializeComponent ();

			MainPage = new NavigationPage(new FriendListScreen());
		}
	}
}

