using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace XForms.CodeBehind
{
	public class LoginScreen : ContentPage
	{
		public LoginScreen ()
		{
			Content = CreatePageContent();
		}

		public View CreatePageContent ()
		{
			var logo = new Image
			{
				Source = "megsoft",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200,
				Aspect = Aspect.AspectFit
			};

			var title = new Label
			{
				Text = "Social App",
				TextColor = Color.FromHex("13a3e2"),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = 32
			};

			var subtitle = new Label
			{
				Text = "Be social. Meet new people",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Gray
			};

			var firstLayout = new StackLayout
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = 
				{
					logo,
					title,
					subtitle
				}
			};

			var facebookButton = new StackLayout
			{
				Children = 
				{
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						Children = 
						{
							new Button
							{
								HorizontalOptions = LayoutOptions.CenterAndExpand,
								BackgroundColor = Color.FromHex("3b5998"),
								BorderRadius = 4,
								Text = "Login using Facebook",
								WidthRequest = 200,
								TextColor = Color.White,
								Command = new Command(OnNavigateTo)
							}
						}
					}
				}
			};

			var releaseVersion = new Label
			{
				Text = "Demo 1.0",
				TextColor = Color.Gray,
				FontSize = 10,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var secondLayout = new StackLayout
			{
				Spacing = 12,
				VerticalOptions = LayoutOptions.End,
				Children = 
				{
					facebookButton,
					releaseVersion
				}
			};

			return new StackLayout
			{
				Padding = new Thickness(20,40),
				Children = 
				{
					firstLayout,
					secondLayout
				}
			};
		}

		async void OnNavigateTo ()
		{
			await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new MainScreen()));
		}
	}
}

