using CustomLayouts;
using CustomLayouts.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XForms.Services;

namespace XForms.Screens.VirtualCards.Code_Behind
{
    public class VirtualCardScreen : ContentPage, ISupportOrientation
    {
        public VirtualCardScreen()
        {
            Content = CreateContent();

            BindingContext = new VirtualCardViewModel();
        }

        public DeviceOrientation[] SupportedOrientation
        {
            get
            {
                return new[] { DeviceOrientation.Landscape };
            }
        }

        private View CreateContent()
        {
            var publicityCarousel = new CarouselLayout
            {
                BackgroundColor = Color.FromHex("f6f6f6"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                IndicatorStyle = CarouselLayout.IndicatorStyleEnum.Dots,
                ItemTemplate = new DataTemplate(typeof(VirtualCardTemplate))
            };
            publicityCarousel.SetBinding<VirtualCardViewModel>(CarouselLayout.ItemsSourceProperty, m => m.Property);
            publicityCarousel.SetBinding<VirtualCardViewModel>(CarouselLayout.SelectedItemProperty, m => m.Selected);

            var pagerIndicator = new PagerIndicatorDots() { DotSize = 8, DotColor = Color.White };

            pagerIndicator.SetBinding<VirtualCardViewModel>(PagerIndicatorDots.ItemsSourceProperty, m => m.Property);

            pagerIndicator.SetBinding<VirtualCardViewModel>(PagerIndicatorDots.SelectedItemProperty, m => m.Selected);

            var publicity = new RelativeLayout
            {
                Children =
                {
                    {
                        publicityCarousel,
                        Constraint.RelativeToParent(p => 0),
                        Constraint.RelativeToParent(p => 0),
                        Constraint.RelativeToParent(p => p.Width),
                        Constraint.RelativeToParent(p => p.Height)
                    },
                    {
                        pagerIndicator,
                        Constraint.RelativeToParent(p => (p.Width / 2 - pagerIndicator.Width / 2)),
                        Constraint.RelativeToParent(p => p.Height - 16)
                    }
                }
            };

            publicity.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Width" || e.PropertyName == "Height")
                {
                    publicity.ForceLayout();
                }
            };

            return publicityCarousel;
        }
    }
}
