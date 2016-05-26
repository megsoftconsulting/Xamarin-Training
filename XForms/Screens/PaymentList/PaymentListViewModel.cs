using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace XForms
{
	public class PaymentListViewModel : INotifyPropertyChanged
	{
		public List<GroupOfPayment> Payments { get; set; }

		public PaymentListViewModel ()
		{
			Payments = new List<GroupOfPayment>
			{
				new GroupOfPayment(DateTime.Now)
				{
					new Payment
					{
						ActionGiven = "Money Received",
						EntityName = "Raul Hernandez",
						TransactionAmount = 200.00,
						EntityIcon = "http://i.dailymail.co.uk/i/pix/2013/05/01/article-2317760-1991F946000005DC-783_964x634.jpg"
					},
					new Payment
					{
						ActionGiven = "Money Sent",
						EntityName = "Luis Nunez",
						TransactionAmount = 1200.00,
						EntityIcon = "http://static.boredpanda.com/blog/wp-content/uploads/2014/06/guinea-pig-booboo-lieveheersbeestje-60.jpg"
					}
				},
				new GroupOfPayment(DateTime.Now.Subtract(TimeSpan.FromDays(40)))
				{
					new Payment
					{
						ActionGiven = "Money Received",
						EntityName = "Claudio Sanchez",
						TransactionAmount = 2000.00,
						EntityIcon = "http://i50.tinypic.com/zmz1af.jpg"
					}
				},
				new GroupOfPayment(DateTime.Now.Subtract(TimeSpan.FromDays(90)))
				{
					new Payment
					{
						ActionGiven = "Money Received",
						EntityName = "Raul Nunez",
						TransactionAmount = 8000.00,
						EntityIcon = "http://i.dailymail.co.uk/i/pix/2015/09/28/08/2CD1E26200000578-0-image-a-312_1443424459664.jpg"
					}
				}
			};
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}