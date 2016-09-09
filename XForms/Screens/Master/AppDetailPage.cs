using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XForms.Screens.Menu;
using XForms.Shared;

namespace XForms.Screens.Master
{
    public class AppDetailPage : MasterDetailPage
    {
        public AppDetailPage()
        {
			this.SetBinding<AppDetailViewModel>(IconProperty, m => m.Icon);

			this.SetBinding<AppDetailViewModel>(TitleProperty, m => m.Title);

			this.SetBinding<AppDetailViewModel>(BackgroundColorProperty, m => m.BackgroundColor);

			Detail = new CustomNavigationPage(new MainScreen());

            Master = new MenuScreen();

            var viewModel = new AppDetailViewModel();

            viewModel.NavigateTo += OnNavigateTo;
        }

        private void OnNavigateTo(object sender, NavigateToEventArg navigateToEventArg)
        {
            var nextPage = Activator.CreateInstance(navigateToEventArg.NextScreen) as Page;

            Detail = new CustomNavigationPage(nextPage);

            IsPresented = false;
        }
    }
}
