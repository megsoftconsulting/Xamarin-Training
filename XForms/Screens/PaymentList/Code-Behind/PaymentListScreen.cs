﻿using System;
using Xamarin.Forms;

namespace XForms
{
	public class PaymentListScreen : ContentPage
	{
		public PaymentListScreen ()
		{
			Content = CreateContent();

			BindingContext = new PaymentListViewModel();
		}

		View CreateContent ()
		{
			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(PaymentViewCell)),
				RowHeight = 70,
				SeparatorVisibility = SeparatorVisibility.None,
				SeparatorColor = Color.Transparent
			};

			listView.SetBinding<PaymentListViewModel>(ListView.ItemsSourceProperty, m => m.Payments);

			return listView;
		}
	}
}