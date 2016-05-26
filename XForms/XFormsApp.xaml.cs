using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XForms.CodeBehind;
using XForms.Screens.Menu;
using XForms.Screens.TransactionDetail;

namespace XForms
{
	public partial class XFormsApp : Application
	{
		public XFormsApp ()
		{
			InitializeComponent ();

			MainPage = new NavigationPage(new LoginScreen());
		}
	}
}

