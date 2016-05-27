using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TinyMessenger;
using Xamarin.Forms;
using XForms.Screens.Menu;
using XForms.Shared;

namespace XForms.Screens.Master
{
    public class AppDetailViewModel : INotifyPropertyChanged
    {
        public Color BackgroundColor { get; set; }

        public string Icon { get; set; }

		public string Title { get; set; }

        public event EventHandler<NavigateToEventArg> NavigateTo;

        public AppDetailViewModel()
        {
            Icon = "drawer";

			Title = "Dashboard";

			BackgroundColor = Color.FromHex("474747");

            Subscribe();
        }

        private void Subscribe()
        {
            XFormsApp.Messenger.Subscribe<NavigateToArgument>(OnNavigateToReceived);
        }

        private void OnNavigateToReceived(NavigateToArgument obj)
        {
            OnNavigateTo(new NavigateToEventArg
            {
                NextScreen = obj.Screen
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnNavigateTo(NavigateToEventArg e)
        {
            NavigateTo?.Invoke(this, e);
        }
    }
}
