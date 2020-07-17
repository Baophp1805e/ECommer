using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace ECommerce.Common.Controls
{
    public class NavigationPageGradientHeader : Xamarin.Forms.NavigationPage
    {
        public NavigationPageGradientHeader(Xamarin.Forms.Page root) : base(root)
        {
            BarTextColor = Color.White;
            // On<iOS>().SetHideNavigationBarSeparator(true);
            //On<iOS>()
            //    .SetStatusBarTextColorMode(Xamarin.Forms.PlatformConfiguration.iOSSpecific.StatusBarTextColorMode.MatchNavigationBarTextLuminosity);
        }

        public static readonly BindableProperty RightColorProperty =
          BindableProperty.Create(propertyName: nameof(RightColor),
              returnType: typeof(Color),
              declaringType: typeof(NavigationPageGradientHeader),
              defaultValue: Color.Accent);

        public static readonly BindableProperty LeftColorProperty =
           BindableProperty.Create(propertyName: nameof(LeftColor),
               returnType: typeof(Color),
               declaringType: typeof(NavigationPageGradientHeader),
               defaultValue: Color.Accent);

        public Color RightColor
        {
            get { return (Color)GetValue(RightColorProperty); }
            set { SetValue(RightColorProperty, value); }
        }

        public Color LeftColor
        {
            get { return (Color)GetValue(LeftColorProperty); }
            set { SetValue(LeftColorProperty, value); }
        }
    }
}
