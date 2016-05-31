using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TinyMessenger;
using Xamarin.Forms;
using XForms.Screens.FriendList;
using XForms.Screens.FriendList.XAML;
using XForms.Screens.Profile;
using XForms.Shared;

namespace XForms.Screens.Menu
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public List<CustomMenu> Options { get; set; }

        public CustomMenu SelectedOption { get; set; }

        public string Icon { get; set; }

		public string Title { get; set; }

		public string Background { get; set; }

		public string LoggedInUser { get; set; }

        public Command<CustomMenu> ItemSelectedCommand { get; set; }
        
        public MenuViewModel()
        {
            Title = "Title";

            Icon = "drawer";

			Background = "background";

			LoggedInUser = "Luis Nunez";

            ItemSelectedCommand = new Command<CustomMenu>(OnItemSelected);

            Options = new List<CustomMenu>
            {
                    new CustomMenu
                    {
                    Title = "Home",
                    Screen = typeof(MainScreen),
                    Icon = "home"
                    },
                   new CustomMenu
                   {
                        Title = "Mi Friends",
                        Screen = typeof(FriendListScreen),
                    Icon = "friends"
                   },
                   new CustomMenu
                   {
                        Title = "Mi Transactions",
                        Screen = typeof(PaymentListScreen),
                    Icon = "transaction"
                   },
                   new CustomMenu
                   {
                        Title = "Mi Profile",
                        Screen = typeof(ProfileScreen),
                    Icon = "profile"
                   }
            };
        }

        private void OnItemSelected(CustomMenu menu)
        {
            if (menu == null)
                return;

            XFormsApp.Messenger.Publish(new NavigateToArgument
            {
                Screen = menu.Screen
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
