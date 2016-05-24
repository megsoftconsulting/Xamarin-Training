using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XForms
{
	public partial class XFormsApp : Application
	{
		public XFormsApp ()
		{
			InitializeComponent ();

            MainPage = new NavigationPage(new MainScreenXaml());
		}
	}
}

