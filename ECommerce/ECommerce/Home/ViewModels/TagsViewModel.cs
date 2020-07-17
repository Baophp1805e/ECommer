using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ECommerce.Common.Bases;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class TagsViewModel : ViewModelTabBase
    {
        public TagsViewModel(IHomeService homeService, INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
            Tags = new ObservableCollection<TagModel>();
        }

        public override void TabActiveChanged()
        {
            base.TabActiveChanged();
            setData();
        }
        public TapTags tapTags { get; set; } = TapTags.Tag1;
        ICommand tapTagCommand;
        private readonly IHomeService homeService;

        public ICommand TapTagCommand => tapTagCommand = tapTagCommand ?? new Command<TapTags>(ExcuteTapTag);

        private void ExcuteTapTag(TapTags obj)
        {
            tapTags = obj;
        }

        private void setData()
        {
            var random = new Random();
            for (var i = 0; i < 20; i++)
            {
                Tags.Add(new TagModel
                {
                    SizeTag = random.Next(40, 120),
                    Title = "bao quynh",
                    IdTag = 1
                });
            }
        }


        public ObservableCollection<TagModel> Tags { get; set; }

        ICommand tapTagCmd;
        public ICommand TapTagCmd => tapTagCmd = tapTagCmd ?? new Command(ExcuteTapTag);

        private void ExcuteTapTag(object obj)
        {
           
        }


        //public override async void RaisePropertyChanged()
        //{

        //    var data = await homeService.GetTagsByECommerce(1);
        //    Tags = new ObservableCollection<TagModel>(data);
        //}
    }
}
