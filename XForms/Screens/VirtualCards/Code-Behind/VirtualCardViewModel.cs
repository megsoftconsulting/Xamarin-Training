using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace XForms.Screens.VirtualCards.Code_Behind
{
    [ImplementPropertyChanged]
    internal class VirtualCardViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<object> Property { get; set; }

        public object Selected { get; set; }

        public VirtualCardViewModel()
        {
            Property = new ObservableCollection<object>
            {
                new object { },
                new object { },
                new object { }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}