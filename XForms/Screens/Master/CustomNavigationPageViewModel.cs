using System;

using Xamarin.Forms;
using System.ComponentModel;

namespace XForms
{
	public class CustomNavigationPageViewModel : INotifyPropertyChanged
	{
		public Color BarBackgroundColor { get; set; }

		public Color BarTextColor { get; set; }

		public CustomNavigationPageViewModel ()
		{
			BarBackgroundColor = Color.FromHex("3eb5e5");

			BarTextColor = Color.White;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}


