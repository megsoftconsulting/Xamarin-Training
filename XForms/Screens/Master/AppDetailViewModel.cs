using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XForms.Annotations;
using XForms.Screens.Menu;

namespace XForms.Screens.Master
{

    public class AppDetailViewModel : INotifyPropertyChanged
    {
		public Color BackgroundColor { get; set; }

        public string Icon { get; set; }

		public string Title { get; set; }

        public AppDetailViewModel()
        {
            Icon = "drawer";

			Title = "Dashboard";

			BackgroundColor = Color.FromHex("474747");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
