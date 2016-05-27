using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XForms.Screens.TransactionDetail;

namespace XForms
{
	public partial class PaymentScreenListXaml : ContentPage
	{
		PaymentListViewModel _viewModel;

		public PaymentScreenListXaml ()
		{
			InitializeComponent ();

			_viewModel = new PaymentListViewModel ();

			_viewModel.NavigateToEvent += OnNavigateTo;

			BindingContext = _viewModel;
		}

		void OnNavigateTo (object sender, EventArgs e)
		{
			Navigation.PushAsync(new TransactionDetailScreen());
		}

		public void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item != null)
			{
				_viewModel.SelectedCommand.Execute(null);
			}

			((ListView)sender).SelectedItem = null;
		}
	}
}

