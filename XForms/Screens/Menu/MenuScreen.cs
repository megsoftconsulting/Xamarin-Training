using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XForms.Shared;

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

			var background = new Image
			{
				Aspect = Aspect.AspectFill
			};

			background.SetBinding<MenuViewModel>(Image.SourceProperty, m => m.Background);

			var loggedInUser = new Label
			{
				TextColor = Color.White,
				FontSize = 18,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			loggedInUser.SetBinding<MenuViewModel>(Label.TextProperty, m => m.LoggedInUser);

			var userLayout = new StackLayout
			{
				Children = 
				{
					loggedInUser
				}
			};

			var layout = new RelativeLayout
			{
				VerticalOptions = LayoutOptions.Start,
				Children = 
				{
					{
						background,
						Constraint.RelativeToParent(p=>0),
						Constraint.RelativeToParent(p=>0),
						Constraint.RelativeToParent(p=>p.Width),
						Constraint.RelativeToParent(p=>264)
					},
					{
						new BoxView { Color = Color.Black, Opacity = 0.6 },
						Constraint.RelativeToParent(p=>0),
						Constraint.RelativeToParent(p=>0),
						Constraint.RelativeToParent(p=>p.Width),
						Constraint.RelativeToParent(p=>264)
					},
					{
						userLayout,
						Constraint.RelativeToParent(p=>0),
						Constraint.RelativeToParent(p=>0),
						Constraint.RelativeToParent(p=>p.Width),
						Constraint.RelativeToParent(p=>264)
					}
				}
			};

            var listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(MenuViewCell)),
                SeparatorColor = Color.Transparent,
                SeparatorVisibility = SeparatorVisibility.None,
                RowHeight = 50,
				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.FillAndExpand
            };
			listView.ItemSelected += (sender, e) => {

                if (listView.SelectedItem == null)
                    return;
                else
                {
                    ((MenuViewModel)BindingContext).ItemSelectedCommand.Execute((CustomMenu)e.SelectedItem);
                }
                listView.SelectedItem = null;
            };
            
            listView.SetBinding<MenuViewModel>(ListView.ItemsSourceProperty, m => m.Options);
            listView.SetBinding<MenuViewModel>(ListView.SelectedItemProperty, m => m.SelectedOption);

			return new StackLayout
			{
				Spacing = 0,
				Children = 
				{
					layout,
					listView
				}
			};
        }
    }
}

