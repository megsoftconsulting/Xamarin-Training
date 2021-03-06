﻿using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace XForms.CodeBehind
{
	public class LoginScreen : ContentPage
	{
		public LoginScreen ()
		{
			Content = CreatePageContent();

			BindingContext = new LoginViewModel();

			NavigationPage.SetHasNavigationBar(this, false);
		}

		public View CreatePageContent ()
		{
			this.SetBinding<LoginViewModel>(TitleProperty, m => m.Title);

			var image = new Image
			{
				Margin = new Thickness(0,20,0,0),
				Aspect = Aspect.AspectFit, 
				WidthRequest = 110,
				HeightRequest = 110
			};

			image.SetBinding<LoginViewModel>(Image.SourceProperty, m => m.Logo);

			var header = new Label
			{
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			header.SetBinding<LoginViewModel>(Label.TextProperty, m => m.Header);
			header.SetBinding<LoginViewModel>(Label.TextColorProperty, m => m.LoginActionColor);

			var userNameEntry = new Entry
			{
				TextColor = Color.Gray
			};
			userNameEntry.SetBinding<LoginViewModel>(Entry.PlaceholderProperty, m => m.UserNamePlaceholder);
			userNameEntry.SetBinding<LoginViewModel>(Entry.TextProperty, m => m.UserName);

			var passwordEntry = new Entry
			{
				TextColor = Color.Gray
			};
			passwordEntry.SetBinding<LoginViewModel>(Entry.PlaceholderProperty, m => m.PasswordPlaceholder);
			passwordEntry.SetBinding<LoginViewModel>(Entry.TextProperty, m => m.Password);

			var forgotPasswordLabel = new Label
			{
				TextColor = Color.Gray,
				FontSize = 12
			};

			var tapGesture = new TapGestureRecognizer();

			tapGesture.SetBinding<LoginViewModel>(TapGestureRecognizer.CommandProperty, m => m.ForgotPasswordCommand);

			forgotPasswordLabel.GestureRecognizers.Add(tapGesture);

			forgotPasswordLabel.SetBinding<LoginViewModel>(Label.TextProperty, m => m.ForgotPasswordLabel);
			
			var loginButton = new Button
			{
				BorderRadius = 4,
				BorderColor = Color.Transparent,
				WidthRequest = 100,
				VerticalOptions = LayoutOptions.End,
				TextColor = Color.White
			};

			loginButton.SetBinding<LoginViewModel>(Button.BackgroundColorProperty, m => m.LoginActionColor);
			loginButton.SetBinding<LoginViewModel>(Button.TextProperty, m => m.LoginActionLabel);
			loginButton.SetBinding<LoginViewModel>(Button.CommandProperty, m => m.LoginCommand);

			return new StackLayout
			{
				Padding = new Thickness(20,40),
				Children = 
				{
					new StackLayout
					{
						Spacing = 10,
						Children = 
						{
							image,
							header
						}
					},
					new StackLayout
					{
						Spacing = 20,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Children = 
						{
							userNameEntry,
							passwordEntry,
							forgotPasswordLabel
						}
					},
					loginButton
				}
			};
		}
	}
}

