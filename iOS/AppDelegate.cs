using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using XForms.Services;
using Xamarin.Forms;

namespace XForms.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			ImageCircle.Forms.Plugin.iOS.ImageCircleRenderer.Init();

			LoadApplication (new XFormsApp());

			return base.FinishedLaunching (app, options);
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

