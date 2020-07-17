using ECommerce.Common.Controls;
using ECommerce.Common.HelperDic;
using ECommerce.Customers.ViewModels;
using ECommerce.Customers.Views;
using ECommerce.Home.Services;
using ECommerce.Home.ViewModels;
using ECommerce.Home.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ECommerce
{
    public partial class App : PrismApplication
    {
            const string ResourceId = "ECommerce.Localization.AppResources";
            static ResourceManager _resourceManager;
            public static ResourceManager ResourceManager => _resourceManager = _resourceManager ?? new ResourceManager(ResourceId, typeof(App).GetTypeInfo().Assembly);


            public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
            {
                var culture = new CultureInfo("en-US");

                //Culture for any thread
                CultureInfo.DefaultThreadCurrentCulture = culture;

                //Culture for UI in any thread
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                // AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;
            }

            protected override async void OnInitialized()
            {
           
                InitializeComponent();
              //  var help = Helper.Instance;
                //MainPage = new NavigationPageGradientHeader(new HomeTabbedPage())
                //{
                //    LeftColor = Color.FromHex("#109F8D"),
                //    RightColor = Color.FromHex("#36ED81")
                //};
                VersionTracking.Track();
                var result = await NavigationService.NavigateAsync(Routes.Landing);

            }
            protected override void RegisterTypes(IContainerRegistry containerRegistry)
            {
                RegisterExternalService(containerRegistry);
                RegisterForNavigation(containerRegistry);
                RegisterService(containerRegistry);
                RegisterDialogs(containerRegistry);
            }
            private void RegisterForNavigation(IContainerRegistry containerRegistry)
            {
                containerRegistry.RegisterForNavigation<NavigationPageGradientHeader>();
                containerRegistry.RegisterForNavigation<LoginDetailsPage, LoginViewModel>();
                containerRegistry.RegisterForNavigation<LandingPage, LandingViewModel>();
                containerRegistry.RegisterForNavigation<HomeTabbedPage, HomeTabbedViewModel>();
                containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
                containerRegistry.RegisterForNavigation<DealsPage, DealsViewModel>();
                containerRegistry.RegisterForNavigation<ShoppingCartPage, ShoppingCardViewModel>();
                containerRegistry.RegisterForNavigation<TagsPage, TagsViewModel>();
                containerRegistry.RegisterForNavigation<ProfilePage, ProfileViewModel>();
                containerRegistry.RegisterForNavigation<SearchPage, SearchViewModel>();
                containerRegistry.RegisterForNavigation<QuickNavigatationPage, QuickNavigationViewModel>();
                containerRegistry.RegisterForNavigation<ProductDetailsPage, ProductDetailsViewModel>();
                containerRegistry.RegisterForNavigation<ChatSupportPage, ChatViewModel>();
                containerRegistry.RegisterForNavigation<CompleteOrderPage, CompleteOrderViewModel>();
                containerRegistry.RegisterForNavigation<FlagPage, FlagViewModel>();
            }

            private void RegisterService(IContainerRegistry containerRegistry)
            {
                containerRegistry.Register<IHomeService, HomeService>();
            }

            private void RegisterDialogs(IContainerRegistry containerRegistry)
            {
            }

      
     
            private void RegisterExternalService(IContainerRegistry containerRegistry)
            {
            }
        }
        public  sealed partial class Routes
        {
            static readonly string navigation = nameof(NavigationPageGradientHeader);
            public static readonly Uri Login = new Uri($"{nameof(LoginDetailsPage)}", UriKind.Relative);
            public static readonly Uri Landing = new Uri($"/{navigation}/{nameof(LandingPage)}", UriKind.Absolute);
            public static readonly Uri Flag = new Uri($"/{navigation}/{nameof(FlagPage)}", UriKind.Absolute);
            public static readonly Uri HomeTabbed = new Uri($"/{navigation}/{nameof(HomeTabbedPage)}", UriKind.Absolute);
            public static readonly Uri Search = new Uri($"{nameof(SearchPage)}", UriKind.Relative);
            public static readonly Uri QuickNavi = new Uri($"{nameof(QuickNavigatationPage)}", UriKind.Relative);
            public static readonly Uri Details = new Uri($"{nameof(ProductDetailsPage)}", UriKind.Relative);
            public static readonly Uri Chat = new Uri($"{nameof(ChatSupportPage)}", UriKind.Relative);
            public static readonly Uri CompleteOrder = new Uri($"{nameof(CompleteOrderPage)}", UriKind.Relative);
        }

        public class NavigationKey
        {
            //public const string ExistUser = "_EdutalkStudent_ExistUser_Key_";
            public const string QuickNavi = "QuickNavi";
            public const string DetailKey = "DetailKey";
        }
}
