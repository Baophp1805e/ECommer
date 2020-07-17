using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using ECommerce.Common.HelperDic;
using Prism;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace ECommerce.Common.Bases
{
    public class ViewModelBase : BindableBase, INavigationAware, IPageLifecycleAware, IInitialize, IDestructible
    {

        readonly INavigationService navigationService;
        public INavigationService NavigationService => navigationService;
        public string Title { set; get; }
        private TittleLanguage titleLanguage;
        public TittleLanguage TitleLanguage
        {
            get => titleLanguage;
            set { SetProperty(ref titleLanguage, value); }
        }
        public ViewModelBase(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            if (TitleLanguage == null)
                TitleLanguage = Helper.Instance.LangOpt;

        }

        public virtual void Destroy()
        {

        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        bool _loaded;

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            OnNavigatedToAsync(parameters).SafeFireAndForget();
            if (!_loaded)
            {
                _loaded = true;
                InitAsync(parameters).SafeFireAndForget();
            }
        }

        public virtual async Task InitAsync(INavigationParameters parameters)
        {

        }

        public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            return Task.Run(() => { });
        }



        public void Navigate(string route)
        {
            navigationService.NavigateAsync(route);
        }
        public void Navigate(Uri route)
        {
            navigationService.NavigateAsync(route);
        }
    }
    public class ViewModelTabBase : BindableBase, IActiveAware
    {
        bool isActive;
        public bool IsActive { get => isActive; set { SetProperty(ref isActive, value, TabActiveChanged); } }

        public virtual void TabActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler IsActiveChanged;
        public INavigationService navigationService;
        public ViewModelTabBase(INavigationService _navigationService)
        {
            navigationService = _navigationService;
        }
    }
}
