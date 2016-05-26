using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XForms.Screens.FriendList
{
    public class FriendListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Person> Friends { get; set; }
        public string Title { get; set; }

        public FriendListViewModel()
        {
            Title = "Friend List";

            Friends = new List<Person>
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
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
