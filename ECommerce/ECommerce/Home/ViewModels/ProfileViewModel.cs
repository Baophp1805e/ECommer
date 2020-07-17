using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ECommerce.Common.Bases;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using Prism.Navigation;

namespace ECommerce.Home.ViewModels
{
    public class ProfileViewModel : TabbedViewModelBase
    {
        readonly IHomeService homeService;

        public ProfileViewModel(IHomeService homeService, INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
        }

        public ObservableCollection<OrderModel> ListStore { get; set; }
        public override async void RaisePropertyChanged()
        {
            var data = await homeService.GetOrderByECommerceAsync(1);
            ListStore = new ObservableCollection<OrderModel>(data);
        }
    }
}
