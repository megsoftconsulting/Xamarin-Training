using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using XForms.Views;

namespace XForms
{
	public class MainScreen : ContentPage
	{
		Grid _grid;

		public MainScreen ()
		{
			Content = CreatePageContent();

			var viewModel = new MainViewModel();

			BindingContext = viewModel;

			viewModel.PropertyChanged += OnPropertyChanged;

			viewModel.Init();
		}

		void OnPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
			case "Tabs":
				{
					var tab = sender as MainViewModel;

					if(tab != null)
					{
						var list = tab.Tabs;

						if(list != null && list.Count > 0)
						{

							var items = 0;

							var quantity = list.Count / 2;

							var rows = _grid.RowDefinitions.Count;

							for (var column = 0; column < quantity; column++)
							{
								for (var row = 0; row < rows; row++)
								{
									_grid.Children.Add(new InfoCard
                                    {
                                        BindingContext = list[items++]
                                    }, row, column);
								}
							}
						}
					}
				}
				break;
			}
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

			_grid = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			_grid.RowDefinitions.Add(new RowDefinition
				{
					Height = new GridLength(1, GridUnitType.Star)
				});
			_grid.RowDefinitions.Add(new RowDefinition
				{
					Height = new GridLength(1, GridUnitType.Star)
				});

			_grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = new GridLength(1, GridUnitType.Star)
				});

			_grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = new GridLength(1, GridUnitType.Star)
				});
			
			return new StackLayout
			{
				Children = 
				{
					layout,
					_grid
				}
			};
		}
	}
}