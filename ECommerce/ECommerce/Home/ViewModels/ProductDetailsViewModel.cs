using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerce.Common.Bases;
using ECommerce.Common.HelperDic;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class ProductDetailsViewModel: TabbedViewModelBase
    {
        private readonly IHomeService homeService;
        private readonly INavigationService navigationService;

        public ProductDetailsViewModel(IHomeService homeService, INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
            this.navigationService = navigationService;
        }

        ObservableCollection<StoreModel> _listStore;
        public ObservableCollection<StoreModel> ListStore { get { return _listStore; } set { SetProperty(ref _listStore, value); } }
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
                var data = await homeService.GetStoreByECommerceAsync(1);
                ListStore = new ObservableCollection<StoreModel>(data);
        }

        //pass data home
        public ProductModel ProductModel { get; set; }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var navMode = parameters.GetNavigationMode();
            if (navMode == NavigationMode.New)
            {
               ProductModel = parameters.GetValue<ProductModel>(NavigationKey.DetailKey);
               Store = ListStore.FirstOrDefault(x => x.Id == ProductModel.IdStore);
            }
            
        }

        ICommand _tapAsk;
        public ICommand TapAsk => _tapAsk = _tapAsk ?? new Command(ExcuteTapAsk);

        private async void ExcuteTapAsk(object obj)
        {
            await NavigationService.NavigateAsync(Routes.Chat);
        }

        //pass data Search page
        //public ProductModel storeModel { get; set; }
        //public override void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    base.OnNavigatedTo(parameters);
        //    storeModel = parameters.GetValue<StoreModel>(NavigationKey.DetailKey);
        //}
        ICommand _tapPurchaseCmd;
        public ICommand TapPurchaseCmd => _tapPurchaseCmd = _tapPurchaseCmd ?? new Command(TapPurchase);
        public ProductModel Product { set; get; }
        public StoreModel Store { set; get; }

        private async void TapPurchase(object obj)
        {
            Help.Instance.AddProductToCart(ProductModel, Store);
            await NavigationService.GoBackToRootAsync() ;
        }
    }
}
