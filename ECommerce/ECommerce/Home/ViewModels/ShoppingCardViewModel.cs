using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ECommerce.Common.Bases;
using ECommerce.Common.HelperDic;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class ShoppingCardViewModel: ViewModelTabBase
    {
        private readonly IHomeService homeService;

        public ShoppingCardViewModel(IHomeService homeService ,INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
        }

        public override void TabActiveChanged()
        {
            base.TabActiveChanged();
            GetData();
        }

        private void GetData()
        {
            var data = Help.Instance.GroupedCart;
            if(data != null)
            {
                getProductModels = new ObservableCollection<GroupedCartModel>(data);
            }
        }

        public PickupButton Pick { get; set; } = PickupButton.CurrentOrder;
        ICommand clickButton;
        public ICommand BtnCommand => clickButton = clickButton ?? new Command<PickupButton>(ExcuteClickButton);

        private void ExcuteClickButton(PickupButton obj)
        {
            Pick = obj;
        }

        public ObservableCollection<GroupedCartModel> getProductModels { get; set; }
        //public override async void RaisePropertyChanged()
        //{
           
        //}
    }
}
