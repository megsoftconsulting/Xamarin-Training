using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XForms
{
	public partial class LoginScreenXAML : ContentPage
	{
		public LoginScreenXAML ()
		{
			InitializeComponent ();

			BindingContext = new LoginViewModel();

			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}