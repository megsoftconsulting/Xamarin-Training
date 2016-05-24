﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

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
	}
}

