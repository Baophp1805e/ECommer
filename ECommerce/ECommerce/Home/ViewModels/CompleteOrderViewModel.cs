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
    public class CompleteOrderViewModel: TabbedViewModelBase
    {
        readonly IHomeService homeService;
        public int Position { set; get; } = 0;

        //bool _isVisiblePersonalAndShipping;
        //public bool IsVisiblePersonalAndShipping { get { return _isVisiblePersonalAndShipping; } set { SetProperty(ref _isVisiblePersonalAndShipping, value); } }

        //bool _isvisibleReviewAndPurchase;
        //public bool IsvisibleReviewAndPurchase { get { return _isvisibleReviewAndPurchase; } set { SetProperty(ref _isvisibleReviewAndPurchase, value); } }

        public CompleteOrderViewModel(IHomeService homeService, INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
        }

        //public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        //{
        //    IsVisiblePersonalAndShipping = true;
        //    IsvisibleReviewAndPurchase = false;
        //}

        ICommand _tapNext;
        public ICommand TapNext => _tapNext = _tapNext ?? new Command(tapNext);

        private async void tapNext(object obj)
        {
            //var result = await NavigationService.NavigateAsync(Routes.CompleteOrder);
            //if(Position == 0)
            //{
            //    IsVisiblePersonalAndShipping = true;
            //    IsvisibleReviewAndPurchase = false;
            //    Position = 1;
            //}
            //else
            //{
            //    Position = 0;
            //    IsvisibleReviewAndPurchase = true;
            //    IsVisiblePersonalAndShipping = false;
            //}
        }

        bool statusView { get; set; } = true;

        //Method
        public ViewMethod StatusView { get; set; } = ViewMethod.View1;

        Command _ViewMethod;
        public ICommand StatusViewComplete => _ViewMethod = _ViewMethod ?? new Command(ExcuteViewMethod);

        private void ExcuteViewMethod(object obj)
        {
            statusView = true;
        }

        ICommand _swipeLeft;
        public ICommand SwipeLeft => _swipeLeft = _swipeLeft ?? new Command(ExcuteSwipeLeft);

        private void ExcuteSwipeLeft(object obj)
        {
        }
        ICommand _swipeRight;
        public ICommand SwipeRight => _swipeRight = _swipeRight ?? new Command(ExcuteSwipeRight);

        private void ExcuteSwipeRight(object obj)
        {
        }

        public ObservableCollection<ProductModel> getProductModels { get; set; }
        public override  async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var data = await homeService.GetProductByECommerceAsync(1);
            getProductModels = new ObservableCollection<ProductModel>(data);
        }
    }
}
