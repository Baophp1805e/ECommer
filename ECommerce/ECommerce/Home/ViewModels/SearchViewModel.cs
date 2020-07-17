using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerce.Common.Bases;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class SearchViewModel: TabbedViewModelBase
    {
        private readonly IHomeService homeService;
        readonly INavigationService navigationService;
        string textString;
        public string TextString
        {
            get => textString;
            set
            {
                textString = value;
                SearchAction(textString);
            }
        }

        public SearchViewModel(IHomeService homeService ,INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
            this.navigationService = navigationService;
        }

        ICommand _tapSearchCmd;
        public ICommand TapSearchCmd => _tapSearchCmd = _tapSearchCmd ?? new Command(tapSearchCmd);

        private async void tapSearchCmd(object obj)
        {
            var data = await homeService.FilterByKey(TextString);
            if (data != null)
                ProductModel = new ObservableCollection<ProductModel>(data);
        }
        public async void SearchAction(string key)
        {
            var data = await homeService.FilterByKey(key);
            if (data != null)
                ProductModel = new ObservableCollection<ProductModel>(data);
        }
        ICommand _tapCloseCmd;
        public ICommand TapCloseCmd => _tapCloseCmd = _tapCloseCmd ?? new Command(tapCloseCmd);

        private async void tapCloseCmd(object obj)
        {
            TextString = string.Empty;
            var data = await homeService.FilterByKey(TextString);
            if (data != null)
                ProductModel = new ObservableCollection<ProductModel>(data);
        }

        //search
        public bool IsRefesh { set; get; }
        //public ObservableCollection<StoreModel> ListStore { get; set; }

       
        ICommand _tapFilterCmd;
        public ICommand TapFilterCmd => _tapFilterCmd = _tapFilterCmd ?? new Command(tapFilterCmd);
        //ListView listView = new ListView { ItemsSource =  };
        private async void tapFilterCmd(object obj)
        {
            
        }

        public ObservableCollection<ProductModel> ProductModel { get; set; }
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            var data = await homeService.GetProductByECommerceAsync(1);
            ProductModel = new ObservableCollection<ProductModel>(data);
        }

        //public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        //{
        //    var data = await homeService.GetProductByECommerceAsync(1);
        //    ListProduct = new ObservableCollection<ProductModel>(data);
        //}

        //pass data
        ICommand _tapItem;
        public ICommand TapItem => _tapItem = _tapItem ?? new Command<StoreModel>(ExcuteTapItem);

        private async void ExcuteTapItem(StoreModel obj)
        {
            var param = new NavigationParameters();
            if (obj != null)
            {
                param.Add(NavigationKey.DetailKey, obj);
            }

            await NavigationService.NavigateAsync(Routes.Details,param);
        }

        ICommand _searchTyped;
        public ICommand TextTypedCmd => _searchTyped = _searchTyped ?? new Command(ExcuteSearchTyped);

        private void ExcuteSearchTyped(object obj)
        {
            
        }
    }
}
