using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Home.Models;
using ECommerce.Home.ViewModels;
using Xamarin.Forms;

namespace ECommerce.Home.Views
{
    public partial class ChatSupportPage : ContentPage
    {
        public ChatSupportPage()
        {
            InitializeComponent();
        }

        void SwipeItem_Invoked(System.Object sender, System.EventArgs e)
        {
        }        //ChatViewModel model;
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (model == null)
        //        model = this.BindingContext as ChatViewModel;
        //}

        //public void ScrollToEnd(ChatModel chatModel)
        //{
        //    listview.ScrollTo(model.ListChat.LastOrDefault(), ScrollToPosition.End, true);
        //}
    }
}
