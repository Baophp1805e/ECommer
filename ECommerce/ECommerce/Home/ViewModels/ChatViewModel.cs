using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerce.Common.Bases;
using ECommerce.Home.Models;
using ECommerce.Home.Services;
using ECommerce.Home.Views;
using Prism.Navigation;
using Xamarin.Forms;

namespace ECommerce.Home.ViewModels
{
    public class ChatViewModel: TabbedViewModelBase
    {
        readonly IHomeService homeService;

        public ChatViewModel(IHomeService homeService, INavigationService navigationService) : base(navigationService)
        {
            this.homeService = homeService;
        }

        public ObservableCollection<ChatModel> ListChat { get; set; }
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            var data = await homeService.GetChatByByECommerceAsync("1");
            ListChat = new ObservableCollection<ChatModel>(data);
        }

        public string TextChat { get; set; }
        ChatSupportPage current;

        ICommand tapSendCmd;
        public ICommand TapSendCmd => tapSendCmd = tapSendCmd ?? new Command(ExcuteTapSendCmd);

        private async void ExcuteTapSendCmd(object obj)
        {
            //ListChat.Add(new ChatModel {
            //    Content = TextChat,
            //    DateCreated = "5m ago",
            //    User = new Customers.Model.CustomerModel() { NameCustomer = "Martha Richards", Avatar = "ic_avatar_shop2" }
            //});
            if (TextChat == null)
            {
                return;
            }
            else
            {
                var chat = new ChatModel()
                {
                    User = new Customers.Model.CustomerModel() { NameCustomer = "Martha Richards", Avatar = "ic_avatar_shop2" }
               ,
                    Content = TextChat,
                    DateCreated = "Just now"
                };
                ListChat.Add(chat);
              //  current.ScrollToEnd(chat);
                TextChat = string.Empty;
            }
           
        }

        ICommand _invokedCmd;
        public ICommand InvokeCmd => _invokedCmd = _invokedCmd ?? new Command<ChatModel>(ExcuteInvokedCmd);

        private void ExcuteInvokedCmd(ChatModel obj)
        {
            ListChat.Remove(obj);
            //var index = ListChat.IndexOf(obj);
            //ListChat.RemoveAt(index);
            //var remove = ListChat.Where(x => x.Id == index).Single();
            //ListChat.Remove(remove);
        }
    }
}
