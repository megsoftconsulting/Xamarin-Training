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
					Color = Color.Aqua,
					UniqueIdentifier = Guid.NewGuid().ToString()
				},
				new Person {
					UserName = "Pinedax",
					Subtitle = "This listview is lit",
					Color = Color.Maroon,
					UniqueIdentifier = Guid.NewGuid().ToString()
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

		public void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (ListView.SelectedItem == null)
				return;
			else
			{
				//Handle selection here
			}
			ListView.SelectedItem = null;
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
			var menuItem = (MenuItem) obj;

			var selectedItem = (Person) menuItem.CommandParameter;

			if(selectedItem != null)
			{
				Navigation.PushAsync(new EditScreen((Person) selectedItem, ref _data));
			}
		}

		void OnAddItem ()
		{
			var newItem = new Person
			{
				UserName = "No name",
				Subtitle = "Edit me",
				Color = Color.Black,
				UniqueIdentifier = Guid.NewGuid().ToString()
			};

			_data.Add(newItem);
		}
	}
}