using System;
using Android.App;
using Android.Runtime;
using Android.Content.PM;
using Xamarin.Forms;
using XForms.Services;

namespace XForms.Droid
{
	[Application]
	public class XFormsApp : Android.App.Application, Android.App.Application.IActivityLifecycleCallbacks
	{
		public XFormsApp (IntPtr ptr, JniHandleOwnership owner) : base(ptr,owner)
		{
			
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			RegisterActivityLifecycleCallbacks(this);
		}

		public void OnActivityCreated (Activity activity, Android.OS.Bundle savedInstanceState)
		{
			
		}

		public void OnActivityDestroyed (Activity activity)
		{
			
		}

		public void OnActivityPaused (Activity activity)
		{
			
		}

		public void OnActivityResumed (Activity activity)
		{
			if (Xamarin.Forms.Application.Current == null || Xamarin.Forms.Application.Current.MainPage == null)
			{
				SetOrientation(activity, ScreenOrientation.Portrait);
			}

			var navigationPage = Xamarin.Forms.Application.Current.MainPage as NavigationPage;

			if (navigationPage != null)
			{
				var orientationPage = navigationPage.CurrentPage as ISupportOrientation;

				if (orientationPage != null)
				{
					var supportedMask = ScreenOrientation.Portrait;

					foreach (var orientation in orientationPage.SupportedOrientation)
					{
						switch (orientation)
						{
						case DeviceOrientation.Portrait:
							supportedMask = ScreenOrientation.Portrait;
							break;

						case DeviceOrientation.Landscape:
							supportedMask = ScreenOrientation.Landscape;
							break;
						default:
							break;
						}
					}
					SetOrientation(activity, supportedMask);
				}
			}
		}

		void SetOrientation(Activity activity, ScreenOrientation orientation)
		{
			activity.RequestedOrientation = orientation;
		}

		public void OnActivitySaveInstanceState (Activity activity, Android.OS.Bundle outState)
		{
			
		}

		public void OnActivityStarted (Activity activity)
		{
			
		}

		public void OnActivityStopped (Activity activity)
		{
			
		}
	}
}

