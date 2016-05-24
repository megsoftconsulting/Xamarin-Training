using System;
using System.ComponentModel;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XForms
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public string AvailableAmountLabel { get; set; }

		public double AvailableAmount { get; set; }

		public List<Tab> Tabs { get; set; }

		public MainViewModel ()
		{
			AvailableAmountLabel = "AVAILABLE BALANCE";

			AvailableAmount = 12000.00;
		}

		public void Init()
		{
			Tabs = new List<Tab>
			{
				new Tab
				{
					Title = "Pay",
					Icon = "megsoft",
					Background = Color.FromHex("f6f6f6")
				},
				new Tab
				{
					Title = "Request Money",
					Icon = "megsoft",
					Background = Color.FromHex("f6f6f6")
				},
				new Tab
				{
					Title = "Profile Information",
					Icon = "megsoft",
					Background = Color.FromHex("f6f6f6")
				},
				new Tab
				{
					Title = "Log out",
					Icon = "megsoft",
					Background = Color.FromHex("f6f6f6")
				}
			};
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged (PropertyChangedEventArgs e)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler (this, e);
		}
	}
}

