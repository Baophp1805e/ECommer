using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerce.Common.Bases;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class QuickNavigationViewModel: TabbedViewModelBase
    {
        readonly IHomeService homeService;
        readonly INavigationService navigationService;

        public QuickNavigationViewModel(IHomeService homeService ,INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
            this.navigationService = navigationService;
        }

        public ObservableCollection<StoreModel> ListStore { get; set; }
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            var NaviMode = parameters.GetNavigationMode();
            if (NaviMode == NavigationMode.New )
            {
                var data = await homeService.GetStoreByECommerceAsync(1);
                ListStore = new ObservableCollection<StoreModel>(data);
            }
            
        }

        //get data Home
        public StoreModel storeModel { get; set; }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var navMode = parameters.GetNavigationMode();
            if (navMode == NavigationMode.New)
            {
                storeModel = parameters.GetValue<StoreModel>(NavigationKey.QuickNavi);
            }

        }

        ICommand _tapItemCollectionView;
        public ICommand TapItemCollectionView => _tapItemCollectionView = _tapItemCollectionView ?? new Command<ProductModel>(ExcuteTapItem);

        private async void ExcuteTapItem(ProductModel obj)
        {
            var param = new NavigationParameters();
            if (obj != null)
            {
                param.Add(NavigationKey.DetailKey, obj);
            }
            var result = await NavigationService.NavigateAsync(Routes.Details, param);
        }

        ICommand _tapCloseCommand;
        public ICommand TapCloseCommand => _tapCloseCommand = _tapCloseCommand ?? new Command(ExcuteTapClose);

        private async void ExcuteTapClose(object obj)
        {
            await NavigationService.GoBackAsync();
        }
    }
}
