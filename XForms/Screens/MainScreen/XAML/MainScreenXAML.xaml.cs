using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XForms.Views;

namespace XForms
{
	public partial class MainScreenXaml : ContentPage
	{
	    public MainScreenXaml()
	    {
	        InitializeComponent();

            var viewModel = new MainViewModel();

            BindingContext = viewModel;

            viewModel.PropertyChanged += OnPropertyChanged;

			viewModel.NavigateTo += OnNavigateTo;

            viewModel.Init();
        }

		async void OnNavigateTo (object sender, TabEventArgs e)
		{
			var tab = e.Tab;

			if(tab == null)
				return;

			var instanceOf = (Page) Activator.CreateInstance(tab.NavigateToScreen);

			await Navigation.PushAsync(instanceOf);
		}

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Tabs":
                    {
                        var tab = sender as MainViewModel;

                        if (tab != null)
                        {
                            var list = tab.Tabs;

                            if (list != null && list.Count > 0)
                            {

                                var items = 0;

                                var quantity = list.Count / 2;

                                var rows = Grid.RowDefinitions.Count;

                                for (var column = 0; column < quantity; column++)
                                {
                                    for (var row = 0; row < rows; row++)
                                    {
                                        Grid.Children.Add(new InfoCard
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
    }
}