using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XForms.Views
{
    public class InfoCard : StackLayout
    {
		//Binding to TapGestureRecognizer.CommandProperty 
		//does not seem to be working, probably is it a Xamarin Forms bug?
        public InfoCard()
        {
            this.Children.Add(CreateContent());

			var tapGesture = new TapGestureRecognizer
			{
				NumberOfTapsRequired = 1
			};

			tapGesture.Tapped += (sender, e) => 
			{
				var binding = BindingContext as Tab;

				if(binding == null)
					return;

				binding.OnSelected.Execute(binding);
			};

//			tapGesture.SetBinding<Tab>(TapGestureRecognizer.CommandProperty, m => m.OnSelected);

//			tapGesture.SetBinding(TapGestureRecognizer.CommandProperty, ".");

			GestureRecognizers.Add(tapGesture);
        }

        private View CreateContent()
        {
            var icon = new Image
            {
                WidthRequest = 32,
                HeightRequest = 32,
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            icon.SetBinding<Tab>(Image.SourceProperty, m => m.Icon);

            var label = new Label
            {
                TextColor = Color.Gray,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 12
            };

            label.SetBinding<Tab>(Label.TextProperty, m => m.Title);

            var layout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new StackLayout
                    {
                        Spacing = 14,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            icon,
                            label
                        }
                    }
                }
            };

            layout.SetBinding<Tab>(BackgroundColorProperty, m => m.Background);

            return layout;
        }
    }
}
