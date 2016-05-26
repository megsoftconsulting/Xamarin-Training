using System;
using System.Collections.Generic;

namespace XForms
{
	public class GroupOfPayment : List<Payment>
	{
		public DateTime Text { get; private set; }

		public GroupOfPayment (DateTime title)
		{
			Text = title;
		}
	}
}

