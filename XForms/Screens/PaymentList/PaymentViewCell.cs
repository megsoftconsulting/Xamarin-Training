using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace XForms
{
	public class PaymentViewCell : ViewCell
	{
		public PaymentViewCell ()
		{
			this.View = CreateContent();
		}

		View CreateContent ()
		{
			var image = new CircleImage
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 48,
				HeightRequest = 48,
				Aspect = Aspect.AspectFill,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			image.SetBinding<Payment>(CircleImage.SourceProperty, m => m.EntityIcon);

			var name = new Label
			{
				FontAttributes = FontAttributes.Bold,
				FontSize = 16
			};

			name.SetBinding<Payment>(Label.TextProperty, m => m.EntityName);

			var subtitle = new Label
			{
				TextColor = Color.Gray,
				FontSize = 12
			};

			subtitle.SetBinding<Payment>(Label.TextProperty, m => m.ActionGiven);

			var amount = new Label
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.EndAndExpand
			};

			amount.SetBinding<Payment>(Label.TextProperty, m => m.TransactionAmount, BindingMode.Default, new AmountFormatter());

			return new StackLayout
			{
				Padding = new Thickness(20,0),
				Orientation = StackOrientation.Horizontal,
				Children = 
				{
					image,
					new StackLayout
					{
						HorizontalOptions = LayoutOptions.StartAndExpand,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Children = 
						{
							name,
							subtitle
						}
					},
					amount
				}
			};
		}
	}
}

