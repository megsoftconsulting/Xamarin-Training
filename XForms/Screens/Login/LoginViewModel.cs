using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace XForms
{
	public class LoginViewModel : INotifyPropertyChanged
	{
		public string Title { get; set; }

		public string UserNamePlaceholder { get; set; }
	
		public string UserName { get; set; }

		public string PasswordPlaceholder { get; set; }

		public string Password { get; set; }

		public string ForgotPasswordLabel { get; set; }

		public string LoginActionLabel { get; set; }

		public Color LoginActionColor { get; set; }

		public ICommand ForgotPasswordCommand { get; set; }

		public ICommand LoginCommand { get; set; }

		public LoginViewModel ()
		{
			Title = "Sign in";

			UserNamePlaceholder = "Username or Email";

			PasswordPlaceholder = "Password";

			ForgotPasswordLabel = "Forgot your password?";

			LoginActionLabel = "Sign in";

			LoginActionColor = Color.FromHex("3eb5e5");

			ForgotPasswordCommand = new Command(OnForgotPassword);

			LoginCommand = new Command(OnLogin);
		}

		void OnForgotPassword ()
		{
			
		}

		void OnLogin ()
		{
			Application.Current.MainPage.Navigation.PushAsync(new MainScreen());
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged (PropertyChangedEventArgs e)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler (this, e);
		}
	}
}

