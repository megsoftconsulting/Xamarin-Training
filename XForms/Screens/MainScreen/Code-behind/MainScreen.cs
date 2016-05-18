using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace XForms
{
	public class MainScreen : ContentPage
	{
		ObservableCollection<Person> _data;

		public MainScreen ()
		{
			Init();

			Content = CreateContent();
		}

		void Init ()
		{
			_data = new ObservableCollection<Person> {
				new Person {
					UserName = "Luis Nunez",
					Subtitle = "Hey guys",
					Color = Color.Aqua
				},
				new Person {
					UserName = "Pinedax",
					Subtitle = "This listview is lit",
					Color = Color.Maroon
				}
			};
		}

		View CreateContent ()
		{
			Title = "Main";

			var addItem = new ToolbarItem
			{
				Icon = Device.OnPlatform<string>(string.Empty, "plus" ,string.Empty),
				Text = "Add",
				Command = new Command(OnAddItem)
			};

			ToolbarItems.Add(addItem);

			var listView = new ListView {
				ItemTemplate = new DataTemplate (()=>
					{
						var vc = new PeopleListViewCell();

						vc.EditUserCommand = new Command(OnEditUser);

						vc.DeleteUserCommand = new Command(OnDeleteUser);

						return vc;
					}),
				HasUnevenRows = true,
				SeparatorColor = Color.Gray,
				ItemsSource = _data
			};

			listView.ItemTapped += async(sender, e) => {

				if (listView.SelectedItem == null)
					return;
				else
				{
					await PersonSelected((Person) e.Item);
				}
				listView.SelectedItem = null;
			};

			return listView;
		}

		void OnDeleteUser (object obj)
		{
			var menuItem = (MenuItem) obj;

			var selectedItem = (Person) menuItem.CommandParameter;

			if(selectedItem != null)
			{
				_data.Remove(selectedItem);
			}
		}

		void OnEditUser (object obj)
		{
			
		}

		void OnAddItem ()
		{
			var newItem = new Person
			{
				UserName = "No name",
				Subtitle = "Edit me",
				Color = Color.Black
			};

			_data.Add(newItem);
		}

		async Task PersonSelected (Person person)
		{
			await Navigation.PushAsync(new MainScreen());
		}
	}
}


