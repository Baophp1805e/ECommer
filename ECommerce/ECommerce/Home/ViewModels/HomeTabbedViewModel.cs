using System;
using System.Windows.Input;
using ECommerce.Common.Bases;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class HomeTabbedViewModel: TabbedViewModelBase
    {
        public HomeTabbedViewModel(INavigationService navigationService): base(navigationService)
        {
        }

        ICommand _tapSearchCmd;
        public ICommand TapSearchCmd => _tapSearchCmd = _tapSearchCmd ?? new Command(tapSearchCmd);

        private async void tapSearchCmd(object obj)
        {
          var result =  await NavigationService.NavigateAsync(Routes.Search);
        }

        ICommand _tapNext;
        public ICommand TapNext => _tapNext = _tapNext ?? new Command(tapNext);

        private async void tapNext(object obj)
        {
            var result = await NavigationService.NavigateAsync(Routes.CompleteOrder);
        }
    }
}
