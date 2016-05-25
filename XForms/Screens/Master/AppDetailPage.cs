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

			this.SetBinding<AppDetailViewModel>(MasterDetailPage.BackgroundColorProperty, m => m.BackgroundColor);

			Detail = new CustomNavigationPage(new MainScreenXaml());

            Master = new MenuScreen();

            BindingContext = new AppDetailViewModel();
        }
    }
}
