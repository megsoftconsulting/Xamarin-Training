using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
									var createdGrid = CreateView();

									var context = list[items++];

									createdGrid.BindingContext = context;

									_grid.Children.Add(createdGrid, row, column);
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

		View CreateView ()
		{
			var icon = new Image
			{
				WidthRequest = 64,
				HeightRequest = 64,
				Aspect = Aspect.AspectFit,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			icon.SetBinding<Tab>(Image.SourceProperty, m => m.Icon);

			var label = new Label
			{
				TextColor = Color.Gray,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontSize = 18
			};

			label.SetBinding<Tab>(Label.TextProperty, m => m.Title);

			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{
					new StackLayout
					{
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Children = 
						{
							icon,
							label
						}
					}
				}
			};

			layout.SetBinding<Tab>(StackLayout.BackgroundColorProperty, m => m.Background);

			return layout;
		}
	}
}