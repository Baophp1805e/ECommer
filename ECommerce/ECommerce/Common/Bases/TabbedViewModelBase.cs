using System;
using Prism;
using ECommerce.Common.Bases;
using Prism.Navigation;

namespace ECommerce.Common.Bases
{
    public class TabbedViewModelBase: ViewModelBase, IActiveAware
    {
        private bool _isActive;
        public TabbedViewModelBase(INavigationService navigationService): base(navigationService)
        {
        }

        public bool IsActive
        {
            get => _isActive;
            set { SetProperty(ref _isActive, value, RaisePropertyChanged); }
        }

        public virtual void RaisePropertyChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler IsActiveChanged;
    }
}
