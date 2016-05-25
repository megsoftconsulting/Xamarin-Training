using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace XForms
{
	public class PaymentListViewModel : INotifyPropertyChanged
	{
		public List<Payment> Payments { get; set; }

		public PaymentListViewModel ()
		{
			Payments = new List<Payment>
			{
				new Payment
				{
					ActionGiven = "Money Received",
					EntityName = "Raul Hernandez",
					TransactionAmount = 200.00,
					EntityIcon = "http://i.telegraph.co.uk/multimedia/archive/03491/Vladimir_Putin_1_3491835k.jpg"
				},
				new Payment
				{
					ActionGiven = "Money Received",
					EntityName = "Raul Hernandez",
					TransactionAmount = 200.00,
					EntityIcon = "http://i.telegraph.co.uk/multimedia/archive/03491/Vladimir_Putin_1_3491835k.jpg"
				},
				new Payment
				{
					ActionGiven = "Money Received",
					EntityName = "Raul Hernandez",
					TransactionAmount = 200.00,
					EntityIcon = "http://i.telegraph.co.uk/multimedia/archive/03491/Vladimir_Putin_1_3491835k.jpg"
				},
				new Payment
				{
					ActionGiven = "Money Received",
					EntityName = "Raul Hernandez",
					TransactionAmount = 200.00,
					EntityIcon = "http://i.telegraph.co.uk/multimedia/archive/03491/Vladimir_Putin_1_3491835k.jpg"
				}
			};
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}