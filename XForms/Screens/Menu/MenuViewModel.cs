using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XForms.Annotations;
using XForms.Shared;

namespace XForms.Screens.Menu
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public List<CustomMenu> Options { get; set; }

        public CustomMenu SelectedOption { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public MenuViewModel()
        {
            Title = "Title";

            Icon = "drawer";

            Options = new List<CustomMenu>
            {
                   new CustomMenu
                   {
                        Title = "Shop"
                   },
                   new CustomMenu
                   {
                        Title = "Activity"
                   },
                   new CustomMenu
                   {
                        Title = "Transfer"
                   },
                   new CustomMenu
                   {
                        Title = "Wallet"
                   },
                   new CustomMenu
                   {
                        Title = "Settings"
                   }
            };
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
