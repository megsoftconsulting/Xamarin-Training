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

			this.SetBinding<AppDetailViewModel>(MasterDetailPage.TitleProperty, m => m.Title);

			BackgroundColor = Color.FromHex("474747");

			Detail = new NavigationPage(new MainScreen()){
				BarBackgroundColor = Color.FromHex("3eb5e5"),
				BarTextColor = Color.White
			};

            Master = new MenuScreen();

            BindingContext = new AppDetailViewModel();
        }
    }

    public class AppDetailViewModel : INotifyPropertyChanged
    {
        
        public string Icon { get; set; }

		public string Title { get; set; }

        public AppDetailViewModel()
        {
            Icon = "drawer";

			Title = "Dashboard";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
