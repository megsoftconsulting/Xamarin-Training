using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace XForms
{
	public class Tab
	{
		public string Title { get; set; }

		public string Icon { get; set; }

		public Color Background { get; set; }

		public Command OnSelected { get; set; }

		public Type NavigateToScreen { get; set; }
	}
}

