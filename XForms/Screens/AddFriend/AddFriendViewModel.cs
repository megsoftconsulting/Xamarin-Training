using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XForms.Screens.AddFriend
{
    public class AddFriendViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        public Color Background { get; set; }

        public string FirstNameHeader { get; set; }

        public string FirstName { get; set; }

        public string GivenNameHeader { get; set; }

        public string GivenName { get; set; }

        public string AddressHeader { get; set; }

        public string Address { get; set; }

        public string CityHeader { get; set; }

        public string City { get; set; }

        public string PhoneNumberHeader { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailHeader { get; set; }

        public string Email { get; set; }
        public string SaveText { get; set; }

        public AddFriendViewModel()
        {
            Background = Color.FromHex("f0eff4");

            Title = "Add Contact";

            FirstNameHeader = "First Name";
            
            GivenNameHeader = "Given Name";
            
            AddressHeader = "Address";
            
            CityHeader = "City";
            
            PhoneNumberHeader = "Phone Number";
            
            EmailHeader = "Email";

            SaveText = "Save";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}