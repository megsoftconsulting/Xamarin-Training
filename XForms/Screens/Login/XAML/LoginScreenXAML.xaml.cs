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
		}

		public async void OnNavigateTo (object sender, EventArgs e)
		{
			await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new MainScreen()));
		}
	}
}