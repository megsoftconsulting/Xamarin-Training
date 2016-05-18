using System;

using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;
using System.Windows.Input;

namespace XForms
{
	public class PeopleListViewCell : ViewCell
	{
		public ICommand DeleteUserCommand { get; set; }

		public ICommand EditUserCommand { get; set; }

		public PeopleListViewCell ()
		{
			View = CreateContent();

			CreateContextActions();
		}

		View CreateContent ()
		{
			var image = new CircleImage
			{
				WidthRequest = 60,
				HeightRequest = 60,
			};

			image.SetBinding<Person>(CircleImage.FillColorProperty, m => m.Color);
			//image.SetBinding(CircleImage.SourceProperty, "Image");

			var name = new Label
			{
				FontAttributes = FontAttributes.Bold
			};

			name.SetBinding<Person>(Label.TextProperty, m => m.UserName);
			//name.SetBinding(Label.TextProperty, "UserName");

			var recipeList = new Label
			{
				TextColor = Color.Gray,
				FontSize = 12
			};
		
			recipeList.SetBinding<Person>(Label.TextProperty, m => m.Subtitle);
			//recipeList.SetBinding(Label.TextProperty, "RecipeCount");

			var layout = new StackLayout
			{
				Padding = new Thickness(20,0,0,0),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = 
				{
					name,
					recipeList
				}
			};

			return new StackLayout
			{
				Padding = new Thickness(10,16),
				Orientation = StackOrientation.Horizontal,
				Children = 
				{
					image,
					layout
				}
			};
		}

		void CreateContextActions ()
		{
			//Command property is not working so i had to use the Clicked event

			var moreAction = new MenuItem { Text = "Edit" , Command = EditUserCommand };

			moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));

			moreAction.Clicked += (object sender, EventArgs e) => 
			{
				EditUserCommand.Execute(sender);
			};
			
			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true, Command = DeleteUserCommand };

			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));

			deleteAction.Clicked += (object sender, EventArgs e) => 
			{
				DeleteUserCommand.Execute(sender);
			};

			ContextActions.Add (moreAction);

			ContextActions.Add (deleteAction);
		}
	}
}


