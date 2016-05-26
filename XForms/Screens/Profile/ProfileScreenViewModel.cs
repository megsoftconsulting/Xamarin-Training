using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XForms.Shared;

namespace XForms.Screens.Profile.XAML
{
    public class ProfileScreenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public ObservableCollection<ProfileSettings> ProfileSettings { get; set; }
        public string Picture { get; set; }
        public string Header { get; set; }

        public ProfileScreenViewModel()
        {
            Title = "MiProfile";

            Picture = "https://pbs.twimg.com/profile_images/378800000532546226/dbe5f0727b69487016ffd67a6689e75a.jpeg";
            
            Header = "Luis Alberto Pena Nunez";

            ProfileSettings = new ObservableCollection<ProfileSettings>
            {
                new ProfileSettings
                {
                    Title = "Email",
                    Subtitle = "luis@mipal.com"
                },
                new ProfileSettings
                {
                    Title = "Phone Number",
                    Subtitle = "612-242-6378"
                },
                new ProfileSettings
                {
                    Title = "Address",
                    Subtitle = "6876 Buttonwood Drive Hilliard, OH 43026"
                },
                new ProfileSettings
                {
                    Title = "Bank Entity",
                    Subtitle = "Banko (****9201)"
                }
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
