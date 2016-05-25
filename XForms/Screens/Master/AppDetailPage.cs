using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XForms.Annotations;
using XForms.Screens.Menu;

namespace XForms.Screens.Master
{
    public class AppDetailPage : MasterDetailPage
    {
        public AppDetailPage()
        {
            this.SetBinding<AppDetailViewModel>(MasterDetailPage.IconProperty, m => m.Icon);

            Detail = new NavigationPage(new MainScreen());

            Master = new MenuScreen();

            BindingContext = new AppDetailViewModel();
        }
    }

    public class AppDetailViewModel : INotifyPropertyChanged
    {
        
        public string Icon { get; set; }

        public AppDetailViewModel()
        {
            Icon = "drawer";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
