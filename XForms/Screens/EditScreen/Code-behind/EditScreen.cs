using System;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XForms
{
	public class EditScreen : ContentPage
	{
		Entry _userName;

		Entry _subtitle;

		Person _person;

		ObservableCollection<Person> _collection;

		public EditScreen (Person person, ref ObservableCollection<Person> collection)
		{
			_collection = collection;

			_person = person;

			Content = CreatePageContent();

			_userName.Text = person.UserName;

			_subtitle.Text = person.Subtitle;
		}

		View CreatePageContent ()
		{
			var panel1 = CreatePanel("Luis", "Pick a username", out _userName);

			var panel2 = CreatePanel("Hey Xamarinos", "Pick a subtitle", out _subtitle);

			var info = new Label
			{
				Text = "A color will be automatically assigned to you",
				TextColor = Color.Gray,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontSize = 12
			};

			return new StackLayout
			{
				Spacing = 16,
				Children =
				{
					new StackLayout
					{
						Padding = new Thickness(16,30),
						VerticalOptions = LayoutOptions.FillAndExpand,
						Children = 
						{
							panel1,
							panel2
						}
					},
					info,
					new StackLayout
					{
						VerticalOptions = LayoutOptions.End,
						BackgroundColor = Color.FromHex("15dbab"),
						Padding = new Thickness(20),
						Children = 
						{
							new Button
							{
								BackgroundColor = Color.Transparent,
								BorderColor = Color.Transparent,
								Text = "Save",
								TextColor = Color.White,
								FontSize = 20,
								FontAttributes = FontAttributes.Bold,
								HorizontalOptions = LayoutOptions.CenterAndExpand,
								VerticalOptions = LayoutOptions.CenterAndExpand,
								Command = new Command(OnSave)
							}
						}
					}
				}
			};
		}

		async void OnSave ()
		{
			var username = _userName.Text;

			var subtitle = _subtitle.Text;

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

		View CreatePanel (string placeholder, string helper, out Entry entry)
		{
			entry = new Entry
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = placeholder,
				PlaceholderColor = Color.Gray,
				BackgroundColor = Color.Transparent,
				Margin = new Thickness(10),
				WidthRequest = 100
			};

			var label = new Label
			{
				Text = helper,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontSize = 18
			};

			return new StackLayout
			{
				Children = 
				{
					label,
					entry
				}
			};
		}
	}
}


