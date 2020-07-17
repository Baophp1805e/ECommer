
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using FFImageLoading.Forms.Platform;
using Plugin.Badge.Droid;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using ZXing.Mobile;

namespace ECommerce.Droid
{
    [Activity(Label = "Quynhapp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Context Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Forms.SetFlags("IndicatorView_Experimental", "SwipeView_Experimental", "Expander_Experimental");
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Instance = this;
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(Application);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();
#if __ANDROID__
            MobileBarcodeScanner.Initialize(Application);
#endif
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Init(savedInstanceState);
            LoadApplication(new App(new AndroidPlatform()));
        }
        public void Init(Bundle bundle)
        {
            CachedImageRenderer.Init(true);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    class AndroidPlatform : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<IFirebaseAuthService, FirebaseAuthService>(); 
        }
    }

}