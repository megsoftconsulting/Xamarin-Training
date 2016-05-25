using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XForms.CodeBehind;
using XForms.Screens.Menu;

namespace XForms
{
	public partial class XFormsApp : Application
	{
		public XFormsApp ()
		{
			InitializeComponent ();

			MainPage = new NavigationPage(new PaymentListScreen());
		}
	}
}

