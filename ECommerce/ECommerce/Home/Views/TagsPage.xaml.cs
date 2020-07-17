using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ECommerce.Home.Views
{
    public partial class TagsPage : ContentPage
    {
        public TagsPage()
        {
            InitializeComponent();
        }

        async void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Favorite invoked.", "OK");
        }

        async void OnShareSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Share invoked.", "OK");
        }

        async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Delete invoked.", "OK");
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var fr = sender as Frame;
            if (fr.BackgroundColor == Color.White)
            {
                fr.BackgroundColor = Color.OrangeRed;
            }
            else fr.BackgroundColor = Color.White;
    }
    }
}
