using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerce.Common.Bases;
using ECommerce.Common.HelperDic;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class FlagViewModel : ViewModelBase
    {
        private readonly IHomeService homeService;
        private readonly INavigationService navigationService;
        public ObservableCollection<FlagModel> FlagModels { get; set; }

        public FlagViewModel(IHomeService homeService, INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
            this.navigationService = navigationService;
            
        }



        public async override Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            var data = await homeService.GetFlagAsync();
            FlagModels = new ObservableCollection<FlagModel>(data);
        }

        public string nameFlag { get; set; } = "EN";
        public string imageFlag { get; set; } = "AMERICAN.png";
        public bool isExpand { get; set; } = false;

        ICommand _tapItem;
        public ICommand TapItem => _tapItem = _tapItem ?? new Command<FlagModel>(ExcuteTapItem);
        private void ExcuteTapItem(FlagModel obj)
        {
            nameFlag = obj.NameFlag;
            imageFlag = obj.ImageFlag;
            isExpand = false;
            switch (nameFlag)
            {
                case "EN":
                    Helper.Instance.ChangeLanguage("en.json");
                  //  Preferences.Set("language", "en-US");
                    break;
                case "KO":
                    Helper.Instance.ChangeLanguage("ko.json");
                  //  Preferences.Set("language", "ko-KR ");
                    break;
                case "JP":
                    Helper.Instance.ChangeLanguage("jp.json");
                   // Preferences.Set("language", "ja-JP");
                    break;
                case "CN":
                  //  Preferences.Set("language", "zh-CN");
                    break;

            }
        }
    }
}
