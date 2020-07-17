using System;
using System.Windows.Input;
using ECommerce.Common.Bases;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Customers.ViewModels
{
    public class LandingViewModel: ViewModelBase
    {
        readonly INavigationService navigationService;
        public LandingViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navigationService = navigationService;
        }

        ICommand _loginWithFBCmd;
        public ICommand LoginWithFBCmd => _loginWithFBCmd = _loginWithFBCmd ?? new Command(tapLoginWithFBCmd);

        private async void tapLoginWithFBCmd(object obj)
        {
            await NavigationService.NavigateAsync(Routes.Login);
        }

        ICommand _tapLoginCmd;
        public ICommand TapLoginCmd => _tapLoginCmd = _tapLoginCmd ?? new Command(tapLoginCmd);

        private async void tapLoginCmd(object obj)
        {
            await NavigationService.NavigateAsync(Routes.Login);
        }

        ICommand _tapSignupCmd;
        public ICommand TapSignupCmd => _tapSignupCmd = _tapSignupCmd ?? new Command(tapSignupCmd);

        private async void tapSignupCmd(object obj)
        {
            await NavigationService.NavigateAsync(Routes.Login);
        }
    }
}
