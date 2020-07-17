//using System;
//using System.Drawing;
//using Android.Content;
//using Android.Graphics.Drawables;
//using ECommerce.Common.Controls;
//using ECommerce.Droid;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
//using Xamarin.Forms.Platform.Android.AppCompat;

//[assembly: ExportRenderer(typeof(NavigationPageGradientHeader), typeof(NavigationPageGradientHeaderRenderer))]

//namespace ECommerce.Droid
//{
//    public class NavigationPageGradientHeaderRenderer : NavigationRenderer
//    {
//        public NavigationPageGradientHeaderRenderer(Context context) : base(context)
//        {

//        }
//        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
//        {
//            base.OnElementChanged(e);

//            //run once when element is created
//            if (e.OldElement != null || Element == null)
//            {
//                return;
//            }

//            var control = (NavigationPageGradientHeader)this.Element;
//            var context = (MainActivity)this.Context;

//            context.ActionBar.SetBackgroundDrawable(new GradientDrawable(GradientDrawable.Orientation.RightLeft, new int[] { control.RightColor.ToAndroid(), control.LeftColor.ToAndroid() }));
//        }
//    }
//}