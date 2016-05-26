using System;
using Xamarin.Forms;

namespace XForms
{
	public class DateConverter : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if(!(value is DateTime))
				return value;

			var date = (DateTime) value;

			return date.ToString("Y");
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value;
		}
	}
}

