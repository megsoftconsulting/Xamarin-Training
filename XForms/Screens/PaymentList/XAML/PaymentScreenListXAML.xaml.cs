using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XForms
{
	public partial class PaymentScreenListXaml : ContentPage
	{
		public PaymentScreenListXaml ()
		{
			InitializeComponent ();

            BindingContext = new PaymentListViewModel();
		}
	}
}

