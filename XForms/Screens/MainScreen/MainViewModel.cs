using System;
using System.ComponentModel;

namespace XForms
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public string AvailableAmountLabel { get; set; }

		public double AvailableAmount { get; set; }

		public MainViewModel ()
		{
			AvailableAmountLabel = "AVAILABLE BALANCE";

			AvailableAmount = 12000.00;
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

