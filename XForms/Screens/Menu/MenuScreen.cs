using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XForms.Screens.Menu
{
    public class MenuScreen : ContentPage
    {
        public MenuScreen()
        {
            Content = CreateContent();

            BindingContext = new MenuViewModel();
        }

        private View CreateContent()
        {
            this.SetBinding<MenuViewModel>(TitleProperty, m => m.Title);

            this.SetBinding<MenuViewModel>(IconProperty, m => m.Icon);

            var listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(MenuViewCell)),
                SeparatorColor = Color.Transparent,
                SeparatorVisibility = SeparatorVisibility.None,
                RowHeight = 50
            };

            listView.SetBinding<MenuViewModel>(ListView.ItemsSourceProperty, m => m.Options);
            listView.SetBinding<MenuViewModel>(ListView.SelectedItemProperty, m => m.SelectedOption);

            return listView;
        }
    }
}
