using System;

using Xamarin.Forms;

namespace XForms
{
	public class CustomNavigationPage : NavigationPage
	{
		public CustomNavigationPage (Page root) : base(root)
		{
			BindingContext = new CustomNavigationPageViewModel();

			this.SetBinding<CustomNavigationPageViewModel>(NavigationPage.BarBackgroundColorProperty, m => m.BarBackgroundColor);

			this.SetBinding<CustomNavigationPageViewModel>(NavigationPage.BarTextColorProperty, m => m.BarTextColor);
				
		}
	}
}


