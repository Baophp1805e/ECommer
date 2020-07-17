using CoreAnimation;
using CoreGraphics;
using ECommerce.Common.Controls;
using ECommerce.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPageGradientHeader), typeof(NavigationPageGradientHeaderRenderer))]
namespace ECommerce.iOS.Renderer
{
    public class NavigationPageGradientHeaderRenderer : NavigationRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var statusFrame = UIApplication.SharedApplication.StatusBarFrame;
            var navigationFrame = NavigationBar.Frame;

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Frame = new CGRect(0, 0, navigationFrame.Width, statusFrame.Height + navigationFrame.Height);
            gradientLayer.Colors = new CGColor[] { Color.FromHex("#A642DC").ToCGColor(), Color.FromHex("#3778E5").ToCGColor() };
           // gradientLayer.StartPoint = new CGPoint(1.0, 0.0);
//            gradientLayer.EndPoint = new CGPoint(0.0, 1.0);

            UIGraphics.BeginImageContext(gradientLayer.Frame.Size);
            gradientLayer.RenderInContext(UIGraphics.GetCurrentContext());
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            NavigationBar.SetBackgroundImage(image, UIBarMetrics.Default);
        }
    }
}