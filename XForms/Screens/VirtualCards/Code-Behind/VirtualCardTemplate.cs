using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XForms.Screens.VirtualCards.Code_Behind
{
    public class VirtualCardTemplate : StackLayout
    {
        public VirtualCardTemplate()
        {
            this.Children.Add(CreateContent());
        }

        private View CreateContent()
        {
            var layout = new RelativeLayout
            {
                BackgroundColor = Color.Transparent,
                Children =
                {
                    {
                     new StackLayout
                     {
                         BackgroundColor = Color.White,
                         Children =
                         {
                                 CreateCardContent()
                         }
                     }  ,
                        Constraint.RelativeToParent(p => 20),
                        Constraint.RelativeToParent(p => 40),
                        Constraint.RelativeToParent(p => p.Width - 40),
                        Constraint.RelativeToParent(p => p.Height - 80)
                    }
                }
            };

            return layout;
        }

        private View CreateCardContent()
        {
            var topBoxView = new BoxView
            {
                Color = Color.FromHex("#032972")
            };

            var logo = new Image
            {
                Source = "http://bower.io/img/bower-logo.png",
                Aspect = Aspect.AspectFit,
                WidthRequest = 40,
                HeightRequest = 40,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            var identificatioNumberHeader = new Label
            {
                FontSize = 12,
                TextColor = Color.White,
                Text = "Identification #"
            };

            var identificatioNumber = new Label
            {
                FontSize = 16,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                Text = "024014010"
            };

            var topLayout = new StackLayout
            {
                BackgroundColor = Color.FromHex("032972"),
                Padding = new Thickness(20,10,20,10),
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    logo,
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.End,
                        Children =
                        {
                            identificatioNumberHeader,
                            identificatioNumber
                        }
                    }
                }
            };
            
            var profile = new CircleImage
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 80,
                HeightRequest = 80,
                BorderColor = Color.Transparent,
                Source = "https://scontent-ord1-1.xx.fbcdn.net/v/t1.0-9/13321740_809776965833621_3813115539637266533_n.jpg?oh=dfdc55d25b718573b5046f7b7c5dd5fc&oe=57D952DA"
            };

            var memberName = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = "Luis Nunez",
                TextColor = Color.FromHex("032972"),
                FontSize = 18,
                FontAttributes = FontAttributes.Bold
            };

            var qrCode = new Image
            {
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 80,
                HeightRequest = 80,
                Source = "http://qrcode.tec-it.com/API/QRCode?data=QR-Code+Generator+by+TEC-IT"
            };

            var bodyContent = new StackLayout
            {
                Spacing = 40,
                Padding = 10,
                Children =
                {
                    new StackLayout
                    {
                        Children =
                        {
                            profile,
                            memberName
                        }
                    },
                    qrCode
                }
            };
            
            return new StackLayout
            {
                Children =
                {
                    topLayout,
                    bodyContent
                }
            };
        }
    }
}
