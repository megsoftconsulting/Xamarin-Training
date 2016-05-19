using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace XForms
{
	public partial class EditScreenXAML : ContentPage
	{
		Person _person;

		ObservableCollection<Person> _collection;

		public EditScreenXAML (Person person, ref ObservableCollection<Person> collection)
		{
			_collection = collection;

			_person = person;

			InitializeComponent ();

			UserName.Text = person.UserName;

			Subtitle.Text = person.Subtitle;

			Button.Command = new Command(OnSave);
		}

		async void OnSave ()
		{
			var username = UserName.Text;

			var subtitle = Subtitle.Text;

			var condition = string.IsNullOrEmpty(username) || string.IsNullOrEmpty(subtitle);

			if(condition)
				await DisplayAlert("Error", "Please ensure that you enter a Username and Subtitle", "Ok");
			else
			{
				var update = _collection.FirstOrDefault(x => x.UniqueIdentifier == _person.UniqueIdentifier);

				if(update != null)
				{
					var person = new Person();

					person.UserName = username;

					person.Subtitle = subtitle;

					person.Color = Color.FromHex(GetRandomColor());

					var index = _collection.IndexOf(update);

					_collection.Remove(update);

					_collection.Insert(index, person);
				}

				await Navigation.PopAsync();
			}
		}

		string GetRandomColor()
		{
			var colors = new string[] {
				"F08080",
				"E0FFFF",
				"FAFAD2",
				"D3D3D3",
				"90EE90",
				"FFB6C1",
				"FFA07A",
				"20B2AA",
				"87CEFA",
				"778899",
				"B0C4DE",
				"FFFFE0",
				"00FF00",
				"32CD32"
			};

			return colors[new Random().Next(colors.Length)];
		}
	}
}

