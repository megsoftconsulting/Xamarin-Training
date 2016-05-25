using System;
using System.ComponentModel;
using System.Collections.Generic;
using Xamarin.Forms;
using XForms.CodeBehind;

namespace XForms
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public string Title { get; set; }

		public string AvailableAmountLabel { get; set; }

		public double AvailableAmount { get; set; }

		public List<Tab> Tabs { get; set; }

		public event EventHandler<TabEventArgs> NavigateTo;

		public MainViewModel ()
		{
			Title = "Dashboard";

			AvailableAmountLabel = "AVAILABLE BALANCE";

			AvailableAmount = 12000.00;
		}

		void OnTabSelected (Tab selectedTab)
		{
			OnNavigateTo(new TabEventArgs
				{
					Tab = selectedTab
				});
		}

		public void Init()
		{
			Tabs = new List<Tab>
			{
				new Tab
				{
					Title = "Pay",
					Icon = "pay",
					Background = Color.FromHex("f6f6f6"),
					OnSelected = new Command<Tab>(OnTabSelected),
					NavigateToScreen = typeof(LoginScreen)
				},
				new Tab
				{
					Title = "Request Money",
					Icon = "request",
					Background = Color.FromHex("f6f6f6"),
					OnSelected = new Command<Tab>(OnTabSelected),
					NavigateToScreen = typeof(LoginScreen)
				},
				new Tab
				{
					Title = "Profile Information",
					Icon = "profile",
					Background = Color.FromHex("f6f6f6"),
					OnSelected = new Command<Tab>(OnTabSelected),
					NavigateToScreen = typeof(LoginScreen)
				},
				new Tab
				{
					Title = "Log out",
					Icon = "logout",
					Background = Color.FromHex("f6f6f6"),
					OnSelected = new Command<Tab>(OnTabSelected),
					NavigateToScreen = typeof(LoginScreen)
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

		protected virtual void OnNavigateTo (TabEventArgs e)
		{
			var handler = NavigateTo;
			if (handler != null)
				handler (this, e);
		}
	}
}

