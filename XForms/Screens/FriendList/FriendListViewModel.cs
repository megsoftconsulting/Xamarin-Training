using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XForms.Screens.FriendList
{
    public class FriendListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Person> Friends { get; set; }

		public string AddItemTitle { get; set; }
        
        public string Title { get; set; }

		public ICommand AddItemCommand { get; set; }

        public string DeleteItemText { get; set; }

        public ICommand DeleteItemCommand { get; set; }

        public event EventHandler NavigateTo;

        public FriendListViewModel()
        {
            Title = "Friend List";

			AddItemTitle = "Add";

            DeleteItemText = "Delete";

            DeleteItemCommand = new Command<object>(OnDeleteItem);

            AddItemCommand = new Command(OnAddItem);

            Friends = new ObservableCollection<Person>
            {
                new Person
                {
                    Picture = "http://i.dailymail.co.uk/i/pix/2013/05/01/article-2317760-1991F946000005DC-783_964x634.jpg",
                    UserName = "Luis Nunez"
                },
                new Person
                {
                    Picture = "http://static.boredpanda.com/blog/wp-content/uploads/2014/06/guinea-pig-booboo-lieveheersbeestje-60.jpg",
           
                    UserName = "Claudio Sanchez"},
                new Person
                {
                    Picture =  "http://i50.tinypic.com/zmz1af.jpg",

                    UserName = "Pepe Magnu"
                },
                new Person
                {
                    Picture = "http://i.dailymail.co.uk/i/pix/2015/09/28/08/2CD1E26200000578-0-image-a-312_1443424459664.jpg",

                    UserName = "Pinedax"
                }
            };
            
        }
        
        private void OnDeleteItem(object obj)
        {
            Friends.Remove(obj as Person);
        }

        void OnAddItem ()
		{
			OnNavigateTo(null);
		}
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

		protected virtual void OnNavigateTo (EventArgs e)
		{
			var handler = NavigateTo;
			if (handler != null)
				handler (this, e);
		}
    }
}
