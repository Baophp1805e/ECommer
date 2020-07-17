using FFImageLoading.Forms.Platform;
using Foundation;
using Plugin.Badge.iOS;
using Prism;
using Prism.Ioc;
using UIKit;
using Xamarin.Forms;

namespace ECommerce.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.SetFlags("SwipeView_Experimental", "CarouselView_Experimental", "IndicatorView_Experimental", "Expander_Experimental");

            global::Xamarin.Forms.Forms.Init();
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();
            Initilinization(app, options);
           
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
        public void Initilinization(UIApplication app, NSDictionary options)
        {
            CachedImageRenderer.Init();
        }
    }
    class IOSPlatform : IPlatformInitializer
    {
        public static IOSPlatform Platform => new IOSPlatform();

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
