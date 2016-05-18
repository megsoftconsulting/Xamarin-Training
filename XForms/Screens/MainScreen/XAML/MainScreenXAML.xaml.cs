using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace XForms
{
	public partial class MainScreenXAML : ContentPage
	{
		ObservableCollection<Person> _data;

		public MainScreenXAML ()
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

			InitializeComponent ();

			ListView.ItemsSource = _data;

			ListView.ItemTemplate = new DataTemplate(()=>{
				return new MainScreenViewCellContent
				{
					DeleteCommand = new Command(OnDeleteUser),
					EditCommand = new Command(OnEditUser)
				};
			});

			AddItem.Command = new Command(OnAddItem);
		}

		public async void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (ListView.SelectedItem == null)
				return;
			else
			{
				await PersonSelected((Person) e.Item);
			}
			ListView.SelectedItem = null;
		}

		async Task PersonSelected (Person person)
		{
			await Navigation.PushAsync(new MainScreenXAML());
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
	}
}