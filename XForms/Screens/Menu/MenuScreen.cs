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

			var background = new Image
			{
				Source = "background",
				Aspect = Aspect.AspectFill
			};

			var label = new Label
			{
				Text = "Welcome Back Luis",
				TextColor = Color.White,
				FontSize = 16,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			var userLayout = new StackLayout
			{
				Children = 
				{
					label
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
                RowHeight = 55,
				BackgroundColor = Color.Black.MultiplyAlpha(0.6),
				VerticalOptions = LayoutOptions.FillAndExpand
            };
			listView.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null;
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
