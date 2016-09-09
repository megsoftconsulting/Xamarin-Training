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
                        Constraint.RelativeToParent(p => 20),  // Y
                        Constraint.RelativeToParent(p => 10),  // X
                        Constraint.RelativeToParent(p => p.Width - 40),
                        Constraint.RelativeToParent(p => p.Height - 40)
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
                Source = "http://www.megsoftconsulting.com/newwpsite/wp-content/uploads/2015/11/Megsoft-logo-sizenew-blanco.png",
                IsOpaque = true,
                Aspect = Aspect.AspectFit,
                WidthRequest = 80,
                //HeightRequest = 40,
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
                HorizontalOptions = LayoutOptions.StartAndExpand,
                WidthRequest = 80,
                HeightRequest = 80,
                BorderColor = Color.Transparent,
                Source = "http://claudiosanchez.net/wp-content/uploads/2016/08/Claudio.jpg",
                IsOpaque = true
                    
            };

            var memberName = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Text = "Claudio Sanchez",
                TextColor = Color.FromHex("032972"),
                FontSize = 18,
                FontAttributes = FontAttributes.Bold
            };

            var qrCode = new Image
            {
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                WidthRequest = 80,
                HeightRequest = 80,
                Source = "http://qrcode.tec-it.com/API/QRCode?data=QR-Code+Generator+by+TEC-IT",
                IsOpaque = true
            };

            var bodyContent = new StackLayout
            {
                Spacing = 0,
                Padding = 10, 
                Orientation = StackOrientation.Horizontal,
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
