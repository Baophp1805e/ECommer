using System;
using System.Windows.Input;
using ECommerce.Common.Bases;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Customers.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        readonly INavigationService navigationService;
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navigationService = navigationService;
        }

        ICommand _tapCloseCmd;
        public ICommand TapCloseCmd => _tapCloseCmd = _tapCloseCmd ?? new Command(tapCloseButton);

        private async void tapCloseButton(object obj)
        {
            await NavigationService.GoBackToRootAsync();
        }

        Command _tapLoginCmd;
        public ICommand TapLoginCmd => _tapLoginCmd = _tapLoginCmd ?? new Command(tapLoginCmd);

        private async void tapLoginCmd(object obj)
        {
            var result = await NavigationService.NavigateAsync(Routes.HomeTabbed);
        }

        Command _tapRegisterCmd;
        public ICommand TapRegisterCmd => _tapRegisterCmd = _tapRegisterCmd ?? new Command(tapRegisterCmd);

        private async void tapRegisterCmd(object obj)
        {
           var result= await NavigationService.NavigateAsync(Routes.HomeTabbed);
        }
    }
}
