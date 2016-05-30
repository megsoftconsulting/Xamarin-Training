using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XForms.Screens.AddFriend
{
    public class AddFriendViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public Color Background { get; set; }

        public AddFriendViewModel()
        {
            Background = Color.FromHex("f0eff4");

            Title = "Add Contact";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}