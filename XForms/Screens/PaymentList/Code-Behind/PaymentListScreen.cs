using System;
using Xamarin.Forms;
using XForms.Screens.TransactionDetail;

namespace XForms
{
	public class PaymentListScreen : ContentPage
	{
		PaymentListViewModel _viewModel;

		public PaymentListScreen ()
		{
			Content = CreateContent();

			_viewModel = new PaymentListViewModel ();

			_viewModel.NavigateToEvent += OnNavigateTo;

			BindingContext = _viewModel;
		}

		void OnNavigateTo (object sender, EventArgs e)
		{
			Navigation.PushAsync(new TransactionDetailScreen());
		}

		View CreateContent ()
		{
            this.SetBinding<PaymentListViewModel>(TitleProperty, m => m.Title);

			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(PaymentViewCell)),
				RowHeight = 70,
				SeparatorVisibility = SeparatorVisibility.None,
				SeparatorColor = Color.Transparent,
				IsGroupingEnabled = true,
				GroupDisplayBinding = new Binding("Text", BindingMode.Default, new DateConverter()),
				GroupHeaderTemplate = null
			};

			listView.ItemTapped += (object sender, ItemTappedEventArgs e) => {

				if (e.Item != null)
				{
					_viewModel.SelectedCommand.Execute(null);
				}

				((ListView)sender).SelectedItem = null; 

			};

			listView.SetBinding<PaymentListViewModel>(ListView.ItemsSourceProperty, m => m.Payments);

			return listView;
		}
	}
}