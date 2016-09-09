using TinyMessenger;
using Xamarin.Forms;
using XForms.Screens.Master;
using XForms.CodeBehind;
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

           // var shell = new LoginScreen ();
           // MainPage = shell;

            var nav =new VirtualCardScreen ();
            MainPage = nav;
		}
	}
}

