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
	}
}

