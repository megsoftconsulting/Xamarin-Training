using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace XForms.Droid
{
	[Activity (Label = "XForms.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;

			global::Xamarin.Forms.Forms.Init (this, bundle);

			ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();

			LoadApplication (new XFormsApp ());
		}

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            if (Xamarin.Forms.Application.Current == null || Xamarin.Forms.Application.Current.MainPage == null)
            {
                return UIInterfaceOrientationMask.Portrait;
            }

            var navigationPage = Xamarin.Forms.Application.Current.MainPage as NavigationPage;

            if (navigationPage != null)
            {
                var orientationPage = navigationPage.CurrentPage as ISupportOrientation;

                if (orientationPage != null)
                {
                    UIInterfaceOrientationMask supportedMask = new UIInterfaceOrientationMask();

                    foreach (var orientation in orientationPage.SupportedOrientation)
                    {
                        switch (orientation)
                        {
                            case DeviceOrientation.Portrait:
                                supportedMask |= UIInterfaceOrientationMask.Portrait;
                                break;

                            case DeviceOrientation.Landscape:
                                supportedMask |= UIInterfaceOrientationMask.Landscape;
                                break;

                            default:
                                break;
                        }
                    }
                    return supportedMask;
                }
            }
            return UIInterfaceOrientationMask.Portrait;
        }
    }
}

