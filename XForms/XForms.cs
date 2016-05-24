using System;
using Xamarin.Forms;
using XForms.CodeBehind;

namespace XForms
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new NavigationPage(new LoginScreenXAML());
		}

		protected override void OnStart ()
		{
			
		}

		protected override void OnSleep ()
		{
			
		}

		protected override void OnResume ()
		{
			
		}
	}
}

