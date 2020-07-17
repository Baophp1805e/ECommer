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
    public class DealsViewModel: TabbedViewModelBase
    {
        readonly IHomeService homeService;

        public DealsViewModel(IHomeService homeService, INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
        }

        public ObservableCollection<TagsModel> dealsModels { get; set; }

        public override async void RaisePropertyChanged()
        {
            var data = await homeService.GetDealByECommerceAsync(1);
            dealsModels = new ObservableCollection<TagsModel>(data);
        }

        //Trigger
        public PickupButton Pick { get; set; } = PickupButton.MostPopular;
        ICommand btnCommand;
        public ICommand BtnCommand => btnCommand = btnCommand ?? new Command<PickupButton>(PickupAction);

        private void PickupAction(PickupButton pick)
        {
            Pick = pick;
        }
    }
}
