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
            Title = "My Profile";

            Picture = "http://claudiosanchez.net/wp-content/uploads/2016/08/Claudio.jpg";
            
            Header = "Claudio Sanchez";

            ProfileSettings = new ObservableCollection<ProfileSettings>
            {
                new ProfileSettings
                {
                    Title = "Email",
                    Subtitle = "claudio@megsoftconsulting.com"
                },
                new ProfileSettings
                {
                    Title = "Phone Number",
                    Subtitle = "240-999-5555"
                },
                new ProfileSettings
                {
                    Title = "Address",
                    Subtitle = "1121 Annapolis Rd Suite 171, Odenton, MD 21113"
                },
                new ProfileSettings
                {
                    Title = "Bank",
                    Subtitle = "New Bank (****9201)"
                }
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
