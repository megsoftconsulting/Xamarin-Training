using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace XForms
{
	public class MainScreen : ContentPage
	{
		public MainScreen ()
		{
			Content = CreatePageContent();

			BindingContext = new MainViewModel();
		}

		View CreatePageContent ()
		{
			var availableAmountLabel = new Label
			{
				FontSize = 12,
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			availableAmountLabel.SetBinding<MainViewModel>(Label.TextProperty, m => m.AvailableAmountLabel);

			var availableAmount = new Label
			{
				FontSize = 30,
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			availableAmount.SetBinding<MainViewModel>(Label.TextProperty, m => m.AvailableAmount, BindingMode.Default, new AmountFormatter());

			var layout = new StackLayout
			{
				BackgroundColor = Color.FromHex("3eb5e5"),
				HeightRequest = 200,
				VerticalOptions = LayoutOptions.Start,
				Children = 
				{
					new StackLayout
					{
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Children = 
						{
							availableAmountLabel,
							availableAmount
						}
					}
				}
			};

			var grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			grid.RowDefinitions.Add(new RowDefinition
				{
					Height = new GridLength(1, GridUnitType.Star)
				});
			grid.RowDefinitions.Add(new RowDefinition
				{
					Height = new GridLength(1, GridUnitType.Star)
				});

			grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = new GridLength(1, GridUnitType.Star)
				});

			grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = new GridLength(1, GridUnitType.Star)
				});

			grid.Children.Add(new BoxView
				{
					Color = Color.Blue
				}, 0, 0);

			grid.Children.Add(new BoxView
				{
					Color = Color.Red
				}, 0, 1);

			grid.Children.Add(new BoxView
				{
					Color = Color.Silver
				}, 1,0);
			
			grid.Children.Add(new BoxView
				{
					Color = Color.Maroon
				}, 1, 1);

			return new StackLayout
			{
				Children = 
				{
					layout,
					grid
				}
			};
		}
	}
}


