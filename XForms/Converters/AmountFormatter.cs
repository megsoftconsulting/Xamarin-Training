using System;
using Xamarin.Forms;

namespace XForms
{
	public class AmountFormatter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if(!(value is double))
				return value;

			return $"{(double)value:C}";
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}

