using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerce.Common.Bases;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class HomeViewModel: TabbedViewModelBase
    {
        readonly IHomeService homeService;
        

        public HomeViewModel(IHomeService homeService, INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
        }

        //Trigger Button
        public PickupButton Pick { set; get; } = PickupButton.MostPopular;

        Command btnCommand;
        public Command BtnCommand => btnCommand = btnCommand ?? new Command<PickupButton>(PickupAction);

        private void PickupAction(PickupButton pick)
        {
            Pick = pick;
        }

        
        

        //TapAvatar
        ICommand _tapAvatarCmd;

        public ICommand TapAvatarCmd => _tapAvatarCmd = _tapAvatarCmd ?? new Command(tapAvatarCmd);

        private async void tapAvatarCmd(object obj)
        {
            var param = new NavigationParameters();
            if (obj != null)
            {
                param.Add(NavigationKey.QuickNavi, obj);
            }
            await NavigationService.NavigateAsync(Routes.QuickNavi, param);
        }

        public ObservableCollection<StoreModel> ListStore { get; set; }
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            var data = await homeService.GetStoreByECommerceAsync(1);
            ListStore = new ObservableCollection<StoreModel>(data);
        }
    }
}
