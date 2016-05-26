using Xamarin.Forms;
using XForms.Screens.Profile;

namespace XForms
{
	public partial class XFormsApp : Application
	{
		public XFormsApp ()
		{
			InitializeComponent ();

			MainPage = new NavigationPage(new ProfileScreen());
		}
	}
}

