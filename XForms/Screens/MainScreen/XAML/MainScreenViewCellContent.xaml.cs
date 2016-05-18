using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;

namespace XForms
{
	public partial class MainScreenViewCellContent : ViewCell
	{
		public ICommand EditCommand { get; set; }

		public ICommand DeleteCommand { get; set; }

		public MainScreenViewCellContent ()
		{
			InitializeComponent ();
		}

		public void OnEditClicked(object obj, EventArgs e)
		{
			EditCommand.Execute(obj);
		}

		public void OnDeleteClicked(object obj, EventArgs e)
		{
			DeleteCommand.Execute(obj);
		}
	}
}

